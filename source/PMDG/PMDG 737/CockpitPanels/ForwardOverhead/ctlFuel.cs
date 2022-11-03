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

namespace tfm.PMDG.PMDG_737.CockpitPanels.ForwardOverhead
{
    public partial class ctlFuel : UserControl, iPanelsPage
    {
        private Timer fuelTimer = new Timer();
        private PanelObject[] fuelControls = PMDG737Aircraft.PanelControls.Where(x => x.PanelName == "Forward Overhead" && x.PanelSection == "Fuel").ToArray();

                        public ctlFuel()
        {
            InitializeComponent();
        }

        private void fuelTimerTick(object Sender, EventArgs eventArgs)
        {

            foreach(PanelObject control in fuelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.FUEL_FuelTempNeedle)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        var fuelTempOffset = (Offset<float>)toggle.Offset;
                        if (Properties.Settings.Default.UseMetric)
                        {
                            fuelTempTextBox.Text = Math.Round(fuelTempOffset.Value, 0).ToString();
                        }
                        else
                        {
                            var fuelTemp = (fuelTempOffset.Value * 9 / 5) + 32;
                            fuelTempTextBox.Text = Math.Round(fuelTemp, 0).ToString();
                        }
                    }
                                        }

                if(toggle.Offset == Aircraft.pmdg737.FUEL_PumpAftSw[0])
                {
                    leftAftPumpButton.Text = toggle.ToString();
                    leftAftPumpButton.AccessibleName = toggle.ToString();
                }

                if(toggle.Offset == Aircraft.pmdg737.FUEL_PumpAftSw[1])
                {
                    rightAftPumpButton.Text = toggle.ToString();
                    rightAftPumpButton.AccessibleName = toggle.ToString();
                }

                if(toggle.Offset == Aircraft.pmdg737.FUEL_AuxAft[0])
                {
                    aftAuxAButton.Text = toggle.ToString();
                    aftAuxAButton.AccessibleName = toggle.ToString();
                }

                if(toggle.Offset == Aircraft.pmdg737.FUEL_AuxAft[1])
                {
                    aftAuxBButton.Text = toggle.ToString();
                    aftAuxBButton.AccessibleName = toggle.ToString();
                }

                if(toggle.Offset == Aircraft.pmdg737.FUEL_AFTBleed)
                {
                    aftBleedButton.Text = toggle.ToString();
                    aftBleedButton.AccessibleName = toggle.ToString();
                }

                if(toggle.Offset == Aircraft.pmdg737.FUEL_annunLOWPRESS_Aft[0])
                {
                    aftLeftLowPressureTextBoxt.Text = toggle.CurrentState.Value;
                }
                if (toggle.Offset == Aircraft.pmdg737.FUEL_annunLOWPRESS_Aft[1])
                {
                    aftRightLowPressureTextBox.Text = toggle.CurrentState.Value;
                }

                if(toggle.Offset == Aircraft.pmdg737.FUEL_PumpFwdSw[0])
                {
                    leftFwdPumpButton.Text = toggle.ToString();
                    leftFwdPumpButton.AccessibleName = toggle.ToString();
                }

                if (toggle.Offset == Aircraft.pmdg737.FUEL_PumpFwdSw[1])
                {
                    rightFwdPumpButton.Text = toggle.ToString();
                    rightFwdPumpButton.AccessibleName = toggle.ToString();
                }

                if(toggle.Offset == Aircraft.pmdg737.FUEL_AuxFwd[0])
                {
                    fwdAuxAButton.Text = toggle.ToString();
                    fwdAuxAButton.AccessibleName = toggle.ToString();                        
                }

                if(toggle.Offset == Aircraft.pmdg737.FUEL_AuxFwd[1])
                {
                    fwdAuxBButton.Text = toggle.ToString();
                    fwdAuxBButton.AccessibleName = toggle.ToString();
                }

                if(toggle.Offset == Aircraft.pmdg737.FUEL_FWDBleed)
                {
                    fwdBleedButton.Text = toggle.ToString();
                    fwdBleedButton.AccessibleName = toggle.ToString();
                }

