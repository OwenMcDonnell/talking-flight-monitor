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

namespace tfm.PMDG.PMDG_737.CockpitPanels.BottomOverhead
{
    public partial class ctlEngines : UserControl, iPanelsPage
    {

        private Timer enginesTimer = new Timer();
        PanelObject[] controls = PMDG737Aircraft.PanelControls.Where(x => x.PanelName == "Bottom Overhead" && x.PanelSection == "Engines").ToArray();

        public ctlEngines()
        {
            InitializeComponent();
        }


        private void EnginesTimerTick(object Sender, EventArgs eventArgs)
        {
            foreach (PanelObject control in controls)
            {
                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.APU_Selector)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        apuSelectorComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.ENG_StartSelector[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        engine1SelectorComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.ENG_StartSelector[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        engine2SelectorComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.ENG_IgnitionSelector)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        ignitionSelectorComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }
                }

                if (FSUIPCConnection.ReadLVar("switch_688_73X") == 0)
                {
                    engFuel1ComboBox.SelectedIndex = 0;
                }
                else
                {
                    engFuel1ComboBox.SelectedIndex = 1;
                }

                if (FSUIPCConnection.ReadLVar("switch_689_73X") == 0)
                {
                    engFuel2ComboBox.SelectedIndex = 0;
                }
                else
                {
                    engFuel2ComboBox.SelectedIndex = 1;
                }
            }

        }

        public void SetDocking()
        {
                    }

        private void ctlEngines_Load(object sender, EventArgs e)
        {
            enginesTimer.Tick += new EventHandler(EnginesTimerTick);
            enginesTimer.Start();


            foreach(PanelObject control in controls)
            {
                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.APU_Selector)
                {
                    apuSelectorComboBox.SelectedIndex = toggle.CurrentState.Key;
                }

                if(toggle.Offset == Aircraft.pmdg737.ENG_StartSelector[0])
                {
                    engine1SelectorComboBox.SelectedIndex = toggle.CurrentState.Key;
                }

                if(toggle.Offset == Aircraft.pmdg737.ENG_StartSelector[1])
                {
                    engine2SelectorComboBox.SelectedIndex = toggle.CurrentState.Key;
                }

                if(toggle.Offset == Aircraft.pmdg737.ENG_IgnitionSelector)
                {
                    ignitionSelectorComboBox.SelectedIndex = toggle.CurrentState.Key;
                }

if(FSUIPCConnection.ReadLVar("switch_688_73X") == 0)
                {
                    engFuel1ComboBox.SelectedIndex = 0;
                }
                else
                {
                    engFuel1ComboBox.SelectedIndex = 1;
                }

if(FSUIPCConnection.ReadLVar("switch_689_73X") == 0)
                {
                    engFuel2ComboBox.SelectedIndex = 0;
                }
                else
                {
                    engFuel2ComboBox.SelectedIndex = 1;
                }
            }
        }

        private void apuSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Properties.pmdg737_offsets.Default.APU_Selector == false)
            {
                if(Tolk.DetectScreenReader() == "NVDA")
                {
                    Tolk.Output(apuSelectorComboBox.SelectedItem.ToString());
                }
            }
            PMDG737Aircraft.APUSelector(apuSelectorComboBox.SelectedIndex); 

        }

        private void engine1SelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Properties.pmdg737_offsets.Default.ENG_StartSelector1 == false)
            {
                if(Tolk.DetectScreenReader() == "NVDA")
                {
                    Tolk.Output(engFuel1ComboBox.SelectedItem.ToString());
                }
            }

            PMDG737Aircraft.Engine1StartSelector(engine1SelectorComboBox.SelectedIndex);
        }

        private void engFuel1ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Tolk.DetectScreenReader() == "NVDA")
            {
                Tolk.Output(engFuel1ComboBox.SelectedItem.ToString());
            }

            PMDG737Aircraft.Eng1FuelSelector(engFuel1ComboBox.SelectedIndex);
        }

        private void engine2SelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Properties.pmdg737_offsets.Default.ENG_StartSelector2 == false)
            {
                if(Tolk.DetectScreenReader() == "NVDA")
                {
                    Tolk.Output(engine2SelectorComboBox.SelectedItem.ToString());
                }
            }

            PMDG737Aircraft.Engine2StartSelector(engine2SelectorComboBox.SelectedIndex);
        }

        private void engFuel2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Tolk.DetectScreenReader() == "NVDA")
            {
                Tolk.Output(engFuel2ComboBox.SelectedItem.ToString());
            }

            PMDG737Aircraft.Eng2FuelSelector(engFuel2ComboBox.SelectedIndex);
        }

        private void ignitionSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Properties.pmdg737_offsets.Default.ENG_IgnitionSelector == false)
            {
                if(Tolk.DetectScreenReader() == "NVDA")
                {
                    Tolk.Output(ignitionSelectorComboBox.SelectedItem.ToString());
                }
            }

            PMDG737Aircraft.IgnitionSelector(ignitionSelectorComboBox.SelectedIndex);
        }

        private void ctlEngines_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                enginesTimer.Start();
            }
            else
            {
                enginesTimer.Stop();
            }

        }
    }
}
