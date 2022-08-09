using tfm.PMDG;
using tfm.PMDG;
using tfm.PMDG.PanelObjects;
using FSUIPC;
using DavyKager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace tfm
{
    static class PMDG737Aircraft
    {

        private static tfm.PMDG.PMDG737.McpComponents.AltitudeBox altitudeBox = new PMDG.PMDG737.McpComponents.AltitudeBox();
        private static tfm.PMDG.PMDG737.McpComponents.SpeedBox speedBox = new PMDG.PMDG737.McpComponents.SpeedBox();
        private static tfm.PMDG.PMDG737.McpComponents.HeadingBox headingBox = new PMDG.PMDG737.McpComponents.HeadingBox();
        private static tfm.PMDG.PMDG737.McpComponents.VerticalSpeedBox verticalSpeedBox = new PMDG.PMDG737.McpComponents.VerticalSpeedBox();

        public static PMDG_NGX_CDU_Screen cdu0 = new PMDG_NGX_CDU_Screen(0x5400);
        public static PMDG_NGX_CDU_Screen cdu1 = new PMDG_NGX_CDU_Screen(0x5800);
        public static PMDG_NGX_CDU_Screen cdu2 = new PMDG_NGX_CDU_Screen(0x5C00);

        // constants for PMDG mouse click parameters
        public const int ClkL = 536870912;
        public const int ClkR = -2147483648;
        public const int DBLCLKL = 0x04000000;
        public const int Inc = 16384;
        public const int Dec = 8192;
        public static void CalculateSwitchPosition(PMDG_737_NGX_Control control, int pos, int sel, bool useClicks = false)
        {
            // there are several PMDG controls that cannot be set by direct parameter entry.
            // this function calculates the number of increment or decrement commands that need to be set in order to set a switch to a specific position.
            // We pass in a PMDG control number, an offset to read the current switch position, and the position we want the switch set to.
            if (pos > sel)
            {
                for (int i = 0; i < pos - sel; i++)
                {
                    if (useClicks)
                    {
                        FSUIPCConnection.SendControlToFS(control, ClkR);
                    }
                    else
                    {
                        FSUIPCConnection.SendControlToFS(control, Dec);
                    }
                }

            }
            if (pos < sel)
            {
                for (int i = 0; i < sel - pos; i++)
                {
                    if (useClicks)
                    {
                        FSUIPCConnection.SendControlToFS(control, ClkL);

                    }
                    else
                    {
                        FSUIPCConnection.SendControlToFS(control, Inc);
                    }
                }

            }

        }


        public static Dictionary<string, System.Windows.Forms.Form> MCPComponents
        {
            get =>
                new Dictionary<string, System.Windows.Forms.Form>
                {
                    {"altitude", altitudeBox },
                    {"speed", speedBox },
                    {"heading", headingBox },
                    {"vertical", verticalSpeedBox },
                };
        }

        /* State dictionaries -
 * The state dictionaries are designed
 * to make creating panel objects eaiser. Each dictionary
 * is a list of 'states' each panel control
 * will look for. The result is found in
 *the panel object's CurrentState property. Each list
 *below is named with the byte = 1 item first, then
 *the byte = 0 item last. Where more than two
 *values are present for a panel object state, it is named after the panel control. EX:
 *_backupPowerStates is used with the backup power switch. */

        private static Dictionary<byte, string> _onOrOffStates = new Dictionary<byte, string>()
        {
            {0, "off" },
            {1, "on" },
        };

        private static  Dictionary<uint, string> _onOrOffInt32States = new Dictionary<uint, string>()
        {
            {0, "off" },
            {1, "on" },
        };

        private static Dictionary<byte, string> _offOrOnStates = new Dictionary<byte, string>()
        {
            {0, "on" },
            {1, "off" },
        };
        private static Dictionary<byte, string> _autoOrOffStates = new Dictionary<byte, string>()
        {
            {0, "off" },
            {1, "auto" },
        };

        private static Dictionary<byte, string> _standbyPowerStates = new Dictionary<byte, string>()
        {
            { 0, "off" },
            {1, "auto" },
            {2, "battery" },
        };

        private static Dictionary<byte, string> _testOrOffStates = new Dictionary<byte, string>()
        {
            {0, "off" },
            {1, "test" },
        };
        private static Dictionary<byte, string> _batteryOrOffStates = new Dictionary<byte, string>()
        {
            {0, "off" },
            {1, "battery" },
        };

        private static Dictionary<byte, string> _cargoTempStates = new Dictionary<byte, string>()
        {
            {0, "off" },
            {1, "low" },
            {2, "high" },
        };

        private static Dictionary<byte, string> _apuStates = new Dictionary<byte, string>()
        {
            {0, "off" },
            {1, "on" },
            {2, "start" },
        };
        private static Dictionary<byte, string> _IRSDisplaySelectorStates = new Dictionary<byte, string>()
        {
                        {1, "TK/GS" },
            {2, "PPOS" },
            {3, "WIND" },
            {4, "HDG/STAT" },
        };
        private static Dictionary<byte, string> _IRSSysDisplayStates = new Dictionary<byte, string>()
        {
            { 0, "left" },
            {1, "right" },
        };

        private static Dictionary<byte, string> _momentaryControlState = new Dictionary<byte, string>()
        {
            {1, "pressed" },
        };

        private static Dictionary<byte, string> _connectOrDisconnectStates = new Dictionary<byte, string>()
        {
            {0, "disconnected" },
            {1, "connected" },
        };

        private static Dictionary<byte, string> _availableOrUnavailableStates = new Dictionary<byte, string>()
        {
            {0, "unavailable" },
            {1, "available" },
        };

        private static Dictionary<byte, string> _wiperStates = new Dictionary<byte, string>()
        {
            {0, "off" },
            {1, "intermittent" },
            {2, "low" },
            {3, "high" },
        };

        private static Dictionary<byte, string> _armedOnOrOffStates = new Dictionary<byte, string>()
        {
            {0, "off" },
            {1, "armed" },
            {2, "on" },
        };

        private static Dictionary<byte, string> _autoOnOrOffStates = new Dictionary<byte, string>()
        {
            {0, "off" },
            {1, "auto" },
            {2, "on" },
        };

        private static Dictionary<byte, string> _indoorLightTestStates = new Dictionary<byte, string>()
        {
            {0, "test" },
            {1, "bright" },
            {2, "dim" },
        };

        private static Dictionary<byte, string> _apuFireHandleStates = new Dictionary<byte, string>()
        {
            {0, "normal" },
            {1, "pulled" },
            {2, "turned left" }, // Momentary position.
            {3, "turned right" }, // Momentary position.
        };

        private static Dictionary<byte, string> _engineStartModeStates = new Dictionary<byte, string>()
        {
            {0, "start" },
            {1, "normal" },
        };

        private static Dictionary<byte, string> _fuelToRemainStates = new Dictionary<byte, string>()
        {
            {0, "pushed" },
            {1, "pulled" },
        };

        private static Dictionary<byte, string> _fuelSelectorStates = new Dictionary<byte, string>()
        {
            {0, "decrease" },
            {1, "neutral" },
            {2, "increase" },
        };

        private static Dictionary<byte, string> _neutralClosedOrOpenStates = new Dictionary<byte, string>()
        {
            {0, "opened" },
            {1, "neutral" },
            {2, "closed" },
        };

        private static Dictionary<byte, string> _neutralIncreaseOrDecrease = new Dictionary<byte, string>()
        {
            {0, "decrease" },
            {1, "neutral" },
            {2, "increase" },
        };
        private static Dictionary<byte, string> _irsModeSelect = new Dictionary<byte, string>()
        {
            {0, "off" },
            { 1, "align" },
            { 2, "nav" },
            { 3, "Att" }
        };
        private static Dictionary<byte, string> _domeLightStates = new Dictionary<byte, string>()
        {
            {0, "dim" },
            {1, "off" },
            {2, "bright" },
        };
        public static Dictionary<byte, string> _normalOrOnStates = new Dictionary<byte, string>()
        {
            {0, "on" },
            {1, "normal" },
        };
        private static Dictionary<byte, string> _downOrUpStates = new Dictionary<byte, string>()
{
    {0, "up" },
    {1, "down" },
};

        private static Dictionary<byte, string> _normalOrTestStates = new Dictionary<byte, string>()
        {
            {0, "test" },
            {1, "normal" },
        };

        private static Dictionary<byte, string> _flightControlStates = new Dictionary<byte, string>()
        {
            {0, "standby" },
            {1, "off" },
            {2, "on" },
        };

        private static Dictionary<byte, string> _armedOrOffStates = new Dictionary<byte, string>()
        {
            {0, "off" },
            {1, "armed" },
        };

        private static Dictionary<byte, string> _offUpOrDownStates = new Dictionary<byte, string>()
        {
            {0, "up" },
            {1, "off" },
            {2, "down" },
        };

        private static Dictionary<byte, string> _normal1Or2SelectorStates = new Dictionary<byte, string>()
        {
            {0, "both on 1" },
            {1, "normal" },
            {2, "both on 2" },
        };

        private static Dictionary<byte, string> _normalLeftOrRightSelectorStates = new Dictionary<byte, string>()
        {
            {0, "left" },
            {1, "normal" },
            {2, "right" }
        };

        private static Dictionary<byte, string> _auto1Or2SelectorStates = new Dictionary<byte, string>()
        {
            {0, "all on 1" },
            {1, "auto" },
            {2, "all on 2" },
        };

        private static Dictionary<byte, string> _fuelValveStates = new Dictionary<byte, string>()
        {
            {0, "closed" },
            {1, "opened" },
            {2, "in transit" },
        };

        private static Dictionary<byte, string> _dcMeterSelectorStates = new Dictionary<byte, string>()
        {
            {0, "standby" },
            {1, "Battery bus" },
            {2, "battery" },
            {3, "AUX battery" },
            {4, "TR 1" },
            {5, "TR 2" },
            {6, "TR 3" },
            {7, "test" },
                    };

        private static Dictionary<byte, string> _acMeterSelectorStates = new Dictionary<byte, string>()
        {
            {0, "standby" },
            {1, "ground power" },
            {2, "generator #1" },
            {3, "APU generator" },
            {4, "generator #2" },
            {5, "inverter" },
            {6, "test" },
                    };

        private static Dictionary<byte, string> _batterySelectorStates = new Dictionary<byte, string>()
        {
            {0, "off" },
            {1, "battery" },
            {2, "on" },
        };

        private static Dictionary<byte, string> _standbySelectorStates = new Dictionary<byte, string>()
        {
            {0, "battery" },
            {1, "off" },
            {2, "auto" },
        };

        private static Dictionary<byte, string> _openOrClosedStates = new Dictionary<byte, string>()
        {
            {0, "closed" },
            {1, "opened" },
        };

        private static Dictionary<byte, string> _airSourceSelectorStates = new Dictionary<byte, string>()
        {
            {0, "scant" },
            {1, "sfwd" },
            {2, "saft" },
            {3, "cfwd" },
            {4, "caft" },
            {5, "pckl" },
            {6, "pckr" },
        };

        private static Dictionary<byte, string> _packStates = new Dictionary<byte, string>()
        {
            {0, "off" },
            {1, "auto" },
            {2, "high" },
        };

        private static Dictionary<byte, string> _isolationValveStates = new Dictionary<byte, string>()
        {
            {0, "closed" },
            {1, "auto" },
            {2, "open" },
        };

        private static Dictionary<byte, string> _outflowValveStates = new Dictionary<byte, string>()
        {
            {0, "closed" },
            {1, "neutral" },
            {2, "open" },
        };

        private static Dictionary<byte, string> _pressurizationModeSelector = new Dictionary<byte, string>()
        {
            {0, "auto" },
            {1, "altn" },
            {2, "man" },
        };



        
        public static List<PanelObject> PanelControls
        {
            get => new List<PanelObject>()
            {
                // --panel: Aft OverheadPanel
                // --section: ADIRU
                                new SingleStateToggle { Name = "IRS Display Selector", PanelName = "Aft Overhead", PanelSection = "ADIRU", Offset = Aircraft.pmdg737.IRS_DisplaySelector, Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Medium, AvailableStates = _IRSDisplaySelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.IRS_DisplaySelector },
                new SingleStateToggle { Name = "IRS Display switch", PanelName = "Aft Overhead", PanelSection = "ADIRU", Offset = Aircraft.pmdg737.IRS_SysDisplay_R, Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Medium, AvailableStates = _IRSSysDisplayStates, shouldSpeak = Properties.pmdg737_offsets.Default.IRS_SysDisplay_r },
                new SingleStateToggle { Name = "IRS GPS light", PanelName = "Aft Overhead", PanelSection = "ADIRU", Offset = Aircraft.pmdg737.IRS_annunGPS, Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Medium, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.IRS_annunGPS },
                new SingleStateToggle { Name = "Left IRS light", PanelName = "Aft Overhead", PanelSection = "ADIRU", Offset = Aircraft.pmdg737.IRS_annunALIGN[0], Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Medium, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.IRS_annunALIGN_L },
                new SingleStateToggle { Name = "Right IRS light", PanelName = "Aft Overhead", PanelSection = "ADIRU", Offset = Aircraft.pmdg737.IRS_annunALIGN[1], Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Medium, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.IRS_annunALIGN_R },
                new SingleStateToggle { Name = "Left IRS DC light", PanelName = "Aft Overhead", PanelSection = "ADIRU", Type = PanelObjectType.Annunciator, Offset = Aircraft.pmdg737.IRS_annunON_DC[0], Verbosity = AircraftVerbosity.High, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.IRS_annunON_DC_L },
                new SingleStateToggle { Name = "Right IRS DC light", PanelName = "Aft Overhead", PanelSection = "ADIRU", Type = PanelObjectType.Annunciator, Offset = Aircraft.pmdg737.IRS_annunON_DC[1], Verbosity = AircraftVerbosity.High, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.IRS_annunON_DC_R },
                new SingleStateToggle { Name = "Left IRS fault light", PanelName = "Aft Overhead", PanelSection = "ADIRU", Type = PanelObjectType.Annunciator, Offset = Aircraft.pmdg737.IRS_annunFAULT[0], Verbosity = AircraftVerbosity.High, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.IRS_annunFAULT_L },
                new SingleStateToggle { Name = "Right IRS fault light", PanelName = "Aft Overhead", PanelSection = "ADIRU", Type = PanelObjectType.Annunciator, Offset = Aircraft.pmdg737.IRS_annunFAULT[1], Verbosity = AircraftVerbosity.High, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.IRS_annunFAULT_R },
                new SingleStateToggle { Name = "Left IRS DC failure light", PanelName = "Aft Overhead", PanelSection = "ADIRU", Type = PanelObjectType.Annunciator, Offset = Aircraft.pmdg737.IRS_annunDC_FAIL[0], Verbosity = AircraftVerbosity.High, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.IRS_annunDC_FAIL_L },
                new SingleStateToggle { Name = "Right IRS DC failure light", PanelName = "Aft Overhead", PanelSection = "ADIRU", Type = PanelObjectType.Annunciator, Offset = Aircraft.pmdg737.IRS_annunDC_FAIL[1], Verbosity = AircraftVerbosity.High, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.IRS_annunDC_FAIL_R },
                new SingleStateToggle { Name = "Left IRS mode selector", PanelName = "Aft Overhead", PanelSection = "ADIRU", Type = PanelObjectType.Switch, Offset = Aircraft.pmdg737.IRS_ModeSelector[0], Verbosity = AircraftVerbosity.Low, AvailableStates = _irsModeSelect, shouldSpeak = Properties.pmdg737_offsets.Default.IRS_ModeSelector_L },
                new SingleStateToggle { Name = "Right IRS mode selector", PanelName = "Aft Overhead", PanelSection = "ADIRU", Type = PanelObjectType.Switch, Offset = Aircraft.pmdg737.IRS_ModeSelector[1], Verbosity = AircraftVerbosity.Low, AvailableStates = _irsModeSelect, shouldSpeak = Properties.pmdg737_offsets.Default.IRS_ModeSelector_R },
                
                // --section: PSEU
                    new SingleStateToggle { Name = "PSEU warning light",  PanelName = "Aft Overhead", PanelSection = "PSEU", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Medium, AvailableStates = _onOrOffStates, Offset = Aircraft.pmdg737.WARN_annunPSEU, shouldSpeak = Properties.pmdg737_offsets.Default.WARN_annunPSEU },

                // --section: Service interphone
new SingleStateToggle {Name = "Service interphone", PanelName = "Aft Overhead", PanelSection = "Service interphone", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.COMM_ServiceInterphoneSw, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.COMM_ServiceInterphoneSw },

// --section: lights
new SingleStateToggle { Name = "Dome lights", PanelName = "Aft Overhead", PanelSection = "Lights", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.LTS_DomeWhiteSw, AvailableStates = _domeLightStates, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_DomeWhiteSw },

// --section: Engines
new SingleStateToggle { Name = "Engine #1 EEC", PanelName = "Aft Overhead", PanelSection = "Engines", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.ENG_EECSwitch[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ENG_EECSwitch_1 },
new SingleStateToggle { Name = "Engine #2 EEC", PanelName = "Aft Overhead", PanelSection = "Engines", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.ENG_EECSwitch[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ENG_EECSwitch_2 },
new SingleStateToggle { Name = "Engine #1 reverser light", PanelName = "Aft Overhead", PanelSection = "Engines", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.ENG_annunREVERSER[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ENG_annunREVERSER_1 },
new SingleStateToggle { Name = "Engine #2 reverser light", PanelName = "Aft Overhead", PanelSection = "Engines", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.ENG_annunREVERSER[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ENG_annunREVERSER_2 },
new SingleStateToggle { Name = "Engine #1 control light", PanelName = "Aft Overhead", PanelSection = "Engines", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.ENG_annunENGINE_CONTROL[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ENG_annunENGINE_CONTROL_1},
new SingleStateToggle { Name = "Engine #2 control light", PanelName = "Aft Overhead", PanelSection = "Engines", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.ENG_annunENGINE_CONTROL[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ENG_annunENGINE_CONTROL_2 },
new SingleStateToggle { Name = "Engine #1 alternate control light", PanelName = "Aft Overhead", PanelSection = "Engines", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.ENG_annunALTN[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ENG_annunALTN_1 },
new SingleStateToggle { Name = "Engine #2 alternate control light", PanelName = "Aft Overhead", PanelSection = "Engines", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.ENG_annunALTN[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ENG_annunALTN_2 },

// --section: Oxygen
new SingleStateToggle { Name = "Oxygen level", PanelName = "Aft Overhead", PanelSection = "Oxygen", Type = PanelObjectType.Slider, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.OXY_Needle, AvailableStates = null, shouldSpeak = Properties.pmdg737_offsets.Default.OXY_Needle },
new SingleStateToggle { Name = "Oxygen", PanelName = "Aft Overhead", PanelSection = "Oxygen", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.OXY_SwNormal, AvailableStates = _normalOrOnStates, shouldSpeak = Properties.pmdg737_offsets.Default.OXY_Needle},
new SingleStateToggle { Name = "Passenger oxygen light", PanelName = "Aft Overhead", PanelSection = "Oxygen", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.OXY_annunPASS_OXY_ON, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.OXY_annunPASS_OXY_ON },

// --section: Gear
new SingleStateToggle { Name = "Nose gear light", PanelName = "Aft Overhead", PanelSection = "Gear", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.GEAR_annunOvhdNOSE, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.GEAR_annunOvhdNOSE},
new SingleStateToggle { Name = "Left gear light", PanelName = "Aft Overhead", PanelSection = "Gear", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.GEAR_annunOvhdLEFT, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.GEAR_annunOvhdLEFT},
new SingleStateToggle { Name = "Right gear light", PanelName = "Aft Overhead", PanelSection = "Gear", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.GEAR_annunOvhdRIGHT, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.GEAR_annunOvhdRIGHT},

// --section: Flight recorder
new SingleStateToggle { Name = "Flight recorder", PanelName = "Aft Overhead", PanelSection = "Flight recorder", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FLTREC_SwNormal, AvailableStates = _normalOrTestStates, shouldSpeak = Properties.pmdg737_offsets.Default.FLTREC_SwNormal},
new SingleStateToggle { Name = "Flight recorder light", PanelName = "Aft Overhead", PanelSection = "Flight recorder", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FLTREC_annunOFF, AvailableStates = _offOrOnStates, shouldSpeak = Properties.pmdg737_offsets.Default.FLTREC_annunOFF },

// --panel: Forward Overhead
// --section: Flight controls
new SingleStateToggle { Name = "Flight control [A]", PanelName = "Forward Overhead", PanelSection = "Flight controls", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FCTL_FltControl_Sw[0], AvailableStates = _flightControlStates, shouldSpeak = Properties.pmdg737_offsets.Default.FCTL_FltControl_Sw_1},
                new SingleStateToggle { Name = "Flight control [B]", PanelName = "Forward Overhead", PanelSection = "Flight controls", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FCTL_FltControl_Sw[1], AvailableStates = _flightControlStates, shouldSpeak = Properties.pmdg737_offsets.Default.FCTL_FltControl_Sw_2},
new SingleStateToggle { Name = "Spoilers A", PanelName = "Forward Overhead", PanelSection = "Flight controls", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FCTL_Spoiler_Sw[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FCTL_Spoiler_Sw_1},
new SingleStateToggle { Name = "Spoilers B", PanelName = "Forward Overhead", PanelSection = "Flight controls", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FCTL_Spoiler_Sw[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FCTL_Spoiler_Sw_2},
new SingleStateToggle { Name = "Yaw damper", PanelName = "Forward Overhead", PanelSection = "Flight controls", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FCTL_YawDamper_Sw, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FCTL_YawDamper_Sw},
new SingleStateToggle { Name = "Alternate flaps [armed]", PanelName = "Forward Overhead", PanelSection = "Flight controls", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FCTL_AltnFlaps_Sw_ARM, AvailableStates = _armedOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FCTL_AltnFlaps_Sw_ARM},
new SingleStateToggle{Name = "Alternate flaps", PanelName = "Forward Overhead", PanelSection = "Flight controls", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FCTL_AltnFlaps_Control_Sw, AvailableStates = _offUpOrDownStates, shouldSpeak = Properties.pmdg737_offsets.Default.FCTL_AltnFlaps_Control_Sw},
new SingleStateToggle{Name = "Flight control [A] low pressure light", PanelName = "Forward Overhead", PanelSection = "Flight controls", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FCTL_annunFC_LOW_PRESSURE[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FCTL_annunFC_LOW_PRESSURE_1},
new SingleStateToggle{Name = "Flight control [B] low pressure light", PanelName = "Forward Overhead", PanelSection = "Flight controls", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FCTL_annunFC_LOW_PRESSURE[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FCTL_annunFC_LOW_PRESSURE_2 },
new SingleStateToggle{ Name = "Yaw damper light", PanelName = "Forward Overhead", PanelSection = "Flight controls", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FCTL_annunYAW_DAMPER, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FCTL_annunYAW_DAMPER},
new SingleStateToggle { Name = "Flight controls low quantity light", PanelName = "Forward Overhead", PanelSection = "Flight controls", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FCTL_annunLOW_QUANTITY, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FCTL_annunLOW_QUANTITY},
new SingleStateToggle { Name = "Flight controls low pressure light", PanelName = "Forward Overhead", PanelSection = "Flight controls", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FCTL_annunLOW_PRESSURE, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FCTL_annunLOW_PRESSURE},
new SingleStateToggle { Name = "Flight controls standby/rudder light", PanelName = "Forward Overhead", PanelSection = "Flight controls", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FCTL_annunLOW_STBY_RUD_ON, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FCTL_annunLOW_STBY_RUD_ON},
new SingleStateToggle { Name = "Feel diff pressure light", PanelName = "Forward Overhead", PanelSection = "Flight controls", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FCTL_annunFEEL_DIFF_PRESS, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FCTL_annunFEEL_DIFF_PRESS},
new SingleStateToggle { Name = "Speed trim failed light", PanelName = "Forward Overhead", PanelSection = "Flight controls", Type = PanelObjectType.Annunciator, Offset = Aircraft.pmdg737.FCTL_annunSPEED_TRIM_FAIL, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FCTL_annunSPEED_TRIM_FAIL},
new SingleStateToggle { Name = "Mach trim failed light", PanelName = "Forward Overhead", PanelSection = "Flight controls", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FCTL_annunMACH_TRIM_FAIL, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FCTL_annunMACH_TRIM_FAIL},
new SingleStateToggle { Name = "Auto slat failed light", PanelName = "Forward Overhead", PanelSection = "Flight controls", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FCTL_annunAUTO_SLAT_FAIL, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FCTL_annunAUTO_SLAT_FAIL},

// ---section: Navigation/Displays
new SingleStateToggle { Name = "VHF navigation selector", PanelName = "Forward Overhead", PanelSection = "Navigation/Displays", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.NAVDIS_VHFNavSelector, AvailableStates = _normal1Or2SelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.NAVDIS_VHFNavSelector},
new SingleStateToggle { Name = "IRS selector", PanelName = "Forward Overhead", PanelSection = "Navigation/Displays", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.High, Offset = Aircraft.pmdg737.NAVDIS_IRSSelector, AvailableStates = _normalLeftOrRightSelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.NAVDIS_IRSSelector},
new SingleStateToggle { Name = "FMC selector", PanelName = "Forward Overhead", PanelSection = "Navigation/Displays", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.High, Offset = Aircraft.pmdg737.NAVDIS_FMCSelector, AvailableStates = _normalLeftOrRightSelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.NAVDIS_FMCSelector},
new SingleStateToggle { Name = "Source selector", PanelName = "Forward Overhead", PanelSection = "Navigation/Displays", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.High, Offset = Aircraft.pmdg737.NAVDIS_SourceSelector, AvailableStates = _auto1Or2SelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.NAVDIS_SourceSelector },
new SingleStateToggle {Name = "Control pane selector", PanelName = "Forward Overhead", PanelSection = "Navigation/Displays", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.High, Offset = Aircraft.pmdg737.NAVDIS_ControlPaneSelector, AvailableStates = _normal1Or2SelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.NAVDIS_ControlPaneSelector},

// ---section: fuel
new SingleStateToggle { Name = "Fuel temprature", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_FuelTempNeedle, AvailableStates = null, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_FuelTempNeedle},
new SingleStateToggle { Name = "Crossfeed", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_CrossFeedSw, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_CrossFeedSw},
new SingleStateToggle { Name = "Left FWD fuel pump ", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_PumpFwdSw[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_PumpFwdSw_L},
new SingleStateToggle { Name = "Right FWD fuel pump", PanelName = "Forward Overhead", PanelSection = "Fuel", Type= PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_PumpFwdSw[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_PumpFwdSw_R},
new SingleStateToggle { Name = "Left AFT fuel pump", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_PumpAftSw[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_PumpAftSw_L},
new SingleStateToggle { Name = "Right AFT fuel pump", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_PumpAftSw[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_PumpAftSw_R},
new SingleStateToggle { Name = "Left center fuel pump", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_PumpCtrSw[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_PumpCtrSw_L},
new SingleStateToggle { Name = "Right center fuel pump", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_PumpCtrSw[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_PumpCtrSw_R},
new SingleStateToggle { Name = "AFT A: aux fuel", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_AuxAft[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_AuxAft_A},
new SingleStateToggle { Name = "AFT B: aux fuel", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_AuxAft[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_AuxAft_B},
new SingleStateToggle { Name = "FWD A: aux fuel", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_AuxFwd[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_AuxFwd_A},
new SingleStateToggle { Name = "FWD B: aux fuel", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_AuxFwd[1], AvailableStates = _onOrOffStates},
new SingleStateToggle { Name = "FWD fuel bleed", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_FWDBleed, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_FWDBleed},
new SingleStateToggle { Name = "AFT fuel bleed", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_AFTBleed, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_AFTBleed},
new SingleStateToggle { Name = "Ground fuel transfer", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_GNDXfr, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_GNDXfr},
new SingleStateToggle { Name = "Engine #1 fuel valve light", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_annunENG_VALVE_CLOSED[0], AvailableStates = _fuelValveStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_annunENG_VALVE_CLOSED_1},
new SingleStateToggle { Name = "Engine #2 fuel valve light", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_annunENG_VALVE_CLOSED[1], AvailableStates = _fuelValveStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_annunENG_VALVE_CLOSED_2},
new SingleStateToggle { Name = "Engine #1 spar valve light", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_annunSPAR_VALVE_CLOSED[0], AvailableStates = _fuelValveStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_annunSPAR_VALVE_CLOSED_1},
new SingleStateToggle { Name = "Engine #2 spar valve light", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_annunSPAR_VALVE_CLOSED[1], AvailableStates = _fuelValveStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_annunSPAR_VALVE_CLOSED_2},
new SingleStateToggle { Name = "Engine #1 fuel filter bypass light", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_annunFILTER_BYPASS[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_annunFILTER_BYPASS_1},
new SingleStateToggle { Name = "Engine #2 fuel filter bypass light", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_annunFILTER_BYPASS[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_annunFILTER_BYPASS_2},
new SingleStateToggle { Name = "Crossfeed valve light", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_annunXFEED_VALVE_OPEN, AvailableStates = _fuelValveStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_annunXFEED_VALVE_OPEN},
new SingleStateToggle { Name = "Engine #1 AFT low pressure light", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_annunLOWPRESS_Aft[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Aft_1},
new SingleStateToggle { Name = "Engine #2 AFT low pressure light", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_annunLOWPRESS_Aft[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Aft_2},
new SingleStateToggle { Name = "Engine #1 FWD low pressure light", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_annunLOWPRESS_Fwd[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Fwd_1},
new SingleStateToggle { Name = "Engine #2 FWD low pressure light", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_annunLOWPRESS_Fwd[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Fwd_2},
new SingleStateToggle { Name = "Engine #1 center low pressure light", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_annunLOWPRESS_Ctr[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Ctr_1},
new SingleStateToggle { Name = "Engine #2 center low pressure light", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_annunLOWPRESS_Ctr[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Ctr_2},

// --section: Electrical
new SingleStateToggle { Name = "Battery discharge light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunBAT_DISCHARGE, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunBAT_DISCHARGE},
new SingleStateToggle { Name = "TR unit light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunTR_UNIT, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunTR_UNIT},
new SingleStateToggle{ Name = "Elec light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunELEC, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunELEC},
new SingleStateToggle{ Name = "DC meter selector", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_DCMeterSelector, AvailableStates = _dcMeterSelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_DCMeterSelector},
new SingleStateToggle { Name = "AC meter selector", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_ACMeterSelector, AvailableStates = _acMeterSelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_ACMeterSelector},
new SingleStateToggle { Name = "Battery", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_BatSelector, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_BatSelector},
new SingleStateToggle { Name = "Cabin utility", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_CabUtilSw, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_CabUtilSw},
new SingleStateToggle { Name = "Passenger seats", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_IFEPassSeatSw, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_IFEPassSeatSw},
new SingleStateToggle { Name = "Drive #1 light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunDRIVE[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunDRIVE_1},
new SingleStateToggle { Name = "Drive #2 light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunDRIVE[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunDRIVE_2},
new SingleStateToggle { Name = "Standby power light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunSTANDBY_POWER_OFF, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunSTANDBY_POWER_OFF},
new SingleStateToggle { Name = "IDG #1 disconnect", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_IDGDisconnectSw[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_IDGDisconnectSw_1},
new SingleStateToggle { Name = "IDG #2 disconnect", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_IDGDisconnectSw[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_IDGDisconnectSw_2},
new SingleStateToggle { Name = "Standby power selector", PanelName = "Forward Overhead", PanelSection = "Electrical",  Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_StandbyPowerSelector, AvailableStates = _standbySelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_StandbyPowerSelector},
new SingleStateToggle { Name = "Ground power light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type= PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunGRD_POWER_AVAILABLE, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunGRD_POWER_AVAILABLE},
new SingleStateToggle { Name = "Ground power", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_GrdPwrSw, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_GrdPwrSw},
new SingleStateToggle { Name = "Bus transfer", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_BusTransSw_AUTO, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_BusTransSw_AUTO},
new SingleStateToggle { Name = "Generator #1", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_GenSw[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_GenSw_1},
new SingleStateToggle { Name = "Generator #2", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_GenSw[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_GenSw_2},
new SingleStateToggle { Name = "APU generator #1", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_APUGenSw[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_APUGenSw_1},
new SingleStateToggle { Name = "APU generator #2", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_APUGenSw[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_APUGenSw_2},
new SingleStateToggle { Name = "Transfer bus #1 light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunTRANSFER_BUS_OFF[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunTRANSFER_BUS_OFF_1},
new SingleStateToggle { Name = "Transfer bus #2 light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunTRANSFER_BUS_OFF[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunTRANSFER_BUS_OFF_2},
new SingleStateToggle { Name = "Generator #1 light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunSOURCE_OFF[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunSOURCE_OFF_1},
new SingleStateToggle { Name = "Generator #2 light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunSOURCE_OFF[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunSOURCE_OFF_2},
new SingleStateToggle { Name = "Generator #1 bus light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunGEN_BUS_OFF[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunGEN_BUS_OFF_1},
new SingleStateToggle { Name = "Generator #2 bus light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunGEN_BUS_OFF[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunGEN_BUS_OFF_2},
new SingleStateToggle { Name = "APU generator bus light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunAPU_GEN_OFF_BUS, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunAPU_GEN_OFF_BUS},

// --section: APU
new SingleStateToggle { Name = "APU EGT needle", PanelName = "Forward Overhead", PanelSection = "APU", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.APU_EGTNeedle, AvailableStates = null, shouldSpeak = Properties.pmdg737_offsets.Default.APU_EGTNeedle},
new SingleStateToggle { Name = "APU maint light", PanelName = "Forward Overhead", PanelSection = "APU", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.APU_annunMAINT, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.APU_annunMAINT},
new SingleStateToggle { Name = "APU low oil pressure light", PanelName = "Forward Overhead", PanelSection = "APU", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.APU_annunLOW_OIL_PRESSURE, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.APU_annunLOW_OIL_PRESSURE},
new SingleStateToggle { Name = "APU fault light", PanelName = "Forward Overhead", PanelSection = "APU", Type= PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.APU_annunFAULT, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.APU_annunFAULT},
new SingleStateToggle { Name = "APU overspeed light", PanelName = "Forward Overhead", PanelSection = "APU", Type = PanelObjectType.Annunciator, Verbosity= AircraftVerbosity.Low, Offset = Aircraft.pmdg737.APU_annunOVERSPEED, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.APU_annunOVERSPEED},

// --section: Wipers
new SingleStateToggle { Name = "Left wipers", PanelName = "Forward Overhead", PanelSection = "Wipers", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.OH_WiperLSelector, AvailableStates = _wiperStates, shouldSpeak = Properties.pmdg737_offsets.Default.OH_WiperLSelector},
new SingleStateToggle { Name = "Right wipers", PanelName = "Forward Overhead", PanelSection = "Wipers", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.OH_WiperRSelector, AvailableStates = _wiperStates, shouldSpeak = Properties.pmdg737_offsets.Default.OH_WiperRSelector},

// --panel: Center Overhead
// -- section: Main

new SingleStateToggle { Name = "Circutt breaker knob", PanelName = "Center Overhead", PanelSection = "Main", Type = PanelObjectType.Dial, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_CircuitBreakerKnob, AvailableStates = null, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_CircuitBreakerKnob},
new SingleStateToggle { Name = "Overhead panel knob", PanelName = "Center Overhead", PanelSection = "Main", Type = PanelObjectType.Dial, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_OvereadPanelKnob, AvailableStates = null, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_OvereadPanelKnob },
new SingleStateToggle { Name = "Emergency exit lights", PanelName = "Center Overhead", PanelSection = "Main", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.High, Offset = Aircraft.pmdg737.LTS_EmerExitSelector, AvailableStates = _armedOnOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_EmerExitSelector},
new SingleStateToggle { Name = "Equipment cooling supply", PanelName = "Center Overhead", PanelSection = "Main", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.High, Offset = Aircraft.pmdg737.AIR_EquipCoolingSupplyNORM, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_EquipCoolingSupplyNORM},
new SingleStateToggle { Name = "Equipment cooling exhaust", PanelName = "Center Overhead", PanelSection = "Main", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.High, Offset = Aircraft.pmdg737.AIR_EquipCoolingExhaustNORM, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_EquipCoolingExhaustNORM},
new SingleStateToggle { Name = "Chimes", PanelName = "Center Overhead", PanelSection = "Main", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.High, Offset = Aircraft.pmdg737.COMM_NoSmokingSelector, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.COMM_NoSmokingSelector},
new SingleStateToggle { Name = "Seatbelt selector", PanelName = "Center Overhead", PanelSection = "Main", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.High, Offset = Aircraft.pmdg737.COMM_FastenBeltsSelector, AvailableStates = _autoOnOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.COMM_FastenBeltsSelector},
new SingleStateToggle { Name = "Emergency exit N/armed light", PanelName = "Center Overhead", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.High, Offset = Aircraft.pmdg737.LTS_annunEmerNOT_ARMED, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_annunEmerNOT_ARMED},
new SingleStateToggle { Name = "Equipment cooling supply light", PanelName = "Center Overhead", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_annunEquipCoolingSupplyOFF, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_annunEquipCoolingSupplyOFF},
new SingleStateToggle { Name = "Equipment cooling exhaust light", PanelName = "Center Overhead", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.High, Offset = Aircraft.pmdg737.AIR_annunEquipCoolingExhaustOFF, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_annunEquipCoolingExhaustOFF},
new SingleStateToggle { Name = "Call light", PanelName = "Center Overhead", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.High, Offset = Aircraft.pmdg737.COMM_annunCALL, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.COMM_annunCALL},
new SingleStateToggle { Name = "PA in use light", PanelName = "Center Overhead", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.High, Offset = Aircraft.pmdg737.COMM_annunPA_IN_USE, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.COMM_annunPA_IN_USE},

// Anti-ice
new SingleStateToggle { Name = "Left side window heat", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ICE_WindowHeatSw[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_WindowHeatSw1},
new SingleStateToggle { Name = "Left forward window heat", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ICE_WindowHeatSw[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_WindowHeatSw2},
new SingleStateToggle { Name = "Right forward window heat", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ICE_WindowHeatSw[2], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_WindowHeatSw3},
new SingleStateToggle { Name = "Right side window heat", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ICE_WindowHeatSw[3], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_WindowHeatSw4},
new SingleStateToggle { Name = "Wing anti-ice", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ICE_WingAntiIceSw, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_WingAntiIceSw},
new SingleStateToggle { Name = "Engine #1 anti-ice", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ICE_EngAntiIceSw[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_EngAntiIceSw1},
new SingleStateToggle { Name = "Engine #2 anti-ice", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ICE_EngAntiIceSw[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_EngAntiIceSw2},
new SingleStateToggle { Name = "Left side window overheat light", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ICE_annunOVERHEAT[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_annunOVERHEAT1},
new SingleStateToggle { Name = "Left forwardwindow overheat light", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ICE_annunOVERHEAT[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_annunOVERHEAT2},
new SingleStateToggle { Name = "Right forward window overheat light", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ICE_annunOVERHEAT[2], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_annunOVERHEAT3},
new SingleStateToggle { Name = "Right side window overheat light", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ICE_annunOVERHEAT[3], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_annunOVERHEAT4},
new SingleStateToggle { Name = "Left side window heat light", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.ICE_annunON[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_annunON1},
new SingleStateToggle { Name = "Left forward window heat light", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.ICE_annunON[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_annunON2},
new SingleStateToggle { Name = "Right forward window heat light", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.ICE_annunON[2], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_annunON3},
new SingleStateToggle { Name = "Right side window heat light", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.ICE_annunON[3], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_annunON4},
new SingleStateToggle { Name = "Captain's pitot heat light", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.High, Offset = Aircraft.pmdg737.ICE_annunCAPT_PITOT, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_annunCAPT_PITOT},
new SingleStateToggle { Name = "Left elevator pitot heat light", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.High, Offset = Aircraft.pmdg737.ICE_annunL_ELEV_PITOT, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_annunL_ELEV_PITOT},
new SingleStateToggle { Name = "Left alpha vane light", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.High, Offset = Aircraft.pmdg737.ICE_annunL_ALPHA_VANE, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_annunL_ALPHA_VANE},
new SingleStateToggle { Name = "Left temp probe light", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Annunciator, Verbosity= AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ICE_annunL_TEMP_PROBE, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_annunL_TEMP_PROBE},
new SingleStateToggle { Name = "F/O pito heat light", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ICE_annunFO_PITOT, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_annunFO_PITOT},
new SingleStateToggle { Name = "Right elevator pitot heat light", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ICE_annunR_ELEV_PITOT, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_annunR_ELEV_PITOT},
new SingleStateToggle { Name = "Right alpha vane light", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ICE_annunR_ALPHA_VANE, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_annunR_ALPHA_VANE},
new SingleStateToggle { Name = "Aux pitot heat light", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ICE_annunAUX_PITOT, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_annunAUX_PITOT},
new SingleStateToggle { Name = "Left anti-ice valve", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ICE_annunVALVE_OPEN[0], AvailableStates = _openOrClosedStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_annunVALVE_OPEN1},
new SingleStateToggle { Name = "Right anti-ice valve", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ICE_annunVALVE_OPEN[1], AvailableStates = _openOrClosedStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_annunVALVE_OPEN2},
new SingleStateToggle { Name = "Left cowl anti-ice light", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ICE_annunCOWL_ANTI_ICE[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_annunCOWL_ANTI_ICE1},
new SingleStateToggle { Name = "Right cowl anti-ice light", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ICE_annunCOWL_ANTI_ICE[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_annunCOWL_ANTI_ICE2},
new SingleStateToggle { Name = "Left cowl valve", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ICE_annunCOWL_VALVE_OPEN[0], AvailableStates = _openOrClosedStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_annunCOWL_VALVE_OPEN1},
new SingleStateToggle { Name = "Right cowl valve", PanelName = "Center Overhead", PanelSection = "Anti-ice", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ICE_annunCOWL_VALVE_OPEN[1], AvailableStates = _openOrClosedStates, shouldSpeak = Properties.pmdg737_offsets.Default.ICE_annunCOWL_VALVE_OPEN2},

// --section: Hydraulics
new SingleStateToggle { Name = "Electric Hydraulic pump #1", PanelName = "Center Overhead", PanelSection = "Hydraulics", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.HYD_PumpSw_elec[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.HYD_PumpSw_elec1},
new SingleStateToggle { Name = "Electric Hydraulic pump #2", PanelName = "Center Overhead", PanelSection = "Hydraulics", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.HYD_PumpSw_elec[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.HYD_PumpSw_elec2},
new SingleStateToggle { Name = "Engine #1 Hydraulic pump", PanelName = "Center Overhead", PanelSection = "Hydraulics", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.HYD_PumpSw_eng[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.HYD_PumpSw_eng1},
new SingleStateToggle { Name = "Engine #2 Hydraulic pump", PanelName = "Center Overhead", PanelSection = "Hydraulics", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.HYD_PumpSw_eng[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.HYD_PumpSw_eng2},
new SingleStateToggle { Name = "Engine #1 hydraulic pump low pressure light", PanelName = "Center Overhead", PanelSection = "Hydraulics", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.HYD_annunLOW_PRESS_eng[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.HYD_annunLOW_PRESS_eng1},
new SingleStateToggle { Name = "Engine #2 hydraulic pump low pressure light", PanelName = "Center Overhead", PanelSection = "Hydraulics", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.HYD_annunLOW_PRESS_eng[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.HYD_annunLOW_PRESS_eng2},
new SingleStateToggle { Name = "Electric hydraulic pump #1 low pressure light", PanelName = "Center Overhead", PanelSection = "Hydraulics", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.HYD_annunLOW_PRESS_elec[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.HYD_annunLOW_PRESS_elec1},
new SingleStateToggle { Name = "Electric hydraulic pump #2 low pressure light", PanelName = "Center Overhead", PanelSection = "Hydraulics", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.HYD_annunLOW_PRESS_elec[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.HYD_annunLOW_PRESS_elec2},
new SingleStateToggle { Name = "Electric hydraulic pump #1 overheat light", PanelName = "Center Overhead", PanelSection = "Hydraulics", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.HYD_annunOVERHEAT_elec[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.HYD_annunOVERHEAT_elec1},
new SingleStateToggle { Name = "Electric hydraulic pump #2 overheat light", PanelName = "Center Overhead", PanelSection = "Hydraulics", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.HYD_annunOVERHEAT_elec[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.HYD_annunOVERHEAT_elec2},
// --section: Air systems
new SingleStateToggle { Name = "Air source", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_TempSourceSelector, AvailableStates = _airSourceSelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_TempSourceSelector },
new SingleStateToggle { Name = "Air trim", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_TrimAirSwitch, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_TrimAirSwitch },
new SingleStateToggle { Name = "Flight deck temprature light", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_annunZoneTemp[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_annunZoneTemp1},
new SingleStateToggle { Name = "Forward cabin temprature light", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_annunZoneTemp[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_annunZoneTemp2},
new SingleStateToggle { Name = "AFT cabin temprature light", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_annunZoneTemp[2], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_annunZoneTemp3},
new SingleStateToggle { Name = "Dual bleed light", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.High, Offset = Aircraft.pmdg737.AIR_annunDualBleed, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_annunDualBleed},
new SingleStateToggle { Name = "Left ram door light", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_annunRamDoorL, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_annunRamDoorL},
new SingleStateToggle { Name = "Right ram door light", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_annunRamDoorR, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_annunRamDoorR},
new SingleStateToggle { Name = "Left recirc fan", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_RecircFanSwitch[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_RecircFanSwitch1},
new SingleStateToggle { Name = "Right recirc fan", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_RecircFanSwitch[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_RecircFanSwitch2},
new SingleStateToggle { Name = "Left pack", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_PackSwitch[0], AvailableStates = _packStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_PackSwitch1},
new SingleStateToggle { Name = "Right pack", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_PackSwitch[1], AvailableStates = _packStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_PackSwitch2},
new SingleStateToggle { Name = "Left air bleed", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_BleedAirSwitch[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_BleedAirSwitch1},
new SingleStateToggle { Name = "Right air bleed", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_BleedAirSwitch[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_BleedAirSwitch2},
new SingleStateToggle { Name = "APU bleed", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_APUBleedAirSwitch, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_APUBleedAirSwitch},
new SingleStateToggle { Name = "Isolation valve", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_IsolationValveSwitch, AvailableStates = _isolationValveStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_IsolationValveSwitch},
new SingleStateToggle { Name = "Left pack trip light", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_annunPackTripOff[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_annunPackTripOff1},
new SingleStateToggle { Name = "Right pack trip light", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_annunPackTripOff[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_annunPackTripOff2},
new SingleStateToggle { Name = "Left wing overheat light", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_annunWingBodyOverheat[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_annunWingBodyOverheat1},
new SingleStateToggle { Name = "Right wing overheat light", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_annunWingBodyOverheat[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_annunWingBodyOverheat2},
new SingleStateToggle { Name = "Left bleed trip light", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_annunBleedTripOff[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_annunBleedTripOff1},
new SingleStateToggle { Name = "Right bleed trip light", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_annunBleedTripOff[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_annunBleedTripOff2},
new SingleStateToggle { Name = "Flight altitude", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Dial, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_DisplayFltAlt, AvailableStates = null, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_DisplayFltAlt},
new SingleStateToggle { Name = "Landing altitude", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.NumericDisplay, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_DisplayLandAlt, AvailableStates = null, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_DisplayLandAlt},
new SingleStateToggle { Name = "Outflow valve", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_OutflowValveSwitch, AvailableStates = _outflowValveStates, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_OutflowValveSwitch},
new SingleStateToggle { Name = "Pressurization mode selector", PanelName = "Center Overhead", PanelSection = "Air Systems", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.AIR_PressurizationModeSelector, AvailableStates = _pressurizationModeSelector, shouldSpeak = Properties.pmdg737_offsets.Default.AIR_PressurizationModeSelector},

// ---Panel: Bottom Overhead

                            // --end-panel-controls                              
            };
        }
        public static AircraftSystem SpeedMode
        {
            get => Aircraft.pmdg737.MCP_IASBlank.Value == 1 ? AircraftSystem.FMC : AircraftSystem.MCP;
        } // SpeedMode

        public static AircraftSpeed SpeedType
        {
            get => Aircraft.pmdg737.MCP_IASMach.Value < 10 ? AircraftSpeed.Mach : AircraftSpeed.Indicated;
        } // SpeedType

        public static double MachSpeed
        {
            get
            {
                double speed = 0;
                if (Aircraft.pmdg737.MCP_IASMach.Value < 10)
                {
                    speed = Math.Round((Aircraft.pmdg737.MCP_IASMach.Value % 1), 2);
                }
                return speed;
            }
        } // MachSpeed

        public static double IndicatedAirSpeed
        {
            get
            {
                double speed = 0;
                if (Aircraft.pmdg737.MCP_IASMach.Value >= 10)
                {
                    speed = Aircraft.pmdg737.MCP_IASMach.Value;
                }
                return speed;
            }
        } // IndicatedAirSpeed

        public static TimeSpan TimeToDestination
        {
            get
            {
                double groundSpeed = ((double)Aircraft.GroundSpeed.Value * 3600d) / (65536d * 1852d);
                groundSpeed = Math.Round(groundSpeed);
                double time = Aircraft.pmdg737.FMC_DistanceToDest.Value / groundSpeed;
                return TimeSpan.FromHours(time);
            }
        } // End TimeToDestination.

        public static TimeSpan TimeToTOD
        {
            get
            {
                double groundSpeed = ((double)Aircraft.GroundSpeed.Value * 3600d) / (65536d * 1852d);
                groundSpeed = Math.Round(groundSpeed);
                double time = Aircraft.pmdg737.FMC_DistanceToTOD.Value / groundSpeed;
                return TimeSpan.FromHours(time);
            }
        } // End TimeToTOD.

        public static double CurrentElevatorTrim
        {
            get => Math.Round(FSUIPCConnection.ReadLVar("ElevTrimTT"), 2);
        } // CurentElevatorTrim

        public static double CurrentFlapsPosition
        {
            get
            {
                return Math.Round(Aircraft.pmdg737.MAIN_TEFlapsNeedle[0].Value);
            }
        } // End CurrentFlapsPosition.

        public static void AltitudeIntervene()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_ALT_INTV_SWITCH, Aircraft.ClkL);
        } // AltitudeIntervene.

        public static void ToggleAltitudeHold()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_ALT_HOLD_SWITCH, Aircraft.ClkL);
        } // ToggleAltitudeHold.

        public static void ToggleVNav()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_VNAV_SWITCH, Aircraft.ClkL);
        } // ToggleVNav

        public static void ToggleLevelChange()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_LVL_CHG_SWITCH, Aircraft.ClkL);
        } // ToggleLevelChange.

        public static void SetAltitude(string altitudeText)
        {
            ushort.TryParse(altitudeText, out ushort altitude);
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_ALT_SET, altitude);
        } // SetAltitude

        public static void ShowAltitudeBox()
        {
            MCPComponents["altitude"].Show();
        } // ShowAltitudeBox.

        public static void ToggleHeadingSelect()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_HDG_SEL_SWITCH, Aircraft.ClkL);
        } //HeadingSelect

        public static void ToggleLNav()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_LNAV_SWITCH, Aircraft.ClkL);
        } // ToggleLNav()

        public static void SetHeading(string headingText)
        {
            short.TryParse(headingText, out short heading);
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_HDG_SET, heading);
        } // SetHeading

        public static void ShowHeadingBox()
        {
            MCPComponents["heading"].Show();
        } // ShowHeadingBox.

        public static void VerticalSpeedIntervene()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_VS_SWITCH, Aircraft.ClkL);
        } // VerticalSpeedIntervene

        public static void SetVerticalSpeed(string verticalSpeedText)
        {
            ushort.TryParse(verticalSpeedText, out ushort verticalSpeed);
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_VS_SET, verticalSpeed);
        } // SetVerticalSpeed

        public static void ShowVerticalSpeedBox()
        {
            MCPComponents["vertical"].Show();
        } // ShowVerticalSpeedBox

        public static void SpeedIntervene()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_SPD_INTV_SWITCH, Aircraft.ClkL);
        } // SpeedIntervene

        public static void ShowSpeedBox()
        {
            MCPComponents["speed"].Show();
        } // ShowSpeedBox

        public static string GetMCPHeadingComponents()
        {
            string navigationAid = string.Empty;
            if (Aircraft.pmdg737.MCP_annunHDG_SEL.Value == 1 && Aircraft.pmdg737.MCP_annunLNAV.Value == 1)
            {
                navigationAid = "Combined";
            }

            else if (Aircraft.pmdg737.MCP_annunHDG_SEL.Value == 1)
            {
                navigationAid = "HDG SEL";
            }// HDG SEL
            else if (Aircraft.pmdg737.MCP_annunLNAV.Value == 1)
            {
                navigationAid = "LNav";
            }
            return $"MCP heading {Aircraft.pmdg737.MCP_Heading.Value} {navigationAid}";
        } // GetMCPHeadingComponents

        public static string GetMCPAltitudeComponents()
        {
            string navigationAid = string.Empty;
            if (Aircraft.pmdg737.MCP_annunALT_HOLD.Value == 1)
            {
                navigationAid = "hold";
            }
            else if (Aircraft.pmdg737.MCP_annunLVL_CHG.Value == 1)
            {
                navigationAid = "level change";
            }
            else if (Aircraft.pmdg737.MCP_annunVNAV.Value == 1)
            {
                navigationAid = "VNav";
            }
            return $"MCP altitude {Aircraft.pmdg737.MCP_Altitude.Value} feet {navigationAid}";
        } // GetMCPAltitudeComponents

        public static string GetMCPSpeedComponents()
        {
            string navigationAID = string.Empty;
            string controllingComponent = string.Empty;
            string FDUoutput = string.Empty;
            double speed = 0.0;

            if (SpeedMode == AircraftSystem.FMC)
            {
                FDUoutput = "FMC speed";
            }
            else if (SpeedMode == AircraftSystem.MCP)
            {
                controllingComponent = "MCP";
                if (SpeedType == AircraftSpeed.Indicated)
                {
                    speed = IndicatedAirSpeed;
                }
                else if (SpeedType == AircraftSpeed.Mach)
                {
                    speed = MachSpeed;
                }

                if (Aircraft.pmdg737.MCP_annunSPEED.Value == 1)
                {
                    navigationAID = "HOLD";
                }

                FDUoutput = $"{controllingComponent} speed {speed} {navigationAID}";
            }
            return FDUoutput;

        } // GetMCPSpeedComponents

        // IRU Left
        public static void IRULeftOff()
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_IRU_MSU_LEFT, Aircraft.pmdg737.IRS_ModeSelector[0].Value, 0);
        }
        public static void IRULeftAlign()
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_IRU_MSU_LEFT, Aircraft.pmdg737.IRS_ModeSelector[0].Value, 1);
        }
        public static void IRULeftNav()
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_IRU_MSU_LEFT, Aircraft.pmdg737.IRS_ModeSelector[0].Value, 2);
        }

        public static void IRULeftAtt()
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_IRU_MSU_LEFT, Aircraft.pmdg737.IRS_ModeSelector[0].Value, 3);
        }

        public static void IRURightOff()
        {

            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_IRU_MSU_RIGHT, Aircraft.pmdg737.IRS_ModeSelector[1].Value, 0);
        }
        public static void IRURightAlign()
        {
            // IRURightCalc(1);
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_IRU_MSU_RIGHT, Aircraft.pmdg737.IRS_ModeSelector[1].Value, 1);
        }
        public static void IRURightNav()
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_IRU_MSU_RIGHT, Aircraft.pmdg737.IRS_ModeSelector[1].Value, 2);
        }
        public static void IRURightAtt()
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_IRU_MSU_RIGHT, Aircraft.pmdg737.IRS_ModeSelector[1].Value, 3);
        }

        // IRS display selector
        public static void IRSDisplayTrackGS()
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_ISDU_DSPL_SEL, Aircraft.pmdg737.IRS_DisplaySelector.Value, 1);
        }
        public static void IRSDisplayPPOS()
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_ISDU_DSPL_SEL, Aircraft.pmdg737.IRS_DisplaySelector.Value, 2);
        }
        public static void IRSDisplayWind()
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_ISDU_DSPL_SEL, Aircraft.pmdg737.IRS_DisplaySelector.Value, 3);
        }
        public static void IRSDisplayHdgStat()
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_ISDU_DSPL_SEL, Aircraft.pmdg737.IRS_DisplaySelector.Value, 4);
        }

        public static void ServiceInterPhoneOn()
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_SERVICE_INTERPHONE_SWITCH, Aircraft.pmdg737.COMM_ServiceInterphoneSw.Value, 1);
        }

        public static void ServiceInterPhoneOff()
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_SERVICE_INTERPHONE_SWITCH, Aircraft.pmdg737.COMM_ServiceInterphoneSw.Value, 0);
        }

        // --Engine EEC switches.
        public static void EngineEEC1On()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_EEC_L_GUARD, Aircraft.ClkL);
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_EEC_L_SWITCH, Aircraft.pmdg737.ENG_EECSwitch[0].Value, 1, true);
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_EEC_L_GUARD, Aircraft.ClkR);

        } // EngineEEC1On

        public static void EngineEEC1Off()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_EEC_L_GUARD, Aircraft.ClkL);
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_EEC_L_SWITCH, Aircraft.pmdg737.ENG_EECSwitch[0].Value, 0, true);
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_EEC_L_GUARD, Aircraft.ClkR);

        } // EngineEEC1Off

        public static void EngineEEC2On()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_EEC_R_GUARD, Aircraft.ClkL);
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_EEC_R_SWITCH, Aircraft.pmdg737.ENG_EECSwitch[1].Value, 1, true);
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_EEC_R_GUARD, Aircraft.ClkR);
        } // EngineEEC2On.

        public static void EngineEEC2Off()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_EEC_R_GUARD, Aircraft.ClkL);
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_EEC_R_SWITCH, Aircraft.pmdg737.ENG_EECSwitch[1].Value, 0, true);
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_EEC_R_GUARD, Aircraft.ClkR);

        } // EngineEEC2Off.

        public static void PassengerOxygenOn()
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_OXY_PASS_SWITCH, Aircraft.pmdg737.OXY_SwNormal.Value, 0, true);
        } // PassengerOxyOn.

        public static void PassengerOxygenNormal()
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_OXY_PASS_SWITCH, Aircraft.pmdg737.OXY_SwNormal.Value, 1, true);
        } // PassengerOxyNormal.

        public static void FlightRecorderTest()
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_FLTREC_SWITCH, Aircraft.pmdg737.FLTREC_SwNormal.Value, 0, true);
        } // FlightRecorderTest.

        public static void FlightRecorderNormal()
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_FLTREC_SWITCH, Aircraft.pmdg737.FLTREC_SwNormal.Value, 1, true);
        } // FlightRecorderNormal.

        public static void FlightControlA(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_FCTL_A_SWITCH, Aircraft.pmdg737.FCTL_FltControl_Sw[0].Value, position, true);
        } // FlightControlA.

        public static void FlightControlB(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_FCTL_B_SWITCH, Aircraft.pmdg737.FCTL_FltControl_Sw[1].Value, position, true);
        } // FlightControlB.
        public static void SpoilerA(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_SPOILER_A_SWITCH, Aircraft.pmdg737.FCTL_Spoiler_Sw[0].Value, position, true);
        } // SpoilerA.

        public static void SpoilerB(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_SPOILER_B_SWITCH, Aircraft.pmdg737.FCTL_Spoiler_Sw[1].Value, position, true);
        } // SpoilerB

        public static void YawDamper(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_YAW_DAMPER, Aircraft.pmdg737.FCTL_YawDamper_Sw.Value, position, true);
        } // YawDamper

        public static void AlternateFlapsArm(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_ALT_FLAPS_MASTER_SWITCH, Aircraft.pmdg737.FCTL_AltnFlaps_Sw_ARM.Value, position, true);
        } // AlternateFlapsArm

        public static void AlternatFlapsPosition(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_ALT_FLAPS_POS_SWITCH, Aircraft.pmdg737.FCTL_AltnFlaps_Control_Sw.Value, position, true);
        } // AlternatFlapsPosition

        public static void VHFSelector(int position)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_NAVDSP_VHF_NAV_SEL, position);
        } // VHFSelector.

        public static void IRSSelector(int position)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_NAVDSP_IRS_SEL, position);
        } // IRSSelector

        public static void FMCSelector(int position)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_NAVDSP_FMC_SEL, position);
        } // FMCSelector

        public static void SourceSelector(int position)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_NAVDSP_DISPLAYS_SOURCE_SEL, position);
        } // SourceSelector.

        public static void ControlPaneSelector(int position)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_NAVDSP_CONTROL_PANEL_SEL, position);
        } // ControlPaneSelector.

        public static void LeftAftFuelPump(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_1_AFT, Aircraft.pmdg737.FUEL_PumpAftSw[0].Value, position, true);
        } // LeftAftFuelPump

        public static void RightAftFuelPump(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_2_AFT, Aircraft.pmdg737.FUEL_PumpAftSw[1].Value, position, true);
        } // RightAftFuelPump

        public static void AftAuxFuelA(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_FUEL_AUX_AFT_A, Aircraft.pmdg737.FUEL_AuxAft[0].Value, position, true);
        } // AftAuxFuelA

        public static void AftAuxFuelB(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_FUEL_AUX_AFT_B, Aircraft.pmdg737.FUEL_AuxAft[1].Value, position, true);
        } // AftAuxFuelB

        public static void AftFuelBleed(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_FUEL_AFT_BLD, Aircraft.pmdg737.FUEL_AFTBleed.Value, position, true);
        } // AftFuelBleed

        public static void LeftFwdFuelPump(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_1_FORWARD, Aircraft.pmdg737.FUEL_PumpFwdSw[0].Value, position, true);
        } // LeftFwdFuelPump

        public static void RightFwdFuelPump(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_2_FORWARD, Aircraft.pmdg737.FUEL_PumpFwdSw[1].Value, position, true);
        } // RightFwdFuelPump

        public static void FwdAuxFuelA(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_FUEL_AUX_FWD_A, Aircraft.pmdg737.FUEL_AuxFwd[0].Value, position, true);
        } // FwdAuxFuelA

        public static void FwdAuxFuelB(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_FUEL_AUX_FWD_B, Aircraft.pmdg737.FUEL_AuxFwd[1].Value, position, true);
        } // FwdAuxFuelB

        public static void FwdFuelBleed(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_FUEL_FWD_BLD, Aircraft.pmdg737.FUEL_FWDBleed.Value, position, true);
        } // FwdFuelBleed

        public static void LeftCenterFuelPump(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_L_CENTER, Aircraft.pmdg737.FUEL_PumpCtrSw[0].Value, position, true);
        } // LeftCenterFuelPump

        public static void RightCenterFuelPump(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_R_CENTER, Aircraft.pmdg737.FUEL_PumpCtrSw[1].Value, position, true);
        } // RightCenterFuelPump

        public static void GroundFuelXfer(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_FUEL_GND_XFR_SW, Aircraft.pmdg737.FUEL_GNDXfr.Value, position, true);
        } // GroundFuelXfer

        public static void CrossFeed(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_FUEL_CROSSFEED, Aircraft.pmdg737.FUEL_CrossFeedSw.Value, position, true);
        } // Crossfeed

        public static void Battery(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_ELEC_BATTERY_SWITCH, Aircraft.pmdg737.ELEC_BatSelector.Value, position, true);
        } // BatterySelector

        public static void GroundPower()
        {
            if(FSUIPCConnection.ReadLVar("7X7X_Ground_Power_Light_Connected") == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_GRD_PWR_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_GRD_PWR_SWITCH, ClkR);
            }
        } // GroundPower.

        public static void CabinUtility(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_ELEC_CAB_UTIL, Aircraft.pmdg737.ELEC_CabUtilSw.Value, position, true);
        } // CabinUtility

        public static void IFE(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_ELEC_IFE, Aircraft.pmdg737.ELEC_IFEPassSeatSw.Value, position, true);
        } // IFE

        public static void DCSelector(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_ELEC_DC_METER, Aircraft.pmdg737.ELEC_DCMeterSelector.Value, position);
        } // DCSelector

        public static void ACSelector(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_ELEC_AC_METER, Aircraft.pmdg737.ELEC_ACMeterSelector.Value, position);
        } // ACSelector

        public static void StandbyBattery()
        {
            if (FSUIPCConnection.ReadLVar("switch_10_73X") != 0)
            {
                if (FSUIPCConnection.ReadLVar("switch_11_73X") != 100)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_GUARD, ClkR);

                }
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_SWITCH, ClkL);
                Thread.Sleep(250);
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_SWITCH, ClkL);

            }
        }

        public static void StandbyOff()
        {
            if (FSUIPCConnection.ReadLVar("switch_10_73X") == 0)
            {
                if (FSUIPCConnection.ReadLVar("switch_11_73X") != 100)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_GUARD, ClkR);
                    Thread.Sleep(50);
                }
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_SWITCH, ClkR);

            }
            if (FSUIPCConnection.ReadLVar("switch_10_73X") == 100)
            {
                if (FSUIPCConnection.ReadLVar("switch_11_73X") != 100)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_GUARD, ClkL);
                    Thread.Sleep(50);
                }
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_SWITCH, ClkL);

            }
        }

        public static void StandbyAuto()
        {
            if (FSUIPCConnection.ReadLVar("switch_10_73X") != 100)
            {
                if (FSUIPCConnection.ReadLVar("switch_11_73X") != 100)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_GUARD, ClkR);

                }
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_SWITCH, ClkR);
                Thread.Sleep(250);
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_SWITCH, ClkR);
                    }
    }

        public static void Idg1Disconnect(int position)
        {
                                    CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_ELEC_DISCONNECT_1_SWITCH, Aircraft.pmdg737.ELEC_IDGDisconnectSw[0].Value, position, true);
        } // Idg1Disconnect

        public static void Idg2Disconnect(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_ELEC_DISCONNECT_2_SWITCH, Aircraft.pmdg737.ELEC_IDGDisconnectSw[1].Value, position, true);
        } // Idg2Disconnect.

        public static void Generator1(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_ELEC_GEN1_SWITCH, Aircraft.pmdg737.ELEC_GenSw[0].Value, position, true);
        } // Generator1

        public static void Generator2(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_ELEC_GEN2_SWITCH, Aircraft.pmdg737.ELEC_GenSw[1].Value, position, true);
        } // Generator2

        public static void ApuGenerator1(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_ELEC_APU_GEN1_SWITCH, Aircraft.pmdg737.ELEC_APUGenSw[0].Value, position, true);
        } // ApuGenerator1

        public static void ApuGenerator2(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_ELEC_APU_GEN2_SWITCH, Aircraft.pmdg737.ELEC_APUGenSw[1].Value, position, true);
        } // ApuGenerator2
        
        public static void BusTransferOff()
        {
            if (FSUIPCConnection.ReadLVar("switch_18_73X") != 0)
            {
                if (FSUIPCConnection.ReadLVar("switch_19_73X") != 100)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_BUS_TRANSFER_GUARD, ClkR);
                }
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_BUS_TRANSFER_SWITCH, ClkL);
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_BUS_TRANSFER_SWITCH, ClkR);
            }

        } // BusTransferOff

        public static void BusTransferAuto()
        {
            if (FSUIPCConnection.ReadLVar("switch_18_73X") != 100)
            {
                if (FSUIPCConnection.ReadLVar("switch_19_73X") != 100)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_BUS_TRANSFER_GUARD, ClkR);
                }
            }
        } // BusTransferAuto

        public static void LeftWiperSelector(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_WIPER_LEFT_CONTROL, Aircraft.pmdg737.OH_WiperLSelector.Value, position);
        } // LeftWiperSelector

        public static void RightWiperSelector(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_WIPER_RIGHT_CONTROL, Aircraft.pmdg737.OH_WiperRSelector.Value, position);
        } // RightWiperSelector

