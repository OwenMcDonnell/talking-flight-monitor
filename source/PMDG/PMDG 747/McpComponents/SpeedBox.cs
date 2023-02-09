using tfm.PMDG.PanelObjects;
using DavyKager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.PMDG.PMDG_747.McpComponents
{
    public partial class SpeedBox : Form
    {

        private System.Timers.Timer speedTimer = new System.Timers.Timer();
        private byte oldSpeedBrake = 0;


        public SpeedBox()
        {
            InitializeComponent();
        }

        private void SpeedTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach(PanelObject control in PMDG747Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg747.MCP_IASBlank)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        if(toggle.CurrentState.Value == "off")
                        {
                            speedTextBox.ReadOnly = true;
                            }
                            else
                            {
                            speedTextBox.ReadOnly = false;
                            }
                                                                                                                               interveneButton.Text = $"&Intervene {toggle.CurrentState.Value}";
                        interveneButton.AccessibleName = $"Intervene {toggle.CurrentState.Value}";
                                                                    }
                } // intervene

                if(toggle.Offset == Aircraft.pmdg747.MCP_ATArm_Sw_On)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        autoThrottleButton.Text = $"A&uto throttle {toggle.CurrentState.Value}";
                        autoThrottleButton.AccessibleName = $"Auto throttle {toggle.CurrentState.Value}";
                    }
                } // auto throttle

                if(toggle.Offset == Aircraft.pmdg747.MCP_annunTHR)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        thrustButton.Text = $"&Thrust {toggle.CurrentState.Value}";
                        thrustButton.AccessibleName = $"Thrust {toggle.CurrentState.Value}";
                    }
                } // thrust

                if(toggle.Offset == Aircraft.pmdg747.MCP_annunSPD)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        holdButton.Text = $"&Hold {toggle.CurrentState.Value}";
                        holdButton.AccessibleName = $"Hold {toggle.CurrentState.Value}";
                    }
                } // hold

                if(toggle.Offset == Aircraft.pmdg747.BRAKES_AutobrakeSelector)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        autoBrakeTextBox.Text = toggle.CurrentState.Value;
                    }
                } // auto brake
                            } // loop.

            if(PMDG747Aircraft.SpeedType == AircraftSpeed.Indicated)
            {
                changeOverButton.Text = "&C/O (IAS)";
                changeOverButton.AccessibleName = "C/O - indicated";
                speedTextBox.AccessibleName = "Indicated air speed";
                if (Aircraft.pmdg747.MCP_IASMach.ValueChanged)
                {
                    speedTextBox.Text = PMDG747Aircraft.IndicatedAirSpeed.ToString();
                }
            }
            else
            {
                changeOverButton.Text = "&C/O (Mach)";
                changeOverButton.AccessibleName = "C/O - Mach";
                speedTextBox.AccessibleName = "Mach speed";
                if (Aircraft.pmdg747.MCP_IASMach.ValueChanged)
                {
                    speedTextBox.Text = PMDG747Aircraft.MachSpeed.ToString();
                }
            }

            LoadSpeedBrake();
                               }

        private void SpeedBox_Load(object sender, EventArgs e)
        {
            Tolk.Load();

            speedTimer.Elapsed += new System.Timers.ElapsedEventHandler(SpeedTimerTick);
            speedTimer.Start();

            foreach (PanelObject control in PMDG747Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg747.MCP_IASBlank)
                {
            if (toggle.CurrentState.Value == "off")
            {
                speedTextBox.ReadOnly = true;
            }
            else
            {
                speedTextBox.ReadOnly = false;
            }
                                                                                                                               interveneButton.Text = $"&Intervene {toggle.CurrentState.Value}";
                        interveneButton.AccessibleName = $"Intervene {toggle.CurrentState.Value}";
                                    } // intervene

                if (toggle.Offset == Aircraft.pmdg747.MCP_ATArm_Sw_On)
                {
                                            autoThrottleButton.Text = $"A&uto throttle {toggle.CurrentState.Value}";
                        autoThrottleButton.AccessibleName = $"Auto throttle {toggle.CurrentState.Value}";
                } // auto throttle

                if (toggle.Offset == Aircraft.pmdg747.MCP_annunTHR)
                {
                                                                thrustButton.Text = $"&Thrust {toggle.CurrentState.Value}";
                        thrustButton.AccessibleName = $"Thrust {toggle.CurrentState.Value}";
                                    } // thrust

                if (toggle.Offset == Aircraft.pmdg747.MCP_annunSPD)
                {
                                            holdButton.Text = $"&Hold {toggle.CurrentState.Value}";
                        holdButton.AccessibleName = $"Hold {toggle.CurrentState.Value}";
                } // hold

                if (toggle.Offset == Aircraft.pmdg747.BRAKES_AutobrakeSelector)
                {
                                                                autoBrakeTextBox.Text = toggle.CurrentState.Value;
                                    } // auto brake
            } // loop.

            if (PMDG747Aircraft.SpeedType == AircraftSpeed.Indicated)
            {
                changeOverButton.Text = "&C/O (IAS)";
                changeOverButton.AccessibleName = "C/O - indicated";
                speedTextBox.AccessibleName = "Indicated air speed";
                                                    speedTextBox.Text = PMDG747Aircraft.IndicatedAirSpeed.ToString();
                            }
            else
            {
                changeOverButton.Text = "&C/O (Mach)";
                changeOverButton.AccessibleName = "C/O - Mach";
                speedTextBox.AccessibleName = "Mach speed";
                                    speedTextBox.Text = PMDG747Aircraft.MachSpeed.ToString();
            }

            LoadSpeedBrake();
                   }

        private void LoadSpeedBrake()
        {
            if (PMDG747Aircraft.CurrentSpeedBrakePosition != oldSpeedBrake)
            {
                switch (PMDG747Aircraft.CurrentSpeedBrakePosition)
                {
                    case 0:
                        speedBrakeTextBox.Text = "down";
                        break;
                    case 25:
                        speedBrakeTextBox.Text = "armed";
                        break;
                    case 62:
                        speedBrakeTextBox.Text = "flt";
                        break;
                    case 100:
                        speedBrakeTextBox.Text = "up";
                        break;
                    default:
                        speedBrakeTextBox.Text = PMDG747Aircraft.CurrentSpeedBrakePosition.ToString();
                        break;
                }
                oldSpeedBrake = PMDG747Aircraft.CurrentSpeedBrakePosition;
            }
            else
            {
                                                    switch (PMDG747Aircraft.CurrentSpeedBrakePosition)
                    {
                        case 0:
                            speedBrakeTextBox.Text = "down";
                            break;
                    case 25:
                        speedBrakeTextBox.Text = "armed";
                        break;
                    case 62:
                        speedBrakeTextBox.Text = "flt";
                        break;
                    case 100:
                            speedBrakeTextBox.Text = "up";
                            break;
                        default:
                            speedBrakeTextBox.Text = PMDG747Aircraft.CurrentSpeedBrakePosition.ToString();
                            break;
                    }
                    oldSpeedBrake = PMDG747Aircraft.CurrentSpeedBrakePosition;
                            }

        } // LoadSpeedBrake

        private void SpeedBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                                Hide();
            }
        }

        private void SpeedBox_KeyDown(object sender, KeyEventArgs e)
        {
            if((e.Alt && e.KeyCode == Keys.F4) || e.KeyCode == Keys.Escape)
            {
                                e.SuppressKeyPress = true;
                                Hide();
            }
        }

        private void speedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                PMDG747Aircraft.SetSpeed(speedTextBox.Text);
            }
        }

        private void interveneButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.SpeedIntervene();
        }

        private void changeOverButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.ChangeOver();   
        }

        private void autoThrottleButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.AutoThrottleToggle();
        }

        private void thrustButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.ClimbThrust();
        }

        private void holdButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.SpeedHoldToggle();
        }

        private void speedBrakeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.U)
            {
                e.SuppressKeyPress = true;
                PMDG747Aircraft.SpeedBrakeUp();
            }

            if(e.KeyCode == Keys.D)
            {
                e.SuppressKeyPress = true;
                PMDG747Aircraft.SpeedBrakeDown();
            }

            if(e.KeyCode == Keys.A)
            {
                e.SuppressKeyPress = true;
                PMDG747Aircraft.SpeedBrakeArm();
            }

            if(e.KeyCode == Keys.F)
            {
                e.SuppressKeyPress = true;
                PMDG747Aircraft.SpeedBrakeFlt();
            }

            if(e.KeyCode == Keys.Oemplus)
            {
                e.SuppressKeyPress = true;
                PMDG747Aircraft.SpeedBrakeIncrease();
            }

            if(e.KeyCode == Keys.OemMinus)
            {
                e.SuppressKeyPress = true;
                PMDG747Aircraft.SpeedBrakeDecrease();
            }


        }

        private void autoBrakeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.O)
            {
                e.SuppressKeyPress = true;
                PMDG747Aircraft.AutoBrakeOff();
            }

            if(e.KeyCode == Keys.R)
            {
                e.SuppressKeyPress = true;
                PMDG747Aircraft.AutoBrakeRTO();
            }

            if(e.KeyCode == Keys.D)
            {
                e.SuppressKeyPress = true;
                PMDG747Aircraft.AutoBrakeDisarm();
            }

            if(e.KeyCode == Keys.D1)
            {
                e.SuppressKeyPress = true;
                PMDG747Aircraft.AutoBrake1();
            }

            if(e.KeyCode == Keys.D2)
            {
                e.SuppressKeyPress = true;
                PMDG747Aircraft.AutoBrake2();
            }

            if(e.KeyCode == Keys.D3)
            {
                e.SuppressKeyPress = true;
                PMDG747Aircraft.AutoBrakeAuto();
            }
        }
    }
}
