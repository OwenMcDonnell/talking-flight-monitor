﻿using tfm.PMDG.PanelObjects;
using DavyKager;
using BingMapsSDSToolkit.GeodataAPI;
using BingMapsRESTToolkit.Extensions;
using FSUIPC;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NHotkey;
using NHotkey.WindowsForms;
using NLog;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Timers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Configuration;
using NGeoNames;
using NGeoNames.Entities;
using TimeZoneConverter;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.ServiceModel.Security;
using System.Drawing.Text;
using System.Windows.Forms.VisualStyles;
using tfm.Properties;
using System.CodeDom;
using System.Speech.Synthesis;
using System.ComponentModel.Design;
using tfm.Keyboard_manager;
// using Microsoft.CognitiveServices.Speech;
// using Microsoft.CognitiveServices.Speech.Audio;

namespace tfm
{
    /// <summary>
    ///  this class handles automatic reading of instrumentation, as well as reading in response to hotkeys
    /// </summary>
    public class IOSubsystem
    {
        // get a logger object for this class
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        // get a speech synthesis object for SAPI output
        public static System.Speech.Synthesis.SpeechSynthesizer synth = new System.Speech.Synthesis.SpeechSynthesizer();

        // objects for cognative speech services
        // private SpeechConfig azureConfig;
        // private Microsoft.CognitiveServices.Speech.SpeechSynthesizer azureSynth;
        // speech history class
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
        private static readonly System.Timers.Timer ilsTimer = new System.Timers.Timer(TimeSpan.FromSeconds(double.Parse(Properties.Settings.Default.ILSAnnouncementTimeInterval)).TotalMilliseconds);
        private static readonly System.Timers.Timer waypointTransitionTimer = new System.Timers.Timer(5000);
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
        // readonly SoundPlayer cmdSound = new SoundPlayer(@"sounds\command.wav");
        // readonly SoundPlayer apCmdSound = new SoundPlayer(@"sounds\ap_command.wav");
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

        public IOSubsystem(bool AdditionalInstance)
        {

        }
        public IOSubsystem()
        {

            Logger.Debug("initializing screen reader driver");
            Tolk.TrySAPI(true);
            Tolk.Load();
            if (Properties.Settings.Default.SpeechSystem == "Azure")
            {
                // disabling Azure speech for now since we're trying to debug issues. If speech is set to azure, we force it to screen reader.
                // SetupAzureSpeech();
                Properties.Settings.Default.SpeechSystem = "ScreenReader";
            }

            // Initialize audio output
            SetupAudio();
            var version = typeof(IOSubsystem).Assembly.GetName().Version.Build;
            HotkeyManager.Current.AddOrReplace("Command_Key", (Keys)Properties.Hotkeys.Default.Command_Key, commandMode);
            HotkeyManager.Current.AddOrReplace("ap_Command_Key", (Keys)Properties.Hotkeys.Default.ap_Command_Key, autopilotCommandMode);
            // HotkeyManager.Current.AddOrReplace("test", Keys.Q, RunTest);

            runwayGuidanceEnabled = false;


            // hook up events for timers
            GroundSpeedTimer.Elapsed += onGroundSpeedTimerTick;
            ilsTimer.Elapsed += onILSTimerTick;
            waypointTransitionTimer.Elapsed += onWaypointTransitionTimerTick;
            WarningsTimer.Elapsed += WarningsTimer_Tick;
            // start the flight following timer if it is enabled in settings
            SetupFlightFollowing();
            // populate the dictionary for the altitude callout flags
            for (int i = 1000; i < 65000; i += 1000)
            {
                altitudeCalloutFlags.Add(i, false);
            }
            pmdg = new PMDGPanelUpdateEvent();
            
           
        }

        private void RunTest(object sender, HotkeyEventArgs e)
        {
            e.Handled = true;
            Tolk.Output(FSUIPCConnection.ReadLVar("switch_28_73X").ToString("f2"));
             FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_APU_GEN1_SWITCH, Aircraft.ClkL);



        }


