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

namespace tfm
{
    public partial class ctlFuel_777 : UserControl, iPanelsPage
    {
        public ctlFuel_777()
        {
            InitializeComponent();
        }

        private void btnLeftForward_Click(object sender, EventArgs e)
        {
if (Aircraft.pmdg777.FUEL_PumpFwd_Sw[0].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_FUEL_PUMP_1_FORWARD, 1);
            }
else
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_FUEL_PUMP_1_FORWARD, 0);
            }
        }

        private void btnLeftAft_Click(object sender, EventArgs e)
        {
            if (Aircraft.pmdg777.FUEL_PumpAft_Sw[0].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_FUEL_PUMP_1_AFT, 1);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_FUEL_PUMP_1_AFT, 0);
            }

        }

        private void btnRightForward_Click(object sender, EventArgs e)
        {
            if (Aircraft.pmdg777.FUEL_PumpFwd_Sw[1].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_FUEL_PUMP_2_FORWARD, 1);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_FUEL_PUMP_2_FORWARD, 0);
            }

        }

        private void btnRightAft_Click(object sender, EventArgs e)
        {
            if (Aircraft.pmdg777.FUEL_PumpAft_Sw[1].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_FUEL_PUMP_2_AFT, 1);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_FUEL_PUMP_2_AFT, 0);
            }

        }

        private void btnCenterLeft_Click(object sender, EventArgs e)
        {
            if (Aircraft.pmdg777.FUEL_PumpCtr_Sw[0].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_FUEL_PUMP_L_CENTER, 1);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_FUEL_PUMP_L_CENTER, 0);
            }

        }

        private void btnCenterRight_Click(object sender, EventArgs e)
        {
            if (Aircraft.pmdg777.FUEL_PumpCtr_Sw[1].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_FUEL_PUMP_R_CENTER, 1);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_FUEL_PUMP_R_CENTER, 0);
            }

        }

        private void btnCrossFeedForward_Click(object sender, EventArgs e)
        {
if (Aircraft.pmdg777.FUEL_CrossFeedFwd_Sw.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_FUEL_CROSSFEED_FORWARD, 1);
            }
else
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_FUEL_CROSSFEED_FORWARD, 0);
            }
        }

        private void btnCrossFeedAft_Click(object sender, EventArgs e)
        {
            if (Aircraft.pmdg777.FUEL_CrossFeedAft_Sw.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_FUEL_CROSSFEED_AFT, 1);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_FUEL_CROSSFEED_AFT, 0);
            }

        }

        public void SetDocking()
        {
            
        }
    }
}
