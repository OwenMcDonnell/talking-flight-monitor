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
    public partial class ctlForwardMcp : UserControl, iPanelsPage
    {

        private System.Timers.Timer mcpTimer = new System.Timers.Timer();

        public ctlForwardMcp()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void McpTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach(PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunAT[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftATTextBox.Text = toggle.CurrentState.Value;
                                            }
                } // AT 1

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunAT[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightATTextBox.Text = toggle.CurrentState.Value;
                    }
                } // AT 2

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunAT_Amber[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftAmberATTextBox.Text = toggle.CurrentState.Value;
                                            }
                } // Amber AT 1

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunAT_Amber[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightAmberATTextBox.Text = toggle.CurrentState.Value;
                    }
                } // Amber AT 2

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunAP[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftAPTextBox.Text = toggle.CurrentState.Value;
                    }
                } // AP 1

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunAP[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightAPTextBox.Text = toggle.CurrentState.Value;
                    }
                } // AP 2

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunAP_Amber[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        leftAmberAPTextBox.Text = toggle.CurrentState.Value;
                                            }
                } // amber AP1

                if(toggle.Offset == Aircraft.pmdg737.MAIN_annunAP_Amber[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rightAmberAPTextBox.Text = toggle.CurrentState.Value;
                    }
                }
            } // loop

                   } // McpTimerTick

        private void ctlForwardMcp_Load(object sender, EventArgs e)
        {
            mcpTimer.Start();

            foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunAT[0])
                {
                                                                leftATTextBox.Text = toggle.CurrentState.Value;
                                    } // AT 1

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunAT[1])
                {
                                            rightATTextBox.Text = toggle.CurrentState.Value;
                } // AT 2

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunAT_Amber[0])
                {
                                                                leftAmberATTextBox.Text = toggle.CurrentState.Value;
                                    } // Amber AT 1

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunAT_Amber[1])
                {
                                            rightAmberATTextBox.Text = toggle.CurrentState.Value;
                } // Amber AT 2

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunAP[0])
                {
                                                                leftAPTextBox.Text = toggle.CurrentState.Value;
                                    } // AP 1

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunAP[1])
                {
                                            rightAPTextBox.Text = toggle.CurrentState.Value;
                } // AP 2

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunAP_Amber[0])
                {
                                                                leftAmberAPTextBox.Text = toggle.CurrentState.Value;
                                    } // amber AP1

                if (toggle.Offset == Aircraft.pmdg737.MAIN_annunAP_Amber[1])
                {
                                            rightAmberAPTextBox.Text = toggle.CurrentState.Value;
                } // amber AP 2
            } // loop

        }
    }
}
