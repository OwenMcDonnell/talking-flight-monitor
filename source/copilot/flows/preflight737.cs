using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSUIPC;
using DavyKager;
using System.Threading;
using System.Drawing;

namespace tfm.copilot
{
    public class Preflight737
    {
        private bool PowerEstablished;
        private bool FirstFlight;

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


        }



