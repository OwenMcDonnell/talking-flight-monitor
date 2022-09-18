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
    public partial class ctlWarnings : UserControl, iSettingsPage
    {
        public ctlWarnings()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlWarnings_Load(object sender, EventArgs e)
        {
            leftFireCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "WARN_annunFIRE_WARN1");
            rightFireCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "WARN_annunFIRE_WARN2");
            leftMasterCautionCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "WARN_annunMASTER_CAUTION1");
            rightMasterCautionCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "WARN_annunMASTER_CAUTION2");
            fltControlsCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "WARN_annunFLT_CONT");
            irsCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "WARN_annunIRS");
            fuelCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "WARN_annunFUEL");
            electricalCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "WARN_annunELEC");
            apuCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "WARN_annunAPU");
            overheatCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "WARN_annunOVHT_DET");
            antiIceCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "WARN_annunANTI_ICE");
            hydraulicsCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "WARN_annunHYD");
            doorsCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "WARN_annunDOORS");
            enginesCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "WARN_annunENG");
            overheadCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "WARN_annunOVERHEAD");
            airSystemsCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "WARN_annunAIR_COND");
        }
    }
}
