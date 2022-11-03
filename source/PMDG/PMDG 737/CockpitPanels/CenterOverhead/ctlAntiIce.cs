using FSUIPC;
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
using FSUIPC;

namespace tfm.PMDG.PMDG_737.CockpitPanels.CenterOverhead
{
    public partial class ctlAntiIce : UserControl, iPanelsPage
    {

        private Timer antiIceTimer = new Timer();
        PanelObject[] antiIceControls = PMDG737Aircraft.PanelControls.Where(x => x.PanelName == "Center Overhead" && x.PanelSection == "Anti-ice").ToArray();

        public ctlAntiIce()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void AntiIceTimerTic(object Sender, EventArgs eventArgs)
        {
foreach(PanelObject control in antiIceControls)
            {

                // Left side window heat.
                if(control.Offset == Aircraft.pmdg737.ICE_WindowHeatSw[0])
                {
                    windowHeat1Button.Text = control.ToString();
                    windowHeat1Button.AccessibleName = control.ToString();
                }

                // Left forward window heat.
                if(control.Offset == Aircraft.pmdg737.ICE_WindowHeatSw[1])
                {
                    windowHeat2Button.Text = control.ToString();
                    windowHeat2Button.AccessibleName = control.ToString();
                }

                // Right forward window heat.
                if(control.Offset == Aircraft.pmdg737.ICE_WindowHeatSw[2])
                {
                    windowHeat3Button.Text = control.ToString();
                    windowHeat3Button.AccessibleName = control.ToString();
                }

                // Left side window heat.
                if(control.Offset == Aircraft.pmdg737.ICE_WindowHeatSw[3])
                {
                    windowHeat4Button.Text = control.ToString();
                    windowHeat4Button.AccessibleName = control.ToString();
                }

                // Window heat test.
                /* Leave out until can troubleshoot.
                if (FSUIPCConnection.ReadLVar("switch_137_73X") == 100)
                {
                    windowHeatTestButton.Text = "Window heat test off";
                    windowHeatTestButton.AccessibleName = "Window heat test off";
                }
                else
                {
                    windowHeatTestButton.Text = "Window heat test on";
                    windowHeatTestButton.AccessibleName = "Window heat test on";

                } */

                // Probe heat #1.
                if (FSUIPCConnection.ReadLVar("switch_140_73X") == 100)
                {
                    probeHeat1Button.Text = "Probe heat #1 on";
                    probeHeat1Button.AccessibleName = "Probe heat #1 on";
                }
                else
                {
                    probeHeat1Button.Text = "Probe heat #1 off";
                    probeHeat1Button.AccessibleName = "Probe heat #1 off";
                }

                // Probe heat #2.
                if (FSUIPCConnection.ReadLVar("switch_141_73X") == 100)
                {
                    probeHeat2Button.Text = "Probe heat #2 on";
                    probeHeat2Button.AccessibleName = "Probe heat #2 on";
                }
                else
                {
                    probeHeat2Button.Text = "Probe heat #2 off";
                    probeHeat2Button.AccessibleName = "Probe heat #2 off";
                }

                // Wing anti-ice
                if(control.Offset == Aircraft.pmdg737.ICE_WingAntiIceSw)
                {
                    wingAntiIceButton.Text = control.ToString();
                    wingAntiIceButton.AccessibleName = control.ToString();
                }

                // Engine #1 anti-ice
                if(control.Offset == Aircraft.pmdg737.ICE_EngAntiIceSw[0])
                {
                    engineHeat1Button.Text = control.ToString();
                    engineHeat1Button.AccessibleName = control.ToString();
                }

                // Engine #2 anti-ice
                if(control.Offset == Aircraft.pmdg737.ICE_EngAntiIceSw[1])
                {
                    engineHeat2Button.Text = control.ToString();
                    engineHeat2Button.AccessibleName = control.ToString();
                }

                // Left side window heat indicator.
                if(control.Offset == Aircraft.pmdg737.ICE_annunON[0])
                {
                    var windowHeat1Indicator = (SingleStateToggle)control;
                    windowHeat1TextBox.Text = windowHeat1Indicator.CurrentState.Value;
                }

                // Left forward window heat indicator.
                if(control.Offset == Aircraft.pmdg737.ICE_annunON[1])
                {
                    var windowHeat2indicator = (SingleStateToggle)control;
                    windowHeat2TextBox.Text = windowHeat2indicator.CurrentState.Value;
                }

                // /Right forward window heat indicator.
                if(control.Offset == Aircraft.pmdg737.ICE_annunON[2])
                {

                    var windowHeat3Indicator = (SingleStateToggle)control;
                    windowHeat3TextBox.Text = windowHeat3Indicator.CurrentState.Value;
                }

                // Right side window heat indicator.
                if(control.Offset == Aircraft.pmdg737.ICE_annunON[3])
                {
                    var windowHeat4Indicator = (SingleStateToggle)control;
                    windowHeat4TextBox.Text = windowHeat4Indicator.CurrentState.Value;
                }

                // Left side window overheat indicator.
                if(control.Offset == Aircraft.pmdg737.ICE_annunOVERHEAT[0])
                {
                    var overheat1Indicator = (SingleStateToggle)control;
                    overHeat1TextBox.Text = overheat1Indicator.CurrentState.Value;
                }

                // Left forward window overheat indicator.
                if(control.Offset == Aircraft.pmdg737.ICE_annunOVERHEAT[1])
                {

                    var overheat2Indicator = (SingleStateToggle)control;
                    overheat2TextBox.Text = overheat2Indicator.CurrentState.Value;
                }

                // Right forward window overheat indicator.
                if(control.Offset == Aircraft.pmdg737.ICE_annunOVERHEAT[2])
                {

                    var overheat3Indicator = (SingleStateToggle)control;
                    overheat3TextBox.Text = overheat3Indicator.CurrentState.Value;
                }

                // Right side window overheat indicator.
                if(control.Offset == Aircraft.pmdg737.ICE_annunOVERHEAT[3])
                {

                    var overheat4Indicator = (SingleStateToggle)control;
                    overheat4TextBox.Text = overheat4Indicator.CurrentState.Value;
                }

                // Captain's pitot heat indicator.
                if(control.Offset == Aircraft.pmdg737.ICE_annunCAPT_PITOT)
                {

                    var captPitotIndicator = (SingleStateToggle)control;
                    captPitotTextBox.Text = captPitotIndicator.CurrentState.Value;
                }

                // Left elevator pitot heat indicator.
                if(control.Offset == Aircraft.pmdg737.ICE_annunL_ELEV_PITOT)
                {

                    var leftElevatorIndicator = (SingleStateToggle)control;
                    leftElevTextBox.Text = leftElevatorIndicator.CurrentState.Value;
                }

                // Left alpha vane indicator
                if(control.Offset == Aircraft.pmdg737.ICE_annunL_ALPHA_VANE)
                {

                    var leftAlphaIndicator = (SingleStateToggle)control;
                    leftAlphaTextBox.Text = leftAlphaIndicator.CurrentState.Value;
                }

                // Temp probe.
                if(control.Offset == Aircraft.pmdg737.ICE_annunL_TEMP_PROBE)
                {

                    var tempProbeIndicator = (SingleStateToggle)control;
                    tempProbeTextBox.Text = tempProbeIndicator.CurrentState.Value;
                }

                // F/O pitot heat indicator.
                if(control.Offset == Aircraft.pmdg737.ICE_annunFO_PITOT)
                {
                    var tempProbeIndicator = (SingleStateToggle)control;
                                        foPitotTextBox.Text = tempProbeIndicator.CurrentState.Value;
                }

                // Right elevator pitot heat indicator.
                if(control.Offset == Aircraft.pmdg737.ICE_annunR_ELEV_PITOT)
                {

                    var rightElevatorIndicator = (SingleStateToggle)control;
                    rightElevTextBox.Text = rightElevatorIndicator.CurrentState.Value;
                }

                // Right alpha vane indicator.
                if(control.Offset == Aircraft.pmdg737.ICE_annunR_ALPHA_VANE)
                {

                    var rightAlphaIndicator = (SingleStateToggle)control;
                    rAlphaTextBox.Text = rightAlphaIndicator.CurrentState.Value;
                }

                // AUX pitot heat indicator.
                if(control.Offset == Aircraft.pmdg737.ICE_annunAUX_PITOT)
                {

                    var auxPitotIndicator = (SingleStateToggle)control;
                    auxPitotTextBox.Text = auxPitotIndicator.CurrentState.Value;
                }

                // Anti-ice valve #1.
                if(control.Offset == Aircraft.pmdg737.ICE_annunVALVE_OPEN[0])
                {

                    var valve1Indicator = (SingleStateToggle)control;
                    valve1TextBox.Text = valve1Indicator.CurrentState.Value;
                }

                // Anti-ice valve #2.
                if(control.Offset == Aircraft.pmdg737.ICE_annunVALVE_OPEN[1])
                {

                    var valve2Indicator = (SingleStateToggle)control;
                    valve2TextBox.Text = valve2Indicator.CurrentState.Value;
                }

                // Cowl anti-ice #1 indicator.
                if(control.Offset == Aircraft.pmdg737.ICE_annunCOWL_ANTI_ICE[0])
                {

                    var cowlAntiIce1Indicator = (SingleStateToggle)control;
                    cowlAntiIce1TextBox.Text = cowlAntiIce1Indicator.CurrentState.Value;
                }

                // Cowl anti-ice #2 indicator.
                if(control.Offset == Aircraft.pmdg737.ICE_annunCOWL_ANTI_ICE[1])
                {

                    var cowlAntiIce2Indicator = (SingleStateToggle)control;
                    cowlAntiIce2TextBox.Text = cowlAntiIce2Indicator.CurrentState.Value;
                }

                // Cowl valve #1.
                if(control.Offset == Aircraft.pmdg737.ICE_annunCOWL_VALVE_OPEN[0])
                {

                    var cowlValve1Indicator = (SingleStateToggle)control;
                    cowlValve1TextBox.Text = cowlValve1Indicator.CurrentState.Value;
                }

                // Cowl valve #2 indicator.
                if(control.Offset == Aircraft.pmdg737.ICE_annunCOWL_VALVE_OPEN[1])
                {

                    var cowlValve2Indicator = (SingleStateToggle)control;
                    cowlValve2TextBox.Text = cowlValve2Indicator.CurrentState.Value;
                }
                            } // end-loop
        }

