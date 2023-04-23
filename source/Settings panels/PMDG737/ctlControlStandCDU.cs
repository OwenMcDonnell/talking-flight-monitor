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
    public partial class ctlControlStandCDU : UserControl, iSettingsPage
    {
        public ctlControlStandCDU()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlControlStandCDU_Load(object sender, EventArgs e)
        {

            cdu1ExecuteCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "CDU_annunEXEC1");
            cdu2ExecuteCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "CDU_annunEXEC2");
            cdu1CallCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "CDU_annunCALL1");
            cdu2CallCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "CDU_annunCALL2");
            cdu1FailureCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "CDU_annunFAIL1");
            cdu2FailureCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "CDU_annunFAIL2");
            cdu1MessageCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "CDU_annunMSG1");
            cdu2MessageCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "CDU_annunMSG2");
            cdu1OffsetCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "CDU_annunOFST1");
            cdu2OffsetCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "CDU_annunOFST2");
            cdu1BrightnessCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "CDU_BrtKnob1");
            cdu2BrightnessCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "CDU_BrtKnob2");
        }
    }
}
