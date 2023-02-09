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
    public partial class ctlAirSystems : UserControl, iSettingsPage
    {
        public ctlAirSystems()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlAirSystems_Load(object sender, EventArgs e)
        {

            // Bind the checkboxes checked property to the 737 announcement toggles. It loads faster and is less code.
            fltAltitudeCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_DisplayFltAlt");
            lndAltCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_DisplayLandAlt");
            airSourceCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_TempSourceSelector");
            pressModeCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_PressurizationModeSelector");
            leftPackCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_PackSwitch1");
            rightPackCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_PackSwitch2");
            leftBleedCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_BleedAirSwitch1");
            rightBleedCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_BleedAirSwitch2");
            apuBleedCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_APUBleedAirSwitch");
            leftRecircFanCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_RecircFanSwitch1");
            rightRecircFanCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_RecircFanSwitch2");
            airTrimCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_TrimAirSwitch");
            outflowValveCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_OutflowValveSwitch");
            isolValveCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_IsolationValveSwitch");
            fltDeckCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_annunZoneTemp1");
            fwdCabinCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_annunZoneTemp2");
            aftCabinCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_annunZoneTemp3");
            dualBleedCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_annunDualBleed");
            leftBleedTripCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_annunBleedTripOff1");
            rightBleedTripCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_annunBleedTripOff2");
            leftRamDoorCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_annunRamDoorL");
            rightRamDoorCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_annunRamDoorR");
            leftPackTripCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_annunPackTripOff1");
            rightPackTripCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_annunPackTripOff2");
            leftWingOverheatCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_annunWingBodyOverheat1");
            rightWingOverheatCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AIR_annunWingBodyOverheat2");
        }
    }
}
