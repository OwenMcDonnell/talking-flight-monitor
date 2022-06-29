﻿using tfm.PMDG.PanelObjects;
using tfm.PMDG.PanelObjects;
using DavyKager;

using FSUIPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.PMDG.PMDG_737.CockpitPanels.ForwardOverhead
{
    public partial class ctlElectrical : UserControl, iPanelsPage
    {

        Timer electricalTimer = new Timer();
        PanelObject[] electricalControls = PMDG737Aircraft.PanelControls.Where(x => x.PanelName == "Forward Overhead" && x.PanelSection == "Electrical").ToArray();
        public ctlElectrical()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void electricalTimerTick(object Sender, EventArgs eventArgs)
        {
            foreach (PanelObject control in electricalControls)
            {
                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.ELEC_BatSelector)
                {
                    batterySelectorComboBox.SelectedIndex = toggle.CurrentState.Key;
                } // battery

                if (toggle.Offset == Aircraft.pmdg737.ELEC_GrdPwrSw)
                {
                    groundPwrButton.Text = $"G&round power {toggle.CurrentState.Value}";
                    groundPwrButton.AccessibleName = toggle.ToString();
                } // ground power

                if (toggle.Offset == Aircraft.pmdg737.ELEC_CabUtilSw)
                {
                    cabinUtilButton.Text = $"&Cabin utility {toggle.CurrentState.Value}";
                    cabinUtilButton.AccessibleName = toggle.ToString();
                } // cabin utility

                if (toggle.Offset == Aircraft.pmdg737.ELEC_IFEPassSeatSw)
                {
                    passSeatsButton.Text = $"I&FE {toggle.CurrentState.Value}";
                    passSeatsButton.AccessibleName = toggle.ToString();
                } // IFE/seats

                if (toggle.Offset == Aircraft.pmdg737.ELEC_DCMeterSelector)
                {
                    dcMeterComboBox.SelectedIndex = toggle.CurrentState.Key;
                } // end dc selector
                                                    if( Aircraft.pmdg737.ELEC_MeterDisplayTop.ValueChanged)
                    {
                    dcAmpsTextBox.Text = Aircraft.pmdg737.ELEC_MeterDisplayTop.Value.Substring(0, 3);
                    dcVoltsTextBox.Text = Aircraft.pmdg737.ELEC_MeterDisplayBottom.Value.Substring(0, 3);
                } // DC amps/volts

                if (Aircraft.pmdg737.ELEC_MeterDisplayBottom.ValueChanged)
                { 
                    acAmpsTextBox.Text = Aircraft.pmdg737.ELEC_MeterDisplayBottom.Value.Substring(8, 4);
                    acVoltsTextBox.Text = Aircraft.pmdg737.ELEC_MeterDisplayBottom.Value.Substring(4, 4);
                } // AC amps/volts
                                if (toggle.Offset == Aircraft.pmdg737.ELEC_ACMeterSelector)
                {
                    acSelectorComboBox.SelectedIndex = toggle.CurrentState.Key;
                } // AC selector

                if (toggle.Offset == Aircraft.pmdg737.ELEC_StandbyPowerSelector)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        standbyPowerComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }

                } // standby power

                if (toggle.Offset == Aircraft.pmdg737.ELEC_IDGDisconnectSw[0])
                {
                    idg1Button.Text = toggle.ToString();
                    idg1Button.AccessibleName = toggle.ToString();
                } // IDG1

                if (toggle.Offset == Aircraft.pmdg737.ELEC_IDGDisconnectSw[1])
                {
                    idg2Button.Text = toggle.ToString();
                    idg2Button.AccessibleName = toggle.ToString();
                } // IDG2

                if (toggle.Offset == Aircraft.pmdg737.ELEC_GenSw[0])
                {
                    generator1Button.Text = toggle.ToString();
                    generator1Button.AccessibleName = toggle.ToString();
                } // generator 1

                if (toggle.Offset == Aircraft.pmdg737.ELEC_GenSw[1])
                {
                    generator2Button.Text = toggle.ToString();
                    generator2Button.AccessibleName = toggle.ToString();
                } // generator 2

                if (toggle.Offset == Aircraft.pmdg737.ELEC_APUGenSw[0])
                {
                    apuGen1Button.Text = toggle.ToString();
                    apuGen1Button.AccessibleName = toggle.ToString();
                } // APU gen1

                if (toggle.Offset == Aircraft.pmdg737.ELEC_APUGenSw[1])
                {
                    apuGen2Button.Text = toggle.ToString();
                    apuGen2Button.AccessibleName = toggle.ToString();
                } // APU gen2

                if (toggle.Offset == Aircraft.pmdg737.ELEC_BusTransSw_AUTO)
                {
                    busXferButton.Text = toggle.ToString();
                    busXferButton.AccessibleName = toggle.ToString();
                } // Bus Xfer

                if (toggle.Offset == Aircraft.pmdg737.ELEC_annunBAT_DISCHARGE)
                {
                    batDischargeTextBox.Text = toggle.CurrentState.Value;
                } // Battery light

                if (toggle.Offset == Aircraft.pmdg737.ELEC_annunTR_UNIT)
                {
                    trUnitTextBox.Text = toggle.CurrentState.Value;
                } // TR unit

                if (toggle.Offset == Aircraft.pmdg737.ELEC_annunELEC)
                {
                    elecTextBox.Text = toggle.CurrentState.Value;
                } // Elec light

                if (toggle.Offset == Aircraft.pmdg737.ELEC_annunDRIVE[0])
                {
                    drive1TextBox.Text = toggle.CurrentState.Value;
                } // Drive 1

                if (toggle.Offset == Aircraft.pmdg737.ELEC_annunDRIVE[1])
                {
                    drive2TextBox.Text = toggle.CurrentState.Value;
                } // drive 2

                if (toggle.Offset == Aircraft.pmdg737.ELEC_annunSTANDBY_POWER_OFF)
                {
                    standbyPowerTextBox.Text = toggle.CurrentState.Value;
                } // standby power light.

                if (toggle.Offset == Aircraft.pmdg737.ELEC_annunGRD_POWER_AVAILABLE)
                {
                    gndPwrAvailTextBox.Text = toggle.CurrentState.Value;
                } // ground power available light

                if (toggle.Offset == Aircraft.pmdg737.ELEC_annunTRANSFER_BUS_OFF[0])
                {
                    xferBus1TextBox.Text = toggle.CurrentState.Value;
                } // xfer bus 1

                if (toggle.Offset == Aircraft.pmdg737.ELEC_annunTRANSFER_BUS_OFF[1])
                {
                    xferBus2TextBox.Text = toggle.CurrentState.Value;
                } // xfer bus 2

                if(toggle.Offset == Aircraft.pmdg737.ELEC_annunSOURCE_OFF[0])
                {
                    dcSourceTextBox.Text = toggle.CurrentState.Value;
                } // source 1

                if(toggle.Offset == Aircraft.pmdg737.ELEC_annunSOURCE_OFF[1])
                {
                    acSourceTextBox.Text = toggle.CurrentState.Value;
                } // source 2

                if(toggle.Offset == Aircraft.pmdg737.ELEC_annunGEN_BUS_OFF[0])
                {
                    gen1BusTextBox.Text = toggle.CurrentState.Value;
                }// gen 1 bus

                if(toggle.Offset == Aircraft.pmdg737.ELEC_annunGEN_BUS_OFF[1])
                {
                    gen2BusTextBox.Text = toggle.CurrentState.Value;
                } // gen 2 bus

                if(toggle.Offset == Aircraft.pmdg737.ELEC_annunAPU_GEN_OFF_BUS)
                {
                    apuGenBusTextBox.Text = toggle.CurrentState.Value;
                } // APU gen bus.


            } // end loop.
        }

        private void ctlElectrical_Load(object sender, EventArgs e)
        {
            electricalTimer.Tick += new EventHandler(electricalTimerTick);
            electricalTimer.Start();

            foreach(PanelObject control in electricalControls)
            {
                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.ELEC_StandbyPowerSelector)
                {
                    standbyPowerComboBox.SelectedIndex = toggle.CurrentState.Key;
                }
            }

            dcAmpsTextBox.Text = Aircraft.pmdg737.ELEC_MeterDisplayTop.Value.Substring(0, 3);
            dcVoltsTextBox.Text = Aircraft.pmdg737.ELEC_MeterDisplayBottom.Value.Substring(0, 3);
            acAmpsTextBox.Text = Aircraft.pmdg737.ELEC_MeterDisplayBottom.Value.Substring(8, 4);
            acVoltsTextBox.Text = Aircraft.pmdg737.ELEC_MeterDisplayBottom.Value.Substring(4, 4);
        }

        private void batterySelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Properties.pmdg737_offsets.Default.ELEC_BatSelector == false)
            {
                if (Tolk.DetectScreenReader() == "NVDA")
                {
                    Tolk.Output(batterySelectorComboBox.SelectedItem.ToString());
                }
            }
            PMDG737Aircraft.Battery(batterySelectorComboBox.SelectedIndex);

        }

        private void groundPwrButton_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle) electricalControls.Where(x => x.Offset == Aircraft.pmdg737.ELEC_GrdPwrSw).ToArray()[0];

            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.GroundPower(0);
            }
            else
            {
                PMDG737Aircraft.GroundPower(1);
            }
        }

        private void cabinUtilButton_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle)electricalControls.Where(x => x.Offset == Aircraft.pmdg737.ELEC_CabUtilSw).ToArray()[0];

            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.CabinUtility(0);
            }
            else
            {
                PMDG737Aircraft.CabinUtility(1);
            }
        }

        private void passSeatsButton_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle)electricalControls.Where(x => x.Offset == Aircraft.pmdg737.ELEC_IFEPassSeatSw).ToArray()[0];

            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.IFE(0);
            }
            else
            {
                PMDG737Aircraft.IFE(1);
            }
        }

        private void dcMeterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Properties.pmdg737_offsets.Default.ELEC_DCMeterSelector== false)
            {
                if (Tolk.DetectScreenReader() == "NVDA")
                {
                    Tolk.Output(dcMeterComboBox.SelectedItem.ToString());
                }
            }
            PMDG737Aircraft.DCSelector(dcMeterComboBox.SelectedIndex);

        }

        private void acSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Properties.pmdg737_offsets.Default.ELEC_ACMeterSelector== false)
            {
                if (Tolk.DetectScreenReader() == "NVDA")
                {
                    Tolk.Output(acSelectorComboBox.SelectedItem.ToString());
                }
            }
            PMDG737Aircraft.ACSelector(acSelectorComboBox.SelectedIndex);

        }

        private void standbyPowerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Properties.pmdg737_offsets.Default.ELEC_StandbyPowerSelector == false)
            {
                if (Tolk.DetectScreenReader() == "NVDA")
                {
                    Tolk.Output(standbyPowerComboBox.SelectedItem.ToString());
                }
            }
            pmdg pmdg = new pmdg();
            switch (standbyPowerComboBox.SelectedIndex)
            {
                case 0:
                    PMDG737Aircraft.StandbyBattery();
                    break;
                case 1:
                    PMDG737Aircraft.StandbyOff();
                    break;
                case 2:
                    PMDG737Aircraft.StandbyAuto();
                    break;
            }

        }

        private void idg1Button_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle)electricalControls.Where(x => x.Offset == Aircraft.pmdg737.ELEC_IDGDisconnectSw[0]).ToArray()[0];
            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.Idg1Disconnect(0);
            }
            else
            {
                PMDG737Aircraft.Idg1Disconnect(1);
            }
        }

        private void idg2Button_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle)electricalControls.Where(x => x.Offset == Aircraft.pmdg737.ELEC_IDGDisconnectSw[1]).ToArray()[0];

