using DavyKager;
using tfm.PMDG.PanelObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.PMDG.PMDG_737.CockpitPanels.ForwardOverhead
{
    public partial class ctlFlightControls : UserControl, iPanelsPage
    {

        System.Timers.Timer flightControlsTimer = new System.Timers.Timer();
        private PanelObject[] flightControls = PMDG737Aircraft.PanelControls.Where(x => x.PanelName == "Forward Overhead" && x.PanelSection == "Flight controls").ToArray();

        public ctlFlightControls()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void flightControlsTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach(PanelObject control in flightControls)
            {
                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.FCTL_FltControl_Sw[0])
                {
                    controlAComboBox.SelectedIndex = toggle.CurrentState.Key;
                                    } // FC A.
                if(toggle.Offset == Aircraft.pmdg737.FCTL_FltControl_Sw[1])
                {
                    controlBComboBox.SelectedIndex = toggle.CurrentState.Key;
                                    } // FC B.
                if(toggle.Offset == Aircraft.pmdg737.FCTL_Spoiler_Sw[0])
                {
                    leftSpoilerButton.Text = $"S&poilers A {toggle.CurrentState.Value}";
                    leftSpoilerButton.AccessibleName = toggle.ToString();
                } // left spoilers.
                if(toggle.Offset == Aircraft.pmdg737.FCTL_Spoiler_Sw[1])
                {
                    rightSpoilerButton.Text = $"Sp&oilers B {toggle.CurrentState.Value}";
                    rightSpoilerButton.AccessibleName = toggle.ToString();
                } // right spoiler.
                if (toggle.Offset == Aircraft.pmdg737.FCTL_YawDamper_Sw)
                {
                    yawDamperButton.Text = $"&{toggle}";
                    yawDamperButton.AccessibleName = toggle.ToString();
                } // Yaw damper.
                if(toggle.Offset == Aircraft.pmdg737.FCTL_AltnFlaps_Sw_ARM)
                {
                    altFlapArmButton.Text = $"Alter&nate flaps [armed] {toggle.CurrentState.Value}";
                    altFlapArmButton.AccessibleName = toggle.ToString();
                }// Alternate flap armed button.
                if(toggle.Offset == Aircraft.pmdg737.FCTL_AltnFlaps_Control_Sw)
                {
                    altnFlapsComboBox.SelectedIndex = toggle.CurrentState.Key;
                                    } // Alternate flaps extension button.
                if(toggle.Offset == Aircraft.pmdg737.FCTL_annunFC_LOW_PRESSURE[0])
                {
                    aLowPressureLightTextBox.Text = toggle.CurrentState.Value;
                } // A low pressure light.
                if(toggle.Offset == Aircraft.pmdg737.FCTL_annunFC_LOW_PRESSURE[1])
                {
                    bLowPressureLightTextBox.Text = toggle.CurrentState.Value;
                } // B low pressure light.
                if(toggle.Offset == Aircraft.pmdg737.FCTL_annunYAW_DAMPER)
                {
                    yawDamperLightTextBox.Text = toggle.CurrentState.Value;
                } // Yaw damper light.
                if(toggle.Offset == Aircraft.pmdg737.FCTL_annunLOW_QUANTITY)
                {
                    lowQuantityLightTextBox.Text = toggle.CurrentState.Value;
                } // low quantity light.
                if(toggle.Offset == Aircraft.pmdg737.FCTL_annunLOW_PRESSURE)
                {
                    lowPressureTextBox.Text = toggle.CurrentState.Value;
                } // Low pressure light.
                if(toggle.Offset == Aircraft.pmdg737.FCTL_annunLOW_STBY_RUD_ON)
                {
                    standbyLightTextBox.Text = toggle.CurrentState.Value;
                } // Standby light.
                if(toggle.Offset == Aircraft.pmdg737.FCTL_annunFEEL_DIFF_PRESS)
                {
                    feelDifLightTextBox.Text = toggle.CurrentState.Value;
                } // Feel dif light.
                if(toggle.Offset == Aircraft.pmdg737.FCTL_annunSPEED_TRIM_FAIL)
                {
                    speedTrimFailLightTextBox.Text = toggle.CurrentState.Value;
                } // Speed trim fail light.
                if(toggle.Offset == Aircraft.pmdg737.FCTL_annunMACH_TRIM_FAIL)
                {
                    machTrimFailLightTextBox.Text = toggle.CurrentState.Value;
                } // Mach trim fail light.
                if(toggle.Offset == Aircraft.pmdg737.FCTL_annunAUTO_SLAT_FAIL)
                {
                    autoSlatFailLightTextBox.Text = toggle.CurrentState.Value;
                } // Auto slat fail light.


                            } // End loop.
        }

        private void ctlFlightControls_Load(object sender, EventArgs e)
        {
            flightControlsTimer.Elapsed += new System.Timers.ElapsedEventHandler(flightControlsTimerTick);
            flightControlsTimer.Interval = 300;
            flightControlsTimer.Start();
            Tolk.Load();

        }

        private void controlAComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Properties.pmdg737_offsets.Default.FCTL_FltControl_Sw_1 == false)
            {
                if(Tolk.DetectScreenReader() == "NVDA")
                {
                    Tolk.Output(controlAComboBox.SelectedItem.ToString());
                                    }
            }
                                    PMDG737Aircraft.FlightControlA(controlAComboBox.SelectedIndex);
        }

        private void controlBComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Properties.pmdg737_offsets.Default.FCTL_FltControl_Sw_2 == false)
            {
                if (Tolk.DetectScreenReader() == "NVDA")
                {
                                        Tolk.Output(controlBComboBox.SelectedItem.ToString());
                }
            }

            PMDG737Aircraft.FlightControlB(controlBComboBox.SelectedIndex);
        }

        private void leftSpoilerButton_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle)PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.FCTL_Spoiler_Sw[0]).ToArray()[0];
            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.SpoilerA(0);
            }
            else
            {
                PMDG737Aircraft.SpoilerA(1);
            }
        }

        private void rightSpoilerButton_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle)PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.FCTL_Spoiler_Sw[1]).ToArray()[0];
            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.SpoilerB(0);
            }
            else
            {
                PMDG737Aircraft.SpoilerB(1);
            }
        }

        private void yawDamperButton_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle)flightControls.Where(x => x.Offset == Aircraft.pmdg737.FCTL_YawDamper_Sw).ToArray()[0];
            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.YawDamper(0);
            }
            else
            {
                PMDG737Aircraft.YawDamper(1);
            }
        }

        private void altFlapArmButton_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle)flightControls.Where(x => x.Offset == Aircraft.pmdg737.FCTL_AltnFlaps_Sw_ARM).ToArray()[0];
            if(toggle.CurrentState.Value == "armed")
            {
                PMDG737Aircraft.AlternateFlapsArm(0);
            }
            else
            {
                PMDG737Aircraft.AlternateFlapsArm(1);
            }
        }

        private void altnFlapsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Properties.pmdg737_offsets.Default.FCTL_AltnFlaps_Control_Sw == false)
            {
                if(Tolk.DetectScreenReader() == "NVDA")
                {
                    Tolk.Output(altnFlapsComboBox.SelectedItem.ToString());
                }
            }
            PMDG737Aircraft.AlternatFlapsPosition(altnFlapsComboBox.SelectedIndex);
        }

        private void ctlFlightControls_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                flightControlsTimer.Start();
            }
            else
            {
                flightControlsTimer.Stop();
            }

        }
    }
}
