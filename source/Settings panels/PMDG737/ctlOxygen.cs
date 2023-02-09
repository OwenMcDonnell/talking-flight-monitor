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
    public partial class ctlOxygen : UserControl, iSettingsPage
    {
        public ctlOxygen()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlOxygen_Load(object sender, EventArgs e)
        {
            oxyNeedleCheckBox.Checked = Properties.pmdg737_offsets.Default.OXY_Needle;
            oxySwitchCheckBox.Checked = Properties.pmdg737_offsets.Default.OXY_SwNormal;
            passengerOxyCheckBox.Checked = Properties.pmdg737_offsets.Default.OXY_annunPASS_OXY_ON;
        }

        private void oxyNeedleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (oxyNeedleCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.OXY_Needle = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.OXY_Needle = false;
            }
        }

        private void oxySwitchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (oxySwitchCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.OXY_SwNormal = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.OXY_SwNormal = false;
            }
        }

        private void passengerOxyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (passengerOxyCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.OXY_annunPASS_OXY_ON = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.OXY_annunPASS_OXY_ON = false;
            }
        }
    }
}
