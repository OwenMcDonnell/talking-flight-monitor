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
    public partial class ctlAPU : UserControl, iSettingsPage
    {
        public ctlAPU()
        {
            InitializeComponent();
        }

        private void ctlAPU_Load(object sender, EventArgs e)
        {
            egtNeedleCheckBox.Checked = Properties.pmdg737_offsets.Default.APU_EGTNeedle;
            maintCheckBox.Checked = Properties.pmdg737_offsets.Default.APU_annunMAINT;
            lowOilCheckBox.Checked = Properties.pmdg737_offsets.Default.APU_annunLOW_OIL_PRESSURE;
            faultCheckBox.Checked = Properties.pmdg737_offsets.Default.APU_annunFAULT;
            overSpeedCheckBox.Checked = Properties.pmdg737_offsets.Default.APU_annunOVERSPEED;
        }

        private void egtNeedleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (egtNeedleCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.APU_EGTNeedle = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.APU_EGTNeedle = false;
            }
        }

        private void maintCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (maintCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.APU_annunMAINT = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.APU_annunMAINT = false;
            }
        }

        private void lowOilCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (lowOilCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.APU_annunLOW_OIL_PRESSURE = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.APU_annunLOW_OIL_PRESSURE = false;
            }
        }

        private void faultCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (faultCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.APU_annunFAULT = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.APU_annunFAULT = false;
            }
        }

        private void overSpeedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (overSpeedCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.APU_annunOVERSPEED = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.APU_annunOVERSPEED = false;
            }
        }

        public void SetDocking()
        {
                    }
    }
}