                if(toggle.Offset == Aircraft.pmdg737.FUEL_annunLOWPRESS_Fwd[0])
                {
                    leftFWDLowPressureTextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.FUEL_annunLOWPRESS_Fwd[1])
                {
                    rightFwdLowPressureTextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.FUEL_PumpCtrSw[0])
                {
                    leftCtrPumpButton.Text = toggle.ToString();
                    leftCtrPumpButton.AccessibleName = toggle.ToString();
                }

                    if (toggle.Offset == Aircraft.pmdg737.FUEL_PumpCtrSw[1])
                    {
                        rightCtrPumpButton.Text = toggle.ToString();
                        rightCtrPumpButton.AccessibleName = toggle.ToString();
                    }

                    if(toggle.Offset == Aircraft.pmdg737.FUEL_annunLOWPRESS_Ctr[0])
                    {
                        leftCtrLowPressureTextBox.Text = toggle.CurrentState.Value;
                    }

                    if (toggle.Offset == Aircraft.pmdg737.FUEL_annunLOWPRESS_Ctr[1])
                    {
                    rightCtrLowPressureTextBox.Text = toggle.CurrentState.Value;
                    }

                    if(toggle.Offset == Aircraft.pmdg737.FUEL_GNDXfr)
                {
                    gndXferButton.Text = toggle.ToString();
                    gndXferButton.AccessibleName = toggle.ToString();
                }

                    if(toggle.Offset == Aircraft.pmdg737.FUEL_CrossFeedSw)
                {
                    crossFeedButton.Text = toggle.ToString();
                    crossFeedButton.AccessibleName = toggle.ToString();
                }

                    if(toggle.Offset == Aircraft.pmdg737.FUEL_annunXFEED_VALVE_OPEN)
                {
                    crossFeedTextBox.Text = toggle.CurrentState.Value;
                }

                    if(toggle.Offset == Aircraft.pmdg737.FUEL_annunENG_VALVE_CLOSED[0])
                {
                    leftValveTextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.FUEL_annunENG_VALVE_CLOSED[1])
                {
                    rightValveTextBox.Text = toggle.CurrentState.Value;
                }

                if(toggle.Offset == Aircraft.pmdg737.FUEL_annunSPAR_VALVE_CLOSED[0])
                {
                    leftSparValveTextBox.Text = toggle.CurrentState.Value;
                }

                if(toggle.Offset == Aircraft.pmdg737.FUEL_annunSPAR_VALVE_CLOSED[1])
                {
                    rightSparValveTextBox.Text = toggle.CurrentState.Value;
                }

