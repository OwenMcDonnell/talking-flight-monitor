using tfm.PMDG;
using tfm.PMDG.PanelObjects;
using FSUIPC;
using DavyKager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public static  void CalculateSwitchPosition(PMDG_737_NGX_Control control, int pos, int sel)
        {
            // there are several PMDG controls that cannot be set by direct parameter entry.
            // this function calculates the number of increment or decrement commands that need to be set in order to set a switch to a specific position.
            // We pass in a PMDG control number, an offset to read the current switch position, and the position we want the switch set to.
            if (pos > sel)
            {
                for (int i = 0; i < pos - sel; i++)
                {
                    FSUIPCConnection.SendControlToFS(control, Dec);
                }

            }
            if (pos < sel)
            {
                for (int i = 0; i < sel - pos; i++)
                {
                    FSUIPCConnection.SendControlToFS(control, Inc);

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

        private static Dictionary<byte, string> _offOrOnStates = new Dictionary<byte, string>
        {
            {0, "on" },
            {1, "off" },
        };
        private static Dictionary<byte, string> _autoOrOffStates = new Dictionary<byte, string>
        {
            {0, "off" },
            {1, "auto" },
        };

        private static Dictionary<byte, string> _standbyPowerStates = new Dictionary<byte, string>
        {
            { 0, "off" },
            {1, "auto" },
            {2, "battery" },
        };

        private static Dictionary<byte, string> _testOrOffStates = new Dictionary<byte, string>
        {
            {0, "off" },
            {1, "test" },
        };
        private static Dictionary<byte, string> _batteryOrOffStates = new Dictionary<byte, string>
        {
            {0, "off" },
            {1, "battery" },
        };

        private static Dictionary<byte, string> _cargoTempStates = new Dictionary<byte, string>
        {
            {0, "off" },
            {1, "low" },
            {2, "high" },
        };

        private static Dictionary<byte, string> _apuStates = new Dictionary<byte, string>
        {
            {0, "off" },
            {1, "on" },
            {2, "start" },
        };
        private static Dictionary<byte, string> _IRSDisplaySelectorStates = new Dictionary<byte, string>
        {
                        {1, "TK/GS" },
            {2, "PPOS" },
            {3, "WIND" },
            {4, "HDG/STAT" },
        };
        private static Dictionary<byte, string> _IRSSysDisplayStates = new Dictionary<byte, string>
        {
            { 0, "left" },
            {1, "right" },
        };

        private static Dictionary<byte, string> _momentaryControlState = new Dictionary<byte, string>
        {
            {1, "pressed" },
        };

        private static Dictionary<byte, string> _connectOrDisconnectStates = new Dictionary<byte, string>
        {
            {0, "disconnected" },
            {1, "connected" },
        };

        private static Dictionary<byte, string> _availableOrUnavailableStates = new Dictionary<byte, string>
        {
            {0, "unavailable" },
            {1, "available" },
        };

        private static Dictionary<byte, string> _wiperStates = new Dictionary<byte, string>
        {
            {0, "off" },
            {1, "intermittent" },
            {2, "low" },
            {3, "high" },
        };

        private static Dictionary<byte, string> _armedOnOrOffStates = new Dictionary<byte, string>
        {
            {0, "off" },
            {1, "armed" },
            {2, "on" },
        };

        private static Dictionary<byte, string> _autoOnOrOffStates = new Dictionary<byte, string>
        {
            {0, "off" },
            {1, "auto" },
            {2, "on" },
        };

        private static Dictionary<byte, string> _indoorLightTestStates = new Dictionary<byte, string>
        {
            {0, "test" },
            {1, "bright" },
            {2, "dim" },
        };

        private static Dictionary<byte, string> _apuFireHandleStates = new Dictionary<byte, string>
        {
            {0, "normal" },
            {1, "pulled" },
            {2, "turned left" }, // Momentary position.
            {3, "turned right" }, // Momentary position.
        };

        private static Dictionary<byte, string> _engineStartModeStates = new Dictionary<byte, string>
        {
            {0, "start" },
            {1, "normal" },
        };

        private static Dictionary<byte, string> _fuelToRemainStates = new Dictionary<byte, string>
        {
            {0, "pushed" },
            {1, "pulled" },
        };

        private static Dictionary<byte, string> _fuelSelectorStates = new Dictionary<byte, string>
        {
            {0, "decrease" },
            {1, "neutral" },
            {2, "increase" },
        };

        private static Dictionary<byte, string> _neutralClosedOrOpenStates = new Dictionary<byte, string>
        {
            {0, "opened" },
            {1, "neutral" },
            {2, "closed" },
        };

        private static Dictionary<byte, string> _neutralIncreaseOrDecrease = new Dictionary<byte, string>
        {
            {0, "decrease" },
            {1, "neutral" },
            {2, "increase" },
        };
        private static Dictionary<byte, string> _irsModeSelect = new Dictionary<byte, string>
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
                new SingleStateToggle { Name = "PSEU warning light",  PanelName = "Aft Overhead", PanelSection = "PSEU", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Medium, AvailableStates = _onOrOffStates, Offset = Aircraft.pmdg737.WARN_annunPSEU },

// --section: Service interphone
new SingleStateToggle {Name = "Service interphone", PanelName = "Aft Overhead", PanelSection = "Service interphone", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.COMM_ServiceInterphoneSw, AvailableStates = _onOrOffStates },

// --section: lights
new SingleStateToggle { Name = "Dome lights", PanelName = "Aft Overhead", PanelSection = "Lights", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.LTS_DomeWhiteSw, AvailableStates = _domeLightStates },

// --section: Engines
new SingleStateToggle { Name = "Engine #1 EEC", PanelName = "Aft Overhead", PanelSection = "Engines", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.ENG_EECSwitch[0], AvailableStates = _onOrOffStates },
new SingleStateToggle { Name = "Engine #2 EEC", PanelName = "Aft Overhead", PanelSection = "Engines", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.ENG_EECSwitch[1], AvailableStates = _onOrOffStates },
new SingleStateToggle { Name = "Engine #1 reverser", PanelName = "Aft Overhead", PanelSection = "Engines", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.ENG_annunREVERSER[0], AvailableStates = _onOrOffStates },
new SingleStateToggle { Name = "Engine #2 reverser", PanelName = "Aft Overhead", PanelSection = "Engines", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.ENG_annunREVERSER[1], AvailableStates = _onOrOffStates },
new SingleStateToggle { Name = "Engine #1 control", PanelName = "Aft Overhead", PanelSection = "Engines", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.ENG_annunENGINE_CONTROL[0], AvailableStates = _onOrOffStates },
new SingleStateToggle { Name = "Engine #2 control", PanelName = "Aft Overhead", PanelSection = "Engines", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.ENG_annunENGINE_CONTROL[1], AvailableStates = _onOrOffStates },
new SingleStateToggle { Name = "Engine #1 alternate", PanelName = "Aft Overhead", PanelSection = "Engines", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.ENG_annunALTN[0], AvailableStates = _onOrOffStates },
new SingleStateToggle { Name = "Engine #2 alternate", PanelName = "Aft Overhead", PanelSection = "Engines", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.ENG_annunALTN[1], AvailableStates = _onOrOffStates },

// --section: Oxygen
new SingleStateToggle { Name = "Oxygen level", PanelName = "Aft Overhead", PanelSection = "Oxygen", Type = PanelObjectType.Slider, Verbosity = AircraftVerbosity.Medium, Offset = Aircraft.pmdg737.OXY_Needle, AvailableStates = null },
new SingleStateToggle { Name = "Oxygen", PanelName = "Aft Overhead", PanelSection = "Oxygen", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.OXY_SwNormal, AvailableStates = _normalOrOnStates},
new SingleStateToggle { Name = "Passenger oxygen", PanelName = "Aft Overhead", PanelSection = "Oxygen", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.OXY_annunPASS_OXY_ON, AvailableStates = _onOrOffStates },

// --section: Gear
new SingleStateToggle { Name = "Nose gear light", PanelName = "Aft Overhead", PanelSection = "Gear", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.GEAR_annunOvhdNOSE, AvailableStates = _downOrUpStates},
new SingleStateToggle { Name = "Left gear light", PanelName = "Aft Overhead", PanelSection = "Gear", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.GEAR_annunOvhdLEFT, AvailableStates = _downOrUpStates},
new SingleStateToggle { Name = "Right gear light", PanelName = "Aft Overhead", PanelSection = "Gear", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.GEAR_annunOvhdRIGHT, AvailableStates = _downOrUpStates},

// --section: Flight recorder
new SingleStateToggle { Name = "Flight recorder", PanelName = "Aft Overhead", PanelSection = "Flight recorder", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FLTREC_SwNormal, AvailableStates = _normalOrTestStates},
new SingleStateToggle { Name = "Flight recorder light", PanelName = "Aft Overhead", PanelSection = "Flight recorder", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FLTREC_annunOFF, AvailableStates = _offOrOnStates },

// --panel: Forward Overhead
// --section: Flight Controls
new SingleStateToggle { Name = "Capt. flight controls", PanelName = "Forward Overhead", PanelSection = "Flight Controls", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FCTL_FltControl_Sw[0], AvailableStates = _flightControlStates},
new SingleStateToggle { Name = "F/O flight controls", PanelName = "Forward Overhead", PanelSection = "Flight Controls", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FCTL_FltControl_Sw[1], AvailableStates = _flightControlStates},
new SingleStateToggle { Name = "Left spoilers", PanelName = "Forward Overhead", PanelSection = "Flight Controls", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FCTL_Spoiler_Sw[0], AvailableStates = _onOrOffStates},
new SingleStateToggle { Name = "Right spoilers", PanelName = "Forward Overhead", PanelSection = "Flight Controls", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FCTL_Spoiler_Sw[1], AvailableStates = _onOrOffStates},
new SingleStateToggle { Name = "Yaw damper", PanelName = "Forward Overhead", PanelSection = "Flight Controls", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FCTL_YawDamper_Sw, AvailableStates = _onOrOffStates},
new SingleStateToggle { Name = "Alternate flaps", PanelName = "Forward Overhead", PanelSection = "Flight Controls", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg737.FCTL_AltnFlaps_Sw_ARM, AvailableStates = _armedOrOffStates},

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
                    } // End PMDG737Aircraft.
} // End namespace.
