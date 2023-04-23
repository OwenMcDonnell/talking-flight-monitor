using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.Settings_panels
{
    public partial class ctlAircraftFlows : UserControl, iSettingsPage
    {
        public ctlAircraftFlows()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void ctlAircraftFlows_Load(object sender, EventArgs e)
        {
            chkAlignIRS.DataBindings.Add("Checked", Properties.Settings.Default, "PreflightAlignIRS");
            chkMuteDuringFlows.DataBindings.Add("Checked", Properties.Settings.Default, "FlowMuteSpeech");


        }
    }
}
