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
using System.Reflection;

namespace tfm
{
    static class PMDG737Aircraft
    {

        private static tfm.PMDG.PMDG737.McpComponents.mcpAltitude altitudeBox = new tfm.PMDG.PMDG737.McpComponents.mcpAltitude();
        private static tfm.PMDG.PMDG737.McpComponents.mcpSpeed speedBox = new tfm.PMDG.PMDG737.McpComponents.mcpSpeed();
        private static tfm.PMDG.PMDG737.McpComponents.mcpHeading  headingBox = new tfm.PMDG.PMDG737.McpComponents.mcpHeading();
        private static tfm.PMDG.PMDG737.McpComponents.mcpVerticalSpeed verticalSpeedBox = new tfm.PMDG.PMDG737.McpComponents.mcpVerticalSpeed();
        private static tfm.PMDG.PMDG737.McpComponents.mcpNavigation navigationBox = new tfm.PMDG.PMDG737.McpComponents.mcpNavigation();

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
                    {"navigation", navigationBox },
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
            {0, "grd" },
            {1, "auto" },
            {2, "cont" },
            {3, "flt" },
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

        private static Dictionary<byte, string> _ignitionStartSelectorStates = new Dictionary<byte, string>()
        {
            {0, "ign L" },
            {1, "both" },
            {2, "ign R" },
        };

        private static Dictionary<byte, string> _retractableLandingLightStates = new Dictionary<byte, string>()
        {
            {0, "retract" },
            {1, "extend" },
            {2, "on" },
        };

        private static Dictionary<byte, string> _positionLightStates = new Dictionary<byte, string>()
        {
            {0, "steady" },
            {1, "off" },
            {2, "strobe/steady" },
        };

        private static Dictionary<byte, string> _autoBrakeSelectorStates = new Dictionary<byte, string>()
        {
            {0, "RTO" },
            {1, "off" },
            {2, "disarm" },
            {3, "1" },
            {4, "2" },
            {5, "3" },
        };

        private static Dictionary<byte, string> _n1SelectorStates = new Dictionary<byte, string>()
        {
            {0, "2" },
            {1, "1" },
            {2, "auto" },
            {3, "both" },
        };

        private static Dictionary<byte, string> _bankLimitSelectorStates = new Dictionary<byte, string>()
        {
            {0, "10" },
            {1, "15" },
            {2, "20" },
            {3, "25" },
            {4, "30" },
                    };

        private static  Dictionary<byte, string> _noseWheelSteeringStates = new Dictionary<byte, string>()
        {
            {0, "Alt" },
            {1, "Normal" },
        };

        private static  Dictionary<byte, string> _captPanelDuSelectorStates = new Dictionary<byte, string>()
        {
            {0, "o-pfd" },
            {1, "normal" },
            {2, "i-eng" },
            {3, "i-pfd" },
            {4, "i-mfd" },
        };

        private static  Dictionary<byte, string> _foPanelDuSelectorStates = new Dictionary<byte, string>()
        {
            {0, "i-mfd" },
            {1, "i-pfd" },
            {2, "i-eng" },
            {3, "normal" },
            {4, "o-pfd" },
        };

        private static  Dictionary<byte, string> _captLowerDuSelectorStates = new Dictionary<byte, string>()
        {
            {0, "eng" },
            {1, "normal" },
            {2, "nd" },
        };

        private static  Dictionary<byte, string> _foLowerDuSelectorStates = new Dictionary<byte, string>()
        {
            {0, "nd" },
            {1, "normal" },
            {2, "eng" },
        };

        private static  Dictionary<byte, string> _disengageTestSelectorStates = new Dictionary<byte, string>()
        {
            {0, "1" },
            {1, "off" },
            {2, "2" },
        };

        private static  Dictionary<byte, string> _lightsSelectorStates = new Dictionary<byte, string>()
        {
            {0, "test" },
            {1, "bright" },
            {2, "dim" },
        };

        private static  Dictionary<byte, string> _speedRefSelectorStates = new Dictionary<byte, string>()
        {
            {0, "set" },
            {1, "auto" },
            {2, "v1" },
            {3, "vr" },
            {4, "wt" },
            {5, "vref" },
            {6, "bug" },
        };

        private static  Dictionary<byte, string> _fuelFlowSelectorStates = new Dictionary<byte, string>()
        {
            {0, "reset" },
            {1, "rate" },
            {2, "used" },
        };

        private static  Dictionary<byte, string> _gearLeverStates = new Dictionary<byte, string>()
        {
            {0, "up" },
            {1, "off" },
            {2, "down" },
        };

        private static  Dictionary<byte, string> _fireOvhtDetStates = new Dictionary<byte, string>()
        {
            {0, "A" },
            {1, "normal" },
            {2, "B" },
        };

        private static  Dictionary<byte, string> _fireTestDetStates = new Dictionary<byte, string>()
        {
            {0, "fault/inop" },
            {1, "neutral" },
            {2, "fire/overheat" },
        };

        private static  Dictionary<byte, string> _fireHandlePosStates = new Dictionary<byte, string>()
        {
            {0, "in" },
            {1, "blocked" },
            {2, "out" },
            {3, "turned left" },
            {4, "turned right" },
        };

        private static  Dictionary<byte, string> _fireExtinguisherTestStates = new Dictionary<byte, string>()
        {
            {0, "1" },
            {1, "neutral" },
            {2, "2" },
        };

        private static  Dictionary<byte, string> _cargoDetSelectorStates = new Dictionary<byte, string>()
        {
            {0, "A" },
            {1, "normal" },
            {2, "B" },
        };

        private static Dictionary<byte, string> _xponderSelectorStates = new Dictionary<byte, string>()
        {
            {0, "1" },
            {1, "2" },
        };

        private static Dictionary<byte, string> _xponderAltSourceSelectorStates = new Dictionary<byte, string>()
        {
            {0, "1" },
            {1, "2" },
        };

        private static Dictionary<byte, string> _xponderModeSelectorStates = new Dictionary<byte, string>()
        {
            {0, "standby" },
            {1, "altitude reporting off" },
            {2, "transponder" },
            {3, "TA only" },
            {4, "TA/RA" },
        };

        private static Dictionary<byte, string> _fltDeckDoorSelectorStates = new Dictionary<byte, string>()
        {
            {0, "unlocked" },
            {1, "auto/pushed in" },
            {2, "auto" },
            {3, "deny" },
        };

