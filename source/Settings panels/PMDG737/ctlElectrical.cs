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
    public partial class ctlElectrical : UserControl, iSettingsPage
    {
        public ctlElectrical()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlElectrical_Load(object sender, EventArgs e)
        {
            batteryCheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_BatSelector;
            gndPowerCheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_GrdPwrSw;
            cabinUtilCheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_CabUtilSw;
            passSeatsCheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_IFEPassSeatSw;
            dcSelectorCheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_DCMeterSelector;
            acSelectorCheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_ACMeterSelector;
            standbyPowerCheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_StandbyPowerSelector;
            idg1CheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_IDGDisconnectSw_1;
            idg2CheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_IDGDisconnectSw_2;
            gen1CheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_GenSw_1;
            gen2CheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_GenSw_2;
            apuGen1CheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_APUGenSw_1;
            apuGen2CheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_APUGenSw_2;
            busXferCheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_BusTransSw_AUTO;
            batteryLightCheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_annunBAT_DISCHARGE;
            trUnitCheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_annunTR_UNIT;
            elecLightCheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_annunELEC;
            drive1LightCheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_annunDRIVE_1;
            drive2LightCheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_annunDRIVE_2;
            standbyLightCheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_annunSTANDBY_POWER_OFF;
            gndPowerLightCheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_annunGRD_POWER_AVAILABLE;
            xferBus1CheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_annunTRANSFER_BUS_OFF_1;
            xferBus2LightCheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_annunTRANSFER_BUS_OFF_2;
            acSourceLightCheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_annunSOURCE_OFF_1;
            dcSourceLightCheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_annunSOURCE_OFF_2;
            genBus1LightCheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_annunGEN_BUS_OFF_1;
            genBus2LightCheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_annunGEN_BUS_OFF_2;
            apuGenBusLightCheckBox.Checked = Properties.pmdg737_offsets.Default.ELEC_annunAPU_GEN_OFF_BUS;

        }

        private void batteryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(batteryCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_BatSelector = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_BatSelector = false;
            }
        }

        private void gndPowerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (gndPowerCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_GrdPwrSw = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_GrdPwrSw = false;
            }
        }

        private void cabinUtilCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (cabinUtilCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_CabUtilSw = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_CabUtilSw = false;
            }
        }

        private void passSeatsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (passSeatsCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_IFEPassSeatSw = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_IFEPassSeatSw = false;
            }
        }

        private void dcSelectorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (dcSelectorCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_DCMeterSelector = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_DCMeterSelector = false;
            }
        }

        private void acSelectorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (acSelectorCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_ACMeterSelector = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_ACMeterSelector = false;
            }
        }

        private void standbyPowerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (standbyPowerCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_StandbyPowerSelector = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_StandbyPowerSelector = false;
            }
        }

        private void idg1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (idg1CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_IDGDisconnectSw_1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_IDGDisconnectSw_1 = false;
            }
        }

        private void idg2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (idg2CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_IDGDisconnectSw_2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_IDGDisconnectSw_2 = false;
            }
        }

        private void gen1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (gen1CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_GenSw_1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_GenSw_1 = false;
            }
        }

        private void gen2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (gen2CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_GenSw_2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_GenSw_2 = false;
            }
        }

        private void apuGen1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (apuGen1CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_APUGenSw_1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_APUGenSw_1 = false;
            }
        }

        private void apuGen2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (apuGen2CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_APUGenSw_2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_APUGenSw_2 = false;
            }
        }

        private void busXferCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (busXferCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_BusTransSw_AUTO = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_BusTransSw_AUTO = false;
            }
        }

        private void batteryLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (batteryLightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_annunBAT_DISCHARGE = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_annunBAT_DISCHARGE = false;
            }
        }

        private void trUnitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (trUnitCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_annunTR_UNIT = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_annunTR_UNIT = false;
            }
        }

        private void elecLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (elecLightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_annunELEC = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_annunELEC = false;
            }
        }

        private void drive1LightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (drive1LightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_annunDRIVE_1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_annunDRIVE_1 = false;
            }
        }

        private void drive2LightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (drive2LightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_annunDRIVE_2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_annunDRIVE_2 = false;
            }
        }

        private void standbyLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (standbyLightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_annunSTANDBY_POWER_OFF = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_annunSTANDBY_POWER_OFF = false;
            }
        }

        private void gndPowerLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (gndPowerLightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_annunGRD_POWER_AVAILABLE = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_annunGRD_POWER_AVAILABLE = false;
            }
        }

        private void xferBus1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (xferBus1CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_annunTRANSFER_BUS_OFF_1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_annunTRANSFER_BUS_OFF_1 = false;
            }
        }

        private void xferBus2LightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (xferBus2LightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_annunTRANSFER_BUS_OFF_2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_annunTRANSFER_BUS_OFF_2 = false;
            }
        }

        private void acSourceLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (acSourceLightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_annunSOURCE_OFF_1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_annunSOURCE_OFF_1 = false;
            }
        }

        private void dcSourceLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (dcSourceLightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_annunSOURCE_OFF_2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_annunSOURCE_OFF_2 = false;
            }
        }

        private void genBus1LightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (genBus1LightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_annunGEN_BUS_OFF_1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_annunGEN_BUS_OFF_1 = false;
            }
        }

        private void genBus2LightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (genBus2LightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_annunGEN_BUS_OFF_2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_annunGEN_BUS_OFF_2 = false;
            }
        }

        private void apuGenBusLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (apuGenBusLightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ELEC_annunAPU_GEN_OFF_BUS = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ELEC_annunAPU_GEN_OFF_BUS = false;
            }
        }
    }
}
