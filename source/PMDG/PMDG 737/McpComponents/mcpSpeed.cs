using tfm.PMDG.PanelObjects;
using tfm.PMDG.PMDG737;
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
using static System.ComponentModel.Design.ObjectSelectorEditor;


namespace tfm.PMDG.PMDG737.McpComponents
{
    public partial class mcpSpeed : Form
    {
private        System.Timers.Timer speedTimer = new System.Timers.Timer();
        private double OldSpeedBrake = 0;

                public mcpSpeed()
        {
            InitializeComponent();
        }

        private void SpeedTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {
            foreach(PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.MCP_IASBlank)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        if(toggle.CurrentState.Value == "off")
                        {
                            speedTextBox.ReadOnly = true;
                            speedTextBox.Text = String.Empty;
                        }
                        else
                        {
                            speedTextBox.ReadOnly = false;
                        }
                        interveneButton.Text = $"&Intervene {toggle.CurrentState.Value}";
                        interveneButton.AccessibleName = $"Intervene {toggle.CurrentState.Value}";
                                                }
                }
            
            if(toggle.Offset == Aircraft.pmdg737.MCP_IASOverspeedFlash)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        overspeedTextBox.Text = toggle.CurrentState.Value;
                    }
                }
            

            if(toggle.Offset == Aircraft.pmdg737.MCP_IASUnderspeedFlash)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        underspeedTextBox.Text = toggle.CurrentState.Value;
                    }
                }

            if(toggle.Offset == Aircraft.pmdg737.MCP_ATArmSw)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        autoThrottleButton.Text = $"A&utothrottle {toggle.CurrentState.Value}";
                        autoThrottleButton.AccessibleName = $"Autothrottle {toggle.CurrentState.Value}";
                            }
                }

            if(toggle.Offset == Aircraft.pmdg737.MCP_annunATArm)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        autoThrottleTextBox.Text = toggle.CurrentState.Value;
                    }
                }

            if(toggle.Offset == Aircraft.pmdg737.MCP_annunN1)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        n1TextBox.Text = toggle.CurrentState.Value;
                        n1SwitchButton.Text = $"&N1 {toggle.CurrentState.Value}";
                        n1SwitchButton.AccessibleName = $"N1 {toggle.CurrentState.Value}";
                    }
                }

                        if(toggle.Offset == Aircraft.pmdg737.MCP_annunSPEED)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                                                speedLightTextBox.Text = toggle.CurrentState.Value;
                        speedButton.Text = $"&Speed {toggle.CurrentState.Value}";
                        speedButton.AccessibleName = $"Speed {toggle.CurrentState.Value}";
                    }
                }


                if (toggle.Offset == Aircraft.pmdg737.MAIN_AutobrakeSelector)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        autoBrakeTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunSPEEDBRAKE_ARMED)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        speedBrakeArmedTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunSPEEDBRAKE_EXTENDED)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        speedBrakeExtendedTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunSPEEDBRAKE_DO_NOT_ARM)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        speedBrakeDNArmTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunAUTO_BRAKE_DISARM)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        autoBrakeDisarmTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.MAIN_N1SetSelector)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        n1Button.Text = $"N1 se&lector {toggle.CurrentState.Value}";
                        n1Button.AccessibleName = $"N1 selector {toggle.CurrentState.Value}";

                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.FCTL_Spoiler_Sw[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        spoilerAButton.Text = $"Spoiler &A {toggle.CurrentState.Value}";
                        spoilerAButton.AccessibleName = $"Spoiler A {toggle.CurrentState.Value}";
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.FCTL_Spoiler_Sw[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        spoilerBButton.Text = $"Spoiler &B {toggle.CurrentState.Value}";
                        spoilerBButton.AccessibleName = $"Spoiler B {toggle.CurrentState.Value}";

                    }
                }
            } // controls loop.
            if (PMDG737Aircraft.SpeedType == AircraftSpeed.Indicated)
            {
                coButton.Text = "&C/O (IAS)";
                coButton.AccessibleName = "C/O - indicated";
                speedTextBox.AccessibleName = "Indicated airspeed";
                if (Aircraft.pmdg737.MCP_IASMach.ValueChanged)
                {
                    speedTextBox.Text = $"{PMDG737Aircraft.IndicatedAirSpeed}";
                }
            }
            else
            {
                coButton.Text = "&C/O (Mach)";
                coButton.AccessibleName = "C/O - Mach";
                speedTextBox.AccessibleName = "Mach speed";
                if (Aircraft.pmdg737.MCP_IASMach.ValueChanged)
                {
                    speedTextBox.Text = $"{PMDG737Aircraft.MachSpeed}";
                }

            }

            // Speedbrake
            if(PMDG737Aircraft.CurrentSpeedBrakePosition != OldSpeedBrake)
            {
                switch (PMDG737Aircraft.CurrentSpeedBrakePosition)
                {
                    case 100:
                        speedBrakeTextBox.Text = "Armed";
                        break;
                    case 272:
                        speedBrakeTextBox.Text = "Flt";
                        break;
                    case 400:
                        speedBrakeTextBox.Text = "Up";
                        break;
                    case 250:
                        speedBrakeTextBox.Text = "Half";
                        break;
                    case 0:
                        speedBrakeTextBox.Text = "Off";
                                                break;
                    default:
                        speedBrakeTextBox.Text = PMDG737Aircraft.CurrentSpeedBrakePosition.ToString();
                        break;
                                                      }
                OldSpeedBrake = PMDG737Aircraft.CurrentSpeedBrakePosition;
            } // speedbrake
        } // SpeedTimerTick

        private void mcpSpeed_Load(object sender, EventArgs e)
        {

            speedTimer.Elapsed += SpeedTimerTick;
            speedTimer.Start();
                        foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.MCP_IASBlank)
                {
                    if (toggle.CurrentState.Value == "off")
                    {
                        speedTextBox.ReadOnly = true;
                        speedTextBox.Text = String.Empty;
                    }
                    else
                    {
                        speedTextBox.ReadOnly = false;
                    }
                    interveneButton.Text = $"&Intervene {toggle.CurrentState.Value}";
                    interveneButton.AccessibleName = $"Intervene {toggle.CurrentState.Value}";
                }

                if (toggle.Offset == Aircraft.pmdg737.MCP_IASOverspeedFlash)
                {
                    overspeedTextBox.DataBindings.Add("Text", toggle.CurrentState, "Value");
                }

                if (toggle.Offset == Aircraft.pmdg737.MCP_IASUnderspeedFlash)
                {
                    underspeedTextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.MCP_ATArmSw)
                {
                    autoThrottleButton.Text = $"A&utothrottle {toggle.CurrentState.Value}";
                    autoThrottleButton.AccessibleName = $"Autothrottle {toggle.CurrentState.Value}";
                }

                if (toggle.Offset == Aircraft.pmdg737.MCP_annunATArm)
                {
                    autoThrottleTextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.MCP_annunN1)
                {
                    n1TextBox.Text = toggle.CurrentState.Value;
                    n1SwitchButton.Text = $"&N1 {toggle.CurrentState.Value}";
                    n1SwitchButton.AccessibleName = $"N1 {toggle.CurrentState.Value}";
                }

                if (toggle.Offset == Aircraft.pmdg737.MCP_annunSPEED)
                {
                    speedLightTextBox.Text = toggle.CurrentState.Value;
                    speedButton.Text = $"&Speed {toggle.CurrentState.Value}";
                    speedButton.AccessibleName = $"Speed {toggle.CurrentState.Value}";
                }

                if(toggle.Offset == Aircraft.pmdg737.FCTL_Spoiler_Sw[0])
                {
                    spoilerAButton.Text = $"Spoiler &A {toggle.CurrentState.Value}";
                    spoilerAButton.AccessibleName = $"Spoiler A {toggle.CurrentState.Value}";

                }
                
                if(toggle.Offset == Aircraft.pmdg737.FCTL_Spoiler_Sw[1])
                {
                                                    spoilerBButton.Text = $"Spoiler &B {toggle.CurrentState.Value}";
                spoilerBButton.AccessibleName = $"Spoiler B {toggle.CurrentState.Value}";
            }

                if(toggle.Offset == Aircraft.pmdg737.MAIN_AutobrakeSelector)
                {
                    autoBrakeTextBox.Text = toggle.CurrentState.Value;
                }

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunSPEEDBRAKE_ARMED)
                {
                    speedBrakeArmedTextBox.Text = toggle.CurrentState.Value;
                }

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunSPEEDBRAKE_EXTENDED)
                {
                    speedBrakeExtendedTextBox.Text = toggle.CurrentState.Value;
                }

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunSPEEDBRAKE_DO_NOT_ARM)
                {
                    speedBrakeDNArmTextBox.Text = toggle.CurrentState.Value;
                }

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunAUTO_BRAKE_DISARM)
                {
                    autoBrakeDisarmTextBox.Text = toggle.CurrentState.Value;
                }

                if(toggle.Offset == Aircraft.pmdg737.MAIN_N1SetSelector)
                {
                    n1Button.Text = $"N1 se&lector {toggle.CurrentState.Value}";
                    n1Button.AccessibleName = $"N1 selector {toggle.CurrentState.Value}";
                }
        } // controls loop.

                                                                                            if (PMDG737Aircraft.SpeedType == AircraftSpeed.Indicated)
            {
                coButton.Text = "&C/O (IAS)";
                coButton.AccessibleName = "C/O - indicated";
                speedTextBox.AccessibleName = "Indicated airspeed";
                speedTextBox.Text = $"{PMDG737Aircraft.IndicatedAirSpeed}";
            }
            else
            {
                coButton.Text = "&C/O (Mach)";
                coButton.AccessibleName = "C/O - Mach";
                speedTextBox.AccessibleName = "Mach speed";
                speedTextBox.Text = $"{PMDG737Aircraft.MachSpeed}";
            }

            // speedbrake
            switch (PMDG737Aircraft.CurrentSpeedBrakePosition)
            {
                case 100:
                    speedBrakeTextBox.Text = "Armed";
                    break;
                case 272:
                    speedBrakeTextBox.Text = "Flt";
                    break;
                case 400:
                    speedBrakeTextBox.Text = "Up";
                    break;
                case 250:
                    speedBrakeTextBox.Text = "Half";
                    break;
                case 0:
                    speedBrakeTextBox.Text = "Off";
                    break;
                default:
                    speedBrakeTextBox.Text = PMDG737Aircraft.CurrentSpeedBrakePosition.ToString();
                    break;
            }            // speedbrake

        }

        private void coButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.ChangeOver();

        }

                private void interveneButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.SpeedIntervene();
       }

        private void autoThrottleButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.AutoThrottle();
        }

        private void n1Button_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.N1SetSelector();
        }

        private void n1SwitchButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.N1();
        }

        private void speedButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.SpeedHold();
        }

        private void spoilerAButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.SpoilerAToggle();
        }

        private void spoilerBButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.SpoilerBToggle();
        }

        private void speedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
                        if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;    
                PMDG737Aircraft.SetSpeed(speedTextBox.Text);
                            }
            
        }

        private void autoBrakeTextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.O)
            {
                PMDG737Aircraft.AutoBrake(1);
            }
                        if(e.KeyCode == Keys.R)
            {
                PMDG737Aircraft.AutoBrake(0);
            }
                        if(e.KeyCode == Keys.D)
            {
                PMDG737Aircraft.AutoBrake(2);
            }
                        if(e.KeyCode == Keys.D1)
            {
                PMDG737Aircraft.AutoBrake(3);
            }
                        if(e.KeyCode == Keys.D2)
            {
                PMDG737Aircraft.AutoBrake(4);
            }
                        if(e.KeyCode == Keys.D3)
            {
                PMDG737Aircraft.AutoBrake(5);
            }
                    }

        private void autoBrakeTextBox_Enter(object sender, EventArgs e)
        {
            autoBrakeTextBox.Select(autoBrakeTextBox.Text.Length, 0);
        }

        private void speedBrakeTextBox_Enter(object sender, EventArgs e)
        {
            speedBrakeTextBox.Select(speedBrakeTextBox.Text.Length, 0);
        }

        private void speedBrakeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            if(e.KeyCode == Keys.Oemplus)
            {
                PMDG737Aircraft.SpeedBrakeIncrease();
            }
            if(e.KeyCode == Keys.OemMinus)
            {
                PMDG737Aircraft.SpeedBrakeDecrease();
            }

            if(e.KeyCode == Keys.A)
            {
                PMDG737Aircraft.SpeedBrakeArm();
            }
            if(e.KeyCode == Keys.F)
            {
                PMDG737Aircraft.SpeedBrakeFlight();
            }
            if(e.KeyCode == Keys.U)
            {
                PMDG737Aircraft.SpeedBrakeFull();
            }
            if(e.KeyCode == Keys.H)
            {
                PMDG737Aircraft.SpeedBrakeHalf();
            }
            if(e.KeyCode == Keys.O)
            {
                PMDG737Aircraft.SpeedBrakeOff();
            }
        }

        private void mcpSpeed_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                Hide();
            }
        }

        private void mcpSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                Hide();
            }
            if((e.Alt && e.KeyCode == Keys.F4))
            {
                Hide();
            }
        }
    }
}
