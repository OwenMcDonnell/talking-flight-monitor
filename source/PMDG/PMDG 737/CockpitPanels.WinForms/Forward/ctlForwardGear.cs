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

namespace tfm.PMDG.PMDG_737.CockpitPanels.Forward
{
    public partial class ctlForwardGear : UserControl, iPanelsPage
    {

        private System.Timers.Timer gearTimer = new System.Timers.Timer();

        public ctlForwardGear()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void GearTimerTick(Object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach(PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.MAIN_GearLever)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        gearLeverButton.Text = $"&Gear {toggle.CurrentState.Value}";
                        gearLeverButton.AccessibleName = $"Gear {toggle.CurrentState.Value}";
                    }
                } // Gear lever

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunGEAR_transit[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        noseTransitTextBox.Text = toggle.CurrentState.Value;
                    }
                } // Nose in transit

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunGEAR_transit[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftTransitTextBox.Text = toggle.CurrentState.Value;
                    }
                } // left gear transit

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunGEAR_transit[2])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightTransitTextBox.Text = toggle.CurrentState.Value;
                    }
                } // right in transit

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunGEAR_locked[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        noseLockedTextBox.Text = toggle.CurrentState.Value;
                    }
                } // nose locked

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunGEAR_locked[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftLockedTextBox.Text = toggle.CurrentState.Value;
                    }
                } // left locked

                    if(toggle.Offset == Aircraft.pmdg737.MAIN_annunGEAR_locked[2])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightLockedTextBox.Text = toggle.CurrentState.Value;
                    }
                } // right locked
            } // loop.

        } // GearTimerTick

        private void ctlForwardGear_Load(object sender, EventArgs e)
        {

            gearTimer.Elapsed += new System.Timers.ElapsedEventHandler(GearTimerTick);
            gearTimer.Interval = 300;
            gearTimer.Start();

            foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.MAIN_GearLever)
                { 
                                                                                gearLeverButton.Text = $"&Gear {toggle.CurrentState.Value}";
                        gearLeverButton.AccessibleName = $"Gear {toggle.CurrentState.Value}";
                                    } // Gear lever

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunGEAR_transit[0])
                {
                                            noseTransitTextBox.Text = toggle.CurrentState.Value;
                } // Nose in transit

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunGEAR_transit[1])
                {
                                                                leftTransitTextBox.Text = toggle.CurrentState.Value;
                                    } // left gear transit

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunGEAR_transit[2])
                {
                                            rightTransitTextBox.Text = toggle.CurrentState.Value;
                } // right in transit

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunGEAR_locked[0])
                {
                                                                noseLockedTextBox.Text = toggle.CurrentState.Value;
                                    } // nose locked

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunGEAR_locked[1])
                {
                                            leftLockedTextBox.Text = toggle.CurrentState.Value;
                } // left locked

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunGEAR_locked[2])
                {
                                                                rightLockedTextBox.Text = toggle.CurrentState.Value;
                                    } // right locked
            } // loop.


        }

        private void gearLeverButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.Gear();
        }

        private void ctlForwardGear_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                gearTimer.Start();
            }
            else
            {
                gearTimer.Stop();
            }
        }
    }
}
