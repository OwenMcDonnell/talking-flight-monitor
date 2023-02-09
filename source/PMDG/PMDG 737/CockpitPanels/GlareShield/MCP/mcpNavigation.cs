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
    public partial class ctlMcpNavigation : UserControl, iPanelsPage
    {

        private System.Timers.Timer navigationTimer = new System.Timers.Timer();

        public ctlMcpNavigation()
        {
            InitializeComponent();
        }

        private void NavigationTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {
            foreach(PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.MCP_FDSw[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        fd1Button.Text = $"&FD/L {toggle.CurrentState.Value}";
                        fd1Button.AccessibleName = $"Left flight director {toggle.CurrentState.Value}";
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.MCP_FDSw[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        fd2Button.Text = $"F&D/R {toggle.CurrentState.Value}";
                        fd2Button.AccessibleName = $"Right flight director {toggle.CurrentState.Value}";
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.MCP_BankLimitSel)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        bankLimitButton.Text = $"Ban&k limit {toggle.CurrentState.Value}";
                        bankLimitButton.AccessibleName = $"Bank limit {toggle.CurrentState.Value}";
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.MCP_DisengageBar)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        disengageBarButton.Text = $"D&isengage bar {toggle.CurrentState.Value}";
                        disengageBarButton.AccessibleName = $"Disengage bar {toggle.CurrentState.Value}";
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.MCP_annunFD[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        fd1TextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.MCP_annunFD[1])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        fd2TextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.MCP_annunAPP)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        appButton.Text = $"A&PP {toggle.CurrentState.Value}";
                        appButton.AccessibleName = $"Approach mode {toggle.CurrentState.Value}";
                        appTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.MCP_annunVOR_LOC)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        vorLocButton.Text = $"&VOR/Loc {toggle.CurrentState.Value}";
                        vorLocButton.AccessibleName = $"Localizer hold {toggle.CurrentState.Value}";
                        vorLocTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.MCP_annunCMD_A)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        cmdAButton.Text = $"CMD&A {toggle.CurrentState.Value}";
                        cmdAButton.AccessibleName = $"CMDA {toggle.CurrentState.Value}";
                        cmdATextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.MCP_annunCWS_A)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        cwsAButton.Text = $"&CWSA {toggle.CurrentState.Value}";
                        cwsAButton.AccessibleName = $"CWSA {toggle.CurrentState.Value}";
                        cwsATextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.MCP_annunCMD_B)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        cmdBButton.Text = $"CMD&B {toggle.CurrentState.Value}";
                        cmdBButton.AccessibleName = $"CMDB {toggle.CurrentState.Value}";
                        cmdBTextBox.Text = toggle.CurrentState.Value;
                    }
                }

                if(toggle.Offset == Aircraft.pmdg737.MCP_annunCWS_B)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        cwsBButton.Text = $"C&WSB {toggle.CurrentState.Value}";
                        cwsBButton.AccessibleName = $"CWSB {toggle.CurrentState.Value}";
                        cwsBTextBox.Text = toggle.CurrentState.Value;
                    }
                }

            } // loop.
        }

        private void mcpNavigation_Load(object sender, EventArgs e)
        {

            navigationTimer.Elapsed += NavigationTimerTick;
            navigationTimer.Start();
            foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;
                if (toggle.Offset == Aircraft.pmdg737.MCP_FDSw[0])
                {
                    fd1Button.Text = $"&FD/L {toggle.CurrentState.Value}";
                    fd1Button.AccessibleName = $"Left flight director {toggle.CurrentState.Value}";
                }

                if (toggle.Offset == Aircraft.pmdg737.MCP_FDSw[1])
                {
                    fd2Button.Text = $"F&D/R {toggle.CurrentState.Value}";
                    fd2Button.AccessibleName = $"Right flight director {toggle.CurrentState.Value}";
                }

                if (toggle.Offset == Aircraft.pmdg737.MCP_BankLimitSel)
                {
                    bankLimitButton.Text = $"Ban&k limit {toggle.CurrentState.Value}";
                    bankLimitButton.AccessibleName = $"Bank limit {toggle.CurrentState.Value}";
                }

                if (toggle.Offset == Aircraft.pmdg737.MCP_DisengageBar)
                {
                    disengageBarButton.Text = $"D&isengage bar {toggle.CurrentState.Value}";
                    disengageBarButton.AccessibleName = $"Disengage bar {toggle.CurrentState.Value}";
                }

                if (toggle.Offset == Aircraft.pmdg737.MCP_annunFD[0])
                {
                    fd1TextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.MCP_annunFD[1])
                {
                    fd2TextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.MCP_annunAPP)
                {
                    appButton.Text = $"A&PP {toggle.CurrentState.Value}";
                    appButton.AccessibleName = $"Approach mode {toggle.CurrentState.Value}";
                    appTextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.MCP_annunVOR_LOC)
                {
                    vorLocButton.Text = $"&VOR/Loc {toggle.CurrentState.Value}";
                    vorLocButton.AccessibleName = $"Localizer hold {toggle.CurrentState.Value}";
                    vorLocTextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.MCP_annunCMD_A)
                {
                    cmdAButton.Text = $"CMD&A {toggle.CurrentState.Value}";
                    cmdAButton.AccessibleName = $"CMDA {toggle.CurrentState.Value}";
                    cmdATextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.MCP_annunCWS_A)
                {
                    cwsAButton.Text = $"&CWSA {toggle.CurrentState.Value}";
                    cwsAButton.AccessibleName = $"CWSA {toggle.CurrentState.Value}";
                    cwsATextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.MCP_annunCMD_B)
                {
                    cmdBButton.Text = $"CMD&B {toggle.CurrentState.Value}";
                    cmdBButton.AccessibleName = $"CMDB {toggle.CurrentState.Value}";
                    cmdBTextBox.Text = toggle.CurrentState.Value;
                }

                if (toggle.Offset == Aircraft.pmdg737.MCP_annunCWS_B)
                {
                    cwsBButton.Text = $"C&WSB {toggle.CurrentState.Value}";
                    cwsBButton.AccessibleName = $"CWSB {toggle.CurrentState.Value}";
                    cwsBTextBox.Text = toggle.CurrentState.Value;
                }
            }
            }

                private void mcpNavigation_KeyDown(object sender, KeyEventArgs e)
        {
            if((e.Alt && e.KeyCode == Keys.F4) ||(e.KeyCode == Keys.Escape))
            {
                Hide();
            }
        }

                private void fd1Button_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.FD1();
        }

        private void fd2Button_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.FD2();
        }

        private void appButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.ApproachMode();
        }

        private void vorLocButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.LocalizerHold();
        }

        private void cmdAButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.CMDA();
        }

        private void cwsAButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.CWSA();
        }

        private void cmdBButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.CMDB();
        }

        private void cwsBButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.CWSB();
        }

        private void disengageBarButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.DisengageBar();
        }

        private void bankLimitButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.BankLimiter();
        }

        public void SetDocking()
        {
                    }

        private void ctlMcpNavigation_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                navigationTimer.Start();
            }
            else
            {
                navigationTimer.Start();
            }
        }
    }
}
