using DavyKager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm
{
    public partial class ctlAircraft : UserControl, iSettingsPage
    {
        public ctlAircraft()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void ctlAircraft_Load(object sender, EventArgs e)
        {
switch(Properties.Settings.Default.takeOffAssistMode)
            {
                case "off":
                    takeoffAssistDropDown.SelectedIndex = 0;
                    break;
                case "partial":
                    takeoffAssistDropDown.SelectedIndex = 1;
                    break;
                case "full":
                    takeoffAssistDropDown.SelectedIndex = 2;
                    break;
                default:
                    MessageBox.Show("There is a problem loading aircraft settings. Try again later.");
                    break;                    
            }

            readLocaliserHeadingsCheckBox.Checked = Properties.Settings.Default.ReadLocaliserHeadingOffsets;
            readGSAltitudeCheckBox.Checked = Properties.Settings.Default.ReadGSAltitude;
        }

        private void takeoffAssistDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Tolk.DetectScreenReader() == "NVDA")
            {
                Tolk.Output(takeoffAssistDropDown.SelectedItem.ToString());
            }
                        switch(takeoffAssistDropDown.SelectedIndex)
            {
                case 0:
                    Properties.Settings.Default.takeOffAssistMode = "off";
                    break;
                case 1:
                    Properties.Settings.Default.takeOffAssistMode = "partial";
                    break;
                case 2:
                    Properties.Settings.Default.takeOffAssistMode = "full";
                    break;
default:
                    MessageBox.Show("There is a problem displaying aircraft settings. Try again later.");
                    break;
            }
        }

        private void readLocaliserHeadingsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (readLocaliserHeadingsCheckBox.Checked)
            {
                Properties.Settings.Default.ReadLocaliserHeadingOffsets = true;
            }
            else
            {
                Properties.Settings.Default.ReadLocaliserHeadingOffsets = false;
            }
        }

        private void readGSAltitudeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (readGSAltitudeCheckBox.Checked)
            {
                Properties.Settings.Default.ReadGSAltitude = true;
            }
            else
            {
                Properties.Settings.Default.ReadGSAltitude = false;
            }
        }
    }
}
