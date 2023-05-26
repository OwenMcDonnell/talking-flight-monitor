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
    public partial class ctlBusses : UserControl, iPanelsPage
    {

        System.Timers.Timer busesTimer = new System.Timers.Timer();

        public ctlBusses()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void BusesTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach(PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        hotBattTextBox.Text = toggle.CurrentState.Value;
                    }
                } // hot battery

                if(toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        hotBattSwitchedTextBox.Text = toggle.CurrentState.Value;
                    }
                } // hot batt switched

                if(toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[2])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        battBusTextBox.Text = toggle.CurrentState.Value;
                    }
                } // battery bus

                if(toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[3])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        dcStandbyTextBox.Text = toggle.CurrentState.Value;
                    }
                } // DC standby

                if(toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[4])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        bus1TextBox.Text = toggle.CurrentState.Value;
                    }
                } // DC bus 1

                if(toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[5])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        bus2TextBox.Text = toggle.CurrentState.Value;
                    }
                } // DC bus 2

                if(toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[6])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        groundServiceTextBox.Text = toggle.CurrentState.Value;
                    }
                } // DC ground svc.

                if(toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[7])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        transfer1TextBox.Text = toggle.CurrentState.Value;
                    }
                } // AC transfer 1

                if(toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[8])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        transfer2TextBox.Text = toggle.CurrentState.Value;
                    }
                } // AC transfer 2

                if(toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[9])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        acGroundService1TextBox.Text = toggle.CurrentState.Value;
                    }
                } // AC gnd svc 1

                if(toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[10])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        acGroundService2TextBox.Text = toggle.CurrentState.Value;
                    }
                } // AC gnd svc 2

                if(toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[11])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        main1TextBox.Text = toggle.CurrentState.Value;
                    }
                } // AC main 1.

                if(toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[12])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        main2TextBox.Text = toggle.CurrentState.Value;
                    }
                } // AC main 2

                if(toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[13])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        galley1TextBox.Text = toggle.CurrentState.Value;
                    }
                } // galley 1

                if(toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[14])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        galley2TextBox.Text = toggle.CurrentState.Value;
                    }
                } // galley 2

                if(toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[15])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        acStandbyTextBox.Text = toggle.CurrentState.Value;
                    }
                }
            } // loop.
        }

        private void ctlBusses_Load(object sender, EventArgs e)
        {

            busesTimer.Elapsed += new System.Timers.ElapsedEventHandler(BusesTimerTick);

            if (Visible)
            {
                busesTimer.Start();
            }

            foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[0])
                {
                                                                hotBattTextBox.Text = toggle.CurrentState.Value;
                                    } // hot battery

                if (toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[1])
                {
                                            hotBattSwitchedTextBox.Text = toggle.CurrentState.Value;
                } // hot batt switched

                if (toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[2])
                {
                                                                battBusTextBox.Text = toggle.CurrentState.Value;
                                    } // battery bus

                if (toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[3])
                {
                                            dcStandbyTextBox.Text = toggle.CurrentState.Value;
                } // DC standby

                if (toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[4])
                {
                                                                bus1TextBox.Text = toggle.CurrentState.Value;
                                    } // DC bus 1

                if (toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[5])
                {
                                            bus2TextBox.Text = toggle.CurrentState.Value;
                } // DC bus 2

                if (toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[6])
                {
                                                                groundServiceTextBox.Text = toggle.CurrentState.Value;
                                    } // DC ground svc.

                if (toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[7])
                {
                                            transfer1TextBox.Text = toggle.CurrentState.Value;
                } // AC transfer 1

                if (toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[8])
                {
                                                                transfer2TextBox.Text = toggle.CurrentState.Value;
                                    } // AC transfer 2

                if (toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[9])
                {
                                            acGroundService1TextBox.Text = toggle.CurrentState.Value;
                } // AC gnd svc 1

                if (toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[10])
                {
                                                                acGroundService2TextBox.Text = toggle.CurrentState.Value;
                                    } // AC gnd svc 2

                if (toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[11])
                {
                                            main1TextBox.Text = toggle.CurrentState.Value;
                } // AC main 1.

                if (toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[12])
                {
                                                                main2TextBox.Text = toggle.CurrentState.Value;
                                    } // AC main 2

                if (toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[13])
                {
                                            galley1TextBox.Text = toggle.CurrentState.Value;
                } // galley 1

                if (toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[14])
                {
                                                                galley2TextBox.Text = toggle.CurrentState.Value;
                                    } // galley 2

                if (toggle.Offset == Aircraft.pmdg737.ELEC_BusPowered[15])
                {
                                            acStandbyTextBox.Text = toggle.CurrentState.Value;
                } // AC Standby
            } // loop.

        }

        private void ctlBusses_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                busesTimer.Start();
            }
            else
            {
                busesTimer.Stop();
            }
        }
    }
}
