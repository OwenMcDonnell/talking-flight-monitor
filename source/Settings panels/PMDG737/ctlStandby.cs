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
    public partial class ctlStandby : UserControl, iSettingsPage
    {
        public ctlStandby()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void ctlStandby_Load(object sender, EventArgs e)
        {

            rmi1CheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_RMISelector1_VOR");
            rmi2CheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_RMISelector2_VOR");
        }
    }
}
