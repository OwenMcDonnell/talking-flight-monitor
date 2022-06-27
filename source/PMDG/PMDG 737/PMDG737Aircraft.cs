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
        public static  PMDG_NGX_CDU_Screen cdu2 = new PMDG_NGX_CDU_Screen(0x5C00);

        // constants for PMDG mouse click parameters
        public const int ClkL = 536870912;
        public const int ClkR = -2147483648;
        public const int Inc = 16384;
        public const int Dec = 8192;
        public static  void CalculateSwitchPosition(PMDG_737_NGX_Control control, int pos, int sel, bool useClicks = false)
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
new SingleStateToggle { Name = "Engine #1 fuel valve [closed] light", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_annunENG_VALVE_CLOSED[0], AvailableStates = _fuelValveStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_annunENG_VALVE_CLOSED_1},
new SingleStateToggle { Name = "Engine #2 fuel valve [closed] light", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_annunENG_VALVE_CLOSED[1], AvailableStates = _fuelValveStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_annunENG_VALVE_CLOSED_2},
new SingleStateToggle { Name = "Engine #1 spar valve [closed] light", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_annunSPAR_VALVE_CLOSED[0], AvailableStates = _fuelValveStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_annunSPAR_VALVE_CLOSED_1},
new SingleStateToggle { Name = "Engine #2 spar valve [closed] light", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_annunSPAR_VALVE_CLOSED[1], AvailableStates = _fuelValveStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_annunSPAR_VALVE_CLOSED_2},
new SingleStateToggle { Name = "Engine #1 fuel filter bypass light", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_annunFILTER_BYPASS[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_annunFILTER_BYPASS_1},
new SingleStateToggle { Name = "Engine #2 fuel filter bypass light", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_annunFILTER_BYPASS[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_annunFILTER_BYPASS_2},
new SingleStateToggle { Name = "Crossfeed valve [open] light", PanelName = "Forward Overhead", PanelSection = "Fuel", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FUEL_annunXFEED_VALVE_OPEN, AvailableStates = _fuelValveStates, shouldSpeak = Properties.pmdg737_offsets.Default.FUEL_annunXFEED_VALVE_OPEN},
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
new SingleStateToggle { Name = "Battery selector", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_BatSelector, AvailableStates = _batterySelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_BatSelector},
new SingleStateToggle { Name = "Cabin utility", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_CabUtilSw, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_CabUtilSw},
new SingleStateToggle { Name = "Passenger seats", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_IFEPassSeatSw, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_IFEPassSeatSw},
new SingleStateToggle { Name = "Drive #1 light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunDRIVE[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunDRIVE_1},
new SingleStateToggle { Name = "Drive #2 light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunDRIVE[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunDRIVE_2},
new SingleStateToggle { Name = "Standby power [off] light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunSTANDBY_POWER_OFF, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunSTANDBY_POWER_OFF},
new SingleStateToggle { Name = "IDG #1 disconnect", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_IDGDisconnectSw[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_IDGDisconnectSw_1},
new SingleStateToggle { Name = "IDG #2 disconnect", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_IDGDisconnectSw[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_IDGDisconnectSw_2},
new SingleStateToggle { Name = "Standby power selector", PanelName = "Forward Overhead", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_StandbyPowerSelector, AvailableStates = _standbySelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_StandbyPowerSelector},
new SingleStateToggle { Name = "Ground power [available] light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type= PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunGRD_POWER_AVAILABLE, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunGRD_POWER_AVAILABLE},
new SingleStateToggle { Name = "Ground power", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_GrdPwrSw, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_GrdPwrSw},
new SingleStateToggle { Name = "Bus transfer [auto]", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_BusTransSw_AUTO, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_BusTransSw_AUTO},
new SingleStateToggle { Name = "Generator #1", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_GenSw[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_GenSw_1},
new SingleStateToggle { Name = "Generator #2", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_GenSw[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_GenSw_2},
new SingleStateToggle { Name = "APU generator #1", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_APUGenSw[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_APUGenSw_1},
new SingleStateToggle { Name = "APU generator #2", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_APUGenSw[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_APUGenSw_2},
new SingleStateToggle { Name = "Transfer bus #1 [off] light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunTRANSFER_BUS_OFF[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunTRANSFER_BUS_OFF_1},
new SingleStateToggle { Name = "Transfer bus #2 [off] light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunTRANSFER_BUS_OFF[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunTRANSFER_BUS_OFF_2},
new SingleStateToggle { Name = "Source #1 [off] light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunSOURCE_OFF[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunSOURCE_OFF_1},
new SingleStateToggle { Name = "Source #2 [off] light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunSOURCE_OFF[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunSOURCE_OFF_2},
new SingleStateToggle { Name = "Generator #1 bus [off] light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunGEN_BUS_OFF[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunGEN_BUS_OFF_1},
new SingleStateToggle { Name = "Generator #2 bus [off] light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunGEN_BUS_OFF[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunGEN_BUS_OFF_2},
new SingleStateToggle { Name = "APU generator bus [off] light", PanelName = "Forward Overhead", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ELEC_annunAPU_GEN_OFF_BUS, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.ELEC_annunAPU_GEN_OFF_BUS},

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
// -- section: none

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
            if(Aircraft.pmdg737.MCP_annunALT_HOLD.Value == 1)
            {
                navigationAid = "hold";
            }
            else if(Aircraft.pmdg737.MCP_annunLVL_CHG.Value == 1)
            {
                navigationAid = "level change";
            }
            else if(Aircraft.pmdg737.MCP_annunVNAV.Value == 1)
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

            if(SpeedMode == AircraftSystem.FMC)
            {
                FDUoutput = "FMC speed";
            }
            else if(SpeedMode == AircraftSystem.MCP)
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
                                   } // End PMDG737Aircraft.
} // End namespace.