if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.Idg2Disconnect(0);
            }
            else
            {
                PMDG737Aircraft.Idg2Disconnect(1);
            }


        }

        private void generator1Button_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle)electricalControls.Where(x => x.Offset == Aircraft.pmdg737.ELEC_GenSw[0]).ToArray()[0];

            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.Generator1(0);
            }
            else
            {
                PMDG737Aircraft.Generator1(1);
            

            }
        }

        private void generator2Button_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle)electricalControls.Where(x => x.Offset == Aircraft.pmdg737.ELEC_GenSw[1]).ToArray()[0];

            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.Generator2(0);
            }
            else
            {
                PMDG737Aircraft.Generator2(1);
            }
        }

        private void apuGen1Button_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle)electricalControls.Where(x => x.Offset == Aircraft.pmdg737.ELEC_APUGenSw[0]).ToArray()[0];

            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.ApuGenerator1(0);
            }
            else
            {
                PMDG737Aircraft.ApuGenerator1(1);
            }
        }

        private void apuGen2Button_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle)electricalControls.Where(x => x.Offset == Aircraft.pmdg737.ELEC_APUGenSw[1]).ToArray()[0];

            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.ApuGenerator2(0);
            }
            else
            {
                PMDG737Aircraft.ApuGenerator2(1);
            }
        }

        private void busXferButton_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle)electricalControls.Where(x => x.Offset == Aircraft.pmdg737.ELEC_BusTransSw_AUTO).ToArray()[0];

            if(toggle.CurrentState.Value == "auto")
            {
                PMDG737Aircraft.BusTransferOff();
            }
            else
            {
                PMDG737Aircraft.BusTransferAuto();
            }
        }

           }
}