using TrayIcon = System.Windows.Forms.NotifyIcon;
using FSUIPC;
using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using NGeoNames.Entities;
using NGeoNames;
using NLog;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

using tfm.PMDG.PMDG_737.McpComponents;

namespace tfm
{
    public partial class App: System.Windows.Application
    {
        // Private fields
        #region "Private fields"
        // UI elements.
        TrayIcon icon;

        // Timers.
        System.Timers.Timer TimerMain = new(500);
        System.Timers.Timer TimerConnection = new(1000);
        System.Timers.Timer TimerLowPriority = new(1000);

        private readonly IOSubsystem inst = new IOSubsystem();
        #endregion


        // PMDG MCP components managers.
        private PMDG737MCPComponentsManager _PMDG737MCPComponentsManager = new PMDG737MCPComponentsManager();
        // get a logger object for this class
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        // get a speech synthesis object for SAPI output
        public static System.Speech.Synthesis.SpeechSynthesizer synth = new System.Speech.Synthesis.SpeechSynthesizer();

        private readonly OutputHistory history = new OutputHistory();
        public PMDGPanelUpdateEvent pmdg;

        private SineWaveProvider pitchSineProvider;


        // load command help resources

        private ResourceManager rm = new ResourceManager(typeof(commandHelp));

        // timers
        private static System.Timers.Timer RunwayGuidanceTimer;
        private static readonly System.Timers.Timer GroundSpeedTimer = new System.Timers.Timer(3000); // 3 seconds;
        private static readonly System.Timers.Timer WarningsTimer = new System.Timers.Timer(5000); // 5 seconds;
        private static System.Timers.Timer AttitudeTimer;
        private static System.Timers.Timer flightFollowingTimer;
        private static readonly System.Timers.Timer ilsTimer = new System.Timers.Timer(TimeSpan.FromSeconds(double.Parse(tfm.Properties.Settings.Default.ILSAnnouncementTimeInterval)).TotalMilliseconds);
        private static readonly System.Timers.Timer waypointTransitionTimer = new System.Timers.Timer(5000);
        private static readonly System.Timers.Timer weatherTimer = new System.Timers.Timer(TimeSpan.FromMinutes(tfm.Properties.Weather.Default.weather_refresh_rate).TotalMilliseconds);
        private System.Timers.Timer cloudTrackingTimer = new System.Timers.Timer(300);
        private string oldCloudType = string.Empty;
        private double HdgRight;
        private double HdgLeft;

        // Audio objects
        private static IWavePlayer driverOut;
        private static SignalGenerator wg;
        // private static readonly SignalGenerator BankWG;
        private static PanningSampleProvider pan;
        private static OffsetSampleProvider pulse;
        private static MixingSampleProvider mixer;

        // initialize sound objects
        private static WaveFileReader cmdSound;
        private static WaveFileReader apCmdSound;
        private static WaveFileReader tickSound;

        // list to store registered hotkey identifiers
        readonly List<string> hotkeys = new List<string>();
        readonly List<string> autopilotHotkeys = new List<string>();
        FsFuelTanksCollection FuelTanks = null;

        // list to store fuel tanks present on the aircraft
        readonly List<FsFuelTank> ActiveTanks = new List<FsFuelTank>();
        readonly InstrumentPanel Autopilot = new InstrumentPanel();
        // dictionaries for altitude and GPWS callouts
        private readonly Dictionary<int, bool> altitudeCalloutFlags = new Dictionary<int, bool>();
        private readonly Dictionary<int, bool> gpwsFlags = new Dictionary<int, bool>() {
            {2500, false },
            {1000, false },
            {500, false },
            {400, false },
            {300, false },
            {200, false },
            {100, false },
            {50, false },
            {40, false },
            {30, false },
            {20, false },
            {10, false }
        };

        static bool FirstRun = true;
        private bool waypointTransition;
        private readonly bool InstrumentationEnabled;
        private bool groundSpeedActive;
        private bool takeOffAssistantActive = false;
        private bool isTakeoffComplete = true; // Always true unless takeoff assist is Active.
        bool isCloudTrackingEnabled = false;
        bool inCloudDescending = false;
        bool wasInCloudDescending = false;
        bool inCloudAscending = false;
        bool wasInCloudAscending = false;
        private double OldElevatorTrim = 0;
        private bool TrimEnabled = true;
        private bool FlapsMoving;
        private bool pmdg777SpeedBrakeMoving = false;

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private bool muteSimconnect;
        private readonly bool flightFollowingOnline;
        private bool runwayGuidanceEnabled;
        private bool attitudeModeEnabled;
        private bool localiserDetected;
        private bool AttitudePitchPlaying;
        private bool AttitudeBankLeftPlaying;