        private void ctlAntiIce_Load(object sender, EventArgs e)
        {
            antiIceTimer.Tick += new EventHandler(AntiIceTimerTic);
            antiIceTimer.Interval = 300;
            antiIceTimer.Start();
        }

        private void windowHeat1Button_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.LeftSideWindowHeatToggle();       }

        private void windowHeat2Button_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.LeftForwardWindowHeatToggle();
        }

        private void windowHeat3Button_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.RightForwardWindowHeatToggle();
        }

        private void windowHeat4Button_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.RightSideWindowHeatToggle();
        }

        private void overHeatTestButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.    WindowOverHeatTest();
        }

        private void probeHeat1Button_Click(object sender, EventArgs e)
        {
            if (FSUIPCConnection.ReadLVar("switch_140_73X") == 100)
            {
                                PMDG737Aircraft.LeftProbeHeatOn();
            }
            else
            {
                PMDG737Aircraft.LeftProbeHeatOff();
            }
        }

        private void probeHeat2Button_Click(object sender, EventArgs e)
        {
            if (FSUIPCConnection.ReadLVar("switch_141_73X") == 100)
            {
                PMDG737Aircraft.RightProbeHeatOn();
            }
            else
            {
                PMDG737Aircraft.RightProbeHeatOff();
            }
        }

        private void wingAntiIceButton_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle)antiIceControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_WingAntiIceSw).ToArray()[0];

            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.WingAntiIceOff();
            }
            else
            {
                PMDG737Aircraft.WingAntiIceOn();
            }
        }

        private void engineHeat1Button_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle)antiIceControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_EngAntiIceSw[0]).ToArray()[0];

            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.Engine1AntiIceOff();
            }
            else
            {
                PMDG737Aircraft.Engine1AntiIceOn();
            }
        }

        private void engineHeat2Button_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle)antiIceControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_EngAntiIceSw[1]).ToArray()[0];

            if (toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.Engine2AntiIceOff();
            }
            else
            {
                PMDG737Aircraft.Engine2AntiIceOn();
            }

        }

        private void ctlAntiIce_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                antiIceTimer.Start();
            }
            else
            {
                antiIceTimer.Stop();
            }

        }
    }
}
