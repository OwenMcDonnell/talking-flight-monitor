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

namespace tfm.PMDG.PMDG_737.CockpitPanels
{
    public partial class ctlLowerForward : UserControl, iPanelsPage
    {

        private System.Timers.Timer lowerForwardTimer = new System.Timers.Timer();
        public ctlLowerForward()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void LowerForwardTimerTick(Object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {
            
            foreach(PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.LTS_MainPanelKnob[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftMainPanelBrtTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                    }
                } // Forward brightness, left side

                if(toggle.Offset == Aircraft.pmdg737.LTS_MainPanelKnob[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightMainPanelBrtTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                    }
                } // Forward panel brightness, right side.

                if(toggle.Offset == Aircraft.pmdg737.LTS_BackgroundKnob)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        mainPanelBckgndTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                    }
                } // panel background

                if(toggle.Offset == Aircraft.pmdg737.LTS_AFDSFloodKnob)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        afdsTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                    }
                } // AFDS

                if(toggle.Offset == Aircraft.pmdg737.LTS_OutbdDUBrtKnob[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftOutBdDUTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                    }
                } // outboard DU, left side.

                if(toggle.Offset == Aircraft.pmdg737.LTS_OutbdDUBrtKnob[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightOutbdDUTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                    }
                } // outboard DU, right side.

                if(toggle.Offset == Aircraft.pmdg737.LTS_InbdDUBrtKnob[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftInbdDUTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                    }
                } // Inboard DU, left side.

                if(toggle.Offset == Aircraft.pmdg737.LTS_InbdDUBrtKnob[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightInboardDUTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                    }
                } // inboard DU, right side.

                if(toggle.Offset == Aircraft.pmdg737.LTS_InbdDUMapBrtKnob[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftInbdMapTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                    }
                } // inboard map, left side.

                if(toggle.Offset == Aircraft.pmdg737.LTS_InbdDUMapBrtKnob[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightInbdMapTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                    }
                } // inboard map, right side.

                if(toggle.Offset == Aircraft.pmdg737.LTS_UpperDUBrtKnob)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        upperDUTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                    }
                } // upper du brightness.

                if(toggle.Offset == Aircraft.pmdg737.LTS_LowerDUBrtKnob)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        lowerDUTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                    }
                } // lower DU brightness.

                if(toggle.Offset == Aircraft.pmdg737.LTS_LowerDUMapBrtKnob)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        lowerMapTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                    }
                } // lower map brightness.

                if(toggle.Offset == Aircraft.pmdg737.GPWS_annunINOP)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        gpwsInopTextBox.Text = toggle.CurrentState.Value;
                    }
                } // GPWS inop.

                if(toggle.Offset == Aircraft.pmdg737.GPWS_FlapInhibitSw_NORM)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        flapsInhibitButton.Text = $"Flaps inhibit {toggle.CurrentState.Value}";
                        flapsInhibitButton.AccessibleName = $"Flaps inhibit {toggle.CurrentState.Value}";
                    }
                } // flaps inhibit.

                if(toggle.Offset == Aircraft.pmdg737.GPWS_GearInhibitSw_NORM)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        gearInhibitButton.Text = $"Gear inhibit {toggle.CurrentState.Value}";
                        gearInhibitButton.AccessibleName = $"Gear inhibit {toggle.CurrentState.Value}";
                    }
                } // gear inhibit.

                if(toggle.Offset == Aircraft.pmdg737.GPWS_TerrInhibitSw_NORM)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        terrainInhibitButton.Text = $"Terrain inhibit {toggle.CurrentState.Value}";
                        terrainInhibitButton.AccessibleName = $"Terrain inhibit {toggle.CurrentState.Value}";
                    }
                } // terrain inhibit.
            } // loop.

        }

        private void leftMainPanelBrtTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.I)
            {
                PMDG737Aircraft.LeftLowerMainPanelLightIncrease();
            }

            if(e.KeyCode == Keys.D)
            {
                PMDG737Aircraft.LeftLowerMainPanelLightDecrease();
                leftMainPanelBrtTextBox.Refresh();
            }

                   }

        private void ctlLowerForward_Load(object sender, EventArgs e)
        {
            lowerForwardTimer.Elapsed += new System.Timers.ElapsedEventHandler(LowerForwardTimerTick);
                        lowerForwardTimer.Start();
            foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.LTS_MainPanelKnob[0])
                {
                                                                leftMainPanelBrtTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                                    } // Forward brightness, left side

                if (toggle.Offset == Aircraft.pmdg737.LTS_MainPanelKnob[1])
                {
                                            rightMainPanelBrtTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                } // Forward panel brightness, right side.

                if (toggle.Offset == Aircraft.pmdg737.LTS_BackgroundKnob)
                {
                                                                mainPanelBckgndTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                                    } // panel background

                if (toggle.Offset == Aircraft.pmdg737.LTS_AFDSFloodKnob)
                {
                                            afdsTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                } // AFDS

                if (toggle.Offset == Aircraft.pmdg737.LTS_OutbdDUBrtKnob[0])
                {
                                                                leftOutBdDUTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                                    } // outboard DU, left side.

                if (toggle.Offset == Aircraft.pmdg737.LTS_OutbdDUBrtKnob[1])
                {
                                            rightOutbdDUTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                } // outboard DU, right side.

                if (toggle.Offset == Aircraft.pmdg737.LTS_InbdDUBrtKnob[0])
                {
                                                                leftInbdDUTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                                    } // Inboard DU, left side.

                if (toggle.Offset == Aircraft.pmdg737.LTS_InbdDUBrtKnob[1])
                {
                                            rightInboardDUTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                } // inboard DU, right side.

                if (toggle.Offset == Aircraft.pmdg737.LTS_InbdDUMapBrtKnob[0])
                {
                                                                leftInbdMapTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                                    } // inboard map, left side.

                if (toggle.Offset == Aircraft.pmdg737.LTS_InbdDUMapBrtKnob[1])
                {
                                            rightInbdMapTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                } // inboard map, right side.

                if (toggle.Offset == Aircraft.pmdg737.LTS_UpperDUBrtKnob)
                {
                                                                upperDUTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                                    } // upper du brightness.

                if (toggle.Offset == Aircraft.pmdg737.LTS_LowerDUBrtKnob)
                {
                                            lowerDUTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                } // lower DU brightness.

                if (toggle.Offset == Aircraft.pmdg737.LTS_LowerDUMapBrtKnob)
                {
                                                                lowerMapTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                                    } // lower map brightness.

                if (toggle.Offset == Aircraft.pmdg737.GPWS_annunINOP)
                {
                                            gpwsInopTextBox.Text = toggle.CurrentState.Value;
                } // GPWS inop.

                if (toggle.Offset == Aircraft.pmdg737.GPWS_FlapInhibitSw_NORM)
                {
                                                                flapsInhibitButton.Text = $"Flaps inhibit {toggle.CurrentState.Value}";
                        flapsInhibitButton.AccessibleName = $"Flaps inhibit {toggle.CurrentState.Value}";
                                    } // flaps inhibit.

                if (toggle.Offset == Aircraft.pmdg737.GPWS_GearInhibitSw_NORM)
                {
                                            gearInhibitButton.Text = $"Gear inhibit {toggle.CurrentState.Value}";
                        gearInhibitButton.AccessibleName = $"Gear inhibit {toggle.CurrentState.Value}";
                } // gear inhibit.

                if (toggle.Offset == Aircraft.pmdg737.GPWS_TerrInhibitSw_NORM)
                {
                                                                terrainInhibitButton.Text = $"Terrain inhibit {toggle.CurrentState.Value}";
                        terrainInhibitButton.AccessibleName = $"Terrain inhibit {toggle.CurrentState.Value}";
                                    } // terrain inhibit.
            } // loop.

        }

        private void rightMainPanelBrtTextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.I)
            {
                PMDG737Aircraft.RightMainPanelLightIncrease();
            }

            if(e.KeyCode == Keys.D)
            {
                PMDG737Aircraft.RightMainPanelLightDecrease();
                            }
        }

        private void mainPanelBckgndTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.I)
            {
                PMDG737Aircraft.MainPanelBackLightIncrease();
            }
            if(e.KeyCode == Keys.D)
            {
                PMDG737Aircraft.MainPanelBackLightDecrease();
            }
        }

        private void afdsTextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.I)
            {
                PMDG737Aircraft.AFDSFloodLightIncrease();
            }
            if(e.KeyCode == Keys.D)
            {
                PMDG737Aircraft.AFDSFloodLightDecrease();
            }
        }

        private void flapsInhibitButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.FlapsInhibit();
        }

        private void gearInhibitButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.GearInhibit();
        }

        private void terrainInhibitButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.TerrainInhibit();
        }

        private void leftOutBdDUTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.I)
            {
                PMDG737Aircraft.LeftOutbdDuLightIncrease();
            }
            if(e.KeyCode == Keys.D)
            {
                PMDG737Aircraft.LeftOutbdDuLightDecrease();
            }
        }

        private void rightOutbdDUTextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.I)
            {
                PMDG737Aircraft.RightOutbdDuLightIncrease();
            }
            if(e.KeyCode == Keys.D)
            {
                PMDG737Aircraft.RightOutbdDuLightDecrease();
            }
        }

        private void leftInbdDUTextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.I)
            {
                PMDG737Aircraft.LeftInbdDuLightIncrease();
            }
            if(e.KeyCode == Keys.D)
            {
                PMDG737Aircraft.LeftInbdDuLightDecrease();
            }
        }

        private void rightInboardDUTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.I)
            {
                PMDG737Aircraft.RightInbdDuLightIncrease();
            }
            if(e.KeyCode == Keys.D)
            {
                PMDG737Aircraft.RightInbdDuLightDecrease();
            }
        }

        private void leftInbdMapTextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.I)
            {
                                            PMDG737Aircraft.LeftInbdMapLightIncrease();
            }
            if(e.KeyCode == Keys.D)
            {
                PMDG737Aircraft.LeftInbdMapLightDecrease();
            }
        }

        private void rightInbdMapTextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.I)
            {
                PMDG737Aircraft.RightInbdMapLightIncrease();
            }
            if(e.KeyCode == Keys.D)
            {
                PMDG737Aircraft.RightInbdMapLightDecrease();
            }
        }

        private void upperDUTextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.I)
            {
                PMDG737Aircraft.UpperDuLightIncrease();
            }
            if(e.KeyCode == Keys.D)
            {
                PMDG737Aircraft.UpperDuLightDecrease();
            }
        }

        private void lowerDUTextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.I)
            {
                PMDG737Aircraft.LowerDuLightIncrease();
            }
            if(e.KeyCode == Keys.D)
            {
                PMDG737Aircraft.LowerDuLightDecrease();
            }
        }

        private void lowerMapTextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.I)
            {
                PMDG737Aircraft.LowerMapLightIncrease();
            }
            if(e.KeyCode == Keys.D)
            {
                PMDG737Aircraft.LowerMapLightDecrease();
            }
        }
    }
}
