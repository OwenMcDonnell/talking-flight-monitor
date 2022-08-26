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
    public partial class ctlCenterMain : UserControl, iSettingsPage
    {
        public ctlCenterMain()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlCenterMain_Load(object sender, EventArgs e)
        {
            breakerKnobCheckBox.Checked = Properties.pmdg737_offsets.Default.LTS_CircuitBreakerKnob;
            overheadPanelKnobCheckBox.Checked = Properties.pmdg737_offsets.Default.LTS_OvereadPanelKnob;
            emergencyLightsSelectorCheckBox.Checked = Properties.pmdg737_offsets.Default.LTS_EmerExitSelector;
            equipCoolingSupplyCheckBox.Checked = Properties.pmdg737_offsets.Default.AIR_EquipCoolingSupplyNORM;
            equipCoolingSupplyCheckBox.Checked = Properties.pmdg737_offsets.Default.AIR_EquipCoolingExhaustNORM;
            noSmokingSelectorCheckBox.Checked = Properties.pmdg737_offsets.Default.COMM_NoSmokingSelector;
            seatBeltSelectorComboBox.Checked = Properties.pmdg737_offsets.Default.COMM_FastenBeltsSelector;
            emergencyLightNotArmedCheckBox.Checked = Properties.pmdg737_offsets.Default.LTS_annunEmerNOT_ARMED;
            equipCoolingSupplyLightCheckBox.Checked = Properties.pmdg737_offsets.Default.AIR_annunEquipCoolingSupplyOFF;
            equipCoolingExhaustLightCheckBox.Checked = Properties.pmdg737_offsets.Default.AIR_annunEquipCoolingExhaustOFF;
            callLightCheckBox.Checked = Properties.pmdg737_offsets.Default.COMM_annunCALL;
            paInUseCheckBox.Checked = Properties.pmdg737_offsets.Default.COMM_annunPA_IN_USE;
        }

        private void breakerKnobCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (breakerKnobCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.LTS_CircuitBreakerKnob = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.LTS_CircuitBreakerKnob = false;
            }
        }

        private void overheadPanelKnobCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (overheadPanelKnobCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.LTS_OvereadPanelKnob = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.LTS_OvereadPanelKnob = false;
            }
        }

        private void emergencyLightsSelectorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (emergencyLightsSelectorCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.LTS_EmerExitSelector = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.LTS_EmerExitSelector = false;
            }
        }

        private void equipCoolingSupplyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (equipCoolingSupplyCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.AIR_EquipCoolingSupplyNORM = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.AIR_EquipCoolingSupplyNORM = false;
            }
        }

        private void equipCoolingExhaustCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (equipCoolingExhaustCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.AIR_EquipCoolingExhaustNORM = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.AIR_EquipCoolingExhaustNORM = false;
            }
        }

        private void noSmokingSelectorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (noSmokingSelectorCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.COMM_NoSmokingSelector = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.COMM_NoSmokingSelector = false;
            }
        }

        private void seatBeltSelectorComboBox_CheckedChanged(object sender, EventArgs e)
        {
            if (seatBeltSelectorComboBox.Checked)
            {
                Properties.pmdg737_offsets.Default.COMM_FastenBeltsSelector = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.COMM_FastenBeltsSelector = false;
            }
        }

        private void emergencyLightNotArmedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (emergencyLightNotArmedCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.LTS_annunEmerNOT_ARMED = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.LTS_annunEmerNOT_ARMED = false;
            }
        }

        private void equipCoolingSupplyLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (equipCoolingSupplyLightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.AIR_annunEquipCoolingSupplyOFF = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.AIR_annunEquipCoolingSupplyOFF = false;
            }
        }

        private void equipCoolingExhaustLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (equipCoolingExhaustLightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.AIR_annunEquipCoolingExhaustOFF = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.AIR_annunEquipCoolingExhaustOFF = false;
            }
        }

        private void callLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (callLightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.COMM_annunCALL = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.COMM_annunCALL = false;
            }
        }

        private void paInUseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (paInUseCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.COMM_annunPA_IN_USE = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.COMM_annunPA_IN_USE = false;
            }
        }
    }
}
