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
    public partial class ctlClouds : UserControl, iPanelsPage
    {
        public ctlClouds()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void ctlClouds_Load(object sender, EventArgs e)
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

            for (int i = 0; i <= weather.CloudLayers.Count - 1; i++)
            {
                layerNumber = i + 1;
                var cloud = weather.CloudLayers[i];

                cloudLayersListBox.Items.Add($"Layer {layerNumber}. Type: {cloud.CloudType}. Coverage: {cloud.CoverageOctas}. Icing: {cloud.Icing}. Lower: {cloud.LowerAltitudeFeet}. Upper: {cloud.UpperAltitudeFeet}. Turbulence: {cloud.Turbulence}. Precip base: {cloud.PrecipitationBaseFeet}. Precip type {cloud.PrecipitationType}. Precip rate {cloud.PrecipitationRate}.");
            }

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            cloudLayersListBox.Items.Clear();
            var weather = FSUIPCConnection.WeatherServices.GetWeatherAtAircraft();
            var layerNumber = 0;

            for (int i = 0; i <= weather.CloudLayers.Count - 1; i++)
            {
                layerNumber = i + 1;
                var cloud = weather.CloudLayers[i];

                cloudLayersListBox.Items.Add($"Layer {layerNumber}. Type: {cloud.CloudType}. Coverage: {cloud.CoverageOctas}. Icing: {cloud.Icing}.Lower: {cloud. LowerAltitudeFeet}. Upper: {cloud.UpperAltitudeFeet}. Turbulence: {cloud.Turbulence}. Precip base: {cloud.PrecipitationBaseFeet}. Precip type {cloud.PrecipitationType}. Precip rate {cloud.PrecipitationRate}.");
            }

            Tolk.Output($"{weather.CloudLayers.Count} cloud layers loaded.");

        }
    }
}
