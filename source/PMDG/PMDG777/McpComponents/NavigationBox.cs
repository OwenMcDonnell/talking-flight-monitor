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

namespace tfm.PMDG.PMDG777.McpComponents
{
    public partial class navigationBox : Form
    {

        private Timer navigationTimer = new Timer();

        public navigationBox()
        {
            InitializeComponent();
        }

                private void navigationTimerTick(object sender, EventArgs eventArgs)
        {
            foreach (tfm.PMDG.PanelObjects.SingleStateToggle toggle in PMDG777Aircraft.PanelControls)
            {
                if (toggle.Name == "Left flight director")
                {
                    string buttonText = $"{toggle.ToString()}";
                    fDLButton.Text = buttonText;
                    fDLButton.AccessibleName = buttonText;
                } // FD/L.

                if(toggle.Name == "Right flight director")
                {
                    fDRButton.Text = toggle.ToString();
                    fDRButton.AccessibleName = toggle.ToString();
                } // fDRButton/r

                if(toggle.Name == "Left autopilot")
                {
                    apLButton.Text = toggle.ToString();
                    apLButton.AccessibleName = toggle.ToString();
                } // AP/L

                if(toggle.Name == "Right autopilot")
                {
                    apRButton.Text = toggle.ToString();
                    apRButton.AccessibleName = toggle.ToString();
                } // AP/R.
            } // foreach.
        }

        private void navigationBox_Load(object sender, EventArgs e)
        {

            navigationTimer.Tick += new EventHandler(navigationTimerTick);
            navigationTimer.Start();
            foreach (tfm.PMDG.PanelObjects.SingleStateToggle toggle in PMDG777Aircraft.PanelControls)
            {
                if (toggle.Name == "Left flight director")
                {
                    string buttonText = $"{toggle.ToString()} {Aircraft.ApFlightDirectorBank.Value}/{Aircraft.ApFlightDirectorPitch.Value}";
                    fDLButton.Text = buttonText;
                    fDLButton.AccessibleName = buttonText;
                } // FD/L.

                if (toggle.Name == "Right flight director")
                {
                    fDRButton.Text = toggle.ToString();
                    fDRButton.AccessibleName = toggle.ToString();
                } // fDRButton/r

                if (toggle.Name == "Left autopilot")
                {
                    apLButton.Text = toggle.ToString();
                    apLButton.AccessibleName = toggle.ToString();
                } // AP/L

                if (toggle.Name == "Right autopilot")
                {
                    apRButton.Text = toggle.ToString();
                    apRButton.AccessibleName = toggle.ToString();
                } // AP/R.
            } // foreach.
        }

        private void apLButton_Click(object sender, EventArgs e)
        {
            var apL = (tfm.PMDG.PanelObjects.SingleStateToggle)PMDG777Aircraft.PanelControls.Where(x => x.Name == "Left autopilot").ToArray()[0]; ;
            if (apL.CurrentState.Key == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_MCP_AP_L_SWITCH, Aircraft.ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_MCP_AP_L_SWITCH, Aircraft.ClkR);
            }
        }

        private void apRButton_Click(object sender, EventArgs e)
        {
            var apR = (tfm.PMDG.PanelObjects.SingleStateToggle)PMDG777Aircraft.PanelControls.Where(x => x.Name == "Right autopilot").ToArray()[0];
            if(apR.CurrentState.Key == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_MCP_AP_R_SWITCH, Aircraft.ClkL);
                            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_MCP_AP_R_SWITCH, Aircraft.ClkR);
            }
        }

        private void fDLButton_Click(object sender, EventArgs e)
        {
            var fdL = (tfm.PMDG.PanelObjects.SingleStateToggle)PMDG777Aircraft.PanelControls.Where(x => x.Name == "Left flight director").ToArray()[0];
            if (fdL.CurrentState.Key == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_MCP_FD_SWITCH_L, Aircraft.ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_MCP_FD_SWITCH_L, Aircraft.ClkR);
            }
            }

        private void fDRButton_Click(object sender, EventArgs e)
        {
            var fdR = (tfm.PMDG.PanelObjects.SingleStateToggle)PMDG777Aircraft.PanelControls.Where(x => x.Name == "Right flight director").ToArray()[0];
            if(fdR.CurrentState.Key == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_MCP_FD_SWITCH_R, Aircraft.ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_MCP_FD_SWITCH_R, Aircraft.ClkR);
            }
                   }

        private void navigationBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void navigationBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                Hide();
            }
        }
    }
}
