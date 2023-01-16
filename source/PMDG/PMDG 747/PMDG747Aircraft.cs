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
    public static      class PMDG747Aircraft
    {

        // MCP boxes.
private static        tfm.PMDG.PMDG_747.McpComponents.AltitudeBox AltitudeBox = new PMDG.PMDG_747.McpComponents.AltitudeBox();
        private static tfm.PMDG.PMDG_747.McpComponents.SpeedBox SpeedBox = new PMDG.PMDG_747.McpComponents.SpeedBox();
        private static tfm.PMDG.PMDG_747.McpComponents.HeadingBox HeadingBox = new PMDG.PMDG_747.McpComponents.HeadingBox();
        private static tfm.PMDG.PMDG_747.McpComponents.VerticalSpeedBox VerticalSpeedBox = new PMDG.PMDG_747.McpComponents.VerticalSpeedBox();
        private static tfm.PMDG.PMDG_747.McpComponents.NavigationBox NavigationBox = new PMDG.PMDG_747.McpComponents.NavigationBox();

        // CDU screens.
        public static PMDG_NGX_CDU_Screen cdu0 = new PMDG_NGX_CDU_Screen(0x5400);
        public static PMDG_NGX_CDU_Screen cdu1 = new PMDG_NGX_CDU_Screen(0x5800);
        public static PMDG_NGX_CDU_Screen cdu2 = new PMDG_NGX_CDU_Screen(0x5C00);

        // constants for PMDG mouse click parameters
        public const int ClkL = 536870912;
        public const int ClkR = -2147483648;
        public const int DBLCLKL = 0x04000000;
        public const int Inc = 16384;
        public const int Dec = 8192;


        public static void CalculateSwitchPosition(PMDG_747QOTSII_Control control, int pos, int sel, bool useClicks = false)
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

        // The MCP components used by outside clients.
        public static Dictionary<string, System.Windows.Forms.Form> MCPComponents
        {
            get => new Dictionary<string, System.Windows.Forms.Form>
            {
                {"altitude", AltitudeBox },
                {"speed", SpeedBox },
                {"heading", HeadingBox },
                {"navigation", NavigationBox },
                {"vertical", VerticalSpeedBox },
            };
        }


        // State dictionaries
        // --state-dictionaries

        private static Dictionary<byte, string> _onOrOffStates = new Dictionary<byte, string>()
        {
            {0, "off" },
            {1, "on" },
        };

        private static Dictionary<byte, string> _armedOrOffStates = new Dictionary<byte, string>()
        {
            {0, "off" },
            {1, "armed" },
        };

        private static Dictionary<byte, string> _speedBrakeStates = new Dictionary<byte, string>()
        {
            {0, "down" },
            {25, "armed" },
            {62, "flt" },
            {100, "up" },
                    };

        private static Dictionary<byte, string> _autoBrakeStates = new Dictionary<byte, string>()
        {
            {0, "RTO" },
            {1, "off" },
            {2, "disarm" },
            {3, "1" },
            {4, "2" },
            {5, "auto" },
        };

        private static Dictionary<byte, string> _bankLimitSelectorStates = new Dictionary<byte, string>()
        {
            {0, "auto" },
            {1, "5" },
            {2, "10" },
            {3, "15" },
            { 4, "20" },
            {5, "25" },
        };

        private static Dictionary<byte, string> _offOrOnStates = new Dictionary<byte, string>()
        {
            {0, "on" },
            {1, "off" },
        };

        private static Dictionary<byte, string> _openOrClosedStates = new Dictionary<byte, string>()
        {
            {0, "closed" },
            {1, "open" },
        };
        //--end-state-dictionaries

        //--panel-controls
        public static List<PanelObject> PanelControls
        {
            get => new List<PanelObject>()
            {
                // ---panel: Overhead Maint
                // ---section: Electric

new SingleStateToggle { Name = "Generator #1 field reset", PanelName = "Overhead Maint", PanelSection = "Electric", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.ELEC_GenFieldReset[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.ELEC_GenFieldReset1},
new SingleStateToggle { Name = "Generator #2 field reset", PanelName = "Overhead Maint", PanelSection = "Electric", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.ELEC_GenFieldReset[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.ELEC_GenFieldReset2},
new SingleStateToggle { Name = "Generator #3 field reset", PanelName = "Overhead Maint", PanelSection = "Electric", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.ELEC_GenFieldReset[2], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.ELEC_GenFieldReset3},
new SingleStateToggle { Name = "Generator #4 field reset", PanelName = "Overhead Maint", PanelSection = "Electric", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.ELEC_GenFieldReset[3], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.ELEC_GenFieldReset4},
new SingleStateToggle { Name = "APU #1 field reset", PanelName = "Overhead Maint", PanelSection = "Electric", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.ELEC_APUFieldReset[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.ELEC_APUFieldReset1},
new SingleStateToggle { Name = "APU #2 field reset", PanelName = "Overhead Maint", PanelSection = "Electric", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.ELEC_APUFieldReset[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.ELEC_APUFieldReset2},
new SingleStateToggle { Name = "Split system breaker", PanelName = "Overhead Maint", PanelSection = "Electric", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.ELEC_SplitSystemBreaker, AvailableStates = _openOrClosedStates, shouldSpeak = Properties.pmdg747_offsets.Default.ELEC_SplitSystemBreaker},
new SingleStateToggle { Name = "Generator #1 field light", PanelName = "Overhead Maint", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.ELEC_annunGen_FIELD_OFF[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.ELEC_annunGen_FIELD_OFF1},
new SingleStateToggle { Name = "Generator #2 field light", PanelName = "Overhead Maint", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.ELEC_annunGen_FIELD_OFF[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.ELEC_annunGen_FIELD_OFF2},
new SingleStateToggle { Name = "Generator #3 field light", PanelName = "Overhead Maint", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.ELEC_annunGen_FIELD_OFF[2], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.ELEC_annunGen_FIELD_OFF3},
new SingleStateToggle { Name = "Generator #4 field light", PanelName = "Overhead Maint", PanelSection = "Electrical", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.ELEC_annunGen_FIELD_OFF[3], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.ELEC_annunGen_FIELD_OFF4},
new SingleStateToggle { Name = "APU field #1 light", PanelName = "Overhead Maint", PanelSection = "Electric", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.ELEC_annunAPU_FIELD_OFF[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.ELEC_annunAPU_FIELD_OFF1},
new SingleStateToggle { Name = "APU field #2 light", PanelName = "Overhead Maint", PanelSection = "Electric", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.ELEC_annunAPU_FIELD_OFF[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.ELEC_annunAPU_FIELD_OFF2},
new SingleStateToggle { Name = "Split system breaker light", PanelName = "Overhead Maint", PanelSection = "Electric", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.ELEC_annunSplitSystemBreaker_OPEN, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.ELEC_annunSplitSystemBreaker_OPEN},

                // ---panel: Glare Shield
                //---section: MCP

                new SingleStateToggle { Name = "Speed intervene", PanelName = "Glare Shield", PanelSection = "MCP", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.MCP_IASBlank, AvailableStates = _offOrOnStates, shouldSpeak = Properties.pmdg747_offsets.Default.MCP_IASBlank},
                new SingleStateToggle { Name = "Climb thrust", PanelName = "Glare Shield", PanelSection = "MCP", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.MCP_annunTHR, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.MCP_annunTHR },
                new SingleStateToggle { Name = "Speed hold", PanelName = "Glare Shield", PanelSection = "MCP", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.MCP_annunSPD, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.MCP_annunSPD },
                new SingleStateToggle { Name = "Auto throttle", PanelName = "Glare Shield", PanelSection = "MCP", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.MCP_ATArm_Sw_On, AvailableStates = _armedOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.MCP_ATArm_Sw_On },
                                new SingleStateToggle { Name = "Auto brake", PanelName = "Glare Shield", PanelSection = "MCP", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.BRAKES_AutobrakeSelector, AvailableStates = _autoBrakeStates, shouldSpeak = Properties.pmdg747_offsets.Default.BRAKES_AutobrakeSelector },
                new SingleStateToggle{ Name = "LNav", PanelName = "Glare Shield", PanelSection = "MCP", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.MCP_annunLNAV, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.MCP_annunLNAV },
                new SingleStateToggle { Name = "Heading hold", PanelName = "Glare Shield", PanelSection = "MCP", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.MCP_annunHDG_HOLD, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.MCP_annunHDG_HOLD },
                new SingleStateToggle { Name = "VNav", PanelName = "Glare Shield", PanelSection = "MCP", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.MCP_annunVNAV, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.MCP_annunVNAV },
                new SingleStateToggle { Name = "Level change", PanelName = "Glare Shield", PanelSection = "MCP", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.MCP_annunFLCH, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.MCP_annunFLCH },
                new SingleStateToggle { Name = "Altitude hold", PanelName = "Glare Shield", PanelSection = "MCP", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.MCP_annunALT_HOLD, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.MCP_annunALT_HOLD },
                new SingleStateToggle { Name = "Vertical speed intervene", PanelName = "Glare Shield", PanelSection = "MCP", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.MCP_VertSpeedBlank, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.MCP_VertSpeedBlank },
                new SingleStateToggle { Name = "Vertical speed", PanelName = "Glare Shield", PanelSection = "MCP", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.MCP_annunVS, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.MCP_annunVS },
                new SingleStateToggle { Name = "Left flight director", PanelName = "Glare Shield", PanelSection = "MCP", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.MCP_FD_Sw_On[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.MCP_FD_Sw_On_L },
                                new SingleStateToggle { Name = "Right flight director", PanelName = "Glare Shield", PanelSection = "MCP", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.MCP_FD_Sw_On[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.MCP_FD_Sw_On_R },
                                new SingleStateToggle { Name = "Bank limit", PanelName = "Glare Shield", PanelSection = "MCP", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.MCP_BankLimitSel, AvailableStates = _bankLimitSelectorStates, shouldSpeak = Properties.pmdg747_offsets.Default.MCP_BankLimitSel },
                                new SingleStateToggle { Name = "Disengage bar", PanelName = "Glare Shield", PanelSection = "MCP", Type = PanelObjectType.Switch, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.MCP_DisengageBar, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.MCP_DisengageBar },
                                new SingleStateToggle { Name = "Left auto pilot", PanelName = "Glare Shield", PanelSection = "MCP", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.MCP_annunAP[0], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.MCP_annunAP_L },
                                                                new SingleStateToggle { Name = "Center auto pilot", PanelName = "Glare Shield", PanelSection = "MCP", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.MCP_annunAP[1], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.MCP_annunAP_C },
                                                                                                new SingleStateToggle { Name = "Right auto pilot", PanelName = "Glare Shield", PanelSection = "MCP", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.MCP_annunAP[2], AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.MCP_annunAP_R },
                                                                                                new SingleStateToggle { Name = "Localizer hold", PanelName = "Glare Shield", PanelSection = "MCP", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.MCP_annunLOC, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.MCP_annunLOC },
                                                                                                new SingleStateToggle { Name = "Approach mode", PanelName = "Glare Shield", PanelSection = "MCP", Type = PanelObjectType.Annunciator, Verbosity = AircraftVerbosity.Low, Offset = Aircraft.pmdg747.MCP_annunAPP, AvailableStates = _onOrOffStates, shouldSpeak = Properties.pmdg747_offsets.Default.MCP_annunAPP },
                                                                                                
            };
        }
        //--end-panel-controls

        // ---properties

        public static bool Is800
        {
            get
            {
                if(Aircraft.pmdg747.AircraftModel.Value ==8 || Aircraft.pmdg747.AircraftModel.Value == 9)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        } // Is800
        public static AircraftSystem SpeedMode
        {
            get => Aircraft.pmdg747.MCP_IASBlank.Value == 1 ? AircraftSystem.FMC : AircraftSystem.MCP;
        }

        public static AircraftSpeed SpeedType
        {
            get => Aircraft.pmdg747.MCP_IASMach.Value > 10 ? AircraftSpeed.Indicated : AircraftSpeed.Mach;
        }

        public static double MachSpeed
        {
            get
            {

                double speed = 0;
                if(SpeedType == AircraftSpeed.Mach)
                {
                    speed = Math.Round((Aircraft.pmdg747.MCP_IASMach.Value % 1), 2);
                }

                return speed;
            }
        }

        public static double IndicatedAirSpeed
        {
            get
            {

                double speed = 0;

                if(SpeedType == AircraftSpeed.Indicated)
                {
                    speed = Aircraft.pmdg747.MCP_IASMach.Value;
                }

                return speed;
            }
        }

        public static TimeSpan TimeToDestination
        {
            get
            {
                double groundSpeed = ((double)Aircraft.GroundSpeed.Value * 3600d) / (65536d * 1852d);
                groundSpeed = Math.Round(groundSpeed);
                double time = Aircraft.pmdg747.FMC_DistanceToDest.Value / groundSpeed;
                return TimeSpan.FromHours(time);
            }
        } // TimeToDestination

        public static TimeSpan TimeToTOD
        {
            get
            {
                double groundSpeed = ((double)Aircraft.GroundSpeed.Value * 3600d) / (65536d * 1852d);
                groundSpeed = Math.Round(groundSpeed);
                double time = Aircraft.pmdg747.FMC_DistanceToTOD.Value / groundSpeed;
                return TimeSpan.FromHours(time);
            }
        } // TimeToTOD

        public static double CurrentStabTrim
        {
            get => FSUIPCConnection.ReadLVar("NGXHStabTrim");
        }


        /// TODO: Evaluate speedbrake detents.        public static double CurrentSpeedBrakePosition
        public static byte CurrentSpeedBrakePosition
        {
            get => Aircraft.pmdg747.FCTL_Speedbrake_Lever.Value;
        }

                public static byte CurrentFlapsPosition
        {
            get
            {
                byte flaps = 0;

                switch (Aircraft.pmdg747.FCTL_Flaps_Lever.Value)
                {
                    case 0:
                        flaps = 0;
                        break;
                    case 1:
                        flaps = 1;
                        break;
                    case 2:
                        flaps = 5;
                        break;
                    case 3:
                        flaps = 10;
                        break;
                    case 4:
                        flaps = 20;
                        break;
                    case 5:
                        flaps = 25;
                        break;
                    case 6:
                        flaps = 30;
                        break;
                }
                return flaps;
            }
                    } // CurrentFlapsPosition

public static void ShowSpeedBox()
        {
            MCPComponents["speed"].Show();
        } // ShowSpeedBox

        public static void SetSpeed(string speedTxt)
        {
            if (SpeedType == AircraftSpeed.Indicated)
            {
                if (int.TryParse(speedTxt, out int speed))
                {
                    FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_IAS_SET, speed);
                }
            }
            else
            {
                if (double.TryParse(speedTxt, out double speed))
                {
                    speed /= 0.01;
                    FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_MACH_SET, (int)speed);
                }
            }
                    } // SetSpeed

        public static void SpeedIntervene()
        {
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_SPEED_PUSH_SWITCH, ClkL);
        } // SpeedIntervene

        public static  void ChangeOver()
        {
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_IAS_MACH_SWITCH, ClkL);
        } // ChangeOver

        public static void AutoThrottleToggle()
        {
            if(Aircraft.pmdg747.MCP_ATArm_Sw_On.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_AT_ARM_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_AT_ARM_SWITCH, ClkR);
            }
        } // AutoThrottleToggle

        public static void ClimbThrust()
        {
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_THR_SWITCH, ClkL);
        } // ClimbThrust

        public static void SpeedHoldToggle()
        {
            if(Aircraft.pmdg747.MCP_annunSPD.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_SPD_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_SPD_SWITCH, ClkR);
            }
        } // SpeedHoldToggle

        public static void SpeedBrakeIncrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_CONTROL_STAND_SPEED_BRAKE_LEVER, Dec);
        } // SpeedBrakeIncrease

        public static void SpeedBrakeDecrease()
        {
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_CONTROL_STAND_SPEED_BRAKE_LEVER, Inc);
        } // SpeedBrakeDecrease

        public static void SpeedBrakeDown()
        {
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_CONTROL_STAND_SPEED_BRAKE_LEVER_DOWN, ClkL);
        } // SpeedBrakeDown

        public static void SpeedBrakeArm()
        {
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_CONTROL_STAND_SPEED_BRAKE_LEVER_ARM, ClkL);
        } // SpeedBrakeArm

        public static void SpeedBrakeFlt()
        {
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_CONTROL_STAND_SPEED_BRAKE_LEVER_FLT_DET, ClkL);
        } // SpeedBrakeArm

        public static void SpeedBrakeUp()
        {
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_CONTROL_STAND_SPEED_BRAKE_LEVER_UP, ClkL);
        } // SpeedBrakeUp

        public static void AutoBrakeRTO()
        {
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_ABS_AUTOBRAKE_SELECTOR, 0);
        } // AutoBrakeRTO

        public static void AutoBrakeOff()
        {
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_ABS_AUTOBRAKE_SELECTOR, 1);
        } // AutoBrakeOff

        public static void AutoBrakeDisarm()
        {
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_ABS_AUTOBRAKE_SELECTOR, 2);
        } // AutoBrakeDisarm

        public static void AutoBrake1()
        {
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_ABS_AUTOBRAKE_SELECTOR, 3);
        } // AutoBrake1

        public static void AutoBrake2()
        {
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_ABS_AUTOBRAKE_SELECTOR, 4);
        } // AutoBrake2

        public static void AutoBrakeAuto()
        {
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_ABS_AUTOBRAKE_SELECTOR, 5);
        } // AutoBrakeAuto

        public static void SetHeading(string text)
        {
            short.TryParse(text, out short heading);
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_HDG_SET, heading);
        } // SetHeading

        public static void LNav()
        {
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_LNAV_SWITCH, ClkL);
        } // LNav

        public static void HeadingHold()
        {
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_HDG_HOLD_SWITCH, ClkL);
        } // HeadingHold

        public static void HeadingIntervene()
        {
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_HEADING_PUSH_SWITCH, ClkL);
        } // HeadingIntervene

        public static void ShowHeadingBox()
        {
            MCPComponents["heading"].Show();
        } // ShowHeadingBox

        public static void ShowAltitudeBox()
        {
            MCPComponents["altitude"].Show();
        } // ShowAltitudeBox

        public static void AltitudeIntervene()
        {
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_ALTITUDE_PUSH_SWITCH, ClkL);
        } // AltitudeIntervene

        public static void VNav()
        {
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_VNAV_SWITCH, ClkL);
        } // VNav

        public static void LevelChange()
        {
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_LVL_CHG_SWITCH, ClkL);
        } // LevelChange

        public static void AltitudeHold()
        {
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_ALT_HOLD_SWITCH, ClkL);
        } // AltitudeHold

        public static void SetAltitude(string altitudeText)
        {
            ushort.TryParse(altitudeText, out ushort altitude);
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_ALT_SET, altitude);
        } // SetAltitude

