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

namespace tfm.PMDG.PMDG_747.McpComponents
{
    public partial class NavigationBox : Form
    {

        private System.Timers.Timer navigationTimer = new System.Timers.Timer();
        public NavigationBox()
        {
            InitializeComponent();
        }

        private void NavigationTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach(PanelObject control in PMDG747Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg747.MCP_FD_Sw_On[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        fdLButton.Text = $"&FD/L {toggle.CurrentState.Value}";
                        fdLButton.AccessibleName = $"Left flight director {toggle.CurrentState.Value}";
                    }
                } // FD/L

                if(toggle.Offset == Aircraft.pmdg747.MCP_FD_Sw_On[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        fdRButton.Text = $"F&D/R {toggle.CurrentState.Value}";
                        fdRButton.AccessibleName = $"Right flight director {toggle.CurrentState.Value}";
                    }
                } // FD/R

                if(toggle.Offset == Aircraft.pmdg747.MCP_annunAP[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        apLButton.Text = $"AP/&L {toggle.CurrentState.Value}";
                        apLButton.AccessibleName = $"Left auto pilot {toggle.CurrentState.Value}";

                    }
                }// AP/L

                if(toggle.Offset == Aircraft.pmdg747.MCP_annunAP[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        apCButton.Text = $"AP/&C {toggle.CurrentState.Value}";
                        apCButton.AccessibleName = $"Center auto pilot {toggle.CurrentState.Value}";
                    }
                } // AP/C

                if(toggle.Offset == Aircraft.pmdg747.MCP_annunAP[2])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        apRButton.Text = $"AP/&R {toggle.CurrentState.Value}";
                        apRButton.AccessibleName = $"Right auto pilot {toggle.CurrentState.Value}";
                    }
                } // AP/R

                if(toggle.Offset == Aircraft.pmdg747.MCP_annunAPP)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        appButton.Text = $"A&PP {toggle.CurrentState.Value}";
                        appButton.AccessibleName = $"Approach mode {toggle.CurrentState.Value}";
                    }
                } // APP mode

                if(toggle.Offset == Aircraft.pmdg747.MCP_annunLOC)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        locButton.Text = $"L&OC {toggle.CurrentState.Value}";
                        locButton.AccessibleName = $"Localizer hold {toggle.CurrentState.Value}";
                    }
                } // Loc hold

                if(toggle.Offset == Aircraft.pmdg747.MCP_BankLimitSel)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        bankLimitButton.Text = $"&Bank limit {toggle.CurrentState.Value}";
                        bankLimitButton.AccessibleName = $"Bank limit {toggle.CurrentState.Value}";
                    }
                } // Bank limit

                if(toggle.Offset == Aircraft.pmdg747.MCP_DisengageBar)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        disengageBarButton.Text = $"D&isengage bar {toggle.CurrentState.Value}";
                        disengageBarButton.AccessibleName = $"Disengage bar {toggle.CurrentState.Value}";
                    }
                } // disengage bar
            } // loop
        }

        private void NavigationBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                Hide();
            }
        }

        private void NavigationBox_KeyDown(object sender, KeyEventArgs e)
        {

            if((e.Alt && e.KeyCode == Keys.F4) || e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                Hide();
            }
        }

        private void fdLButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.LeftFlightDirectorToggle();
        }

        private void fdRButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.RightFlightDirectorToggle();
        }

        private void apLButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.LeftAutoPilotToggle();
        }

        private void apCButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.CenterAutoPilotToggle();
        }

        private void apRButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.RightAutoPilotToggle();
        }

        private void appButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.ApproachModeToggleToggle();
        }

        private void locButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.LocalizerHoldToggle();
        }

        private void bankLimitButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.BankLimitCycle();
        }

        private void disengageBarButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.DisengageBarToggle();
        }

        private void NavigationBox_Load(object sender, EventArgs e)
        {

            navigationTimer.Elapsed += new System.Timers.ElapsedEventHandler(NavigationTimerTick);
            navigationTimer.Start();

            foreach (PanelObject control in PMDG747Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg747.MCP_FD_Sw_On[0])
                {
                                                                fdLButton.Text = $"&FD/L {toggle.CurrentState.Value}";
                        fdLButton.AccessibleName = $"Left flight director {toggle.CurrentState.Value}";
                                    } // FD/L

                if (toggle.Offset == Aircraft.pmdg747.MCP_FD_Sw_On[1])
                {
                                            fdRButton.Text = $"F&D/R {toggle.CurrentState.Value}";
                        fdRButton.AccessibleName = $"Right flight director {toggle.CurrentState.Value}";
                } // FD/R

                if (toggle.Offset == Aircraft.pmdg747.MCP_annunAP[0])
                {
                                                                apLButton.Text = $"AP/&L {toggle.CurrentState.Value}";
                        apLButton.AccessibleName = $"Left auto pilot {toggle.CurrentState.Value}";
                                                        }// AP/L

                if (toggle.Offset == Aircraft.pmdg747.MCP_annunAP[1])
                {
                                                                apCButton.Text = $"AP/&C {toggle.CurrentState.Value}";
                        apCButton.AccessibleName = $"Center auto pilot {toggle.CurrentState.Value}";
                                    } // AP/C

                if (toggle.Offset == Aircraft.pmdg747.MCP_annunAP[2])
                {
                                            apRButton.Text = $"AP/&R {toggle.CurrentState.Value}";
                        apRButton.AccessibleName = $"Right auto pilot {toggle.CurrentState.Value}";
                } // AP/R

                if (toggle.Offset == Aircraft.pmdg747.MCP_annunAPP)
                {
                                                                appButton.Text = $"A&PP {toggle.CurrentState.Value}";
                        appButton.AccessibleName = $"Approach mode {toggle.CurrentState.Value}";
                                    } // APP mode

                if (toggle.Offset == Aircraft.pmdg747.MCP_annunLOC)
                {
                                            locButton.Text = $"L&OC {toggle.CurrentState.Value}";
                        locButton.AccessibleName = $"Localizer hold {toggle.CurrentState.Value}";
                } // Loc hold

                if (toggle.Offset == Aircraft.pmdg747.MCP_BankLimitSel)
                {
                                                                bankLimitButton.Text = $"&Bank limit {toggle.CurrentState.Value}";
                        bankLimitButton.AccessibleName = $"Bank limit {toggle.CurrentState.Value}";
                                    } // Bank limit

                if (toggle.Offset == Aircraft.pmdg747.MCP_DisengageBar)
                {
                                            disengageBarButton.Text = $"D&isengage bar {toggle.CurrentState.Value}";
                        disengageBarButton.AccessibleName = $"Disengage bar {toggle.CurrentState.Value}";
                } // disengage bar
            } // loop

        }
    }
}