                if(toggle.Offset == Aircraft.pmdg737.FUEL_annunFILTER_BYPASS[0])
                {
                    leftFilterBypassTextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.FUEL_annunFILTER_BYPASS[1])
                {
                    rightFilterBypassTextBox.Text = toggle.CurrentState.Value;
                }
                            } // End loop.
        }

        public void SetDocking()
        {
                    }

        private void ctlFuel_Load(object sender, EventArgs e)
        {
            fuelTimer.Tick += new EventHandler(fuelTimerTick);
            fuelTimer.Start();
        }

        private void leftAftPumpButton_Click(object sender, EventArgs e)
        {

            var toggle = (SingleStateToggle) fuelControls.Where(x => x.Offset == Aircraft.pmdg737.FUEL_PumpAftSw[0]).ToArray()[0];

            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.LeftAftFuelPump(0);
            }
            else
            {
                PMDG737Aircraft.LeftAftFuelPump(1);
            }
        }

        private void rightAftPumpButton_Click(object sender, EventArgs e)
        {

            var toggle = (SingleStateToggle)fuelControls.Where(x => x.Offset == Aircraft.pmdg737.FUEL_PumpAftSw[1]).ToArray()[0];
            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.RightAftFuelPump(0);
            }
            else
            {
                PMDG737Aircraft.RightAftFuelPump(1);
            }
        }

        private void aftAuxAButton_Click(object sender, EventArgs e)
        {

            var toggle = (SingleStateToggle)fuelControls.Where(x => x.Offset == Aircraft.pmdg737.FUEL_AuxAft[0]).ToArray()[0];

            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.AftAuxFuelA(0);
            }
            else
            {
                PMDG737Aircraft.AftAuxFuelA(1);
            }
        }

        private void aftAuxBButton_Click(object sender, EventArgs e)
        {
            
            var toggle = (SingleStateToggle)fuelControls.Where(x => x.Offset == Aircraft.pmdg737.FUEL_AuxAft[1]).ToArray()[0];

            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.AftAuxFuelB(0);
            }
            else
            {
                PMDG737Aircraft.AftAuxFuelB(1);
            }
        }

        private void aftBleedButton_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle)fuelControls.Where(x => x.Offset == Aircraft.pmdg737.FUEL_AFTBleed).ToArray()[0];

            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.AftFuelBleed(0);
            }
            else
            {
                PMDG737Aircraft.AftFuelBleed(1);
            }
        }

        private void leftFwdPumpButton_Click(object sender, EventArgs e)
        {

            var toggle = (SingleStateToggle)fuelControls.Where(x => x.Offset == Aircraft.pmdg737.FUEL_PumpFwdSw[0]).ToArray()[0];

            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.LeftFwdFuelPump(0);
            }
            else
            {
                PMDG737Aircraft.LeftFwdFuelPump(1);
            }
        }

        private void rightFwdPumpButton_Click(object sender, EventArgs e)
        {

            var toggle = (SingleStateToggle)fuelControls.Where(x => x.Offset == Aircraft.pmdg737.FUEL_PumpFwdSw[1]).ToArray()[0];

            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.RightFwdFuelPump(0);
            }
            else
            {
                PMDG737Aircraft.RightFwdFuelPump(1);
            }
        }

        private void fwdAuxAButton_Click(object sender, EventArgs e)
        {

            var toggle = (SingleStateToggle)fuelControls.Where(x => x.Offset == Aircraft.pmdg737.FUEL_AuxFwd[0]).ToArray()[0];

            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.FwdAuxFuelA(0);
            }
            else
            {
                PMDG737Aircraft.FwdAuxFuelA(1);
            }
        }

        private void fwdAuxBButton_Click(object sender, EventArgs e)
        {

            var toggle = (SingleStateToggle)fuelControls.Where(x => x.Offset == Aircraft.pmdg737.FUEL_AuxFwd[1]).ToArray()[0];

            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.FwdAuxFuelB(0);
            }
            else
            {
                PMDG737Aircraft.FwdAuxFuelB(1);
            }
        }

        private void fwdBleedButton_Click(object sender, EventArgs e)
        {

            var toggle = (SingleStateToggle)fuelControls.Where(x => x.Offset == Aircraft.pmdg737.FUEL_FWDBleed).ToArray()[0];

            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.FwdFuelBleed(0);
            }
            else
            {
                PMDG737Aircraft.FwdFuelBleed(1);
            }
        }

        private void leftCtrPumpButton_Click(object sender, EventArgs e)
        {

            var toggle = (SingleStateToggle)fuelControls.Where(x => x.Offset == Aircraft.pmdg737.FUEL_PumpCtrSw[0]).ToArray()[0];

            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.LeftCenterFuelPump(0);
            }
            else
            {
                PMDG737Aircraft.LeftCenterFuelPump(1);
            }
        }

        private void rightCtrPumpButton_Click(object sender, EventArgs e)
        {

            var toggle = (SingleStateToggle)fuelControls.Where(x => x.Offset == Aircraft.pmdg737.FUEL_PumpCtrSw[1]).ToArray()[0];

            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.RightCenterFuelPump(0);
            }
            else
            {
                PMDG737Aircraft.RightCenterFuelPump(1);
            }
        }

        private void gndXferButton_Click(object sender, EventArgs e)
        {

            var toggle = (SingleStateToggle)fuelControls.Where(x => x.Offset == Aircraft.pmdg737.FUEL_GNDXfr).ToArray()[0];

            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.GroundFuelXfer(0);
            }
            else
            {
                PMDG737Aircraft.GroundFuelXfer(1);
            }
        }

        private void crossFeedButton_Click(object sender, EventArgs e)
        {

            var toggle = (SingleStateToggle)fuelControls.Where(x => x.Offset == Aircraft.pmdg737.FUEL_CrossFeedSw).ToArray()[0];

            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.CrossFeed(0);
            }
            else
            {
                PMDG737Aircraft.CrossFeed(1);
            }
        }

        private void ctlFuel_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                fuelTimer.Start();
            }
            else
            {
                fuelTimer.Stop();
            }

        }
    }
}
