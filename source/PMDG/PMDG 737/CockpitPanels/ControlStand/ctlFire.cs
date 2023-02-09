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

namespace tfm.PMDG.PMDG_737.CockpitPanels.ControlStand
{
    public partial class ctlFire : UserControl, iPanelsPage
    {

        System.Timers.Timer fireTimer = new System.Timers.Timer();

        public ctlFire()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        public void FireTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {
            foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {
                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.FIRE_HandlePos[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        engine1FireHandleButton.Text = $"Eng/L {toggle.CurrentState.Value}";
                        engine1FireHandleButton.AccessibleName = $"Engine #1 {toggle.CurrentState.Value}";
                    }
                } // Engine 1 fire handle

                if (toggle.Offset == Aircraft.pmdg737.FIRE_HandlePos[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        engine2FireHandleButton.Text = $"Eng/R {toggle.CurrentState.Value}";
                        engine2FireHandleButton.AccessibleName = $"Engine #2 {toggle.CurrentState.Value}";
                    }
                } // Engine #2 fire handle.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_HandlePos[2])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        apuFireHandleButton.Text = $"APU {toggle.CurrentState.Value}";
                        apuFireHandleButton.AccessibleName = $"APU {toggle.CurrentState.Value}";
                    }
                } // APU fire handle.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_DetTestSw)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        fireTestButton.Text = $"Fire &test {toggle.CurrentState.Value}";
                        fireTestButton.AccessibleName = $"Fire test {toggle.CurrentState.Value}";
                    }
                } // detection test.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_OvhtDetSw[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftOverheatDetectButton.Text = $"Ovht det/L {toggle.CurrentState.Value}";
                        leftOverheatDetectButton.AccessibleName = $"Left overheat detect {toggle.CurrentState.Value}";
                    }
                } // Left overheat detect.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_OvhtDetSw[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightOverHeatDetectButton.Text = $"Ovht detect/R {toggle.CurrentState.Value}";
                        rightOverHeatDetectButton.AccessibleName = $"Right overheat detect {toggle.CurrentState.Value}";
                    }
                } // right overheat detect.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_ExtinguisherTestSw)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        fireExtinguisherTestButton.Text = $"Extinguisher test {toggle.CurrentState.Value}";
                        fireExtinguisherTestButton.AccessibleName = $"Fire extinguisher test {toggle.CurrentState.Value}";
                    }
                } // Fire extinguisher test

                if (toggle.Offset == Aircraft.pmdg737.FIRE_HandleIlluminated[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        engine1HandleTextBox.Text = toggle.CurrentState.Value;
                    }
                } // Eng 1 handle light

                if (toggle.Offset == Aircraft.pmdg737.FIRE_HandleIlluminated[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        engine2HandleTextBox.Text = toggle.CurrentState.Value;
                    }
                } // Eng #2 handle light

                if (toggle.Offset == Aircraft.pmdg737.FIRE_HandleIlluminated[2])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        apuHandleTextBox.Text = toggle.CurrentState.Value;
                    }
                } // APU handle light

                if (toggle.Offset == Aircraft.pmdg737.FIRE_annunENG_OVERHEAT[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        engine1OverheatTextBox.Text = toggle.CurrentState.Value;
                    }
                } // Eng 1 overheat light.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_annunENG_OVERHEAT[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        engine2OverheatTextBox.Text = toggle.CurrentState.Value;
                    }
                } // Eng 2 overheat light

                if (toggle.Offset == Aircraft.pmdg737.FIRE_annunWHEEL_WELL)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        wheelWellTextBox.Text = toggle.CurrentState.Value;
                    }
                } // Wheel well light.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_annunFAULT)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        faultTextBox.Text = toggle.CurrentState.Value;
                    }
                } // fire fault light.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_annunAPU_DET_INOP)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        apuInopTextBox.Text = toggle.CurrentState.Value;
                    }
                } // APU inop light.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_annunAPU_BOTTLE_DISCHARGE)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        apuBottleDischargeTextBox.Text = toggle.CurrentState.Value;
                    }
                } // APU bottle discharge light.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_annunBOTTLE_DISCHARGE[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        eng1BottleDischargeTextBox.Text = toggle.CurrentState.Value;
                    }
                } // Eng 1 bottle discharge light.

                if(toggle.Offset == Aircraft.pmdg737.FIRE_annunBOTTLE_DISCHARGE[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        eng2BottleDischargeTextBox.Text = toggle.CurrentState.Value;
                    }
                } // Eng 2 bottle discharge light.

                if(toggle.Offset == Aircraft.pmdg737.FIRE_annunExtinguisherTest[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        eng1ExtinguisherTextBox.Text = toggle.CurrentState.Value;
                    }
                } // Extinguisher test 1.

                if(toggle.Offset == Aircraft.pmdg737.FIRE_annunExtinguisherTest[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        eng2ExtinguisherTextBox.Text = toggle.CurrentState.Value;
                    }
                } // extinguisher test 2.

                if(toggle.Offset == Aircraft.pmdg737.FIRE_annunExtinguisherTest[2])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        apuExtinguisherTextBox.Text = toggle.CurrentState.Value;
                    }
                } // APU extinguisher test.
                   } // loop

                                                        }

        private void ctlFire_Load(object sender, EventArgs e)
        {
            fireTimer.Elapsed += new System.Timers.ElapsedEventHandler(FireTimerTick);
            fireTimer.Start();

            foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {
                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.FIRE_HandlePos[0])
                {
                                                                engine1FireHandleButton.Text = $"Eng/L {toggle.CurrentState.Value}";
                        engine1FireHandleButton.AccessibleName = $"Engine #1 {toggle.CurrentState.Value}";
                                    } // Engine 1 fire handle

                if (toggle.Offset == Aircraft.pmdg737.FIRE_HandlePos[1])
                {
                                            engine2FireHandleButton.Text = $"Eng/R {toggle.CurrentState.Value}";
                        engine2FireHandleButton.AccessibleName = $"Engine #2 {toggle.CurrentState.Value}";
                } // Engine #2 fire handle.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_HandlePos[2])
                {
                                                                apuFireHandleButton.Text = $"APU {toggle.CurrentState.Value}";
                        apuFireHandleButton.AccessibleName = $"APU {toggle.CurrentState.Value}";
                                    } // APU fire handle.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_DetTestSw)
                {
                                            fireTestButton.Text = $"Fire &test {toggle.CurrentState.Value}";
                        fireTestButton.AccessibleName = $"Fire test {toggle.CurrentState.Value}";
                } // detection test.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_OvhtDetSw[0])
                {
                                                                leftOverheatDetectButton.Text = $"Ovht det/L {toggle.CurrentState.Value}";
                        leftOverheatDetectButton.AccessibleName = $"Left overheat detect {toggle.CurrentState.Value}";
                                    } // Left overheat detect.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_OvhtDetSw[1])
                {
                                            rightOverHeatDetectButton.Text = $"Ovht detect/R {toggle.CurrentState.Value}";
                        rightOverHeatDetectButton.AccessibleName = $"Right overheat detect {toggle.CurrentState.Value}";
                } // right overheat detect.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_ExtinguisherTestSw)
                {
                                                                fireExtinguisherTestButton.Text = $"Extinguisher test {toggle.CurrentState.Value}";
                        fireExtinguisherTestButton.AccessibleName = $"Fire extinguisher test {toggle.CurrentState.Value}";
                                    } // Fire extinguisher test

                if (toggle.Offset == Aircraft.pmdg737.FIRE_HandleIlluminated[0])
                {
                                            engine1HandleTextBox.Text = toggle.CurrentState.Value;
                } // Eng 1 handle light

                if (toggle.Offset == Aircraft.pmdg737.FIRE_HandleIlluminated[1])
                {
                                                                engine2HandleTextBox.Text = toggle.CurrentState.Value;
                                    } // Eng #2 handle light

                if (toggle.Offset == Aircraft.pmdg737.FIRE_HandleIlluminated[2])
                {
                                            apuHandleTextBox.Text = toggle.CurrentState.Value;
                } // APU handle light

                if (toggle.Offset == Aircraft.pmdg737.FIRE_annunENG_OVERHEAT[0])
                {
                                                                engine1OverheatTextBox.Text = toggle.CurrentState.Value;
                                    } // Eng 1 overheat light.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_annunENG_OVERHEAT[1])
                {
                                            engine2OverheatTextBox.Text = toggle.CurrentState.Value;
                } // Eng 2 overheat light

                if (toggle.Offset == Aircraft.pmdg737.FIRE_annunWHEEL_WELL)
                {
                                                                wheelWellTextBox.Text = toggle.CurrentState.Value;
                                    } // Wheel well light.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_annunFAULT)
                {
                                            faultTextBox.Text = toggle.CurrentState.Value;
                } // fire fault light.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_annunAPU_DET_INOP)
                {
                                                                apuInopTextBox.Text = toggle.CurrentState.Value;
                                    } // APU inop light.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_annunAPU_BOTTLE_DISCHARGE)
                {
                                            apuBottleDischargeTextBox.Text = toggle.CurrentState.Value;
                } // APU bottle discharge light.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_annunBOTTLE_DISCHARGE[0])
                {
                                                                eng1BottleDischargeTextBox.Text = toggle.CurrentState.Value;
                                    } // Eng 1 bottle discharge light.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_annunBOTTLE_DISCHARGE[1])
                {
                                            eng2BottleDischargeTextBox.Text = toggle.CurrentState.Value;
                } // Eng 2 bottle discharge light.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_annunExtinguisherTest[0])
                {
                                                                eng1ExtinguisherTextBox.Text = toggle.CurrentState.Value;
                                    } // Extinguisher test 1.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_annunExtinguisherTest[1])
                {
                                            eng2ExtinguisherTextBox.Text = toggle.CurrentState.Value;
                } // extinguisher test 2.

                if (toggle.Offset == Aircraft.pmdg737.FIRE_annunExtinguisherTest[2])
                {
                                                                apuExtinguisherTextBox.Text = toggle.CurrentState.Value;
                                    } // APU extinguisher test.
            } // loop
                    }

        private void engine1FireHandleButton_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.L)
            {
                PMDG737Aircraft.Engine1FireHandleTurnLeft();
            }
                                   if(e.KeyCode == Keys.R)
            {
                PMDG737Aircraft.Engine1FireHandleTurnRight();
            }
                                   if(e.KeyCode == Keys.P)
            {
                PMDG737Aircraft.Engine1FireHandlePushPull();
            }
                                          }

        private void fireTestButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.FireTest();
        }

        private void leftOverheatDetectButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.LeftFireOverheatDetector();
        }

        private void rightOverHeatDetectButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.RightFireOverheatDetector();
        }

        private void fireExtinguisherTestButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.FireExtinguisherTest();
        }

        private void alarmCutOffButton_Click(object sender, EventArgs e)
        {   
            PMDG737Aircraft.FireAlarmCuttoff();
        }

        private void apuFireHandleButton_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.P)
            {
                PMDG737Aircraft.PushPullApuFireHandle();
            }
            if(e.KeyCode == Keys.L)
            {
                PMDG737Aircraft.ApuFireHandleLeft();
            }
            if(e.KeyCode == Keys.R)
            {
                PMDG737Aircraft.ApuFireHandleRight();
            }
        }

        private void engine2FireHandleButton_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.P)
            {
                PMDG737Aircraft.PushPullEngine2FireHandle();
            }
            if(e.KeyCode == Keys.L)
            {
                PMDG737Aircraft.Engine2FireHandleLeft();
            }
            if(e.KeyCode == Keys.R)
            {
                PMDG737Aircraft.Engine2FireHandleRight();
            }

        }
    }
}