public static void EmergencyLightSelector(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_EMER_EXIT_LIGHT_SWITCH, Aircraft.pmdg737.LTS_EmerExitSelector.Value, position, true);
        } // EmergencyLightsSelector

        public static void AirEquipCoolingSupply(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_EC_SUPPLY_SWITCH, Aircraft.pmdg737.AIR_EquipCoolingSupplyNORM.Value, position, true);
        } // AirEquipCoolingSupply
        public static void AirEquipCoolingExhaust(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_EC_EXHAUST_SWITCH, Aircraft.pmdg737.AIR_EquipCoolingExhaustNORM.Value, position, true);
        } // AirEquipCoolingExhaust

        public static void NoSmokingSelector(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_NO_SMOKING_LIGHT_SWITCH, Aircraft.pmdg737.COMM_NoSmokingSelector.Value, position, true);
                                                } // NoSmokingSelector



        public static void SeatBeltSelector(int position)
        {
            CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_FASTEN_BELTS_LIGHT_SWITCH, Aircraft.pmdg737.COMM_FastenBeltsSelector.Value, position, true);
        } // SeatBeltSelector

        public static void CircuttBreakerLightIncrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_CB_LIGHT_CONTROL, Inc);
        } // CircuttBreakerIncrease

        public static void CircuttBreakerLightDecrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_CB_LIGHT_CONTROL, Dec);
        } // CircuttBreakerLightDecrease

        public static void OverheadPanelLightIncrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_PANEL_LIGHT_CONTROL, Inc);
        } // OverheadPanelLightIncrease

        public static void OverheadPanelLightDecrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_PANEL_LIGHT_CONTROL, Dec);
        } // OverheadPanelLightDecrease

        public static void LeftSideWindowHeatOn()
        {
                                            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_WINDOW_HEAT_1, ClkL);
                    } // LeftSideWindowHeatOn

        public static void LeftSideWindowHeatOff()
        {
                                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_WINDOW_HEAT_1, ClkR);
            
        } // LeftSideWindowHeatOff

        public static void LeftSideWindowHeatToggle()
        {
        if (Aircraft.pmdg737.ICE_WindowHeatSw[0].Value == 0)
            {
                LeftSideWindowHeatOn();
            }
            else
            {
                LeftSideWindowHeatOff();
            }

        } // LeftSideWindowHeatToggle

        public static void LeftForwardWindowHeatOn()
        {
                                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_WINDOW_HEAT_2, ClkL);
                    } // LeftForwardWindowHeatOn

        public static void LeftForwardWindowHeatOff()
        {
                            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_WINDOW_HEAT_2, ClkR);
        } // LeftForwardWindowHeatOff

        public static void LeftForwardWindowHeatToggle()
        {
        if (Aircraft.pmdg737.ICE_WindowHeatSw[1].Value == 0)
            {
                LeftForwardWindowHeatOn();
            }
            else
            {
                LeftForwardWindowHeatOff();
            }
        } // LeftForwardWindowHeatToggle

        public static void WindowHeatTestOn()
        {
            if(Aircraft.pmdg737.ICE_WindowHeatTestSw.Value == 0)
            {
                                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_WINDOW_HEAT_TEST, ClkL);
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_WINDOW_HEAT_TEST, ClkL);
            }
        } // WindowHeatTestOn

        public static void WindowHeatTestOff()
        {
        } // WindowHeatTest Off

        public static void WindowOverHeatTest()
        {
//            var switchPosition = FSUIPCConnection.ReadLVar("switch_137_73X");

            if(Aircraft.pmdg737.ICE_WindowHeatTestSw.Value == 1)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_WINDOW_HEAT_TEST, ClkR);
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_WINDOW_HEAT_TEST, ClkR);
            }
        } // WindowOverHeatTest

        public static void RightForwardWindowHeatOn()
        {
                                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_WINDOW_HEAT_3, ClkL);
                    } // RightForwardWindowHeatOn

        public static void RightForwardWindowHeatOff()
        {
                            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_WINDOW_HEAT_3, ClkR);
        } // RightForwardWindowHeatOff

    public static void RightForwardWindowHeatToggle()
        {
            if (Aircraft.pmdg737.ICE_WindowHeatSw[2].Value == 0)
            {
                RightForwardWindowHeatOn();
            }
            else
            {
                RightForwardWindowHeatOn();
            }
        } // RightForwardWindowHeatToggle

        public static void RightSideWindowHeatOn()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_WINDOW_HEAT_4, ClkL);
        } // RightSideWindowHeatOn.

        public static void RightSideWindowHeatOff()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_WINDOW_HEAT_4, ClkR);
        } // RightSideWindowHeatOff

        public static void RightSideWindowHeatToggle()
        {
            if (Aircraft.pmdg737.ICE_WindowHeatSw[3].Value == 0)
            {
                RightSideWindowHeatOn();
            }
            else
            {
                RightSideWindowHeatOff();
            }
        } // RightSideWindowHeatToggle.
    
        public static void LeftProbeHeatOn()
        {
            if(FSUIPCConnection.ReadLVar("switch_140_73X") == 100)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_PROBE_HEAT_1, ClkL);
            }
                    } // LeftProbeHeatOn

        public static void LeftProbeHeatOff()
        {
            if(FSUIPCConnection.ReadLVar("switch_140_73X") == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_PROBE_HEAT_1, ClkR);
            }
        } // LeftProbeHeatOff

        public static void RightProbeHeatOn()
        {
            if(FSUIPCConnection.ReadLVar("switch_141_73X") == 100)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_PROBE_HEAT_2, ClkL);
            }
        } // RightProbeHeatOn

        public static void RightProbeHeatOff()
        {
            if(FSUIPCConnection.ReadLVar("switch_141_73X") == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_PROBE_HEAT_2, ClkR);
            }
        } // RightProbeHeatOff

        public static void WingAntiIceOn()
        {
            if(Aircraft.pmdg737.ICE_WingAntiIceSw.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_WING_ANTIICE, ClkL);
            }
        } // WingAntiIceOn
        public static void WingAntiIceOff()
        {
            if(Aircraft.pmdg737.ICE_WingAntiIceSw.Value == 1)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_WING_ANTIICE, ClkR);
            }
        } // WingAntiIceOff

        public static void Engine1AntiIceOn()
        {
            if (Aircraft.pmdg737.ICE_EngAntiIceSw[0].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_ENGINE_ANTIICE_1, ClkL);
            }
        } // Engine1AntiIceOn

        public static void Engine1AntiIceOff()
        {
            if (Aircraft.pmdg737.ICE_EngAntiIceSw[0].Value == 1)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_ENGINE_ANTIICE_1, ClkR);
            }
        } // Engine1AntiIceOff

        public static void Engine2AntiIceOn()
        {
            if (Aircraft.pmdg737.ICE_EngAntiIceSw[1].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_ENGINE_ANTIICE_2, ClkL);
            }
        }  // Engine2AntiIceOn

        public static void Engine2AntiIceOff()
        {
            if (Aircraft.pmdg737.ICE_EngAntiIceSw[1].Value == 1)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_ENGINE_ANTIICE_2, ClkR);
            }
        } // Engine2AntiIceOff

        public static void HydraulicElectricalPump1()
        {
            if (Aircraft.pmdg737.HYD_PumpSw_elec[1].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_HYD_ELEC1, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_HYD_ELEC1, ClkR);
            }
        } // HydraulicsElectricalPump1

        public static void HydraulicElectricalPump2()
        {
               if (Aircraft.pmdg737.HYD_PumpSw_elec[0].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_HYD_ELEC2, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_HYD_ELEC2, ClkR);
            }
        } // HydraulicElectricalPump2

        public static void HydraulicsEnginePump1()
        {
            if (Aircraft.pmdg737.HYD_PumpSw_eng[0].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_HYD_ENG1, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_HYD_ENG1, ClkR);
            }
        } // HydraulicsEnginePump1

        public static void HydraulicsEnginePump2()
        {
            if (Aircraft.pmdg737.HYD_PumpSw_eng[1].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_HYD_ENG2, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_HYD_ENG2, ClkR);
            }
        } // HydraulicsEnginePump12
    } // End PMDG737Aircraft.
    } // End namespace.