        private static Dictionary<byte, string> _micSelectorStates = new Dictionary<byte, string>()
        {
            {0, "vhf1" },
            {1, "vhf2" },
            {2, "vhf3" },
            {3, "hf1" },
            {4, "hf2" },
            {5, "flt" },
            {6, "svc" },
            {7, "pa" },
        };

        private static Dictionary<byte, string> _aircraftModels = new Dictionary<byte, string>()
        {
            {1, "600" },
            {2, "700" },
            {3, "700 BW" },
            {4, "700 SSW" },
            {5, "800" },
            {6, "800 BW" },
            {7, "800 SSW" },
            {8, "900" },
            {9, "900 BW" },
            {10, "900 SSW" },
            {11, "900ER BW" },
            {12, "900ER SSW" },
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
// ---section: Engines

new SingleStateToggle { Name = "APU selector", PanelName = "Bottom Overhead", PanelSection = "Engines", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.APU_Selector, AvailableStates = _apuStates, shouldSpeak = Properties.pmdg737_offsets.Default.APU_Selector},
new SingleStateToggle { Name = "Engine #1", PanelName = "Bottom Overhead", PanelSection = "Engines", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ENG_StartSelector[0], AvailableStates = _engineStartModeStates, shouldSpeak = Properties.pmdg737_offsets.Default.ENG_StartSelector1},
new SingleStateToggle { Name = "Engine #2", PanelName = "Bottom Overhead", PanelSection = "Engines", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ENG_StartSelector[1], AvailableStates = _engineStartModeStates, shouldSpeak = Properties.pmdg737_offsets.Default.ENG_StartSelector2},
new SingleStateToggle { Name = "Ignition start selector", PanelName = "Bottom Overhead", PanelSection = "Engines", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.ENG_IgnitionSelector, AvailableStates = _ignitionStartSelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.ENG_IgnitionSelector},

// --section: lights
new SingleStateToggle {Name = "Left retractable landing light", PanelName = "Bottom Overhead", PanelSection = "Lights", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_LandingLtRetractableSw[0], AvailableStates = _retractableLandingLightStates, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_LandingLtRetractableSw1},
new SingleStateToggle {Name = "Right retractable landing light", PanelName = "Bottom Overhead", PanelSection = "Lights", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_LandingLtRetractableSw[1], AvailableStates = _retractableLandingLightStates, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_LandingLtRetractableSw2},
new SingleStateToggle{ Name = "Left fixed landing light", PanelName = "Bottom Overhead", PanelSection = "Lights", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_LandingLtFixedSw[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_LandingLtFixedSw1},
new SingleStateToggle{ Name = "Right fixed landing light", PanelName = "Bottom Overhead", PanelSection = "Lights", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_LandingLtFixedSw[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_LandingLtFixedSw2},
new SingleStateToggle { Name = "Left runway turnoff light", PanelName = "Bottom Overhead", PanelSection = "Lights", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_RunwayTurnoffSw[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_RunwayTurnoffSw1},
new SingleStateToggle { Name = "Right runway turnoff light", PanelName = "Bottom Overhead", PanelSection = "Lights", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_RunwayTurnoffSw[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_RunwayTurnoffSw2},
new SingleStateToggle { Name = "Taxi light", PanelName = "Bottom Overhead", PanelSection = "Lights", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_TaxiSw, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_TaxiSw},
new SingleStateToggle { Name = "Logo lights", PanelName = "Bottom Overhead", PanelSection = "Lights", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_LogoSw, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_LogoSw},
new SingleStateToggle { Name = "Position lights", PanelName = "Bottom Overhead", PanelSection = "Lights", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_PositionSw, AvailableStates = _positionLightStates, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_PositionSw},
new SingleStateToggle { Name = "Anti-collision lights", PanelName = "Bottom Overhead", PanelSection = "Lights", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_AntiCollisionSw, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_AntiCollisionSw},
new SingleStateToggle { Name = "Wing lights", PanelName = "Bottom Overhead", PanelSection = "Lights", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_WingSw, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_WingSw},
new SingleStateToggle { Name = "Wheel well lights", PanelName = "Bottom Overhead", PanelSection = "Lights", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_WheelWellSw, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_WheelWellSw},

// --panel: Glare Shield
// --section: Warnings
new SingleStateToggle {Name = "Left fire warning light", PanelName = "Glare Shield", PanelSection = "Warnings", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.WARN_annunFIRE_WARN[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.WARN_annunFIRE_WARN1},
new SingleStateToggle {Name = "Right fire warning light", PanelName = "Glare Shield", PanelSection = "Warnings", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.WARN_annunFIRE_WARN[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.WARN_annunFIRE_WARN2},
new SingleStateToggle { Name = "Left master caution light", PanelName = "Glare Shield", PanelSection = "Warnings", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.WARN_annunMASTER_CAUTION[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.WARN_annunMASTER_CAUTION1},
new SingleStateToggle { Name = "Right master caution light", PanelName = "Glare Shield", PanelSection = "Warnings", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.WARN_annunMASTER_CAUTION[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.WARN_annunMASTER_CAUTION2},
new SingleStateToggle { Name = "Flight controls warning light", PanelName = "Glare Shield", PanelSection = "Warnings", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.WARN_annunFLT_CONT, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.WARN_annunFLT_CONT},
new SingleStateToggle { Name = "IRS warning light", PanelName = "Glare Shield", PanelSection = "Warnings", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.WARN_annunIRS, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.WARN_annunIRS},
new SingleStateToggle { Name = "Fuel warning light", PanelName = "Glare Shield", PanelSection = "Warnings", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.WARN_annunFUEL, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.WARN_annunFUEL},
new SingleStateToggle { Name = "Electrical warning light", PanelName = "Glare Shield", PanelSection = "Warnings", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.WARN_annunELEC, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.WARN_annunELEC},
new SingleStateToggle { Name = "APU warning light", PanelName = "Glare Shield", PanelSection = "Warnings", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.WARN_annunAPU, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.WARN_annunAPU},
new SingleStateToggle { Name = "Overheat warning light", PanelName = "Glare Shield", PanelSection = "Warnings", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.WARN_annunOVHT_DET, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.WARN_annunOVHT_DET},
new SingleStateToggle { Name = "Anti-ice warning light", PanelName = "Glare Shield", PanelSection = "Warnings", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.WARN_annunANTI_ICE, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.WARN_annunANTI_ICE},
new SingleStateToggle { Name = "Hydraulics warning light", PanelName = "Glare Shield", PanelSection = "Warnings", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.WARN_annunHYD, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.WARN_annunHYD},
new SingleStateToggle { Name = "Doors warning light", PanelName = "Glare Shield", PanelSection = "Warnings", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.WARN_annunDOORS, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.WARN_annunDOORS},
new SingleStateToggle { Name = "Engines warning light", PanelName = "Glare Shield", PanelSection = "Warnings", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.WARN_annunENG, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.WARN_annunENG},
new SingleStateToggle { Name = "Overhead warning light", PanelName = "Glare Shield", PanelSection = "Warnings", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.WARN_annunOVERHEAD, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.WARN_annunOVERHEAD},
new SingleStateToggle { Name = "Air Systems warning light", PanelName = "Glare Shield", PanelSection = "Warnings", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.WARN_annunAIR_COND, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.WARN_annunAIR_COND},

// --section: MCP
new SingleStateToggle { Name = "Speed intervene", PanelName = "Glare Shield", PanelSection = "MCP-SPEED", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_IASBlank, AvailableStates = _offOrOnStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_IASBlank},
new SingleStateToggle { Name = "MCP Overspeed warning", PanelName = "Glare Shield", PanelSection = "MCP-SPEED", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_IASOverspeedFlash, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_IASOverspeedFlash},
new SingleStateToggle { Name = "MCP underspeed warning", PanelName = "Glare Shield", PanelSection = "MCP-SPEED", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_IASUnderspeedFlash, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_IASUnderspeedFlash},
new SingleStateToggle { Name = "Autothrottle", PanelName = "Glare Shield", PanelSection = "MCP-SPEED", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_ATArmSw, AvailableStates = _armedOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_ATArmSw},
new SingleStateToggle { Name = "Autothrottle armed light", PanelName = "Glare Shield", PanelSection = "MCP-SPEED", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_annunATArm, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_annunATArm},
new SingleStateToggle { Name = "N1 light", PanelName = "Glare Shield", PanelSection = "MCP-SPEED", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_annunN1, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_annunN1},
new SingleStateToggle { Name = "Speed light", PanelName = "Glare Shield", PanelSection = "MCP-SPEED", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_annunSPEED, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_annunSPEED},
new SingleStateToggle { Name = "Heading select light", PanelName = "Glare Shield", PanelSection = "MCP-HEADING", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_annunHDG_SEL, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_annunHDG_SEL},
new SingleStateToggle { Name = "LNav light", PanelName = "Glare Shield", PanelSection = "MCP-HEADING", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_annunLNAV, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_annunLNAV},
new SingleStateToggle { Name = "Vertical speed mode", PanelName = "Glare Shield", PanelSection = "MCP-VERTICAL", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_VertSpeedBlank, AvailableStates = _offOrOnStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_VertSpeedBlank },
new SingleStateToggle { Name = "Vertical speed light", PanelName = "Glare Shield", PanelSection = "MCP-VERTICAL", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_annunVS, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_annunVS},
new SingleStateToggle { Name = "V NAV light", PanelName = "Glare Shield", PanelSection = "MCP-ALTITUDE", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_annunVNAV, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_annunVNAV},
new SingleStateToggle { Name = "Level change light", PanelName = "Glare Shield", PanelSection = "MCP-ALTITUDE", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_annunLVL_CHG, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_annunLVL_CHG},
new SingleStateToggle { Name = "Altitude hold light", PanelName = "Glare Shield", PanelSection = "MCP-ALTITUDE", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_annunALT_HOLD, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_annunALT_HOLD},
new SingleStateToggle { Name = "Left flight director", PanelName = "Glare Shield", PanelSection = "MCP-NAVIGATION", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_FDSw[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_FDSw1},
new SingleStateToggle { Name = "Right flight director", PanelName = "Glare Shield", PanelSection = "MCP-NAVIGATION", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_FDSw[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_FDSw2},
new SingleStateToggle { Name = "Bank limit", PanelName = "Glare Shield", PanelSection = "MCP-NAVIGATION", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_BankLimitSel, AvailableStates = _bankLimitSelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_BankLimitSel},
new SingleStateToggle { Name = "Disengage bar", PanelName = "Glare Shield", PanelSection = "MCP-NAVIGATION", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_DisengageBar, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_DisengageBar},
new SingleStateToggle { Name = "Left flight director light", PanelName = "Glare Shield", PanelSection = "MCP-NAVIGATION", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_annunFD[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_annunFD1},
new SingleStateToggle { Name = "Right flight director light", PanelName = "Glare Shield", PanelSection = "MCP-NAVIGATION", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_annunFD[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_annunFD2},
new SingleStateToggle { Name = "Approach mode light", PanelName = "Glare Shield", PanelSection = "MCP-NAVIGATION", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_annunAPP, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_annunAPP},
new SingleStateToggle { Name = "VOR/Localizer light", PanelName = "Glare Shield", PanelSection = "MCP-NAVIGATION", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_annunVOR_LOC, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_annunVOR_LOC},
new SingleStateToggle { Name = "CMDA light", PanelName = "Glare Shield", PanelSection = "MCP-NAVIGATION", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_annunCMD_A, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_annunCMD_A},
new SingleStateToggle { Name = "CWSA light", PanelName = "Glare Shield", PanelSection = "MCP-NAVIGATJION", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_annunCWS_A, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_annunCWS_A},
new SingleStateToggle { Name = "CMDB light", PanelName = "Glare Shield", PanelSection = "MCP-NAVIGATION", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_annunCMD_B, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_annunCMD_B},
new SingleStateToggle { Name = "CWSB", PanelName = "Glare Shield", PanelSection = "MCP-NAVIGATION", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MCP_annunCWS_B, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MCP_annunCWS_B},
// ---panel: forward
// --section: main

new SingleStateToggle { Name = "Auto brake", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_AutobrakeSelector, AvailableStates = _autoBrakeSelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_AutobrakeSelector},
new SingleStateToggle { Name = "Speed brake armed light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunSPEEDBRAKE_ARMED, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunSPEEDBRAKE_ARMED},
new SingleStateToggle { Name = "Speed brake extended light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunSPEEDBRAKE_EXTENDED, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunSPEEDBRAKE_EXTENDED},
new SingleStateToggle { Name = "Speedbrake d/n arm light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunSPEEDBRAKE_DO_NOT_ARM, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunSPEEDBRAKE_DO_NOT_ARM},
new SingleStateToggle { Name = "Autobrake disarm light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunAUTO_BRAKE_DISARM, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunAUTO_BRAKE_DISARM},
new SingleStateToggle { Name = "N1", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_N1SetSelector, AvailableStates = _n1SelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_N1SetSelector},
new SingleStateToggle {Name = "Nose wheel stearing", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_NoseWheelSteeringSwNORM, AvailableStates = _noseWheelSteeringStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_NoseWheelSteeringSwNORM},
new SingleStateToggle { Name = "Left Disengage test selector", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_DisengageTestSelector[0], AvailableStates = _disengageTestSelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_DisengageTestSelector1},
new SingleStateToggle { Name = "Right Disengage test selector", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_DisengageTestSelector[1], AvailableStates = _disengageTestSelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_DisengageTestSelector2},
new SingleStateToggle { Name = "Interior lights", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_LightsSelector, AvailableStates = _lightsSelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_LightsSelector},
new SingleStateToggle { Name = "Fuel flow selector", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_FuelFlowSelector, AvailableStates = _fuelFlowSelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_FuelFlowSelector},
new SingleStateToggle { Name = "Left below glide slope light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunBELOW_GS[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunBELOW_GS1},
new SingleStateToggle { Name = "Right below glide slope light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunBELOW_GS[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunBELOW_GS2},
new SingleStateToggle { Name = "Red command A disengage light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunAP[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunAP1},
new SingleStateToggle { Name = "Amber command A disengage light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunAP_Amber[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunAP_Amber1},
new SingleStateToggle { Name = "Red command B disengage light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunAP[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunAP2},
new SingleStateToggle { Name = "Amber command B disengage light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunAP_Amber[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunAP_Amber2},
new SingleStateToggle { Name = "Red left auto throttle disengage light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunAT[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunAT1},
new SingleStateToggle { Name = "Red right auto throttle disengage light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunAT[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunAT2},
new SingleStateToggle { Name = "Amber left auto throttle disengage light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunAT_Amber[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunAT_Amber1},
new SingleStateToggle { Name = "Amber right auto throttle disengage light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunAT_Amber[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunAT_Amber2},
new SingleStateToggle { Name = "Left FMC light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunFMC[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunFMC1},
new SingleStateToggle { Name = "Right FMC light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunFMC[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunFMC2},
new SingleStateToggle { Name = "Stab out of trim light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunSTAB_OUT_OF_TRIM, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunSTAB_OUT_OF_TRIM},
new SingleStateToggle { Name = "Anti-skid inop light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunANTI_SKID_INOP, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunANTI_SKID_INOP},
new SingleStateToggle { Name = "Left DU selector", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_MainPanelDUSel[0], AvailableStates = _captPanelDuSelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_MainPanelDUSel1},
new SingleStateToggle { Name = "Right DU selector", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_MainPanelDUSel[1], AvailableStates = _foPanelDuSelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_MainPanelDUSel2},
new SingleStateToggle { Name = "Left lower DU selector", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_LowerDUSel[0], AvailableStates = _captLowerDuSelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_LowerDUSel1},
new SingleStateToggle { Name = "Right lower DU selector", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_LowerDUSel[1], AvailableStates = _foLowerDuSelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_LowerDUSel2},
new SingleStateToggle { Name = "RMI #1", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_RMISelector1_VOR, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_RMISelector1_VOR},
new SingleStateToggle { Name = "RMI #2", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_RMISelector2_VOR, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_RMISelector2_VOR},
new SingleStateToggle { Name = "Speed ref  selector", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_SpdRefSelector, AvailableStates = _speedRefSelectorStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_SpdRefSelector},
new SingleStateToggle { Name = "Break pressure needle", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.High, Offset = Aircraft.pmdg737.MAIN_BrakePressNeedle, AvailableStates = null, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_BrakePressNeedle},
new SingleStateToggle { Name = "Left flaps needle", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.High, Offset = Aircraft.pmdg737.MAIN_TEFlapsNeedle[0], AvailableStates = null, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_TEFlapsNeedle1},
new SingleStateToggle { Name = "Right flaps needle", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.High, Offset = Aircraft.pmdg737.MAIN_TEFlapsNeedle[1], AvailableStates = null, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_TEFlapsNeedle2},
new SingleStateToggle { Name = "Flaps in transit light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunLE_FLAPS_TRANSIT, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunLE_FLAPS_TRANSIT},
new SingleStateToggle { Name = "Flaps extended light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunLE_FLAPS_EXT, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunLE_FLAPS_EXT},
new SingleStateToggle { Name = "Gear lever", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_GearLever, AvailableStates = _gearLeverStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_GearLever},
new SingleStateToggle { Name = "Nose gear in transit light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunGEAR_transit[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunGEAR_transit_nose},
new SingleStateToggle { Name = "Left gear in transit light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunGEAR_transit[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunGEAR_transit_left},
new SingleStateToggle { Name = "Right gear in transit light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunGEAR_transit[2], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunGEAR_transit_right},
new SingleStateToggle { Name = "Nose gear locked light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunGEAR_locked[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunGEAR_locked_nose},
new SingleStateToggle { Name = "Left gear locked light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunGEAR_locked[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunGEAR_locked_left},
new SingleStateToggle { Name = "Right gear locked light", PanelName = "Forward", PanelSection = "Main", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.MAIN_annunGEAR_locked[2], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.MAIN_annunGEAR_locked_right},

// --panel: Lower Forward
// --section: lights

new SingleStateToggle { Name = "Left main panel lighting", PanelName = "Lower Forward", PanelSection = "Lights", Type = PanelObjectType.Dial, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_MainPanelKnob[0], AvailableStates = null, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_MainPanelKnob1},
new SingleStateToggle { Name = "Right main panel lighting", PanelName = "Lower Forward", PanelSection = "Lights", Type = PanelObjectType.Dial, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_MainPanelKnob[1], AvailableStates = null, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_MainPanelKnob2},
new SingleStateToggle { Name = "Main panel Backlight", PanelName = "Lower Forward", PanelSection = "Lights", Type = PanelObjectType.Dial, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_BackgroundKnob, AvailableStates = null, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_BackgroundKnob},
new SingleStateToggle { Name = "AFDS flood light", PanelName = "Lower Forward", PanelSection = "Lights", Type = PanelObjectType.Dial, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_AFDSFloodKnob, AvailableStates = null, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_AFDSFloodKnob},
new SingleStateToggle { Name = "Left outboard DU brightness", PanelName = "Lower Forward", PanelSection = "Lights", Type = PanelObjectType.Dial, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_OutbdDUBrtKnob[0], AvailableStates = null, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_OutbdDUBrtKnob1},
new SingleStateToggle { Name = "Right outboard DU brightness", PanelName = "Lower Forward", PanelSection = "Lights", Type = PanelObjectType.Dial, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_OutbdDUBrtKnob[1], AvailableStates = null, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_OutbdDUBrtKnob2},
new SingleStateToggle { Name = "Left inboard DU brightness", PanelName = "Lower Forward", PanelSection = "Lights", Type = PanelObjectType.Dial, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_InbdDUBrtKnob[0], AvailableStates = null, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_InbdDUBrtKnob1},
new SingleStateToggle { Name = "Right inboard DU brightness", PanelName = "Lower Forward", PanelSection = "Lights", Type = PanelObjectType.Dial, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_InbdDUBrtKnob[1], AvailableStates = null, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_InbdDUBrtKnob2},
new SingleStateToggle { Name = "Left inboard map brightness", PanelName = "Lower Forward", PanelSection = "Lights", Type = PanelObjectType.Dial, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_InbdDUMapBrtKnob[0], AvailableStates = null, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_InbdDUMapBrtKnob1},
new SingleStateToggle { Name = "Right inboard map brightness", PanelName = "Lower Forward", PanelSection = "Lights", Type = PanelObjectType.Dial, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_InbdDUMapBrtKnob[1], AvailableStates = null, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_InbdDUMapBrtKnob2},
new SingleStateToggle { Name = "Upper DU brightness", PanelName = "Lower Forward", PanelSection = "Lights", Type = PanelObjectType.Dial, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_UpperDUBrtKnob},
new SingleStateToggle {Name = "Lower DU brightness", PanelName = "Lower Forward", PanelSection = "Lights", Type = PanelObjectType.Dial, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_LowerDUBrtKnob, AvailableStates = null, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_LowerDUBrtKnob},
new SingleStateToggle { Name = "Lower DU map brightness", PanelName = "Lower Forward", PanelSection = "Lights", Type = PanelObjectType.Dial, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.LTS_LowerDUMapBrtKnob, AvailableStates = null, shouldSpeak = Properties.pmdg737_offsets.Default.LTS_LowerDUMapBrtKnob},
new SingleStateToggle { Name = "GPWS inop light", PanelName = "Lower Forward", PanelSection = "Lights", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.GPWS_annunINOP, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg737_offsets.Default.GPWS_annunINOP},
new SingleStateToggle { Name = "GPWS flaps inhibit", PanelName = "Lower Forward", PanelSection = "Lights", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.GPWS_FlapInhibitSw_NORM, AvailableStates = _normalOrOnStates, shouldSpeak = Properties.pmdg737_offsets.Default.GPWS_FlapInhibitSw_NORM},
new SingleStateToggle { Name = "GPWS gear inhibit", PanelName = "Lower Forward", PanelSection = "Lights", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.GPWS_GearInhibitSw_NORM, AvailableStates = _normalOrOnStates, shouldSpeak = Properties.pmdg737_offsets.Default.GPWS_GearInhibitSw_NORM},
new SingleStateToggle { Name = "GPWS terrain inhibit", PanelName = "Lower Forward", PanelSection = "Lights", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.GPWS_TerrInhibitSw_NORM, AvailableStates = _normalOrOnStates, shouldSpeak = Properties.pmdg737_offsets.Default.GPWS_TerrInhibitSw_NORM},

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
        } // CurrentElevatorTrim

        public static double CurrentSpeedBrakePosition
        {

            /*
             * Named detents are below.
             * 0: Off
             * 100: Armed
             * 250: 50% deployed.
             * 272: Flight;
             * 400: 100% deployed.
             */
            get => FSUIPCConnection.ReadLVar("SWITCH_679_73X");
                                               }

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
            if(Aircraft.pmdg737.MCP_VertSpeedBlank.Value == 1)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_VS_SWITCH, ClkR);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_VS_SWITCH, ClkL);
            }
        } // VerticalSpeedIntervene
    
        public static void SetVerticalSpeed(string verticalSpeedText)
        {
            if(int.TryParse(verticalSpeedText, out int speed))
            {
                speed = speed - 10000;
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_VS_SET, speed);
            }
                    } // SetVerticalSpeed

        public static void ShowVerticalSpeedBox()
        {
            MCPComponents["vertical"].Show();
        } // ShowVerticalSpeedBox

        public static void SpeedIntervene()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_SPD_INTV_SWITCH, Aircraft.ClkL);
        } // SpeedIntervene

        public static void ShowNavigationBox()
        {
            MCPComponents["navigation"].Show();
        }

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
        } // HydraulicsEnginePump2

        public static void SetPressFltAlt(int altitude)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_PRESS_FLT_ALT_SET, altitude);
        } // SetPressFltAltitude

        public static void SetPressLndAltitude(int altitude)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_PRESS_LAND_ALT_SET, altitude);
        } // SetPressLndAltitude.

        public static void AirSourceSelector(int position)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_AIRCOND_TEMP_SOURCE_SELECTOR_800, position);
        } // AirSourceSelector

        public static void PressModeSelector(int position)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_PRESS_SELECTOR, position);
        } // PressModeSelector

        public static void LeftPackSelector(int position)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_PACK_L_SWITCH, position);
        } // LeftPackSelector

        public static void RightPackSelector(int position)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_PACK_R_SWITCH, position);
        } // RightPackSelector

        public static void LeftBleedOff()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_ENG_1_SWITCH, ClkR);
        } // LeftBleedOff

        public static void LeftBleedOn()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_ENG_1_SWITCH, ClkL);
        } // LeftBleedOn.

        public static void RightBleedOff()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_ENG_2_SWITCH, ClkR);
        } // RightBleedOff

        public static void RightBleedOn()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_ENG_2_SWITCH, ClkL);
        } // RightBleedOn

        public static void APUBleedOn()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_APU_SWITCH, ClkL);
        } // APUBleedOn

        public static void APUBleedOff()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_APU_SWITCH, ClkR);
        } // APUBleedOff

        public static void LeftRecircFanOn()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_RECIRC_FAN_L_SWITCH, ClkL);
        } // LeftRecircFanOn

        public static void LeftRecircFanOff()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_RECIRC_FAN_L_SWITCH, ClkR);
        } // LeftRecircFanOff

        public static void RightRecircFanOn()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_RECIRC_FAN_R_SWITCH, ClkL);
        } // RightRecircFanOn

