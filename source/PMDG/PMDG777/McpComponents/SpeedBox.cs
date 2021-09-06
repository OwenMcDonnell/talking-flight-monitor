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

namespace tfm.PMDG.PMDG777.McpComponents
{
    public partial class SpeedBox : Form
    {
        Timer speedTimer = new Timer();
        private bool _isAirspeedMode = true;



        
        public SpeedBox()
        {
            InitializeComponent();
                    } // End SpeedBox constructor,.

        private void SpeedTimerTick(object Sender, EventArgs eventArgs)
        {

            // Only look for changes as to not paralize a screen reader when
            // using the controls.

            // New way of getting offsets. Only get the ones required for speed.
foreach(tfm.PMDG.PanelObjects.SingleStateToggle toggle in PMDG777Aircraft.PanelControls)
            {
                if(toggle.Name == "Autobrake")
                {
                    switch (toggle.CurrentState.Key)
                    {
                        case 0:
                            autoBrakeRTORadioButton.CheckedChanged -= autoBrakeRTORadioButton_CheckedChanged;
                            autoBrakeRTORadioButton.Checked = true;
                            autoBrakeRTORadioButton.CheckedChanged += autoBrakeRTORadioButton_CheckedChanged;
                                                        break;
                        case 1:
                            autoBrakeOffRadioButton.CheckedChanged -= autoBrakeOffRadioButton_CheckedChanged;
                            autoBrakeOffRadioButton.Checked = true;
                            autoBrakeOffRadioButton.CheckedChanged += autoBrakeOffRadioButton_CheckedChanged;
                            break;
                        case 2:
                            autoBrakeDisarmRadioButton.CheckedChanged -= autoBrakeDisarmRadioButton_CheckedChanged;
                            autoBrakeDisarmRadioButton.Checked = true;
                            autoBrakeDisarmRadioButton.CheckedChanged += autoBrakeDisarmRadioButton_CheckedChanged;
                            break;
                        case 3:
                            autoBrakeMinimumRadioButton.CheckedChanged -= autoBrakeMinimumRadioButton_CheckedChanged;
                            autoBrakeMinimumRadioButton.Checked = true;
                            autoBrakeMinimumRadioButton.CheckedChanged += autoBrakeMinimumRadioButton_CheckedChanged;
                            break;
                        case 4:
                            autoBrakeMediumRadioButton.CheckedChanged -= autoBrakeMediumRadioButton_CheckedChanged;
                            autoBrakeMediumRadioButton.Checked = true;
                            autoBrakeMediumRadioButton.CheckedChanged += autoBrakeMediumRadioButton_CheckedChanged;
                            break;
                        case 5:
                            autoBrakeMaximumRadioButton.CheckedChanged -= autoBrakeMaximumRadioButton_CheckedChanged;
                           autoBrakeMaximumRadioButton.Checked = true;
                            autoBrakeMaximumRadioButton.CheckedChanged += autoBrakeMaximumRadioButton_CheckedChanged;
                            break;
                    }
                } // Autobrake
            }
                                        
            if (Aircraft.pmdg777.MCP_IASMach.Value > 10)
            {
                if(Aircraft.pmdg777.MCP_IASMach.ValueChanged)
                {
                    speedTextBox.Text = Aircraft.pmdg777.MCP_IASMach.Value.ToString();
                    modeButton.Text = "&mode [IAS]";
                    modeButton.AccessibleName = "mode [IAS]";
                                    }
            } // Airspeed mode.
            else if(Aircraft.pmdg777.MCP_IASMach.Value > 10)
            {
                if(Aircraft.pmdg777.MCP_IASMach.ValueChanged)
                {
                    speedTextBox.Text = $"{Math.Round(Aircraft.pmdg777.MCP_IASMach.Value, 2)}";
                    modeButton.Text = "&mode [mach]";
                    modeButton.AccessibleName = "mode [mach]";
                } // End value changed.
                                            } // End mach mode.
            if(Aircraft.pmdg777.MCP_ATArm_Sw_On[0].ValueChanged)
            {
                switch(Aircraft.pmdg777.MCP_ATArm_Sw_On[0].Value)
                {
                    case 0:
                        autoThrottleLButton.Text = "&left off";
                        autoThrottleLButton.AccessibleName = "left off";
                        break;
                    case 1:
                        autoThrottleLButton.Text = "&left on";
                        autoThrottleLButton.AccessibleName = "left on";
                        break;
                }
            }
            if(Aircraft.pmdg777.MCP_ATArm_Sw_On[1].ValueChanged)
            {
                switch(Aircraft.pmdg777.MCP_ATArm_Sw_On[1].Value)
                {
                    case 0:
                        autoThrottleRButton.Text = "&right off";
                        autoThrottleRButton.AccessibleName = "right off";
                        break;
                    case 1:
                        autoThrottleRButton.Text = "&right on";
                        autoThrottleRButton.AccessibleName = "right on";
                        break;
                }
            }

            if(Aircraft.pmdg777.MCP_annunAT.ValueChanged)
            {
                switch(Aircraft.pmdg777.MCP_annunAT.Value)
                {
                    case 0:
                        autoThrottleButton.Text = "&autothrottle off";
                        autoThrottleButton.AccessibleName = "Autothrottle off";
                        break;
                    case 1:
                        autoThrottleButton.Text = "&Autothrottle on";
                        autoThrottleButton.AccessibleName = "Autothrottle on";
                        break;
                }
            }
        } // End SpeedTimerTick.

