using System;
using System.Collections.Generic;
using System.ComponentModel;
using tfm.PMDG.PanelObjects;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.PMDG.PMDG_737.CockpitPanels.GlareShield.MCP
{
    public partial class ctlMcpAltitude : UserControl, iPanelsPage
    {
        private System.Timers.Timer altitudeTimer = new System.Timers.Timer();


        public ctlMcpAltitude()
        {
            InitializeComponent();
        }

        private void AltitudeTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {
                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.MCP_annunVNAV)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        vNavButton.Text = $"&VNav {toggle.CurrentState.Value}";
                        vNavButton.AccessibleName = $"VNav {toggle.CurrentState.Value}";
                        vNavTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.MCP_annunLVL_CHG)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        levelChangeButton.Text = $"&Level change {toggle.CurrentState.Value}";
                        levelChangeButton.AccessibleName = $"Level change {toggle.CurrentState.Value}";
                        lvlChangeTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if (toggle.Offset == Aircraft.pmdg737.MCP_annunALT_HOLD)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        holdButton.Text = $"&Hold {toggle.CurrentState.Value}";
                        holdButton.AccessibleName = $"Hold {toggle.CurrentState.Value}";
                        holdTextBox.Text = toggle.CurrentState.Value;
                    }
                }
            }

            if (Aircraft.pmdg737.MCP_Altitude.ValueChanged)
            {
                altitudeTextBox.Text = Aircraft.pmdg737.MCP_Altitude.Value.ToString();
            }

        }

        private void interveneButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.AltitudeIntervene();
        }

        private void vNavButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.ToggleVNav();
        }

        private void levelChangeButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.ToggleLevelChange();
        }

        private void holdButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.ToggleAltitudeHold();
        }

        private void altitudeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                PMDG737Aircraft.SetAltitude(altitudeTextBox.Text);
            }
        }

        private void mcpAltitude_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Alt && e.KeyCode == Keys.F4) || e.KeyCode == Keys.Escape)
            {
                Hide();
            }
        }

                        private void ctlMcpAltitude_Load(object sender, EventArgs e)
        {
            altitudeTimer.Elapsed += AltitudeTimerTick;
            altitudeTimer.Start();

            foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {
                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.MCP_annunVNAV)
                {
                    vNavButton.Text = $"&VNav {toggle.CurrentState.Value}";
                    vNavButton.AccessibleName = $"VNav {toggle.CurrentState.Value}";
                    vNavTextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.MCP_annunLVL_CHG)
                {
                    levelChangeButton.Text = $"&Level change {toggle.CurrentState.Value}";
                    levelChangeButton.AccessibleName = $"Level change {toggle.CurrentState.Value}";
                    lvlChangeTextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.MCP_annunALT_HOLD)
                {
                    holdButton.Text = $"&Hold {toggle.CurrentState.Value}";
                    holdButton.AccessibleName = $"Hold {toggle.CurrentState.Value}";
                    holdTextBox.Text = toggle.CurrentState.Value;
                }
            }

            altitudeTextBox.Text = Aircraft.pmdg737.MCP_Altitude.Value.ToString();
        }

        public void SetDocking()
        {
            
        }
    }
                }
