using DavyKager;
using FSUIPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.Weather
{
    public partial class ctlTempratures : UserControl, iPanelsPage
    {
        public ctlTempratures()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void ctlTempratures_Load(object sender, EventArgs e)
        {

            Tolk.Load();
            FsWeather weather = null;
            if(utility.CurrentWeather == null)
            {
                weather = FSUIPCConnection.WeatherServices.GetWeatherAtAircraft();
            }
            else
            {
                weather = utility.CurrentWeather;
            }
            var layerNumber = 0;

            for (int i = 0; i <= weather.TemperatureLayers.Count - 1; i++)
            {
                layerNumber = i + 1;
                var tempratureLayer = weather.TemperatureLayers[i];

                tempratureZonesListBox.Items.Add($"Layer {layerNumber}. Base altitude: {tempratureLayer.BaseAltitudeFeet}. Temprature: {tempratureLayer.DayFahrenheit}F({tempratureLayer.DayCelsius}C). Night varience: {tempratureLayer.NightVarianceFahrenheit}F({tempratureLayer.NightVarianceCelsius}C). Dewpoint: {tempratureLayer.DewPointFahrenheit}F({tempratureLayer.DewPointCelsius}C).");
            }

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            var weather = FSUIPCConnection.WeatherServices.GetWeatherAtAircraft();
            var layerNumber = 0;

            for (int i = 0; i <= weather.TemperatureLayers.Count - 1; i++)
            {
                layerNumber = i + 1;
                var tempratureLayer = weather.TemperatureLayers[i];

                tempratureZonesListBox.Items.Add($"Layer {layerNumber}. Base altitude: {tempratureLayer.BaseAltitudeFeet}. Temprature: {tempratureLayer.DayFahrenheit}F({tempratureLayer.DayCelsius}C). Night varience: {tempratureLayer.NightVarianceFahrenheit}F({tempratureLayer.NightVarianceCelsius}C). Dewpoint: {tempratureLayer.DewPointFahrenheit}F({tempratureLayer.DewPointCelsius}C).");
            }

            Tolk.Output($"{weather.TemperatureLayers.Count} temprature layers loaded.");
        }
    }
}