        private void SpeedBox_Load(object sender, EventArgs e)
        {
            speedTimer.Tick += new EventHandler(SpeedTimerTick);
            speedTimer.Interval = 100;
            speedTimer.Start();

            var autoBrake = (tfm.PMDG.PanelObjects.SingleStateToggle)PMDG777Aircraft.PanelControls.Where(x => x.Name == "Autobrake").ToArray()[0];

            // Set initial values for the form.
            switch (autoBrake.CurrentState.Key)
            {
                case 0:
                    autoBrakeRTORadioButton.Checked = true;
                    break;
                case 1:
                    autoBrakeOffRadioButton.Checked = true;
                    break;
                case 2:
                    autoBrakeDisarmRadioButton.Checked = true;
                    break;
                case 3:
                    autoBrakeMinimumRadioButton.Checked = true;
                    break;
                case 4:
                    autoBrakeMediumRadioButton.Checked = true;
                    break;
                case 5:
                    autoBrakeMaximumRadioButton.Checked = true;
                    break;
            } // Autobrake.
                        if(Aircraft.pmdg777.MCP_IASMach.Value > 10)
            {
                speedTextBox.Text = Aircraft.pmdg777.MCP_IASMach.Value.ToString();
            } // End airspeed mode.
            else if(Aircraft.pmdg777.MCP_IASMach.Value < 10)
            {
                speedTextBox.Text = $"{Math.Round(Aircraft.pmdg777.MCP_IASMach.Value, 2)}";
            } // End mach mode.

            if(Aircraft.pmdg777.MCP_ATArm_Sw_On[0].Value == 0)
            {
                autoThrottleLButton.Text = "&left off";
                autoThrottleLButton.AccessibleName = "left off";
            }
            else
            {
                autoThrottleLButton.Text = "&left on";
                autoThrottleLButton.AccessibleName = "left on";
            } // End left autothrottle.

            if(Aircraft.pmdg777.MCP_ATArm_Sw_On[1].Value == 0)
            {
                autoThrottleRButton.Text = "&right off";
                autoThrottleRButton.AccessibleName = "right off";
            }
            else
            {
                autoThrottleRButton.Text = "&right on";
                autoThrottleRButton.AccessibleName = "right on";
            } // End right autothrottle.

            if(this._isAirspeedMode)
            {
                modeButton.Text = "&mode [IAS]";
                modeButton.AccessibleName = "mode [IAS]";
            }
            else
            {
                modeButton.Text = "&mode [mach]";
                modeButton.AccessibleName = "mode [mach]";
            }

            if(Aircraft.pmdg777.MCP_annunAT.Value == 0)
            {
                autoThrottleButton.Text = "&Autothrottle off";
                autoThrottleButton.AccessibleName = "Autothrottle off";
            }
            else
            {
                autoThrottleButton.Text = "&Autothrottle on";
                autoThrottleButton.AccessibleName = "Autothrottle on";
            } // End autothrottle.
        } // End SpeedBox_Load.

