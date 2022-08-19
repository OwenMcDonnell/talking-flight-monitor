using DavyKager;
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

namespace tfm.PMDG.PMDG_737.CockpitPanels.CenterOverhead
{
    public partial class ctlAirSystems : UserControl, iPanelsPage
    {
        Timer airSystemsTimer = new Timer();
        PanelObject[] controls = PMDG737Aircraft.PanelControls.Where(x => x.PanelName == "Center Overhead" && x.PanelSection == "Air Systems").ToArray();

        public ctlAirSystems()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void AirSystemsTimerTick(Object Sender, EventArgs eventArgs)
        {
            foreach (PanelObject control in controls)
            {
                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.AIR_TempSourceSelector)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        airSourceSelectorComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_TrimAirSwitch)
                {
                    airTrimButton.AccessibleName = toggle.ToString();
                    airTrimButton.Text = toggle.ToString();
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_annunZoneTemp[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        fltDckTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_annunZoneTemp[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        fwdZoneTempTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_annunZoneTemp[2])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        aftZoneTempTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_annunDualBleed)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        dualBleedTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_annunRamDoorL)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        ramDoorLTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_annunRamDoorR)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        ramDoorRTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_RecircFanSwitch[0])
                {
                    leftRecircFanButton.AccessibleName = toggle.ToString();
                    leftRecircFanButton.Text = toggle.ToString();
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_RecircFanSwitch[1])
                {
                    rightRecircFanButton.AccessibleName = toggle.ToString();
                    rightRecircFanButton.Text = toggle.ToString();
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_PackSwitch[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        packLComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_PackSwitch[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        packRComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_BleedAirSwitch[0])
                {
                    leftBleedButton.AccessibleName = toggle.ToString();
                    leftBleedButton.Text = toggle.ToString();
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_BleedAirSwitch[1])
                {
                    rightBleedButton.AccessibleName = toggle.ToString();
                    rightBleedButton.Text = toggle.ToString();
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_APUBleedAirSwitch)
                {
                    apuBleedButton.AccessibleName = toggle.ToString();
                    apuBleedButton.Text = toggle.ToString();
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_IsolationValveSwitch)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        isolationValveComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_annunPackTripOff[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftPackTripTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_annunPackTripOff[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightPackTripTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_annunWingBodyOverheat[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftWingOverheatTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_annunWingBodyOverheat[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightWingOverheatTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_annunBleedTripOff[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftBleedTripTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_annunBleedTripOff[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightBleedTripTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_DisplayFltAlt)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        fltAltTextBox.Text = toggle.Offset.GetValue<string>();
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_DisplayLandAlt)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        lndAltTextBox.Text = toggle.Offset.GetValue<string>();
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_OutflowValveSwitch)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        outFlowValveComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.AIR_PressurizationModeSelector)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        pressModeComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }
                }
            }

        }

        private void ctlAirSystems_Load(object sender, EventArgs e)
        {
            Tolk.Load();
            airSystemsTimer.Tick += new EventHandler(AirSystemsTimerTick);  
            airSystemsTimer.Start();
            foreach(PanelObject control in controls)
            {
                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.AIR_TempSourceSelector)
                {
                    airSourceSelectorComboBox.SelectedIndex = toggle.CurrentState.Key;
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_TrimAirSwitch)
                {
                    airTrimButton.AccessibleName = toggle.ToString();
                    airTrimButton.Text = toggle.ToString();
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_annunZoneTemp[0])
                {
                    fltDckTextBox.Text = toggle.CurrentState.Value;
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_annunZoneTemp[1])
                {
                    fwdZoneTempTextBox.Text = toggle.CurrentState.Value;
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_annunZoneTemp[2])
                {
                    aftZoneTempTextBox.Text = toggle.CurrentState.Value;
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_annunDualBleed)
                {
                    dualBleedTextBox.Text = toggle.CurrentState.Value;
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_annunRamDoorL)
                {
                    ramDoorLTextBox.Text = toggle.CurrentState.Value;
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_annunRamDoorR)
                {
                    ramDoorRTextBox.Text = toggle.CurrentState.Value;
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_RecircFanSwitch[0])
                {
                    leftRecircFanButton.AccessibleName = toggle.ToString();
                    leftRecircFanButton.Text = toggle.ToString();
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_RecircFanSwitch[1])
                {
                    rightRecircFanButton.AccessibleName = toggle.ToString();
                    rightRecircFanButton.Text = toggle.ToString();
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_PackSwitch[0])
                {
                    packLComboBox.SelectedIndex = toggle.CurrentState.Key;
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_PackSwitch[1])
                {
                    packRComboBox.SelectedIndex = toggle.CurrentState.Key;
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_BleedAirSwitch[0])
                {
                    leftBleedButton.AccessibleName = toggle.ToString();
                    leftBleedButton.Text = toggle.ToString();
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_BleedAirSwitch[1])
                {
                    rightBleedButton.AccessibleName = toggle.ToString();
                    rightBleedButton.Text = toggle.ToString();
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_APUBleedAirSwitch)
                {
                    apuBleedButton.AccessibleName = toggle.ToString();
                    apuBleedButton.Text = toggle.ToString();
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_IsolationValveSwitch)
                {
                    isolationValveComboBox.SelectedIndex = toggle.CurrentState.Key;
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_annunPackTripOff[0])
                {
                    leftPackTripTextBox.Text = toggle.CurrentState.Value;
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_annunPackTripOff[1])
                {
                    rightPackTripTextBox.Text = toggle.CurrentState.Value;
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_annunWingBodyOverheat[0])
                {
                    leftWingOverheatTextBox.Text = toggle.CurrentState.Value;
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_annunWingBodyOverheat[1])
                {
                    rightWingOverheatTextBox.Text = toggle.CurrentState.Value;
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_annunBleedTripOff[0])
                {
                    leftBleedTripTextBox.Text = toggle.CurrentState.Value;
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_annunBleedTripOff[1])
                {
                    rightBleedTripTextBox.Text = toggle.CurrentState.Value;
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_DisplayFltAlt)
                {
                    fltAltTextBox.Text = toggle.Offset.GetValue<string>();
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_DisplayLandAlt)
                {
                    lndAltTextBox.Text = toggle.Offset.GetValue<string>();
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_OutflowValveSwitch)
                {
                    outFlowValveComboBox.SelectedIndex = toggle.CurrentState.Key;
                }

                if(toggle.Offset == Aircraft.pmdg737.AIR_PressurizationModeSelector)
                {
                    pressModeComboBox.SelectedIndex = toggle.CurrentState.Key;
                }



            }
        } // end form load.

        private void fltAltTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if(e.KeyCode == Keys.Enter)
            {
                if(int.TryParse(fltAltTextBox.Text, out int altitude))
                {
                    PMDG737Aircraft.SetPressFltAlt(altitude);
                }
                else
                {
                    Tolk.Output("Cruising altitude is invalid.");
                }
            }
        }
    }
}
