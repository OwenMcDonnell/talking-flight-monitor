using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.Settings_panels.PMDG737
{
    public partial class ctlTransponder : UserControl, iSettingsPage
    {
        public ctlTransponder()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void ctlTransponder_Load(object sender, EventArgs e)
        {
            sourceCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "XPDR_XpndrSelector_2");
            altSourceCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "XPDR_AltSourceSel_2");
            modeCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "XPDR_ModeSel");failureCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "XPDR_annunFAIL");
        }
    }
}