        private void modeButton_Click(object sender, EventArgs e)
        {
                                        FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_MCP_IAS_MACH_SWITCH, Aircraft.ClkL);
                        } // End modeButton click.

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
            FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_MCP_SPEED_PUSH_SWITCH, Aircraft.ClkL);
        }

        private void autoThrottleLButton_Click(object sender, EventArgs e)
        {
            if(Aircraft.pmdg777.MCP_ATArm_Sw_On[0].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_MCP_AT_ARM_SWITCH_L, Aircraft.ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_MCP_AT_ARM_SWITCH_L, Aircraft.ClkR);
            }
        }

        private void autoThrottleRButton_Click(object sender, EventArgs e)
        {
            if(Aircraft.pmdg777.MCP_ATArm_Sw_On[1].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_MCP_AT_ARM_SWITCH_R, Aircraft.ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_MCP_AT_ARM_SWITCH_R, Aircraft.ClkR);
            }
        }

        private void autoThrottleButton_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_MCP_AT_SWITCH, Aircraft.ClkL);
            if (Aircraft.pmdg777.MCP_annunAT.Value == 0)
            {
                autoThrottleButton.Text = "&Autothrottle on";
                autoThrottleButton.AccessibleName = "Autothrottle on";
            }
            else
            {
                                autoThrottleButton.Text = "&Autothrottle off";
                autoThrottleButton.AccessibleName = "Autothrottle off";
            }
        }

        private void speedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
                        if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (Aircraft.pmdg777.MCP_IASMach.Value < 10)
                {
                    float.TryParse(speedTextBox.Text, out float mach);
                    FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_MCP_MACH_SET, PMDG777Aircraft.CalculateMachParameter(mach));
                } // End mach.
                else if(Aircraft.pmdg777.MCP_IASMach.Value > 10)
                {
                    int.TryParse(speedTextBox.Text, out int speed);
                    FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_MCP_IAS_SET, speed);
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
                    } // End SpeedBox key down event.

        private void autoBrakeRTORadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (autoBrakeRTORadioButton.Checked)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_ABS_AUTOBRAKE_SELECTOR, 0);
            }
        }// autoBrakeRTORadioButton_CheckedChanged.

        private void autoBrakeOffRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (autoBrakeOffRadioButton.Checked)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_ABS_AUTOBRAKE_SELECTOR, 1);
            }
        } // autoBrakeOffRadioButton_CheckChanged

        private void autoBrakeDisarmRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (autoBrakeDisarmRadioButton.Checked)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_ABS_AUTOBRAKE_SELECTOR, 2);
            }
        } // autoBrakeDisarmRadioButton_CheckedChanged.

        private void autoBrakeMinimumRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (autoBrakeMinimumRadioButton.Checked)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_ABS_AUTOBRAKE_SELECTOR, 3);
            }
        } // autoBrakeMinimumRadioButton_CheckedChanged

        private void autoBrakeMediumRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (autoBrakeMediumRadioButton.Checked)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_ABS_AUTOBRAKE_SELECTOR, 4);
            }
        } // autoBrakeMediumRadioButton_CheckedChanged.

        private void autoBrakeMaximumRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (autoBrakeMaximumRadioButton.Checked)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_ABS_AUTOBRAKE_SELECTOR, 5);
            }
        } // autoBrakeMaximumRadioButton_CheckedChanged
    } // End SpeedBox form.
} // End namespace.
