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




namespace tfm
{
    public partial class App : System.Windows.Application
    {


        // Private fields
        #region "Private fields"
        // UI elements.
        TrayIcon icon;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        // Timers.
        System.Timers.Timer TimerMain = new(500);
        System.Timers.Timer TimerConnection = new(1000);
        System.Timers.Timer TimerLowPriority = new(1000);

        private readonly IOSubsystem inst = new IOSubsystem();
        #endregion

        // Startup event.
        #region "Startup"
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            LoadTrayIcon();
            //RegisterTFMGlobalCommands();

            // Debug mode.
            #region "Debug mode"
            if (e.Args.Length == 1)
            {
                if (e.Args[0] == "/debug")
                {
                    utility.DebugEnabled = true;
                    Tolk.Output("debug mode active");
                }
            }
            #endregion


            // Initialize Navigraph database.
            App.Navigraph.Initialize();

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
                this.TimerLowPriority.Elapsed += TimerLowPriority_Tick;
                this.TimerLowPriority.AutoReset = true;
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
                #endregion

                // Load TFM's database.
                TFMDatabase.Initialize();
                                
                // load airport database
                #region "Airports database"
                inst.Speak("loading airport database");
                utility.LoadAirportsDatabase();
                #endregion

                // Load the destination runway.
                App.Utilities.LoadDestination();

                // Get TFM's version number.
                #region "TFM's version"
                Assembly assembly = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
                Version tfmVersion = assembly.GetName().Version;
                #endregion

                              // Log version numbers.
                #region "Logging version numbers"
                logger.Info("-------------------- Version numbers --------------------");
                logger.Info($"Windows version: {Environment.OSVersion.Version}");
                logger.Info($"TFM version: {tfmVersion}");
                logger.Info($"simulator version: {FSUIPCConnection.FlightSimVersionConnected}");
                logger.Info($"FSUIPC version: {FSUIPCConnection.FSUIPCVersion}");
                logger.Info($"FSUIPC .net DLL version: {FSUIPCConnection.DLLVersion}");
                logger.Info($"Navigraph version {App.Navigraph.Version}");
                logger.Info($"SQLite version: {TFMDatabase.Version}");
                logger.Info("---------------------------------------------------------");
                #endregion
                                            }
            catch (Exception ex)
            {
                icon.Text = " - Waiting for connection...";
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
                if (App.Utilities.isPMDG737Loaded || App.Utilities.isPMDG747Loaded || App.Utilities.isPMDG777Loaded)
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
                    inst.ReadAircraftState();
                }
                #endregion
                /*
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
                }*/
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
icon = new TrayIcon
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
