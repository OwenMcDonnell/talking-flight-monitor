using FSUIPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm
{
    public partial class ctlHydraulics_777 : UserControl, iPanelsPage
    {
        pmdg pmdg = new pmdg();
        public ctlHydraulics_777()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }
        
        private void ctlHydraulics_777_Load(object sender, EventArgs e)
        {
            tmrHydraulics.Start();
        }

        private void UpdateToggleControl(bool toggleStateOn, CheckBox ctrl)
        {

            if (toggleStateOn)
            {
                if (ctrl.Checked != true)
                {
                    ctrl.Checked = true;
                }

            }
            else
            {
                if (ctrl.Checked != false)
                {
                    ctrl.Checked = false;
                }

            }
        }


        private void tmrHydraulics_Tick(object sender, EventArgs e)
        {
            foreach (tfm.PMDG.PanelObjects.SingleStateToggle toggle in PMDG777Aircraft.PanelControls)
            {
                if (toggle.Name == "Primary electrical pump #1")
                {
                    chkElec1.CheckedChanged -= chkElec1_CheckedChanged;
                    switch (toggle.CurrentState.Key)
                    {
                        case 0:
                            chkElec1.Checked = false;
                            break;

                        case 1:
                            chkElec1.Checked = true;
                            break;
                    }
                    chkElec1.CheckedChanged += chkElec1_CheckedChanged;
                }
            if (toggle.Name == "Primary electrical pump #2")
                {
                    chkElec2.CheckedChanged -= chkElec2_CheckedChanged;
switch (toggle.CurrentState.Key)
                    {
                        case 0:
                            chkElec2.Checked = false;
                            break;

                        case 1:
                            chkElec2.Checked = true;
                            break;
                    }
                    chkElec2.CheckedChanged += chkElec2_CheckedChanged;
                }
            
            }
        }


        private void chkEng1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEng1.Checked)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_HYD_ENG1, 1);

            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_HYD_ENG1, 0);
            }

        }

        private void chkEng2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEng2.Checked)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_HYD_ENG2, 1);

            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_HYD_ENG2, 0);
            }

        }

        private void chkElec1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkElec1.Checked)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_HYD_ELEC1, 1);

            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_HYD_ELEC1, 0);
            }

        }

        private void chkElec2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkElec2.Checked)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_HYD_ELEC2, 1);

            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_HYD_ELEC2, 0);
            }

        }

        private void radAirDemand1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                switch (rb.Name)
                {
                    case "radAirDemand1Off":
                        FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_HYD_AIR1, 0);
                        break;
                    case "radAirDemand1Auto":
                        FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_HYD_AIR1, 1);
                        break;
                    case "radAirDemand1On":
                        FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_HYD_AIR1, 2);
                        break;

                }
            }

        }

        private void radAirDemand2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                switch (rb.Name)
                {
                    case "radAirDemand2Off":
                        FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_HYD_AIR2, 0);
                        break;
                    case "radAirDemand2Auto":
                        FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_HYD_AIR2, 1);
                        break;
                    case "radAirDemand2 On":
                        FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_HYD_AIR2, 2);
                        break;

                }
            }

        }
    }
}
