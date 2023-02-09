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
    public partial class ctlServiceInterPhone : UserControl, iSettingsPage
    {
        public ctlServiceInterPhone()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void servicePhoneCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (servicePhoneCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.COMM_ServiceInterphoneSw = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.COMM_ServiceInterphoneSw = false;
            }
        }

        private void ctlServiceInterPhone_Load(object sender, EventArgs e)
        {
            servicePhoneCheckBox.Checked = Properties.pmdg737_offsets.Default.COMM_ServiceInterphoneSw;
        }
    }
}
