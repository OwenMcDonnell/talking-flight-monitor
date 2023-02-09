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
    public partial class ctlForwardGear : UserControl, iSettingsPage
    {
        public ctlForwardGear()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlForwardGear_Load(object sender, EventArgs e)
        {
            gearCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_GearLever");
            noseGearTransitCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunGEAR_transit_nose");
            leftGearTransitCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunGEAR_transit_left");
            rightGearTransitCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunGEAR_transit_right");
            noseGearLockedCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunGEAR_locked_nose");
            leftGearLockedCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunGEAR_locked_left");
            rightGearLockedCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunGEAR_locked_right");
        }
    }
}
