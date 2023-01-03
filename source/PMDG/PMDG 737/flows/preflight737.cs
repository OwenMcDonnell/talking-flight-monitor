using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSUIPC;
using DavyKager;
using System.Threading;
using System.Drawing;

namespace tfm.PMDG.PMDG_737.flows
{
    public class Preflight737
    {
        private bool PowerEstablished;
        private bool FirstFlight;

        public void PreflightFlow(int Power)
        {
            if (Aircraft.pmdg737.ELEC_BatSelector.Value == 0)
            {
                FirstFlight = true;
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_BATTERY_SWITCH, Aircraft.ClkL);
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
                Tolk.Output("Setting IRS Switches. ");
                PMDG737Aircraft.IRULeftNav();
                Thread.Sleep(1000);
                PMDG737Aircraft.IRURightNav();

                if (Properties.Settings.Default.PreflightAlignIRS)
                {
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

            private bool PowerWithAPU()
            {
                if (Aircraft.pmdg737.APU_Selector.Value != 1)
                {
                    for (int i = Aircraft.pmdg737.APU_Selector.Value; i != 2; i++)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_APU_START, Aircraft.ClkL);
                        Thread.Sleep(500);
                    }
                    Tolk.Output("waiting 2 minutes for APU to start");
                    Thread.Sleep(TimeSpan.FromSeconds(120));
                    if (Aircraft.pmdg737.ELEC_annunAPU_GEN_OFF_BUS.Value == 1)
                    {

                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_APU_GEN1_SWITCH, Aircraft.ClkL);

                        Thread.Sleep(1);
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_APU_GEN2_SWITCH, Aircraft.ClkL);
                        Thread.Sleep(1);
                    }
                    if (Aircraft.pmdg737.AIR_APUBleedAirSwitch.Value == 0)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_APU_SWITCH, Aircraft.ClkL);
                        Thread.Sleep(1);
                    }
                    if (Aircraft.pmdg737.APU_annunFAULT.Value == 0)
                    {


                        Thread.Sleep(2000);
                    }
                }

                return true;
            }


        }
    }


