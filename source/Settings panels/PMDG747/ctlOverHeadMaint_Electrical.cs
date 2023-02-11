using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.Settings_panels.PMDG747
{
    public partial class ctlOverHeadMaint_Electrical : UserControl, iSettingsPage
    {
        public ctlOverHeadMaint_Electrical()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlOverHeadMaint_Electrical_Load(object sender, EventArgs e)
        {

            gen1ResetCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "ELEC_GenFieldReset1");
            gen2ResetCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "ELEC_GenFieldReset2");
            gen3ResetCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "ELEC_GenFieldReset3");
            gen4ResetCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "ELEC_GenFieldReset4");
            gen1FieldCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "ELEC_annunGen_FIELD_OFF1");
            gen2FieldCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "ELEC_annunGen_FIELD_OFF2");
            gen3FieldCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "ELEC_annunGen_FIELD_OFF3");
            gen4FieldCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "ELEC_annunGen_FIELD_OFF4");
            apu1ResetCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "ELEC_APUFieldReset1");
            apu2ResetCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "ELEC_APUFieldReset2");
            apu1FieldCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "ELEC_annunAPU_FIELD_OFF1");
            apu2FieldCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "ELEC_annunAPU_FIELD_OFF2");
            splitSystemBreakerCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "ELEC_SplitSystemBreaker");
            splitSystemBreakerLightCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "ELEC_annunSplitSystemBreaker_OPEN");
        }
    }
}
