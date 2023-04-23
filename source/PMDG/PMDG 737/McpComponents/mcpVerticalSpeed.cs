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

namespace tfm.PMDG.PMDG737.McpComponents
{
    public partial class mcpVerticalSpeed : Form
    {

        private System.Timers.Timer vsTimer = new System.Timers.Timer();

                public mcpVerticalSpeed()
        {
            InitializeComponent();
        }

        private void VSTimerTick(Object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {
                        foreach(PanelObject control in PMDG737Aircraft.PanelControls)
            {
                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.MCP_VertSpeedBlank)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        verticalSpeedButton.Text = $"&Vertical speed {toggle.CurrentState.Value}";
                        verticalSpeedButton.AccessibleName = $"Vertical speed {toggle.CurrentState.Value}";
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.MCP_annunVS)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        verticalSpeedLightTextBox.Text = toggle.CurrentState.Value;
                    }
                }
                                           }

                        if(Aircraft.pmdg737.MCP_VertSpeedBlank.Value == 1)
            {
                verticalSpeedTextBox.Text = String.Empty;
                verticalSpeedTextBox.ReadOnly = true;
            }
            else
            {
                if (Aircraft.pmdg737.MCP_VertSpeed.ValueChanged)
                {
                    verticalSpeedTextBox.ReadOnly = false;
                    verticalSpeedTextBox.Text = Aircraft.pmdg737.MCP_VertSpeed.Value.ToString();
                }

            }
        } // VSTimerTick

        private void verticalSpeedButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.VerticalSpeedIntervene();
        }

        private void verticalSpeedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PMDG737Aircraft.SetVerticalSpeed(verticalSpeedTextBox.Text);
            }
                       }

        private void mcpVerticalSpeed_Load(object sender, EventArgs e)
        {
            vsTimer.Elapsed += VSTimerTick;
            
            vsTimer.Start();
            foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {
                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.MCP_VertSpeedBlank)
                {
                                                                verticalSpeedButton.Text = $"&Vertical speed {toggle.CurrentState.Value}";
                        verticalSpeedButton.AccessibleName = $"Vertical speed {toggle.CurrentState.Value}";
                                    }

                if (toggle.Offset == Aircraft.pmdg737.MCP_annunVS)
                {
                    verticalSpeedLightTextBox.Text = toggle.CurrentState.Value;
                }
                            }
if(Aircraft.pmdg737.MCP_VertSpeedBlank.Value == 1)
            {
                verticalSpeedTextBox.Text = String.Empty;
                verticalSpeedTextBox.ReadOnly = true;
            }
            else
            {
                verticalSpeedTextBox.Text = Aircraft.pmdg737.MCP_VertSpeed.Value.ToString();
            }
                            
        }

        private void mcpVerticalSpeed_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                Hide();
            }
        }

        private void mcpVerticalSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if((e.Alt && e.KeyCode== Keys.F4) || e.KeyCode == Keys.Escape)
            {
                Hide();
            }
        }
    }
}
