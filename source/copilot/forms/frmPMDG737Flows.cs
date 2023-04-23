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
                txtStatus.Text = FlowStatusMessage + "\n";
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

        private void btnFireTest_Click(object sender, EventArgs e)
        {
            var flow = Task.Run(() => preflight.systemTestFire());
        }

        private void frmPMDG737Flows_Load(object sender, EventArgs e)
        {

        }

        private void btnGPWS_Click(object sender, EventArgs e)
        {
            var flow = Task.Run(() => preflight.systemTestGPWS());
        }

        private void btnPanelSetup_Click(object sender, EventArgs e)
        {
            var flow = Task.Run(() => preflight.PreflightPanelSetup());
        }

        private void btnOverspeed_Click(object sender, EventArgs e)
        {
            var flow = Task.Run(() => preflight.SystemTestOverspeed());
        }

        private void btnStallTest_Click(object sender, EventArgs e)
        {
            var flow = Task.Run(() => preflight.SystemTestStallWarning());
        }

        private void tabPreflight_Click(object sender, EventArgs e)
        {

        }

        private void btnCVRTest_Click(object sender, EventArgs e)
        {
            var flow = Task.Run(() => preflight.SystemTestVoiceRecorder());
        }

        private void btnOxygen_Click(object sender, EventArgs e)
        {
            var flow = Task.Run(() => preflight.SystemTestOxygen    ());
        }

        private void btnApDisc_Click(object sender, EventArgs e)
        {
            var flow = Task.Run(() => preflight.SystemTestAutopilotDisconnect());
        }

        private void btnFMCTest_Click(object sender, EventArgs e)
        {
            var flow = Task.Run(() => preflight.FmcRoute()) ;
        }
    }
}
