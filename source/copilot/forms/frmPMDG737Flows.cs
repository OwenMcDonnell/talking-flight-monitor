using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tfm.Properties;

namespace tfm.copilot
{
    public partial class frmPMDG737Flows : Form
    {
        private Preflight737 preflight = new Preflight737();
        public static string FlowStatusMessage = "";
        public frmPMDG737Flows()
        {
            InitializeComponent();
            tmrFlowStatus.Start();

            
        }
        
        private void btnAPU_Click(object sender, EventArgs e)
        {
            var flow = Task.Run(() => preflight.ElectricalFlow(0));
        }

        private void tmrFlowStatus_Tick(object sender, EventArgs e)
        {
            if (txtStatus.Text != FlowStatusMessage)
            {
                txtStatus.Text = FlowStatusMessage;
            }

        }

        private void btnGPU_Click(object sender, EventArgs e)
        {
            var flow = Task.Run(() => preflight.ElectricalFlow(1));
        }

        private void btnIRS_Click(object sender, EventArgs e)
        {
            var flow = Task.Run(() => preflight.AlignIRS());    
        }
    }
}
