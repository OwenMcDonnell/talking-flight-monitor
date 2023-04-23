using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.Settings_panels.PMDG747
{
    public partial class ctlOverheadMaint_Fuel : UserControl, iSettingsPage
    {
        public ctlOverheadMaint_Fuel()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void ctlOverheadMaint_Fuel_Load(object sender, EventArgs e)
        {
            scavengeCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "FUEL_CWTScavengePump_Sw_ON");
            rsv23XferCheckBox.DataBindings.Add("Checked", Properties.pmdg747_offsets.Default, "FUEL_Reserve23Xfer_Sw_OPEN");

        }
    }
}
