using FSUIPC;
using System.Media;
using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using NHotkey;
using NHotkey.WindowsForms;
using DavyKager;
using System.Reflection;
using tfm.Properties;
using tfm.Keyboard_manager;
using NLog;
using NLog.Config;
using System.Speech.Synthesis;
using System.Collections;
using System.Timers;

namespace tfm
{
    public partial class TFMMainForm : Form
    {

        
        // get a logger object for this class
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        // set up timers
        System.Timers.Timer TimerMain = new System.Timers.Timer(100);
        System.Timers.Timer TimerConnection = new System.Timers.Timer(1000);
        System.Timers.Timer TimerLowPriority = new System.Timers.Timer(1000);

        // Create a counter for the connection timer.
        private int connectionCounter = 0;



        private readonly IOSubsystem inst = new IOSubsystem();

        private readonly bool AzureSpeaking = false;

        public TFMMainForm()
        {
            InitializeComponent();
            
            // Upgrade settings from previous version.
            if (Properties.Settings.Default.SettingsRequiresUpgrade)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.SettingsRequiresUpgrade = false;
                Properties.Settings.Default.Save();
                Application.Restart();
            }
            this.trayIcon.Visible = true;
            

                        // speak a debug message via SAPI if debug mode is turned on
            if (utility.DebugEnabled)
            {
                Tolk.PreferSAPI(true);
                Tolk.Output("Debug mode");
                Tolk.PreferSAPI(false);
                            }
// Show first run dialog if it hasn't been disabled
if (Properties.Settings.Default.ShowFirstRunDialog)
            {
                frmFirstRunHelp frm = new frmFirstRunHelp();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK) {
                    Properties.Settings.Default.Save();

                }

            }
            if (Properties.Settings.Default.GeonamesUsername == "")
            {
                MessageBox.Show("Geonames username has not been configured. Flight following features will not function.\nGo to the General section in settings to add your Geonames user name\n", "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            
            // Start the connection timer to look for a flight sim
            TimerConnection.Elapsed += TimerConnection_Tick;
            this.TimerConnection.AutoReset = true;
            this.TimerConnection.Start();

            if (Properties.Settings.Default.PlayStartupSound)
            {
                var executable = Assembly.GetExecutingAssembly().Location;
                var soundFile = Path.Combine(Path.GetDirectoryName(executable), @"sounds\TFM-Startup.wav");
                SoundPlayer sound = new SoundPlayer(soundFile);
                sound.Play();
            }

            utility.TFMMainForm = this;
        }

        


        // This method is called every 1 second by the connection timer.
        private void TimerConnection_Tick(object sender, ElapsedEventArgs e)
        {

            // The connection counter prevents excessive instances of an error
            // from appearing in the log.
            connectionCounter++;

            // Try to open the connection
            try
            {
                FSUIPCConnection.Open();

                // If there was no problem, stop this timer and start the main timer
                this.TimerConnection.Stop();
                Aircraft.InitOffsets();
                this.SetCommandKeyMenuText();
                this.TimerMain.Elapsed += TimerMain_Tick;
                this.TimerMain.AutoReset = true;
                this.TimerMain.Start();
                this.TimerLowPriority.Elapsed += TimerLowPriority_Tick;
                this.TimerLowPriority.AutoReset = true;
                this.TimerLowPriority.Start();
                TFMDatabase.Initialize();
                // load airport database
                inst.Speak("loading airport database");
                //dbLoadWorker.RunWorkerAsync();

                utility.LoadAirportsDatabase();
                                                // write version info to the debug log
                logger.Debug($"simulator version: {FSUIPCConnection.FlightSimVersionConnected}");
                logger.Debug($"FSUIPC version: {FSUIPCConnection.FSUIPCVersion}");
                logger.Debug($"FSUIPC .net DLL version: {FSUIPCConnection.DLLVersion}");
                logger.Debug($"SQLite version: {TFMDatabase.Version}");

            }
            catch (Exception ex)
            {
                if (connectionCounter <= 5)
                {
                    logger.Debug($"Connection failed [attempt #{connectionCounter}]: {ex.Message}: {ex.Source}:{ex.StackTrace}");
                    //logger.Debug($"Inner exception {ex.InnerException.Message}");
                }
                else if (connectionCounter == 35)
                {
                    Tolk.Output("Connection timed out. See the TFM log for more details. Please restart TFM to continue.");
                    logger.Debug("Connection timeout: The simulator or fsuipc are not running. Make sure they are running before starting TFM.");
                    this.TimerConnection.Stop();
                    // Command keys menu item is not needed when FSUIPC is not running.
                    commandKeysMenuItem.Visible = false;
                }
            }
        }

        // This method runs 10 times per second (every 100ms). This is set on the timerMain properties.
        private void TimerMain_Tick(object sender, ElapsedEventArgs e)
        {
            // stop the timer so we don't tick again while this method is running
            TimerMain.Stop();
            // Call process() to read/write data to/from FSUIPC
            // We do this in a Try/Catch block incase something goes wrong
            try
            {
                FSUIPCConnection.Process();
                inst.MonitorN1Limit();
                if (Aircraft.AircraftName.Value.Contains("PMDG"))
                {
                                        Aircraft.pmdg737.RefreshData();
                    Aircraft.pmdg747.RefreshData();
                   Aircraft.pmdg777.RefreshData();
                                                       }
                inst.ReadAircraftState();
                if (!inst.PostTakeOffChecklist())
                {
                    inst.PostTakeOffChecklist();
                }
                                                                                          }
                                    catch (Exception ex)
            {
                // An error occured. Tell the user and stop this timer.
                this.TimerMain.Stop();
                logger.Debug($"High priority instruments failed to read: {ex.Message}: {ex.StackTrace}");
                // Update the connection status
                // start the connection timer
                this.TimerConnection.Start();
            }
            // we're finished this tick, so restart the timer
            TimerMain.Start();
        }
        // second 200 MS timer for lower priority instruments, or instruments that don't work well on 100 MS
        private void TimerLowPriority_Tick(object sender, ElapsedEventArgs e)
        {
            // stop the timer so we don't tick again on another thread
            TimerLowPriority.Stop();
            try
            {
                FSUIPCConnection.Process("LowPriority");
                inst.ReadLowPriorityInstruments();
                            }
            catch (Exception ex)
            {
                // Stop the timer.
                this.TimerLowPriority.Stop();

                                // Make a log entry since notifying the user is pointless.
                logger.Debug($"Low priority instruments failed to read: {ex.Message}: {ex.StackTrace}");
                this.TimerConnection.Start();
            }
            TimerLowPriority.Start();
        }


        // Form is closing so stop all the timers and close FSUIPC Connection
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            /// TODO: Add message box confirmation for system tray shutdown code.

            Tolk.PreferSAPI(true);
            Tolk.Output("TFM is shutting down.");
            Tolk.PreferSAPI(false);
            Thread.Sleep(2000);

            if (Properties.Settings.Default.PlayShutdownSound)
            {
                var executable = Assembly.GetExecutingAssembly().Location;
                var soundFile = Path.Combine(Path.GetDirectoryName(executable), @"sounds\TFM-Shutdown.wav");
                SoundPlayer sound = new SoundPlayer(soundFile);
                sound.Play();
                Thread.Sleep(10000);
            }

            this.TimerConnection.Stop();
            this.TimerMain.Stop();
            this.TimerLowPriority.Stop();
            FSUIPCConnection.Close();
        }
                           public void Shutdown()
        {
            Close();
        } // Shutdown

