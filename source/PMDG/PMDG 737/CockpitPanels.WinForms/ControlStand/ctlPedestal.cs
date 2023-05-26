using tfm.PMDG.PanelObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.PMDG.PMDG_737.CockpitPanels.ControlStand
{
    public partial class ctlPedestal : UserControl, iPanelsPage
    {

        System.Timers.Timer pedistalTimer = new System.Timers.Timer();
        public ctlPedestal()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void PedistalTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach(PanelObject control in PMDG737Aircraft.PanelControls)
            {
                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.LTS_PedFloodKnob)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        pedestalFloodTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                    }
                } // pedistal flood knob.

                if(toggle.Offset == Aircraft.pmdg737.LTS_PedPanelKnob)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        panelBrightnessTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                    }
                } // Panel brightness.

                if(toggle.Offset == Aircraft.pmdg737.PED_annunAUTO_UNLK)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        autoUnlockTextBox.Text = toggle.CurrentState.Value;
                    }
                } // auto unlock indicator.

                if(toggle.Offset == Aircraft.pmdg737.PED_annunLOCK_FAIL)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        pedestalUnlockFailTextBox.Text = toggle.CurrentState.Value;
                    }
                } // unlock failure indicator.

                if(toggle.Offset == Aircraft.pmdg737.PED_annunParkingBrake)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        parkingBrakeTextBox.Text = toggle.CurrentState.Value;
                        parkingBrakeButton.Text = $"&Parking brake {toggle.CurrentState.Value}";
                        parkingBrakeButton.AccessibleName = $"Parking brake {toggle.CurrentState.Value}";
                    }
                } // parking brake indicator.

                if(toggle.Offset == Aircraft.pmdg737.PED_FltDkDoorSel)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        fltDeckDoorButton.Text = $"Flt &dck door {toggle.CurrentState.Value}";
                        fltDeckDoorButton.AccessibleName = $"Flight deck door {toggle.CurrentState.Value}";
                    }
                } // Flight deck door

                           }

        } // PedestalTimerTick

        private void ctlPedestal_Load(object sender, EventArgs e)
        {
            pedistalTimer.Elapsed += new System.Timers.ElapsedEventHandler(PedistalTimerTick);
            pedistalTimer.Start();

            foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {
                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.LTS_PedFloodKnob)
                {
                                                                pedestalFloodTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                                    } // pedistal flood knob.

                if (toggle.Offset == Aircraft.pmdg737.LTS_PedPanelKnob)
                {
                                           panelBrightnessTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                                    } // Panel brightness.

                if (toggle.Offset == Aircraft.pmdg737.PED_annunAUTO_UNLK)
                {
                                            autoUnlockTextBox.Text = toggle.CurrentState.Value;
                } // auto unlock indicator.

                if (toggle.Offset == Aircraft.pmdg737.PED_annunLOCK_FAIL)
                {
                                                                pedestalUnlockFailTextBox.Text = toggle.CurrentState.Value;
                                    } // unlock failure indicator.

                if (toggle.Offset == Aircraft.pmdg737.PED_annunParkingBrake)
                {
                                            parkingBrakeTextBox.Text = toggle.CurrentState.Value;
                    parkingBrakeButton.Text = $"&Parking brake {toggle.CurrentState.Value}";
                    parkingBrakeButton.AccessibleName = $"Parking brake {toggle.CurrentState.Value}";

                } // parking brake indicator.

                if (toggle.Offset == Aircraft.pmdg737.PED_FltDkDoorSel)
                {
                    fltDeckDoorButton.Text = $"Flt &dck door {toggle.CurrentState.Value}";
                    fltDeckDoorButton.AccessibleName = $"Flight deck door {toggle.CurrentState.Value}";

                } // Flight deck door.
            }


        }

        private void pedestalFloodTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.I)
            {
                PMDG737Aircraft.PedestalFloodIncrease();
            }
            if(e.KeyCode == Keys.D)
            {
                PMDG737Aircraft.PedestalFloodDecrease();
            }
        }

        private void panelBrightnessTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.D)
            {
                PMDG737Aircraft.PedestalPanelBrightnessDecrease();
            }
            if(e.KeyCode == Keys.I)
            {
                PMDG737Aircraft.PedestalPanelBrightnessIncrease();
            }
        }

        private void fltDeckDoorButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.FlightDeckDoor();
        }

        private void parkingBrakeButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.ParkingBrake();
        }
    }
}
