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
    public partial class ctlHydraulics : UserControl, iSettingsPage
    {
        public ctlHydraulics()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void ctlHydraulics_Load(object sender, EventArgs e)
        {
            elecPump1CheckBox.Checked = Properties.pmdg737_offsets.Default.HYD_PumpSw_elec1;
            elecPump2CheckBox.Checked = Properties.pmdg737_offsets.Default.HYD_PumpSw_elec2;
            engPump1CheckBox.Checked = Properties.pmdg737_offsets.Default.HYD_PumpSw_eng1;
            engPump2CheckBox.Checked = Properties.pmdg737_offsets.Default.HYD_PumpSw_eng2;
            elec1LowPressCheckBox.Checked = Properties.pmdg737_offsets.Default.HYD_annunLOW_PRESS_elec1;
            elec2LowPressCheckBox.Checked = Properties.pmdg737_offsets.Default.HYD_annunLOW_PRESS_elec2;
            eng1LowPressCheckBox.Checked = Properties.pmdg737_offsets.Default.HYD_annunLOW_PRESS_eng1;
            eng2LowPressCheckBox.Checked = Properties.pmdg737_offsets.Default.HYD_annunLOW_PRESS_eng2;
            elec1OvhtCheckBox.Checked = Properties.pmdg737_offsets.Default.HYD_annunOVERHEAT_elec1;
            elec2OvhtCheckBox.Checked = Properties.pmdg737_offsets.Default.HYD_annunOVERHEAT_elec2;
        }

        private void elecPump1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (elecPump1CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.HYD_PumpSw_elec1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.HYD_PumpSw_elec1 = false;
            }
        }

        private void elecPump2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (elecPump2CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.HYD_PumpSw_elec2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.HYD_PumpSw_elec2 = false;
            }
        }

        private void engPump1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (engPump1CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.HYD_PumpSw_eng1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.HYD_PumpSw_eng1 = false;
            }
        }

        private void engPump2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (engPump2CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.HYD_PumpSw_eng2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.HYD_PumpSw_eng2 = false;
            }
        }

        private void elec1LowPressCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (elec1LowPressCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.HYD_annunLOW_PRESS_elec1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.HYD_annunLOW_PRESS_elec1 = false;
            }
        }

        private void elec2LowPressCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (elec2LowPressCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.HYD_annunLOW_PRESS_elec2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.HYD_annunLOW_PRESS_elec2 = false;
            }
        }

        private void eng1LowPressCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (eng1LowPressCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.HYD_annunLOW_PRESS_eng1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.HYD_annunLOW_PRESS_eng1 = false;
            }
        }

        private void eng2LowPressCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (eng2LowPressCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.HYD_annunLOW_PRESS_eng2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.HYD_annunLOW_PRESS_eng2 = false;
            }
        }

        private void elec1OvhtCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (elec1OvhtCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.HYD_annunOVERHEAT_elec1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.HYD_annunOVERHEAT_elec1 = false;
            }
        }

        private void elec2OvhtCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (elec2OvhtCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.HYD_annunOVERHEAT_elec2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.HYD_annunOVERHEAT_elec2 = false;
            }
        }
    }
}
