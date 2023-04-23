using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSUIPC;
using DavyKager;
using System.Threading;
using System.Drawing;
using NLog;

namespace tfm.copilot
{
    public class Preflight737
    {
        private bool PowerEstablished;
        private bool FirstFlight;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public void ElectricalFlow(int Power)
        {
            if (Aircraft.pmdg737.ELEC_BatSelector.Value == 0)
            {
                FirstFlight = true;
                frmPMDG737Flows.FlowStatusMessage = "battery on";
                PMDG737Aircraft.Battery(1);
                Thread.Sleep(1000);

                switch (Power)
                {
                    case 0:
                        PowerWithAPU();
                        break;
                    case 1:
                        PowerWithGPU();
                        break;


                }
            }
            // Turn on strobe light
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_POS_STROBE, Aircraft.ClkL);
            // set internal lights
            if (Aircraft.pmdg737.LTS_DomeWhiteSw.Value != 2)
            {
                for (int i = 0; i != 2; i++)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_DOME_SWITCH, Aircraft.ClkL);
                }
                Thread.Sleep(1000);
                
                
            }
        }


            public void PowerWithGPU()
            {
                if (Aircraft.pmdg737.ELEC_annunGRD_POWER_AVAILABLE.Value == 0)
                {
                    Tolk.Output("Connecting Ground Power. ");
                    for (int i = 0; i < 6; i++)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_R_MENU, Aircraft.ClkL);
                    }
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_R_CLR, Aircraft.ClkL);
                    Thread.Sleep(1000);
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_R_MENU, Aircraft.ClkL);
                    Thread.Sleep(1000);
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_R_R5, Aircraft.ClkL);
                    Thread.Sleep(1000);
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_R_R1, Aircraft.ClkL);
                    Thread.Sleep(1000);
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_R_L2, Aircraft.ClkL);
                    Thread.Sleep(1000);
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_R_MENU, Aircraft.ClkL);
                    Thread.Sleep(1000);
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_R_CLR, Aircraft.ClkL);

                }
                if (Aircraft.pmdg737.ELEC_annunGRD_POWER_AVAILABLE.Value > 0)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_GRD_PWR_SWITCH, Aircraft.ClkL);
                    Thread.Sleep(1000);
                }
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_R_CLR, Aircraft.ClkL);

                if (Aircraft.pmdg737.ELEC_GrdPwrSw.Value == 1)
                {
                    Tolk.Output("Ground power estabilished");
                    PowerEstablished = true;
                    Thread.Sleep(2000);
                }


            }

            private void PowerWithAPU()
            {

                
                if (Aircraft.pmdg737.APU_Selector.Value != 1)
                {
                Thread.Sleep(2000);
                PMDG737Aircraft.APUSelector(1);
                Thread.Sleep(1000);
                PMDG737Aircraft.APUSelector(2);


                frmPMDG737Flows.FlowStatusMessage = "waiting 2 minutes for APU to start";
                Thread.Sleep(TimeSpan.FromSeconds(120));
                PMDG737Aircraft.ApuGenerator1On();
                Thread.Sleep(250);
                PMDG737Aircraft.ApuGenerator2On();
            }
                    if (Aircraft.pmdg737.AIR_APUBleedAirSwitch.Value == 0)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_APU_SWITCH, Aircraft.ClkL);
                        Thread.Sleep(1);
                    }
                }

        public void AlignIRS()
        {
            if (Properties.Settings.Default.PreflightAlignIRS)
            {
                Tolk.Output("Setting IRS Switches. ");
                PMDG737Aircraft.IRULeftNav();
                Thread.Sleep(1000);
                PMDG737Aircraft.IRURightNav();
                Thread.Sleep(3000);
                Tolk.Output("waiting 35 seconds to input last position.");
                Thread.Sleep(35000);

                Tolk.Output("Setting last position");
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_R_CLR, Aircraft.ClkL);
                Thread.Sleep(1000);
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_R_MENU, Aircraft.ClkL);
                Thread.Sleep(1000);
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_R_L1, Aircraft.ClkL);
                Thread.Sleep(1000);
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_R_R6, Aircraft.ClkL);
                Thread.Sleep(1000);
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_R_R1, Aircraft.ClkL);
                Thread.Sleep(1000);
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_R_R4, Aircraft.ClkL);
                Thread.Sleep(1000);
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_R_MENU, Aircraft.ClkL);
                Thread.Sleep(1000);

            }

        }

        public void systemTestFire()
        {
            if (Properties.Settings.Default.FlowMuteSpeech)
            {
                utility.flgMuteFlows = true;
            }
            frmPMDG737Flows.FlowStatusMessage = "running fire tests.";
            Tolk.Output("Running fire tests.");
            Thread.Sleep(1000);
            for (int i = 0; i != 2; i++)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_FIRE_DETECTION_TEST_SWITCH, Aircraft.ClkL);
                Thread.Sleep(250);
            }
            Thread.Sleep(4000);
            // ClearCautWarn(0);
            Thread.Sleep(2000);
            for (int k = 0; k != 2; k++)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_FIRE_DETECTION_TEST_SWITCH, Aircraft.ClkR);
                Thread.Sleep(250);
            }
            Thread.Sleep(3000);
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_FIRE_DETECTION_TEST_SWITCH, Aircraft.ClkL);
            Thread.Sleep(3000);
            for (int j = 0; j != 2; j++)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_FIRE_EXTINGUISHER_TEST_SWITCH, Aircraft.ClkL);
                Thread.Sleep(250);
            }
            Thread.Sleep(2000);
            for (int i = 0; i != 2; i++)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_FIRE_EXTINGUISHER_TEST_SWITCH, Aircraft.ClkR);
                Thread.Sleep(250);
            }
            Thread.Sleep(2000);
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_FIRE_EXTINGUISHER_TEST_SWITCH, Aircraft.ClkL);
            Thread.Sleep(1000);
            frmPMDG737Flows.FlowStatusMessage = "Fire tests completed.";
            Tolk.Output("Fire test completed.");
            utility.flgMuteFlows = false;



        }

        public void systemTestGPWS()
        {
            frmPMDG737Flows.FlowStatusMessage = "Starting GPWS test.";
            Tolk.Output("Starting GPWS test.");

            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_GPWS_SYS_TEST_BTN, Aircraft.ClkR);
            Thread.Sleep(75000);
            frmPMDG737Flows.FlowStatusMessage = "GPWS test completed. ";
            Tolk.Output("GPWS test completed.");

        }

        public void SystemTestOverspeed()
        {
            frmPMDG737Flows.FlowStatusMessage = "Starting Overspeed test.";
            Tolk.Output("starting Overspeed test. ");
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_WARNING_TEST_MACH_IAS_1_PUSH, Aircraft.ClkL);
            Thread.Sleep(3000);
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_WARNING_TEST_MACH_IAS_1_PUSH, Aircraft.LeftRelease);
            frmPMDG737Flows.FlowStatusMessage = "Overspeed test completed.";
            Tolk.Output("Overspeed test completed. ");
        }

        public void SystemTestStallWarning ()
        {
            frmPMDG737Flows.FlowStatusMessage = "Starting stall warning test.";
            Tolk.Output("starting Stall WArning test. ");
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_WARNING_TEST_STALL_1_PUSH, Aircraft.ClkL);
            Thread.Sleep(4000);
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_WARNING_TEST_STALL_1_PUSH, Aircraft.LeftRelease);
            frmPMDG737Flows.FlowStatusMessage = "Stall warning test completed.";
            Tolk.Output("Stall warning test completed. ");


        }

        public void SystemTestVoiceRecorder ()
        {
            Tolk.Output("starting voice recorder test.");
            for (int v = 0; v != 5; v++)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_CVR_TEST, Aircraft.ClkL);
            }
            Thread.Sleep(5000);
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_CVR_TEST, Aircraft.LeftRelease);
            Tolk.Output("voice recorder test completed.");
            Thread.Sleep(1000);


        }

        public void SystemTestOxygen ()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_OXY_TEST_RESET_SWITCH_R, Aircraft.ClkR);
            Thread.Sleep(3000);

        }

        public void SystemTestAutopilotDisconnect ()
        {
            Tolk.Output("Starting Autopilot disconnect test.");
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_DSP_FO_DISENGAGE_TEST_SWITCH, Aircraft.ClkL);
            Thread.Sleep(3000);
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_DSP_FO_DISENGAGE_TEST_SWITCH, Aircraft.LeftRelease);
            Tolk.Output("test completed.");

        }

        public void PreflightPanelSetup()
        {
            if (Properties.Settings.Default.FlowMuteSpeech && ! Properties.Settings.Default.AutomaticAnnouncements)
            {
                Properties.Settings.Default.AutomaticAnnouncements = false;
            }
            Pf_YawDamper();
            Pf_NavDisplay();
            Pf_FuelPanel();
            Pf_ElectricalPanel();
            Pf_EquipmentCooling();
            Pf_EmergencyExit();
            Pf_PassengerSigns();
            Pf_WindowHeat();
            Pf_ProbeHeat();
            Pf_AntiIce();
            Pf_Hydraulics();
            Pf_AirSystems();
            Pf_EngStartSwitches();
            Pf_AutoBrake();
            Pf_Transponder();
            Properties.Settings.Default.AutomaticAnnouncements = true;

        }

        public void Pf_YawDamper()
        {
            // yaw damper
            Tolk.Output("checking yaw damper...");
            if (Aircraft.pmdg737.FCTL_YawDamper_Sw.Value != 1)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_YAW_DAMPER, 1);
                Thread.Sleep(1000);

            }

        }

        public void Pf_NavDisplay ()
        {
            // nav display
            Tolk.Output("checking nav display");
            if (Aircraft.pmdg737.NAVDIS_ControlPaneSelector.Value != 1)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_NAVDSP_CONTROL_PANEL_SEL, 1);
            }
            Thread.Sleep(1000);
            if (Aircraft.pmdg737.NAVDIS_SourceSelector.Value != 1)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_NAVDSP_DISPLAYS_SOURCE_SEL, 1);
            }
            Thread.Sleep(1000);


        }

        public void Pf_FuelPanel()
        {
            // fuel panel
            Tolk.Output("checking fule panel.");
            if (Aircraft.pmdg737.FUEL_PumpAftSw[0].Value != 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_1_AFT, Aircraft.ClkL);
                Thread.Sleep(1000);
            }
            if (Aircraft.pmdg737.FUEL_PumpAftSw[1].Value != 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_2_AFT, Aircraft.ClkL);
                Thread.Sleep(1000);
            }
            if (Aircraft.pmdg737.FUEL_PumpCtrSw[0].Value != 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_L_CENTER, Aircraft.ClkL);
                Thread.Sleep(1000);
            }
            if (Aircraft.pmdg737.FUEL_PumpCtrSw[1].Value != 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_R_CENTER, Aircraft.ClkL);
                Thread.Sleep(1000);
            }
            if (Aircraft.pmdg737.FUEL_PumpFwdSw[1].Value != 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_2_FORWARD, Aircraft.ClkL);
                Thread.Sleep(1000);
            }
            if (Aircraft.pmdg737.APU_Selector.Value == 0 && Aircraft.pmdg737.FUEL_PumpFwdSw[0].Value != 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_1_FORWARD, Aircraft.ClkL);
                Thread.Sleep(1000);
            }
            if (Aircraft.pmdg737.APU_Selector.Value > 0 && Aircraft.pmdg737.FUEL_PumpFwdSw[0].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_1_FORWARD, Aircraft.ClkL);
                Thread.Sleep(1000);
            }

        }

        public void Pf_ElectricalPanel ()
        {
            // check electrical panel
            Tolk.Output("checking electrical panel.");
            if (Aircraft.pmdg737.ELEC_CabUtilSw.Value != 1)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_CAB_UTIL, Aircraft.ClkL);
                Thread.Sleep(1000);
            }
            if (Aircraft.pmdg737.ELEC_IFEPassSeatSw.Value != 1)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_IFE, Aircraft.ClkL);
                Thread.Sleep(1000);
            }
            if (Aircraft.pmdg737.ELEC_annunSTANDBY_POWER_OFF.Value == 1)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_GUARD, Aircraft.ClkL);
                Thread.Sleep(1000);
            }

        }

        public void Pf_EquipmentCooling ()
        {
            // Equipment cooling
            Tolk.Output("checking equipment cooling.");
            if (Aircraft.pmdg737.AIR_EquipCoolingSupplyNORM.Value != 1)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_EC_SUPPLY_SWITCH, Aircraft.ClkL);
                Thread.Sleep(1000);
            }
            if (Aircraft.pmdg737.AIR_EquipCoolingExhaustNORM.Value != 1)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_EC_EXHAUST_SWITCH, Aircraft.ClkL);
                Thread.Sleep(1000);
            }

        }

        public void Pf_EmergencyExit ()
        {
            // emergency exit
            Tolk.Output("checking emergency exit.");
            if (Aircraft.pmdg737.LTS_EmerExitSelector.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_EMER_EXIT_LIGHT_GUARD, Aircraft.ClkL);
                Thread.Sleep(1000);
            }

        }

        public void Pf_PassengerSigns ()
        {
            // passenger signs
            Tolk.Output("Checking passenger signs.");
            if (Aircraft.pmdg737.COMM_FastenBeltsSelector.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_FASTEN_BELTS_LIGHT_SWITCH, Aircraft.ClkL);
            }
            if (Aircraft.pmdg737.COMM_FastenBeltsSelector.Value == 2)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_FASTEN_BELTS_LIGHT_SWITCH, Aircraft.ClkR);
            }


        }

        public void Pf_WindowHeat ()
        {
            // check window heat
            Tolk.Output("checking window heat.");
            if (Aircraft.pmdg737.ICE_WindowHeatSw[0].Value != 1)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_WINDOW_HEAT_1, Aircraft.ClkL);
                Thread.Sleep(500);
            }
            if (Aircraft.pmdg737.ICE_WindowHeatSw[1].Value != 1)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_WINDOW_HEAT_2, Aircraft.ClkL);
                Thread.Sleep(500);
            }
            if (Aircraft.pmdg737.ICE_WindowHeatSw[2].Value != 1)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_WINDOW_HEAT_3, Aircraft.ClkL);
                Thread.Sleep(500);
            }
            if (Aircraft.pmdg737.ICE_WindowHeatSw[3].Value != 1)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_WINDOW_HEAT_4, Aircraft.ClkL);
                Thread.Sleep(500);
            }


        }

        public void Pf_ProbeHeat ()
        {
            // probe heat
            Tolk.Output("checking probe heat.");
            if (Aircraft.pmdg737.ICE_TestProbeHeatSw[0].Value != 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_PROBE_HEAT_1, Aircraft.ClkL);
                Thread.Sleep(500);
            }
            if (Aircraft.pmdg737.ICE_TestProbeHeatSw[1].Value != 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_PROBE_HEAT_2, Aircraft.ClkL);
                Thread.Sleep(500);
            }

        }

        public void Pf_AntiIce ()
        {
            // anti-ice
            Tolk.Output("checking anti-ice.");
            if (Aircraft.pmdg737.ICE_EngAntiIceSw[0].Value != 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_ENGINE_ANTIICE_1, Aircraft.ClkL);
                Thread.Sleep(1000);
            }
            if (Aircraft.pmdg737.ICE_EngAntiIceSw[1].Value != 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_ENGINE_ANTIICE_2, Aircraft.ClkL);
                Thread.Sleep(1000);
            }
            if (Aircraft.pmdg737.ICE_WingAntiIceSw.Value != 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ICE_WING_ANTIICE, Aircraft.ClkL);
                Thread.Sleep(1000);
            }


        }

        public void Pf_Hydraulics ()
        {
            // hydraulics
            Tolk.Output("checking hydraulics panel...");

            if (Aircraft.pmdg737.HYD_PumpSw_eng[0].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_HYD_ENG1, Aircraft.ClkL);
                Thread.Sleep(500);
            }
            if (Aircraft.pmdg737.HYD_PumpSw_eng[1].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_HYD_ENG2, Aircraft.ClkL);
                Thread.Sleep(500);
            }
            if (Aircraft.pmdg737.HYD_PumpSw_elec[0].Value > 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_HYD_ELEC2, Aircraft.ClkL);
                Thread.Sleep(500);
            }
            if (Aircraft.pmdg737.HYD_PumpSw_elec[1].Value > 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_HYD_ELEC1, Aircraft.ClkL);
                Thread.Sleep(500);
            }


        }

        public void Pf_AirSystems ()
        {
            // air systems panel
            Tolk.Output("Checking air systems panel.");
            PMDG737Aircraft.LeftRecircFanOn();
            Thread.Sleep(1000);

            PMDG737Aircraft.RightRecircFanOn();
            Thread.Sleep(1000);
            PMDG737Aircraft.IsolationValveSelector(1);
            Thread.Sleep(1000);
            PMDG737Aircraft.LeftPackSelector(1);
            Thread.Sleep(1000);
            PMDG737Aircraft.RightPackSelector(1);
            Thread.Sleep(1000);
            PMDG737Aircraft.APUBleedOn();
            Thread.Sleep(1000);
            PMDG737Aircraft.RightBleedOn();
            Thread.Sleep(1000);
            PMDG737Aircraft.LeftBleedOn();



        }

        public void Pf_EngStartSwitches ()
        {
            // engine start switches
            Tolk.Output("checking engine start switches.");
            PMDG737Aircraft.Engine1StartSelector(1);
            Thread.Sleep(1000);
            PMDG737Aircraft.Engine2StartSelector(1);


        }

        public void Pf_AutoBrake ()
        {
            // autobrake
            Tolk.Output("setting auto brake.");
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MPM_AUTOBRAKE_SELECTOR, 0);
            Thread.Sleep(1000);


        }

        public void Pf_Transponder ()
        {
            // transponder
            Tolk.Output("checking transponder.");
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_TCAS_MODE, 0);
            Thread.Sleep(1000);

        }

        public void FmcRoute ()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_R_MENU, Aircraft.ClkL);
            Thread.Sleep(1000);
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_R_L1, Aircraft.ClkL);
            Thread.Sleep(1000);
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_R_RTE, Aircraft.ClkL);
            Thread.Sleep(1000);
            PMDG737Aircraft.EnterCDUText(2, FlightPlan.SimbriefOrigin.IcaoCode + FlightPlan.Destination.ICAO);
            Thread.Sleep(1000);
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_R_L2, Aircraft.ClkL);
            Thread.Sleep(1000);
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_R_R6, Aircraft.ClkL);
            Thread.Sleep(1000);
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_R_EXEC, Aircraft.ClkL);
            Thread.Sleep(1000);
            // PmdgEnterFMcKeyBrdData(FlightPlanInfo.callsign);
            Thread.Sleep(1000);
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_R_R2, Aircraft.ClkL);
            Thread.Sleep(1000);

        }

    }


}



