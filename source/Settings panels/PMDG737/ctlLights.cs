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
    public partial class ctlLights : UserControl, iSettingsPage
    {
        public ctlLights()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlLights_Load(object sender, EventArgs e)
        {
            leftRetractableCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_LandingLtRetractableSw1");
            rightRetractableCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_LandingLtRetractableSw2");
            leftFixedCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_LandingLtFixedSw1");
            rightFixedCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_LandingLtFixedSw2");
            leftTurnoffCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_RunwayTurnoffSw1");
            rightTurnoffCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_RunwayTurnoffSw2");
            taxiCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_TaxiSw");
            logoCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_LogoSw");
            antiCollisionCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_AntiCollisionSw");
            wingCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_WingSw");
            wheelWellCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_WheelWellSw");
            positionCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_PositionSw");

        }
    }
}
