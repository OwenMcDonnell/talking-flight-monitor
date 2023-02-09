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
    public partial class ctlControlStandTrim : UserControl, iSettingsPage
    {
        public ctlControlStandTrim()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlControlStandTrim_Load(object sender, EventArgs e)
        {

            electricalTrimCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "TRIM_StabTrimMainElecSw_NORMAL");
            autoPilotTrimCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "TRIM_StabTrimAutoPilotSw_NORMAL");
            trimCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "TRIM_StabTrimSw_NORMAL");
        }
    }
}
