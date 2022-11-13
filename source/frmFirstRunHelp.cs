using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm
{
    public partial class frmFirstRunHelp : Form
    {
        public frmFirstRunHelp()
        {
            InitializeComponent();
        }

        private void frmFirstRunHelp_Load(object sender, EventArgs e)
        {
            txtHelpMessage.Text = @"Welcome to Talking Flight Monitor (TFM)!
TFM is controlled entirely through keyboard commands. All commands start with either the left or right Square Bracket keys.
Left Square Bracket: autopilot commands
Right square bracket: aircraft information
Right Bracket, then Question Mark: Turns on help mode, pressing any command will read it's function.
Right Bracket, then Ctrl+K: keyboard manager";
            txtHelpMessage.SelectionStart = 0;
            
        }

private void chkDoNotShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDoNotShow.Checked) {
                Properties.Settings.Default.ShowFirstRunDialog = false;
                    }
        }
    }
}
