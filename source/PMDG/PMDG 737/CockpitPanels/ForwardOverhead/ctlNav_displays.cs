using tfm.PMDG.PanelObjects;
using DavyKager;
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
    public partial class ctlNav_displays : UserControl, iPanelsPage
    {

        Timer sourceTimer = new Timer();
        PanelObject[] sourceControls = PMDG737Aircraft.PanelControls.Where(x => x.PanelName == "Forward Overhead" && x.PanelSection == "Navigation/Displays").ToArray();
        public ctlNav_displays()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void sourceTimerTick(object Sender, EventArgs eventArgs)
        {
            foreach(PanelObject control in sourceControls)
            {
                var toggle = (SingleStateToggle)control;

                // VHF selector
                if(toggle.Offset == Aircraft.pmdg737.NAVDIS_VHFNavSelector)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        vhfComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }
                }

                // IRS selector
                if(toggle.Offset == Aircraft.pmdg737.NAVDIS_IRSSelector)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        irsComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }
                }

                //FMC selector
                if(toggle.Offset == Aircraft.pmdg737.NAVDIS_FMCSelector)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        fmcComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }
                }

                // Source selector
                if(toggle.Offset == Aircraft.pmdg737.NAVDIS_SourceSelector)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        sourceComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }
                }

                // Control pane selector
                if(toggle.Offset == Aircraft.pmdg737.NAVDIS_ControlPaneSelector)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        controlPaneComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }
                                    }
            } // End foreach.
        }

        private void ctlNav_displays_Load(object sender, EventArgs e)
        {
            sourceTimer.Tick += new EventHandler(sourceTimerTick);
            sourceTimer.Start();
            foreach(PanelObject control in sourceControls)
            {
                var toggle = (SingleStateToggle)control;
                if(toggle.Offset == Aircraft.pmdg737.NAVDIS_VHFNavSelector)
                {
                    vhfComboBox.SelectedIndex = toggle.CurrentState.Key;
                }
                if(toggle.Offset == Aircraft.pmdg737.NAVDIS_IRSSelector)
                {
                    irsComboBox.SelectedIndex = toggle.CurrentState.Key;
                }
                if(toggle.Offset == Aircraft.pmdg737.NAVDIS_FMCSelector)
                {
                    fmcComboBox.SelectedIndex = toggle.CurrentState.Key;
                }
                if(toggle.Offset == Aircraft.pmdg737.NAVDIS_SourceSelector)
                {
                    sourceComboBox.SelectedIndex = toggle.CurrentState.Key;
                }
                if(toggle.Offset == Aircraft.pmdg737.NAVDIS_ControlPaneSelector)
                {
                    controlPaneComboBox.SelectedIndex = toggle.CurrentState.Key;
                }
            }
            Tolk.Load();
                   }

        private void vhfComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Properties.pmdg737_offsets.Default.NAVDIS_VHFNavSelector == false)
            {
                if (Tolk.DetectScreenReader() == "NVDA")
                {
                    Tolk.Output(vhfComboBox.SelectedItem.ToString());
                }
            }
            PMDG737Aircraft.VHFSelector(vhfComboBox.SelectedIndex);
        }

        private void irsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Properties.pmdg737_offsets.Default.NAVDIS_IRSSelector == false)
            {
                if(Tolk.DetectScreenReader() == "NVDA")
                {
                    Tolk.Output(irsComboBox.SelectedItem.ToString());
                }
            }
            
            PMDG737Aircraft.IRSSelector(irsComboBox.SelectedIndex);
        }

        private void fmcComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Properties.pmdg737_offsets.Default.NAVDIS_FMCSelector == false)
            {
                if(Tolk.DetectScreenReader() == "NVDA")
                {
                    Tolk.Output(fmcComboBox.SelectedItem.ToString());
                }
            }
            PMDG737Aircraft.FMCSelector(fmcComboBox.SelectedIndex);
        }

        private void sourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Properties.pmdg737_offsets.Default.NAVDIS_SourceSelector == false)
            {
                if(Tolk.DetectScreenReader() == "NVDA")
                {
                    Tolk.Output(sourceComboBox.SelectedItem.ToString());
                }
            }

            PMDG737Aircraft.SourceSelector(sourceComboBox.SelectedIndex);
        }

        private void controlPaneComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Properties.pmdg737_offsets.Default.NAVDIS_ControlPaneSelector == false)
            {
                if(Tolk.DetectScreenReader() == "NVDA")
                {
                    Tolk.Output(controlPaneComboBox.SelectedItem.ToString());
                }
            }

            PMDG737Aircraft.ControlPaneSelector(controlPaneComboBox.SelectedIndex);
        }
    }
}
