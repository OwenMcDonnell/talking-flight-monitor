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
    public partial class ctlFuel : UserControl, iSettingsPage
    {
        public ctlFuel()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void ctlFuel_Load(object sender, EventArgs e)
        {
            fuelTempCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_FuelTempNeedle;
            leftAftPumpCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_PumpAftSw_L;
            rightAftPumpCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_PumpAftSw_R;
            aftAuxACheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_AuxAft_A;
            aftAuxBCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_AuxAft_B;
            aftBleedCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_AFTBleed;
            leftAftLowPressureCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Aft_1;
            rightAftLowPressureCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Aft_2;
            leftFwdPumpCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_PumpFwdSw_L;
            rightFwdPumpCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_PumpFwdSw_R;
            fwdAuxACheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_AuxFwd_A;
            fwdAuxBCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_AuxAft_B;
            fwdBleedCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_FWDBleed;
            leftFwdLowPressureCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Fwd_1;
            rightFwdLowPressureCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Fwd_2;
            leftCtrPumpCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_PumpCtrSw_L;
            rightCtrPumpCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_PumpCtrSw_R;
            leftCtrLowPressureCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Ctr_1;
            rightCtrLowPressureCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Ctr_2;
            gndXferCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_GNDXfr;
            crossfeedCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_CrossFeedSw;
            leftValveCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_annunENG_VALVE_CLOSED_1;
            rightValveCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_annunENG_VALVE_CLOSED_2;
            leftSparCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_annunSPAR_VALVE_CLOSED_1;
            rightSparCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_annunSPAR_VALVE_CLOSED_2;
            leftBypassCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_annunFILTER_BYPASS_1;
            rightBypassCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_annunFILTER_BYPASS_2;
            crossfeedLightCheckBox.Checked = Properties.pmdg737_offsets.Default.FUEL_annunXFEED_VALVE_OPEN;
        }

        private void leftAftPumpCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leftAftPumpCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_PumpAftSw_L = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_PumpAftSw_L = false;
            }
        }

        private void rightAftPumpCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightAftPumpCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_PumpAftSw_R = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_PumpAftSw_R = false;
            }
        }

        private void aftAuxACheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (aftAuxACheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_AuxAft_A = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_AuxAft_A = false;
            }
        }

        private void aftAuxBCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (aftAuxBCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_AuxAft_B = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_AuxAft_B = false;
            }
        }

        private void aftBleedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (aftBleedCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_AFTBleed = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_AFTBleed = false;
            }
        }

        private void leftAftLowPressureCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leftAftLowPressureCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Aft_1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Aft_1 = false;
            }
        }

        private void rightAftLowPressureCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightAftLowPressureCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Aft_2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Aft_2 = false;
            }
        }

        private void leftFwdPumpCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leftFwdPumpCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_PumpFwdSw_L = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_PumpFwdSw_L = false;
            }
        }

        private void rightFwdPumpCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightFwdPumpCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_PumpFwdSw_R = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_PumpFwdSw_R = false;
            }
        }

        private void fwdAuxACheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (fwdAuxACheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_AuxFwd_A = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_AuxFwd_A = false;
            }
        }

        private void fwdAuxBCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (fwdAuxBCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_AuxFwd_B = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_AuxFwd_B = false;
            }
        }

        private void fwdBleedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (fwdBleedCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_FWDBleed = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_FWDBleed = false;
            }
        }

        private void leftFwdLowPressureCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leftFwdLowPressureCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Fwd_1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Fwd_1 = false;
            }
        }

        private void rightFwdLowPressureCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightFwdLowPressureCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Fwd_2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Fwd_2 = false;
            }
        }

        private void leftCtrPumpCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leftCtrPumpCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_PumpCtrSw_L = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_PumpCtrSw_L = false;
            }
        }

        private void rightCtrPumpCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightCtrPumpCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_PumpCtrSw_R = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_PumpCtrSw_R = false;
            }
        }

        private void leftCtrLowPressureCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leftCtrLowPressureCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Ctr_1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Ctr_1 = false;
            }
        }

        private void rightCtrLowPressureCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightCtrLowPressureCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Ctr_2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_annunLOWPRESS_Ctr_2 = false;
            }
        }

        private void gndXferCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (gndXferCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_GNDXfr = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_GNDXfr = false;
            }
        }

        private void crossfeedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (crossfeedCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_CrossFeedSw = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_CrossFeedSw = false;
            }
        }

        private void leftValveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leftValveCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_annunENG_VALVE_CLOSED_1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_annunENG_VALVE_CLOSED_1 = false;
            }
        }

        private void rightValveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightValveCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_annunENG_VALVE_CLOSED_2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_annunENG_VALVE_CLOSED_2 = false;
            }
        }

        private void leftSparCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leftSparCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_annunSPAR_VALVE_CLOSED_1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_annunSPAR_VALVE_CLOSED_1 = false;
            }
        }

        private void rightSparCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightSparCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_annunSPAR_VALVE_CLOSED_2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_annunSPAR_VALVE_CLOSED_2 = false;
            }
        }

        private void leftBypassCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leftBypassCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_annunFILTER_BYPASS_1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_annunFILTER_BYPASS_1 = false;
            }
        }

        private void rightBypassCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightBypassCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_annunFILTER_BYPASS_2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_annunFILTER_BYPASS_2 = false;
            }
        }

        private void crossfeedLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (crossfeedLightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FUEL_annunXFEED_VALVE_OPEN = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FUEL_annunXFEED_VALVE_OPEN = false;
            }
        }
    }
}
