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
    public partial class ctlGear : UserControl, iSettingsPage
    {
        public ctlGear()
        {
            InitializeComponent();
        }

        private void ctlGear_Load(object sender, EventArgs e)
        {
            noseGearCheckBox.Checked = Properties.pmdg737_offsets.Default.GEAR_annunOvhdNOSE;
            leftGearCheckBox.Checked = Properties.pmdg737_offsets.Default.GEAR_annunOvhdLEFT;
            rightGearCheckBox.Checked = Properties.pmdg737_offsets.Default.GEAR_annunOvhdRIGHT;
        }

        private void noseGearCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (noseGearCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.GEAR_annunOvhdNOSE = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.GEAR_annunOvhdNOSE = false;
            }
        }

        private void leftGearCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leftGearCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.GEAR_annunOvhdLEFT = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.GEAR_annunOvhdLEFT = false;
            }
        }

        private void rightGearCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightGearCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.GEAR_annunOvhdRIGHT = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.GEAR_annunOvhdRIGHT = true;
            }
        }

        public void SetDocking()
        {
                    }
    }
}
