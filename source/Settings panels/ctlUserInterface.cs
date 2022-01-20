using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm
{
    public partial class ctlUserInterface : UserControl, iSettingsPage
    {
        public ctlUserInterface()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void ctlUserInterface_Load(object sender, EventArgs e)
        {
            chkPlayStartupSound.Checked = Properties.Settings.Default.PlayStartupSound;
            chkPlayShutdownSound.Checked = Properties.Settings.Default.PlayShutdownSound;
        }

        private void chkPlayStartupSound_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPlayStartupSound.Checked)
            {
                Properties.Settings.Default.PlayStartupSound = true;

            }
            else
            {
                Properties.Settings.Default.PlayStartupSound = false;
            }
        }

        private void chkPlayShutdownSound_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPlayShutdownSound.Checked)
            {
                Properties.Settings.Default.PlayShutdownSound = true;

            }
            else
            {
                Properties.Settings.Default.PlayShutdownSound = false;
            }

        }
    }
}
