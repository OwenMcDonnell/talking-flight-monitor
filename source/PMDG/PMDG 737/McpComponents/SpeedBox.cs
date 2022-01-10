using tfm.PMDG.PMDG777;
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

namespace tfm.PMDG.PMDG737.McpComponents
{
    public partial class SpeedBox : Form
    {
        System.Windows.Forms.Timer speedTimer = new System.Windows.Forms.Timer();
                
        public SpeedBox()
        {
            InitializeComponent();

            // Timer for tracking MCP switches and values.
                                    speedTimer.Tick += new EventHandler(SpeedTimerTick);
            speedTimer.Start();
        } // End SpeedBox constructor,.

        private void SpeedTimerTick(object Sender, EventArgs eventArgs)
        {

            // Only look for changes as to not paralize a screen reader when
            // using the controls.

            if(Aircraft.pmdg737.MCP_IASBlank.ValueChanged)
            {
                switch (Aircraft.pmdg737.MCP_IASBlank.Value)
                {
                                                        case 1:
                        speedTextBox.Text = "[FMC speed]";
                        speedButton.Text = "&Speed [FMC]";
                        speedButton.AccessibleName = "Speed [FMC]";
                        break;
                    case 0:
                                                                            if (PMDG737Aircraft.SpeedType == AircraftSpeed.Mach)
                            {
                                speedTextBox.Text = PMDG737Aircraft.MachSpeed.ToString();
                                speedButton.Text = "&Speed [MCP]";
                                speedButton.AccessibleName = "Speed [MCP]";
                            }
                             else if(PMDG737Aircraft.SpeedType == AircraftSpeed.Indicated)
                            {
                            speedTextBox.Text = PMDG737Aircraft.IndicatedAirSpeed.ToString();
                                speedButton.Text = "&Speed [MCP]";
                                speedButton.AccessibleName = "Speed [MCP]";
                            }

                                                                            break;                        
                }
            }

                                    if (Aircraft.pmdg737.MCP_ATArmSw.ValueChanged)
            {
                switch(Aircraft.pmdg737.MCP_ATArmSw.Value)
                {
                    case 0:
                        autoThrottleLButton.Text = "&Autothrottle off";
                        autoThrottleLButton.AccessibleName = "Autothrottle off";
                        break;
                    case 1:
                        autoThrottleLButton.Text = "&Autothrottle on";
                        autoThrottleLButton.AccessibleName = "Autothrottle on";
                        break;
                }
            }
                    } // End SpeedTimerTick.

        private void SpeedBox_Load(object sender, EventArgs e)
        {

            // Set initial values for the form.
                                       if(PMDG737Aircraft.SpeedMode == AircraftSystem.FMC)
            {
                speedTextBox.Text = "[FMC speed]";
                speedButton.Text = "Speed [FMC]";
                speedButton.AccessibleName = "Speed [FMC]";
            }
            else
            {
                if (PMDG737Aircraft.SpeedType == AircraftSpeed.Mach)
                {
                    speedTextBox.Text = PMDG737Aircraft.MachSpeed.ToString();
                    speedButton.Text = "&Speed [MCP]";
                    speedButton.AccessibleName = "Speed [MCP]";

                }
                else if (PMDG737Aircraft.SpeedType == AircraftSpeed.Indicated)
                {
                    speedTextBox.Text = PMDG737Aircraft.IndicatedAirSpeed.ToString();
                    speedButton.Text = "&Speed [MCP]";
                    speedButton.AccessibleName = "Speed [MCP]";
                                    }
            }
                        
            if(Aircraft.pmdg737.MCP_ATArmSw.Value == 0)
            {
                autoThrottleLButton.Text = "&Autothrottle off";
                autoThrottleLButton.AccessibleName = "Autothrottle off";
            }
            else
            {
                autoThrottleLButton.Text = "&Autothrottle on";
                autoThrottleLButton.AccessibleName = "Autothrottle on";
            } // End left autothrottle.
        } // End SpeedBox_Load.

                private void SpeedBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
                    } // End closing event.

        private void speedButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.SpeedIntervene();
            if(PMDG737Aircraft.SpeedMode == AircraftSystem.FMC)
            {
                speedTextBox.Text = "[FMC speed]";
            }
                   }

        private void autoThrottleLButton_Click(object sender, EventArgs e)
        {
            pmdg pmdg = new pmdg();
            if (Aircraft.pmdg737.MCP_ATArmSw.Value == 0)
            {
                
                pmdg.mcpAutoThrottleArmOn();
            }
            else
            {
                pmdg.mcpAutoThrottleArmOff();
            }
        }

                        private void speedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
                        if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (PMDG737Aircraft.SpeedType == AircraftSpeed.Mach)
                {
                    float.TryParse(speedTextBox.Text, out float mach);
                    var machParameter = (int)(mach / .01);
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_MACH_SET, machParameter);
                } // End mach.
                if(PMDG737Aircraft.SpeedType == AircraftSpeed.Indicated)
                {
                    short.TryParse(speedTextBox.Text, out short speed);
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_IAS_SET, speed);
                } // End airspeed.
            } // End key check.
        } // End key down event.

        private void SpeedBox_KeyDown(object sender, KeyEventArgs e)
        {
            if((e.Alt) && (e.KeyCode == Keys.E))
            {
                e.SuppressKeyPress = true;
                speedTextBox.Focus();
            }
            if(e.KeyCode == Keys.Escape)
            {
                Hide();
            }
        } // End SpeedBox key down event.

        private void SpeedBox_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                speedTextBox.SelectAll();
            }
            else
            {
                speedTextBox.DeselectAll();
            }
        }
    } // End SpeedBox form.
} // End namespace.
