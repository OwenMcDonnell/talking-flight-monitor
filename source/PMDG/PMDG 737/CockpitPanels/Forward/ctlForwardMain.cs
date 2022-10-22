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
    public partial class ctlForwardMain : UserControl, iPanelsPage
    {

        System.Timers.Timer mainTimer = new System.Timers.Timer();

                        public ctlForwardMain()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void MainTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach(PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.MAIN_NoseWheelSteeringSwNORM)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        noseWheelSteeringButton.Text = $"Nose &wheel steering {toggle.CurrentState.Value}";
                        noseWheelSteeringButton.AccessibleName = $"Nose wheel steering {toggle.CurrentState.Value}";
                    }
                } // nose wheel steering

                if(toggle.Offset == Aircraft.pmdg737.MAIN_DisengageTestSelector[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftDisengageTestButton.Text = $"&Capt. disengage test {toggle.CurrentState.Value}";
                        leftDisengageTestButton.AccessibleName = $"Capt. disengage test {toggle.CurrentState.Value}";
                    }
                } // Disengage test 1

                if(toggle.Offset == Aircraft.pmdg737.MAIN_DisengageTestSelector[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightDisengageTestButton.Text = $"F/&O. disengage test {toggle.CurrentState.Value}";
                        rightDisengageTestButton.AccessibleName = $"F/O. disengage test {toggle.CurrentState.Value}";
                    }
                } // disengage test 2

                if(toggle.Offset == Aircraft.pmdg737.MAIN_LightsSelector)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        lightsButton.Text = $"Cockpit l&ights {toggle.CurrentState.Value}";
                        lightsButton.AccessibleName = $"Cockpit lights {toggle.CurrentState.Value}";
                    }
                } // Lights

                if(toggle.Offset == Aircraft.pmdg737.MAIN_FuelFlowSelector)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        fuelFlowButton.Text = $"&Fuel flow {toggle.CurrentState.Value}";
                        fuelFlowButton.AccessibleName = $"Fuel flow {toggle.CurrentState.Value}";
                    }
                } // Fuel flow

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunBELOW_GS[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftBelowGSTextBox.Text = toggle.CurrentState.Value;
                    }
                } // below GS 1

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunBELOW_GS[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightBelowGSTextBox.Text = toggle.CurrentState.Value;
                    }
                } // Below GS 2

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunFMC[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftFMCTextBox.Text = toggle.CurrentState.Value;
                    }
                } // left FMC

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunFMC[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightFMCTextBox.Text = toggle.CurrentState.Value;
                    }
                } // right FMC

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunSTAB_OUT_OF_TRIM)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        stabOutOfTrimTextBox.Text = toggle.CurrentState.Value;
                    }
                } // Stab out of trim.

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunANTI_SKID_INOP)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        antiSkidInopTextBox.Text = toggle.CurrentState.Value;
                    }
                } // anti skid.
            } // foreach
        } // MainTimerTick

        private void ctlForwardMain_Load(object sender, EventArgs e)
        {
            mainTimer.Elapsed += new System.Timers.ElapsedEventHandler(MainTimerTick);
            mainTimer.Start();

            foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.MAIN_NoseWheelSteeringSwNORM)
                {
                                                                noseWheelSteeringButton.Text = $"Nose &wheel steering {toggle.CurrentState.Value}";
                        noseWheelSteeringButton.AccessibleName = $"Nose wheel steering {toggle.CurrentState.Value}";
                                    } // nose wheel steering

                if (toggle.Offset == Aircraft.pmdg737.MAIN_DisengageTestSelector[0])
                {
                                            leftDisengageTestButton.Text = $"&Capt. disengage test {toggle.CurrentState.Value}";
                        leftDisengageTestButton.AccessibleName = $"Capt. disengage test {toggle.CurrentState.Value}";
                } // Disengage test 1

                if (toggle.Offset == Aircraft.pmdg737.MAIN_DisengageTestSelector[1])
                {
                                                                rightDisengageTestButton.Text = $"F/&O. disengage test {toggle.CurrentState.Value}";
                        rightDisengageTestButton.AccessibleName = $"F/O. disengage test {toggle.CurrentState.Value}";
                                    } // disengage test 2

                if (toggle.Offset == Aircraft.pmdg737.MAIN_LightsSelector)
                {
                                            lightsButton.Text = $"Cockpit l&ights {toggle.CurrentState.Value}";
                        lightsButton.AccessibleName = $"Cockpit lights {toggle.CurrentState.Value}";
                } // Lights

                if (toggle.Offset == Aircraft.pmdg737.MAIN_FuelFlowSelector)
                {
                                                                fuelFlowButton.Text = $"&Fuel flow {toggle.CurrentState.Value}";
                        fuelFlowButton.AccessibleName = $"Fuel flow {toggle.CurrentState.Value}";
                                    }

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunBELOW_GS[0])
                {
                                                                leftBelowGSTextBox.Text = toggle.CurrentState.Value;
                                    } // below GS 1

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunBELOW_GS[1])
                {
                                            rightBelowGSTextBox.Text = toggle.CurrentState.Value;
                } // Below GS 2

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunFMC[0])
                {
                                                                leftFMCTextBox.Text = toggle.CurrentState.Value;
                                    } // left FMC

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunFMC[1])
                {
                                            rightFMCTextBox.Text = toggle.CurrentState.Value;
                } // right FMC

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunSTAB_OUT_OF_TRIM)
                {
                                                                stabOutOfTrimTextBox.Text = toggle.CurrentState.Value;
                                    } // Stab out of trim.

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunANTI_SKID_INOP)
                {
                                            antiSkidInopTextBox.Text = toggle.CurrentState.Value;
                } // anti skid.

            } // foreach
        } // Load

        private void ctlForwardMain_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                mainTimer.Start();
            }
            else
            {
                mainTimer.Stop();
            }
            // Stop and start the timer based on visibility.
            if (this.Visible)
            {
                mainTimer.Enabled = true;
                mainTimer.Start();
            }
            else
            {
                mainTimer.Stop();
                mainTimer.Enabled = false;
            }
        } // VisibleChanged

        private void noseWheelSteeringButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.NoseWheelSteering();
        }

        private void leftDisengageTestButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.LeftDisengageTest();    
        }

        private void rightDisengageTestButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.RightDisengageTest();
        }

        private void lightsButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.Lights();
        }

        private void fuelFlowButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.FuelFlow();  
        }
    }
}
