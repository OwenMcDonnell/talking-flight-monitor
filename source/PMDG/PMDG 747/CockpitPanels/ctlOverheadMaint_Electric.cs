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

namespace tfm.PMDG.PMDG_747.CockpitPanels
{
    public partial class ctlOverheadMaint_Electric : UserControl, iPanelsPage
    {

        private System.Timers.Timer electricTimer = new System.Timers.Timer();
        public ctlOverheadMaint_Electric()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ElectricTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach(PanelObject control in PMDG747Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg747.ELEC_GenFieldReset[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        gen1ResetButton.Text = $"#1 {toggle.CurrentState.Value}";
                        gen1ResetButton.AccessibleName = $"#1 {toggle.CurrentState.Value}";
                    }
                } // Gen 1 reset.

                if(toggle.Offset == Aircraft.pmdg747.ELEC_GenFieldReset[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        gen2ResetButton.Text = $"#2 {toggle.CurrentState.Value}";
                        gen2ResetButton.AccessibleName = $"#2 {toggle.CurrentState.Value}";
                    }
                }

                if(toggle.Offset == Aircraft.pmdg747.ELEC_GenFieldReset[2])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        gen3ResetButton.Text = $"#3 {toggle.CurrentState.Value}";
                        gen3ResetButton.AccessibleName = $"#3 {toggle.CurrentState.Value}";
                    }
                } // Gen 3 reset.

                if(toggle.Offset == Aircraft.pmdg747.ELEC_GenFieldReset[3])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        gen4ResetButton.Text = $"#4 {toggle.CurrentState.Value}";
                        gen4ResetButton.AccessibleName = $"#4 {toggle.CurrentState.Value}";
                    }
                } // Gen 4 reset.

                if(toggle.Offset == Aircraft.pmdg747.ELEC_APUFieldReset[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        apu1FieldResetButton.Text = $"#1 {toggle.CurrentState.Value}";
                        apu1FieldResetButton.AccessibleName = $"#1 {toggle.CurrentState.Value}";
                    }
                } // APU 1 field reset.

                if(toggle.Offset == Aircraft.pmdg747.ELEC_APUFieldReset[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        apu2FieldResetButton.Text = $"#2 {toggle.CurrentState.Value}";
                        apu2FieldResetButton.AccessibleName = $"#2 {toggle.CurrentState.Value}";
                    }
                } // APU 2 field reset.

                if(toggle.Offset == Aircraft.pmdg747.ELEC_SplitSystemBreaker)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        splitSystemBreakerButton.Text = $"&Split sys brkr {toggle.CurrentState.Value}";
                        splitSystemBreakerButton.AccessibleName = $"Split system breaker {toggle.CurrentState.Value}";
                    }
                } // Split system breaker

                if(toggle.Offset == Aircraft.pmdg747.ELEC_annunGen_FIELD_OFF[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        gen1FieldTextBox.Text = toggle.CurrentState.Value;
                    }
                } // Gen 1 field light.

                if(toggle.Offset == Aircraft.pmdg747.ELEC_annunGen_FIELD_OFF[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        gen2FieldTextBox.Text = toggle.CurrentState.Value;
                    }
                } // Gen 2 field light.

                if(toggle.Offset == Aircraft.pmdg747.ELEC_annunGen_FIELD_OFF[2])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        gen3FieldTextBox.Text = toggle.CurrentState.Value;
                    }
                } // Gen 3 field light.

                if(toggle.Offset == Aircraft.pmdg747.ELEC_annunGen_FIELD_OFF[3])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        gen4FieldTextBox.Text = toggle.CurrentState.Value;
                    }
                } // Gen 4 field light.

                if(toggle.Offset == Aircraft.pmdg747.ELEC_annunAPU_FIELD_OFF[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        apu1FieldTextBox.Text = toggle.CurrentState.Value;
                    }
                } // APU 1 field light.

                if(toggle.Offset == Aircraft.pmdg747.ELEC_annunAPU_FIELD_OFF[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        apu2FieldTextBox.Text = toggle.CurrentState.Value;
                    }
                } // APU 2 field light.

                if(toggle.Offset == Aircraft.pmdg747.ELEC_annunSplitSystemBreaker_OPEN)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        splitSystemBreakerTextBox.Text = toggle.CurrentState.Value;
                    }
                } // Split system breaker light.
                                           } // loop
        } // ElectricTimerTick

        private void ctlOverheadMaint_Electric_Load(object sender, EventArgs e)
        {

            electricTimer.Elapsed += new System.Timers.ElapsedEventHandler(ElectricTimerTick);
            electricTimer.Start();
                        foreach (PanelObject control in PMDG747Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg747.ELEC_GenFieldReset[0])
                {
                                                                gen1ResetButton.Text = $"#1 {toggle.CurrentState.Value}";
                        gen1ResetButton.AccessibleName = $"#1 {toggle.CurrentState.Value}";
                                    } // Gen 1 reset.

                if (toggle.Offset == Aircraft.pmdg747.ELEC_GenFieldReset[1])
                {
                                            gen2ResetButton.Text = $"#2 {toggle.CurrentState.Value}";
                        gen2ResetButton.AccessibleName = $"#2 {toggle.CurrentState.Value}";
                } // Gen 2 reset.

                if (toggle.Offset == Aircraft.pmdg747.ELEC_GenFieldReset[2])
                {
                                                                gen3ResetButton.Text = $"#3 {toggle.CurrentState.Value}";
                        gen3ResetButton.AccessibleName = $"#3 {toggle.CurrentState.Value}";
                                    } // Gen 3 reset.

                if (toggle.Offset == Aircraft.pmdg747.ELEC_GenFieldReset[3])
                {
                                            gen4ResetButton.Text = $"#4 {toggle.CurrentState.Value}";
                        gen4ResetButton.AccessibleName = $"#4 {toggle.CurrentState.Value}";
                } // Gen 4 reset.

                if (toggle.Offset == Aircraft.pmdg747.ELEC_APUFieldReset[0])
                {
                                                                apu1FieldResetButton.Text = $"#1 {toggle.CurrentState.Value}";
                        apu1FieldResetButton.AccessibleName = $"#1 {toggle.CurrentState.Value}";
                                    } // APU 1 field reset.

                if(toggle.Offset == Aircraft.pmdg747.ELEC_APUFieldReset[1])
                {
                    apu2FieldResetButton.Text = $"#2 {toggle.CurrentState.Value}";
                    apu2FieldResetButton.AccessibleName = $"#2 {toggle.CurrentState.Value}";
                } // APU 2 field reset.

                if (toggle.Offset == Aircraft.pmdg747.ELEC_SplitSystemBreaker)
                {
                                            splitSystemBreakerButton.Text = $"&Split sys brkr {toggle.CurrentState.Value}";
                        splitSystemBreakerButton.AccessibleName = $"Split system breaker {toggle.CurrentState.Value}";
                } // Split system breaker

                if (toggle.Offset == Aircraft.pmdg747.ELEC_annunGen_FIELD_OFF[0])
                {
                                                                gen1FieldTextBox.Text = toggle.CurrentState.Value;
                                    } // Gen 1 field light.

                if (toggle.Offset == Aircraft.pmdg747.ELEC_annunGen_FIELD_OFF[1])
                {
                                            gen2FieldTextBox.Text = toggle.CurrentState.Value;
                } // Gen 2 field light.

                if (toggle.Offset == Aircraft.pmdg747.ELEC_annunGen_FIELD_OFF[2])
                {
                                                                gen3FieldTextBox.Text = toggle.CurrentState.Value;
                                    } // Gen 3 field light.

                if (toggle.Offset == Aircraft.pmdg747.ELEC_annunGen_FIELD_OFF[3])
                {
                                            gen4FieldTextBox.Text = toggle.CurrentState.Value;
                } // Gen 4 field light.

                if (toggle.Offset == Aircraft.pmdg747.ELEC_annunAPU_FIELD_OFF[0])
                {
                                                                apu1FieldTextBox.Text = toggle.CurrentState.Value;
                                    } // APU 1 field light.

                if (toggle.Offset == Aircraft.pmdg747.ELEC_annunAPU_FIELD_OFF[1])
                {
                                            apu2FieldTextBox.Text = toggle.CurrentState.Value;
                } // APU 2 field light.

                if (toggle.Offset == Aircraft.pmdg747.ELEC_annunSplitSystemBreaker_OPEN)
                {
                                                                splitSystemBreakerTextBox.Text = toggle.CurrentState.Value;
                                    } // Split system breaker light.
                                            } // loop

            if (PMDG747Aircraft.Is800 == false)
            {
                towingPwrButton.Visible = false;
            } // Towing power.

        }

        private void gen1ResetButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.Gen1ResetToggle();
        }

        private void gen2ResetButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.Gen2ResetToggle();
        }

        private void gen3ResetButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.Gen3ResetToggle();
        }

        private void gen4ResetButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.Gen4ResetToggle();
        }

        private void apu1FieldResetButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.APU1ResetToggle();
        }

        private void apu2FieldResetButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.APU2ResetToggle();
        }

        private void splitSystemBreakerButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.SplitSystemBreakerToggle();
        }

        private void groundPwrTestButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.GroundPowerTest();
        }

        private void towingPwrButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.TowingPower();
        }
    }
}
