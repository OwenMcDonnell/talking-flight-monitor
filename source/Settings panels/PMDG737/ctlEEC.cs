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
    public partial class ctlEEC : UserControl, iSettingsPage
    {
        public ctlEEC()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlEEC_Load(object sender, EventArgs e)
        {
            leftEECCheckBox.Checked = Properties.pmdg737_offsets.Default.ENG_EECSwitch_1;
            rightEECCheckBox.Checked = Properties.pmdg737_offsets.Default.ENG_EECSwitch_2;
            leftControlCheckBox.Checked = Properties.pmdg737_offsets.Default.ENG_annunENGINE_CONTROL_1;
            rightControlCheckBox.Checked = Properties.pmdg737_offsets.Default.ENG_annunENGINE_CONTROL_2;
            leftAlternateCheckBox.Checked = Properties.pmdg737_offsets.Default.ENG_annunALTN_1;
            rightAlternateCheckBox.Checked = Properties.pmdg737_offsets.Default.ENG_annunALTN_2;
            leftReverserCheckBox.Checked = Properties.pmdg737_offsets.Default.ENG_annunREVERSER_1;
            rightReverserCheckBox.Checked = Properties.pmdg737_offsets.Default.ENG_annunREVERSER_2;
        }

        private void leftEECCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leftEECCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ENG_EECSwitch_1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ENG_EECSwitch_1 = false;
            }
        }

        private void rightEECCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightEECCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ENG_EECSwitch_2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ENG_EECSwitch_2 = false;
            }
        }

        private void leftControlCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leftControlCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ENG_annunENGINE_CONTROL_1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ENG_annunENGINE_CONTROL_1 = false;
            }
        }

        private void rightControlCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightControlCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ENG_annunENGINE_CONTROL_2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ENG_annunENGINE_CONTROL_2 = false;
            }
        }

        private void leftAlternateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leftAlternateCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ENG_annunALTN_1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ENG_annunALTN_1 = false;
            }
        }

        private void rightAlternateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightAlternateCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ENG_annunALTN_2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ENG_annunALTN_2 = false;
            }
        }

        private void leftReverserCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leftReverserCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ENG_annunREVERSER_1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ENG_annunREVERSER_1 = false;
            }
        }

        private void rightReverserCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightReverserCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ENG_annunREVERSER_2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ENG_annunREVERSER_1 = false;
            }
        }
    }
}
