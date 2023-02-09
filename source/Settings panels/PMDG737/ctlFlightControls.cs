using tfm.Properties;
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
    public partial class ctlFlightControls : UserControl, iSettingsPage
    {

        public ctlFlightControls()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlFlightControls_Load(object sender, EventArgs e)
        {
            fctlACheckBox.Checked = pmdg737_offsets.Default.FCTL_FltControl_Sw_1;
            fctlBCheckBox.Checked = pmdg737_offsets.Default.FCTL_FltControl_Sw_2;
            spoilerACheckBox.Checked = pmdg737_offsets.Default.FCTL_Spoiler_Sw_1;
            spoilerBCheckBox.Checked = pmdg737_offsets.Default.FCTL_Spoiler_Sw_2;
            yawDamperCheckBox.Checked = pmdg737_offsets.Default.FCTL_YawDamper_Sw;
            altnFlapArmCheckBox.Checked = pmdg737_offsets.Default.FCTL_AltnFlaps_Sw_ARM;
            altnFlapPosCheckBox.Checked = pmdg737_offsets.Default.FCTL_AltnFlaps_Control_Sw;
            lowPressureALightCheckBox.Checked = pmdg737_offsets.Default.FCTL_annunFC_LOW_PRESSURE_1;
            lowPressureBCheckBox.Checked = pmdg737_offsets.Default.FCTL_annunFC_LOW_PRESSURE_2;
            yawDamperLightCheckBox.Checked = pmdg737_offsets.Default.FCTL_annunYAW_DAMPER;
            lowQuantityCheckBox.Checked = pmdg737_offsets.Default.FCTL_annunLOW_QUANTITY;
            lowPressureCheckBox.Checked = pmdg737_offsets.Default.FCTL_annunLOW_PRESSURE;
            standbyCheckBox.Checked = pmdg737_offsets.Default.FCTL_annunLOW_STBY_RUD_ON;
            feelDifCheckBox.Checked = pmdg737_offsets.Default.FCTL_annunFEEL_DIFF_PRESS;
            speedTrimCheckBox.Checked = pmdg737_offsets.Default.FCTL_annunSPEED_TRIM_FAIL;
            machTrimCheckBox.Checked = pmdg737_offsets.Default.FCTL_annunMACH_TRIM_FAIL;
            autoSlatCheckBox.Checked = pmdg737_offsets.Default.FCTL_annunAUTO_SLAT_FAIL;
        }

        private void fctlACheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (fctlACheckBox.Checked)
            {
                pmdg737_offsets.Default.FCTL_FltControl_Sw_1 = true;
            }
            else
            {
                pmdg737_offsets.Default.FCTL_FltControl_Sw_1 = false;
            }
        }

        private void fctlBCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (fctlBCheckBox.Checked)
            {
                pmdg737_offsets.Default.FCTL_FltControl_Sw_2 = true;
            }
            else
            {
                pmdg737_offsets.Default.FCTL_FltControl_Sw_2 = false;
            }
        }

        private void spoilerACheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (spoilerACheckBox.Checked)
            {
                pmdg737_offsets.Default.FCTL_Spoiler_Sw_1 = true;
            }
            else
            {
                pmdg737_offsets.Default.FCTL_Spoiler_Sw_1 = false;
            }
        }

        private void spoilerBCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (spoilerBCheckBox.Checked)
            {
                pmdg737_offsets.Default.FCTL_Spoiler_Sw_2 = true;
            }
            else
            {
                pmdg737_offsets.Default.FCTL_Spoiler_Sw_2 = false;
            }
        }

        private void yawDamperCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (yawDamperCheckBox.Checked)
            {
                pmdg737_offsets.Default.FCTL_YawDamper_Sw = true;
            }
            else
            {
                pmdg737_offsets.Default.FCTL_YawDamper_Sw = false;
            }
        }

        private void altnFlapArmCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (altnFlapArmCheckBox.Checked)
            {
                pmdg737_offsets.Default.FCTL_AltnFlaps_Sw_ARM = true;
            }
            else
            {
                pmdg737_offsets.Default.FCTL_AltnFlaps_Sw_ARM = false;
            }
        }

        private void altnFlapPosCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (altnFlapPosCheckBox.Checked)
            {
                pmdg737_offsets.Default.FCTL_AltnFlaps_Control_Sw = true;
            }
            else
            {
                pmdg737_offsets.Default.FCTL_AltnFlaps_Control_Sw = false;
            }
        }

        private void lowPressureALightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (lowPressureALightCheckBox.Checked)
            {
                pmdg737_offsets.Default.FCTL_annunFC_LOW_PRESSURE_1 = true;
            }
            else
            {
                pmdg737_offsets.Default.FCTL_annunFC_LOW_PRESSURE_1 = false;
            }
        }

        private void lowPressureBCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (lowPressureBCheckBox.Checked)
            {
                pmdg737_offsets.Default.FCTL_annunFC_LOW_PRESSURE_2 = true;
            }
            else
            {
                pmdg737_offsets.Default.FCTL_annunFC_LOW_PRESSURE_2 = false;
            }
        }

        private void yawDamperLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (yawDamperLightCheckBox.Checked)
            {
                pmdg737_offsets.Default.FCTL_annunYAW_DAMPER = true;
            }
            else
            {
                pmdg737_offsets.Default.FCTL_annunYAW_DAMPER = true;
            }

                            }

        private void lowQuantityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (lowQuantityCheckBox.Checked)
            {
                pmdg737_offsets.Default.FCTL_annunLOW_QUANTITY = true;
            }
            else
            {
                pmdg737_offsets.Default.FCTL_annunLOW_QUANTITY = false;
            }
        }

        private void lowPressureCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (lowPressureCheckBox.Checked)
            {
                pmdg737_offsets.Default.FCTL_annunLOW_PRESSURE = true;
            }
            else
            {
                pmdg737_offsets.Default.FCTL_annunLOW_PRESSURE = false;
            }
        }

        private void standbyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (standbyCheckBox.Checked)
            {
                pmdg737_offsets.Default.FCTL_annunLOW_STBY_RUD_ON = true;
            }
            else
            {
                pmdg737_offsets.Default.FCTL_annunLOW_STBY_RUD_ON = false;
            }
        }

        private void feelDifCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (feelDifCheckBox.Checked)
            {
                pmdg737_offsets.Default.FCTL_annunFEEL_DIFF_PRESS = true;
            }
            else
            {
                pmdg737_offsets.Default.FCTL_annunFEEL_DIFF_PRESS = false;
            }
        }

        private void speedTrimCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (speedTrimCheckBox.Checked)
            {
                pmdg737_offsets.Default.FCTL_annunSPEED_TRIM_FAIL = true;
            }
            else
            {
                pmdg737_offsets.Default.FCTL_annunSPEED_TRIM_FAIL = false;
            }
        }

        private void machTrimCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (machTrimCheckBox.Checked)
            {
                pmdg737_offsets.Default.FCTL_annunMACH_TRIM_FAIL = true;
            }
            else
            {
                pmdg737_offsets.Default.FCTL_annunMACH_TRIM_FAIL = false;
            }
        }

        private void autoSlatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (autoSlatCheckBox.Checked)
            {
                pmdg737_offsets.Default.FCTL_annunAUTO_SLAT_FAIL = true;
            }
            else
            {
                pmdg737_offsets.Default.FCTL_annunAUTO_SLAT_FAIL = false;
            }
        }
    }
}
