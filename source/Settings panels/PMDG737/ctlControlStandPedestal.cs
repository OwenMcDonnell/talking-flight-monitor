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
    public partial class ctlControlStandPedestal : UserControl, iSettingsPage
    {
        public ctlControlStandPedestal()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlControlStandPedestal_Load(object sender, EventArgs e)
        {
            floodKnobCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_PedFloodKnob");
            brightnessKnobCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_PedPanelKnob");
            parkingBrakeLightCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "PED_annunParkingBrake");
            unlockLightCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "PED_annunAUTO_UNLK");
            unlockFailureCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "PED_annunLOCK_FAIL");

        }
    }
}
