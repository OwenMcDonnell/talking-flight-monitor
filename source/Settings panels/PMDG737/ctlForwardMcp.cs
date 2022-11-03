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
    public partial class ctlForwardMcp : UserControl, iSettingsPage
    {
        public ctlForwardMcp()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void ctlForwardMcp_Load(object sender, EventArgs e)
        {
            redLeftATCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunAT1");
            rightRedATCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunAT2");
            amberLeftATCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunAT_Amber1");
            amberRightATCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunAT_Amber2");
            redCommandACheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunAP1");
            redCommandBCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunAP2");
            amberCommandACheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunAP_Amber1");
            amberCommandBCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunAP_Amber2");
        }
    }
}
