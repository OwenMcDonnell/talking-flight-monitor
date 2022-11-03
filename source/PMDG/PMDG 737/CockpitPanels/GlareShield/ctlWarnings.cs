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

namespace tfm.PMDG.PMDG_737.CockpitPanels.GlareShield
{
    public partial class ctlWarnings : UserControl, iPanelsPage
    {

        System.Timers.Timer warningTimer = new System.Timers.Timer();
        PanelObject[] controls = PMDG737Aircraft.PanelControls.Where(x => x.PanelName == "Glare Shield" && x.PanelSection == "Warnings").ToArray();

        public ctlWarnings()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void WarningsTimerTick(object Sender, System.Timers.ElapsedEventArgs eventArgs)
        {

            foreach(PanelObject control in controls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.WARN_annunFIRE_WARN[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        fire1TextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.WARN_annunFIRE_WARN[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        fire2TextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.WARN_annunMASTER_CAUTION[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        masterCaution1TextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.WARN_annunMASTER_CAUTION[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        masterCaution2TextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.WARN_annunFLT_CONT)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        fltControlsTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.WARN_annunIRS)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        irsTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.WARN_annunFUEL)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        fuelTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.WARN_annunELEC)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        electricalTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.WARN_annunAPU)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        apuTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.WARN_annunOVHT_DET)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        overheatTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.WARN_annunANTI_ICE)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        antiIceTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.WARN_annunHYD)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        hydraulicsTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.WARN_annunDOORS)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        doorsTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.WARN_annunENG)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        enginesTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.WARN_annunOVERHEAD)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        overheadTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.WARN_annunAIR_COND)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        airSystemsTextBox.Text = toggle.CurrentState.Value;
                    }
                }
            }

        }

        private void ctlWarnings_Load(object sender, EventArgs e)
        {
            warningTimer.Elapsed += WarningsTimerTick;
            warningTimer.Start();

            foreach (PanelObject control in controls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.WARN_annunFIRE_WARN[0])
                {
                        fire1TextBox.Text = toggle.CurrentState.Value;
                                    }

                if (toggle.Offset == Aircraft.pmdg737.WARN_annunFIRE_WARN[1])
                {
                                            fire2TextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.WARN_annunMASTER_CAUTION[0])
                {
                                            masterCaution1TextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.WARN_annunMASTER_CAUTION[1])
                {
                                            masterCaution2TextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.WARN_annunFLT_CONT)
                {
                                            fltControlsTextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.WARN_annunIRS)
                {
                                            irsTextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.WARN_annunFUEL)
                {
                                            fuelTextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.WARN_annunELEC)
                {
                                            electricalTextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.WARN_annunAPU)
                {
                                            apuTextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.WARN_annunOVHT_DET)
                {
                                            overheatTextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.WARN_annunANTI_ICE)
                {
                                            antiIceTextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.WARN_annunHYD)
                {
                                            hydraulicsTextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.WARN_annunDOORS)
                {
                                            doorsTextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.WARN_annunENG)
                {
                                            enginesTextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.WARN_annunOVERHEAD)
                {
                                            overheadTextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.WARN_annunAIR_COND)
                {
                                            airSystemsTextBox.Text = toggle.CurrentState.Value;
                }
            }

        }

        private void ctlWarnings_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                warningTimer.Start();
            }
            else
            {
                warningTimer.Stop();
            }

        }
    }
}
