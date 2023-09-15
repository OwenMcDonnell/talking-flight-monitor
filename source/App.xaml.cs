using tfm;
using tfm.Properties.Data.Navdata;
using tfm.Properties.Data.Navigraph;
using DavyKager;

using FSUIPC;

using NLog;

using System.IO;
using System.Media;
using System.Reflection;
using System.Timers;
using System.Windows;

using ContextMenu = System.Windows.Forms.ContextMenuStrip;
using MenuItem = System.Windows.Forms.ToolStripMenuItem;
using TrayIcon = System.Windows.Forms.NotifyIcon;
using NHotkey.WindowsForms;

namespace tfm
{
    public partial class App : System.Windows.Application
    {


                // Startup event.
        #region "Startup"
        private void Application_Startup(object sender, StartupEventArgs e)
        {
                       LoadTrayIcon();
            RegisterTFMGlobalCommands();

            // Load tolk.
            #region
            Tolk.Load();
            logger.Info("Loading screen reader driver.");
            #endregion
            
            // Debug mode.
            #region "Debug mode"
            if (e.Args.Length == 1)
            {
                if (e.Args[0] == "/debug")
                {
                    DebugEnabled = true;
                    Output(isGauge: false, useSAPI: true, output: "Debug mode active.");
                }
            }
            #endregion

                        // Install default Navigraph database if required.
            #region
            using(var _dbContext = new tfm.Properties.Data.Navigraph.NavigraphContext())
            {
                _dbContext.InstallDefaultDatabase();
            }
            #endregion

            // Upgrade settings.
            #region "Upgrade settings"
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

            }
            #endregion

            // Show first run help dialog
            #region "First run"
            if (tfm.Properties.Settings.Default.ShowFirstRunDialog)
            {
                firstRunHelp firstRun = new firstRunHelp();
                firstRun.Show();
            }
            #endregion

            // Start the connection timer to look for a flight sim
            #region "Connection timer"
            TimerConnection.Elapsed += TimerConnection_Tick;
            this.TimerConnection.AutoReset = true;
            this.TimerConnection.Interval = 500;
            this.TimerConnection.Start();
            #endregion

            //Play startup sound.
            #region "Startup sound"
            if (tfm.Properties.Settings.Default.PlayStartupSound)
            {
                var executable = Assembly.GetExecutingAssembly().Location;
                var soundFile = Path.Combine(Path.GetDirectoryName(executable), @"sounds\TFM-Startup.wav");
                SoundPlayer sound = new SoundPlayer(soundFile);
                sound.Play();
            }
            #endregion

                                    if (tfm.Properties.Settings.Default.SpeechSystem == "Azure")
            {
                // disabling Azure speech for now since we're trying to debug issues. If speech is set to azure, we force it to screen reader.
                // SetupAzureSpeech();
                tfm.Properties.Settings.Default.SpeechSystem = "ScreenReader";
            }

            // Initialize audio output
            SetupAudio();
                                }
        #endregion

        // Connection timer's elapsed event.
        #region "Connection timer elapsed event"
        private void TimerConnection_Tick(object sender, ElapsedEventArgs e)
        {

            // Try to open the connection
            try
            {
                                   FSUIPCConnection.Open();


                                                // Stop trying to connect
                #region "Timers"
                this.TimerConnection.Stop();
                this.TimerMain.Elapsed += TimerMain_Tick;
                this.TimerMain.AutoReset = true;
                this.TimerMain.Start();
                this.TimerLowPriority.Elapsed += TimerLowPriority_Tick;
                this.TimerLowPriority.AutoReset = true;
                this.TimerLowPriority.Start();
                logger.Info("Connection to FSUIPC open.");
                #endregion

                // Load offsets.
                #region "Load offsets"
                Aircraft.InitOffsets();
                logger.Info("Loading offsets...");
                #endregion

                // Start interacting with the simulator.
                #region "Start timers"
                this.TimerMain.Start();
                this.TimerLowPriority.Start();
                logger.Info("Monitoring aircraft systems and simulator environment...");
                icon.Text = $" - Connected to {FSUIPCConnection.FlightSimVersionConnected}";
                                                                                        runwayGuidanceEnabled = false;


                    // hook up events for timers
                    GroundSpeedTimer.Elapsed += onGroundSpeedTimerTick;
                    ilsTimer.Elapsed += onILSTimerTick;
                    waypointTransitionTimer.Elapsed += onWaypointTransitionTimerTick;
                    weatherTimer.Elapsed += OnWeatherRefreshTimerTick;
                    weatherTimer.Start();
                    cloudTrackingTimer.Elapsed += CloudTrackingTimerTick;
                    WarningsTimer.Elapsed += WarningsTimer_Tick;
                    // start the flight following timer if it is enabled in settings
                    SetupFlightFollowing();
                    // populate the dictionary for the altitude callout flags
                    for (int i = 1000; i < 65000; i += 1000)
                    {
                        altitudeCalloutFlags.Add(i, false);
                    }
                    pmdg = new PMDGPanelUpdateEvent();

                    // Setup SimBrief support.
                    if (tfm.Properties.Settings.Default.IsSimBriefUserIDValid)
                    {
                        logger.Debug("Starting SimBrief support.");
                        Output(isGauge: false, output: "Starting SimBrief support.");
                        FlightPlan.LoadFromXML();
                    }
                    else
                    {
                        logger.Debug("SimBrief support not loaded");
                        Output(isGauge: false, output: "SimBrief support not loaded.");
                }
                #endregion
                
                    // Load TFM's database.
                TFMDatabase.Initialize();

                // load airport database
                #region "Airports database"
                LoadAirportsDatabase();
                                #endregion

                // Load the destination runway.
                LoadDestination();

                // Get TFM's version number.
                #region "TFM's version"
                Assembly assembly = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
                Version tfmVersion = assembly.GetName().Version;
                #endregion

                // Log version numbers.
                #region "Logging version numbers"
                try
                {
                    logger.Info("-------------------- Version numbers --------------------");
                    logger.Info($"Windows version: {Environment.OSVersion.Version}");
                    logger.Info($"TFM version: {tfmVersion}");
                    logger.Info($"simulator version: {FSUIPCConnection.FlightSimVersionConnected}");
                    logger.Info($"FSUIPC version: {FSUIPCConnection.FSUIPCVersion}");
                    logger.Info($"FSUIPC .net DLL version: {FSUIPCConnection.DLLVersion}");
                    using (var _dbContext = new EDfdContext())
                    {
                        var _navigraphHeader = _dbContext.Headers.FirstOrDefault();
                        if (_navigraphHeader != null)
                        {
                            logger.Info($"Navigraph version {_navigraphHeader.CurrentAirac} Rev {_navigraphHeader.Revision}");
                        }
                        else
                        {
                            logger.Warn("No Navigraph header found.");
                        }
                    }
                                            logger.Info($"SQLite version: {TFMDatabase.Version}");
                    logger.Info("---------------------------------------------------------");
                                        }
                catch(Exception x)
                {
                    logger.Error($"{x.Message}\r\n{x.StackTrace}");
                }
                #endregion

                announcedOfflineState = false;
                                            }
            catch 
            {
                icon.Text = " - Waiting for connection...";
                if (announcedOfflineState == false)
                {
                    Output(isGauge: false, useSAPI: true, output: "Working offline.");
                }
                announcedOfflineState = true;
            }
        }
        #endregion

