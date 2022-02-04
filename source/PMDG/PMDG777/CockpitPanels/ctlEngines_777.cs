using System;
using System.Collections.Generic;
using DavyKager;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FSUIPC;
namespace tfm
{
    public partial class ctlEngines_777 : UserControl, iPanelsPage
    {
        public ctlEngines_777()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
        }

        private void btnEng1Start_Click(object sender, EventArgs e)
        {
            if (Aircraft.pmdg777.ENG_Start_Selector[0].Value == 1)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_ENGINE_L_START, 0);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_ENGINE_L_START, 1);
            }

        }

        private void btnEng1Fuel_Click(object sender, EventArgs e)
        {
            if (Aircraft.pmdg777.ENG_FuelControl_Sw_RUN[0].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_CONTROL_STAND_ENG1_START_LEVER, 0);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_CONTROL_STAND_ENG1_START_LEVER, 1);
            }
            
        }

        private void btnEng2Start_Click(object sender, EventArgs e)
        {
            if (Aircraft.pmdg777.ENG_Start_Selector[1].Value == 1)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_ENGINE_R_START, 0);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_ENGINE_R_START, 1);
            }
        }

        private void btnEng2Fuel_Click(object sender, EventArgs e)
        {
            if (Aircraft.pmdg777.ENG_FuelControl_Sw_RUN[1].Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_CONTROL_STAND_ENG2_START_LEVER, 0);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_CONTROL_STAND_ENG2_START_LEVER, 1);
            }

        }

        private void tmrEngines_Tick(object sender, EventArgs e)
        {
            // engine 1 start switch    
            if (Aircraft.pmdg777.ENG_Start_Selector[0].Value == 0)
            {
                btnEng1Start.Text = "Engine 1 start mode - Start";
                btnEng1Start.AccessibleName = "Engine 1 start mode - Start";
            }
            else
            {
                btnEng1Start.Text = "Engine 1 start mode - Normal";
                btnEng1Start.AccessibleName = "Engine 1 start mode - Normal";
            }

            // Engine 1 fuel
            if (Aircraft.pmdg777.ENG_FuelControl_Sw_RUN[0].Value == 1)
            {
                btnEng1Fuel.Text = "Engine 1 fuel lever - Run";
                btnEng1Fuel.AccessibleName = "Engine 1 fuel lever - Run";
            }
            else
            {
                btnEng1Fuel.Text = "Engine 1 fuel lever - Off";
                btnEng1Fuel.AccessibleName = "Engine 1 fuel lever - Off";
            }

            // engine 2 start switch    
            if (Aircraft.pmdg777.ENG_Start_Selector[1].Value == 0)
            {
                btnEng2Start.Text = "Engine 2 start mode - Start";
                btnEng2Start.AccessibleName = "Engine 2 start mode - Start";
            }
            else
            {
                btnEng2Start.Text = "Engine 2 start mode - Normal";
                btnEng2Start.AccessibleName = "Engine 2 start mode - Normal";
            }
            // Engine 2 fuel
            if (Aircraft.pmdg777.ENG_FuelControl_Sw_RUN[1].Value == 1)
            {
                btnEng2Fuel.Text = "Engine 2 fuel lever - Run";
                btnEng2Fuel.AccessibleName = "Engine 2 fuel lever - Run";
            }
            else
            {
                btnEng2Fuel.Text = "Engine 2 fuel lever - Off";
                btnEng2Fuel.AccessibleName = "Engine 2 fuel lever - Off";
            }

        }

        private void ctlEngines_777_Load(object sender, EventArgs e)
        {
            tmrEngines.Start();
        }
    }
    }
