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
    public partial class ctlNav_Dis : UserControl, iSettingsPage
    {
        public ctlNav_Dis()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlNav_Dis_Load(object sender, EventArgs e)
        {
            vhfCheckBox.Checked = Properties.pmdg737_offsets.Default.NAVDIS_VHFNavSelector;
            irsCheckBox.Checked = Properties.pmdg737_offsets.Default.NAVDIS_IRSSelector;
            fmcCheckBox.Checked = Properties.pmdg737_offsets.Default.NAVDIS_FMCSelector;
            sourceCheckBox.Checked = Properties.pmdg737_offsets.Default.NAVDIS_SourceSelector;
            controlPaneCheckBox.Checked = Properties.pmdg737_offsets.Default.NAVDIS_ControlPaneSelector;
        }

        private void vhfCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (vhfCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.NAVDIS_VHFNavSelector = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.NAVDIS_VHFNavSelector = false;
            }
        }

        private void irsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (irsCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.NAVDIS_IRSSelector = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.NAVDIS_IRSSelector = false;
            }
        }

        private void fmcCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (fmcCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.NAVDIS_FMCSelector = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.NAVDIS_FMCSelector = false;
            }
        }

        private void sourceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sourceCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.NAVDIS_SourceSelector = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.NAVDIS_SourceSelector = false;
            }
        }

        private void controlPaneCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (controlPaneCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.NAVDIS_ControlPaneSelector = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.NAVDIS_ControlPaneSelector = false;
            }
        }
    }
}
