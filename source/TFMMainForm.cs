using FSUIPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private bool visibleOnStartup = false;

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
            Aircraft.InitOffsets();

                        // speak a debug message via SAPI if debug mode is turned on
            if (utility.DebugEnabled)
            {
                Tolk.PreferSAPI(true);
                Tolk.Output("Debug mode");
                Tolk.PreferSAPI(false);
            }

            if (Properties.Settings.Default.GeonamesUsername == "")
            {
                MessageBox.Show("Geonames username has not been configured. Flight following features will not function.\nGo to the General section in settings to add your Geonames user name\n", "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            // Start the connection timer to look for a flight sim
            TimerConnection.Elapsed += TimerConnection_Tick;
            this.TimerConnection.AutoReset = true;
            this.TimerConnection.Start();

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
                this.TimerMain.Elapsed += TimerMain_Tick;
                this.TimerMain.AutoReset = true;
                this.TimerMain.Start();
                this.TimerLowPriority.Elapsed += TimerLowPriority_Tick;
                this.TimerLowPriority.AutoReset = true;
                this.TimerLowPriority.Start();
                // load airport database
                inst.Speak("loading airport database");
                dbLoadWorker.RunWorkerAsync();
                // write version info to the debug log
                logger.Debug($"simulator version: {FSUIPCConnection.FlightSimVersionConnected}");
                logger.Debug($"FSUIPC version: {FSUIPCConnection.FSUIPCVersion}");
                logger.Debug($"FSUIPC .net DLL version: {FSUIPCConnection.DLLVersion}");


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
                    Tolk.Output("Connection timed out. See the TFM log for more details. Please restart TFM or manually connect to continue.");
                    logger.Debug("Connection timeout: The simulator or fsuipc are not running. Make sure they are running before starting TFM.");
                    this.TimerConnection.Stop();
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
            this.TimerConnection.Stop();
            this.TimerMain.Stop();
            this.TimerLowPriority.Stop();
            FSUIPCConnection.Close();
        }
   
                private void dbLoadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                FSUIPCConnection.AirportsDatabase.LoadTaxiways = true;
                FSUIPCConnection.AirportsDatabase.Load();
                if (FSUIPCConnection.AirportsDatabase.IsLoaded)
                {
                    Tolk.Output("Airport database loaded.");
                }
            }
            catch (Exception ex)
            {
                Tolk.Output("could not load airport database.");
            }
        } // load database.

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(visibleOnStartup? value:visibleOnStartup);
        } // SetVisibleCore.

            }//End TFMMainForm class.
} //End TFM namespace.
