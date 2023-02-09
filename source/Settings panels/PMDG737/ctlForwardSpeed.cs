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
    public partial class ctlForwardSpeed : UserControl, iSettingsPage
    {
        public ctlForwardSpeed()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void ctlForwardSpeed_Load(object sender, EventArgs e)
        {
            n1SelectorCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_N1SetSelector");
            speedRefCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_SpdRefSelector");
        }
    }
}