        public static void RightRecircFanOff()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_RECIRC_FAN_R_SWITCH, ClkR);


        } // RightRecircFanOff

        public static void AirTrimOn()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_AIRCOND_TRIM_AIR_SWITCH_800, ClkL);
        } // AirTrimOn

        public static void AirTrimOff()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_AIRCOND_TRIM_AIR_SWITCH_800, ClkR);
        } // AirTrimOff

        public static void OutflowValveSelector(int position)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_PRESS_VALVE_SWITCH, position);
        } // OutflowValveSelector

        public static void IsolationValveSelector(int position)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_ISOLATION_VALVE_SWITCH, position);
        } // IsolationValveSelector

public static void APUSelector(int position)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_APU_START, position);
        } // APUSelector

        public static void Engine1StartSelector(int position)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_L_ENGINE_START, position);
        } // Engine1StartSelector

        public static void Eng1FuelSelector(int position)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CONTROL_STAND_ENG1_START_LEVER, position);
        } // Eng1FuelSelector

        public static void Engine2StartSelector(int position)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_R_ENGINE_START, position);
        } // Engine2StartSelector

        public static void Eng2FuelSelector(int position)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CONTROL_STAND_ENG2_START_LEVER, position);
        } // Eng2FuelSelector

        public static void IgnitionSelector(int position)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_IGN_SEL, position);
        } // IgnitionSelector

        public static void LeftRetractableLandingLights(int position)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_L_RETRACT, position);
        } // LeftRetractableLandingLights

        public static void RightRetractableLandingLights(int position)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_R_RETRACT, position);
        } // RightRetractableLandingLights

        public static void LeftFixedLandingLight()
        {
            if (Aircraft.pmdg737.LTS_LandingLtFixedSw[0].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_L_FIXED, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_L_FIXED, ClkR);
            }
        } // LeftFixedLandingLights

        public static void RightFixedLandingLights()
        {
            if (Aircraft.pmdg737.LTS_LandingLtFixedSw[1].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_R_FIXED, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_R_FIXED, ClkR);
            }
                    } // RightFixedLandingLights

