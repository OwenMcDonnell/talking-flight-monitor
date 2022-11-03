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
    public partial class ctlForwardBrakes : UserControl, iSettingsPage
    {
        public ctlForwardBrakes()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlForwardBrakes_Load(object sender, EventArgs e)
        {
            autoBrakeCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_AutobrakeSelector");
            brakePressureCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_BrakePressNeedle");
            speedBrakeArmedCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunSPEEDBRAKE_ARMED");
            speedBrakeDoNotArmCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunSPEEDBRAKE_DO_NOT_ARM");
            speedBrakeExtendedCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunSPEEDBRAKE_EXTENDED");
            autoBrakeDisarmCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunAUTO_BRAKE_DISARM");
        }
    }
}
