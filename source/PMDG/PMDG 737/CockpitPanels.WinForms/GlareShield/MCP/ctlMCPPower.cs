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

namespace tfm.PMDG.PMDG_737.CockpitPanels.GlareShield.MCP
{
    public partial class ctlMCPPower : UserControl, iPanelsPage
    {

        System.Timers.Timer powerTimer = new System.Timers.Timer();

        public ctlMCPPower()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                }

        private void PowerTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach(PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.MCP_indication_powered)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        powerTextBox.Text = toggle.CurrentState.Value;
                    }
                } // MCP power.
            } // loop.
        }

        private void ctlMCPPower_Load(object sender, EventArgs e)
        {

            powerTimer.Elapsed += new System.Timers.ElapsedEventHandler(PowerTimerTick);
            powerTimer.Start();

            foreach(PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.MCP_indication_powered)
                {
                    powerTextBox.Text = toggle.CurrentState.Value;
                } // MCP power
            } // loop.
        }
    }
}
