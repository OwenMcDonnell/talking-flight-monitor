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

            public partial class ctlHydraulics : UserControl, iPanelsPage
    {

        private Timer hydraulicsTimer = new Timer();
        private PanelObject[] hydControls = PMDG737Aircraft.PanelControls.Where(x => x.PanelName == "Center Overhead" && x.PanelSection == "Hydraulics").ToArray();

        public ctlHydraulics()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void HydraulicsTimerTic(object Sender, EventArgs eventArgs)
        {

            foreach(PanelObject control in hydControls)
            {
                var toggle = (SingleStateToggle)control;

                // Electrical pump #1.
                if(toggle.Offset == Aircraft.pmdg737.HYD_PumpSw_elec[1])
                {
                    elec1Button.Text = $"Electrical pump #1 {toggle.CurrentState.Value}";
                    elec1Button.AccessibleName = $"Electrical pump #1 {toggle.CurrentState.Value}";
                }

                // Electrical pump #2.
                if(toggle.Offset == Aircraft.pmdg737.HYD_PumpSw_elec[0])
                {
                    elec2Button.Text = $"Electrical pump #2 {toggle.CurrentState.Value}";
                    elec2Button.AccessibleName = $"Electrical pump #2 {toggle.CurrentState.Value}";
                }

                // Engine pump #1.
                if(toggle.Offset == Aircraft.pmdg737.HYD_PumpSw_eng[0])
                {
                    eng1Button.Text = $"Engine pump #1 {toggle.CurrentState.Value}";
                    eng1Button.AccessibleName = $"Engine #1 pump {toggle.CurrentState.Value}";
                }

                // Engine pump #2.
                if(toggle.Offset == Aircraft.pmdg737.HYD_PumpSw_eng[1])
                {
                    eng2Button.Text = $"Engine pump #2 {toggle.CurrentState.Value}";
                    eng2Button.AccessibleName = $"Engine pump #2 {toggle.CurrentState.Value}";
                }

                // Electrical pump #1 indicator.
                if(toggle.Offset == Aircraft.pmdg737.HYD_annunLOW_PRESS_elec[1])
                {
                    electrical1TextBox.Text = toggle.CurrentState.Value;
                }

                // Electrical pump #2 indicator
                if(toggle.Offset == Aircraft.pmdg737.HYD_annunLOW_PRESS_elec[0])
                {
                    electrical2TextBox.Text = toggle.CurrentState.Value;
                }

                // Engine pump #1 indicator.
                if(toggle.Offset == Aircraft.pmdg737.HYD_annunLOW_PRESS_eng[0])
                {
                    engine1TextBox.Text = toggle.CurrentState.Value;
                }

                // Engine pump #2 indicator.
                if(toggle.Offset == Aircraft.pmdg737.HYD_annunLOW_PRESS_eng[1])
                {
                    engine2TextBox.Text = toggle.CurrentState.Value;
                }

                // Pump #1 overheat indicator.
                if(toggle.Offset == Aircraft.pmdg737.HYD_annunOVERHEAT_elec[1])
                {
                    overheat1TextBox.Text = toggle.CurrentState.Value;
                }

                // Pump overheat #2 indicator.
                if(toggle.Offset == Aircraft.pmdg737.HYD_annunOVERHEAT_elec[0])
                {
                    overheat2TextBox.Text = toggle.CurrentState.Value;
                }
            }
        }

        private void ctlHydraulics_Load(object sender, EventArgs e)
        {
            hydraulicsTimer.Tick += new EventHandler(HydraulicsTimerTic);
            hydraulicsTimer.Start();
        }

        private void elec1Button_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.HydraulicElectricalPump1();
        }

        private void elec2Button_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.HydraulicElectricalPump2();
        }

        private void eng1Button_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.HydraulicsEnginePump1();
        }

        private void eng2Button_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.HydraulicsEnginePump2();
        }
    }
}
