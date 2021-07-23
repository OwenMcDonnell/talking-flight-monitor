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
            speedTimer.Interval = 200;
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
                        speedTextBox.Text = string.Empty;
                        speedButton.Text = "&Intervene off";
                        speedButton.AccessibleName = "Intervene off";
                        break;
                    case 0:
                                                                            if (Aircraft.pmdg737.MCP_IASMach.Value > 10)
                            {
                                speedTextBox.Text = Aircraft.pmdg737.MCP_IASMach.Value.ToString();
                                speedButton.Text = "&Intervene on";
                                speedButton.AccessibleName = "Intervene on";
                            }
                             if (Aircraft.pmdg737.MCP_IASMach.Value < 10)
                            {
                                double machSpeed = Aircraft.pmdg737.MCP_IASMach.Value % 1;
                                machSpeed = Math.Round(machSpeed, 2);

                                speedTextBox.Text = machSpeed.ToString();
                                speedButton.Text = "&Intervene on";
                                speedButton.AccessibleName = "Intervene on";
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
                                       if(Aircraft.pmdg737.MCP_IASBlank.Value == 1)
            {
                speedTextBox.Text = string.Empty;
                speedButton.Text = "&Intervene off";
                speedButton.AccessibleName = "Interveen off";
            }
            else
            {
                if (Aircraft.pmdg737.MCP_IASMach.Value < 10)
                {
                    double machSpeed = Math.Round((Aircraft.pmdg737.MCP_IASMach.Value % 1), 2);
                    speedTextBox.Text = machSpeed.ToString();
                    speedButton.Text = "&Intervene on";
                    speedButton.AccessibleName = "Intervene on";

                }
                else if (Aircraft.pmdg737.MCP_IASMach.Value > 10)
                {
                    speedTextBox.Text = Aircraft.pmdg737.MCP_IASMach.Value.ToString();
                    speedButton.Text = "&Intervene on";
                    speedButton.AccessibleName = "Intervene on";

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
                if (Aircraft.pmdg737.MCP_IASMach.Value < 10)
                {
                    float.TryParse(speedTextBox.Text, out float mach);
                    var machParameter = (int)(mach / .01);
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_MACH_SET, machParameter);
                } // End mach.
                if(Aircraft.pmdg737.MCP_IASMach.Value > 10)
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
    } // End SpeedBox form.
} // End namespace.
