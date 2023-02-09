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
    public partial class ctlDomeLights : UserControl, iSettingsPage
    {
        public ctlDomeLights()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlDomeLights_Load(object sender, EventArgs e)
        {
            domeLightsCheckBox.Checked = Properties.pmdg737_offsets.Default.LTS_DomeWhiteSw;
        }

        private void domeLightsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (domeLightsCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.LTS_DomeWhiteSw = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.LTS_DomeWhiteSw = false;
            }
        }
    }
}
