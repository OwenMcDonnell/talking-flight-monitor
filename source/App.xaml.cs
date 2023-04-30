using TrayIcon = System.Windows.Forms.NotifyIcon;
using ContextMenu = System.Windows.Forms.ContextMenuStrip;
using MenuItem = System.Windows.Forms.ToolStripMenuItem;
using DavyKager;
using FSUIPC;
using NLog;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;




namespace tfm
{
        public partial class App : System.Windows.Application
    {
        // get a logger object for this class
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        // set up timers
        System.Timers.Timer TimerMain = new(500);
        System.Timers.Timer TimerConnection = new(1000);
        System.Timers.Timer TimerLowPriority = new(1000);

        // Create a counter for the connection timer.
        private int connectionCounter = 0;
        private readonly IOSubsystem inst = new IOSubsystem();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            LoadTrayIcon();
            if (e.Args.Length == 1)
            {
                if (e.Args[0] == "/debug")
                {
                    utility.DebugEnabled = true;
                    Tolk.Output("debug mode active");
                }
            }
            
            // Upgrade settings if needed
            if (tfm.Properties.Settings.Default.SettingsRequiresUpgrade)
            {
                tfm.Properties.Settings.Default.Upgrade();
                tfm.Properties.pmdg737_offsets.Default.Upgrade();
                tfm.Properties.pmdg747_offsets.Default.Upgrade();
                tfm.Properties.Weather.Default.Upgrade();
                tfm.Properties.NavlogColumns.Default.Upgrade();
                tfm.Properties.Settings.Default.SettingsRequiresUpgrade = false;

                // Disable vatsim mode for now.
                tfm.Properties.Settings.Default.VatsimMode = false;
                tfm.Properties.Settings.Default.Save();
                tfm.Properties.pmdg737_offsets.Default.Save();
                tfm.Properties.pmdg747_offsets.Default.Save();
                tfm.Properties.Weather.Default.Save();
                // System.Windows.Application.Restart();
                
            }
            // speak a debug message via SAPI if debug mode is turned on
            if (utility.DebugEnabled)
            {
                Tolk.PreferSAPI(true);
                Tolk.Output("Debug mode");
                Tolk.PreferSAPI(false);
            }
            if (tfm.Properties.Settings.Default.GeonamesUsername == "")
            {
                System.Windows.MessageBox.Show("Geonames username has not been configured. Flight following features will not function.\nGo to the General section in settings to add your Geonames user name\n", "error", MessageBoxButton.OK);
            }
            // Start the connection timer to look for a flight sim
            TimerConnection.Elapsed += TimerConnection_Tick;
            this.TimerConnection.AutoReset = true;
            this.TimerConnection.Start();

            if (tfm.Properties.Settings.Default.PlayStartupSound)
            {
                var executable = Assembly.GetExecutingAssembly().Location;
                var soundFile = Path.Combine(Path.GetDirectoryName(executable), @"sounds\TFM-Startup.wav");
                SoundPlayer sound = new SoundPlayer(soundFile);
                sound.Play();
            }







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
                
                // this.SetCommandKeyMenuText();
                this.TimerMain.Elapsed += TimerMain_Tick;
                this.TimerMain.AutoReset = true;
                // Initialize aircraft offsets
                Aircraft.InitOffsets();
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
                    // commandKeysMenuItem.Visible = false;
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
                if (tfm.Properties.Settings.Default.AutomaticAnnouncements)
                {
                    inst.ReadAircraftState();
                }

                if (!inst.PostTakeOffChecklist())
                {
                    inst.PostTakeOffChecklist();
                }

                if (Aircraft.inCloud.Value > 0)
                {
                    if (Aircraft.inCloud.ValueChanged)
                    {
                        inst.Output(isGauge: false, output: "In cloud.");
                    }
                }
                else
                {
                    if (Aircraft.inCloud.ValueChanged)
                    {
                        inst.Output(isGauge: false, output: "Out of cloud.");
                    }
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
                if (tfm.Properties.Settings.Default.AutomaticAnnouncements)
                {
                    inst.ReadLowPriorityInstruments();
                }

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

private void LoadTrayIcon()
        {

            // Load the system tray icon and assign all of the context menu items to it.

            // Settings menu item.
            MenuItem SettingsMenuItem = new MenuItem
            {
                Name = "SettingsMenuItem",
                Text = "&Settings...",
            };
            SettingsMenuItem.Click += new EventHandler(SettingsMenuItem_Click);

            // Keyboard manager menu item.
            MenuItem KeyboardManagerMenuItem = new MenuItem
            {
                Name = "KeyboardManagerMenuItem",
                Text = "&Keyboard manager...",
            };
            KeyboardManagerMenuItem.Click += new EventHandler(KeyboardManagerMenuItem_Click);

            // Restart menu item.
            MenuItem RestartMenuItem = new MenuItem
            {
                Name = "RestartMenuItem",
                Text = "&Restart",
            };
            RestartMenuItem.Click += new EventHandler(RestartMenuItem_Click);

            // Shutdown menu item.
            MenuItem ShutdownMenuItem = new MenuItem
            {
                Name = "ShutdownMenuItem",
                Text = "&Shutdown",
            };
            ShutdownMenuItem.Click += new EventHandler(ShutdownMenuItem_Click);

            // Issue tracker menu item.
            MenuItem IssueTrackerMenuItem = new MenuItem
            {
                Name = "IssueTrackerMenuItem",
                Text = "&Issue tracker...",
            };
            IssueTrackerMenuItem.Click += new EventHandler(IssueTrackerMenuItem_Click);

            // Website menu item.
            MenuItem WebsiteMenuItem = new MenuItem
            {
                Name = "WebsiteMenuItem",
                Text = "&Website...",
            };
            WebsiteMenuItem.Click += new EventHandler(WebsiteMenuItem_Click);

            // About menu item.
            MenuItem AboutMenuItem = new MenuItem
            {
                Name = "AboutMenuItem",
                Text = "&About...",
            };
            AboutMenuItem.Click += new EventHandler(AboutMenuItem_Click);

            // The context menu.
            ContextMenu TFMContextMenu = new ContextMenu
            {
                Name = "TFMContextMenu",
                AccessibleName = "TFM context menu",
                Items =
                {
SettingsMenuItem,
KeyboardManagerMenuItem,
RestartMenuItem,
ShutdownMenuItem,
IssueTrackerMenuItem,
WebsiteMenuItem,
AboutMenuItem,
                }
            };

            // The tray icon.
            TrayIcon icon = new TrayIcon
            {
                Text = "Talking flight monitor",
                Icon = new Icon("Properties/TFM_icon.ico"),
                ContextMenuStrip = TFMContextMenu,
                Visible = true,
            };
        }

        private void SettingsMenuItem_Click(object? sender, EventArgs e)
        {

        }

        private void KeyboardManagerMenuItem_Click(object? sender, EventArgs e)
        {

        }

        private void RestartMenuItem_Click(object? sender, EventArgs e)
        {
            
        }

        private void ShutdownMenuItem_Click(object? sender, EventArgs e)
        {
            App.Current.Shutdown();
                    }

        private void IssueTrackerMenuItem_Click(object? sender, EventArgs e)
        {

        }

        private void WebsiteMenuItem_Click(object? sender, EventArgs e)
        {

        }

        private void AboutMenuItem_Click(object? sender, EventArgs e)
        {

        }
    }
}
