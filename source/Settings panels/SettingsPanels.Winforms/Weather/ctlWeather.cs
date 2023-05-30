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
    public partial class ctlWeather : UserControl, iSettingsPage
    {
        public ctlWeather()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlWeather_Load(object sender, EventArgs e)
        {
            refreshRateNumericSpinner.DataBindings.Add("Value", Properties.Weather.Default, "weather_refresh_rate");
        }
    }
}
