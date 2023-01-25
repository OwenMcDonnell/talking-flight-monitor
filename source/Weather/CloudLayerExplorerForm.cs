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
    public partial class CloudLayerExplorerForm : Form
    {
        public CloudLayerExplorerForm()
        {
            InitializeComponent();
        }

        private void CloudLayerExplorerForm_Load(object sender, EventArgs e)
        {

            var weather = FSUIPCConnection.WeatherServices.GetWeatherAtAircraft();
            var layerNumber = 0;

            for(int i = 0; i <= weather.CloudLayers.Count -1; i++)
            {
                layerNumber = i + 1;
                var cloud = weather.CloudLayers[i];

                cloudLayersListBox.Items.Add($"Layer {layerNumber}. Type: {cloud.CloudType}. Coverage: {cloud.CoverageOctas}. Icing: {cloud.Icing}.Lower: {cloud.LowerAltitudeFeet}. Upper: {cloud.UpperAltitudeFeet}. Turbulence: {cloud.Turbulence}. Precip base: {cloud.PrecipitationBaseFeet}. Precip type {cloud.PrecipitationType}. Precip rate {cloud.PrecipitationRate}.");
            }
        }
    }
}