public static void LeftTurnOffLights()
        {
            if (Aircraft.pmdg737.LTS_RunwayTurnoffSw[0].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_L_TURNOFF, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_L_TURNOFF, ClkR);
            }
        }// LeftTurnOffLights

        public static void RightTurnOffLights()
        {
            if (Aircraft.pmdg737.LTS_RunwayTurnoffSw[1].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_R_TURNOFF, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_R_TURNOFF, ClkR);
            }

        } // RightTurnOffLights

        public static void TaxiLights()
        {
            if(Aircraft.pmdg737.LTS_TaxiSw.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_TAXI, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_TAXI, ClkR);
            }
        } // TaxiLights
// PositionLights is the main function that cycles through the different light modes.
// Each mode has its own function to make it easier to read.
        public static void PositionLights()
        {
            if(FSUIPCConnection.ReadLVar("switch_123_73X") == 0)
            {
                PositionLightsOff();
            }
            else if(FSUIPCConnection.ReadLVar("switch_123_73X") == 50)
            {
                PositionLightsSteady();
            }
            else
            {
                PositionLightsStrobe();
            }
                    } // PositionLights

        private static void PositionLightsStrobe()
        {
            if(FSUIPCConnection.ReadLVar("switch_123_73X") != 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_POS_STROBE, ClkR);
                                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_POS_STROBE, ClkR);
            }
        } // PositionLightsStrobe

        private static void PositionLightsOff()
        {
            if (FSUIPCConnection.ReadLVar("switch_123_73X") > 50)
            {
                                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_POS_STROBE, ClkR);
            }
