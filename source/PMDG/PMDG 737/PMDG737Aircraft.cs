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
            { 0, "position 1" },
            {1, "position 2" },
            {2, "position 3" },
            {3, "position 4" },
            {4, "position 5" },
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
        public static PanelObject[] PanelControls
        {
            get => new PanelObject[]
            {
                // Aft Forward Panel
                // ADIRU
                new SingleStateToggle {
                    Name = "IRS Display Selector",
                    PanelName = "Aft Overhead",
                    PanelSection = "ADIRU",
                    Offset = Aircraft.pmdg737.IRS_DisplaySelector,
                    Type = PanelObjectType.Switch,
                    Verbosity = AircraftVerbosity.Medium,
                    AvailableStates = _IRSDisplaySelectorStates
                },
                new SingleStateToggle {
                    Name = "IRS Display switch",
                    PanelName = "Aft Overhead",
                    PanelSection = "ADIRU",
                    Offset = Aircraft.pmdg737.IRS_SysDisplay_R,
                    Type = PanelObjectType.Switch,
                    Verbosity = AircraftVerbosity.Medium,
                    AvailableStates = _IRSSysDisplayStates
                },
                new SingleStateToggle {
                    Name = "IRS GPS light",
                    PanelName = "Aft Overhead",
                    PanelSection = "ADIRU",
                    Offset = Aircraft.pmdg737.IRS_annunGPS,
                    Type = PanelObjectType.Annunciator,
                    Verbosity = AircraftVerbosity.Medium,
                    AvailableStates = _onOrOffStates
                },
                new SingleStateToggle {
                    Name = "IRS left aligned",
                    PanelName = "Aft Overhead",
                    PanelSection = "ADIRU",
                    Offset = Aircraft.pmdg737.IRS_annunALIGN[0],
                    Type = PanelObjectType.Annunciator,
                    Verbosity = AircraftVerbosity.Medium,
                    AvailableStates = _onOrOffStates
                },
                new SingleStateToggle {
                    Name = "IRS right aligned",
                    PanelName = "Aft Overhead",
                    PanelSection = "ADIRU",
                    Offset = Aircraft.pmdg737.IRS_annunALIGN[1],
                    Type = PanelObjectType.Annunciator,
                    Verbosity = AircraftVerbosity.Medium,
                    AvailableStates = _onOrOffStates
                },
                new SingleStateToggle
                {
                    Name = "IRS on DC - left",
                    PanelName = "Aft Overhead",
                    PanelSection = "ADIRU",
                    Type = PanelObjectType.Annunciator,
                    Offset = Aircraft.pmdg737.IRS_annunON_DC[0],
                    Verbosity = AircraftVerbosity.High,
                    AvailableStates = _onOrOffStates,
                },
                new SingleStateToggle
                {
                    Name = "IRS on DC - right",
                    PanelName = "Aft Overhead",
                    PanelSection = "ADIRU",
                    Type = PanelObjectType.Annunciator,
                    Offset = Aircraft.pmdg737.IRS_annunON_DC[1],
                    Verbosity = AircraftVerbosity.High,
                    AvailableStates = _onOrOffStates,
                },
                new SingleStateToggle
                {
                    Name = "IRS left fault light",
                    PanelName = "Aft Overhead",
                    PanelSection = "ADIRU",
                    Type = PanelObjectType.Annunciator,
                    Offset = Aircraft.pmdg737.IRS_annunFAULT[0],
                    Verbosity = AircraftVerbosity.High,
                    AvailableStates = _onOrOffStates,
                },
                new SingleStateToggle
                {
                    Name = "IRS right fault light",
                    PanelName = "Aft Overhead",
                    PanelSection = "ADIRU",
                    Type = PanelObjectType.Annunciator,
                    Offset = Aircraft.pmdg737.IRS_annunFAULT[1],
                    Verbosity = AircraftVerbosity.High,
                    AvailableStates = _onOrOffStates,
                },
                new SingleStateToggle
                {
                    Name = "IRS left  DC failure light",
                    PanelName = "Aft Overhead",
                    PanelSection = "ADIRU",
                    Type = PanelObjectType.Annunciator,
                    Offset = Aircraft.pmdg737.IRS_annunDC_FAIL[0],
                    Verbosity = AircraftVerbosity.High,
                    AvailableStates = _onOrOffStates,
                },
                new SingleStateToggle
                {
                    Name = "IRS right DC failure light",
                    PanelName = "Aft Overhead",
                    PanelSection = "ADIRU",
                    Type = PanelObjectType.Annunciator,
                    Offset = Aircraft.pmdg737.IRS_annunDC_FAIL[1],
                    Verbosity = AircraftVerbosity.High,
                    AvailableStates = _onOrOffStates,
                },
                new SingleStateToggle
                {
                    Name = "IRS left mode selector",
                    PanelName = "Aft Overhead",
                    PanelSection = "ADIRU",
                    Type = PanelObjectType.Switch,
                    Offset = Aircraft.pmdg737.IRS_ModeSelector[0],
                    Verbosity = AircraftVerbosity.Low,
                    AvailableStates = _irsModeSelect,

                },
                new SingleStateToggle
                {
                    Name = "IRS right mode selector",
                    PanelName = "Aft Overhead",
                    PanelSection = "ADIRU",
                    Type = PanelObjectType.Switch,
                    Offset = Aircraft.pmdg737.IRS_ModeSelector[1],
                    Verbosity = AircraftVerbosity.Low,
                    AvailableStates = _irsModeSelect,
                },
                // PSEU
                new SingleStateToggle
                {
                    Name = "PSEU warning light",
                    PanelName = "Aft Overhead",
                    PanelSection = "PSEU",
                    Type = PanelObjectType.Annunciator,
                    Verbosity = AircraftVerbosity.Medium,
                    AvailableStates = _onOrOffStates,
                    Offset = Aircraft.pmdg737.WARN_annunPSEU,
                },











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
    } // End PMDG737Aircraft.
} // End namespace.
