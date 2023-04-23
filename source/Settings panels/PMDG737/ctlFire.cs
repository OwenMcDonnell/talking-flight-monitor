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
    public partial class ctlFire : UserControl, iSettingsPage
    {
        public ctlFire()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlFire_Load(object sender, EventArgs e)
        {
            engine1FireHandleCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "FIRE_HandlePos1");
            apuFireHandleCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "FIRE_HandlePos2");
            engine2FireHandleCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "FIRE_HandlePos3");
            leftOverheatDetectCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "FIRE_OvhtDetSw1");
            rightOverheatDetectCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "FIRE_OvhtDetSw2");
            testCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "FIRE_DetTestSw");
            extinguisherTestCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "FIRE_ExtinguisherTestSw");
            engine1HandleLightCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "FIRE_HandleIlluminated1");
            apuHandleLightCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "FIRE_HandleIlluminated2");
            engine2HandleIlluminatedCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "FIRE_HandleIlluminated3");
            engine1OverheatCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "FIRE_annunENG_OVERHEAT1");
            engine2OverheatCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "FIRE_annunENG_OVERHEAT2");
            wheelWellCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "FIRE_annunWHEEL_WELL");
            fireFaultCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "FIRE_annunFAULT");
            apuDetectorInopCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "FIRE_annunAPU_DET_INOP");
            apuBottleDischCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "FIRE_annunAPU_BOTTLE_DISCHARGE");
            engine1BottleDischCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "FIRE_annunBOTTLE_DISCHARGE1");
            engine2BottleDischCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "FIRE_annunBOTTLE_DISCHARGE2");
            engine1ExtinguisherTestCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "FIRE_annunExtinguisherTest1");
            engine2ExtinguisherTestCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "FIRE_annunExtinguisherTest2");
            apuExtinguisherTestCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "FIRE_annunExtinguisherTest3");
        }
    }
}
