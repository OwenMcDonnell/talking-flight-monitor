using FSUIPC;
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

namespace tfm.PMDG.PMDG_737.CockpitPanels.CenterOverhead
{
    public partial class ctlCenterMain : UserControl, iPanelsPage
    {

        private Timer mainTimer = new Timer();
        private PanelObject[] mainControls = PMDG737Aircraft.PanelControls.Where(x => x.PanelName == "Center Overhead" && x.PanelSection == "Main").ToArray();
        public ctlCenterMain()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
        }

        private void MainTimerTick(object Sender, EventArgs eventArgs)
        {
            foreach (PanelObject control in mainControls)
            {
                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.LTS_CircuitBreakerKnob)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        Offset<byte> offset = (Offset<byte>)toggle.Offset;
                        breakerTextBox.Text = offset.Value.ToString();

                    }
                }// breaker

                if (toggle.Offset == Aircraft.pmdg737.LTS_OvereadPanelKnob)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        Offset<byte> offset = (Offset<byte>)toggle.Offset;
                        overheadKnobTextBox.Text = offset.Value.ToString();
                    }
                } // panel knob

                if (toggle.Offset == Aircraft.pmdg737.LTS_EmerExitSelector)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        emergencyExitSelectorComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }
                } // emergency exit lights

                if (toggle.Offset == Aircraft.pmdg737.AIR_EquipCoolingSupplyNORM)
                {
                    equipCoolSpplyButton.Text = $"Equip. cool s&upp. {toggle.CurrentState.Value}";
                    equipCoolSpplyButton.AccessibleName = toggle.ToString();
                } // Equip. cooling supply.

                if (toggle.Offset == Aircraft.pmdg737.AIR_EquipCoolingExhaustNORM)
                {
                    coolExhaustButton.Text = $"Equip. cool e&xhst. {toggle.CurrentState.Value}";
                    coolExhaustButton.AccessibleName = toggle.ToString();
                } // exhaust.

                if (toggle.Offset == Aircraft.pmdg737.COMM_NoSmokingSelector)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        chimesComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }
                } // no smoking

                if (toggle.Offset == Aircraft.pmdg737.COMM_FastenBeltsSelector)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        seatBeltComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }
                } // seatbelts

                if (toggle.Offset == Aircraft.pmdg737.LTS_annunEmerNOT_ARMED)
                {
                    emergencyExitNotArmedTextBox.Text = toggle.CurrentState.Value;
                }// emergency exit lts indicator

                if (toggle.Offset == Aircraft.pmdg737.AIR_annunEquipCoolingSupplyOFF)
                {
                    equipCoolSpplyTextBox.Text = toggle.CurrentState.Value;
                } // equip. supply

                if (toggle.Offset == Aircraft.pmdg737.AIR_annunEquipCoolingExhaustOFF)
                {
                    equipCoolExhaustTextBox.Text = toggle.CurrentState.Value;
                } // equip. exhaust

                if (toggle.Offset == Aircraft.pmdg737.COMM_annunCALL)
                {
                    callTextBox.Text = toggle.CurrentState.Value;
                } // call

                if (toggle.Offset == Aircraft.pmdg737.COMM_annunPA_IN_USE)
                {
                    paTextBox.Text = toggle.CurrentState.Value;
                } // PA
            }// End loop
        }

        private void ctlCenterMain_Load(object sender, EventArgs e)
        {
            mainTimer.Tick += new EventHandler(MainTimerTick);
            mainTimer.Start();
            Tolk.Load();
            foreach (PanelObject control in mainControls)
            {
                var toggle = (SingleStateToggle)control;
                if (toggle.Offset == Aircraft.pmdg737.LTS_CircuitBreakerKnob)
                {
                    Offset<byte> offset = (Offset<byte>)toggle.Offset;
                    breakerTextBox.Text = offset.Value.ToString();
                    breakerTextBox.DeselectAll();
                } // breaker

                if (toggle.Offset == Aircraft.pmdg737.LTS_OvereadPanelKnob)
                {
                    Offset<byte> offset = (Offset<byte>)toggle.Offset;
                    overheadKnobTextBox.Text = offset.Value.ToString();
                    overheadKnobTextBox.DeselectAll();
                } // overhead panel knob.

                if (toggle.Offset == Aircraft.pmdg737.LTS_EmerExitSelector)
                {
                    emergencyExitSelectorComboBox.SelectedIndex = toggle.CurrentState.Key;
                } // emergency light selector.

                if (toggle.Offset == Aircraft.pmdg737.COMM_NoSmokingSelector)
                {
                    chimesComboBox.SelectedIndex = toggle.CurrentState.Key;
                } // no smoking

                if (toggle.Offset == Aircraft.pmdg737.COMM_FastenBeltsSelector)
                {
                    seatBeltComboBox.SelectedIndex = toggle.CurrentState.Key;
                } // seatbelts

            } // end load loop
        }

        private void emergencyExitSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Properties.pmdg737_offsets.Default.LTS_EmerExitSelector == false)
            {
                if (Tolk.DetectScreenReader() == "NVDA")
                {
                    Tolk.Output(emergencyExitSelectorComboBox.SelectedItem.ToString());
                }
            }
            PMDG737Aircraft.EmergencyLightSelector(emergencyExitSelectorComboBox.SelectedIndex);
        }

        private void equipCoolSpplyButton_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle)mainControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_EquipCoolingSupplyNORM).ToArray()[0];
            if (toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.AirEquipCoolingSupply(0);
            }
            else
            {
                PMDG737Aircraft.AirEquipCoolingSupply(1);
            }

        }

        private void coolExhaustButton_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle)mainControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_EquipCoolingExhaustNORM).ToArray()[0];
            if (toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.AirEquipCoolingExhaust(0);
            }
            else
            {
                PMDG737Aircraft.AirEquipCoolingExhaust(1);
            }
        }

        private void chimesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Properties.pmdg737_offsets.Default.COMM_NoSmokingSelector == false)
            {
                if (Tolk.DetectScreenReader() == "NVDA")
                {
                    Tolk.Output(chimesComboBox.SelectedItem.ToString());
                }
            }
            PMDG737Aircraft.NoSmokingSelector(chimesComboBox.SelectedIndex);
        }

        private void seatBeltComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Properties.pmdg737_offsets.Default.COMM_FastenBeltsSelector == false)
            {
                if (Tolk.DetectScreenReader() == "NVDA")
                {
                    Tolk.Output(seatBeltComboBox.SelectedItem.ToString());
                }
            }

            PMDG737Aircraft.SeatBeltSelector(seatBeltComboBox.SelectedIndex);
        }

        private void breakerTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.I)
            {
                PMDG737Aircraft.CircuttBreakerLightIncrease();
                breakerTextBox.Refresh();
            } // increase
            if (e.KeyCode == Keys.D)
            {
                PMDG737Aircraft.CircuttBreakerLightDecrease();
                breakerTextBox.Refresh();
            } // decrease
        }

        private void overheadKnobTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.I)
            {
                PMDG737Aircraft.OverheadPanelLightIncrease();
                overheadKnobTextBox.Refresh();
            } // increase

            if (e.KeyCode == Keys.D)
            {
                PMDG737Aircraft.OverheadPanelLightDecrease();
                overheadKnobTextBox.Refresh();
            } // decrease
        }

        private void breakerTextBox_Enter(object sender, EventArgs e)
        {
            breakerTextBox.Select(0, 0);
        }

        private void overheadKnobTextBox_Enter(object sender, EventArgs e)
        {
            overheadKnobTextBox.Select(0, 0);
        }
    }
}
