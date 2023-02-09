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
    public partial class ctlForwardMain : UserControl, iSettingsPage
    {
        public ctlForwardMain()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void ctlForwardMain_Load(object sender, EventArgs e)
        {
            noseWheelSteeringCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_NoseWheelSteeringSwNORM");
            captDisengageTestCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_DisengageTestSelector1");
            foDisengageTestCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_DisengageTestSelector2");
            lightsCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_LightsSelector");
            fuelFlowCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_FuelFlowSelector");
            belowGS1CheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunBELOW_GS1");
            belowGS2CheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunBELOW_GS2");
            fmc1CheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunFMC1");
            fmc2CheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunFMC2");
            stabOutOfTrimCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunSTAB_OUT_OF_TRIM");
            antiSkidInopCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MAIN_annunANTI_SKID_INOP");
        }
    }
}