        /*private void SetupAzureSpeech()
{
   try
   {
       azureConfig = SpeechConfig.FromSubscription(Properties.Settings.Default.AzureAPIKey, Properties.Settings.Default.AzureServiceRegion);
       azureSynth = new Microsoft.CognitiveServices.Speech.SpeechSynthesizer(azureConfig);

   }
   catch (Exception x)
   {
       MessageBox.Show("error setting up Azure Speech. Either you did not enter an API key, or the settings file needs updating.\n If adding the Azure key doesn't work, try deleting your settings file and restarting TFM. ");
       logger.Debug($"Error setting up Azure speech: {x.Message}");

   }
}
*/
        private void SetupAudio()
        {
            driverOut = new WaveOutEvent() { DesiredLatency = 50 };

            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 2))
            {
                ReadFully = true
            };
            driverOut.Init(mixer);
            // start the mixer. We can then add audio sources as needed.
            driverOut.Play();

        }

        private void onWaypointTransitionTimerTick(object sender, ElapsedEventArgs e)
        {
            waypointTransition = false;
            readWaypointFlag = true;
        }

        public void SetupFlightFollowing()
        {
            flightFollowingTimer = new System.Timers.Timer(TimeSpan.FromMinutes(double.Parse(Properties.Settings.Default.FlightFollowingTimeInterval)).TotalMilliseconds);
            flightFollowingTimer.Elapsed += onFlightFollowingTimerTick;
            if (Properties.Settings.Default.FlightFollowing)
            {
                flightFollowingTimer.AutoReset = true;
                flightFollowingTimer.Enabled = true;

            }
            else
            {
                flightFollowingTimer.Stop();


            }

        }

        private void onFlightFollowingTimerTick(object sender, ElapsedEventArgs e)
        {
            // this just reads the flight following info, same as the hotkey

            if (Properties.Settings.Default.GeonamesUsername == "") return;
            OnCityKey();
        }

        private void OffsetTest(object sender, HotkeyEventArgs e)
        {
            Tolk.Output(FSUIPCConnection.ReadLVar("ngx_switch_28_a").ToString());
        }

        public void ReadAircraftState()
        {
            // If this is the first time through the loop, don't read instruments.

            if (!FirstRun || InstrumentationEnabled)
            {
                // Read when aircraft changes
                if (Aircraft.AircraftName.ValueChanged)
                {
                    string name = Aircraft.AircraftName.Value;
                    Output(isGauge: false, output: "Current aircraft: " + Aircraft.AircraftName.Value);
                    if (name.Contains("PMDG"))
                    {
                        if (name.Contains("737"))
                        {
                            PMDG737Detected = true;
                        }
                        if (name.Contains("747"))
                        {
                            PMDG747Detected = true;
                        }
                        if (name.Contains("777"))
                        {
                            PMDG777Detected = true;
                        }

                    }
                    DetectFuelTanks();
                }

                // read any instruments that are toggles
                ReadToggle(Aircraft.SimPauseIndicator, Aircraft.SimPauseIndicator.Value > 0, "", "paused", "unpaused");
                ReadToggle(Aircraft.SimSoundFlag, Aircraft.SimSoundFlag.Value > 0, "sound", "on", "off");
                ReadToggle(Aircraft.AvionicsMaster, Aircraft.AvionicsMaster.Value > 0, "avionics master", "active", "off");
                ReadToggle(Aircraft.SeatbeltSign, Aircraft.SeatbeltSign.Value > 0, "seatbelt sign", "on", "off");
                ReadToggle(Aircraft.NoSmokingSign, Aircraft.NoSmokingSign.Value > 0, "no smoking sign", "on", "off");
                ReadToggle(Aircraft.PitotHeat, Aircraft.PitotHeat.Value > 0, "Pitot Heat", "on", "off");
                ReadToggle(Aircraft.ParkingBrake, Aircraft.ParkingBrake.Value > 0, "Parking brake", "on", "off");
                ReadToggle(Aircraft.AutoFeather, Aircraft.AutoFeather.Value > 0, "Auto Feather", "Active", "off");
                ReadToggle(Aircraft.ApMaster, Aircraft.ApMaster.Value > 0, "Auto pilot master", "active", "off");
                ReadToggle(Aircraft.AutoThrottleArm, Aircraft.AutoThrottleArm.Value > 0, "Auto Throttle", "Armed", "off");
                ReadToggle(Aircraft.ApYawDamper, Aircraft.ApYawDamper.Value > 0, "Yaw Damper", "active", "off");
                ReadToggle(Aircraft.Toga, Aircraft.Toga.Value > 0, "take off power", "active", "off");
                // if approach mode is on, read altitude and heading lock using SAPI
                if (Aircraft.ApApproachHold.Value == 1)
                {
                    ReadToggle(Aircraft.ApAltitudeLock, Aircraft.ApAltitudeLock.Value > 0, "altitude lock", "active", "off", true);
                    ReadToggle(Aircraft.ApHeadingLock, Aircraft.ApHeadingLock.Value > 0, "Heading lock", "active", "off", true);
                }
                else
                {
                    ReadToggle(Aircraft.ApAltitudeLock, Aircraft.ApAltitudeLock.Value > 0, "altitude lock", "active", "off");
                    ReadToggle(Aircraft.ApHeadingLock, Aircraft.ApHeadingLock.Value > 0, "Heading lock", "active", "off");

                }
                ReadToggle(Aircraft.ApNavLock, Aircraft.ApNavLock.Value > 0, "nav lock", "active", "off");
                ReadToggle(Aircraft.ApFlightDirector, Aircraft.ApFlightDirector.Value > 0, "Flight Director", "Active", "off");
                ReadToggle(Aircraft.ApNavGPS, Aircraft.ApNavGPS.Value > 0, "Nav gps switch", "set to GPS", "set to nav");
                ReadToggle(Aircraft.ApWingLeveler, Aircraft.ApWingLeveler.Value > 0, "Wing leveler", "active", "off");
                ReadToggle(Aircraft.ApAutoRudder, Aircraft.ApAutoRudder.Value > 0, "Auto rudder", "active", "off");
                ReadToggle(Aircraft.ApApproachHold, Aircraft.ApApproachHold.Value > 0, "approach mode", "active", "off");
                ReadToggle(Aircraft.ApGlideSlopeHold, Aircraft.ApGlideSlopeHold.Value > 0, "Glide slope hold", "active", "off");
                ReadToggle(Aircraft.ApSpeedHold, Aircraft.ApSpeedHold.Value > 0, "Airspeed hold", "active", "off");
                ReadToggle(Aircraft.ApMachHold, Aircraft.ApMachHold.Value > 0, "Mach hold", "Active", "off");
                ReadToggle(Aircraft.PropSync, Aircraft.PropSync.Value > 0, "Propeller Sync", "active", "off");
                ReadToggle(Aircraft.BatteryMaster, Aircraft.BatteryMaster.Value > 0, "Battery Master", "active", "off");
                // TODO: add check for a2a since below toggles aren't needed for a2a
                ReadToggle(Aircraft.FuelPump, Aircraft.FuelPump.Value > 0, "Fuel pump", "active", "off");

                ReadLandingGear();
                if (Properties.Settings.Default.ReadAutopilot) ReadAutopilotInstruments();
                if (Properties.Settings.Default.ReadGroundSpeed) ReadGroundSpeed();
                readAutopilotAltitude();
                if (Properties.Settings.Default.AltitudeAnnouncements) ReadAltitudeAnnouncement();

                ReadTransponder();
                ReadRadios();
                ReadAutoBrake();
                ReadSpoilers();
                ReadTrim();
                ReadAltimeter(TriggeredByKey: false);
                NextWaypoint();
                ReadLights();
                ReadDoors();
                if (Properties.Settings.Default.ReadILS) ReadILSInfo();
                ReadSimulationRate(TriggeredByKey: false);
                readAPU();
                readOnGround();
                readWarnings();

                // TODO: engine select
                if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("737"))
                {
                    ReadPMDG737Toggles();
                    ReadPmdgFMCMessage();
                }

                if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("747"))
                {
                    foreach (KeyValuePair<string, Dictionary<string, Dictionary<Offset<byte>, string>>> panel in PMDG747.Lights)
                    {
                        foreach (KeyValuePair<string, Dictionary<Offset<byte>, string>> panelSection in panel.Value)
                        {
                            foreach (KeyValuePair<Offset<byte>, string> light in panelSection.Value)
                            {
                                ReadToggle(light.Key, light.Key.Value > 0, $"{light.Value} light", "On", "Off");
                            }
                        }
                    }

                    ReadPMDG747Toggles();
                    ReadPmdgFMCMessage();
                } // End read 747 toggles.
                if (PMDG777Detected)
                {
                    foreach (tfm.PMDG.PanelObjects.PanelObject control in PMDG777Aircraft.PanelControls)
                    {
                        if (control.Name == "Speedbrake") continue;
                                                if (control.Offset.ValueChanged)
                        {
                                                        Output(isGauge: false, output: control.ToString());
                        }
                    }
                    
                    foreach(SingleStateToggle toggle in PMDG777Aircraft.PanelControls)
                    {
                        if(toggle.Name == "Speedbrake")
                        {
                            if (toggle.Offset.ValueChanged)
                            {
                                pmdg777SpeedBrakeMoving = true;
                            }
                            else
                            {
                                if (pmdg777SpeedBrakeMoving)
                                {
                                    pmdg777SpeedBrakeMoving = false;
                                    Output(isGauge: false, output: toggle.ToString());
                                }
                            }
                        }// speedbrake
                    } // speedbrake silence routine.
                    ReadPmdgFMCMessage();
                } // End PMDG 777 toggles.
            }
            else
            {
                string name = Aircraft.AircraftName.Value;
                Output(isGauge: false, output: "Current aircraft: " + Aircraft.AircraftName.Value);
                if (name.Contains("PMDG"))
                {
                    if (name.Contains("737"))
                    {
                        PMDG737Detected = true;
                        Tolk.Output("737 detected");
                    }
                    if (name.Contains("747"))
                    {
                        PMDG747Detected = true;
                    }
                    if (name.Contains("777"))
                    {
                        PMDG777Detected = true;
                    }
                }

                DetectFuelTanks();
                FirstRun = false;
            }
        }

        private void readWarnings()
        {
            // if stall or overspeed warnings are active, read a SAPI message every 5 seconds
            if (WarningFlag == false)
            {
                if (Aircraft.StallWarning.Value == 1 || Aircraft.OverSpeedWarning.Value == 1)
                {
                    WarningFlag = true;

                    WarningsTimer.AutoReset = true;
                    WarningsTimer.Enabled = true;
                }
            }

        }

        private void WarningsTimer_Tick(object sender, ElapsedEventArgs e)
        {
            if (Aircraft.StallWarning.Value == 1)
            {
                Output(isGauge: false, useSAPI: true, output: "stall warning! ");
            }
            if (Aircraft.OverSpeedWarning.Value == 1)
            {
                Output(isGauge: false, useSAPI: true, output: "over speed warning! ");
            }
            if (Aircraft.StallWarning.Value == 0 && Aircraft.OverSpeedWarning.Value == 0)
            {
                WarningFlag = false;
                WarningsTimer.Stop();
            }
        }

        public void ReadLowPriorityInstruments()
        {
            ReadToggle(Aircraft.Eng1Starter, Aircraft.Eng1Starter.Value > 0, "Number 1 starter", "engaged", "off");
            ReadToggle(Aircraft.Eng2Starter, Aircraft.Eng2Starter.Value > 0, "Number 2 starter", "engaged", "off");
            ReadToggle(Aircraft.Eng3Starter, Aircraft.Eng3Starter.Value > 0, "Number 3 starter", "engaged", "off");
            ReadToggle(Aircraft.Eng4Starter, Aircraft.Eng4Starter.Value > 0, "Number 4 starter", "engaged", "off");
            ReadToggle(Aircraft.Eng1Combustion, Aircraft.Eng1Combustion.Value > 0, "Number 1 ignition", "on", "off");
            ReadToggle(Aircraft.Eng2Combustion, Aircraft.Eng2Combustion.Value > 0, "Number 2 ignition", "on", "off");
            ReadToggle(Aircraft.Eng3Combustion, Aircraft.Eng3Combustion.Value > 0, "Number 3 ignition", "on", "off");
            ReadToggle(Aircraft.Eng4Combustion, Aircraft.Eng4Combustion.Value > 0, "Number 4 ignition", "on", "off");
            ReadToggle(Aircraft.Eng1Generator, Aircraft.Eng1Generator.Value > 0, "Number 1 generator", "active", "off");
            ReadToggle(Aircraft.Eng2Generator, Aircraft.Eng2Generator.Value > 0, "Number 2 generator", "active", "off");
            ReadToggle(Aircraft.Eng3Generator, Aircraft.Eng3Generator.Value > 0, "Number 3 generator", "active", "off");
            ReadToggle(Aircraft.Eng4Generator, Aircraft.Eng4Generator.Value > 0, "Number 4 generator", "active", "off");
            ReadToggle(Aircraft.APUGenerator, Aircraft.APUGenerator.Value > 0, "A P U Generator", "active", "off");
            ReadToggle(Aircraft.Eng1FuelValve, Aircraft.Eng1FuelValve.Value > 0, "number 1 fuel valve", "open", "closed");
            ReadToggle(Aircraft.Eng2FuelValve, Aircraft.Eng2FuelValve.Value > 0, "number 2 fuel valve", "open", "closed");
            ReadToggle(Aircraft.Eng3FuelValve, Aircraft.Eng3FuelValve.Value > 0, "number 3 fuel valve", "open", "closed");
            ReadToggle(Aircraft.Eng4FuelValve, Aircraft.Eng4FuelValve.Value > 0, "number 4 fuel valve", "open", "closed");
            if (Properties.Settings.Default.ReadSimconnectMessages) ReadSimConnectMessages();
            ReadFlaps();
                    }

        private void readOnGround()
        {
            if (Aircraft.OnGround.ValueChanged)
            {
                if (Aircraft.OnGround.Value == 1)
                {
                    Output(isGauge: false, useSAPI: true, output: "on ground. ");
                }
                else
                {
                    Output(isGauge: false, useSAPI: true, output: "airborn. ");
                }

            }
        }

        private void readAPU()
        {
            double apuPercent = Math.Round((double)Aircraft.APUPercentage.Value);
            if (Aircraft.APUPercentage.ValueChanged)
            {
                if (apuPercent > 4 && apuStarting == false && apuRunning == false && apuShuttingDown == false && apuOff == true)
                {
                    Output(isGauge: false, output: "A P U starting. ");
                    apuStarting = true;
                    apuOff = false;
                }
                if (apuPercent == 100 && apuStarting == true)
                {
                    apuStarting = false;
                    apuRunning = true;
                    Output(isGauge: false, output: "A P U at 100 percent. ");
                }
                if (apuPercent < 100 && apuRunning == true)
                {
                    apuRunning = false;
                    apuShuttingDown = true;
                    Output(isGauge: false, output: "A P U shutting down. ");
                }
                if (apuPercent == 0 && apuOff == false)
                {
                    apuRunning = false;
                    apuStarting = false;
                    apuShuttingDown = false;
                    apuOff = true;
                    Output(isGauge: false, output: "A P U shut down. ");
                }

            }
        }

        private void ReadAltitudeAnnouncement()
        {
            // read altitude every 1000 feet
            double alt = Math.Round((double)Aircraft.Altitude.Value);
            double radioAlt = Math.Round((double)Aircraft.RadioAltimeter.Value / 65536d * 3.28084d);
            double vSpeed = Math.Round((Aircraft.VerticalSpeed.Value * 3.28084) * -1);

            for (int i = 1000; i < 65000; i += 1000)
            {
                if (alt >= i - 10 && alt <= i + 10 && altitudeCalloutFlags[i] == false)
                {
                    Output(isGauge: false, output: $"{i} feet. ");
                    altitudeCalloutFlags[i] = true;

                }
                else
                {
                    if (alt >= i + 100)
                    {
                        altitudeCalloutFlags[i] = false;

                    }
                }
            }
            if (Properties.Settings.Default.ReadGPWS == true)
            {
                try
                {
                    if (radioAlt < 10000 && vSpeed < -50)
                    {
                        var gpwsKeys = new List<int>(gpwsFlags.Keys);
                        foreach (int key in gpwsKeys)
                        {
                            if (radioAlt <= key + 5 && radioAlt >= key - 5 && gpwsFlags[key] == false)
                            {
                                gpwsSound = new WaveFileReader("sounds\\" + key.ToString() + ".wav");
                                // SoundPlayer snd = new SoundPlayer("sounds\\" + key.ToString() + ".wav");
                                // snd.Play();
                                mixer.AddMixerInput(gpwsSound.ToSampleProvider().ToStereo());
                                gpwsFlags[key] = true;
                            }
                            else
                            {
                                if (radioAlt > key + 50)
                                {
                                    gpwsFlags[key] = false;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }

            }
        }

        private void DetectFuelTanks()
        {
            // clear fuel tank data
            ActiveTanks.Clear();
            // grab fuel tank data from the sim
            FSUIPCConnection.PayloadServices.RefreshData();
            // Assign the fuel tanks to our class level variable for easier access
            FuelTanks = FSUIPCConnection.PayloadServices.FuelTanks;
            foreach (FsFuelTank tank in FuelTanks)
            {
                if (tank.IsPresent)
                {
                    ActiveTanks.Add(tank);
                    Logger.Debug("found " + tank.Tank.ToString());
                }
            }

        }
        private void ReadTrim()
        {

            if (PMDG737Detected)
            {
                                                                                if(PMDG737Aircraft.CurrentElevatorTrim != OldElevatorTrim && TrimEnabled)
                {
                    Output(isGauge: false, output: $"{PMDG737Aircraft.CurrentElevatorTrim}");
                    OldElevatorTrim = PMDG737Aircraft.CurrentElevatorTrim;
                }
                            } // end-pmdg737-trim
            else
            {
                // Elevator trim
                double elevator = (double)Aircraft.ConvertRadiansToDegrees(Aircraft.ElevatorTrim.Value);
                double aileron = (double)Aircraft.ConvertRadiansToDegrees(Aircraft.AileronTrim.Value);
                if (Aircraft.ElevatorTrim.ValueChanged && Aircraft.ApMaster.Value != 1 && TrimEnabled)

                {
                    if (elevator < 0)
                    {
                        Output(isGauge: false, output: $"Trim down {Math.Abs(Math.Round(elevator, 2)):F2}. ");
                    }
                    else
                    {
                        Output(isGauge: false, output: $"Trim up: {Math.Round(elevator, 2):F2}");
                    }

                }
                if (Aircraft.AileronTrim.ValueChanged && Aircraft.ApMaster.Value != 1 && TrimEnabled)
                {
                    if (aileron < 0)
                    {
                        Output(isGauge: false, output: $"Trim left {Math.Abs(Math.Round(aileron, 2))}. ");
                    }
                    else
                    {
                        Output(isGauge: false, output: $"Trim right {Math.Round(aileron, 2)}");
                    }
                }
            }// end-freeware-trim
        }

        private void ReadAltimeter(bool TriggeredByKey)
        {
            if (Aircraft.Altimeter.ValueChanged || TriggeredByKey)
            {
                double AltQNH = (double)Aircraft.Altimeter.Value / 16d;
                double AltHPA = Math.Floor(AltQNH + 0.5);
                double AltInches = Math.Floor(((100 * AltQNH * 29.92) / 1013.2) + 0.5);
                var isGauge = true;
                var gaugeName = "Altimeter";
                var gaugeValue = $"{AltHPA}, {AltInches / 100} inches. ";
                Output(gaugeName, gaugeValue, isGauge);
            }


        }


        private void ReadAutoBrake()
        {
                                       
            string AbState = null;
            if (Aircraft.AutoBrake.ValueChanged)
            {
                switch (Aircraft.AutoBrake.Value)
                {
                    case 0:
                        AbState = "R T O";
                        break;
                    case 1:
                        AbState = "off";
                        break;
                    case 2:
                        AbState = "position 1";
                        break;
                    case 3:
                        AbState = "position 2";
                        break;
                    case 4:
                        AbState = "position 3";
                        break;
                    case 5:
                        AbState = "maximum";
                        break;

                }
                Output(isGauge: false, output: "Autobrake " + AbState);
            }
        }

        private void ReadRadios()
        {
            FsFrequencyCOM com1Helper = new FsFrequencyCOM(Aircraft.Com1Freq.Value);
            FsFrequencyCOM com2Helper = new FsFrequencyCOM(Aircraft.Com2Freq.Value);
            FsFrequencyNAV nav1Helper = new FsFrequencyNAV(Aircraft.Nav1Freq.Value);
            FsFrequencyNAV nav2Helper = new FsFrequencyNAV(Aircraft.Nav2Freq.Value);
            bool isGauge = true;
            string gaugeName;
            string gaugeValue;
            if (Aircraft.Com1Freq.ValueChanged)
            {
                gaugeName = "Com1";
                gaugeValue = com1Helper.ToString();
                Output(gaugeName, gaugeValue, isGauge);

            }
            if (Aircraft.Com2Freq.ValueChanged)
            {
                gaugeName = "Com2";
                gaugeValue = com2Helper.ToString();
                Output(gaugeName, gaugeValue, isGauge);

            }
            if (Properties.Settings.Default.ReadNavRadios == true)
            {
                if (Aircraft.Nav1Freq.ValueChanged)
                {
                    gaugeName = "Nav1";
                    gaugeValue = nav1Helper.ToString();
                    Output(gaugeName, gaugeValue, isGauge);

                }
                if (Aircraft.Nav2Freq.ValueChanged)
                {
                    gaugeName = "Nav2";
                    gaugeValue = nav2Helper.ToString();
                    Output(gaugeName, gaugeValue, isGauge);

                }

            }
        }

        private void ReadTransponder()
        {

            FsTransponderCode txHelper = new FsTransponderCode(Aircraft.Transponder.Value);
            if (Aircraft.Transponder.ValueChanged)
            {
                var gaugeName = "Transponder";
                var gaugeValue = txHelper.ToString();
                var isGauge = true;
                Output(gaugeName, gaugeValue, isGauge);

            }

        }

        private void NextWaypoint()
        {
            // convert distance to nautical miles
            double dist = Aircraft.NextWPDistance.Value * 0.00053995D;

            if (waypointTransition == false && readWaypointFlag == true)
            {
                ReadWayPoint();
                return;
            }
            if (Aircraft.NextWPName.ValueChanged)
            {
                waypointTransitionTimer.AutoReset = false;
                waypointTransitionTimer.Start();

            }

        }

        private void ReadWayPoint()
        {
            double dist = Aircraft.NextWPDistance.Value * 0.00053995D;
            string name = Aircraft.NextWPName.Value;
            string strDist = dist.ToString("F0");
            TimeSpan TimeEnroute = TimeSpan.FromSeconds(Aircraft.NextWPETE.Value);
            double baring = Aircraft.ConvertRadiansToDegrees((double)Aircraft.NextWPBaring.Value);
            string strBaring = baring.ToString("F0");
            string strTime = string.Format("{0:%h} hours, {0:%m} minutes, {0:%s} seconds", TimeEnroute);
            readWaypointFlag = false;
            if (TimeEnroute.Hours == 0)
            {
                strTime = string.Format("{0:%m} minutes, {0:%s} seconds", TimeEnroute);
            }
            if (TimeEnroute.Minutes == 0 && TimeEnroute.Hours == 0)
            {
                strTime = string.Format("{0:%s} seconds", TimeEnroute);
            }
            Output(isGauge: false, output: $"Next waypoint: {name}.\nDistance: {strDist} nautical miles.\nBaring: {strBaring} degrees.\n{strTime}");
        }
        private void ReadLights()
        {
            // read when aircraft lights change
            if (Aircraft.Lights.ValueChanged)
            {
                string state = null;
                // loop through each bit and announce which values have changed.
                FsBitArray lightBits = Aircraft.Lights.Value;
                for (int i = 0; i < lightBits.Changed.Length; i++)
                {
                    if (lightBits.Changed[i])
                    {
                        string name = Enum.GetName(typeof(Aircraft.light), i);
                        // string state = (Aircraft.Lights.Value[i]) ? "off" : "on";
                        if (Aircraft.Lights.Value[i] == true)
                        {
                            state = "on";
                        }
                        else
                        {
                            state = "off";
                        }
                        Output(isGauge: false, output: $"{name} {state}. ");
                    }
                }
            }

        }
        private void ReadDoors()
        {
            // read aircraft exit status
            if (Aircraft.Doors.ValueChanged)
            {
                // loop through each bit and announce which values have changed.
                FsBitArray DoorBits = Aircraft.Doors.Value;
                for (int i = 0; i < DoorBits.Changed.Length; i++)
                {
                    if (DoorBits.Changed[i])
                    {
                        string state = (Aircraft.Doors.Value[i]) ? "open" : "closed";
                        Output(isGauge: false, output: $"door {i + 1} {state}. ");
                    }
                }
            }

        }

        private void ReadILSInfo()
        {
            double vspeed = (double)Aircraft.VerticalSpeed.Value * 3.28084d * -1;
            if (Properties.Settings.Default.ReadILS && Aircraft.OnGround.Value == 0 && vspeed < 200)
            {
                if (Aircraft.Nav1GS.Value == 1 && gsDetected == false)
                {
                    if (Properties.Settings.Default.SapiILSAnnouncements)
                    {
                        Output(isGauge: false, useSAPI: true, output: "glide slope is alive. ");
                    }
                    else
                    {
                        Output(isGauge: false, output: "glide slope is alive. ");
                    }
                    
                    gsDetected = true;
                }
                if (Aircraft.Nav1Flags.Value[7] && hasLocaliser == false)
                {
                    if (Properties.Settings.Default.SapiILSAnnouncements)
                    {
                        Output(isGauge: false, useSAPI: true, output: "nav 1 has localiser.");
                    }
                    else
                    {
                        Output(isGauge: false, output: "nav 1 has localiser.");
                    }
                    
                    hasLocaliser = true;
                }
                if (Aircraft.Nav1Signal.Value == 256 && localiserDetected == false && Aircraft.Nav1Flags.Value[7])
                {

                                       double hdgTrue = (double)Aircraft.Heading.Value * 360d / (65536d * 65536d);
                                         double magvar = (double)Aircraft.MagneticVariation.Value * 360d / 65536d;
                                        double magHeading = hdgTrue - magvar;
                                         double rwyHeading = (double)Aircraft.Nav1LocaliserInverseRunwayHeading.Value * 360d / 65536d + 180d - magvar;

                    if (Properties.Settings.Default.SapiILSAnnouncements)
                    {
                        Output(isGauge: false, useSAPI: true, output: "Localiser is alive. Runway heading" + rwyHeading.ToString("F0"));
                    }
                    else
                    {
                        Output(isGauge: false,output: "Localiser is alive. Runway heading" + rwyHeading.ToString("F0"));
                    }
                                        
                                                            localiserDetected = true;
                    ilsTimer.AutoReset = true;
                    ilsTimer.Enabled = true;

                }
                if (Aircraft.Nav1Flags.Value[6] && hasGlideSlope == false)
                {

                    if (Properties.Settings.Default.SapiILSAnnouncements)
                    {
                        Output(isGauge: false, useSAPI: true, output: "nav 1 has glide slope. ");
                    }
                    else
                    {
                        Output(isGauge: false,output: "nav 1 has glide slope. ");
                    }

                    hasGlideSlope = true;
                }

            }
            else
            {
                ilsTimer.Enabled = false;
                hasGlideSlope = false;
                hasLocaliser = false;
                localiserDetected = false;
                gsDetected = false;
            }
        }

        private void onILSTimerTick(object sender, ElapsedEventArgs e)
        {
            FlightPlan.Destination.SetReferenceLocation(AirportComponents.Runways);
            double gsNeedle = (double)Aircraft.Nav1GSNeedle.Value;
            double locNeedle = (double)Aircraft.Nav1LocNeedle.Value;
            double locPercent;
            double gsPercent;
            double magvar = (double)Aircraft.MagneticVariation.Value * 360d / 65536d;
            double rwyHeading = (double)Aircraft.Nav1LocaliserInverseRunwayHeading.Value * 360d / 65536d + 180d - magvar;
            // if on ground, stop reading ILS values
            if (Aircraft.OnGround.Value == 1)
            {
                ilsTimer.Enabled = false;
                return;
            }
            // only read ils when approach mode is on
            if (Aircraft.ApApproachHold.Value == 1 || Aircraft.pmdg737.MCP_annunAPP.Value == 1 || Aircraft.pmdg747.MCP_annunAPP.Value == 1 || Aircraft.pmdg777.MCP_annunAPP.Value == 1)
            {
                if (Properties.Settings.Default.ReadGSAltitude)
                {
                    var gsHeight = utility.CalculateAngleHeight(FlightPlan.DestinationRunway.DistanceFeet, FlightPlan.DestinationRunway.ILSInfo.Slope);
                                        var relativeGsHeight = Autopilot.AglAltitude - gsHeight;
                    relativeGsHeight = Math.Round(relativeGsHeight, 0);

                    if (relativeGsHeight > 0)
                    {
                        var gaugeName = "Glide slope";
                        var gaugeValue = $"{relativeGsHeight} down.";
                        var isGauge = true;

                        if (Properties.Settings.Default.SapiILSAnnouncements)
                        {
                            Output(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);
                        }
                        else
                        {
                            Output(gaugeName, gaugeValue, isGauge, textOutput: false);
                        }

                    }
                    if (relativeGsHeight < 0)
                    {
                        var gaugeName = "Glide slope";
                        var gaugeValue = $"{Math.Abs(relativeGsHeight)} up";
                        var isGauge = true;

                        if (Properties.Settings.Default.SapiILSAnnouncements)
                        {
                            Output(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);
                        }
                        else
                        {
                            Output(gaugeName, gaugeValue, isGauge, textOutput: false);
                        }
                                            }
                    if (relativeGsHeight == 0)
                    {
                        var gaugeName = "Glide slope";
                        var gaugeValue = "Centered.";
                        var isGauge = true;

                        if (Properties.Settings.Default.SapiILSAnnouncements)
                        {
                            Output(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);
                        }
                        else
                        {
                            Output(gaugeName, gaugeValue, isGauge, textOutput: false);
                        }
                    }
                }
                else
                {
                    if (gsNeedle > 0 && gsNeedle < 119)
                    {
                        gsPercent = gsNeedle / 119 * 100;
                        string strPercent = gsPercent.ToString("F0");
                        var gaugeName = "Glide slope";
                        var gaugeValue = $"up {strPercent} percent. ";
                        var isGauge = true;

                        if (Properties.Settings.Default.SapiILSAnnouncements)
                        {
                            Output(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);
                        }
                        else
                        {
                            Output(gaugeName, gaugeValue, isGauge, textOutput: false);
                        }
                    }
                    if (gsNeedle < 0 && gsNeedle > -119)
                    {
                        gsPercent = Math.Abs(gsNeedle) / 119 * 100;
                        string strPercent = gsPercent.ToString("F0");
                        var gaugeName = "Glide slope";
                        var gaugeValue = $"down {strPercent} percent. ";
                        var isGauge = true;

                        if (Properties.Settings.Default.SapiILSAnnouncements)
                        {
                            Output(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);
                        }
                        else
                        {
                            Output(gaugeName, gaugeValue, isGauge, textOutput: false);
                        }
                                            }
                }
                if (Properties.Settings.Default.ReadLocaliserHeadingOffsets)
                {
                                        double heading = (double)Aircraft.Nav1LocaliserInverseRunwayHeading.Value * 360d / 65536d + 180d - magvar;
                    var headingOffset = utility.ReadHeadingOffset(Autopilot.Heading, heading);
                    headingOffset = Math.Round(headingOffset, 0);
                    if (headingOffset < 0)
                    {
                        var gaugeName = "Localiser";
                        var isGauge = true;
                        var gaugeValue = $"Left {Math.Abs(headingOffset)}";

                        if (Properties.Settings.Default.SapiILSAnnouncements)
                        {
                            Output(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);
                        }
                        else
                        {
                            Output(gaugeName, gaugeValue, isGauge, textOutput: false);
                        }

                    }
                    if (headingOffset > 0)
                    {
                        var gaugeName = "Localiser";
                        var isGauge = true;
                        var gaugeValue = $"Right {headingOffset}";

                        if (Properties.Settings.Default.SapiILSAnnouncements)
                        {
                            Output(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);
                        }
                        else
                        {
                            Output(gaugeName, gaugeValue, isGauge, textOutput: false);
                        }

                    }
                    if (headingOffset == 0)
                    {
                        var gaugeName = "Localiser";
                        var isGauge = true;
                        var gaugeValue = "Centered.";
                        if (Properties.Settings.Default.SapiILSAnnouncements)
                        {
                            Output(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);
                        }
                        else
                        {
                            Output(gaugeName, gaugeValue, isGauge, textOutput: false);
                        }


                    }
                }
                else
                {
                    if (locNeedle > 0 && locNeedle < 127)
                    {
                        locPercent = locNeedle / 127 * 100;
                        string strPercent = locPercent.ToString("F0");
                        var gaugeName = "Localiser";
                        var gaugeValue = $"{strPercent} percent right. ";
                        var isGauge = true;

                        if (Properties.Settings.Default.SapiILSAnnouncements)
                        {
                            Output(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);
                        }
                        else
                        {
                            Output(gaugeName, gaugeValue, isGauge, textOutput: false);
                        }

                    }
                    if (locNeedle < 0 && locNeedle > -127)
                    {
                        locPercent = Math.Abs(locNeedle) / 127 * 100;
                        string strPercent = locPercent.ToString("F0");
                        var gaugeName = "Localiser";
                        var gaugeValue = $"{strPercent} percent left. ";
                        var isGauge = true;

                        if (Properties.Settings.Default.SapiILSAnnouncements)
                        {
                            Output(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);
                        }
                        else
                        {
                            Output(gaugeName, gaugeValue, isGauge, textOutput: false);
                        }

                    }
                }
                            }
        }

        private void ReadSimulationRate(bool TriggeredByKey)
        {
            double rate = (double)Aircraft.SimulationRate.Value / 256;
            if (TriggeredByKey)
            {
                Output(isGauge: false, output: $"simulation rate: {rate}");
            }
            if (Aircraft.SimulationRate.ValueChanged && rate >= 0.25)
            {
                Output(isGauge: false, output: $"simulation rate: {rate}");
            }
        }
        private void ReadSpoilers()
        {
            if (Aircraft.Spoilers.ValueChanged)
            {
                uint sp = Aircraft.Spoilers.Value;
                if (sp == 4800) Output(isGauge: false, output: "Spoilers armed. ");
                else if (sp == 16384) Output(isGauge: false, output: "Spoilers deployed. ");
                else if (sp == 0)
                {
                    if (OldSpoilersValue == 4800)
                    {
                        Output(isGauge: false, output: "arm spoilers off. ");
                    }
                    else
                    {
                        Output(isGauge: false, output: "spoilers retracted. ");
                    }

                }
            }
        }

        private void onSpoilersKey()
        {
            uint currentSpoilers = Aircraft.Spoilers.Value;
            if (currentSpoilers == 0)
            {
                Output(isGauge: false, output: "Spoilers retracted.");
            }
            else if (currentSpoilers == 4800)
            {
                Output(isGauge: false, output: "Spoilers armed.");
            }
            else if (currentSpoilers >= 5620)
            {
                Output(isGauge: false, output: $"Spoilers: {Autopilot.SpoilerPercent}");
            }
        }


        private void ReadFlaps()
        {
            if (PMDG737Detected)
            {
                if (Aircraft.pmdg737.MAIN_TEFlapsNeedle[0].ValueChanged)
                {
                    FlapsMoving = true;
                                    } // value changed.
                else
                {
                    if (FlapsMoving)
                    {
                        FlapsMoving = false;
                        var gaugeName = "Flaps";
                        var gaugeValue = PMDG737Aircraft.CurrentFlapsPosition.ToString();
                        var isGauge = true;
                        Output(gaugeName, gaugeValue, isGauge);
                    } // Flaps are moving.
                } // Report flaps position.
            } // PMDG 737.
            else if (PMDG747Detected)
            {
                if (Aircraft.Flaps.ValueChanged)
                {
                    FlapsMoving = true;
                } // value changed.
                else
                {
                    if (FlapsMoving)
                    {
                        FlapsMoving = false;
                        var gaugeName = "Flaps";
                        var gaugeValue = PMDG747Aircraft.CurrentFlapsPosition.ToString();
                        var isGauge = true;
                        Output(gaugeName, gaugeValue, isGauge);
                    } // Flaps are moving.
                } // Report flaps position.
            } // PMDG 747
else              if (PMDG777Detected)
            {
                if (Aircraft.Flaps.ValueChanged)
                {
                    FlapsMoving = true;
                } // value changed.
                else
                {
                    if (FlapsMoving)
                    {
                        FlapsMoving = false;
                        var gaugeName = "Flaps";
                        var gaugeValue = PMDG777Aircraft.CurrentFlapsPosition.ToString();
                        var isGauge = true;
                        Output(gaugeName, gaugeValue, isGauge);
                    } // Flaps are moving.
                } // Report flaps position.
            } // PMDG 777
            else
            {
                if (Aircraft.Flaps.ValueChanged)
                {
                    FlapsMoving = true;
                }
                else
                {
                    if (FlapsMoving)
                    {
                        FlapsMoving = false;
                        double FlapsAngle = (double)Aircraft.Flaps.Value / 256d;
                        var gaugeName = "Flaps";
                        var gaugeValue = FlapsAngle.ToString("f0");
                        var isGauge = true;
                        Output(gaugeName, gaugeValue, isGauge);
                    }
                }

            }

        }
        public void ReadLandingGear()
        {
            var gaugeName = "Gear";
            var isGauge = true;
            string gaugeValue;
            if (Aircraft.LandingGear.ValueChanged)
            {
                if (Aircraft.LandingGear.Value == 0)
                {
                    gaugeValue = "up. ";
                    Output(gaugeName, gaugeValue, isGauge);
                }
                if (Aircraft.LandingGear.Value == 16383)
                {
                    gaugeValue = "down. ";
                    Output(gaugeName, gaugeValue, isGauge);
                }

            }
        }
        // read autopilot settings
        public void ReadAutopilotInstruments()
        {
            string gaugeName;
            string gaugeValue;
            bool isGauge = true;
            // heading
            if (PMDG737Detected)
            {
                if (Aircraft.pmdg737.MCP_Heading.ValueChanged)
                {
                    gaugeName = "AP heading";
                    gaugeValue = $"MCP heading {Aircraft.pmdg737.MCP_Heading.Value}";
                    Output(gaugeName, gaugeValue, isGauge);
                                    }
            }
            if (PMDG747Detected)
            {
                if (Aircraft.pmdg747.MCP_Heading.ValueChanged)
                {
                    gaugeName = "AP heading";
                    gaugeValue = Aircraft.pmdg747.MCP_Heading.Value.ToString();
                    Output(gaugeName, gaugeValue, isGauge);

                }
            }
            if (PMDG777Detected)
            {
                if (Aircraft.pmdg777.MCP_Heading.ValueChanged)
                {
                    gaugeName = "AP heading";
                    gaugeValue = Aircraft.pmdg777.MCP_Heading.Value.ToString();
                    Output(gaugeName, gaugeValue, isGauge);

                }
            }
            // read non-pmdg heading    
            if (Aircraft.ApHeading.ValueChanged)
            {
                gaugeName = "AP heading";
                gaugeValue = Autopilot.ApHeading.ToString();
                Output(gaugeName, gaugeValue, isGauge);
            }

            // speed
            if (PMDG737Detected)
            {
                if (Aircraft.pmdg737.MCP_IASMach.ValueChanged)
                {
                    if (PMDG737Aircraft.SpeedType == PMDG.AircraftSpeed.Indicated)
                    {
                                                gaugeName = "AP airspeed";
                        gaugeValue = PMDG737Aircraft.IndicatedAirSpeed.ToString();
                        Output(gaugeName, gaugeValue, isGauge);
                    } // airspeed
                    else if(PMDG737Aircraft.SpeedType == PMDG.AircraftSpeed.Mach)
                    {
                        gaugeName = "AP mach";
                        gaugeValue = PMDG737Aircraft.MachSpeed.ToString();
                        Output(gaugeName, gaugeValue, isGauge);
                    } // mach speed
                }
            } // PMDG737
            if (PMDG747Detected)
            {
                if (Aircraft.pmdg747.MCP_IASMach.ValueChanged)
                {
                    gaugeName = "AP airspeed";
                    gaugeValue = Aircraft.pmdg747.MCP_IASMach.Value.ToString();
                    Output(gaugeName, gaugeValue, isGauge);

                }
            }
            if (PMDG777Detected)
            {
                if (Aircraft.pmdg777.MCP_IASMach.ValueChanged)
                {
                    if(PMDG777Aircraft.SpeedType == PMDG.AircraftSpeed.Indicated)
                    {
                        gaugeName = "AP airspeed";
                        gaugeValue = PMDG777Aircraft.IndicatedAirSpeed.ToString();
                        Output(gaugeName, gaugeValue, isGauge);
                    }
                    else if(PMDG777Aircraft.SpeedType == PMDG.AircraftSpeed.Mach)
                    {
                        gaugeName = "AP airspeed";
                        gaugeValue = PMDG777Aircraft.MachSpeed.ToString();
                        Output(gaugeName, gaugeValue, isGauge);
                    }
                    
                                    }
                if (Aircraft.pmdg777.MCP_FPA.ValueChanged)
                {
                    gaugeName = "AP Flight path angle";
                    gaugeValue = Aircraft.pmdg777.MCP_FPA.Value.ToString();
                    Output(gaugeName, gaugeValue, isGauge);
                }
            }
            // handle speed for standard aircraft
            if (Aircraft.ApAirspeed.ValueChanged)
            {
                gaugeName = "AP airspeed";
                gaugeValue = Autopilot.ApAirspeed.ToString();
                Output(gaugeName, gaugeValue, isGauge);
            }
                        // vertical speed
            if (Aircraft.ApVerticalSpeed.ValueChanged)
            {
                gaugeName = "AP vertical speed";
                gaugeValue = Autopilot.ApVerticalSpeed.ToString();
                Output(gaugeName, gaugeValue, isGauge);
            }
        }
        private void readAutopilotAltitude()
        {
            // Altitude
            var gaugeName = "AP altitude";
            var isGauge = true;
            if (Aircraft.AircraftName.Value.Contains("PMDG"))
            {
                if (PMDG737Detected)
                {
                    if (Aircraft.pmdg737.MCP_Altitude.ValueChanged)
                    {
                        var gaugeValue = Aircraft.pmdg737.MCP_Altitude.Value.ToString();
                        Output(gaugeName, gaugeValue, isGauge);

                    }
                }
                if (PMDG747Detected)
                {
                    if (Aircraft.pmdg747.MCP_Altitude.ValueChanged)
                    {
                        var gaugeValue = Aircraft.pmdg747.MCP_Altitude.Value.ToString();
                        Output(gaugeName, gaugeValue, isGauge);

                    }
                }
                if (PMDG777Detected)
                {
                    if (Aircraft.pmdg777.MCP_Altitude.ValueChanged)
                    {
                        var gaugeValue = Aircraft.pmdg777.MCP_Altitude.Value.ToString();
                        Output(gaugeName, gaugeValue, isGauge);
                    }
                }
            }

            else
            {
                if (Aircraft.ApAltitude.ValueChanged)
                {
                    var gaugeValue = Autopilot.ApAltitude.ToString();
                    Output(gaugeName, gaugeValue, isGauge);


                }
            }

        }
        public void ReadGroundSpeed()
        {
            if (!groundSpeedActive)
            {
                // only read if aircraft is on ground
                if (Aircraft.OnGround.Value == 1)
                {
                    if (GroundSpeed > 10)
                    {
                        groundSpeedActive = true;
                        GroundSpeedTimer.AutoReset = true;
                        GroundSpeedTimer.Enabled = true;

                    }



                }

            }
        }

        private void onGroundSpeedTimerTick(object sender, ElapsedEventArgs e)
        {

            if (GroundSpeed > 10)
            {
                Output(textOutput: false, isGauge: false, useSAPI: true, output: $"{GroundSpeed} knotts. ");
            }
            if (GroundSpeed < 10 || Aircraft.OnGround.Value == 0)
            {
                groundSpeedActive = false;
                GroundSpeedTimer.Stop();
            }
        }

        public void ReadSimConnectMessages()
        {
            Aircraft.textMenu.RefreshData();
            if (Aircraft.textMenu.Changed) // Check if the text/menu is different from the last time we called RefreshData()
            {
                if (!muteSimconnect)
                {
                    if (Aircraft.textMenu.IsMenu) // Check if it's a menu (true) or a simple message (false)
                    {
                        if (Aircraft.textMenu.ToString() == "") return;
                        string menu = Aircraft.textMenu.MenuTitleText + "\r\n";
                        menu += Aircraft.textMenu.MenuPromptText + "\r\n";

                        int count = 1;
                        foreach (string item in Aircraft.textMenu.MenuItems)
                        {
                            menu += $"{count}: {item}. \r\n";
                            count++;
                        }
                        Output(isGauge: false, output: menu);
                    }
                    else
                    {
                        if (Aircraft.textMenu.Message.Contains("Initialising All Systems") && PMDGInitializing == false)
                        {
                            PMDGInitializing = true;
                            Output(isGauge: false, output: "Initializing all systems. ");


                        }
                        if (Aircraft.textMenu.Message.Contains("hold Ctrl to skip"))
                        {
                            tickSound = new WaveFileReader(@"sounds\tick.wav");
                            mixer.AddMixerInput(tickSound);

                            OldSimConnectMessage = Aircraft.textMenu.ToString();
                            return;
                        }


                        
                        if (Aircraft.textMenu.Message == "")
                        {
                            PMDGInitializing = false;
                            return;
                        }

                        if (PMDGInitializing == false)
                        {
                            Output(isGauge: false, output: Aircraft.textMenu.Message);
                        }

                    }

                }
                OldSimConnectMessage = Aircraft.textMenu.ToString();
            }
        }

        private void ReadToggle(Offset instrument, bool toggleStateOn, string name, string OnMsg = "on", string OffMsg = "off", bool SAPI = false)
        {
            if (instrument.ValueChanged)
            {
                if (toggleStateOn)
                {
                    Output(isGauge: false, useSAPI: SAPI, output: $"{name} {OnMsg}");
                }
                else
                {
                    Output(isGauge: false, useSAPI: SAPI, output: $"{name} {OffMsg}");
                }
            }
        }
        private void ReadPMDGToggle(Offset instrument, bool toggleStateOn, string name, string OnMsg = "on", string OffMsg = "off")
        {
            if (instrument.ValueChanged)
            {
                if (toggleStateOn)
                {
                    Output(isGauge: false, output: $"{name} {OnMsg}");
                    pmdg.fireOnPMDGPanelUpdateEvent("on");
                }
                else
                {
                    Output(isGauge: false, output: $"{name} {OffMsg}");
                }
            }
        }

        public static double mapOneRangeToAnother(double sourceNumber, double fromA, double fromB, double toA, double toB, int decimalPrecision)
        {
            double deltaA = fromB - fromA;
            double deltaB = toB - toA;
            double scale = deltaB / deltaA;
            double negA = -1 * fromA;
            double offset = (negA * scale) + toA;
            double finalNumber = (sourceNumber * scale) + offset;
            int calcScale = (int)Math.Pow(10, decimalPrecision);
            return (double)Math.Round(finalNumber * calcScale) / calcScale;
        }

        private void commandMode(object sender, HotkeyEventArgs e)
        {
            // Check to see if we are connected to the sim.
            if (FSUIPCConnection.IsOpen || utility.DebugEnabled || helpModeEnabled)
            {
                // remove the left bracket autopilot command
                HotkeyManager.Current.Remove("ap_Command_Key");
                // play the command sound
                cmdSound = new WaveFileReader(@"sounds\command.wav");
                mixer.AddMixerInput(cmdSound);
                if (helpModeEnabled)
                {
                    Speak(rm.GetString("Command_Key"));
                }
                // populate a list of hotkeys, so we can clear them later.
                foreach (SettingsProperty s in Properties.Hotkeys.Default.Properties)
                {
                    if (s.Name == "Command_Key") continue;
                    if (s.Name.StartsWith("ap_")) continue;
                    hotkeys.Add(s.Name);
                    try
                    {
                        HotkeyManager.Current.AddOrReplace(s.Name, (Keys)Properties.Hotkeys.Default[s.Name], onKeyPressed);
                    }
                    catch (NHotkey.HotkeyAlreadyRegisteredException ex)
                    {
                        logger.Debug($"Cannot register {s.Name}. Probably duplicated key. {ex.Message}");
                        Output(isGauge: false, output: $"hotkey error in {s.Name}");
                    }

                }




            }
            else
            {
                Tolk.Output("not connected to simulator");

            }

        }

        private void autopilotCommandMode(object sender, HotkeyEventArgs e)
        {
            // unregister the right bracket command key so it isn't pressed by accident
            HotkeyManager.Current.Remove("Command_Key");
            // Check to see if we are connected to the sim
            if (FSUIPCConnection.IsOpen || utility.DebugEnabled)
            {
                // play the command sound
                // AudioPlaybackEngine.Instance.PlaySound(cmdSound);
                apCmdSound = new WaveFileReader(@"sounds\ap_command.wav");
                mixer.AddMixerInput(apCmdSound);
                if (helpModeEnabled)
                {
                    Speak(rm.GetString("ap_Command_Key"));
                }

                // populate a list of hotkeys, so we can clear them later.
                foreach (SettingsProperty s in Properties.Hotkeys.Default.Properties)
                {
                    if (s.Name == "Autopilot_Command_Key") continue;
                    if (s.Name.StartsWith("ap_") || s.Name == "toggle_help_mode")
                    {
                        autopilotHotkeys.Add(s.Name);
                        try
                        {
                            HotkeyManager.Current.AddOrReplace(s.Name, (Keys)Properties.Hotkeys.Default[s.Name], onAutopilotKeyPressed);
                        }
                        catch (NHotkey.HotkeyAlreadyRegisteredException ex)
                        {
                            logger.Debug($"Cannot register {s.Name}. Probably duplicated key.");
                            Output(isGauge: false, output: $"hotkey error in {s.Name}");

                        }
                    }

                }


            }
            else
            {
                Tolk.Output("not connected to simulator. ");

            }

        }

        private void onAutopilotKeyPressed(object sender, HotkeyEventArgs e)
        {
            
            e.Handled = true;
            ResetHotkeys();
            
            if (helpModeEnabled == true)
            {
                if (e.Name == "toggle_help_mode")
                {
                    Output(isGauge: false, output: "Toggle Command help. Exiting help.");
                    helpModeEnabled = false;
                    return;
                }

                Speak(rm.GetString(e.Name));
                return;
            }
            ExecuteAutopilotCommand(e.Name);
            
        }

        private void ExecuteAutopilotCommand(string Name)
        {
            frmAutopilot ap;
            frmComRadios com;
            frmNavRadios nav;
            frmAltimeter alt;
            string gaugeName;
            string gaugeValue;
            bool isGauge = true;

            switch (Name)
            {
                case "toggle_help_mode":
                    // enabling command help is handled here. Since command functions are bypassed when help is on, we handle turning it off in the key pressed event.
                    if (helpModeEnabled == false)
                    {
                        Output(isGauge: false, output: "Command help enabled");
                        helpModeEnabled = true;
                    }
                    break;

                case "ap_FMCMessage":
                    ReadPmdgFMCMessage("requested");
                    break;
                case "ap_set_spoilers":
                    ap = new frmAutopilot("spoilers");
                    ap.ShowDialog();
                    break;

                case "ap_Get_Altitude":
                    gaugeName = "AP altitude";

                    if (PMDG737Detected)
                    {
                        gaugeValue = PMDG737Aircraft.GetMCPAltitudeComponents();
                    } // PMDG737
                    if (PMDG777Detected)
                    {
                        gaugeValue = PMDG777Aircraft.GetMCPAltitudeComponents();
                    }
                    else
                    {

                        gaugeValue = Autopilot.ApAltitude.ToString();
                        if (Autopilot.ApAltitudeLock) gaugeValue = " hold " + gaugeValue;
                    }

                    Output(gaugeName, gaugeValue, isGauge);
                    break;
                case "ap_Set_Altitude":
                    if (PMDG737Detected)
                    {
                        if (PMDG737Aircraft.MCPComponents["altitude"].Visible)
                        {
                            Output(isGauge: false, output: "The altitude box is already open!");
                            PMDG737Aircraft.MCPComponents["altitude"].Focus();
                        }
                        else
                        {
                            PMDG737Aircraft.ShowAltitudeBox();
                        }
                    } // PMDG 737
                    else if (PMDG747Detected)
                    {
                        if (PMDG747Aircraft.MCPComponents["altitude"].Visible)
                        {
                            Output(isGauge: false, output: "The altitude box is already open!");
                        }
                        else
                        {
                            PMDG747Aircraft.ShowAltitudeBox();
                        }
                    }
                                        else if (PMDG777Detected)
                    {
                        if (PMDG777Aircraft.McpComponents["altitude"].Visible)
                        {
                            Output(isGauge: false, output: "The altitude box is already open!");
                        }
                        else
                        {
                            PMDG777Aircraft.ShowAltitudeBox();
                        }
                    } // End PMDG777.
                    else
                    {
                        ap = new frmAutopilot("Altitude");
                        ap.ShowDialog();
                        break;
                    }
                    break;
                case "ap_NavigationBox":

                    if (PMDG737Detected)
                    {
                        if (PMDG737Aircraft.MCPComponents["navigation"].Visible == true)
                        {
                            Output(isGauge: false, output: "The navigation box is already open!");
                        }
                        else
                        {
                            PMDG737Aircraft.ShowNavigationBox();
                        }
                    }
                    else if (PMDG747Detected)
                    {
                        if (PMDG747Aircraft.MCPComponents["navigation"].Visible)
                        {
                            Output(isGauge: false, output: "The MCP flight controls window is already open!");
                        }
                        else
                        {
                            PMDG747Aircraft.ShowNavigationBox();
                        }
                    }
else                    if (PMDG777Detected)
                    {
                        if (PMDG777Aircraft.McpComponents["navigation"].Visible)
                        {
                            Output(isGauge: false, output: "The navigation box is already open!");
                        } // navigation box already open.
                        else
                        {
                            PMDG777Aircraft.ShowNavigationBox();
                        } // navigation box is displayed.
                    } // PMDG 777
                    break;
                case "ap_Get_Altimeter":
                    ReadAltimeter(true);
                    break;
                case "ap_Set_Altimeter":
                    alt = new frmAltimeter();
                    alt.ShowDialog();
                    break;

                case "ap_Get_Heading":
                    gaugeName = "AP heading";
                    if (PMDG737Detected)
                    {
                        gaugeValue = PMDG737Aircraft.GetMCPHeadingComponents();
                    } // PMDG 737
                    if (PMDG777Detected)
                    {
                        gaugeValue = PMDG777Aircraft.GetMCPHeadingComponents();
                    }
                    else
                    {
                        gaugeValue = Autopilot.ApHeading.ToString();
                        if (Autopilot.ApHeadingLock) gaugeValue = " hold " + gaugeValue;
                    } // Freeware
                    Output(gaugeName, gaugeValue, isGauge);
                    break;
                case "ap_Set_Heading":
                    if (PMDG737Detected)
                    {
                        if (PMDG737Aircraft.MCPComponents["heading"].Visible)
                        {
                            Output(isGauge: false, output: "The heading box is already open!");
                        }
                        else
                        {
                            PMDG737Aircraft.ShowHeadingBox();
                        }
                    }
else                    if (PMDG747Detected)
                    {
                        if (PMDG747Aircraft.MCPComponents["heading"].Visible)
                        {
                            Output(isGauge: false, output: "The heading box is already open!");
                        }
                        else
                        {
                            PMDG747Aircraft.ShowHeadingBox();
                        }
                    }
                    else if (PMDG777Detected)
                    {
                        if (PMDG777Aircraft.McpComponents["heading"].Visible)
                        {
                            Output(isGauge: false, output: "The heading box is already open!");
                        }
                        else
                        {
                            PMDG777Aircraft.McpComponents["heading"].Show();
                        }
                    } // End PMDG777 check.
                    else
                    {
                        ap = new frmAutopilot("Heading");
                        ap.ShowDialog();
                    } // End freeware.
                    break;

                case "ap_Get_Airspeed":
                    gaugeName = "AP airspeed";
                    gaugeValue = string.Empty;
                    if (PMDG737Detected)
                    {
                        if (PMDG737Aircraft.SpeedType == PMDG.AircraftSpeed.Indicated)
                        {
                            gaugeValue = PMDG737Aircraft.GetMCPSpeedComponents();
                        }
                    } // PMDG737
                    if (PMDG777Detected)
                    {
                        gaugeValue = PMDG777Aircraft.GetMCPSpeedComponents();
                    }

                    // freeware.
                    else
                    {
                        gaugeValue = Autopilot.ApAirspeed.ToString();
                        if (Autopilot.ApAirspeedHold) gaugeValue = " hold " + gaugeValue;
                    } // freeware

                    Output(gaugeName, gaugeValue, isGauge);
                    break;

                case "ap_Set_Airspeed":
                    if (PMDG737Detected)
                    {
                        if (PMDG737Aircraft.MCPComponents["speed"].Visible)
                        {
                            Output(isGauge: false, output: "The speed box is already open!");
                        }
                        else
                        {
                            PMDG737Aircraft.ShowSpeedBox();
                        }
                    }
                    else if (PMDG747Detected)
                    {
                        if (PMDG747Aircraft.MCPComponents["speed"].Visible)
                        {
                            Output(isGauge: false, output: "The speed box is already open!");
                        }
                        else
                        {
                            PMDG747Aircraft.ShowSpeedBox();
                        }
                    } // PMDG747
                    else if (PMDG777Detected)
                    {

                        if (PMDG777Aircraft.McpComponents["speed"].Visible)
                        {
                            Output(isGauge: false, output: "Speed box already open!");
                            history.AddItem("Speed box already open!");
                        }
                        else
                        {
                            PMDG777Aircraft.ShowSpeedBox();
                        }
                    } // End PMDG 777.
                    else
                    {
                        ap = new frmAutopilot("Airspeed");
                        ap.ShowDialog();
                    } // End freeware planes.
                    break;

                case "ap_Get_Mach_Speed":
                    gaugeName = "AP mach";
                    gaugeValue = string.Empty;
                    if (PMDG737Detected)
                    {
                        if (PMDG737Aircraft.SpeedType == PMDG.AircraftSpeed.Mach)
                        {
                            gaugeValue = PMDG737Aircraft.GetMCPSpeedComponents();
                        } // MachSpeed
                    } // PMDG737

                    // freeware
                    else
                    {
                        gaugeValue = Autopilot.ApMachSpeed.ToString();
                        if (Autopilot.ApMachHold) gaugeValue = " hold " + gaugeValue;
                    } // freeware
                    Output(gaugeName, gaugeValue, isGauge);
                    break;

                case "ap_Set_Mach_Speed":

                    if (PMDG737Detected)
                    {
                        if (PMDG737Aircraft.MCPComponents["speed"].Visible == false)
                        {
                            PMDG737Aircraft.ShowSpeedBox();
                        }
                        else
                        {
                            Output(isGauge: false, output: "The speed box is already open!");
                        }
                    } // PMDG737
                    else
                    {
                        ap = new frmAutopilot("Mach");
                        ap.ShowDialog();
                    }
                    break;

                case "ap_Get_Vertical_Speed":
                    gaugeName = "AP vertical speed";
                    gaugeValue = Autopilot.ApVerticalSpeed.ToString();
                    if (Autopilot.ApVerticalSpeedHold) gaugeValue = " hold " + gaugeValue;
                    Output(gaugeName, gaugeValue, isGauge);
                    break;

                case "ap_Set_Vertical_Speed":
                    if (PMDG737Detected)
                    {
                        if (PMDG737Aircraft.MCPComponents["vertical"].Visible)
                        {
                            Output(isGauge: false, output: "The vertical speed box is already open!");
                        }
                        else
                        {
                            PMDG737Aircraft.ShowVerticalSpeedBox();
                        }
                    }
                    else if (PMDG747Detected)
                    {
                        if (PMDG747Aircraft.MCPComponents["vertical"].Visible)
                        {
                            Output(isGauge: false, output: "The vertical speed box is already open!");
                        }
                        else
                        {
                            PMDG747Aircraft.ShowVerticalSpeedBox();
                        }
                    }
                    else if (PMDG777Detected)
                    {
                        if (PMDG777Aircraft.McpComponents["vertical"].Visible)
                        {
                            Output(isGauge: false, output: "The vertical speed box is already open!");
                        }
                        else
                        {
                            PMDG777Aircraft.McpComponents["vertical"].Show();
                        }
                    } // End PMDG777 check.
                    else
                    {
                        ap = new frmAutopilot("Vertical speed");
                        ap.ShowDialog();
                    } // End freeware check.

                    break;
                case "ap_Get_Com_Radios":
                    Output(isGauge: false, output: $"com 1: {Autopilot.Com1Freq.ToString()}. ");
                    Output(isGauge: false, output: $"com 2: {Autopilot.Com2Freq.ToString()}. ");
                    break;


                case "ap_Set_Com_Radios":
                    com = new frmComRadios();
                    com.ShowDialog();
                    break;

                case "ap_Get_Nav_Radios":
                    string navInfo = null;
                    Output(isGauge: false, output: $"nav 1: {Autopilot.Nav1Freq.ToString()}. Course: {Autopilot.Nav1Course.ToString()}. ");

                    if (Aircraft.AutopilotRadioStatus.Value[6])
                    {
                        // nav 1 has ILS
                        navInfo += "ILS. \n";
                        double gsInclination = (double)Aircraft.Nav1GSInclination.Value * 360d / 65536d - 360d;
                        navInfo += "Glide slope angle: " + gsInclination.ToString("F1") + "degrees. \n";
                        navInfo += $"{Aircraft.Vor1Name.Value}. \n";
                        double magvar = (double)Aircraft.MagneticVariation.Value * 360d / 65536d;
                        double rwyHeading = (double)Aircraft.Nav1LocaliserInverseRunwayHeading.Value * 360d / 65536d + 180d - magvar;
                        navInfo += "localiser heading: " + rwyHeading.ToString("F0");
                    }
                    else
                    {
                        if (Aircraft.Vor1ID.Value != "")
                        {
                            navInfo += $"VOR ID: {Aircraft.Vor1ID.Value}. ";
                        }

                    }
                    Output(isGauge: false, output: navInfo);
                    break;
                case "ap_Set_Nav_Radios":
                    nav = new frmNavRadios();
                    nav.ShowDialog();
                    break;


                case "ap_Get_Transponder":
                    gaugeName = "Transponder";
                    gaugeValue = Autopilot.Transponder.ToString();
                    Output(gaugeName, gaugeValue, isGauge);
                    break;
                case "ap_Set_Transponder":

                    if (PMDG737Detected)
                    {
                        var transponderForm = new tfm.PMDG.PMDG_737.Forms.TransponderForm();
                        transponderForm.ShowDialog();
                    }
                    else
                    {
                        ap = new frmAutopilot("Transponder");
                        ap.ShowDialog();

                    }
                    break;

                case "ap_Set_Throttle":
                    ap = new frmAutopilot("Throttle");
                    ap.ShowDialog();
                    break;

                case "ap_PMDG_CDU":
                    if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("737"))
                    {
                        var is737CDUOpen = false;
                        foreach (Form form in Application.OpenForms)
                        {
                            if (form is _737CDU)
                            {
                                is737CDUOpen = true;
                                break;
                            } // End the form is valid.
                        } // End foreach

                        if (is737CDUOpen)
                        {
                            Output(isGauge: false, output: "The FMC window is already open!");
                            break;
                        } // End what to do when CDU is already open.
                        else
                        {
                            _737CDU _737 = new _737CDU();
                            _737.Show();
                            is737CDUOpen = true;
                            break;
                        } // End what to do if FMC isn't open.
                        is737CDUOpen = false;
                        break;
                    } // End checking for PMDG 737
                    else if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("747"))
                    {
                        var is747CDUOpen = false;
                        foreach (Form form in Application.OpenForms)
                        {
                            if (form is _747CDU)
                            {
                                is747CDUOpen = true;
                                break;
                            } // End the form is valid.
                        } // End foreach

                        if (is747CDUOpen)
                        {
                            Output(isGauge: false, output: "The FMC window is already open!");
                            break;
                        } // End what to do when CDU is already open.
                        else
                        {
                            _747CDU _747CDU = new _747CDU();
                            _747CDU.Show();
                            is747CDUOpen = true;
                            break;
                        } // End what to do if FMC isn't open.
                        is747CDUOpen = false;
                        break;
                    } // End PMDG 747.
                    else if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("777"))
                    {
                        var is777CDUOpen = false;
                        foreach (Form form in Application.OpenForms)
                        {
                            if (form is _777CDU)
                            {
                                is777CDUOpen = true;
                                break;
                            } // End the form is valid.
                        } // End foreach

                        if (is777CDUOpen)
                        {
                            Output(isGauge: false, output: "The FMC window is already open!");
                            break;
                        } // End what to do when CDU is already open.
                        else
                        {
                            _777CDU _777CDU = new _777CDU();
                            _777CDU.Show();
                            is777CDUOpen = true;
                            break;
                        } // End what to do if FMC isn't open.
                        is777CDUOpen = false;
                        break;
                    } // End PMDG 777.
                    break;

                case "ap_PMDG_Panels":

                    if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("737"))
                    {
                        frmCockpitPanels pnl = new frmCockpitPanels();
                        pnl.Show();
                    }
                    else if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("747"))
                    {
                        CockPitPanels_747 cp = new CockPitPanels_747();
                        cp.Show();
                    }
                    else if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("777"))
                    {
                        CockpitPanels_777 cp = new CockpitPanels_777();
                        cp.Show();
                    }
                    break;

                default:
                    Tolk.Output("key not defined");
                    break;

            }
        }

        public void ExecuteCommand(string Name)
        {
            switch (Name)
            {
                case "SetTrim":
                    if (PMDG737Detected)
                    {
                        tfm.PMDG.PMDG_737.Forms.TrimForm trimForm = new PMDG.PMDG_737.Forms.TrimForm();
                        trimForm.ShowDialog();

                    }
                    else
                    {
                        throw new NotImplementedException("Setting trim is only available for the PMDG 737 at this time.");
                    }
                    break;
                case "JumpToRunway":

                    JumpTo.RunwaysForm runwaysForm = new JumpTo.RunwaysForm();
                    runwaysForm.ShowDialog();
                    break;
                case "JumpToGate":

                    tfm.JumpTo.GatesForm gatesForm = new JumpTo.GatesForm();
                    gatesForm.ShowDialog();
                    break;
                case "toggle_help_mode":
                    // enabling command help is handled here. Since command functions are bypassed when help is on, we handle turning it off in the key pressed event.
                    if (helpModeEnabled == false)
                    {
                        Output(isGauge: false, output: "Command help enabled");
                        helpModeEnabled = true;
                    }
                    break;

                case "keyboard_manager":
                    DisplayKeyboardManager();
                    break;


                case "ApplicationRestart":
                    Application.Restart();
                    break;
                case "destination_runway":
                    DestinationForm df = new DestinationForm();
                    df.Show();
                    break;
                case "get_speedbreak":

                    if (PMDG737Detected)
                    {
                        var speedBrakeValue = string.Empty;
                        switch (PMDG737Aircraft.CurrentSpeedBrakePosition)
                        {
                            case 100:
                                speedBrakeValue = "Armed";
                                break;
                            case 272:
                                speedBrakeValue = "Flt";
                                break;
                            case 400:
                                speedBrakeValue = "Up";
                                break;
                            case 250:
                                speedBrakeValue = "50%";
                                break;
                            case 0:
                                speedBrakeValue = "Off";
                                break;
                            default:
                                speedBrakeValue = PMDG737Aircraft.CurrentSpeedBrakePosition.ToString();
                                break;
                        }

                        Output(isGauge: false, output: speedBrakeValue);
                    }

                    if (PMDG747Detected)
                    {
                        var speedBrakeValue = string.Empty;
                        switch (PMDG747Aircraft.CurrentSpeedBrakePosition)
                        {
                            case 0:
                                speedBrakeValue = "down";
                                break;
                            case 25:
                                speedBrakeValue = "armed";
                                break;
                            case 62:
                                speedBrakeValue = "flt";
                                break;
                            case 100:
                                speedBrakeValue = "up";
                                break;
                            default:
                                speedBrakeValue = PMDG747Aircraft.CurrentSpeedBrakePosition.ToString();
                                break;
                        }

                        Output(isGauge: false, output: speedBrakeValue);

                    }

                    if (PMDG777Detected)
                    {
                        foreach (tfm.PMDG.PanelObjects.SingleStateToggle toggle in PMDG777Aircraft.PanelControls)
                        {
                            if (toggle.Name == "Speedbrake")
                            {
                                Output(isGauge: false, output: toggle.ToString());
                                break;
                            }
                        }
                    } // PMDG 777
                    break;
                case "report_issue":
                    ReportIssue();
                    break;
                case "display_website":
                    DisplayWebsite();
                    break;
                case "aircraft_profiles":
                    DisplayAircraftProfiles();
                    break;
                case "A2A_manager":
                    DisplayA2AManager();
                    break;
                case "application_settings":

                    DisplayApplicationSettings();
                    break;

                case "LocalTime":
                    ReadSimulatorTime();
                    break;
                case "distanceToDescent":
                    onTODKey();
                    break;
                case "n1monitor":
                    frmAutopilot frmAutopilot = new frmAutopilot("n1Monitor");
                    frmAutopilot.ShowDialog();
                    break;
                case "application_quit":
                    Tolk.Output("TFM is shutting down...");
                    Application.Exit();
                    break;

                case "get_spoilers":
                    onSpoilersKey();
                    break;

                case "flight_planner":
                    /*var isPlannerActive = false;
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form is FlightPlanForm)
                        {
                            isPlannerActive = true;
                            break;
                        }
                    }
                    if (isPlannerActive)
                    {
                        Output(isGauge: false, output: "Flight planner is already open!");
                        break;
                    }
                    else
                    {
                        FlightPlanForm fp = new FlightPlanForm();
                        fp.ShowDialog();
                        isPlannerActive = true;
                        break;
                    }
                    isPlannerActive = false;
                    break;*/
                    Output(isGauge: false, output: "Feature not yet implemented.");
                    break;
                case "takeoff_assist":
                    onTakeOffAssistant();
                    break;
                case "ASL_Altitude":
                    OnASLKey();
                    break;
                case "Fuel_Manager":
                    if (fuelManagerActive)
                    {
                        Output(isGauge: false, output: "fuel manager already open");
                        break;
                    }
                    if (Aircraft.AircraftName.Value.Contains("PMDG"))
                    {
                        MessageBox.Show("Fuel manager is not available on PMDG aircraft. Please use the FMC to load fuel.", "error");
                        break;

                    }
                    else
                    {
                        frmFuelManager frm = new frmFuelManager();
                        fuelManagerActive = true;
                        frm.ShowDialog();
                        fuelManagerActive = false;
                        break;
                    }


                case "Current_Location":
                    OnCurrentLocation();
                    break;
                case "AGL_Altitude":
                    OnAGLKey();
                    break;
                case "Disable_Command_Key":
                    Output(isGauge: false, output: "command key disabled.");
                    CommandKeyEnabled = false;
                    break;

                case "Aircraft_Heading":
                    OnHeadingKey();
                    break;
                case "Indicated_Airspeed":
                    OnIASKey();
                    break;
                case "Read_Simulation_Rate":
                    ReadSimulationRate(true);
                    break;
                case "Ground_Speed":
                    onGroundSpeedKey();
                    break;

                case "True_Airspeed":
                    OnTASKey();
                    break;
                case "Mach_Speed":
                    OnMachKey();
                    break;
                case "Vertical_Speed":
                    OnVSpeedKey();
                    break;
                case "Landing_Rate":
                    OnLandingRateKey();
                    break;

                case "Outside_Temperature":
                    onAirtempKey();
                    break;
                case "Toggle_Trim_Announcement":
                                                                                            onTrimKey();
                                                                    break;
                case "Mute_Simconnect_Messages":
                    OnMuteSimconnectKey();
                    break;
                case "Repeat_Last_Simconnect_Message":
                    onRepeatLastSimconnectMessage();
                    break;
                case "Output_History":
                    frmOutputHistory frmHistory = new frmOutputHistory();
                    frmHistory.ShowDialog();
                    break;

                case "Nearest_City":
                    OnCityKey();
                    break;
                case "Next_Waypoint":
                    OnWaypointKey();
                    break;
                case "Destination_Info":
                    OnDestinationKey();
                    break;
                case "Attitude_Mode":
                    onAttitudeKey();
                    break;
                case "Toggle_Autopilot_Announcement":
                    onAutopilotKey();
                    break;
                case "Toggle_GPWS_Announcement":
                    onGPWSKey();
                    break;
                case "Toggle_ILS_Announcement":
                    onToggleILSKey();
                    break;
                case "Toggle_Flaps_Announcement":
                    onToggleFlapsAnnouncementKey();
                    break;
                case "Read_Flaps_Angle":
                    onFlapsAngleKey();
                    break;
                case "Read_Landing_Gear":
                    onGearState();
                    break;

                case "Wind_Information":
                    onWindKey();
                    break;
                case "Runway_Guidance_Mode":
                    onRunwayGuidanceKey();
                    break;
                case "Fuel_Report":
                    onFuelReportKey();
                    break;
                case "Fuel_Flow":
                    onFuelFlowKey();
                    break;
                case "Weight_Report":
                    onWeightReportKey();
                    break;

                case "Fuel_Tank_1":
                    onFuelTankKey(1);
                    break;
                case "Fuel_Tank_2":
                    onFuelTankKey(2);
                    break;
                case "Fuel_Tank_3":
                    onFuelTankKey(3);
                    break;
                case "Fuel_Tank_4":
                    onFuelTankKey(4);
                    break;
                case "Fuel_Tank_5":
                    onFuelTankKey(5);
                    break;
                case "Fuel_Tank_6":
                    onFuelTankKey(6);
                    break;
                case "Fuel_Tank_7":
                    onFuelTankKey(7);
                    break;
                case "Fuel_Tank_8":
                    onFuelTankKey(8);
                    break;
                case "Fuel_Tank_9":
                    onFuelTankKey(9);
                    break;
                case "Fuel_Tank_10":
                    onFuelTankKey(10);
                    break;
                case "Nearby_Airborn_Aircraft":

                    if (Properties.Settings.Default.VatsimMode)
                    {
                        tfm.Vatsim.VatsimRadar vatsimRadar = new Vatsim.VatsimRadar();
                        vatsimRadar.Show();
                    }
                    else
                    {
                        onNearbyAircraft();
                    }
                    break;
                case "Nearby_Ground_Aircraft":
                    onTCASGround();
                    break;
                case "Engine_1_Throttle":
                    onEngineThrottleKey(1);
                    break;

                case "Engine_2_Throttle":
                    onEngineThrottleKey(2);
                    break;

                case "Engine_3_Throttle":
                    onEngineThrottleKey(3);
                    break;

                case "Engine_4_Throttle":
                    onEngineThrottleKey(4);
                    break;

                case "Engine_1_Info":
                    OnEngineInfoKey(1);
                    break;
                case "Engine_2_Info":
                    OnEngineInfoKey(2);
                    break;
                case "Engine_3_Info":
                    OnEngineInfoKey(3);
                    break;
                case "Engine_4_Info":
                    OnEngineInfoKey(4);
                    break;
                case "Toggle_Braille_Output":
                    onBrailleOutputKey();
                    break;

            }
        }
        private void onKeyPressed(object sender, HotkeyEventArgs e)
        {

            e.Handled = true;
            ResetHotkeys();
            if (helpModeEnabled == true)
            {
                if (e.Name == "toggle_help_mode")
                {
                    Output(isGauge: false, output: "Toggle Command help. Exiting help.");
                    helpModeEnabled = false;
                    return;
                }
                Output(isGauge:false, output:rm.GetString(e.Name));
                return;
            }

            ExecuteCommand(e.Name);

        }


        private void onGearState()
        {
            var gaugeName = "Gear";
            var isGauge = true;
            string gaugeValue;
            if (Aircraft.LandingGear.Value == 0)
            {
                gaugeValue = "up. ";
                Output(gaugeName, gaugeValue, isGauge);
            }
            if (Aircraft.LandingGear.Value == 16383)
            {
                gaugeValue = "down. ";
                Output(gaugeName, gaugeValue, isGauge);
            }
            if (Aircraft.LandingGear.Value > 0 && Aircraft.LandingGear.Value < 16383)
            {
                gaugeValue = "in motion. ";
                Output(gaugeName, gaugeValue, isGauge);
            }

        }

        private void onFlapsAngleKey()
        {
            var gaugeName = "Flaps";
            if (PMDG737Detected)
            {

                if (FlapsMoving)
                {
                    Output(isGauge: false, output: "Flaps in motion.");
                }
                else
                {
                    var gaugeValue = PMDG737Aircraft.CurrentFlapsPosition.ToString();
                    var isGauge = true;
                    Output(gaugeName, gaugeValue, isGauge);
                }
            } // PMDG 737.
            else if (PMDG747Detected)
            {
                if (FlapsMoving)
                {
                    Output(isGauge: false, output: "Flaps in motion.");
                }
                else
                {
                    var gaugeValue = PMDG747Aircraft.CurrentFlapsPosition.ToString();
                    var isGauge = true;
                    Output(gaugeName, gaugeValue, isGauge);
                }
            } // PMDG 747
             else if (PMDG777Detected)
            {
                if (FlapsMoving)
                {
                    Output(isGauge: false, output: "Flaps in motion.");
                }
                else
                {
                    var gaugeValue = PMDG777Aircraft.CurrentFlapsPosition.ToString();
                    var isGauge = true;
                    Output(gaugeName, gaugeValue, isGauge);
                }
            } // PMDG 777.
            else
            {

                double FlapsAngle = (double)Aircraft.Flaps.Value / 256d;
                var gaugeValue = FlapsAngle.ToString("f0");
                var isGauge = true;
                Output(gaugeName, gaugeValue, isGauge);
            }
        }

                       private void onBrailleOutputKey()
        {
            if (Properties.Settings.Default.OutputBraille)
            {
                Properties.Settings.Default.OutputBraille = false;
                Output(isGauge: false, output: "Braille output disabled. ");
            }
            else
            {
                Properties.Settings.Default.OutputBraille = true;
                Output(isGauge: false, output: "Braille output enabled. ");
            }
        }

        private void onEngineThrottleKey(int engine)
        {
            string throttleValue = null;
            string thrustValue = null;
            if (engine > Aircraft.num_engines.Value)
            {
                Output(isGauge: false, output: $"Only {Aircraft.num_engines.Value} available. ");
                return;
            }
            if (engine == 1)
            {
                double throttlePercent = (double)Aircraft.Engine1ThrottleLever.Value / 16384d * 100d;
                double thrust = Aircraft.Engine1JetThrust.Value;
                throttleValue = throttlePercent.ToString("F1");
                thrustValue = Aircraft.Engine1JetThrust.Value.ToString("F0");
                Output(isGauge: false, output: $"Engine 1: {throttleValue} percent, {thrustValue} pounds thrust.");
            }
            if (engine == 2)
            {
                double throttlePercent = (double)Aircraft.Engine2ThrottleLever.Value / 16384d * 100d;
                throttleValue = throttlePercent.ToString("F1");
                thrustValue = Aircraft.Engine2JetThrust.Value.ToString("F0");
                Output(isGauge: false, output: $"Engine 2: {throttleValue} percent, {thrustValue} pounds thrust.");
            }
            if (engine == 3)
            {
                double throttlePercent = (double)Aircraft.Engine3ThrottleLever.Value / 16384d * 100d;
                throttleValue = throttlePercent.ToString("F1");
                thrustValue = Aircraft.Engine3JetThrust.Value.ToString("F0");
                Output(isGauge: false, output: $"Engine 3: {throttleValue} percent, {thrustValue} pounds thrust.");
            }
            if (engine == 4)
            {
                double throttlePercent = (double)Aircraft.Engine4ThrottleLever.Value / 16384d * 100d;
                throttleValue = throttlePercent.ToString("F1");
                thrustValue = Aircraft.Engine4JetThrust.Value.ToString("F0");
                Output(isGauge: false, output: $"Engine 4: {throttleValue} percent, {thrustValue} pounds thrust.");

            }



        }

        private void onGroundSpeedKey()
        {
            var gaugeName = "Ground speed";
            var gaugeValue = GroundSpeed.ToString();
            var isGauge = true;
            Output(gaugeName, gaugeValue, isGauge);
        }

        private void onRepeatLastSimconnectMessage()
        {
            if (OldSimConnectMessage != null)
            {
                Output(isGauge: false, output: OldSimConnectMessage);
            }
            else
            {
                Output(isGauge: false, output: "no recent message");
            }

        }

        private void onWindKey()
        {
            double WindSpeed = (double)Aircraft.WindSpeed.Value;
            double WindDirection = (double)Aircraft.WindDirection.Value * 360d / 65536d;
            WindDirection = Math.Round(WindDirection);
            double WindGust = (double)Aircraft.WindGust.Value;
            Output(isGauge: false, output: $"Wind: {WindDirection} at {WindSpeed} knotts. Gusts at {WindGust} knotts.");

        }


        private void onNearbyAircraft()
        {
            // Get a reference to the AITrafficServices (for easier use)
            AITrafficServices ts = FSUIPCConnection.AITrafficServices;
            ts.UpdateExtendedPlaneIndentifiers(
                    TailNumber: false,
                    AirlineAndFlightNumber: true,
                    AircraftTypeAndModel: true,
                    AircraftTitle: false);

            // Get the latest data from FSUIPC
            Tolk.Output("please wait... ");
            ts.RefreshAITrafficInformation();

            // Get the list of all AI Traffic
            List<AIPlaneInfo> groundtraffic = ts.GroundTraffic;
            List<AIPlaneInfo> airbornTraffic = ts.AirborneTraffic;
            if (groundtraffic.Count == 0 && airbornTraffic.Count == 0)
            {
                Output(isGauge: false, output: "no traffic available. ");
            }
            else
            {
                frmNearbyAircraft frm = new frmNearbyAircraft(groundtraffic, airbornTraffic);
                frm.ShowDialog();

            }
        }

        private void onTCASGround()
        {
            Tolk.Output("not yet implemented.");
        }

        private void onFuelTankKey(int tank)
        {
            FSUIPCConnection.PayloadServices.RefreshData();
            if (tank > ActiveTanks.Count)
            {
                Output(isGauge: false, output: "tank not available");
            }
            else
            {
                tank = tank - 1;
                string name = ActiveTanks[tank].Tank.ToString();
                string pct = ActiveTanks[tank].LevelPercentage.ToString("F0");
                string weight = null;
                if (Properties.Settings.Default.UseMetric)
                {
                    weight = ActiveTanks[tank].WeightKgs.ToString("F0");
                }
                else
                {
                    weight = ActiveTanks[tank].WeightLbs.ToString("F0");
                }

                string gal = ActiveTanks[tank].LevelUSGallons.ToString("F0");
                if (Properties.Settings.Default.UseMetric)
                {
                    Output(isGauge: false, output: $"{name}.  {pct} percent, {weight} kilograms, {gal} gallons.");
                }
                else
                {
                    Output(isGauge: false, output: $"{name}.  {pct} percent, {weight} pounds, {gal} gallons.");
                }

            }
        }

        private void onFuelFlowKey()
        {
            int NumEngines = Aircraft.num_engines.Value;
            double eng1 = Math.Round(Aircraft.eng1_fuel_flow.Value);
            double eng2 = Math.Round(Aircraft.eng2_fuel_flow.Value);
            double eng3 = Math.Round(Aircraft.eng3_fuel_flow.Value);
            double eng4 = Math.Round(Aircraft.eng4_fuel_flow.Value);
            Output(isGauge: false, output: "Fuel flow (pounds per hour): ");
            Output(isGauge: false, output: $"Engine 1: {eng1}. ");
            if (NumEngines >= 2)
            {
                Output(isGauge: false, output: $"Engine 2: {eng2}. ");
            }
            if (NumEngines >= 3)
            {
                Output(isGauge: false, output: $"Engine 3: {eng3}. ");
            }
            if (NumEngines >= 4)
            {
                Output(isGauge: false, output: $"Engine 4: {eng4}. ");
            }

        }

        private void onFuelReportKey()
        {
            // Make a variable to make accessing the payload services object quicker
            // NOTE: The connection must already be open in order to access payload services
            PayloadServices ps = FSUIPCConnection.PayloadServices;
            // Refresh the current payload data
            ps.RefreshData();
            string TotalFuelWeight = ps.FuelWeightLbs.ToString("F1");
            string TotalFuelQuantity = ps.FuelLevelUSGallons.ToString("F1");
            Output(isGauge: false, output: $"total fuel: {TotalFuelWeight} pounds. ");
            Output(isGauge: false, output: $"{TotalFuelQuantity} gallons. ");
            double TotalFuelFlow = (double)Aircraft.eng1_fuel_flow.Value + Aircraft.eng2_fuel_flow.Value + Aircraft.eng3_fuel_flow.Value + Aircraft.eng4_fuel_flow.Value;
            TotalFuelFlow = Math.Round(TotalFuelFlow);
            Output(isGauge: false, output: $"Total fuel flow: {TotalFuelFlow}");
        }
        private void onWeightReportKey()
        {
            // Make a variable to make accessing the payload services object quicker
            // NOTE: The connection must already be open in order to access payload services
            PayloadServices ps = FSUIPCConnection.PayloadServices;
            // Refresh the current payload data
            ps.RefreshData();
            if (Properties.Settings.Default.UseMetric)
            {
                string GrossWeight = ps.GrossWeightKgs.ToString("F0");
                string EmptyWeight = ps.EmptyWeightKgs.ToString("F0");
                string FuelWeight = ps.FuelWeightKgs.ToString("F0");
                string PayloadWeight = ps.PayloadWeightKgs.ToString("F0");
                string MaxGrossWeight = ps.MaxGrossWeightKgs.ToString("F0");
                if (ps.GrossWeightKgs > ps.MaxGrossWeightKgs)
                {
                    Output(isGauge: false, output: "Overweight warning! ");
                }
                Output(isGauge: false, output: $"Fuel Weight: {FuelWeight} Kilograms");
                Output(isGauge: false, output: $"Payload Weight: {PayloadWeight} kilograms. ");
                Output(isGauge: false, output: $"Gross Weight: {GrossWeight} of {MaxGrossWeight} kilograms maximum.");

            }
            else
            {
                string GrossWeight = ps.GrossWeightLbs.ToString("F0");
                string EmptyWeight = ps.EmptyWeightLbs.ToString("F0");
                string FuelWeight = ps.FuelWeightLbs.ToString("F0");
                string PayloadWeight = ps.PayloadWeightLbs.ToString("F0");
                string MaxGrossWeight = ps.MaxGrossWeightLbs.ToString("F0");
                if (ps.GrossWeightLbs > ps.MaxGrossWeightLbs)
                {
                    Output(isGauge: false, output: "Overweight warning! ");
                }
                Output(isGauge: false, output: $"Fuel Weight: {FuelWeight} pounds");
                Output(isGauge: false, output: $"Payload Weight: {PayloadWeight} pounds. ");
                Output(isGauge: false, output: $"Gross Weight: {GrossWeight} of {MaxGrossWeight} pounds maximum.");

            }
        }
        private void onRunwayGuidanceKey()
        {
            if (!runwayGuidanceEnabled)
            {
                runwayGuidanceEnabled = true;
                // set up the timer
                RunwayGuidanceTimer = new System.Timers.Timer(200); // 200 milliseconds
                // Hook up the Elapsed event for the timer. 
                RunwayGuidanceTimer.Elapsed += OnRunwayGuidanceTickEvent;
                RunwayGuidanceTimer.AutoReset = true;
                RunwayGuidanceTrackedHeading = (double)Math.Round(Aircraft.CompassHeading.Value);
                Output(isGauge: false, output: $"Runway guidance enabled. current heading: {RunwayGuidanceTrackedHeading}. ");
                // play tones for 45 degrees on either side of the tracked heading
                HdgRight = RunwayGuidanceTrackedHeading + 45;
                HdgLeft = RunwayGuidanceTrackedHeading - 45;
                if (HdgRight > 360)
                {
                    HdgRight = HdgRight - 360;
                }
                if (HdgLeft < 0)
                {
                    HdgLeft = HdgLeft + 360;
                }
                // start audio
                wg = new SignalGenerator
                {
                    Type = SignalGeneratorType.Square,
                    Gain = 0.1
                };
                // set up panning provider, with the signal generator as input
                pan = new PanningSampleProvider(wg.ToMono());
                // we use an OffsetSampleProvider to allow playing beep tones
                RunwayGuidanceTimer.Enabled = true;
            }
            else
            {
                mixer.RemoveAllMixerInputs();
                RunwayGuidanceTimer.Stop();
                runwayGuidanceEnabled = false;
                Output(isGauge: false, output: "Runway Guidance disabled. ");
            }

        }
        private void OnRunwayGuidanceTickEvent(Object source, ElapsedEventArgs e)
        {
            pulse = new OffsetSampleProvider(pan)
            {
                Take = TimeSpan.FromMilliseconds(50),
            };
            mixer.RemoveAllMixerInputs();
            double hdg = (double)Math.Round(Aircraft.CompassHeading.Value);
            if (hdg > RunwayGuidanceTrackedHeading && hdg < HdgRight)
            {
                double freq = mapOneRangeToAnother(hdg, RunwayGuidanceTrackedHeading, HdgRight, 400, 800, 0);
                wg.Frequency = freq;
                pan.Pan = 1;
                mixer.AddMixerInput(pulse);
            }
            if (hdg < RunwayGuidanceTrackedHeading && hdg > HdgLeft)
            {
                double freq = mapOneRangeToAnother(hdg, HdgLeft, RunwayGuidanceTrackedHeading, 800, 400, 0);
                wg.Frequency = freq;
                pan.Pan = -1;
                mixer.AddMixerInput(pulse);
            }
            if (hdg == RunwayGuidanceTrackedHeading)
            {
                mixer.RemoveAllMixerInputs();
            }
        }



        private void onToggleFlapsAnnouncementKey()
        {
            if (Properties.Settings.Default.ReadFlaps)
            {
                Properties.Settings.Default.ReadFlaps = false;
                Output(isGauge: false, output: "flaps announcement disabled. ");
            }
            else
            {
                Properties.Settings.Default.ReadFlaps = true;
                Output(isGauge: false, output: "Flaps announcement enabled. ");
            }
        }

        private void onToggleILSKey()
        {
            if (Properties.Settings.Default.ReadILS == true)
            {
                Properties.Settings.Default.ReadILS = false;
                ilsTimer.Enabled = false;
                Output(isGauge: false, output: "Read ILS disabled");
            }
            else
            {
                Properties.Settings.Default.ReadILS = true;
                Output(isGauge: false, output: "Read ILS enabled");

            }
        }

        private void onGPWSKey()
        {
            if (Properties.Settings.Default.ReadGPWS == false)
            {
                Properties.Settings.Default.ReadGPWS = true;
                Output(isGauge: false, output: "GPWS enabled");
            }
            else
            {
                Properties.Settings.Default.ReadGPWS = false;
                Output(isGauge: false, output: "GPWS disabled");
            }
        }

        private void onDirectorKey()
        {
            Tolk.Output("not yet implemented.");
        }

        private void onAutopilotKey()
        {
            if (Properties.Settings.Default.ReadAutopilot)
            {
                Properties.Settings.Default.ReadAutopilot = false;
                Output(isGauge: false, output: "read autopilot instruments disabled");
            }
            else
            {
                Properties.Settings.Default.ReadAutopilot = true;
                Output(isGauge: false, output: "Read autopilot instruments enabled. ");
            }
        }

        private void onAttitudeKey()
        {
            if (!attitudeModeEnabled)
            {
                attitudeModeEnabled = true;
                // set up the timer
                AttitudeTimer = new System.Timers.Timer(150); // 200 milliseconds
                // Hook up the Elapsed event for the timer. 
                AttitudeTimer.Elapsed += OnAttitudeModeTickEvent;
                AttitudeTimer.AutoReset = true;
                Output(isGauge: false, output: "Attitude mode enabled. ");
                // start audio
                // signal generator for generating tones
                wg = new SignalGenerator
                {
                    Type = SignalGeneratorType.Square,
                    Gain = 0.1
                };
                // set up panning provider, with the signal generator as input
                pan = new PanningSampleProvider(wg.ToMono());

                pitchSineProvider = new SineWaveProvider();
                // bankSineProvider = new SineWaveProvider();
                AttitudeTimer.Enabled = true;
            }
            else
            {
                mixer.RemoveAllMixerInputs();
                AttitudePitchPlaying = false;
                AttitudeBankLeftPlaying = false;
                AttitudeBankRightPlaying = false;
                AttitudeTimer.Stop();
                attitudeModeEnabled = false;
                Output(isGauge: false, output: "Attitude mode disabled. ");
            }
        }
        private void OnAttitudeModeTickEvent(Object source, ElapsedEventArgs e)
        {
            attitudeModeSelect = Properties.Settings.Default.AttitudeAnnouncementMode;
            // pan = new PanningSampleProvider(bankSineProvider);
            FSUIPCConnection.Process("attitude");
            double Pitch = Math.Round((double)Aircraft.AttitudePitch.Value * 360d / (65536d * 65536d));
            double Bank = Math.Round((double)Aircraft.AttitudeBank.Value * 360d / (65536d * 65536d));
            // pitch down
            if (Pitch > 0 && Pitch < 20)
            {
                if (attitudeModeSelect == 2 || attitudeModeSelect == 3)
                {
                    if (Pitch != oldPitch)
                    {
                        Output(isGauge: false, textOutput: false, interruptSpeech: true, output: $"down {Pitch}");
                        oldPitch = Pitch;
                        if (attitudeModeSelect == 2) return;
                    }
                }
                if (attitudeModeSelect == 1 || attitudeModeSelect == 3)
                {
                    if (!AttitudePitchPlaying)
                    {
                        mixer.AddMixerInput(new SampleToWaveProvider(pitchSineProvider.ToStereo()));
                        Logger.Debug("pitch: " + Pitch);
                        AttitudePitchPlaying = true;
                    }

                    double freq = mapOneRangeToAnother(Pitch, 0, 20, 600, 200, 0);
                    pitchSineProvider.Frequency = freq;
                }

            }
            // pitch up
            if (Pitch < 0 && Pitch > -20)
            {
                if (attitudeModeSelect == 2 || attitudeModeSelect == 3)
                {
                    if (Pitch != oldPitch)
                    {
                        Output(interruptSpeech: true, isGauge: false, textOutput: false, output: $"up {Math.Abs(Pitch)}");
                        oldPitch = Pitch;
                        if (attitudeModeSelect == 2) return;
                    }
                }

                if (attitudeModeSelect == 1 || attitudeModeSelect == 3)
                {
                    if (!AttitudePitchPlaying)
                    {
                        mixer.AddMixerInput(new SampleToWaveProvider(pitchSineProvider.ToStereo()));
                        Logger.Debug("pitch: " + Pitch);
                        AttitudePitchPlaying = true;
                    }
                    double freq = mapOneRangeToAnother(Pitch, -20, 0, 1200, 800, 0);
                    pitchSineProvider.Frequency = freq;
                }

            }
            // bank left
            if (Bank > 0 && Bank < 90)
            {
                if (attitudeModeSelect == 2 || attitudeModeSelect == 3)
                {
                    if (Bank != OldBank)
                    {
                        Output(interruptSpeech: true, isGauge: false, textOutput: false, output: $"left {Bank}");
                        OldBank = Bank;
                        if (attitudeModeSelect == 2) return;
                    }
                }
                if (attitudeModeSelect == 1 || attitudeModeSelect == 3)
                {
                    double freq = mapOneRangeToAnother(Bank, 1, 90, 400, 800, 0);
                    // bankSineProvider.Frequency = freq;
                    wg.Frequency = freq;
                    if (!AttitudeBankLeftPlaying)
                    {
                        mixer.RemoveAllMixerInputs();
                        pan.Pan = -1;
                        mixer.AddMixerInput(pan);
                        mixer.AddMixerInput(new SampleToWaveProvider(pitchSineProvider.ToStereo()));
                        AttitudeBankLeftPlaying = true;
                        AttitudeBankRightPlaying = false;
                    }

                }


            }
            // bank right
            if (Bank < 0 && Bank > -90)
            {
                Bank = Math.Abs(Bank);
                if (attitudeModeSelect == 2 || attitudeModeSelect == 3)
                {
                    if (Bank != OldBank)
                    {
                        Output(interruptSpeech: true, isGauge: false, textOutput: false, output: $"right {Bank}");
                        OldBank = Bank;
                        if (attitudeModeSelect == 2) return;
                    }
                }

                if (attitudeModeSelect == 1 || attitudeModeSelect == 3)
                {
                    double freq = mapOneRangeToAnother(Bank, 1, 90, 400, 800, 0);
                    // bankSineProvider.Frequency = freq;
                    wg.Frequency = freq;
                    if (!AttitudeBankRightPlaying)
                    {
                        mixer.RemoveAllMixerInputs();
                        pan.Pan = 1;
                        mixer.AddMixerInput(pan);
                        mixer.AddMixerInput(new SampleToWaveProvider(pitchSineProvider.ToStereo()));
                        AttitudeBankLeftPlaying = false;
                        AttitudeBankRightPlaying = true;
                    }

                }
            }
            if (Bank == 0)
            {
                if (attitudeModeSelect == 1 || attitudeModeSelect == 3)
                {
                    mixer.RemoveAllMixerInputs();
                    mixer.AddMixerInput(new SampleToWaveProvider(pitchSineProvider.ToStereo()));
                    AttitudeBankLeftPlaying = false;
                    AttitudeBankRightPlaying = false;
                    AttitudePitchPlaying = true;

                }
            }

        }


        private void OnDestinationKey()
        {
            if (PMDG737Detected)
            {
                var distanceToDestination = Math.Round(Aircraft.pmdg737.FMC_DistanceToDest.Value);
                try
                {
                    Output(isGauge: false, output: $"Distance to destination: {distanceToDestination}/{PMDG737Aircraft.TimeToDestination.ToString(@"d\:h\:m\:s")}");
                }
                catch (DivideByZeroException)
                {
                    Output(isGauge: false, output: "The aircraft is not moving.");
                }
                                catch (OverflowException)
                {
                    Output(isGauge: false, output: "Distance to destination not available.");
                }
                            } // PMDG 737
            else if (PMDG747Detected)
            {
                var distanceToDestination = Math.Round(Aircraft.pmdg747.FMC_DistanceToDest.Value);
                try
                {
                    Output(isGauge: false, output: $"Distance to destination: {distanceToDestination}/{PMDG747Aircraft.TimeToDestination.ToString(@"d\:h\:m\:s")}");
                }
                catch (DivideByZeroException)
                {
                    Output(isGauge: false, output: "The aircraft is not moving.");
                }
                catch (OverflowException)
                {
                    Output(isGauge: false, output: "Distance to destination not available.");
                }
            }
            else if (PMDG777Detected)
            {
                var distanceToDestination = Math.Round(Aircraft.pmdg777.FMC_DistanceToDest.Value);
                try
                {
                    Output(isGauge: false, output: $"Distance to destination: {distanceToDestination}/{PMDG777Aircraft.TimeToDestination.ToString(@"d\:h\:m\:s")}");
                }
                catch (DivideByZeroException)
                {
                    Output(isGauge: false, output: "The aircraft is not moving.");
                }
                catch (OverflowException)
                {
                    Output(isGauge: false, output: "Distance to destination not available.");
                }
                            } // End PMDG 777.
            else
            {

                TimeSpan TimeEnroute = TimeSpan.FromSeconds(Aircraft.DestinationTimeEnroute.Value);
                string strTime = string.Format("{0:%h} hours {0:%m} minutes, {0:%s} seconds", TimeEnroute);
                if (TimeEnroute.Hours == 0)
                {
                    strTime = string.Format("{0:%m} minutes, {0:%s} seconds", TimeEnroute);
                }
                if (TimeEnroute.Minutes == 0 && TimeEnroute.Hours == 0)
                {
                    strTime = string.Format("{0:%s} seconds", TimeEnroute);
                }
                Output(isGauge: false, output: $"Time enroute to destination, {strTime}. ");

            }
        }

        private void onTODKey()
        {
            if (PMDG737Detected)
            {
                var tod = Math.Round(Aircraft.pmdg737.FMC_DistanceToTOD.Value);
                try
                {
                    Output(isGauge: false, output: $"Distance to descent: {tod}/{PMDG737Aircraft.TimeToTOD.ToString(@"d\:h\:m\:s")}");
                }
                catch (DivideByZeroException)
                {
                    Output(isGauge: false, output: "The aircraft is not moving.");
                }
                catch (OverflowException)
                {
                    Output(isGauge: false, output: "Distance to descent not available.");
                }
            } // PMDG 737
            else if (PMDG747Detected)
            {
                var tod = Math.Round(Aircraft.pmdg747.FMC_DistanceToTOD.Value);
                try
                {
                    Output(isGauge: false, output: $"Distance to descent: {tod}/{PMDG747Aircraft.TimeToTOD.ToString(@"d\:h\:m\:s")}");
                }
                catch (DivideByZeroException)
                {
                    Output(isGauge: false, output: "The aircraft is not moving.");
                }
                catch (OverflowException)
                {
                    Output(isGauge: false, output: "Distance to descent not available.");
                }
            }
            else if (PMDG777Detected)
            {
                var tod = Math.Round(Aircraft.pmdg777.FMC_DistanceToTOD.Value);
                try
                {
                    Output(isGauge: false, output: $"Distance to descent: {tod}/{PMDG777Aircraft.TimeToTOD.ToString(@"d\:h\:m\:s")}");
                }
                catch (DivideByZeroException)
                {
                    Output(isGauge: false, output: "The aircraft is not moving.");
                }
                catch (OverflowException)
                {
                    Output(isGauge: false, output: "Distance to descent not available.");
                }
            } // End PMDG 777.
            else
            {
                return;
            }
        }

        private void OnWaypointKey()
        {
            if (Aircraft.AircraftName.Value.Contains("PMDG"))
            {
                Output(isGauge: false, output: "Not supported in PMDG aircraft. Please see the legs page of your FMC for the next waypoint.");
                return;
            }
            ReadWayPoint();
        }

        private void OnCityKey()
        {
            double lat = Aircraft.aircraftLat.Value.DecimalDegrees;
            double lon = Aircraft.aircraftLon.Value.DecimalDegrees;
            // double lat = -48.876667;
            // double lon = -123.393333;
            if (Properties.Settings.Default.GeonamesUsername == "")
            {
                Output(isGauge: false, output: "geonames username not configured");
                return;
            }
            var geonamesUser = Properties.Settings.Default.GeonamesUsername;
            if (Properties.Settings.Default.FlightFollowingOffline)
            {
                var pos = r.CreateFromLatLong(lat, lon);
                var results = r.NearestNeighbourSearch(pos, 1);
                foreach (var res in results)
                {
                    Tolk.Output(res.Name);
                    Tolk.Output(res.Admincodes[1]);
                }
            }
            else
            {
                try
                {

                    var xmlNearby = XElement.Load($"http://api.geonames.org/findNearbyPlaceName?style=long&lat={lat}&lng={lon}&username={geonamesUser}&cities=cities1000&radius=200");
                    var locations = xmlNearby.Descendants("geoname").Select(g => new
                    {
                        Name = g.Element("name").Value,
                        Lat = g.Element("lat").Value,
                        Long = g.Element("lng").Value,
                        admin1 = g.Element("adminName1").Value,
                        countryName = g.Element("countryName").Value
                    });
                    if (locations.Count() > 0)
                    {
                        var location = locations.First();
                        // get the current magnetic variation
                        double magVarDegrees = (double)Aircraft.MagneticVariation.Value * 360d / 65536d;
                        // create a point for the aircraft current position
                        FsLatLonPoint aircraftPos = new FsLatLonPoint(Aircraft.aircraftLat.Value, Aircraft.aircraftLon.Value);
                        // create a point for the nearest city
                        double nearestCityLat = double.Parse(location.Lat);
                        double nearestCityLong = double.Parse(location.Long);
                        FsLatLonPoint nearestCityPoint = new FsLatLonPoint(nearestCityLat, nearestCityLong);
                        string distanceNM = aircraftPos.DistanceFromInNauticalMiles(nearestCityPoint).ToString("F1");
                        double bearingTrue = aircraftPos.BearingTo(nearestCityPoint);
                        double bearingMagnetic = bearingTrue - magVarDegrees;
                        string strBearing = bearingMagnetic.ToString("F0");
                        Output(isGauge: false, output: $"{location.Name} {location.admin1}, {location.countryName}. ");
                        Output(isGauge: false, output: $"{distanceNM} nautical miles, {strBearing} degrees.");
                    }
                    else
                    {
                        Output(isGauge: false, output: $"No city nearby.");
                    }
                }
                catch (Exception ex)
                {
                    Logger.Debug($"error retrieving nearest city: {ex.Message}");
                    Tolk.Output("error retrieving nearest city. check log.");
                }
                try
                {
                    var xmlOcean = XElement.Load($"http://api.geonames.org/ocean?lat={lat}&lng={lon}&username={geonamesUser}");
                    var ocean = xmlOcean.Descendants("ocean").Select(g => new
                    {
                        Name = g.Element("name").Value
                    });
                    if (ocean.Count() > 0)
                    {
                        var currentOcean = ocean.First();
                        Output(isGauge: false, output: $"{currentOcean.Name}. ");
                    }

                }
                catch (Exception ex)
                {
                    Logger.Debug($"error retrieving oceanic info: {ex.Message}");

                }
                var xmlTimezone = XElement.Load($"http://api.geonames.org/timezone?lat={lat}&lng={lon}&username={geonamesUser}&radius=50");
                var timezone = xmlTimezone.Descendants("timezone").Select(g => new
                {
                    Name = g.Element("timezoneId").Value
                });
                if (timezone.Count() > 0)
                {
                    var currentTimezone = timezone.First();
                    if (currentTimezone.Name != oldTimezone)
                    {
                        try
                        {
                            string tzName = TZConvert.IanaToWindows(currentTimezone.Name);
                            Output(isGauge: false, output: $"{tzName}. ");
                        }
                        catch (Exception)
                        {

                            Logger.Debug($"cannot convert timezone: {currentTimezone.Name}");
                        }

                        oldTimezone = currentTimezone.Name;
                    }

                }


            }
        }
        private void OnMuteSimconnectKey()
        {
            if (muteSimconnect)
            {
                muteSimconnect = false;
                Output(isGauge: false, output: "SimConnect messages unmuted. ");
            }
            else
            {
                muteSimconnect = true;
                Output(isGauge: false, output: "SimConnect messages muted.");
            }
            ResetHotkeys();
        }

        private void onTrimKey()
        {
            if (TrimEnabled)
            {
                TrimEnabled = false;
                Output(isGauge: false, output: "read trim disabled. ");
            }
            else
            {
                TrimEnabled = true;
                Output(isGauge: false, output: "trim enabled. ");
            }
            ResetHotkeys();
        }

        private void onAirtempKey()
        {
            double tempC = (double)Aircraft.AirTemp.Value / 256d;
            double tempF = 9.0 / 5.0 * tempC + 32;
            var gaugeName = "Outside temperature";
            var isGauge = true;
            string gaugeValue;
            if (Properties.Settings.Default.UseMetric)
            {
                gaugeValue = tempC.ToString("F0");
            }
            else
            {
                gaugeValue = tempF.ToString("F0");
            }
            Output(gaugeName, gaugeValue, isGauge);
        }

        private void OnVSpeedKey()
        {
            double vspeed = (double)Aircraft.VerticalSpeed.Value * 3.28084d * -1;

            // used in the onScreenReaderOutput event in the main form.
            var gageName = "Vertical speed";
            var gageValue = vspeed.ToString("f0");
            var isGage = true;

            //Tolk.Output(vspeed.ToString("f0") + " feet per minute. ");
            // Test the new event.
            Output(gageName, gageValue, isGage);
            ResetHotkeys();

        }
        private void OnLandingRateKey()
        {
            // convert FSUIPC unit to expected FPM value
            double vspd = Math.Round(Aircraft.LandingRate.Value * 60 * 3.28084 / 256);
            Output(isGauge: false, output: $"Landing Rate: {vspd} Feet per minute");

        }
        private void OnMachKey()
        {
            double mach = (double)Aircraft.AirspeedMach.Value / 20480d;
            var gaugeName = "Mach";
            var isGauge = true;
            var gaugeValue = mach.ToString("F2");
            Output(gaugeName, gaugeValue, isGauge);

        }

        private void OnTASKey()
        {
            double tas = (double)Aircraft.AirspeedTrue.Value / 128d;
            var gaugeName = "Airspeed true";
            var isGauge = true;
            var gaugeValue = tas.ToString("F0");
            Output(gaugeName, gaugeValue, isGauge);
        }

        private void OnIASKey()
        {
            double ias = (double)Aircraft.AirspeedIndicated.Value / 128d;
            var gaugeName = "Airspeed indicated";
            var isGauge = true;
            var gaugeValue = ias.ToString("F0");
            Output(gaugeName, gaugeValue, isGauge);
        }

        private void OnHeadingKey()
        {
            Output(isGauge: false, output: "heading: " + Autopilot.Heading);
            ResetHotkeys();
        }

        private void OnAGLKey()
        {
            double groundAlt = (double)Aircraft.GroundAltitude.Value / 256d * 3.28084d;
            double agl = (double)Aircraft.Altitude.Value - groundAlt;
            var gaugeName = "AGL altitude";
            var isGauge = true;
            var gaugeValue = Math.Round(agl, 0).ToString();
            Output(gaugeName, gaugeValue, isGauge);
        }

        public void ResetHotkeys()
        {
            HotkeyManager.Current.Remove("Command_Key");
            HotkeyManager.Current.Remove("ap_Command_Key");
            foreach (string k in hotkeys)
            {
                HotkeyManager.Current.Remove(k);
            }
            foreach (string k in autopilotHotkeys)
            {
                HotkeyManager.Current.Remove(k);
            }
            if (CommandKeyEnabled)
            {
                HotkeyManager.Current.AddOrReplace("Command_Key", (Keys)Properties.Hotkeys.Default.Command_Key, commandMode);
                HotkeyManager.Current.AddOrReplace("ap_Command_Key", (Keys)Properties.Hotkeys.Default.ap_Command_Key, autopilotCommandMode);
            }

        }


        private void OnASLKey()
        {
            double asl = Math.Round((double)Aircraft.Altitude.Value, 0);
            var gaugeName = "ASL altitude";
            var gaugeValue = asl.ToString("F0");
            var isGauge = true;
            Output(gaugeName, gaugeValue, isGauge);
        }


        private void OnEngineInfoKey(int eng)
        {
            double N1 = 0;
            double N2 = 0;
            bool metric = Properties.Settings.Default.UseMetric;
            string output = null;
            // check engine type. 0 - piston, 1- jet
            if (Aircraft.EngineType.Value == 0)
            {
                double cht;
                double egt;
                double manifold;
                double rpm;
                string units;
                switch (eng)
                {
                    case 1:
                        // FSUIPC represents EGT in degrees Rankine, so we need to convert
                        egt = Aircraft.Engine1EGT.Value;
                        if (metric == true)
                        {
                            egt = Math.Round((egt - 491.67) * 5d / 9d);
                        }
                        else
                        {
                            egt = Math.Round(egt - 459.67);
                        }
                        cht = Aircraft.Engine1CHT.Value;
                        if (Properties.Settings.Default.UseMetric == true)
                        {
                            cht = Math.Round((cht - 32) * 5 / 9);
                            units = "C";
                        }
                        else
                        {
                            cht = Math.Round(cht);
                            units = "F";
                        }
                        rpm = Math.Round(Aircraft.Engine1RPM.Value);
                        manifold = Aircraft.Engine1ManifoldPressure.Value / 1024;
                        output = $"Engine 1: CHT: {cht} {units}, EGT: {egt} {units}, RPM: {rpm}, manifold: {manifold} inches. ";
                        Output(isGauge: false, output: output);
                        break;

                    case 2:
                        // FSUIPC represents EGT in degrees Rankine, so we need to convert
                        egt = Aircraft.Engine2EGT.Value;
                        if (metric == true)
                        {
                            egt = Math.Round((egt - 491.67) * 5d / 9d);
                        }
                        else
                        {
                            egt = Math.Round(egt - 459.67);
                        }
                        cht = Aircraft.Engine2CHT.Value;
                        if (Properties.Settings.Default.UseMetric == true)
                        {
                            cht = Math.Round((cht - 32) * 5 / 9);
                            units = "C";
                        }
                        else
                        {
                            cht = Math.Round(cht);
                            units = "F";
                        }
                        rpm = Math.Round(Aircraft.Engine2RPM.Value);
                        manifold = Aircraft.Engine2ManifoldPressure.Value / 1024;
                        output = $"Engine 2: CHT: {cht} {units}, EGT: {egt} {units}, RPM: {rpm}, manifold: {manifold} inches. ";
                        Output(isGauge: false, output: output);
                        break;

                    case 3:
                        // FSUIPC represents EGT in degrees Rankine, so we need to convert
                        egt = Aircraft.Engine3EGT.Value;
                        if (metric == true)
                        {
                            egt = Math.Round((egt - 491.67) * 5d / 9d);
                        }
                        else
                        {
                            egt = Math.Round(egt - 459.67);
                        }
                        cht = Aircraft.Engine3CHT.Value;
                        if (Properties.Settings.Default.UseMetric == true)
                        {
                            cht = Math.Round((cht - 32) * 5 / 9);
                            units = "C";
                        }
                        else
                        {
                            cht = Math.Round(cht);
                            units = "F";
                        }
                        rpm = Math.Round(Aircraft.Engine3RPM.Value);
                        manifold = Aircraft.Engine3ManifoldPressure.Value / 1024;
                        output = $"Engine 3: CHT: {cht} {units}, EGT: {egt} {units}, RPM: {rpm}, manifold: {manifold} inches. ";
                        Output(isGauge: false, output: output);
                        break;

                    case 4:
                        // FSUIPC represents EGT in degrees Rankine, so we need to convert
                        egt = Aircraft.Engine4EGT.Value;
                        if (metric == true)
                        {
                            egt = Math.Round((egt - 491.67) * 5d / 9d);
                        }
                        else
                        {
                            egt = Math.Round(egt - 459.67);
                        }
                        cht = Aircraft.Engine4CHT.Value;
                        if (Properties.Settings.Default.UseMetric == true)
                        {
                            cht = Math.Round((cht - 32) * 5 / 9);
                            units = "C";
                        }
                        else
                        {
                            cht = Math.Round(cht);
                            units = "F";
                        }
                        rpm = Math.Round(Aircraft.Engine4RPM.Value);
                        manifold = Aircraft.Engine4ManifoldPressure.Value / 1024;
                        output = $"Engine 4: CHT: {cht} {units}, EGT: {egt} {units}, RPM: {rpm}, manifold: {manifold} inches. ";
                        Output(isGauge: false, output: output);
                        break;
                }
            }
            if (Aircraft.EngineType.Value == 1)
            {
                switch (eng)
                {
                    case 1:
                        N1 = (double)Aircraft.Eng1N1.Value;
                        N2 = (double)Aircraft.Eng1N2.Value;
                        break;
                    case 2:
                        N1 = (double)Aircraft.Eng2N1.Value;
                        N2 = (double)Aircraft.Eng2N2.Value;
                        break;
                    case 3:
                        N1 = (double)Aircraft.Eng3N1.Value;
                        N2 = (double)Aircraft.Eng3N2.Value;
                        break;
                    case 4:
                        N1 = (double)Aircraft.Eng4N1.Value;
                        N2 = (double)Aircraft.Eng4N2.Value;
                        break;
                }
                Output(isGauge: false, output: $"Engine {eng}. ");
                Output(isGauge: false, output: $"N1: {Math.Round(N1)}. ");
                Output(isGauge: false, output: $"N2: {Math.Round(N2)}. ");
            }

        }

        /// <summary>
        /// TODO: Rework current location feature.
        /// </summary>
        private async void OnCurrentLocation()
        {
            var database = FSUIPCConnection.AirportsDatabase;
            var currentLocation = database.Airports.GetPlayerLocation(AirportComponents.Gates | AirportComponents.Runways | AirportComponents.Taxiways);

            // Check to see if we are on the ground
            if(currentLocation != null && currentLocation.OnGround)
            {
                                if (currentLocation.Runway != null && currentLocation.Runway.IsPlayerOnRunway)
                {
                    Output(isGauge: false, output: $"Runway {currentLocation.Runway.ID}@{currentLocation.Airport.ICAO}");
                }
else if (currentLocation.Gate != null && currentLocation.Gate.IsPlayerAtGate)
                {
                    Output(isGauge: false, output: $"Gate {currentLocation.Gate.ID}@{currentLocation.Airport.ICAO}");
                }
else if(currentLocation.Taxiway != null && currentLocation.Taxiway.IsPlayerOnTaxiway)
                {
                    Output(isGauge: false, output: $"Taxiway {currentLocation.Taxiway.Name}@{currentLocation.Airport.ICAO}");
                }
else if(currentLocation.Gate == null && currentLocation.Taxiway == null && currentLocation.Runway == null && currentLocation.Airport.IsPlayerAtAirport)
                {
                    Output(isGauge: false, output: $"@{currentLocation.Airport.ICAO}");
                }
else if(currentLocation.Airport == null)
                {
                    Output(isGauge: false, output: "Not at an airport.");
                }
                                                               }
            else
            {
                if (string.IsNullOrEmpty(Properties.Settings.Default.bingMapsAPIKey))
                {
                    Output(isGauge: false, output: "Please set the Bing Maps API key in settings before using the where am I feature.");
                    return;
                } // Sanity check on api keys.
                var latitude = Aircraft.aircraftLat.Value.DecimalDegrees;
                var longitude = Aircraft.aircraftLon.Value.DecimalDegrees;
                // Retrieve the state/province/territory.
                var cityRequest = new GetBoundaryRequest()
                {
                    EntityType = BoundaryEntityType.AdminDivision2,
                    LevelOfDetail = 3,
                    GetAllPolygons = true,
                    GetEntityMetadata = true,
                    Coordinate = new BingMapsSDSToolkit.GeodataLocation(latitude, longitude)
                };

                var stateRequest = new GetBoundaryRequest()
                {
                    EntityType = BoundaryEntityType.AdminDivision1,
                    LevelOfDetail = 3,
                    GetAllPolygons = true,
                    GetEntityMetadata = true,
                    Coordinate = new BingMapsSDSToolkit.GeodataLocation(latitude, longitude)
                };

                var countryRequest = new GetBoundaryRequest()
                {
                    EntityType = BoundaryEntityType.CountryRegion,
                    LevelOfDetail = 3,
                    GetAllPolygons = true,
                    GetEntityMetadata = true,
                    Coordinate = new BingMapsSDSToolkit.GeodataLocation(latitude, longitude)
                };
                var cityResponse = await GeodataManager.GetBoundary(cityRequest, Properties.Settings.Default.bingMapsAPIKey);
                var stateResponse = await GeodataManager.GetBoundary(stateRequest, Properties.Settings.Default.bingMapsAPIKey);
                var countryResponse = await GeodataManager.GetBoundary(countryRequest, Properties.Settings.Default.bingMapsAPIKey);

                // Check for existence of a country. If none present, most likely we are in a body of water.
                if (countryResponse == null)
                {
                    if (string.IsNullOrWhiteSpace(Properties.Settings.Default.GeonamesUsername))
                    {
                        Output(isGauge: false, output: "You must have a Geonames username to use this feature.");
                        return;
                    }
                    try
                    {
                        var xmlOcean = XElement.Load($"http://api.geonames.org/ocean?lat={latitude}&lng={longitude}&username={Properties.Settings.Default.GeonamesUsername}");
                        var ocean = xmlOcean.Descendants("ocean").Select(g => new
                        {
                            Name = g.Element("name").Value
                        });
                        if (ocean.Count() > 0)
                        {
                            var currentOcean = ocean.First();
                            Output(isGauge: false, output: $"{currentOcean.Name}. ");
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Debug($"error retrieving oceanic info: {ex.Message}");

                    }
                }
                else
                {
                    Output(isGauge: false, output: $"{cityResponse[0].Name.EntityName} {stateResponse[0].Name.EntityName}, {countryResponse[0].Name.EntityName}");
                }
                var xmlTimezone = XElement.Load($"http://api.geonames.org/timezone?lat={latitude}&lng={longitude}&username={Properties.Settings.Default.GeonamesUsername}&radius=50");
                var timezone = xmlTimezone.Descendants("timezone").Select(g => new
                {
                    Name = g.Element("timezoneId").Value
                });
                if (timezone.Count() > 0)
                {
                    var currentTimezone = timezone.First();
                    if (currentTimezone.Name != oldTimezone)
                    {
                        try
                        {
                            string tzName = TZConvert.IanaToWindows(currentTimezone.Name);
                            Output(isGauge: false, output: $"{tzName}. ");
                        }
                        catch (Exception)
                        {

                            Logger.Debug($"cannot convert timezone: {currentTimezone.Name}");
                        }
                    }
                    oldTimezone = currentTimezone.Name;
                }
            }
        }

        private void onTakeOffAssistant()
        {
            if (Properties.Settings.Default.takeOffAssistMode == "off")
            {
                Output(isGauge: false, textOutput: true, output: "Takeoff assist is turned off. Please change it to full or partial in settings.");
                takeOffAssistantActive = false;
            } // Takeoff assist is permanently turned off.
            else if (Properties.Settings.Default.takeOffAssistMode == "full")
            {
                takeOffAssistantActive = true;
                Output(isGauge: false, textOutput: true, output: "Takeoff assist on.");
                // Flaps aren't included because flap positions very between planes,
                // and there isn't a promising way to determine flap positions.

                Aircraft.AutoThrottleArm.Value = 1; // On.
                Aircraft.AutoBrake.Value = 0; // Rejected takeoff.
                Aircraft.ApWingLeveler.Value = 1; // On.
                Aircraft.PitotHeat.Value = 1; // On.
                Autopilot.ApMaster = true;
                Autopilot.ApVerticalSpeed = 500; // Keeps most planes from bouncing.
                                                 //Autopilot.ApAltitudeLock = true; // Lock altitude before setting it. Otherwise, altitude lock reverts to current altitude.
                Autopilot.ApAltitude = 5000; // Reasonable request for a step climb until profiles are implemented.
                Autopilot.ApAirspeed = 250; // Must be faster than takeoff speed to avoid crashing.
                Aircraft.ParkingBrake.Value = 0; // Off.
                                                 // Start the engines on the plane.
                                                 //switch (Aircraft.num_engines.Value)
                                                 //{
                                                 //    case 1:
                                                 //        Aircraft.Engine1ThrottleLever.Value = 16388;
                                                 //        break;
                                                 //    case 2:
                                                 //        Aircraft.Engine1ThrottleLever.Value = 16388;
                                                 //        Aircraft.Engine2ThrottleLever.Value = 16388;
                                                 //        break;
                                                 //    case 3:
                                                 //        Aircraft.Engine1ThrottleLever.Value = 16388;
                                                 //        Aircraft.Engine2ThrottleLever.Value = 16388;
                                                 //        Aircraft.Engine3ThrottleLever.Value = 16388;
                                                 //        break;
                                                 //    case 4:
                                                 //        Aircraft.Engine1ThrottleLever.Value = 16388;
                                                 //        Aircraft.Engine2ThrottleLever.Value = 16388;
                                                 //        Aircraft.Engine3ThrottleLever.Value = 16388;
                                                 //        Aircraft.Engine4ThrottleLever.Value = 16388;
                                                 //        break;
                                                 //    case 0:
                                                 //        Output(isGauge: false, textOutput: true, output: "The aircraft engines are off, or have problems. Try again later.");
                                                 //        break;
                                                 //} // End throttle engines.
                isTakeoffComplete = false;
                PostTakeOffChecklist();
            } // End takeoff mode is full.
            else if (Properties.Settings.Default.takeOffAssistMode == "partial")
            {
                takeOffAssistantActive = true;
                Output(isGauge: false, textOutput: true, output: "Takeoff assist on.");
                isTakeoffComplete = false;
                PostTakeOffChecklist();
            } // End takeoff assist mode partial.
        }
        public bool PostTakeOffChecklist()
        {
            double groundAlt = (double)Aircraft.GroundAltitude.Value / 256d * 3.28084d;
            double agl = (double)Math.Round(Aircraft.Altitude.Value - groundAlt);
            if (takeOffAssistantActive && Aircraft.OnGround.Value == 0 && agl >= 100)
            {
                //var airSpeed = Autopilot.ApAirspeed;
                //Autopilot.ApAirspeed = airSpeed;
                Autopilot.ApAirspeedHold = true;
                Autopilot.ApAltitude = 32000;
                Autopilot.ApAltitudeLock = true;
                if (Aircraft.ApWingLeveler.Value == 1) Aircraft.ApWingLeveler.Value = 0; // Off.
                if (!Autopilot.ApHeadingLock) Autopilot.ApHeadingLock = true;
                Aircraft.AutoBrake.Value = 1; // Off.    
                Aircraft.ApYawDamper.Value = 1; // On.
                Autopilot.ApVerticalSpeedHold = true;
                Autopilot.ApVerticalSpeed = 2500; // Slowly increase for smoother transition.
                Aircraft.LandingGearControl.Value = 0; // Gear up.
                takeOffAssistantActive = false;
                isTakeoffComplete = true;
                Output(isGauge: false, output: "Takeoff assist off.");
                return isTakeoffComplete;
            }
            else
            {
                return isTakeoffComplete;
            }

        } // End PostTakeoffChecklist.

        public void MonitorN1Limit()
        {
            double n1Monitor = Math.Round(Aircraft.n1MonitorValue); // The value to watch,.
            bool isAnnounced = false;

            double en1n1 = (double)Math.Round(Aircraft.Eng1N1.Value);
            double en2n1 = (double)Math.Round(Aircraft.Eng2N1.Value);
            double en3n1 = (double)Math.Round(Aircraft.Eng3N1.Value);
            double en4n1 = (double)Math.Round(Aircraft.Eng4N1.Value);
            if (n1Monitor == 0 || isAnnounced) return;
            switch (Aircraft.num_engines.Value)
            {
                case 1:
                    if (en1n1 == n1Monitor)
                    {
                        if (isAnnounced) return;
                        Output(useSAPI: true, isGauge: false, interruptSpeech: false, output: "N1 limits achieved.");
                        isAnnounced = true;
                    }
                    else
                    {
                        isAnnounced = false;
                    }
                    break;

                case 2:
                    if ((en1n1 == n1Monitor) && (en2n1 == n1Monitor))
                    {
                        if (isAnnounced) break;
                        isAnnounced = true;
                        Output(useSAPI: true, isGauge: false, interruptSpeech: false, output: "N1 limits achieved.");

                    }
                    else
                    {
                        isAnnounced = false;
                    }
                    break;

                case 3:
                    if (en1n1 == n1Monitor && en2n1 == n1Monitor && en3n1 == n1Monitor)
                    {
                        if (isAnnounced) return;
                        Output(useSAPI: true, isGauge: false, interruptSpeech: false, output: "N1 limits achieved.");
                        isAnnounced = true;
                    }
                    else
                    {
                        isAnnounced = false;
                    }
                    break;

                case 4:
                    if (en1n1 == n1Monitor && en2n1 == n1Monitor && en3n1 == n1Monitor && en4n1 == n1Monitor)
                    {
                        if (isAnnounced)
                            Output(useSAPI: true, isGauge: false, interruptSpeech: false, output: "N1 limits achieved.");
                        isAnnounced = true;
                    }
                    else
                    {
                    }
                    break;
            } // End switch
        } // End MonitorN1Limit.

        public void ReadPmdgFMCMessage(string type = null)
        {
            PMDG_NGX_CDU_Screen cDU_Screen = new PMDG_NGX_CDU_Screen(0x5400);
            string message = string.Empty;

            if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("737"))
            {
                if (Aircraft.pmdg737.CDU_annunMSG[0].Value == 1)
                {
                    cDU_Screen.RefreshData();
                    message = cDU_Screen.Rows[13].ToString();
                }
            } // End 737 check.
            else if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("747"))
            {
                if (Aircraft.pmdg747.CDU_annunMSG[0].Value == 1)
                {
                    cDU_Screen.RefreshData();
                    message = cDU_Screen.Rows[13].ToString();
                }
            } // End 747 check.
            else if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("777"))
            {
                if (Aircraft.pmdg777.CDU_annunMSG[0].Value == 1)
                {
                    cDU_Screen.RefreshData();
                    message = cDU_Screen.Rows[13].ToString();
                }
            } // End 777 check.
            if (type == "requested")
            {
                Output(isGauge: false, useSAPI: true, output: message);
            } // End requested.
            else
            {
                if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("737"))
                {

                    if (Aircraft.pmdg737.CDU_annunMSG[0].ValueChanged)
                    {
                        switch (Aircraft.pmdg737.CDU_annunMSG[0].Value)
                        {
                            case 1:
                                Thread.Sleep(1000);
                                cDU_Screen.RefreshData();
                                
                                Output(isGauge: false, useSAPI: true, output: $"{cDU_Screen.Rows[13].ToString()}");
                                break;
                        }
                    }
                } // End 737 check.
                if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("747"))
                {

                    if (Aircraft.pmdg747.CDU_annunMSG[0].ValueChanged)
                    {
                        switch (Aircraft.pmdg747.CDU_annunMSG[0].Value)
                        {
                            case 1:
                                cDU_Screen.RefreshData();
                                Output(isGauge: false, useSAPI: true, output: $"{cDU_Screen.Rows[13].ToString()}");
                                break;
                        }
                    }
                } // End 747 check.
                if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("777"))
                {

                    if (Aircraft.pmdg777.CDU_annunMSG[0].ValueChanged)
                    {
                        switch (Aircraft.pmdg777.CDU_annunMSG[0].Value)
                        {
                            case 1:
                                Thread.Sleep(1000);
                                cDU_Screen.RefreshData();
                                Output(isGauge: false, useSAPI: true, output: $"{cDU_Screen.Rows[13].ToString()}");
                                break;
                        }
                    }
                } // End 777 check.
            } // End else
        } // End ReadPmdgFmcMessage.

        private void ReadPMDG737Toggles()
        {
                        foreach(PanelObject toggle in PMDG737Aircraft.PanelControls)
            {
                // Only ones marked to speak are announced.
                if (toggle.shouldSpeak == true)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        Output(isGauge: false, output: toggle.ToString());
                    }
                                    }
            }


            ReadToggle(Aircraft.pmdg737.HGS_annun_FLARE, Aircraft.pmdg737.HGS_annun_FLARE.Value > 0, "Flare light", "on", "off");
            // electrical panel
            ReadPMDGToggle(Aircraft.pmdg737.ELEC_BatSelector, Aircraft.pmdg737.ELEC_BatSelector.Value > 0, "Battery", "active", "off");
            ReadToggle(Aircraft.pmdg737.ELEC_annunBAT_DISCHARGE, Aircraft.pmdg737.ELEC_annunBAT_DISCHARGE.Value > 0, "bat discharge light", "on", "off");
            ReadToggle(Aircraft.pmdg737.ELEC_annunGRD_POWER_AVAILABLE, Aircraft.pmdg737.ELEC_annunGRD_POWER_AVAILABLE.Value > 0, "ground power", "available", "not available");
            ReadToggle(Aircraft.pmdg737.ELEC_CabUtilSw, Aircraft.pmdg737.ELEC_CabUtilSw.Value > 0, "cabin utility switch", "on", "off");
            ReadToggle(Aircraft.pmdg737.ELEC_IFEPassSeatSw, Aircraft.pmdg737.ELEC_IFEPassSeatSw.Value > 0, "passenger seat power", "on", "off");
            ReadToggle(Aircraft.pmdg737.ELEC_annunAPU_GEN_OFF_BUS, Aircraft.pmdg737.ELEC_annunAPU_GEN_OFF_BUS.Value > 0, "APU Gen 1 off bus light", "on", "off");
            ReadToggle(Aircraft.pmdg737.ELEC_annunAPU_GEN_OFF_BUS, Aircraft.pmdg737.ELEC_annunAPU_GEN_OFF_BUS.Value > 0, "engine generator off bus light", "on", "off");
            ReadToggle(Aircraft.pmdg737.APU_annunLOW_OIL_PRESSURE, Aircraft.pmdg737.APU_annunLOW_OIL_PRESSURE.Value > 0, "APU low oil pressure light", "on", "off");
            ReadToggle(Aircraft.pmdg737.ELEC_BusTransSw_AUTO, Aircraft.pmdg737.ELEC_BusTransSw_AUTO.Value > 0, "auto bus transfer", "on", "off");
            // standby power switch
            if (Aircraft.pmdg737.ELEC_StandbyPowerSelector.ValueChanged)
            {
                switch (Aircraft.pmdg737.ELEC_StandbyPowerSelector.Value)
                {
                    case 0:
                        Output(isGauge: false, output: "Standby power: Battery");
                        break;
                    case 1:
                        Output(isGauge: false, output: "Standby power: Off");
                        break;
                    case 2:
                        Output(isGauge: false, output: "Standby power: Auto");
                        break;
                }

            }
            // ADIRU
            ReadToggle(Aircraft.pmdg737.IRS_aligned, Aircraft.pmdg737.IRS_aligned.Value > 0, "IRS", "aligned", "");

            // MCP

            // flight director
            ReadToggle(Aircraft.pmdg737.MCP_FDSw[0], Aircraft.pmdg737.MCP_FDSw[0].Value > 0, "left flight director", "on", "off");
            ReadToggle(Aircraft.pmdg737.MCP_FDSw[1], Aircraft.pmdg737.MCP_FDSw[1].Value > 0, "right flight director", "on", "off");
            ReadToggle(Aircraft.pmdg737.MCP_annunFD[0], Aircraft.pmdg737.MCP_annunFD[0].Value > 0, "left fd master", "on", "off");
            ReadToggle(Aircraft.pmdg737.MCP_annunFD[1], Aircraft.pmdg737.MCP_annunFD[1].Value > 0, "right   fd master", "on", "off");
            // auto throttle arm
            ReadToggle(Aircraft.pmdg737.MCP_ATArmSw, Aircraft.pmdg737.MCP_ATArmSw.Value > 0, "autothrottle arm switch", "on", "off");
            ReadToggle(Aircraft.pmdg737.MCP_annunATArm, Aircraft.pmdg737.MCP_annunATArm.Value > 0, "Auto throttle light", "on", "off");
            // N1 button
            ReadToggle(Aircraft.pmdg737.MCP_annunN1, Aircraft.pmdg737.MCP_annunN1.Value > 0, "N1 light", "on", "off");
            // speed
            ReadToggle(Aircraft.pmdg737.MCP_annunSPEED, Aircraft.pmdg737.MCP_annunSPEED.Value > 0, "speed light", "on", "off");
            ReadToggle(Aircraft.pmdg737.MCP_IASBlank, Aircraft.pmdg737.MCP_IASBlank.Value > 0, "speed box", "blank", "visible");
            // LNAV
            ReadToggle(Aircraft.pmdg737.MCP_annunLNAV, Aircraft.pmdg737.MCP_annunLNAV.Value > 0, "L Nav light", "on", "off");
            // VNAV
            ReadToggle(Aircraft.pmdg737.MCP_annunVNAV, Aircraft.pmdg737.MCP_annunVNAV.Value > 0, "V Nav light", "on", "off");
            // Autopilot CMD buttons
            ReadToggle(Aircraft.pmdg737.MCP_annunCMD_A, Aircraft.pmdg737.MCP_annunCMD_A.Value > 0, "CMD A", "on", "off");
            ReadToggle(Aircraft.pmdg737.MCP_annunCMD_B, Aircraft.pmdg737.MCP_annunCMD_B.Value > 0, "CMD B", "on", "off");
            // autopilot heading select
            ReadToggle(Aircraft.pmdg737.MCP_annunHDG_SEL, Aircraft.pmdg737.MCP_annunHDG_SEL.Value > 0, "heading select", "on", "off");
            // level change
            ReadToggle(Aircraft.pmdg737.MCP_annunLVL_CHG, Aircraft.pmdg737.MCP_annunLVL_CHG.Value > 0, "level change", "on", "off");
            // altitude hold
            ReadToggle(Aircraft.pmdg737.MCP_annunALT_HOLD, Aircraft.pmdg737.MCP_annunALT_HOLD.Value > 0, "Altitude hold", "on", "off");
            // approach mode
            ReadToggle(Aircraft.pmdg737.MCP_annunAPP, Aircraft.pmdg737.MCP_annunAPP.Value > 0, "approach", "on", "off");
            ReadToggle(Aircraft.pmdg737.MCP_annunVOR_LOC, Aircraft.pmdg737.MCP_annunVOR_LOC.Value > 0, "vor loc", "on", "off");
            // CWS mode
            ReadToggle(Aircraft.pmdg737.MCP_annunCWS_A, Aircraft.pmdg737.MCP_annunCWS_A.Value > 0, "CWS A", "on", "off");
            ReadToggle(Aircraft.pmdg737.MCP_annunCWS_B, Aircraft.pmdg737.MCP_annunCWS_B.Value > 0, "CWS B", "on", "off");
            // CDU exec button light
            ReadToggle(Aircraft.pmdg737.CDU_annunEXEC[0], Aircraft.pmdg737.CDU_annunEXEC[0].Value > 0, "execute key", "available", "off");
            // CDU message light
            ReadToggle(Aircraft.pmdg737.CDU_annunMSG[0], Aircraft.pmdg737.CDU_annunMSG[0].Value > 0, "CDU message", "displayed", "cleared", SAPI: true);
            // auto land lights
            ReadToggle(Aircraft.pmdg737.HGS_annun_AIII, Aircraft.pmdg737.HGS_annun_AIII.Value > 0, "auto land", "active", "off");
            ReadToggle(Aircraft.pmdg737.HGS_annun_FLARE, Aircraft.pmdg737.HGS_annun_FLARE.Value > 0, "flare", "active", "off");
            ReadToggle(Aircraft.pmdg737.HGS_annun_RO, Aircraft.pmdg737.HGS_annun_RO.Value > 0, "roll out", "active", "off");

            // fuel panel
            ReadToggle(Aircraft.pmdg737.FUEL_CrossFeedSw, Aircraft.pmdg737.FUEL_CrossFeedSw.Value > 0, "fuel cross feed", "on", "off");
            ReadToggle(Aircraft.pmdg737.FUEL_PumpFwdSw[0], Aircraft.pmdg737.FUEL_PumpFwdSw[0].Value > 0, "left forward fuel pump", "on", "off");
            ReadToggle(Aircraft.pmdg737.FUEL_PumpFwdSw[1], Aircraft.pmdg737.FUEL_PumpFwdSw[1].Value > 0, "right forward fuel pump", "on", "off");
            ReadToggle(Aircraft.pmdg737.FUEL_PumpAftSw[1], Aircraft.pmdg737.FUEL_PumpAftSw[1].Value > 0, "right aft fuel pump", "on", "off");
            ReadToggle(Aircraft.pmdg737.FUEL_PumpAftSw[0], Aircraft.pmdg737.FUEL_PumpAftSw[0].Value > 0, "left aft fuel pump", "on", "off");
            ReadToggle(Aircraft.pmdg737.FUEL_PumpCtrSw[0], Aircraft.pmdg737.FUEL_PumpCtrSw[0].Value > 0, "center left fuel pump");
            ReadToggle(Aircraft.pmdg737.FUEL_PumpCtrSw[1], Aircraft.pmdg737.FUEL_PumpCtrSw[1].Value > 0, "center right fuel pump");

            // fuel crossfeed valve
            if (Aircraft.pmdg737.FUEL_annunXFEED_VALVE_OPEN.ValueChanged)

            {
                switch (Aircraft.pmdg737.FUEL_annunXFEED_VALVE_OPEN.Value)
                {
                    case 0:
                        Output(isGauge: false, output: "fuel cross feed valve closed");
                        break;
                    case 1:
                        Output(isGauge: false, output: "fuel cross feed valve open");
                        break;
                    case 2:
                        Output(isGauge: false, output: "fuel cross feed valve in transit");
                        break;
                }

            }
            // hydraulics
            ReadToggle(Aircraft.pmdg737.HYD_PumpSw_elec[1], Aircraft.pmdg737.HYD_PumpSw_elec[1].Value > 0, "electrical hydraulic pump 1", "on", "off");
            ReadToggle(Aircraft.pmdg737.HYD_PumpSw_elec[0], Aircraft.pmdg737.HYD_PumpSw_elec[0].Value > 0, "electrical hydraulic pump 2", "on", "off");
            if (Aircraft.pmdg737.AIR_PackSwitch[0].ValueChanged)
            {
                string pck = null;
                switch (Aircraft.pmdg737.AIR_PackSwitch[0].Value)
                {
                    case 0:
                        pck = "off";
                        break;
                    case 1:
                        pck = "auto";
                        break;
                    case 2:
                        pck = "high";
                        break;

                }
                Output(isGauge: false, output: $"left pack {pck}");
            }
            if (Aircraft.pmdg737.AIR_IsolationValveSwitch.ValueChanged)
            {
                string isol = null;
                switch (Aircraft.pmdg737.AIR_IsolationValveSwitch.Value)
                {
                    case 0:
                        isol = "off";
                        break;
                    case 1:
                        isol = "auto";
                        break;
                    case 2:
                        isol = "on";
                        break;

                }
                Output(isGauge: false, output: $"isolation valve {isol}");
            }
            if (Aircraft.pmdg737.AIR_PackSwitch[1].ValueChanged)
            {
                string pck = null;
                switch (Aircraft.pmdg737.AIR_PackSwitch[1].Value)
                {
                    case 0:
                        pck = "off";
                        break;
                    case 1:
                        pck = "auto";
                        break;
                    case 2:
                        pck = "high";
                        break;

                }
                Output(isGauge: false, output: $"right pack {pck}");
            }
            ReadToggle(Aircraft.pmdg737.AIR_BleedAirSwitch[1], Aircraft.pmdg737.AIR_BleedAirSwitch[1].Value > 0, "engine 2 bleed", "on", "off");
            ReadToggle(Aircraft.pmdg737.AIR_BleedAirSwitch[0], Aircraft.pmdg737.AIR_BleedAirSwitch[0].Value > 0, "engine 1 bleed", "on", "off");
            ReadToggle(Aircraft.pmdg737.AIR_APUBleedAirSwitch, Aircraft.pmdg737.AIR_APUBleedAirSwitch.Value > 0, "APU bleed", "on", "off");
        } // End ReadPMDG737Toggles.
        private void ReadPMDG747Toggles()
        {

            foreach(PanelObject toggle in PMDG747Aircraft.PanelControls)
            {
                if (toggle.shouldSpeak == true)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        Output(isGauge: false, output: toggle.ToString());
                    }
                }
            }
            // Overhead Maintenance
            // Electrical
            ReadToggle(Aircraft.pmdg747.ELEC_annunGen_FIELD_OFF[0], Aircraft.pmdg747.ELEC_annunGen_FIELD_OFF[0].Value > 0, "Gen. #1 field", "Off", "On");
            ReadToggle(Aircraft.pmdg747.ELEC_annunGen_FIELD_OFF[1], Aircraft.pmdg747.ELEC_annunGen_FIELD_OFF[1].Value > 0, "Gen. #2 field", "Off", "On");
            ReadToggle(Aircraft.pmdg747.ELEC_annunGen_FIELD_OFF[2], Aircraft.pmdg747.ELEC_annunGen_FIELD_OFF[2].Value > 0, "Gen. #3 field", "Off", "On");
            ReadToggle(Aircraft.pmdg747.ELEC_annunGen_FIELD_OFF[3], Aircraft.pmdg747.ELEC_annunGen_FIELD_OFF[3].Value > 0, "Gen. #4 field", "Off", "On");
            ReadToggle(Aircraft.pmdg747.ELEC_annunAPU_FIELD_OFF[0], Aircraft.pmdg747.ELEC_annunAPU_FIELD_OFF[0].Value > 0, "APU #1 field", "Off", "On");
            ReadToggle(Aircraft.pmdg747.ELEC_annunAPU_FIELD_OFF[1], Aircraft.pmdg747.ELEC_annunAPU_FIELD_OFF[1].Value > 0, "APU #2 field", "Off", "On");
            ReadToggle(Aircraft.pmdg747.ELEC_annunSplitSystemBreaker_OPEN, Aircraft.pmdg747.ELEC_annunSplitSystemBreaker_OPEN.Value > 0, "Split system breaker", "Open", "Closed");

            // Flight controls.
            ReadToggle(Aircraft.pmdg747.FCTL_annunTailHydVALVE_CLOSED[0], Aircraft.pmdg747.FCTL_annunTailHydVALVE_CLOSED[0].Value > 0, "Tail hyd. #1 valve", "Closed", "Opened");
            ReadToggle(Aircraft.pmdg747.FCTL_annunTailHydVALVE_CLOSED[1], Aircraft.pmdg747.FCTL_annunTailHydVALVE_CLOSED[1].Value > 0, "Tail hyd. #2 valve", "Closed", "Opened");
            ReadToggle(Aircraft.pmdg747.FCTL_annunTailHydVALVE_CLOSED[2], Aircraft.pmdg747.FCTL_annunTailHydVALVE_CLOSED[2].Value > 0, "Tail hyd. #3 valve", "Closed", "Opened");
            ReadToggle(Aircraft.pmdg747.FCTL_annunTailHydVALVE_CLOSED[3], Aircraft.pmdg747.FCTL_annunTailHydVALVE_CLOSED[3].Value > 0, "Tail hyd. #4 valve", "Closed", "Opened");
            ReadToggle(Aircraft.pmdg747.FCTL_annunWingHydVALVE_CLOSED[0], Aircraft.pmdg747.FCTL_annunWingHydVALVE_CLOSED[0].Value > 0, "Wing hyd. #1 valve", "Closed", "Opened");
            ReadToggle(Aircraft.pmdg747.FCTL_annunWingHydVALVE_CLOSED[1], Aircraft.pmdg747.FCTL_annunWingHydVALVE_CLOSED[1].Value > 0, "Wing hyd. #2 valve", "Closed", "Opened");
            ReadToggle(Aircraft.pmdg747.FCTL_annunWingHydVALVE_CLOSED[2], Aircraft.pmdg747.FCTL_annunWingHydVALVE_CLOSED[2].Value > 0, "Wing hyd. #3 valve", "Closed", "Opened");
            ReadToggle(Aircraft.pmdg747.FCTL_annunWingHydVALVE_CLOSED[3], Aircraft.pmdg747.FCTL_annunWingHydVALVE_CLOSED[3].Value > 0, "Wing hyd. #4 valve", "Closed", "Opened");

            // Overhead panels
            // IRS.


        } // End ReadPMDG747Toggles
        /// <summary>
        ///  function for speech and braille output
        /// </summary>
        /// <param name="isGauge"></param>
        /// <param name="gaugeName"></param>
        /// <param name="gaugeValue"></param>
        /// <param name="output"></param>
        public void Output(string gaugeName = "", string gaugeValue = "", bool isGauge = false, string output = "", bool textOutput = true, bool useSAPI = false, bool interruptSpeech = false)
        {
            // We can do anything we want since the gage/value are broken up into different variables now.
            // The event should take care of anything the screen reader needs to output to the user.

            // when e.isGage is true, e.output is empty.
            // Otherwise, e.output should contain a string to send to the screen reader.
            // EX: the next waypoint feature is inappropriate for e.gageName and e.gageValue, so e.isGage will be false, and e.output will have the output for the next waypoint.

            if (isGauge)
            {
                switch (gaugeName)
                {
                    case "Vertical speed":
                        // We can implement different settings here. One of them is braille support.
                        // After including a braille only, speech only, or both setting,
                        // All we need to do is check for the setting and respond to it.
                        // Braile, speech, and output can have different output without toying with the backend code.
                        // This also makes way for message type: short or long. A pilot might not want
                        // to hear "feet per minute" every time he/she presses ]v, so, give them a choice.
                        // That setting would be checked here because it influences screen reader/braille output.
                        // The log may also contain different formatting options. For now, stick with
                        // reasonable defaults.

                        Speak($"{gaugeValue} feet per minute.");
                        braille($"VSPD {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");

                        break;
                    case "Outside temperature":
                        Speak($"{gaugeValue} degrees");
                        braille($"temp {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;
                    case "ASL altitude":
                        Speak($"{gaugeValue} feet ASL.");
                        braille($"ASL  {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "AGL altitude":
                        Speak($"{gaugeValue} feet AGL.");
                        braille($"AGL {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "Airspeed true":
                        Speak($"{gaugeValue} knotts true");
                        braille($"TAS {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "Airspeed indicated":
                        Speak($"{gaugeValue} knotts indicated");
                        braille($"IAS {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "Ground speed":
                        Speak($"{gaugeValue} knotts ground speed");
                        braille($"{gaugeName}: {gaugeValue}\n");
                        history.AddItem($"gnd: {gaugeValue}\n");
                        break;

                    case "Mach":
                        Speak($"Mach {gaugeValue}. ");
                        braille($"mach{gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "Localiser":

                        if (useSAPI)
                        {
                            Speak($"{gaugeValue}. ", useSAPI: true);
                        }
                        else
                        {
                            Speak($"{gaugeValue}. ");
                        }
                        
                        braille($"loc {gaugeValue}\n");
                        break;

                    case "Glide slope":

                        if (useSAPI)
                        {
                            Speak($"{gaugeValue}", useSAPI: true);
                        }
                        else
                        {
                            Speak($"{gaugeValue}");
                        }
                        
                        braille($"gs {gaugeValue}\n");
                        break;

                    case "Altimeter":
                        Speak($"{gaugeName}: {gaugeValue}. ");
                        braille($"{gaugeName}: {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "Flaps":
                        Speak($"{gaugeName} {gaugeValue}. ");
                        braille($"{gaugeName} {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "Gear":
                        Speak($"{gaugeName} {gaugeValue}. ");
                        braille($"{gaugeName}: {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "AP heading":
                        if (PMDG737Detected || PMDG747Detected || PMDG777Detected)
                        {
                            Speak($"{gaugeValue}");
                            braille($"{gaugeValue}");
                            history.AddItem($"{gaugeValue}");
                        }
                        else
                        {
                            Speak($"heading {gaugeValue}. ");
                            braille($"hdg: {gaugeValue}\n");
                            history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        }
                                                break;

                    case "AP airspeed":
                        if (PMDG737Detected || PMDG747Detected || PMDG777Detected)
                        {
                            Speak(gaugeValue);
                            braille(gaugeValue);
                            history.AddItem(gaugeValue);
                        } // PMDG
                        else
                        {
                            Speak($"{gaugeValue} knotts. ");
                            braille($"{gaugeName}: {gaugeValue}\n");
                            history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        }
                        break;

                    case "AP mach":
                        if (PMDG737Detected || PMDG747Detected || PMDG777Detected)
                        {
                            Speak(gaugeValue);
                            braille(gaugeValue);
                            history.AddItem(gaugeValue);
                        } // PMDG
                        else
                        {

                            Speak($"Mach {gaugeValue}");
                            braille($"{gaugeName}: {gaugeValue}\n");
                            history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        }
                        break;

                    case "AP vertical speed":
                        Speak($"{gaugeValue} feet per minute. ");
                        braille($"{gaugeValue} FPM\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;
                    case "AP altitude":

                        if (PMDG737Detected || PMDG747Detected || PMDG777Detected)
                        {
                            Speak(gaugeValue);
                            braille(gaugeValue);
                            history.AddItem(gaugeValue);
                        } // PMDG
                        else
                        {
                            Speak($"{gaugeName}: {gaugeValue} feet. ");
                            braille($"{gaugeName}: {gaugeValue}\n");
                            history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        }
                        break;


                    case "Com1":
                        Speak($"{gaugeName}: {gaugeValue}. ");
                        braille($"{gaugeName}: {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "Com2":
                        Speak($"{gaugeName}: {gaugeValue}. ");
                        braille($"{gaugeName}: {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "Nav1":
                        Speak($"{gaugeName}: {gaugeValue}. ");
                        braille($"{gaugeName}: {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "Nav2":
                        Speak($"{gaugeName}: {gaugeValue}. ");
                        braille($"{gaugeName}: {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "Transponder":
                        Speak($"squawk {gaugeValue}. ");
                        braille($"Squawk: {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;





                    default:
                        Tolk.Output("Gage or instrument not supported.\n");
                        break;
                }
            } // End gage output.
            else
            {
                if (useSAPI == true)
                {
                    Speak(useSAPI: true, interruptSpeech: interruptSpeech, output: output);
                }
                else
                {
                    Speak(output, interruptSpeech: interruptSpeech);
                }
                if (textOutput == true)
                {
                    history.AddItem($"{output}\n");
                }

            } // end generic output
        } // end output method

        public async void Speak(string output, bool useSAPI = false, bool interruptSpeech = false)
        {
            if (Properties.Settings.Default.SpeechSystem == "SAPI" || useSAPI == true)
            {
                if (interruptSpeech == true) synth.SpeakAsyncCancelAll();
                synth.Rate = Properties.Settings.Default.SAPISpeechRate;
                synth.SpeakAsync(output);
                return;
            }
            if (Properties.Settings.Default.SpeechSystem == "ScreenReader")
            {
                Tolk.Speak(output, interruptSpeech);

            }
            /*if (Properties.Settings.Default.SpeechSystem == "Azure")
            {
                var voice = Properties.Settings.Default.AzureVoice;
                var ssml = $"<speak version='1.0' xml:lang='en-US' xmlns='http://www.w3.org/2001/10/synthesis' xmlns:mstts='http://www.w3.org/2001/mstts'><voice name='{voice}'>{output}</voice></speak>";
                using (SpeechSynthesisResult result = await azureSynth.SpeakSsmlAsync(ssml))
                {
                    if (result.Reason == ResultReason.Canceled)
                    {
                        var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                        logger.Debug($"Error getting speech from Azure: {cancellation.Reason}");
                        if (Properties.Settings.Default.FallbackSpeechSystem == "ScreenReader")
                        {
                            Tolk.Speak(output, interruptSpeech);
                        }
                        else
                        {
                            if (interruptSpeech == true) synth.SpeakAsyncCancelAll();
                            synth.Rate = Properties.Settings.Default.SAPISpeechRate;
                            synth.SpeakAsync(output);

                        }

                    }
                }



            }*/
        }
        private void braille(string output)
        {
            if (Properties.Settings.Default.OutputBraille)
            {
                Tolk.Braille(output);
            }
        } // Braille

        private void ReadSimulatorTime()
        {
            

            Speak($"{Aircraft.simulatorTimeHours.Value}:{Aircraft.simulatorTimeMinutes.Value}:{Aircraft.simulatorTimeSeconds.Value}");
        } // ReadSimulatorTime

        private void ReadSimulatorZuluTime()
        {

        } // ReadSimulatorZuluTime

        private void DisplayApplicationSettings()
        {
            /// TODO: IoSubsystem: Remove avionics tab from settings.
            /// TODO: IoSubSystem: Make displaying settings reusable code in the global scope.
            /// 
            frmSettings settings = new frmSettings();

            settings.ShowDialog();
            if (settings.DialogResult == DialogResult.OK)
            {
                Properties.Settings.Default.Save();
                Properties.pmdg737_offsets.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Reload();
                Properties.pmdg737_offsets.Default.Reload();

            }
        } // DisplayApplicationSettings.

        private void DisplayKeyboardManager()
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

        }

        private void DisplayA2AManager()
        {
            Output(isGauge: false, output: "A2A manager not yet supported.");
        } // DisplayA2AManager.

        private void DisplayAircraftProfiles()
        {
            Output(isGauge: false, output: "Aircraft profiles not yet supported.");
        } // AircraftProfiles

        public static  void DisplayWebsite()
        {
            System.Diagnostics.Process.Start("www.talkingflightmonitor.com");
        } // DisplayWebsite

        public static void ReportIssue()
        {
            System.Diagnostics.Process.Start("https://github.com/jfayre/talking-flight-monitor-net/issues");
        } // ReportIssue
    } // End IOSubsystem class
} // End TFM namespace.
