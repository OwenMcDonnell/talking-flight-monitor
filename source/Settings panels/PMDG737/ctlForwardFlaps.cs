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
    public partial class ctlForwardFlaps : UserControl, iSettingsPage
    {
        public ctlForwardFlaps()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlForwardFlaps_Load(object sender, EventArgs e)
        {
            leftFlapsNeedleCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_TEFlapsNeedle1");
            rightFlapsNeedleCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_TEFlapsNeedle2");
            flapsInTransitCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunLE_FLAPS_TRANSIT");
            flapsExtendedCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunLE_FLAPS_EXT");
        }
    }
}