else            if (FSUIPCConnection.ReadLVar("switch_123_73X") < 50)
            {
                                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_POS_STROBE, ClkL);
            }
        } // PositionLightsOff

        public static void PositionLightsSteady()
        {
            if(FSUIPCConnection.ReadLVar("switch_123_73X") != 100)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_POS_STROBE, ClkL);
                                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_POS_STROBE, ClkL);
            }
        } // PositionLightsSteady

        public static void LogoLights()
        {
            if(Aircraft.pmdg737.LTS_LogoSw.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_LOGO, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_LOGO, ClkR);
            }
        } // LogoLights

        public static void AntiCollisionLights()
        {
            if(Aircraft.pmdg737.LTS_AntiCollisionSw.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_ANT_COL, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_ANT_COL, ClkR);
            }
        } // AntiCollisionLights

        public static void WingLights()
        {
            if(Aircraft.pmdg737.LTS_WingSw.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_WING, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_WING, ClkR);
            }
        } // WingLights

        public static void WheelWellLights()
        {
            if(Aircraft.pmdg737.LTS_WheelWellSw.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_WHEEL_WELL, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_WHEEL_WELL, ClkR);
            }
        } // WheelWellLights

        public static void ChangeOver()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_CO_SWITCH, ClkL);
        } // ChangeOver

        public static void AutoThrottle()
        {
            if(Aircraft.pmdg737.MCP_ATArmSw.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_AT_ARM_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_AT_ARM_SWITCH, ClkR);
            }
        } // AutoThrottle

        public static void N1SetSelector()
        {
            if(FSUIPCConnection.ReadLVar("L:switch_466_73X") < 30)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MPM_N1SET_SELECTOR, Inc);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MPM_N1SET_SELECTOR, 0);
            }
        } // N1SetSelector

        public static void N1()
        {
            if(Aircraft.pmdg737.MCP_annunN1.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_N1_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_N1_SWITCH, ClkR);
            }
        } // N1

        public static void SpeedHold()
        {
            if(Aircraft.pmdg737.MCP_annunSPEED.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_SPEED_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_SPEED_SWITCH, ClkR);
            }
        } // SpeedHold

        public static void SpoilerAToggle()
        {
            if (Aircraft.pmdg737.FCTL_Spoiler_Sw[0].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_SPOILER_A_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_SPOILER_A_SWITCH, ClkR);
            }
        } // SpoilerAToggle

        public static void SpoilerBToggle()
        {
            if (Aircraft.pmdg737.FCTL_Spoiler_Sw[1].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_SPOILER_B_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_SPOILER_B_SWITCH, ClkR);
            }

        } // SpoilerBToggle

        public static void SetSpeed(string speedTxt)
        {
            if (SpeedType == AircraftSpeed.Indicated)
            {
                if (int.TryParse(speedTxt, out int speed))
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_IAS_SET, speed);
                }
            }
            else
            {
                if (double.TryParse(speedTxt, out double speed))
                {
                    speed /= 0.01;
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_MACH_SET, (int)speed);
                }
            }

        } // SetSpeed

        public static void AutoBrake(int position)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MPM_AUTOBRAKE_SELECTOR, position);
        } // AutoBrake

        public static void SpeedBrakeIncrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CONTROL_STAND_SPEED_BRAKE_LEVER, ClkL);
        } // SpeedBrakeIncrease

        public static void SpeedBrakeDecrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CONTROL_STAND_SPEED_BRAKE_LEVER, ClkR);
        } // SpeedBrakeDecrease

        public static void SpeedBrakeArm()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CONTROL_STAND_SPEED_BRAKE_LEVER_ARM, ClkL);
        } // SpeedBrakeArm

        public static void SpeedBrakeFlight()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CONTROL_STAND_SPEED_BRAKE_LEVER_FLT_DET, ClkL);
        } // SpeedBrakeFlight

        public static void SpeedBrakeFull()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CONTROL_STAND_SPEED_BRAKE_LEVER_UP, ClkL);
        } // SpeedBrakeFull

        public static void SpeedBrakeHalf()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CONTROL_STAND_SPEED_BRAKE_LEVER_50PCT, ClkL);
        } // SpeedBrakeHalf

        public static void SpeedBrakeOff()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CONTROL_STAND_SPEED_BRAKE_LEVER_DOWN, ClkL);
        } // SpeedBrakeOff

        public static void FD1()
        {
            if (Aircraft.pmdg737.MCP_FDSw[0].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_FD_SWITCH_L, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_FD_SWITCH_L, ClkR);
            }
        } // FD1

        public static void FD2()
        {
            if (Aircraft.pmdg737.MCP_FDSw[1].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_FD_SWITCH_R, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_FD_SWITCH_R, ClkR);
            }
        } // FD2

        public static void ApproachMode()
        {
            if(Aircraft.pmdg737.MCP_annunAPP.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_APP_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_APP_SWITCH, ClkR);
            }
        } // ApproachMode

        public static void LocalizerHold()
        {
            if(Aircraft.pmdg737.MCP_annunVOR_LOC.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_VOR_LOC_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_VOR_LOC_SWITCH, ClkR);
            }
        } // LocalizerHold

        public static void CMDA()
        {
            if(Aircraft.pmdg737.MCP_annunCMD_A.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_CMD_A_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_CMD_A_SWITCH, ClkR);
            }
        } // CMDA

        public static void CWSA()
        {
            if(Aircraft.pmdg737.MCP_annunCWS_A.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_CWS_A_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_CWS_A_SWITCH, ClkR);
            }
        } // CWSA

        public static void CMDB()
        {
            if(Aircraft.pmdg737.MCP_annunCMD_B.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_CMD_B_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_CMD_B_SWITCH, ClkR);
            }
        } // CMDB

        public static void CWSB()
        {
            if(Aircraft.pmdg737.MCP_annunCWS_B.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_CWS_B_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_CWS_B_SWITCH, ClkR);
            }
        } // CWSB

        public static void DisengageBar()
        {
            if(Aircraft.pmdg737.MCP_DisengageBar.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_DISENGAGE_BAR, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_DISENGAGE_BAR, ClkR);
            }
        } // DisengageBar

        public static void BankLimiter()
        {
            var counter = Aircraft.pmdg737.MCP_BankLimitSel.Value;
            if(counter == 4)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_BANK_ANGLE_SELECTOR, 0);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_BANK_ANGLE_SELECTOR, counter+1);
            }
                                                        } // BankLimiter

        public static void NoseWheelSteering()
        {
if(Aircraft.pmdg737.MAIN_NoseWheelSteeringSwNORM.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_NOSE_WHEEL_STEERING_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_NOSE_WHEEL_STEERING_SWITCH, ClkR);
            }
        } // NoseWheelSteering

        public static void LeftDisengageTest()
        {
            if (Aircraft.pmdg737.MAIN_DisengageTestSelector[0].Value != 2)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_DSP_CPT_DISENGAGE_TEST_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_DSP_CPT_DISENGAGE_TEST_SWITCH, 0);
            }
        } // LeftDisengageTest

        public static void RightDisengageTest()
        {
            if (Aircraft.pmdg737.MAIN_DisengageTestSelector[1].Value != 2)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_DSP_FO_DISENGAGE_TEST_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_DSP_FO_DISENGAGE_TEST_SWITCH, 0);
            }
        } // RightDisengageTest

        public static void Lights()
        {
            if(Aircraft.pmdg737.MAIN_LightsSelector.Value != 2)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_DSP_CPT_MASTER_LIGHTS_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_DSP_CPT_MASTER_LIGHTS_SWITCH, 0);
            }
        } // Lights

        public static void FuelFlow()
        {
                if(Aircraft.pmdg737.MAIN_FuelFlowSelector.Value != 2)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MPM_FUEL_FLOW_SWITCH, ClkL);
            }
                else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MPM_FUEL_FLOW_SWITCH, 0);
            }
        } //FuelFlow

        public static void DU1()
        {
            if (Aircraft.pmdg737.MAIN_MainPanelDUSel[0].Value != 4)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_DSP_CPT_MAIN_DU_SELECTOR, Aircraft.pmdg737.MAIN_MainPanelDUSel[0].Value + 1);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_DSP_CPT_MAIN_DU_SELECTOR, 0);
            }
        } // DU1

        public static void DU2()
        {
            if (Aircraft.pmdg737.MAIN_MainPanelDUSel[1].Value != 4)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_DSP_FO_MAIN_DU_SELECTOR, Aircraft.pmdg737.MAIN_MainPanelDUSel[1].Value + 1);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_DSP_FO_MAIN_DU_SELECTOR, 0);
            }
        } // DU2

        public static void LowerDU1()
        {
            if (Aircraft.pmdg737.MAIN_LowerDUSel[0].Value != 2)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_DSP_CPT_LOWER_DU_SELECTOR, Aircraft.pmdg737.MAIN_LowerDUSel[0].Value + 1);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_DSP_CPT_LOWER_DU_SELECTOR, 0);
            }
        } // Lower DU1

        public static void LowerDU2()
        {
            if (Aircraft.pmdg737.MAIN_LowerDUSel[1].Value != 2)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_DSP_FO_LOWER_DU_SELECTOR, Aircraft.pmdg737.MAIN_LowerDUSel[1].Value + 1);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_DSP_FO_LOWER_DU_SELECTOR, 0);
            }
        } // Lower DU2

        public static void RMI1()
        {
            if(Aircraft.pmdg737.MAIN_RMISelector1_VOR.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_RMI_LEFT_SELECTOR, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_RMI_LEFT_SELECTOR, ClkR);
            }
        }// RMI1

        public static void RMI2()
        {
            if(Aircraft.pmdg737.MAIN_RMISelector2_VOR.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_RMI_RIGHT_SELECTOR, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_RMI_RIGHT_SELECTOR, ClkR);
            }
        } // RMI2

        public static void SpeedRef()
        {
if(Aircraft.pmdg737.MAIN_SpdRefSelector.Value != 6)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MPM_SPEED_REFERENCE_SELECTOR, Aircraft.pmdg737.MAIN_SpdRefSelector.Value + 1);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MPM_SPEED_REFERENCE_SELECTOR, 0);
            }
        } // SpeedRef

