using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.Settings_panels.Weather
{
    public partial class WindSnadshot : UserControl, iSettingsPage
    {
        public WindSnadshot()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void WindSnadshot_Load(object sender, EventArgs e)
        {
            upperAltitudeCheckBox.DataBindings.Add("Checked", Properties.Weather.Default, "WindLayer_UpperAltitude");
            directionCheckBox.DataBindings.Add("Checked", Properties.Weather.Default, "WindLayer_Direction");
            speedCheckBox.DataBindings.Add("Checked", Properties.Weather.Default, "WindLayer_Speed");
            gustsCheckBox.DataBindings.Add("Checked", Properties.Weather.Default, "WindLayer_Gust");
            visibilityCheckBox.DataBindings.Add("Checked", Properties.Weather.Default, "WindLayer_Visibility");
            turbulenceCheckBox.DataBindings.Add("Checked", Properties.Weather.Default, "WindLayer_Turbulence");
            shearCheckBox.DataBindings.Add("Checked", Properties.Weather.Default, "WindLayer_Shear");
        }

        private void upperAltitudeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (upperAltitudeCheckBox.Checked)
            {
                Properties.Weather.Default.WindLayer_UpperAltitude = true;
            }
            else
            {
                Properties.Weather.Default.WindLayer_UpperAltitude = false;
            }
        }
    }
}
