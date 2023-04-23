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
    public partial class ctlBuses : UserControl, iSettingsPage
    {
        public ctlBuses()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlBuses_Load(object sender, EventArgs e)
        {
            hotBattCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "BUSSES_DC_HOT_BAT");
            hotBattSwitchedCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "BUSSES_DC_HOT_BAT_SWITCHED");
            battBusCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "BUSSES_DC_BAT_BUS");
            dcStandbyCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "BUSSES_DC_STANDBY_BUS");
                        bus1CheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "BUSSES_DC_BUS1");
            bus2CheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "BUSSES_DC_BUS2");
            dcGrndSvcCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "BUSSES_DC_GROUND_SVC");
            transfer1CheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "BUSSES_AC_TRANSFER1");
            transfer2CheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "BUSSES_AC_TRANSFER2");
            acGndSvc1CheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "BUSSES_AC_GROUND_SVC1");
            acGndSvc2CheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "BUSSES_AC_GROUND_SVC2");
            main1CheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "BUSSES_AC_MAIN1");
            main2CheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "BUSSES_AC_MAIN2");
            galley1CheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "BUSSES_AC_GALLEY1");
            galley2CheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "BUSSES_AC_GALLEY2");
            acStandbyCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "BUSSES_AC_STANDBY");
        }
    }
}
