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
    public partial class ctlForwardBrakes : UserControl, iPanelsPage
    {

        private System.Timers.Timer brakesTimer = new System.Timers.Timer();

        public ctlForwardBrakes()
        {
            InitializeComponent();
        }

        private void BrakesTimerTick(Object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach(PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.MAIN_AutobrakeSelector)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        autoBrakeTextBox.Text = toggle.CurrentState.Value;
                    }
                                                        } // auto brake

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunSPEEDBRAKE_ARMED)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        speedBrakeArmedTextBox.Text = toggle.CurrentState.Value;
                    }
                } // speed brake armed

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunSPEEDBRAKE_DO_NOT_ARM)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        speedBrakeDoNotArmTextBox.Text = toggle.CurrentState.Value;
                    }
                } // speed brake do not arm

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunSPEEDBRAKE_EXTENDED)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        speedBrakeExtendedTextBox.Text = toggle.CurrentState.Value;
                    }
                } // speed brake extended

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunAUTO_BRAKE_DISARM)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        autoBrakeDisarmTextBox.Text = toggle.CurrentState.Value;
                    }
                } // autobrake disarm
                                                          } // loop

            if (Aircraft.pmdg737.MAIN_BrakePressNeedle.ValueChanged)
            {
                brakeNeedleTextBox.Text = Math.Round(Aircraft.pmdg737.MAIN_BrakePressNeedle.Value, 0).ToString();
            } // brake needle

        }

        private void autoBrakeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Alt && e.KeyCode == Keys.D1) ||
    (e.Alt && e.KeyCode == Keys.D2) ||
    (e.Alt && e.KeyCode == Keys.D3)) return;
            if (e.KeyCode == Keys.O)
            {
                PMDG737Aircraft.AutoBrake(1);
            }
            if (e.KeyCode == Keys.R)
            {
                PMDG737Aircraft.AutoBrake(0);
            }
            if (e.KeyCode == Keys.D)
            {
                PMDG737Aircraft.AutoBrake(2);
            }
            if (e.KeyCode == Keys.D1)
            {
                PMDG737Aircraft.AutoBrake(3);
            }
            if (e.KeyCode == Keys.D2)
            {
                PMDG737Aircraft.AutoBrake(4);
            }
            if (e.KeyCode == Keys.D3)
            {
                PMDG737Aircraft.AutoBrake(5);
            }

        }

        private void autoBrakeTextBox_Enter(object sender, EventArgs e)
        {
            autoBrakeTextBox.Select(autoBrakeTextBox.Text.Length, 0);
        }

        public void SetDocking()
        {
            
        }

        private void ctlForwardBrakes_Load(object sender, EventArgs e)
        {

            brakesTimer.Elapsed += new System.Timers.ElapsedEventHandler(BrakesTimerTick);
            brakesTimer.Interval = 300;
            brakesTimer.Start();

            foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.MAIN_AutobrakeSelector)
                {
                                                                autoBrakeTextBox.Text = toggle.CurrentState.Value;
                                    } // auto brake

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunSPEEDBRAKE_ARMED)
                {
                                            speedBrakeArmedTextBox.Text = toggle.CurrentState.Value;
                } // speed brake armed

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunSPEEDBRAKE_DO_NOT_ARM)
                {
                                                                speedBrakeDoNotArmTextBox.Text = toggle.CurrentState.Value;
                                    } // speed brake do not arm

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunSPEEDBRAKE_EXTENDED)
                {
                                            speedBrakeExtendedTextBox.Text = toggle.CurrentState.Value;
                } // speed brake extended

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunAUTO_BRAKE_DISARM)
                {
                                                                autoBrakeDisarmTextBox.Text = toggle.CurrentState.Value;
                                    } // autobrake disarm
            } // loop

                                        brakeNeedleTextBox.Text = Math.Round(Aircraft.pmdg737.MAIN_BrakePressNeedle.Value, 0).ToString();
            
        }

        private void ctlForwardBrakes_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                brakesTimer.Start();
            }
            else
            {
                brakesTimer.Stop();
            }
        }
    }
}
