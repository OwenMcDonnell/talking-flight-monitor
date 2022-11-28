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
    public partial class ctlControlStandCDU : UserControl, iPanelsPage
    {

        System.Timers.Timer cduTimer = new System.Timers.Timer();
        public ctlControlStandCDU()
        {
                                    InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void CduTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach(PanelObject control in PMDG737Aircraft.PanelControls)
            {

                SingleStateToggle toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.CDU_annunEXEC[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftExecuteTextBox.Text = toggle.CurrentState.Value;
                    }
                } // left execute key.

                if(toggle.Offset == Aircraft.pmdg737.CDU_annunEXEC[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightExecuteTextBox.Text = toggle.CurrentState.Value;
                    }
                } // right execute key.

                if(toggle.Offset == Aircraft.pmdg737.CDU_annunCALL[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftCallTextBox.Text = toggle.CurrentState.Value;
                    }
                } // left call.

                if(toggle.Offset == Aircraft.pmdg737.CDU_annunCALL[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightCallTextBox.Text = toggle.CurrentState.Value;
                    }
                } // right call.

                if(toggle.Offset == Aircraft.pmdg737.CDU_annunFAIL[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftFailTextBox.Text = toggle.CurrentState.Value;
                    }
                } // left fail.

                if(toggle.Offset == Aircraft.pmdg737.CDU_annunFAIL[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightFailTextBox.Text = toggle.CurrentState.Value;
                    }
                } // right fail.

                if(toggle.Offset == Aircraft.pmdg737.CDU_annunMSG[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftMessageTextBox.Text = toggle.CurrentState.Value;
                    }
                } // left message

                if(toggle.Offset == Aircraft.pmdg737.CDU_annunMSG[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightMessageTextBox.Text = toggle.CurrentState.Value;
                    }
                } // right message

                if(toggle.Offset == Aircraft.pmdg737.CDU_annunOFST[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftOffsetTextBox.Text = toggle.CurrentState.Value;
                    }
                } // left offset.

                if(toggle.Offset == Aircraft.pmdg737.CDU_annunOFST[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightOffsetTextBox.Text = toggle.CurrentState.Value;
                    }
                } // right offset

                if(toggle.Offset == Aircraft.pmdg737.CDU_BrtKnob[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftBrightnessTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                    }
                } // left brightness

                if(toggle.Offset == Aircraft.pmdg737.CDU_BrtKnob[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightBrightnessTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                    }
                } // right brightness.
            } // loop
        }

        private void ctlControlStandCDU_Load(object sender, EventArgs e)
        {

            cduTimer.Elapsed += new System.Timers.ElapsedEventHandler(CduTimerTick);
            cduTimer.Start();           
            foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {

                SingleStateToggle toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.CDU_annunEXEC[0])
                {
                                                                leftExecuteTextBox.Text = toggle.CurrentState.Value;
                                    } // left execute key.

                if (toggle.Offset == Aircraft.pmdg737.CDU_annunEXEC[1])
                {
                                            rightExecuteTextBox.Text = toggle.CurrentState.Value;
                } // right execute key.

                if (toggle.Offset == Aircraft.pmdg737.CDU_annunCALL[0])
                {
                                                                leftCallTextBox.Text = toggle.CurrentState.Value;
                                    } // left call.

                if (toggle.Offset == Aircraft.pmdg737.CDU_annunCALL[1])
                {
                                            rightCallTextBox.Text = toggle.CurrentState.Value;
                } // right call.

                if (toggle.Offset == Aircraft.pmdg737.CDU_annunFAIL[0])
                {
                                                                leftFailTextBox.Text = toggle.CurrentState.Value;
                                    } // left fail.

                if (toggle.Offset == Aircraft.pmdg737.CDU_annunFAIL[1])
                {
                                            rightFailTextBox.Text = toggle.CurrentState.Value;
                } // right fail.

                if (toggle.Offset == Aircraft.pmdg737.CDU_annunMSG[0])
                {
                                                                leftMessageTextBox.Text = toggle.CurrentState.Value;
                                    } // left message

                if (toggle.Offset == Aircraft.pmdg737.CDU_annunMSG[1])
                {
                                            rightMessageTextBox.Text = toggle.CurrentState.Value;
                } // right message

                if (toggle.Offset == Aircraft.pmdg737.CDU_annunOFST[0])
                {
                                                                leftOffsetTextBox.Text = toggle.CurrentState.Value;
                                    } // left offset.

                if (toggle.Offset == Aircraft.pmdg737.CDU_annunOFST[1])
                {
                                            rightOffsetTextBox.Text = toggle.CurrentState.Value;
                } // right offset

                if (toggle.Offset == Aircraft.pmdg737.CDU_BrtKnob[0])
                {
                                                                leftBrightnessTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                                    } // left brightness

                if (toggle.Offset == Aircraft.pmdg737.CDU_BrtKnob[1])
                {
                                            rightBrightnessTextBox.Text = toggle.Offset.GetValue<byte>().ToString();
                } // right brightness.
            } // loop

        }

        private void ctlControlStandCDU_VisibleChanged(object sender, EventArgs e)
        {
            if(Visible == true)
            {
                cduTimer.Start();
            }
            else
            {
                cduTimer.Stop();
            }
        }

        private void leftBrightnessTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.I)
            {
                                PMDG737Aircraft.CDU1BrightnessIncrease();
            }
            if(e.KeyCode == Keys.D)
            {
                PMDG737Aircraft.CDU1BrightnessDecrease();
            }
        }

        private void rightBrightnessTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.I)
            {
                PMDG737Aircraft.CDU2BrightnessIncrease();
            }
            if(e.KeyCode == Keys.D)
            {
                PMDG737Aircraft.CDU2BrightnessDecrease();
            }
        }
    }
}