        // Main timer loop.
        #region "Main timer"
        private void TimerMain_Tick(object sender, ElapsedEventArgs e)
        {
            // stop the timer so we don't tick again while this method is running
            TimerMain.Stop();
            // Call process() to read/write data to/from FSUIPC
                        try
            {
                FSUIPCConnection.Process();

                // Process PMDG data.
                #region "PMDG data"
                if (isPMDG737Loaded || isPMDG747Loaded || isPMDG777Loaded)
                {
                    Aircraft.pmdg737.RefreshData();
                    Aircraft.pmdg747.RefreshData();
                    Aircraft.pmdg777.RefreshData();
                }
                #endregion


                ///todo: Figure out a better way to mute TFM.
                #region "Mute TFM"
                if (tfm.Properties.Settings.Default.AutomaticAnnouncements)
                {
                    ReadAircraftState();
                }
                #endregion
                           }
            catch (Exception ex)
            {
                                this.TimerMain.Stop();
                logger.Debug($"High priority instruments failed to read: {ex.Message}: {ex.StackTrace}");

                // start the connection timer
                this.TimerConnection.Start();
            }
            // we're finished this tick, so restart the timer
            TimerMain.Start();
        }
        #endregion

        // second 200 MS timer for lower priority instruments, or instruments that don't work well on 100 MS
        #region
        private void TimerLowPriority_Tick(object sender, ElapsedEventArgs e)
        {
            // stop the timer so we don't tick again on another thread
            TimerLowPriority.Stop();
            try
            {
                FSUIPCConnection.Process("LowPriority");

                // TODO: Figure out a better way of muting TFM.
                #region
                if (tfm.Properties.Settings.Default.AutomaticAnnouncements)
                {
                    ReadLowPriorityInstruments();
                }
                #endregion

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
        #endregion
        
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
                AccessibleName = "Talking flight monitor",
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
            TFMContextMenu.Opened += TalkingFlightMonitorMenu_Open;
            // The tray icon.
icon = new TrayIcon
            {
                Text = "Talking flight monitor",
                Icon = new Icon("Properties/TFM_icon.ico"),
                ContextMenuStrip = TFMContextMenu,
                Visible = true,
            };
        }


        // Context menu events.
        #region
        private void SettingsMenuItem_Click(object? sender, EventArgs e)
        {
            DisplayApplicationSettings();
        }

        private void KeyboardManagerMenuItem_Click(object? sender, EventArgs e)
        {
            Output(isGauge: false, output: "The keyboard manager is not yet implemented!");
        }

        private void RestartMenuItem_Click(object? sender, EventArgs e)
        {
            Restart();
        }

        private void ShutdownMenuItem_Click(object? sender, EventArgs e)
        {
            App.Current.Shutdown();
                    }

        private void IssueTrackerMenuItem_Click(object? sender, EventArgs e)
        {
            OpenUrl("https://github.com/jfayre/talking-flight-monitor-net/issues");
        }

        private void WebsiteMenuItem_Click(object? sender, EventArgs e)
        {
            OpenUrl("http://www.talkingflightmonitor.com");
        }

        private void AboutMenuItem_Click(object? sender, EventArgs e)
        {
            Output(isGauge: false, output: "The about box is not yet implemented!");
        }

        private void TalkingFlightMonitorMenu_Open(object? sender, EventArgs e)
        {
if(sender is ContextMenu menu && menu.Items.Count > 0)
            {
                menu.Focus();
            }
        }
        #endregion
    }
}
