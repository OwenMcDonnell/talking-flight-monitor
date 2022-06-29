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
    public partial class ctlWipers : UserControl, iSettingsPage
    {
        public ctlWipers()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlWipers_Load(object sender, EventArgs e)
        {
            leftWiperCheckBox.Checked = Properties.pmdg737_offsets.Default.OH_WiperLSelector;
            rightWiperCheckBox.Checked = Properties.pmdg737_offsets.Default.OH_WiperRSelector;
        }

        private void leftWiperCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leftWiperCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.OH_WiperLSelector = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.OH_WiperLSelector = false;
            }
        }

        private void rightWiperCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightWiperCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.OH_WiperRSelector = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.OH_WiperRSelector = false;    
            }
        }
    }
}
