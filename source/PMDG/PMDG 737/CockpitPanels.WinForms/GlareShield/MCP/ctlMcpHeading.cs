using tfm.PMDG.PanelObjects;
using FSUIPC;
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
    public partial class ctlMcpHeading : UserControl, iPanelsPage
    {

        private System.Timers.Timer headingTimer = new System.Timers.Timer();
private        PanelObject[] headingControls = PMDG737Aircraft.PanelControls.Where(x => x.PanelName == "Glare Shield" && x.PanelSection == "MCP-HEADING").ToArray();
        
                public ctlMcpHeading()
        {
            InitializeComponent();
        }

        private void HeadingTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach(PanelObject control in headingControls)
            {
                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.MCP_annunHDG_SEL)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        hdgSelButton.Text = $"&Hdg sel {toggle.CurrentState.Value}";
                        hdgSelButton.AccessibleName = $"Hdg sel {toggle.CurrentState.Value}";
                        hdgSelTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.MCP_annunLNAV)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        lNavButton.Text = $"&LNav {toggle.CurrentState.Value}";
                        lNavButton.AccessibleName = $"LNav {toggle.CurrentState.Value}";
                        lnavTextBox.Text = toggle.CurrentState.Value;
                    }
                }
            }
            if (Aircraft.pmdg737.MCP_Heading.ValueChanged)
            {
                headingTextBox.Text = Aircraft.pmdg737.MCP_Heading.Value.ToString();
            }
                    } // HeadingTimerTick

        private void CtlMcpHeading_Load(object sender, EventArgs e)
        {

            var headingControls = PMDG737Aircraft.PanelControls.Where(x => x.PanelName == "Glare Shield" && x.PanelSection == "MCP-HEADING").ToArray();
        headingTimer.Elapsed += HeadingTimerTick;
            headingTimer.Start();

            foreach (PanelObject control in headingControls)
            {
                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.MCP_annunHDG_SEL)
                {
                                                                hdgSelButton.Text = $"&Hdg sel {toggle.CurrentState.Value}";
                        hdgSelButton.AccessibleName = $"Hdg sel {toggle.CurrentState.Value}";
                        hdgSelTextBox.Text = toggle.CurrentState.Value;
                                    }

                if (toggle.Offset == Aircraft.pmdg737.MCP_annunLNAV)
                {
                                            lNavButton.Text = $"&LNav {toggle.CurrentState.Value}";
                        lNavButton.AccessibleName = $"LNav {toggle.CurrentState.Value}";
                        lnavTextBox.Text = toggle.CurrentState.Value;
                                    }
            }
            headingTextBox.Text = Aircraft.pmdg737.MCP_Heading.Value.ToString();
                    }

        private void headingTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                PMDG737Aircraft.SetHeading(headingTextBox.Text);
            }
        }

        private void hdgSelButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.ToggleHeadingSelect();
        }

        private void lNavButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.ToggleLNav();
        }

                private void mcpHeading_KeyDown(object sender, KeyEventArgs e)
        {
            if((e.Alt && e.KeyCode == Keys.F4) || (e.KeyCode == Keys.Escape))
            {
                Hide();
            }
        }

        public void SetDocking()
        {
            
        }

        private void ctlMcpHeading_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                headingTimer.Start();
            }
            else
            {
                headingTimer.Stop();
            }
        }
    }
}
