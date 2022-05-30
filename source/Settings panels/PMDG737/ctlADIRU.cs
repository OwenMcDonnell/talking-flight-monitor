using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.Settings_panels.PMDG737
{
    public partial class ctlADIRU : UserControl, iSettingsPage
    {
        public ctlADIRU()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlADIRU_Load(object sender, EventArgs e)
        {
            displaySelectorCheckBox.Checked = Properties.pmdg737_offsets.Default.IRS_DisplaySelector;
            displaySwitchCheckBox.Checked = Properties.pmdg737_offsets.Default.IRS_SysDisplay_r;
            leftModeSelectorCheckBox.Checked = Properties.pmdg737_offsets.Default.IRS_ModeSelector_L;
            rightModeSelectorCheckBox.Checked = Properties.pmdg737_offsets.Default.IRS_ModeSelector_R;
            gpsLightCheckBox.Checked = Properties.pmdg737_offsets.Default.IRS_annunGPS;
            leftLightCheckBox.Checked = Properties.pmdg737_offsets.Default.IRS_annunALIGN_L;
            rightLightCheckBox.Checked = Properties.pmdg737_offsets.Default.IRS_annunALIGN_R;
            leftDCLightCheckBox.Checked = Properties.pmdg737_offsets.Default.IRS_annunON_DC_L;
            rightDcLightCheckBox.Checked = Properties.pmdg737_offsets.Default.IRS_annunON_DC_R;
            leftFaultLightCheckBox.Checked = Properties.pmdg737_offsets.Default.IRS_annunFAULT_L;
            rightFaultLightCheckBox.Checked = Properties.pmdg737_offsets.Default.IRS_annunFAULT_R;
            leftDcFailureLightCheckBox.Checked = Properties.pmdg737_offsets.Default.IRS_annunDC_FAIL_L;
            rightDcFailureLightCheckBox.Checked = Properties.pmdg737_offsets.Default.IRS_annunDC_FAIL_R;

        }

        private void displaySelectorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (displaySelectorCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.IRS_DisplaySelector = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.IRS_DisplaySelector = false;
            }
        }

        private void displaySwitchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (displaySwitchCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.IRS_SysDisplay_r = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.IRS_SysDisplay_r = false;
            }
        }

        private void leftModeSelectorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leftModeSelectorCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.IRS_ModeSelector_L = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.IRS_ModeSelector_L = false;
            }
        }

        private void rightModeSelectorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightModeSelectorCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.IRS_ModeSelector_R = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.IRS_ModeSelector_R = false;
            }
        }

        private void gpsLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (gpsLightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.IRS_annunGPS = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.IRS_annunGPS = false;
            }
                        }
private void leftLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leftLightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.IRS_annunALIGN_L = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.IRS_annunALIGN_L = false;
            }
        }

        private void rightLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightLightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.IRS_annunALIGN_R = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.IRS_annunALIGN_R = false;
            }
        }

        private void leftDCLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leftDCLightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.IRS_annunON_DC_L = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.IRS_annunON_DC_L = false;
            }
        }

        private void rightDcLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightDcLightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.IRS_annunON_DC_R = true;
                            }
            else
            {
                Properties.pmdg737_offsets.Default.IRS_annunON_DC_R = false;
            }
        }

        private void leftFaultLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leftFaultLightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.IRS_annunFAULT_L = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.IRS_annunFAULT_L = false;
            }
        }

        private void rightFaultLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightFaultLightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.IRS_annunFAULT_R = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.IRS_annunFAULT_R = false;
            }
        }

        private void leftDcFailureLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leftDcFailureLightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.IRS_annunDC_FAIL_L = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.IRS_annunDC_FAIL_L = false;
            }
        }

        private void rightDcFailureLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightDcFailureLightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.IRS_annunDC_FAIL_R = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.IRS_annunDC_FAIL_R = false;
            }
        }
    }
    }
