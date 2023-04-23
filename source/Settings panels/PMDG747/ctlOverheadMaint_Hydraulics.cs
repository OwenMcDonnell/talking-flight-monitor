using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.Settings_panels.PMDG747
{
    public partial class ctlOverheadMaint_Hydraulics : UserControl, iSettingsPage
    {
        public ctlOverheadMaint_Hydraulics()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void ctlOverheadMaint_Hydraulics_Load(object sender, EventArgs e)
        {

            wingHydValve1CheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "FCTL_WingHydValve_Sw_SHUT_OFF1");
            wingHydValve2CheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "FCTL_WingHydValve_Sw_SHUT_OFF2");
            wingHydValve3CheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "FCTL_WingHydValve_Sw_SHUT_OFF3");
            wingHydValve4CheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "FCTL_WingHydValve_Sw_SHUT_OFF4");
            tailHydValve1CheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "FCTL_TailHydValve_Sw_SHUT_OFF1");
            tailHydValve2CheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "FCTL_TailHydValve_Sw_SHUT_OFF2");
            tailHydValve3CheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "FCTL_TailHydValve_Sw_SHUT_OFF3");
            tailHydValve4CheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "FCTL_TailHydValve_Sw_SHUT_OFF4");
            wingHydValve1LightCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "FCTL_annunWingHydVALVE_CLOSED1");
            wingHydValve2LightCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "FCTL_annunWingHydVALVE_CLOSED2");
            wingHydValve3LightCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "FCTL_annunWingHydVALVE_CLOSED3");
            wingHydValve4LightCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "FCTL_annunWingHydVALVE_CLOSED4");
            tailHydValve1LightCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "FCTL_annunTailHydVALVE_CLOSED1");
            tailHydValve2LightCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "FCTL_annunTailHydVALVE_CLOSED2");
            tailHydValve3LightCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "FCTL_annunTailHydVALVE_CLOSED3");
            tailHydValve4LightCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "FCTL_annunTailHydVALVE_CLOSED4");
        }
    }
}
