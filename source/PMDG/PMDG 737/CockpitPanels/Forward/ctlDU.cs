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
    public partial class ctlDU : UserControl, iPanelsPage
    {

        private System.Timers.Timer duTimer = new System.Timers.Timer();

        public ctlDU()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void DuTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {
            foreach(PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.MAIN_MainPanelDUSel[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        du1Button.Text = $"Capt. &DU {toggle.CurrentState.Value}";
                        du1Button.AccessibleName = $"Capt. DU {toggle.CurrentState.Value}";
                            }
                } // DU 1

                if(toggle.Offset == Aircraft.pmdg737.MAIN_MainPanelDUSel[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        du2Button.Text = $"F/O D&U {toggle.CurrentState.Value}";
                        du2Button.AccessibleName = $"F/O DU {toggle.CurrentState.Value}";
                    }
                } // DU 2

                if(toggle.Offset == Aircraft.pmdg737.MAIN_LowerDUSel[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        lowerDu1Button.Text = $"&Capt. lower DU {toggle.CurrentState.Value}";
                        lowerDu1Button.AccessibleName = $"Capt. lower DU {toggle.CurrentState.Value}";
                    }
                } // Lower DU 1

                if (toggle.Offset == Aircraft.pmdg737.MAIN_LowerDUSel[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        lowerDu2Button.Text = $"&F/o. lower DU {toggle.CurrentState.Value}";
                        lowerDu2Button.AccessibleName = $"F/O. lower DU {toggle.CurrentState.Value}";
                    }
                } // Lower DU 2

            } // loop
        } // DuTimerTick

        private void ctlDU_Load(object sender, EventArgs e)
        {

            duTimer.Elapsed += new System.Timers.ElapsedEventHandler(DuTimerTick);
            duTimer.Start();

            foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.MAIN_MainPanelDUSel[0])
                {
                                                                du1Button.Text = $"Capt. &DU {toggle.CurrentState.Value}";
                        du1Button.AccessibleName = $"Capt. DU {toggle.CurrentState.Value}";
                                    } // DU 1

                if (toggle.Offset == Aircraft.pmdg737.MAIN_MainPanelDUSel[1])
                {
                                            du2Button.Text = $"F/O D&U {toggle.CurrentState.Value}";
                        du2Button.AccessibleName = $"F/O DU {toggle.CurrentState.Value}";
                } // DU 2

                if (toggle.Offset == Aircraft.pmdg737.MAIN_LowerDUSel[0])
                {
                                                                lowerDu1Button.Text = $"&Capt. lower DU {toggle.CurrentState.Value}";
                        lowerDu1Button.AccessibleName = $"Capt. lower DU {toggle.CurrentState.Value}";
                                    } // Lower DU 1

                if (toggle.Offset == Aircraft.pmdg737.MAIN_LowerDUSel[1])
                {
                                            lowerDu2Button.Text = $"&F/O. lower DU {toggle.CurrentState.Value}";
                        lowerDu2Button.AccessibleName = $"F/O. lower DU {toggle.CurrentState.Value}";
                } // Lower DU 2

            } // loop

        }

        private void du1Button_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.DU1();
        }

        private void du2Button_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.DU2();
        }

        private void lowerDu1Button_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.LowerDU1();
        }

        private void lowerDu2Button_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.LowerDU2();
        }

        private void ctlDU_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                duTimer.Start();
            }
            else
            {
                duTimer.Stop();
            }

        }
    }
}
