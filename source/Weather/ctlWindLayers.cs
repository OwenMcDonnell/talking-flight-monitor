﻿using DavyKager;
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
    public partial class ctlWindLayers : UserControl, iPanelsPage
    {
        public ctlWindLayers()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void ctlWindLayers_Load(object sender, EventArgs e)
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

            for (int i = 0; i <= weather.WindLayers.Count - 1; i++)
            {
                layerNumber = i + 1;
                var windLayer = weather.WindLayers[i];

                windLayersListBox.Items.Add($"Layer: {layerNumber}. Upper altitude: {windLayer.UpperAltitudeFeet}FT. Direction: {((int)windLayer.Direction)}. Speed: {windLayer.SpeedKnots} knotts. Gust: {windLayer.GustKnots} knotts. Visibility: {weather.Visibility.RangeNauticalMiles} Knottical miles. Turbulence: {windLayer.Turbulence}. Shear: {windLayer.Shear}.");
            }


        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            var weather = FSUIPCConnection.WeatherServices.GetWeatherAtAircraft();
            var layerNumber = 0;
            windLayersListBox.Items.Clear();
            for (int i = 0; i <= weather.WindLayers.Count - 1; i++)
            {
                layerNumber = i + 1;
                var windLayer = weather.WindLayers[i];

                windLayersListBox.Items.Add($"Layer: {layerNumber}. Upper altitude: {windLayer.UpperAltitudeFeet}FT. Direction: {((int)windLayer.Direction)}. Speed: {windLayer.SpeedKnots} knotts. Gust: {windLayer.GustKnots} knotts. Visibility: {weather.Visibility.RangeNauticalMiles} Knottical miles. Turbulence: {windLayer.Turbulence}. Shear: {windLayer.Shear}.");
            }
            Tolk.Output($"{weather.WindLayers.Count} wind layers loaded.");
        }
    }
}