        private void ShowAboutBox()
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        } // ShowAboutBox.

        private void ShowWebsite()
        {
            System.Diagnostics.Process.Start("http://www.talkingflightmonitor.com");
        } // ShowWebsite.

        private void ShowIssueTracker()
        {
            System.Diagnostics.Process.Start("https://github.com/jfayre/talking-flight-monitor-net/issues");
        } // ShowIssueTracker.

private void ShowSettings()
        {
            /// TODO: TFM main form: Remove avionics tab from settings.
            /// TODO: TFM main form: Make displaying settings reusable code in the global scope.
            /// 
            frmSettings settings = new frmSettings();

            settings.ShowDialog();
            if (settings.DialogResult == DialogResult.OK)
            {
                if (Properties.Settings.Default.AvionicsTabChangeFlag)
                {
                    MessageBox.Show("You must restart TFM for the avionics tab changes to take affect", "restart required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Properties.Settings.Default.Save();
                Properties.pmdg737_offsets.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Reload();
                Properties.pmdg737_offsets.Default.Reload();

            }
        } // ShowSettings.

        private void ShowKeyboardManager()
        {
                                       frmKeyboardManager keyboardManager = new frmKeyboardManager();
                keyboardManager.ShowDialog();
                if (keyboardManager.DialogResult == DialogResult.OK)
                {
                    Properties.Hotkeys.Default.Save();
                                }
                if (keyboardManager.DialogResult == DialogResult.Cancel)
                {
                    Properties.Hotkeys.Default.Reload();
                }
            } // ShowKeyboardManager.
        
        private bool ToggleCommandKeys()
        {
            bool isEnabled = false;
                                        if (inst.CommandKeyEnabled)
                {
                    inst.CommandKeyEnabled = false;
                isEnabled = false;
                    inst.ResetHotkeys();
                Tolk.PreferSAPI(true);    
                Tolk.Output("command key disabled");
                Tolk.PreferSAPI(false);
                }
                else
                {
                    inst.CommandKeyEnabled = true;
                isEnabled = true;
                    inst.ResetHotkeys();
                Tolk.PreferSAPI(true);
                Tolk.Output("command key enabled");
                Tolk.PreferSAPI(false);
                }
                                        return isEnabled;
            } // ToggleCommandKeys.

        private void SetCommandKeyMenuText()
        {
            // Make the menu item visible in the event the connection timer made it invisible.
            if(commandKeysMenuItem.Visible == false)
            {
                commandKeysMenuItem.Visible = true; 
            }
            if(inst.CommandKeyEnabled ==  true)
            {
                commandKeysMenuItem.Text = $"&Command keys enabled";
                commandKeysMenuItem.AccessibleName = "Command keys enabled";
            }
            else
            {
                commandKeysMenuItem.Text = "&Command keys disabled";
                commandKeysMenuItem.AccessibleName = "Command keys disabled";
            }
        } // SetCommandKeyMenuText.

        private void Restart()
        {
            Tolk.PreferSAPI(true);
            Tolk.Output("TFM is restarting...");
            Tolk.PreferSAPI(false);
            Thread.Sleep(1500);
            Application.Restart();
                    } // Restart.

        private void settingsMenuItem_Click(object sender, EventArgs e)
        {
            ShowSettings();
        } // settingsMenuItem_Click.

        private void commandKeysMenuItem_Click(object sender, EventArgs e)
        {
                        bool isEnabled = ToggleCommandKeys()? true : false;
            string commandKeyState = isEnabled ?  "enabled" : "disabled";   
            commandKeysMenuItem.AccessibleName = $"Command keys {commandKeyState}";
            commandKeysMenuItem.Checked = isEnabled? true : false;
        } // commandKeysMenuItem_Click.

        private void keyboardMenuItem_Click(object sender, EventArgs e)
        {
            ShowKeyboardManager();
        } // keyboardManagerMenuItem_Click.

        private void issueTrackerMenuItem_Click(object sender, EventArgs e)
        {
            ShowIssueTracker();
        } // issueTrackerMenuItem_Click.

        private void websiteMenuItem_Click(object sender, EventArgs e)
        {
            ShowWebsite();
        } // websiteMenuItem_Click.

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            ShowAboutBox();
        } // aboutMenuItem_Click.

        private void restartMenuItem_Click(object sender, EventArgs e)
        {
            this.Restart();
        } // restartMenuItem_Click.

        private void shutDownMenuItem_Click(object sender, EventArgs e)
        {
            utility.ApplicationShutdown();
        } // shutdownMenuItem_Click.

        private void TFMMainForm_Load(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }//End TFMMainForm class.
} //End TFM namespace.
