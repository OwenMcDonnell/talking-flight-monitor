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
    public partial class ctlPSEU : UserControl, iSettingsPage
    {
        public ctlPSEU()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlPSEU_Load(object sender, EventArgs e)
        {
            pseuWarningCheckBox.Checked = Properties.pmdg737_offsets.Default.WARN_annunPSEU;
        }

        private void pseuWarningCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (pseuWarningCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.WARN_annunPSEU = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.WARN_annunPSEU = false;
            }
        }
    }
}
