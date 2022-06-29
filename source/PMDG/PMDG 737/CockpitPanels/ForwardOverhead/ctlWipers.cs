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
    public partial class ctlWipers : UserControl, iPanelsPage
    {

        private Timer wipersTimer = new Timer();
        private PanelObject[] wiperControls = PMDG737Aircraft.PanelControls.Where(x => x.PanelName == "Forward Overhead" && x.PanelSection == "Wipers").ToArray();

        public ctlWipers()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void WiperTimerTick(object Sender, EventArgs eventArgs)
        {

            foreach(PanelObject control in wiperControls)
            {
                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.OH_WiperLSelector)
                {
                    if (toggle.Offset.ValueChanged)
                    { 
                    leftWipersComboBox.SelectedIndex = toggle.CurrentState.Key;
                }
                }

                if(toggle.Offset == Aircraft.pmdg737.OH_WiperRSelector)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightWipersComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }
                }
            }// end loop
        }

        private void leftWipersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Properties.pmdg737_offsets.Default.OH_WiperLSelector == false)
            {
                if(Tolk.DetectScreenReader() == "NVDA")
                {
                    Tolk.Output(leftWipersComboBox.SelectedItem.ToString());
                }
            }
            PMDG737Aircraft.LeftWiperSelector(leftWipersComboBox.SelectedIndex);
        }

        private void rightWipersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Properties.pmdg737_offsets.Default.OH_WiperRSelector == false)
            {
                if(Tolk.DetectScreenReader() == "NVDA")
                {
                    Tolk.Output(rightWipersComboBox.SelectedItem.ToString());
                }
            }
            PMDG737Aircraft.RightWiperSelector(rightWipersComboBox.SelectedIndex);
        }

        private void ctlWipers_Load(object sender, EventArgs e)
                    {
            Tolk.Load();
foreach(PanelObject control in wiperControls)
            {
                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.OH_WiperLSelector)
                {
                    leftWipersComboBox.SelectedIndex = toggle.CurrentState.Key;
                }
                if(toggle.Offset == Aircraft.pmdg737.OH_WiperRSelector)
                {
                    rightWipersComboBox.SelectedIndex = toggle.CurrentState.Key;
                }
            }
            wipersTimer.Tick += new EventHandler((WiperTimerTick));
            wipersTimer.Start();
        }
    }
}
