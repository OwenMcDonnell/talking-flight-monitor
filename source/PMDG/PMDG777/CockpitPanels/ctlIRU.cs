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
    public partial class ctlIRU_777 : UserControl, iPanelsPage
    {
        public ctlIRU_777()
        {
            InitializeComponent();
            tmrIRU.Start();
        }

        public void SetDocking()
        {
            
        }

        private void btnIRU_Click(object sender, EventArgs e)
        {
if (Aircraft.pmdg777.ADIRU_Sw_On.Value == 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_ADIRU_SWITCH, 1);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_777X_Control.EVT_OH_ADIRU_SWITCH, 0);
            }
        }

        private void tmrIRU_Tick(object sender, EventArgs e)
        {
if (Aircraft.pmdg777.ADIRU_Sw_On.Value == 0)
            {
                btnIRU.Text = "IRU - Off";
                btnIRU.AccessibleName = "IRU - Off";
            }
            else
            {
                btnIRU.Text = "IRU - On";
                btnIRU.AccessibleName = "IRU - On";

            }
        }
    }
}
