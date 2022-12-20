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
    public partial class ctlAFS : UserControl, iSettingsPage
    {
        public ctlAFS()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlAFS_Load(object sender, EventArgs e)
        {

            servosCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AFS_AutothrottleServosConnected");
            pitchCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AFS_ControlsPitch");
            rollCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "AFS_ControlsRoll");
        }
    }
}
