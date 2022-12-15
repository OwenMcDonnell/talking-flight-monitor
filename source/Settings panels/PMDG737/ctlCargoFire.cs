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
    public partial class ctlCargoFire : UserControl, iSettingsPage
    {
        public ctlCargoFire()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlCargoFire_Load(object sender, EventArgs e)
        {
            forwardSelectorCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "CARGO_DetSelect1");
            aftSelectorCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "CARGO_DetSelect2");
            forwardDetectorCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "CARGO_ArmedSw1");
            aftDetectorCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "CARGO_ArmedSw2");
            forwardExtinguisherTestCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "CARGO_annunExtTest1");
            aftExtinguisherTestCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "CARGO_annunExtTest2");
            fwdFireCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "CARGO_annunFWD");
            aftFireCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "CARGO_annunAFT");
            detectorFaultCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "CARGO_annunDETECTOR_FAULT");
            bottleDischargeCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "CARGO_annunDISCH");
        }
    }
}
