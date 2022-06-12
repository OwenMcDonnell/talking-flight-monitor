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
    public partial class ctlFlightRecorder : UserControl, iSettingsPage
    {
        public ctlFlightRecorder()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlFlightRecorder_Load(object sender, EventArgs e)
        {
            flightRecorderCheckBox.Checked = Properties.pmdg737_offsets.Default.FLTREC_SwNormal;
            flightRecorderLightCheckBox.Checked = Properties.pmdg737_offsets.Default.FLTREC_annunOFF;
        }

        private void flightRecorderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (flightRecorderCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FLTREC_SwNormal = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FLTREC_SwNormal = false;
            }
        }

        private void flightRecorderLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (flightRecorderLightCheckBox.Checked)
            {
                Properties.pmdg737_offsets.Default.FLTREC_annunOFF = true;
            }
            else
            {
                Properties.pmdg737_offsets.Default.FLTREC_annunOFF = false;
            }
        }
    }
}
