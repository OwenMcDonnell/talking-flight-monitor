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
    public partial class ctlDU : UserControl, iSettingsPage
    {
        public ctlDU()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void ctlDU_Load(object sender, EventArgs e)
        {
            captDUCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_MainPanelDUSel1");
            foDUCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_MainPanelDUSel2");
            captLowerDUCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_LowerDUSel1");
            foLowerDUCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_LowerDUSel2");
        }
    }
}