public static void Gear()
        {
            if(Aircraft.pmdg737.MAIN_GearLever.Value != 2)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_GEAR_LEVER, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_GEAR_LEVER, 0);
            }
        } // Gear

public static void LeftLowerMainPanelLightIncrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_CAPT_MAIN_PANEL_BRT, Inc);
        } // LeftLowerMainPanelLightIncrease

        public static void LeftLowerMainPanelLightDecrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_CAPT_MAIN_PANEL_BRT, Dec);
        } // LeftLowerMainPanelLightDecrease

public static void RightMainPanelLightIncrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_FO_MAIN_PANEL_BRT, Inc);
        } // RightMainPanelLightIncrease

        public static void RightMainPanelLightDecrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_FO_MAIN_PANEL_BRT, Dec);
        } // RightMainPanelDecrease

        public static void MainPanelBackLightIncrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_CAPT_BACKGROUND_BRT, Inc);
        } // MainPanelBackLightIncrease

        public static void MainPanelBackLightDecrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_CAPT_BACKGROUND_BRT, Dec);
        } // MainPanelBackLightDecrease

        public static void AFDSFloodLightIncrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_CAPT_AFDS_BRT, Inc);
        } // AFDSFloodLightIncrease

        public static void AFDSFloodLightDecrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_CAPT_AFDS_BRT, Dec);
        } // AFDSFloodLightDecrease

        public static void FlapsInhibit()
        {
            if(Aircraft.pmdg737.GPWS_FlapInhibitSw_NORM.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_GPWS_FLAP_INHIBIT_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_GPWS_FLAP_INHIBIT_SWITCH, ClkR);
            }
        } // FlapsInhibit

        public static void GearInhibit()
        {
            if(Aircraft.pmdg737.GPWS_GearInhibitSw_NORM.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_GPWS_GEAR_INHIBIT_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_GPWS_GEAR_INHIBIT_SWITCH, ClkR);
            }
        } // GearInhibit

        public static void TerrainInhibit()
        {
            if(Aircraft.pmdg737.GPWS_TerrInhibitSw_NORM.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_GPWS_TERR_INHIBIT_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_GPWS_TERR_INHIBIT_SWITCH, ClkR);
            }
        } // TerrainInhibit

        public static void LeftOutbdDuLightIncrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_CAPT_OUTBD_DU_BRT, Inc);
        } // LeftOutbdDuLightIncrease

        public static void LeftOutbdDuLightDecrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_CAPT_OUTBD_DU_BRT, Dec);
        } // LeftOutbdDuLightDecrease

        public static void RightOutbdDuLightIncrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_FO_OUTBD_DU_BRT, Inc);
        } // RightOutbdDuLightIncrease

        public static void RightOutbdDuLightDecrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_FO_OUTBD_DU_BRT, Dec);
        } // RightOutbdDuLightDecrease

        public static void LeftInbdDuLightIncrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_CAPT_INBD_DU_BRT, Inc);
        } // LeftInbdDuLightIncrease

        public static void LeftInbdDuLightDecrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_CAPT_INBD_DU_BRT, Dec);
        } // LeftInbdDuLightDecrease

        public static void RightInbdDuLightIncrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_FO_INBD_DU_BRT, Inc);
        } // RightInbdDuLightIncrease

        public static void RightInbdDuLightDecrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_FO_INBD_DU_BRT, Dec);
        } // RightInbdDuLightDecrease

        public static void LeftInbdMapLightIncrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_CAPT_INBD_DU_INNER_BRT, Inc);
        } // LeftInbdMapLightIncrease

        public static void LeftInbdMapLightDecrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_CAPT_INBD_DU_INNER_BRT, Dec);
        } // LeftInbdMapLightDecrease

        public static void RightInbdMapLightIncrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_FO_INBD_DU_INNER_BRT, Inc);
        } // RightInbdMapLightIncrease

        public static void RightInbdMapLightDecrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_FO_INBD_DU_INNER_BRT, Dec);
        } // RightInbdMapLightDecrease

        public static void UpperDuLightIncrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_CAPT_UPPER_DU_BRT, Inc);
        } // UpperDuLightIncrease

        public static void UpperDuLightDecrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_CAPT_UPPER_DU_BRT, Dec);
        } // UpperDuLightDecrease

        public static void LowerDuLightIncrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_CAPT_LOWER_DU_BRT, Inc);
        } // LowerDuLightIncrease

        public static void LowerDuLightDecrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_CAPT_LOWER_DU_BRT, Dec);
        } // LowerDuLightDecrease

        public static void LowerMapLightIncrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_CAPT_LOWER_DU_INNER_BRT, Inc);
        } // LowerMapLightIncrease

        public static void LowerMapLightDecrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_LWRMAIN_CAPT_LOWER_DU_INNER_BRT, Dec);
        } // LowerMapLightDecrease
                  } // End PMDG737Aircraft.
    } // End namespace.
