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
            public partial class ctlCargoFire : UserControl, iPanelsPage
    {

        System.Timers.Timer cargoTimer = new System.Timers.Timer();

        public ctlCargoFire()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void CargoTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach(PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.CARGO_DetSelect[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        fwdDetectorButton.Text = $"&FWD SEL {toggle.CurrentState.Value}";
                        fwdDetectorButton.AccessibleName = $"Forward selector {toggle.CurrentState.Value}";
                    }
                } // FWD detector.

                if(toggle.Offset == Aircraft.pmdg737.CARGO_DetSelect[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        aftDetectorButton.Text = $"&AFT SEL {toggle.CurrentState.Value}";
                        aftDetectorButton.AccessibleName = $"AFT selector {toggle.CurrentState.Value}";
                    }
                } // AFT detector.

                if(toggle.Offset == Aircraft.pmdg737.CARGO_ArmedSw[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        fwdArmedButton.Text = $"F&WD DET arm {toggle.CurrentState.Value}";
                        fwdArmedButton.AccessibleName = $"Forward detector {toggle.CurrentState.Value}";
                    }
                } // FWD arm

                if(toggle.Offset == Aircraft.pmdg737.CARGO_ArmedSw[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        aftArmedButton.Text = $"AFT D&ET {toggle.CurrentState.Value}";
                        aftArmedButton.AccessibleName = $"AFT detector {toggle.CurrentState.Value}";
                    }
                } // AFT arm

                if(toggle.Offset == Aircraft.pmdg737.CARGO_annunExtTest[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        fwdTestTextBox.Text = toggle.CurrentState.Value;
                    }
                } // FWD test

                if(toggle.Offset == Aircraft.pmdg737.CARGO_annunExtTest[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        aftTestTextBox.Text = toggle.CurrentState.Value;
                    }
                } // AFT test

                if(toggle.Offset == Aircraft.pmdg737.CARGO_annunFWD)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        fwdFireTextBox.Text = toggle.CurrentState.Value;
                    }
                } // FWD fire

                if(toggle.Offset == Aircraft.pmdg737.CARGO_annunAFT)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        aftFireTextBox.Text = toggle.CurrentState.Value;
                    }
                } // AFT fire

                if(toggle.Offset == Aircraft.pmdg737.CARGO_annunDETECTOR_FAULT)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        detectorFaultTextBox.Text = toggle.CurrentState.Value;
                    }
                } // fault

                if(toggle.Offset == Aircraft.pmdg737.CARGO_annunDISCH)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        dischargeTextBox.Text = toggle.CurrentState.Value;
                    }
                } // discharge
            } // loop
        }

        private void ctlCargoFire_Load(object sender, EventArgs e)
        {

            cargoTimer.Elapsed += new System.Timers.ElapsedEventHandler(CargoTimerTick);
            cargoTimer.Interval = 300;
            cargoTimer.Start();

            foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.CARGO_DetSelect[0])
                {
                                                                fwdDetectorButton.Text = $"&FWD SEL {toggle.CurrentState.Value}";
                        fwdDetectorButton.AccessibleName = $"Forward selector {toggle.CurrentState.Value}";
                                    } // FWD detector.

                if (toggle.Offset == Aircraft.pmdg737.CARGO_DetSelect[1])
                {
                                            aftDetectorButton.Text = $"&AFT SEL {toggle.CurrentState.Value}";
                        aftDetectorButton.AccessibleName = $"AFT selector {toggle.CurrentState.Value}";
                } // AFT detector.

                if (toggle.Offset == Aircraft.pmdg737.CARGO_ArmedSw[0])
                {
                                                                fwdArmedButton.Text = $"F&WD DET arm {toggle.CurrentState.Value}";
                        fwdArmedButton.AccessibleName = $"Forward detector {toggle.CurrentState.Value}";
                                    } // FWD arm

                if (toggle.Offset == Aircraft.pmdg737.CARGO_ArmedSw[1])
                {
                                            aftArmedButton.Text = $"AFT D&ET {toggle.CurrentState.Value}";
                        aftArmedButton.AccessibleName = $"AFT detector {toggle.CurrentState.Value}";
                } // AFT arm

                if (toggle.Offset == Aircraft.pmdg737.CARGO_annunExtTest[0])
                {
                                                                fwdTestTextBox.Text = toggle.CurrentState.Value;
                                    } // FWD test

                if (toggle.Offset == Aircraft.pmdg737.CARGO_annunExtTest[1])
                {
                                            aftTestTextBox.Text = toggle.CurrentState.Value;
                } // AFT test

                if (toggle.Offset == Aircraft.pmdg737.CARGO_annunFWD)
                {
                                                                fwdFireTextBox.Text = toggle.CurrentState.Value;
                                    } // FWD fire

                if (toggle.Offset == Aircraft.pmdg737.CARGO_annunAFT)
                {
                                            aftFireTextBox.Text = toggle.CurrentState.Value;
                } // AFT fire

                if (toggle.Offset == Aircraft.pmdg737.CARGO_annunDETECTOR_FAULT)
                {
                                                                detectorFaultTextBox.Text = toggle.CurrentState.Value;
                                    } // fault

                if (toggle.Offset == Aircraft.pmdg737.CARGO_annunDISCH)
                {
                                            dischargeTextBox.Text = toggle.CurrentState.Value;
                } // discharge
            } // loop

        }

        private void ctlCargoFire_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                cargoTimer.Start();
            }
            else
            {
                cargoTimer.Stop();
            }
        }

        private void fwdDetectorButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.ForwardCargoFireSelector();
        }

        private void aftDetectorButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.AftCargoFireSelector();
        }

        private void fwdArmedButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.ForwardCargoFireArm();
        }

        private void aftArmedButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.AftCargoFireArm();
        }

        private void dischargeButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.CargoFireDischarge();
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            FSUIPC.FSUIPCConnection.SendControlToFS(FSUIPC.PMDG_737_NGX_Control.EVT_CARGO_FIRE_TEST_SWITCH, Aircraft.ClkL); 
        }
    }
}
