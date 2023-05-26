using DavyKager;
using tfm.PMDG.PanelObjects;

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

namespace tfm.PMDG.PMDG_737.CockpitPanels.BottomOverhead
{
    public partial class ctlLights : UserControl, iPanelsPage
    {

        private System.Timers.Timer lightsTimer = new System.Timers.Timer();
        private PanelObject[] controls = PMDG737Aircraft.PanelControls.Where(x => x.PanelName == "Bottom Overhead" && x.PanelSection == "Lights").ToArray();

        private void LightsTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach(PanelObject control in controls)
            {
                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.LTS_LandingLtRetractableSw[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftRetractableComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.LTS_LandingLtRetractableSw[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightRetractableComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.LTS_LandingLtFixedSw[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftFixedButton.AccessibleName = $"Left fixed {toggle.CurrentState.Value}";
                        leftFixedButton.Text = $"Left fixed {toggle.CurrentState.Value}";
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.LTS_LandingLtFixedSw[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightFixedButton.AccessibleName = $"Right fixed {toggle.CurrentState.Value}";
                        rightFixedButton.Text = $"Right fixed {toggle.CurrentState.Value}";
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.LTS_RunwayTurnoffSw[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftTurnOffButton.AccessibleName = $"Left turnoff {toggle.CurrentState.Value}";
                        leftTurnOffButton.Text = $"Left turnoff {toggle.CurrentState.Value}";
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.LTS_RunwayTurnoffSw[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightTurnOffButton.Text = $"Right turnoff {toggle.CurrentState.Value}";
                        rightTurnOffButton.AccessibleName = $"Right turnoff {toggle.CurrentState.Value}";
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.LTS_TaxiSw)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        taxiButton.Text = $"&Taxi light {toggle.CurrentState.Value}";
                        taxiButton.AccessibleName = $"Taxi light {toggle.CurrentState.Value}";
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.LTS_LogoSw)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        logoButton.Text= $"Lo&go light {toggle.CurrentState.Value}";
                        logoButton.AccessibleName = $"Logo light {toggle.CurrentState.Value}";
                    }
                            }

                if(toggle.Offset == Aircraft.pmdg737.LTS_PositionSw)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        positionButton.Text = $"&Position lights {toggle.CurrentState.Value}";
                        positionButton.AccessibleName = $"Position lights {toggle.CurrentState.Value}";

                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.LTS_AntiCollisionSw)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        antiCollisionButton.AccessibleName = $"Anti-collision light {toggle.CurrentState.Value}";
                        antiCollisionButton.Text= $"&Anti-collision light {toggle.CurrentState.Value}";
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.LTS_WingSw)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        wingButton.AccessibleName = $"Wing lights {toggle.CurrentState.Value}";
                        wingButton.Text = $"&Wing lights {toggle.CurrentState.Value}";
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.LTS_WheelWellSw)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        wheelWellButton.AccessibleName = $"Wheel well lights {toggle.CurrentState.Value}";
                        wheelWellButton.Text = $"W&heel well lights {toggle.CurrentState.Value}";
                    }
                }

            }
        }

        public ctlLights()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlLights_Load(object sender, EventArgs e)
        {
            lightsTimer.Elapsed += new System.Timers.ElapsedEventHandler(LightsTimerTick);
            lightsTimer.Interval = 300;
            lightsTimer.Start();

            foreach (PanelObject control in controls)
            {
                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.LTS_LandingLtRetractableSw[0])
                {
                                                               leftRetractableComboBox.SelectedIndex = toggle.CurrentState.Key;
                                    }

                if (toggle.Offset == Aircraft.pmdg737.LTS_LandingLtRetractableSw[1])
                {
                                            rightRetractableComboBox.SelectedIndex = toggle.CurrentState.Key;
                }

                if (toggle.Offset == Aircraft.pmdg737.LTS_LandingLtFixedSw[0])
                {
                                                                leftFixedButton.AccessibleName = $"Left fixed {toggle.CurrentState.Value}";
                        leftFixedButton.Text = $"Left fixed {toggle.CurrentState.Value}";
                                    }

                if (toggle.Offset == Aircraft.pmdg737.LTS_LandingLtFixedSw[1])
                {
                        rightFixedButton.AccessibleName = $"Right fixed {toggle.CurrentState.Value}";
                        rightFixedButton.Text = $"Right fixed {toggle.CurrentState.Value}";
                                    }

                if (toggle.Offset == Aircraft.pmdg737.LTS_RunwayTurnoffSw[0])
                {
                                            leftTurnOffButton.AccessibleName = $"Left turnoff {toggle.CurrentState.Value}";
                        leftTurnOffButton.Text = $"Left turnoff {toggle.CurrentState.Value}";
                }

                if (toggle.Offset == Aircraft.pmdg737.LTS_RunwayTurnoffSw[1])
                {
                                                                rightTurnOffButton.Text = $"Right turnoff {toggle.CurrentState.Value}";
                        rightTurnOffButton.AccessibleName = $"Right turnoff {toggle.CurrentState.Value}";
                                    }

                if (toggle.Offset == Aircraft.pmdg737.LTS_TaxiSw)
                {
                                            taxiButton.Text = $"&Taxi light {toggle.CurrentState.Value}";
                        taxiButton.AccessibleName = $"Taxi light {toggle.CurrentState.Value}";
                }

                if (toggle.Offset == Aircraft.pmdg737.LTS_LogoSw)
                {
                                                                logoButton.Text = $"Lo&go light {toggle.CurrentState.Value}";
                        logoButton.AccessibleName = $"Logo light {toggle.CurrentState.Value}";
                                    }

                if (toggle.Offset == Aircraft.pmdg737.LTS_PositionSw)
                {
                    positionButton.Text = $"&Position lights {toggle.CurrentState.Value}";
                    positionButton.AccessibleName = $"Position lights {toggle.CurrentState.Value}";
                }

                if (toggle.Offset == Aircraft.pmdg737.LTS_AntiCollisionSw)
                {
                                                                antiCollisionButton.AccessibleName = $"Anti-collision light {toggle.CurrentState.Value}";
                    antiCollisionButton.Text = $"&Anti-collision light {toggle.CurrentState.Value}";
                }

                if (toggle.Offset == Aircraft.pmdg737.LTS_WingSw)
                {
                                                                wingButton.AccessibleName = $"Wing lights {toggle.CurrentState.Value}";
                        wingButton.Text = $"&Wing lights {toggle.CurrentState.Value}";
                                    }

                if (toggle.Offset == Aircraft.pmdg737.LTS_WheelWellSw)
                {
                                            wheelWellButton.AccessibleName = $"Wheel well lights {toggle.CurrentState.Value}";
                        wheelWellButton.Text = $"W&heel well lights {toggle.CurrentState.Value}";
                }

            }

        }

        private void leftRetractableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(Properties.pmdg737_offsets.Default.LTS_LandingLtRetractableSw1 == false)
            {
                if(Tolk.DetectScreenReader() == "NVDA")
                {
                    Tolk.Output(leftRetractableComboBox.SelectedItem.ToString());
                }
            }

            PMDG737Aircraft.LeftRetractableLandingLights(leftRetractableComboBox.SelectedIndex);
        }

        private void rightRetractableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(Properties.pmdg737_offsets.Default.LTS_LandingLtRetractableSw2 == false)
            {
                if(Tolk.DetectScreenReader() == "NVDA")
                {
                    Tolk.Output(rightRetractableComboBox.SelectedItem.ToString());
                }
            }

            PMDG737Aircraft.RightRetractableLandingLights(rightRetractableComboBox.SelectedIndex);
        }

        private void leftFixedButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.LeftFixedLandingLight();


        }

        private void rightFixedButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.RightFixedLandingLights();
        }

        private void leftTurnOffButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.LeftTurnOffLights();
        }

        private void rightTurnOffButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.RightTurnOffLights();
        }

        private void taxiButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.TaxiLights();
        }

                private void positionButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.PositionLights();
        }

        private void logoButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.LogoLights();
        }

        private void antiCollisionButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.AntiCollisionLights();
        }

        private void wingButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.WingLights();
        }

        private void wheelWellButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.WheelWellLights();
        }

        private void ctlLights_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                lightsTimer.Start();
            }
            else
            {
                lightsTimer.Stop();
            }

        }
    }
}
