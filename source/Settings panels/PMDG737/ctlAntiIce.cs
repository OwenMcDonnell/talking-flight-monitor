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
    public partial class ctlAntiIce : UserControl, iSettingsPage
    {
        public ctlAntiIce()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlAntiIce_Load(object sender, EventArgs e)
        {
            windowHeat1CheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_WindowHeatSw1;
            windowHeat2CheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_WindowHeatSw2;
            windowHeat3CheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_WindowHeatSw3;
            windowHeat4CheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_WindowHeatSw4;
            wingAntiIceCheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_WingAntiIceSw;
            engine1AntiIceCheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_EngAntiIceSw1;
            engine2AntiIceCheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_EngAntiIceSw2;
            windowHeat1IndicatorCheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_annunON1;
            windowHeat2IndicatorCheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_annunON2;
            windowHeat3IndicatorCheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_annunON3;
            windowHeat4IndicatorCheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_annunON4;
            overHeat1CheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_annunOVERHEAT1;
            overHeat2CheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_annunOVERHEAT2;
            overHeat3CheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_annunOVERHEAT3;
            overHeat4CheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_annunOVERHEAT4;
            captainProbeHeatCheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_annunCAPT_PITOT;
            leftElevatorPitotCheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_annunL_ELEV_PITOT;
            lAlphaCheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_annunL_ALPHA_VANE;
            leftTempProbeCheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_annunL_TEMP_PROBE;
            foProbeHeatIndicatorCheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_annunFO_PITOT;
            rightElevatorPitotCheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_annunR_ELEV_PITOT;
            rightAlphaCheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_annunR_ALPHA_VANE;
            auxPitotCheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_annunAUX_PITOT;
            valve1CheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_annunVALVE_OPEN1;
            valve2CheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_annunVALVE_OPEN2;
            cowlAntiIce1CheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_annunCOWL_ANTI_ICE1;
            cowl2AntiIceCheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_annunCOWL_ANTI_ICE2;
            cowlValve1CheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_annunCOWL_VALVE_OPEN1;
            cowlValve2CheckBox.Checked = Properties.pmdg737_offsets.Default.ICE_annunCOWL_VALVE_OPEN2;
        }

        private void windowHeat1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (windowHeat1CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_WindowHeatSw1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_WindowHeatSw1 = false;
            }
        }

        private void windowHeat2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (windowHeat2CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_WindowHeatSw2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_WindowHeatSw2 = false;
            }
        }

        private void windowHeat3CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (windowHeat3CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_WindowHeatSw3 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_WindowHeatSw3 = false;
            }
        }

        private void windowHeat4CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (windowHeat4CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_WindowHeatSw4 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_WindowHeatSw4 = false;
            }
        }

        private void wingAntiIceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (wingAntiIceCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_WingAntiIceSw = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_WingAntiIceSw = false;
            }
        }

        private void engine1AntiIceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (engine1AntiIceCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_EngAntiIceSw1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_EngAntiIceSw1 = false;
            }
        }

        private void engine2AntiIceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (engine2AntiIceCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_EngAntiIceSw2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_EngAntiIceSw2 = false;
            }
        }

        private void windowHeat1IndicatorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (windowHeat1IndicatorCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_annunON1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_annunON1 = false;
            }
        }

        private void windowHeat2IndicatorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (windowHeat2IndicatorCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_annunON2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_annunON2 = false;
            }
        }

        private void windowHeat3IndicatorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (windowHeat3IndicatorCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_annunON3 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_annunON3 = false;
            }
        }

        private void windowHeat4IndicatorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (windowHeat4IndicatorCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_annunON4 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_annunON4 = false;
            }
        }

        private void overHeat1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (overHeat1CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_annunOVERHEAT1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_annunOVERHEAT1 = false;
            }
        }

        private void overHeat2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (overHeat2CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_annunOVERHEAT2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_annunOVERHEAT1 = false;
            }
        }

        private void overHeat3CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (overHeat3CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_annunOVERHEAT3 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_annunOVERHEAT3 = false;
            }
        }

        private void overHeat4CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (overHeat4CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_annunOVERHEAT4 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_annunOVERHEAT4 = false;
            }
        }

        private void captainProbeHeatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (captainProbeHeatCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_annunCAPT_PITOT = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_annunCAPT_PITOT = false;
            }
        }

        private void leftElevatorPitotCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leftElevatorPitotCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_annunL_ELEV_PITOT = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_annunL_ELEV_PITOT = false;
            }
        }

        private void lAlphaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (lAlphaCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_annunL_ALPHA_VANE = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_annunL_ALPHA_VANE = false;
            }
        }

        private void leftTempProbeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leftTempProbeCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_annunL_TEMP_PROBE = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_annunL_TEMP_PROBE = false;
            }
        }

        private void foProbeHeatIndicatorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (foProbeHeatIndicatorCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_annunFO_PITOT = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_annunFO_PITOT = false;
            }
        }

        private void rightElevatorPitotCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightElevatorPitotCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_annunR_ELEV_PITOT = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_annunR_ELEV_PITOT = false;
            }
        }

        private void rightAlphaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rightAlphaCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_annunR_ALPHA_VANE = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_annunR_ALPHA_VANE = false;
            }
        }

        private void auxPitotCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (auxPitotCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_annunAUX_PITOT = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_annunAUX_PITOT = false;
            }
        }

        private void valve1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (valve1CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_annunVALVE_OPEN1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_annunVALVE_OPEN1 = false;
            }
        }

        private void valve2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (valve2CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_annunVALVE_OPEN2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_annunVALVE_OPEN2 = false;
            }
        }

        private void cowlAntiIce1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (cowlAntiIce1CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_annunCOWL_ANTI_ICE1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_annunCOWL_ANTI_ICE1 = false;
            }
        }

        private void cowl2AntiIceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (cowl2AntiIceCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_annunCOWL_ANTI_ICE2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_annunCOWL_ANTI_ICE2 = false;
            }
        }

        private void cowlValve1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (cowlValve1CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_annunCOWL_VALVE_OPEN1 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_annunCOWL_VALVE_OPEN1 = false;
            }
        }

        private void cowlValve2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (cowlValve2CheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.ICE_annunCOWL_VALVE_OPEN2 = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.ICE_annunCOWL_VALVE_OPEN2 = false;
            }
        }
    }
}