        // engine throttle properties
        private double engine1ThrottlePercent;
        public double Engine1ThrottlePercent
        {
            get
            {
                engine1ThrottlePercent = (double)Aircraft.Engine1ThrottleLever.Value / 16384d * 100d;
                return engine1ThrottlePercent;
            }
            set
            {
                value = value / 100 * 16384;
                Aircraft.Engine1ThrottleLever.Value = (short)value;
            }
        }
        private double engine2ThrottlePercent;
        public double Engine2ThrottlePercent
        {
            get
            {
                engine2ThrottlePercent = (double)Aircraft.Engine2ThrottleLever.Value / 16384d * 100d;
                return engine2ThrottlePercent;
            }
            set
            {
                value = value / 100 * 16384;
                Aircraft.Engine2ThrottleLever.Value = (short)value;
            }
        }
        private double engine3ThrottlePercent;
        public double Engine3ThrottlePercent
        {
            get
            {
                engine3ThrottlePercent = (double)Aircraft.Engine3ThrottleLever.Value / 16384d * 100d;
                return engine3ThrottlePercent;
            }
            set
            {
                value = value / 100 * 16384;
                Aircraft.Engine3ThrottleLever.Value = (short)value;
            }
        }
        private double engine4ThrottlePercent;
        public double Engine4ThrottlePercent
        {
            get
            {
                engine4ThrottlePercent = (double)Aircraft.Engine4ThrottleLever.Value / 16384d * 100d;
                return engine4ThrottlePercent;
            }
            set
            {
                value = value / 100 * 16384;
                Aircraft.Engine4ThrottleLever.Value = (short)value;
            }
        }

        public double OldBank { get; private set; }

        public double CurrentHeading;

        public ReverseGeoCode<ExtendedGeoName> r = new ReverseGeoCode<ExtendedGeoName>(GeoFileReader.ReadExtendedGeoNames(@".\data\cities1000.txt"));
        private readonly int OldSpoilersValue;
        private double RunwayGuidanceTrackedHeading;
        private string OldSimConnectMessage;
        private readonly double apHeading;
        private bool AttitudeBankRightPlaying;
        private bool readNavRadios;
        private double groundSpeed;
        public double GroundSpeed
        {
            get
            {
                groundSpeed = ((double)Aircraft.GroundSpeed.Value * 3600d) / (65536d * 1852d);
                groundSpeed = Math.Round(groundSpeed);
                return groundSpeed;

            }
        }

        public bool WarningFlag { get; private set; }
        public bool helpModeEnabled { get; private set; }

        public bool CommandKeyEnabled = true;

        private int attitudeModeSelect;
        private double oldPitch;
        private string oldTimezone;
        private bool gsDetected;
        private bool hasLocaliser;
        private bool hasGlideSlope;
        private bool readWaypointFlag;
        private bool apuStarting;
        private bool apuRunning;
        private bool apuShuttingDown;
        private bool apuOff = true;
        private bool fuelManagerActive;
        WaveFileReader gpwsSound;
        public bool PMDG737Detected;
        private bool PMDG747Detected;
        public bool PMDG777Detected;
        private bool PMDGInitializing;
        private bool FirstOfficerCountDown;

        /* Check to see if PMDG aircraft are loaded.
         * Basing the results on contents found in the aircraft name instead of the
         * model. If there is a more reliable way, it would be great.
         * NOTE: The ability to use other liveries is unreliable because of the
         * detection method is purely based on contents found in a string.*/

        public bool isPMDG737Loaded
        {
            get => Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("737");
        }

        public bool isPMDG747Loaded
        {
            get => Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("747");
        }

        public bool isPMDG777Loaded
        {
            get => Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("777");
        }


        /* Check to see if P3D is loaded. Basing it on FSUIPC version
         * since it is more reliable than simulator name or version.*/
        public bool IsP3DLoaded { get => FSUIPCConnection.FSUIPCVersion.Major <= 6 ? true : false; }

        // Same for MSFS. See above.
        public bool isMSFSLoaded { get => FSUIPCConnection.FSUIPCVersion.Major >= 7 ? true : false; }

        // Location of the binary files for the airports database.
        public string airportsDatabaseFolder
        {
            get
            {
                string databasePath = string.Empty;
                var tfmFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Talking flight monitor");

                // Geneerate the P3D database location.
                if (IsP3DLoaded)
                {
                    databasePath = Path.Combine(tfmFolder, "P3D airports");
                }

                // Generate the MSFS database location.
                else if (isMSFSLoaded)
                {
                    databasePath = Path.Combine(tfmFolder, "MSFS airports");
                }

                return databasePath;
            }
        }

        public static InstrumentPanel instrumentPanel { get => new InstrumentPanel(); }
    }
}
