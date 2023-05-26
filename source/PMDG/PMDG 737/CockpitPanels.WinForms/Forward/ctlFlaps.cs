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

namespace tfm.PMDG.PMDG_737.CockpitPanels.Forward
{
    public partial class ctlFlaps : UserControl, iPanelsPage
                    {

        private System.Timers.Timer flapsTimer = new System.Timers.Timer();

        public ctlFlaps()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void FlapsTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach(PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.MAIN_TEFlapsNeedle[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        flaps1TextBox.Text = Math.Round(toggle.Offset.GetValue<float>(), 2).ToString();
                    }
                } // flaps 1 needle

                if(toggle.Offset == Aircraft.pmdg737.MAIN_TEFlapsNeedle[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        flaps2TextBox.Text = Math.Round(toggle.Offset.GetValue<float>(), 2).ToString();
                    }
                } // flaps 2 needle

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunLE_FLAPS_TRANSIT)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        flapsInTransitTextBox.Text = toggle.CurrentState.Value;
                    }
                } // flaps in transit

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunLE_FLAPS_EXT)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        flapsExtendedTextBox.Text = toggle.CurrentState.Value;
                    }
                } // flaps extended.
            } // loop
        }

        private void ctlFlaps_Load(object sender, EventArgs e)
        {

            flapsTimer.Elapsed += new System.Timers.ElapsedEventHandler(FlapsTimerTick);
            flapsTimer.Interval = 300;
            flapsTimer.Start();

            foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.MAIN_TEFlapsNeedle[0])
                {
                                                                flaps1TextBox.Text = Math.Round(toggle.Offset.GetValue<float>(), 2).ToString();
                                    } // flaps 1 needle

                if (toggle.Offset == Aircraft.pmdg737.MAIN_TEFlapsNeedle[1])
                {
                                            flaps2TextBox.Text = Math.Round(toggle.Offset.GetValue<float>(), 2).ToString();
                } // flaps 2 needle

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunLE_FLAPS_TRANSIT)
                {
                                                                flapsInTransitTextBox.Text = toggle.CurrentState.Value;
                                    } // flaps in transit

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunLE_FLAPS_EXT)
                {
                                            flapsExtendedTextBox.Text = toggle.CurrentState.Value;
                } // flaps extended.
            } // loop

        }

        private void ctlFlaps_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                flapsTimer.Start();
            }
            else
            {
                flapsTimer.Stop();
            }
        }
    }
}