public static void SetVerticalSpeed(string verticalSpeedText)
        {
            if (int.TryParse(verticalSpeedText, out int speed))
            {
                speed = speed - 10000;
                FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_VS_SET, speed);
            }
                    } // SetVerticalSpeed

        public static void VerticalSpeedMode()
        {
            FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_VS_SWITCH, ClkL);
        } // VerticalSpeedMode

        public static void ShowVerticalSpeedBox()
        {
            MCPComponents["vertical"].Show();
        } // ShowVerticalSpeedBox

        public static void ShowNavigationBox()
        {
            MCPComponents["navigation"].Show();
        } // ShowNavigationBox

        public static void LeftFlightDirectorToggle()
        {
            if (Aircraft.pmdg747.MCP_FD_Sw_On[0].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_FD_SWITCH_L, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_FD_SWITCH_L, ClkR);
            }
        } // LeftFlightDirectorToggle

        public static void RightFlightDirectorToggle()
        {
            if (Aircraft.pmdg747.MCP_FD_Sw_On[1].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_FD_SWITCH_R, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_FD_SWITCH_R, ClkR);
            }
        } // RightFlightDirectorToggle

        public static void LeftAutoPilotToggle()
        {
            if (Aircraft.pmdg747.MCP_annunAP[0].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_AP_L_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_AP_L_SWITCH, ClkR);
            }
        } // LeftAutoPilotToggle

        public static void CenterAutoPilotToggle()
        {
            if (Aircraft.pmdg747.MCP_annunAP[1].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_AP_C_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_AP_C_SWITCH, ClkR);
            }
        } // CenterAutoPilotToggle

        public static void RightAutoPilotToggle()
        {
            if (Aircraft.pmdg747.MCP_annunAP[2].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_AP_R_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_AP_R_SWITCH, ClkR);
            }
        } // RightAutoPilotToggle

        public static void ApproachModeToggleToggle()
        {
            if (Aircraft.pmdg747.MCP_annunAPP.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_APP_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_APP_SWITCH, ClkR);
            }
        } // ApproachModeToggle

        public static void LocalizerHoldToggle()
        {
            if(Aircraft.pmdg747.MCP_annunLOC.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_LOC_SWITCH, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_LOC_SWITCH, ClkR);
            }
        } // LocalizerHoldToggle

        public static void BankLimitCycle()
        {
            var counter = Aircraft.pmdg747.MCP_BankLimitSel.Value;

            if(Aircraft.pmdg747.MCP_BankLimitSel.Value != 5)
            {
                FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_BANK_ANGLE_SELECTOR, counter + 1);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_BANK_ANGLE_SELECTOR, 0);
            }
        } // BankLimitCycle

        public static void DisengageBarToggle()
        {
            if(Aircraft.pmdg747.MCP_DisengageBar.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_DISENGAGE_BAR, ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_747QOTSII_Control.EVT_MCP_DISENGAGE_BAR, ClkR);
            }
        } // DisengageBarToggle


    } // End PMDG747Aircraft.
} // End namespace.
