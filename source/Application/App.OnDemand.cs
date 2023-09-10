using tfm;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSUIPC;
using DavyKager;
using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using System.Xml.Linq;
using TimeZoneConverter;
using BingMapsSDSToolkit.GeodataAPI;

namespace tfm
{
    public partial class App: System.Windows.Application
    {

        // Spoilers.
        #region
        private void onSpoilersKey()
        {
            uint currentSpoilers = Aircraft.Spoilers.Value;
            if (currentSpoilers == 0)
            {
                Output(isGauge: false, output: "Spoilers retracted.");
            }
            else if (currentSpoilers == 4800)
            {
                Output(isGauge: false, output: "Spoilers armed.");
            }
            else if (currentSpoilers >= 5620)
            {
                Output(isGauge: false, output: $"Spoilers: {Autopilot.SpoilerPercent}");
            }
        }
        #endregion

        // Global mute
        #region
        private void OnGlobalMuteKey()
        {
            if (tfm.Properties.Settings.Default.AutomaticAnnouncements == true)
            {
                tfm.Properties.Settings.Default.AutomaticAnnouncements = false;
                Output(isGauge: false, output: "Automatic announcements disabled.");
            }
            else
            {
                tfm.Properties.Settings.Default.AutomaticAnnouncements = true;
                Output(isGauge: false, output: "Automatic announcements enabled.");
            }
        }
        #endregion

        // Gear state.
        #region
        private void onGearStateKey()
        {
            var gaugeName = "Gear";
            var isGauge = true;
            string gaugeValue;
            if (Aircraft.LandingGear.Value == 0)
            {
                gaugeValue = "up. ";
                Output(gaugeName, gaugeValue, isGauge);
            }
            if (Aircraft.LandingGear.Value == 16383)
            {
                gaugeValue = "down. ";
                Output(gaugeName, gaugeValue, isGauge);
            }
            if (Aircraft.LandingGear.Value > 0 && Aircraft.LandingGear.Value < 16383)
            {
                gaugeValue = "in motion. ";
                Output(gaugeName, gaugeValue, isGauge);
            }

        }
        #endregion

        // Flaps position.
        #region
        private void onFlapsKey()
        {
            var gaugeName = "Flaps";
            if (PMDG737Detected)
            {

                if (FlapsMoving)
                {
                    Output(isGauge: false, output: "Flaps in motion.");
                }
                else
                {
                    var gaugeValue = PMDG737Aircraft.CurrentFlapsPosition.ToString();
                    var isGauge = true;
                    Output(gaugeName, gaugeValue, isGauge);
                }
            } // PMDG 737.
            else if (PMDG747Detected)
            {
                if (FlapsMoving)
                {
                    Output(isGauge: false, output: "Flaps in motion.");
                }
                else
                {
                    var gaugeValue = PMDG747Aircraft.CurrentFlapsPosition.ToString();
                    var isGauge = true;
                    Output(gaugeName, gaugeValue, isGauge);
                }
            } // PMDG 747
            else if (PMDG777Detected)
            {
                if (FlapsMoving)
                {
                    Output(isGauge: false, output: "Flaps in motion.");
                }
                else
                {
                    var gaugeValue = PMDG777Aircraft.CurrentFlapsPosition.ToString();
                    var isGauge = true;
                    Output(gaugeName, gaugeValue, isGauge);
                }
            } // PMDG 777.
            else
            {

                double FlapsAngle = (double)Aircraft.Flaps.Value / 256d;
                var gaugeValue = FlapsAngle.ToString("f0");
                var isGauge = true;
                Output(gaugeName, gaugeValue, isGauge);
            }
        }
        #endregion

        // Toggle braille setting.
        #region
        private void onBrailleOutputKey()
        {
            if (tfm.Properties.Settings.Default.OutputBraille)
            {
                tfm.Properties.Settings.Default.OutputBraille = false;
                Output(isGauge: false, output: "Braille output disabled. ");
            }
            else
            {
                tfm.Properties.Settings.Default.OutputBraille = true;
                Output(isGauge: false, output: "Braille output enabled. ");
            }
        }
        #endregion

        // Engine thrust level.
        #region
        private void onEngineThrottleKey(int engine)
        {
            string throttleValue = null;
            string thrustValue = null;
            if (engine > Aircraft.num_engines.Value)
            {
                Output(isGauge: false, output: $"Only {Aircraft.num_engines.Value} available. ");
                return;
            }
            if (engine == 1)
            {
                double throttlePercent = (double)Aircraft.Engine1ThrottleLever.Value / 16384d * 100d;
                double thrust = Aircraft.Engine1JetThrust.Value;
                throttleValue = throttlePercent.ToString("F1");
                thrustValue = Aircraft.Engine1JetThrust.Value.ToString("F0");
                Output(isGauge: false, output: $"Engine 1: {throttleValue} percent, {thrustValue} pounds thrust.");
            }
            if (engine == 2)
            {
                double throttlePercent = (double)Aircraft.Engine2ThrottleLever.Value / 16384d * 100d;
                throttleValue = throttlePercent.ToString("F1");
                thrustValue = Aircraft.Engine2JetThrust.Value.ToString("F0");
                Output(isGauge: false, output: $"Engine 2: {throttleValue} percent, {thrustValue} pounds thrust.");
            }
            if (engine == 3)
            {
                double throttlePercent = (double)Aircraft.Engine3ThrottleLever.Value / 16384d * 100d;
                throttleValue = throttlePercent.ToString("F1");
                thrustValue = Aircraft.Engine3JetThrust.Value.ToString("F0");
                Output(isGauge: false, output: $"Engine 3: {throttleValue} percent, {thrustValue} pounds thrust.");
            }
            if (engine == 4)
            {
                double throttlePercent = (double)Aircraft.Engine4ThrottleLever.Value / 16384d * 100d;
                throttleValue = throttlePercent.ToString("F1");
                thrustValue = Aircraft.Engine4JetThrust.Value.ToString("F0");
                Output(isGauge: false, output: $"Engine 4: {throttleValue} percent, {thrustValue} pounds thrust.");

            }



        }
        #endregion

        // Ground speed.
        #region
        private void onGroundSpeedKey()
        {
            var gaugeName = "Ground speed";
            var gaugeValue = GroundSpeed.ToString();
            var isGauge = true;
            Output(gaugeName, gaugeValue, isGauge);
        }
        #endregion

        // Last simconnect message.
        #region
        private void onRepeatLastSimconnectMessage()
        {
            if (OldSimConnectMessage != null)
            {
                Output(isGauge: false, output: OldSimConnectMessage);
            }
            else
            {
                Output(isGauge: false, output: "no recent message");
            }

        }
        #endregion

        // Wind data.
        #region
        private void onWindKey()
        {
            if (FSUIPCConnection.FSUIPCVersion.Major >= 7)
            {
                double WindSpeed = (double)Aircraft.WindSpeed.Value;
                double WindDirection = (double)Aircraft.WindDirection.Value * 360d / 65536d;
                WindDirection = Math.Round(WindDirection);
                double WindGust = (double)Aircraft.WindGust.Value;
                Output(isGauge: false, output: $"Wind: {WindDirection} at {WindSpeed} knotts. Gusts at {WindGust} knotts.");
            }
            else
            {
                var weather = FSUIPCConnection.WeatherServices.GetWeatherAtAircraft();

                // StringBuilder used in wind command output.
                StringBuilder windOutput = new StringBuilder();

                // Get the current wind layer at aircraft location.
                var windLayer = weather.WindLayers.Where(x => x.UpperAltitudeFeet >= Autopilot.AslAltitude).OrderBy(x => x.UpperAltitudeFeet).FirstOrDefault();

                // No matching wind layers, so assume the layer just above surface level.
                if (windLayer == null)
                {
                    windLayer = weather.WindLayers[0];
                }

                // Build the output string based on user settings.
                if (tfm.Properties.Weather.Default.WindLayer_UpperAltitude)
                {
                    windOutput.Append($"Upper altitude: {windLayer.UpperAltitudeFeet}. ");
                }
                if (tfm.Properties.Weather.Default.WindLayer_Direction)
                {
                    windOutput.Append($"Direction: {((int)windLayer.Direction)}. ");
                }
                if (tfm.Properties.Weather.Default.WindLayer_Speed)
                {
                    windOutput.Append($"Speed: {windLayer.SpeedKnots} Knots. ");
                }
                if (tfm.Properties.Weather.Default.WindLayer_Gust)
                {
                    windOutput.Append($"Gust: {windLayer.GustKnots} knots. ");
                }
                if (tfm.Properties.Weather.Default.WindLayer_Visibility)
                {
                    windOutput.Append($"Visibility: {weather.Visibility.RangeNauticalMiles} knautical miles. ");
                }
                if (tfm.Properties.Weather.Default.WindLayer_Turbulence)
                {
                    windOutput.Append($"Turbulence: {windLayer.Turbulence}. ");
                }
                if (tfm.Properties.Weather.Default.WindLayer_Shear)
                {
                    windOutput.Append($"Shear: {windLayer.Shear}.");
                }

                // No settings are selected, so show a short message.
                if (windOutput.Length == 0)
                {
                    windOutput.Append("You must choose at least one wind element in settings.");
                }

                Output(isGauge: false, output: windOutput.ToString());
            }
        }
        #endregion

        // Cloud tracking.
        #region
        private void OnCloudKey()
        {

            /*
             * Base the ability to ascend or descend through
             * clouds based on the vertical speed of the aircraft. If the VS is below 0, we are
             * descending through the clouds, if any. If the VS
             * is above 0, then we are ascending through the clouds, if any. In cases where VS is 0, requesting
             * the cloud report should give the current cloud, if any.
             */

            if (Autopilot.VerticalSpeed >= 0)
            {
                AscendThroughClouds();
            }
            else
            {
                DescendThroughClouds();
            }
        }

        private void AscendThroughClouds()
        {

            StringBuilder cloudOutput = new StringBuilder();
            var weather = FSUIPCConnection.WeatherServices.GetWeatherAtAircraft();

            // Select the current cloud layer if any.
            var currentCloud = weather.CloudLayers.Where(x => Autopilot.AslAltitude >= x.LowerAltitudeFeet && Autopilot.AslAltitude <= x.UpperAltitudeFeet).OrderBy(x => x.LowerAltitudeFeet).FirstOrDefault();

            // Select the next cloud if any.
            var nextCloud = weather.CloudLayers.Where(x => Autopilot.AslAltitude <= x.LowerAltitudeFeet).OrderBy(x => x.LowerAltitudeFeet).FirstOrDefault();

            // Select the previous cloud if any.
            var previousCloud = weather.CloudLayers.Where(x => Autopilot.AslAltitude >= x.UpperAltitudeFeet).OrderByDescending(x => x.UpperAltitudeFeet).FirstOrDefault();

            // Flags for previous/next/current clouds.
            bool isCloudsAbove = nextCloud != null ? true : false;
            bool isCloudsBelow = previousCloud != null ? true : false;
            bool inCloud = currentCloud != null ? true : false;

            // Current cloud.
            #region "Current cloud"
            if (inCloud)
            {


                if (tfm.Properties.Weather.Default.CloudLayer_InCloud)
                {
                    cloudOutput.Append("In cloud. ");
                }

                if (tfm.Properties.Weather.Default.CloudLayer_CloudType)
                {
                    cloudOutput.Append($"Type: {currentCloud.CloudType}. ");
                }

                if (tfm.Properties.Weather.Default.CloudLayer_CloudCoverage)
                {
                    cloudOutput.Append($"Coverage: {currentCloud.CoverageOctas}. ");
                }

                if (tfm.Properties.Weather.Default.CloudLayer_Icing)
                {
                    cloudOutput.Append($"Icing: {currentCloud.Icing}. ");
                }

                if (currentCloud.PrecipitationType != FsPrecipitationType.None)
                {
                    if (tfm.Properties.Weather.Default.CloudLayer_PrecipitationRate)
                    {
                        cloudOutput.Append($"Precipitation rate: {currentCloud.PrecipitationRate}. ");
                    }
                }

                if (tfm.Properties.Weather.Default.CloudLayer_PrecipitationType)
                {
                    cloudOutput.Append($"Precipitation: {currentCloud.PrecipitationType}. ");
                }

                if (tfm.Properties.Weather.Default.CloudLayer_Turbulence)
                {
                    cloudOutput.Append($"Turbulence: {currentCloud.Turbulence}. ");
                }

                if (tfm.Properties.Weather.Default.CloudLayer_DistanceToTop)
                {
                    cloudOutput.Append($"Top: {currentCloud.UpperAltitudeFeet - Autopilot.AslAltitude} feet. ");
                }

                if (tfm.Properties.Weather.Default.CloudLayer_DistanceToBottom)
                {
                    cloudOutput.Append($"Bottom: {Autopilot.AslAltitude - currentCloud.LowerAltitudeFeet} feet. ");
                }
            }
            else
            {
                // Check if clouds are above/below.
                if (inCloud == false)
                {
                    if (tfm.Properties.Weather.Default.CloudLayer_OutOfCloud)
                    {
                        cloudOutput.Append("Not in a cloud. ");
                    }
                }

                if (isCloudsAbove)
                {
                    if (tfm.Properties.Weather.Default.CloudLayer_DistanceToCloudAbove)
                    {
                        cloudOutput.Append($"Cloud {nextCloud.LowerAltitudeFeet - Autopilot.AslAltitude} feet above. ");
                    }
                }
                else
                {
                    if (tfm.Properties.Weather.Default.CloudLayer_NoCloudsAbove)
                    {
                        cloudOutput.Append("No clouds above. ");
                    }
                }

                if (isCloudsBelow)
                {
                    if (tfm.Properties.Weather.Default.CloudLayer_DistanceToCloudBelow)
                    {
                        cloudOutput.Append($"Cloud {Autopilot.AslAltitude - previousCloud.UpperAltitudeFeet} feet below. ");
                    }
                }
                else
                {
                    if (tfm.Properties.Weather.Default.CloudLayer_NoCloudsBelow)
                    {
                        cloudOutput.Append("No clouds below. ");
                    }
                }
            }
            #endregion

            if (cloudOutput.Length == 0)
            {
                cloudOutput.Append("Nothing to announce.");
            }
            Output(isGauge: false, output: cloudOutput.ToString());
        }

        private void DescendThroughClouds()
        {

            StringBuilder cloudOutput = new StringBuilder();
            var weather = FSUIPCConnection.WeatherServices.GetWeatherAtAircraft();

            // Select the current cloud layer if any.
            var currentCloud = weather.CloudLayers.Where(x => Autopilot.AslAltitude >= x.LowerAltitudeFeet && Autopilot.AslAltitude <= x.UpperAltitudeFeet).OrderByDescending(x => x.UpperAltitudeFeet).FirstOrDefault();

            // Select the next cloud if any.
            var nextCloud = weather.CloudLayers.Where(x => Autopilot.AslAltitude >= x.UpperAltitudeFeet).OrderByDescending(x => x.UpperAltitudeFeet).FirstOrDefault();

            // Select the previous cloud if any.
            var previousCloud = weather.CloudLayers.Where(x => Autopilot.AslAltitude <= x.LowerAltitudeFeet).OrderBy(x => x.LowerAltitudeFeet).FirstOrDefault();

            // Flags for previous/next/current clouds.
            bool isCloudsAbove = previousCloud != null ? true : false;
            bool isCloudsBelow = nextCloud != null ? true : false;
            bool inCloud = currentCloud != null ? true : false;

            // Current cloud.
            #region "Current cloud"
            if (inCloud)
            {

                if (tfm.Properties.Weather.Default.CloudLayer_CloudType)
                {
                    cloudOutput.Append($"Type: {currentCloud.CloudType}. ");
                }

                if (tfm.Properties.Weather.Default.CloudLayer_CloudCoverage)
                {
                    cloudOutput.Append($"Coverage: {currentCloud.CoverageOctas}. ");
                }

                if (tfm.Properties.Weather.Default.CloudLayer_Icing)
                {
                    cloudOutput.Append($"Icing: {currentCloud.Icing}. ");
                }

                if (currentCloud.PrecipitationType != FsPrecipitationType.None)
                {
                    if (tfm.Properties.Weather.Default.CloudLayer_PrecipitationRate)
                    {
                        cloudOutput.Append($"Precipitation rate: {currentCloud.PrecipitationRate}. ");
                    }
                }

                if (tfm.Properties.Weather.Default.CloudLayer_PrecipitationType)
                {
                    cloudOutput.Append($"Precipitation: {currentCloud.PrecipitationType}. ");
                }

                if (tfm.Properties.Weather.Default.CloudLayer_Turbulence)
                {
                    cloudOutput.Append($"Turbulence: {currentCloud.Turbulence}. ");
                }

                if (tfm.Properties.Weather.Default.CloudLayer_DistanceToTop)
                {
                    cloudOutput.Append($"Top: {currentCloud.UpperAltitudeFeet - Autopilot.AslAltitude} feet. ");
                }

                if (tfm.Properties.Weather.Default.CloudLayer_DistanceToBottom)
                {
                    cloudOutput.Append($"Bottom: {Autopilot.AslAltitude - currentCloud.LowerAltitudeFeet} feet. ");
                }
            }
            else
            {

                // Check if clouds are above/below.
                if (inCloud == false)
                {
                    if (tfm.Properties.Weather.Default.CloudLayer_OutOfCloud)
                    {
                        cloudOutput.Append("Not in a cloud. ");
                    }
                }

                if (isCloudsAbove)
                {
                    if (tfm.Properties.Weather.Default.CloudLayer_DistanceToCloudAbove)
                    {
                        cloudOutput.Append($"Cloud {previousCloud.LowerAltitudeFeet - Autopilot.AslAltitude} feet above. ");
                    }
                }
                else
                {
                    if (tfm.Properties.Weather.Default.CloudLayer_NoCloudsAbove)
                    {
                        cloudOutput.Append("No clouds above. ");
                    }
                }

                if (isCloudsBelow)
                {
                    if (tfm.Properties.Weather.Default.CloudLayer_DistanceToCloudBelow)
                    {
                        cloudOutput.Append($"Cloud {Autopilot.AslAltitude - nextCloud.UpperAltitudeFeet} feet below. ");
                    }
                }
                else
                {
                    if (tfm.Properties.Weather.Default.CloudLayer_NoCloudsBelow)
                    {
                        cloudOutput.Append("No clouds below. ");
                    }
                }
            }
            #endregion

            if (cloudOutput.Length == 0)
            {
                cloudOutput.Append("Nothing to announce.");
            }
            Output(isGauge: false, output: cloudOutput.ToString());
        }

        #endregion

        // Traffic
        #region
        private void onNearbyAircraft()
        {
            // Get a reference to the AITrafficServices (for easier use)
            AITrafficServices ts = FSUIPCConnection.AITrafficServices;
            ts.UpdateExtendedPlaneIndentifiers(
                    TailNumber: false,
                    AirlineAndFlightNumber: true,
                    AircraftTypeAndModel: true,
                    AircraftTitle: false);

            // Get the latest data from FSUIPC
            Tolk.Output("please wait... ");
            ts.RefreshAITrafficInformation();

            // Get the list of all AI Traffic
            List<AIPlaneInfo> groundtraffic = ts.GroundTraffic;
            List<AIPlaneInfo> airbornTraffic = ts.AirborneTraffic;
            if (groundtraffic.Count == 0 && airbornTraffic.Count == 0)
            {
                Output(isGauge: false, output: "no traffic available. ");
            }
            else
            {
                frmNearbyAircraft frm = new frmNearbyAircraft(groundtraffic, airbornTraffic);
                frm.ShowDialog();

            }
        }

        private void onTCASGround()
        {
            Tolk.Output("not yet implemented.");
        }
        #endregion

        // Fuel.
        #region
        private void onFuelTankKey(int tank)
        {
            FSUIPCConnection.PayloadServices.RefreshData();
            if (tank > ActiveTanks.Count)
            {
                Output(isGauge: false, output: "tank not available");
            }
            else
            {
                tank = tank - 1;
                string name = ActiveTanks[tank].Tank.ToString();
                string pct = ActiveTanks[tank].LevelPercentage.ToString("F0");
                string weight = null;
                if (tfm.Properties.Settings.Default.UseMetric)
                {
                    weight = ActiveTanks[tank].WeightKgs.ToString("F0");
                }
                else
                {
                    weight = ActiveTanks[tank].WeightLbs.ToString("F0");
                }

                string gal = ActiveTanks[tank].LevelUSGallons.ToString("F0");
                if (tfm.Properties.Settings.Default.UseMetric)
                {
                    Output(isGauge: false, output: $"{name}.  {pct} percent, {weight} kilograms, {gal} gallons.");
                }
                else
                {
                    Output(isGauge: false, output: $"{name}.  {pct} percent, {weight} pounds, {gal} gallons.");
                }

            }
        }

        private void onFuelFlowKey()
        {
            int NumEngines = Aircraft.num_engines.Value;
            double eng1 = Math.Round(Aircraft.eng1_fuel_flow.Value);
            double eng2 = Math.Round(Aircraft.eng2_fuel_flow.Value);
            double eng3 = Math.Round(Aircraft.eng3_fuel_flow.Value);
            double eng4 = Math.Round(Aircraft.eng4_fuel_flow.Value);
            Output(isGauge: false, output: "Fuel flow (pounds per hour): ");
            Output(isGauge: false, output: $"Engine 1: {eng1}. ");
            if (NumEngines >= 2)
            {
                Output(isGauge: false, output: $"Engine 2: {eng2}. ");
            }
            if (NumEngines >= 3)
            {
                Output(isGauge: false, output: $"Engine 3: {eng3}. ");
            }
            if (NumEngines >= 4)
            {
                Output(isGauge: false, output: $"Engine 4: {eng4}. ");
            }

        }

        private void onFuelReportKey()
        {
            // Make a variable to make accessing the payload services object quicker
            // NOTE: The connection must already be open in order to access payload services
            PayloadServices ps = FSUIPCConnection.PayloadServices;
            // Refresh the current payload data
            ps.RefreshData();
            string TotalFuelWeight = ps.FuelWeightLbs.ToString("F1");
            string TotalFuelQuantity = ps.FuelLevelUSGallons.ToString("F1");
            Output(isGauge: false, output: $"total fuel: {TotalFuelWeight} pounds. ");
            Output(isGauge: false, output: $"{TotalFuelQuantity} gallons. ");
            double TotalFuelFlow = (double)Aircraft.eng1_fuel_flow.Value + Aircraft.eng2_fuel_flow.Value + Aircraft.eng3_fuel_flow.Value + Aircraft.eng4_fuel_flow.Value;
            TotalFuelFlow = Math.Round(TotalFuelFlow);
            Output(isGauge: false, output: $"Total fuel flow: {TotalFuelFlow}");
        }
        #endregion

        // Weight
        #region
        private void onWeightReportKey()
        {
            // Make a variable to make accessing the payload services object quicker
            // NOTE: The connection must already be open in order to access payload services
            PayloadServices ps = FSUIPCConnection.PayloadServices;
            // Refresh the current payload data
            ps.RefreshData();
            if (tfm.Properties.Settings.Default.UseMetric)
            {
                string GrossWeight = ps.GrossWeightKgs.ToString("F0");
                string EmptyWeight = ps.EmptyWeightKgs.ToString("F0");
                string FuelWeight = ps.FuelWeightKgs.ToString("F0");
                string PayloadWeight = ps.PayloadWeightKgs.ToString("F0");
                string MaxGrossWeight = ps.MaxGrossWeightKgs.ToString("F0");
                if (ps.GrossWeightKgs > ps.MaxGrossWeightKgs)
                {
                    Output(isGauge: false, output: "Overweight warning! ");
                }
                Output(isGauge: false, output: $"Fuel Weight: {FuelWeight} Kilograms");
                Output(isGauge: false, output: $"Payload Weight: {PayloadWeight} kilograms. ");
                Output(isGauge: false, output: $"Gross Weight: {GrossWeight} of {MaxGrossWeight} kilograms maximum.");

            }
            else
            {
                string GrossWeight = ps.GrossWeightLbs.ToString("F0");
                string EmptyWeight = ps.EmptyWeightLbs.ToString("F0");
                string FuelWeight = ps.FuelWeightLbs.ToString("F0");
                string PayloadWeight = ps.PayloadWeightLbs.ToString("F0");
                string MaxGrossWeight = ps.MaxGrossWeightLbs.ToString("F0");
                if (ps.GrossWeightLbs > ps.MaxGrossWeightLbs)
                {
                    Output(isGauge: false, output: "Overweight warning! ");
                }
                Output(isGauge: false, output: $"Fuel Weight: {FuelWeight} pounds");
                Output(isGauge: false, output: $"Payload Weight: {PayloadWeight} pounds. ");
                Output(isGauge: false, output: $"Gross Weight: {GrossWeight} of {MaxGrossWeight} pounds maximum.");

            }
        }
        #endregion

        // Runway guidance mode.
        #region
        private void onRunwayGuidanceKey()
        {
            if (!runwayGuidanceEnabled)
            {
                runwayGuidanceEnabled = true;
                // set up the timer
                RunwayGuidanceTimer = new System.Timers.Timer(200); // 200 milliseconds
                // Hook up the Elapsed event for the timer. 
                RunwayGuidanceTimer.Elapsed += OnRunwayGuidanceTickEvent;
                RunwayGuidanceTimer.AutoReset = true;
                RunwayGuidanceTrackedHeading = (double)Math.Round(Aircraft.CompassHeading.Value);
                Output(isGauge: false, output: $"Runway guidance enabled. current heading: {RunwayGuidanceTrackedHeading}. ");
                // play tones for 45 degrees on either side of the tracked heading
                HdgRight = RunwayGuidanceTrackedHeading + 45;
                HdgLeft = RunwayGuidanceTrackedHeading - 45;
                if (HdgRight > 360)
                {
                    HdgRight = HdgRight - 360;
                }
                if (HdgLeft < 0)
                {
                    HdgLeft = HdgLeft + 360;
                }
                // start audio
                wg = new SignalGenerator
                {
                    Type = SignalGeneratorType.Square,
                    Gain = 0.1
                };
                // set up panning provider, with the signal generator as input
                pan = new PanningSampleProvider(wg.ToMono());
                // we use an OffsetSampleProvider to allow playing beep tones
                RunwayGuidanceTimer.Enabled = true;
            }
            else
            {
                mixer.RemoveAllMixerInputs();
                RunwayGuidanceTimer.Stop();
                runwayGuidanceEnabled = false;
                Output(isGauge: false, output: "Runway Guidance disabled. ");
            }

        }
        #endregion

        private void onToggleFlapsAnnouncementKey()
        {
            if (tfm.Properties.Settings.Default.ReadFlaps)
            {
                tfm.Properties.Settings.Default.ReadFlaps = false;
                Output(isGauge: false, output: "flaps announcement disabled. ");
            }
            else
            {
                tfm.Properties.Settings.Default.ReadFlaps = true;
                Output(isGauge: false, output: "Flaps announcement enabled. ");
            }
        }

        private void onToggleILSKey()
        {
            if (tfm.Properties.Settings.Default.ReadILS == true)
            {
                tfm.Properties.Settings.Default.ReadILS = false;
                ilsTimer.Enabled = false;
                Output(isGauge: false, output: "Read ILS disabled");
            }
            else
            {
                tfm.Properties.Settings.Default.ReadILS = true;
                Output(isGauge: false, output: "Read ILS enabled");

            }
        }

        private void onGPWSKey()
        {
            if (tfm.Properties.Settings.Default.ReadGPWS == false)
            {
                tfm.Properties.Settings.Default.ReadGPWS = true;
                Output(isGauge: false, output: "GPWS enabled");
            }
            else
            {
                tfm.Properties.Settings.Default.ReadGPWS = false;
                Output(isGauge: false, output: "GPWS disabled");
            }
        }

        private void onDirectorKey()
        {
            Tolk.Output("not yet implemented.");
        }

        private void onAutopilotKey()
        {
            if (tfm.Properties.Settings.Default.ReadAutopilot)
            {
                tfm.Properties.Settings.Default.ReadAutopilot = false;
                Output(isGauge: false, output: "read autopilot instruments disabled");
            }
            else
            {
                tfm.Properties.Settings.Default.ReadAutopilot = true;
                Output(isGauge: false, output: "Read autopilot instruments enabled. ");
            }
        }

        private void onAttitudeKey()
        {
            if (!attitudeModeEnabled)
            {
                attitudeModeEnabled = true;
                // set up the timer
                AttitudeTimer = new System.Timers.Timer(150); // 200 milliseconds
                // Hook up the Elapsed event for the timer. 
                AttitudeTimer.Elapsed += OnAttitudeModeTickEvent;
                AttitudeTimer.AutoReset = true;
                Output(isGauge: false, output: "Attitude mode enabled. ");
                // start audio
                // signal generator for generating tones
                wg = new SignalGenerator
                {
                    Type = SignalGeneratorType.Square,
                    Gain = 0.1
                };
                // set up panning provider, with the signal generator as input
                pan = new PanningSampleProvider(wg.ToMono());

                pitchSineProvider = new SineWaveProvider();
                // bankSineProvider = new SineWaveProvider();
                AttitudeTimer.Enabled = true;
            }
            else
            {
                mixer.RemoveAllMixerInputs();
                AttitudePitchPlaying = false;
                AttitudeBankLeftPlaying = false;
                AttitudeBankRightPlaying = false;
                AttitudeTimer.Stop();
                attitudeModeEnabled = false;
                Output(isGauge: false, output: "Attitude mode disabled. ");
            }
        }

        private void OnDestinationKey()
        {
            if (PMDG737Detected)
            {
                var distanceToDestination = Math.Round(Aircraft.pmdg737.FMC_DistanceToDest.Value);
                try
                {
                    Output(isGauge: false, output: $"Distance to destination: {distanceToDestination}/{PMDG737Aircraft.TimeToDestination.ToString(@"d\:h\:m\:s")}");
                }
                catch (DivideByZeroException)
                {
                    Output(isGauge: false, output: "The aircraft is not moving.");
                }
                catch (OverflowException)
                {
                    Output(isGauge: false, output: "Distance to destination not available.");
                }
            } // PMDG 737
            else if (PMDG747Detected)
            {
                var distanceToDestination = Math.Round(Aircraft.pmdg747.FMC_DistanceToDest.Value);
                try
                {
                    Output(isGauge: false, output: $"Distance to destination: {distanceToDestination}/{PMDG747Aircraft.TimeToDestination.ToString(@"d\:h\:m\:s")}");
                }
                catch (DivideByZeroException)
                {
                    Output(isGauge: false, output: "The aircraft is not moving.");
                }
                catch (OverflowException)
                {
                    Output(isGauge: false, output: "Distance to destination not available.");
                }
            }
            else if (PMDG777Detected)
            {
                var distanceToDestination = Math.Round(Aircraft.pmdg777.FMC_DistanceToDest.Value);
                try
                {
                    Output(isGauge: false, output: $"Distance to destination: {distanceToDestination}/{PMDG777Aircraft.TimeToDestination.ToString(@"d\:h\:m\:s")}");
                }
                catch (DivideByZeroException)
                {
                    Output(isGauge: false, output: "The aircraft is not moving.");
                }
                catch (OverflowException)
                {
                    Output(isGauge: false, output: "Distance to destination not available.");
                }
            } // End PMDG 777.
            else
            {

                TimeSpan TimeEnroute = TimeSpan.FromSeconds(Aircraft.DestinationTimeEnroute.Value);
                string strTime = string.Format("{0:%h} hours {0:%m} minutes, {0:%s} seconds", TimeEnroute);
                if (TimeEnroute.Hours == 0)
                {
                    strTime = string.Format("{0:%m} minutes, {0:%s} seconds", TimeEnroute);
                }
                if (TimeEnroute.Minutes == 0 && TimeEnroute.Hours == 0)
                {
                    strTime = string.Format("{0:%s} seconds", TimeEnroute);
                }
                Output(isGauge: false, output: $"Time enroute to destination, {strTime}. ");

            }
        }

        private void onTODKey()
        {
            if (PMDG737Detected)
            {
                var tod = Math.Round(Aircraft.pmdg737.FMC_DistanceToTOD.Value);
                try
                {
                    Output(isGauge: false, output: $"Distance to descent: {tod}/{PMDG737Aircraft.TimeToTOD.ToString(@"d\:h\:m\:s")}");
                }
                catch (DivideByZeroException)
                {
                    Output(isGauge: false, output: "The aircraft is not moving.");
                }
                catch (OverflowException)
                {
                    Output(isGauge: false, output: "Distance to descent not available.");
                }
            } // PMDG 737
            else if (PMDG747Detected)
            {
                var tod = Math.Round(Aircraft.pmdg747.FMC_DistanceToTOD.Value);
                try
                {
                    Output(isGauge: false, output: $"Distance to descent: {tod}/{PMDG747Aircraft.TimeToTOD.ToString(@"d\:h\:m\:s")}");
                }
                catch (DivideByZeroException)
                {
                    Output(isGauge: false, output: "The aircraft is not moving.");
                }
                catch (OverflowException)
                {
                    Output(isGauge: false, output: "Distance to descent not available.");
                }
            }
            else if (PMDG777Detected)
            {
                var tod = Math.Round(Aircraft.pmdg777.FMC_DistanceToTOD.Value);
                try
                {
                    Output(isGauge: false, output: $"Distance to descent: {tod}/{PMDG777Aircraft.TimeToTOD.ToString(@"d\:h\:m\:s")}");
                }
                catch (DivideByZeroException)
                {
                    Output(isGauge: false, output: "The aircraft is not moving.");
                }
                catch (OverflowException)
                {
                    Output(isGauge: false, output: "Distance to descent not available.");
                }
            } // End PMDG 777.
            else
            {
                return;
            }
        }

        private void OnWaypointKey()
        {
            if (tfm.Properties.Settings.Default.IsSimBriefEnabled && tfm.Properties.Settings.Default.IsSimBriefUserIDValid)
            {
                ReadSimBriefWaypoint();
            }
            else
            {
                ReadWayPoint();
            }
        }


        private void ReadSimBriefWaypoint()
        {
            double groundSpeed = ((double)Aircraft.GroundSpeed.Value * 3600d) / (65536d * 1852d);
            FsLatLonPoint currentLocation = new FsLatLonPoint(Aircraft.aircraftLat.Value, Aircraft.aircraftLon.Value);
            var target = new FsLatLonPoint(FlightPlan.Navlog[0].Latitude, FlightPlan.Navlog[0].Longitude);
            var distance = Math.Round(currentLocation.DistanceFromInNauticalMiles(target), 0);
            var bearing = Math.Round(currentLocation.BearingTo(target), 0);

            try
            {

                groundSpeed = Math.Round(groundSpeed, 0);
                double time = distance / groundSpeed;
                var timeToNext = TimeSpan.FromHours(time);

                Output(isGauge: false, output: $"Next waypoint: {FlightPlan.Navlog[0].Name}. Bearing {bearing} degrees. Distance {distance} nautical miles. Time: {timeToNext.ToString(@"d\:h\:m\:s")}");
            }
            catch (DivideByZeroException)
            {
                Output(isGauge: false, output: $"Next waypoint: {FlightPlan.Navlog[0].Name}. Bearing {bearing} degrees. Distance {distance} nautical miles. Time: Not available.");
            }
            catch (OverflowException)
            {
                Output(isGauge: false, output: $"Next waypoint: {FlightPlan.Navlog[0].Name}. Bearing {bearing} degrees. Distance {distance} nautical miles. Time: Not available.");
            }
        }

        private void OnCityKey()
        {
            double lat = Aircraft.aircraftLat.Value.DecimalDegrees;
            double lon = Aircraft.aircraftLon.Value.DecimalDegrees;
            // double lat = -48.876667;
            // double lon = -123.393333;
            if (tfm.Properties.Settings.Default.GeonamesUsername == "")
            {
                Output(isGauge: false, output: "geonames username not configured");
                return;
            }
            var geonamesUser = tfm.Properties.Settings.Default.GeonamesUsername;
            if (tfm.Properties.Settings.Default.FlightFollowingOffline)
            {
                var pos = r.CreateFromLatLong(lat, lon);
                var results = r.NearestNeighbourSearch(pos, 1);
                foreach (var res in results)
                {
                    Tolk.Output(res.Name);
                    Tolk.Output(res.Admincodes[1]);
                }
            }
            else
            {
                try
                {

                    var xmlNearby = XElement.Load($"http://api.geonames.org/findNearbyPlaceName?style=long&lat={lat}&lng={lon}&username={geonamesUser}&cities=cities1000&radius=200");
                    var locations = xmlNearby.Descendants("geoname").Select(g => new
                    {
                        Name = g.Element("name").Value,
                        Lat = g.Element("lat").Value,
                        Long = g.Element("lng").Value,
                        admin1 = g.Element("adminName1").Value,
                        countryName = g.Element("countryName").Value
                    });
                    if (locations.Count() > 0)
                    {
                        var location = locations.First();
                        // get the current magnetic variation
                        double magVarDegrees = (double)Aircraft.MagneticVariation.Value * 360d / 65536d;
                        // create a point for the aircraft current position
                        FsLatLonPoint aircraftPos = new FsLatLonPoint(Aircraft.aircraftLat.Value, Aircraft.aircraftLon.Value);
                        // create a point for the nearest city
                        double nearestCityLat = double.Parse(location.Lat);
                        double nearestCityLong = double.Parse(location.Long);
                        FsLatLonPoint nearestCityPoint = new FsLatLonPoint(nearestCityLat, nearestCityLong);
                        string distanceNM = aircraftPos.DistanceFromInNauticalMiles(nearestCityPoint).ToString("F1");
                        double bearingTrue = aircraftPos.BearingTo(nearestCityPoint);
                        double bearingMagnetic = bearingTrue - magVarDegrees;
                        string strBearing = bearingMagnetic.ToString("F0");
                        Output(isGauge: false, output: $"{location.Name} {location.admin1}, {location.countryName}. ");
                        Output(isGauge: false, output: $"{distanceNM} nautical miles, {strBearing} degrees.");
                    }
                    else
                    {
                        Output(isGauge: false, output: $"No city nearby.");
                    }
                }
                catch (Exception ex)
                {
                    Logger.Debug($"error retrieving nearest city: {ex.Message}");
                    Tolk.Output("error retrieving nearest city. check log.");
                }
                try
                {
                    var xmlOcean = XElement.Load($"http://api.geonames.org/ocean?lat={lat}&lng={lon}&username={geonamesUser}");
                    var ocean = xmlOcean.Descendants("ocean").Select(g => new
                    {
                        Name = g.Element("name").Value
                    });
                    if (ocean.Count() > 0)
                    {
                        var currentOcean = ocean.First();
                        Output(isGauge: false, output: $"{currentOcean.Name}. ");
                    }

                }
                catch (Exception ex)
                {
                    Logger.Debug($"error retrieving oceanic info: {ex.Message}");

                }
                var xmlTimezone = XElement.Load($"http://api.geonames.org/timezone?lat={lat}&lng={lon}&username={geonamesUser}&radius=50");
                var timezone = xmlTimezone.Descendants("timezone").Select(g => new
                {
                    Name = g.Element("timezoneId").Value
                });
                if (timezone.Count() > 0)
                {
                    var currentTimezone = timezone.First();
                    if (currentTimezone.Name != oldTimezone)
                    {
                        try
                        {
                            string tzName = TZConvert.IanaToWindows(currentTimezone.Name);
                            Output(isGauge: false, output: $"{tzName}. ");
                        }
                        catch (Exception)
                        {

                            Logger.Debug($"cannot convert timezone: {currentTimezone.Name}");
                        }

                        oldTimezone = currentTimezone.Name;
                    }

                }


            }
        }
        private void OnMuteSimconnectKey()
        {
            if (muteSimconnect)
            {
                muteSimconnect = false;
                Output(isGauge: false, output: "SimConnect messages unmuted. ");
            }
            else
            {
                muteSimconnect = true;
                Output(isGauge: false, output: "SimConnect messages muted.");
            }
            ResetHotkeys();
        }

        private void onTrimKey()
        {
            if (TrimEnabled)
            {
                TrimEnabled = false;
                Output(isGauge: false, output: "read trim disabled. ");
            }
            else
            {
                TrimEnabled = true;
                Output(isGauge: false, output: "trim enabled. ");
            }
            ResetHotkeys();
        }

        private void onAirtempKey()
        {
            double tempC = (double)Aircraft.AirTemp.Value / 256d;
            double tempF = 9.0 / 5.0 * tempC + 32;
            var gaugeName = "Outside temperature";
            var isGauge = true;
            string gaugeValue;
            if (tfm.Properties.Settings.Default.UseMetric)
            {
                gaugeValue = tempC.ToString("F0");
            }
            else
            {
                gaugeValue = tempF.ToString("F0");
            }
            Output(gaugeName, gaugeValue, isGauge);
        }

        private void OnVSpeedKey()
        {
            double vspeed = (double)Aircraft.VerticalSpeed.Value * 3.28084d * -1;

            // used in the onScreenReaderOutput event in the main form.
            var gageName = "Vertical speed";
            var gageValue = vspeed.ToString("f0");
            var isGage = true;

            //Tolk.Output(vspeed.ToString("f0") + " feet per minute. ");
            // Test the new event.
            Output(gageName, gageValue, isGage);
            ResetHotkeys();

        }
        private void OnLandingRateKey()
        {
            // convert FSUIPC unit to expected FPM value
            double vspd = Math.Round(Aircraft.LandingRate.Value * 60 * 3.28084 / 256);
            Output(isGauge: false, output: $"Landing Rate: {vspd} Feet per minute");

        }
        private void OnMachKey()
        {
            double mach = (double)Aircraft.AirspeedMach.Value / 20480d;
            var gaugeName = "Mach";
            var isGauge = true;
            var gaugeValue = mach.ToString("F2");
            Output(gaugeName, gaugeValue, isGauge);

        }

        private void OnTASKey()
        {
            double tas = (double)Aircraft.AirspeedTrue.Value / 128d;
            var gaugeName = "Airspeed true";
            var isGauge = true;
            var gaugeValue = tas.ToString("F0");
            Output(gaugeName, gaugeValue, isGauge);
        }

        private void OnIASKey()
        {
            double ias = (double)Aircraft.AirspeedIndicated.Value / 128d;
            var gaugeName = "Airspeed indicated";
            var isGauge = true;
            var gaugeValue = ias.ToString("F0");
            Output(gaugeName, gaugeValue, isGauge);
        }

        private void OnHeadingKey()
        {
            Output(isGauge: false, output: "heading: " + Autopilot.Heading);
            ResetHotkeys();
        }

        private void OnAGLKey()
        {
            double groundAlt = (double)Aircraft.GroundAltitude.Value / 256d * 3.28084d;
            double agl = (double)Aircraft.Altitude.Value - groundAlt;
            var gaugeName = "AGL altitude";
            var isGauge = true;
            var gaugeValue = Math.Round(agl, 0).ToString();
            Output(gaugeName, gaugeValue, isGauge);
        }

        private void OnASLKey()
        {
            double asl = Math.Round((double)Aircraft.Altitude.Value, 0);
            var gaugeName = "ASL altitude";
            var gaugeValue = asl.ToString("F0");
            var isGauge = true;
            Output(gaugeName, gaugeValue, isGauge);
        }


        private void OnEngineInfoKey(int eng)
        {
            double N1 = 0;
            double N2 = 0;
            bool metric = tfm.Properties.Settings.Default.UseMetric;
            string output = null;
            // check engine type. 0 - piston, 1- jet
            if (Aircraft.EngineType.Value == 0)
            {
                double cht;
                double egt;
                double manifold;
                double rpm;
                string units;
                switch (eng)
                {
                    case 1:
                        // FSUIPC represents EGT in degrees Rankine, so we need to convert
                        egt = Aircraft.Engine1EGT.Value;
                        if (metric == true)
                        {
                            egt = Math.Round((egt - 491.67) * 5d / 9d);
                        }
                        else
                        {
                            egt = Math.Round(egt - 459.67);
                        }
                        cht = Aircraft.Engine1CHT.Value;
                        if (tfm.Properties.Settings.Default.UseMetric == true)
                        {
                            cht = Math.Round((cht - 32) * 5 / 9);
                            units = "C";
                        }
                        else
                        {
                            cht = Math.Round(cht);
                            units = "F";
                        }
                        rpm = Math.Round(Aircraft.Engine1RPM.Value);
                        manifold = Aircraft.Engine1ManifoldPressure.Value / 1024;
                        output = $"Engine 1: CHT: {cht} {units}, EGT: {egt} {units}, RPM: {rpm}, manifold: {manifold} inches. ";
                        Output(isGauge: false, output: output);
                        break;

                    case 2:
                        // FSUIPC represents EGT in degrees Rankine, so we need to convert
                        egt = Aircraft.Engine2EGT.Value;
                        if (metric == true)
                        {
                            egt = Math.Round((egt - 491.67) * 5d / 9d);
                        }
                        else
                        {
                            egt = Math.Round(egt - 459.67);
                        }
                        cht = Aircraft.Engine2CHT.Value;
                        if (tfm.Properties.Settings.Default.UseMetric == true)
                        {
                            cht = Math.Round((cht - 32) * 5 / 9);
                            units = "C";
                        }
                        else
                        {
                            cht = Math.Round(cht);
                            units = "F";
                        }
                        rpm = Math.Round(Aircraft.Engine2RPM.Value);
                        manifold = Aircraft.Engine2ManifoldPressure.Value / 1024;
                        output = $"Engine 2: CHT: {cht} {units}, EGT: {egt} {units}, RPM: {rpm}, manifold: {manifold} inches. ";
                        Output(isGauge: false, output: output);
                        break;

                    case 3:
                        // FSUIPC represents EGT in degrees Rankine, so we need to convert
                        egt = Aircraft.Engine3EGT.Value;
                        if (metric == true)
                        {
                            egt = Math.Round((egt - 491.67) * 5d / 9d);
                        }
                        else
                        {
                            egt = Math.Round(egt - 459.67);
                        }
                        cht = Aircraft.Engine3CHT.Value;
                        if (tfm.Properties.Settings.Default.UseMetric == true)
                        {
                            cht = Math.Round((cht - 32) * 5 / 9);
                            units = "C";
                        }
                        else
                        {
                            cht = Math.Round(cht);
                            units = "F";
                        }
                        rpm = Math.Round(Aircraft.Engine3RPM.Value);
                        manifold = Aircraft.Engine3ManifoldPressure.Value / 1024;
                        output = $"Engine 3: CHT: {cht} {units}, EGT: {egt} {units}, RPM: {rpm}, manifold: {manifold} inches. ";
                        Output(isGauge: false, output: output);
                        break;

                    case 4:
                        // FSUIPC represents EGT in degrees Rankine, so we need to convert
                        egt = Aircraft.Engine4EGT.Value;
                        if (metric == true)
                        {
                            egt = Math.Round((egt - 491.67) * 5d / 9d);
                        }
                        else
                        {
                            egt = Math.Round(egt - 459.67);
                        }
                        cht = Aircraft.Engine4CHT.Value;
                        if (tfm.Properties.Settings.Default.UseMetric == true)
                        {
                            cht = Math.Round((cht - 32) * 5 / 9);
                            units = "C";
                        }
                        else
                        {
                            cht = Math.Round(cht);
                            units = "F";
                        }
                        rpm = Math.Round(Aircraft.Engine4RPM.Value);
                        manifold = Aircraft.Engine4ManifoldPressure.Value / 1024;
                        output = $"Engine 4: CHT: {cht} {units}, EGT: {egt} {units}, RPM: {rpm}, manifold: {manifold} inches. ";
                        Output(isGauge: false, output: output);
                        break;
                }
            }
            if (Aircraft.EngineType.Value == 1)
            {
                switch (eng)
                {
                    case 1:
                        N1 = (double)Aircraft.Eng1N1.Value;
                        N2 = (double)Aircraft.Eng1N2.Value;
                        break;
                    case 2:
                        N1 = (double)Aircraft.Eng2N1.Value;
                        N2 = (double)Aircraft.Eng2N2.Value;
                        break;
                    case 3:
                        N1 = (double)Aircraft.Eng3N1.Value;
                        N2 = (double)Aircraft.Eng3N2.Value;
                        break;
                    case 4:
                        N1 = (double)Aircraft.Eng4N1.Value;
                        N2 = (double)Aircraft.Eng4N2.Value;
                        break;
                }
                Output(isGauge: false, output: $"Engine {eng}. ");
                Output(isGauge: false, output: $"N1: {Math.Round(N1)}. ");
                Output(isGauge: false, output: $"N2: {Math.Round(N2)}. ");
            }

        }

        /// <summary>
        /// TODO: Rework current location feature.
        /// </summary>
        private async void OnCurrentLocation()
        {
            var database = FSUIPCConnection.AirportsDatabase;
            var currentLocation = database.Airports.GetPlayerLocation(AirportComponents.Gates | AirportComponents.Runways | AirportComponents.Taxiways);

            // Check to see if we are on the ground
            if (currentLocation != null && currentLocation.OnGround)
            {
                if (currentLocation.Runway != null && currentLocation.Runway.IsPlayerOnRunway)
                {
                    Output(isGauge: false, output: $"Runway {currentLocation.Runway.ID}@{currentLocation.Airport.ICAO}/{currentLocation.Runway.LengthFeet}");
                }
                else if (currentLocation.Gate != null && currentLocation.Gate.IsPlayerAtGate)
                {
                    Output(isGauge: false, output: $"Gate {currentLocation.Gate.ID}@{currentLocation.Airport.ICAO}");
                }
                else if (currentLocation.Taxiway != null && currentLocation.Taxiway.IsPlayerOnTaxiway)
                {
                    Output(isGauge: false, output: $"Taxiway {currentLocation.Taxiway.Name}@{currentLocation.Airport.ICAO}");
                }
                else if (currentLocation.Gate == null && currentLocation.Taxiway == null && currentLocation.Runway == null && currentLocation.Airport.IsPlayerAtAirport)
                {
                    Output(isGauge: false, output: $"@{currentLocation.Airport.ICAO}");
                }
                else if (currentLocation.Airport == null)
                {
                    Output(isGauge: false, output: "Not at an airport.");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(tfm.Properties.Settings.Default.bingMapsAPIKey))
                {
                    Output(isGauge: false, output: "Please set the Bing Maps API key in settings before using the where am I feature.");
                    return;
                } // Sanity check on api keys.
                var latitude = Aircraft.aircraftLat.Value.DecimalDegrees;
                var longitude = Aircraft.aircraftLon.Value.DecimalDegrees;
                // Retrieve the state/province/territory.
                var cityRequest = new GetBoundaryRequest()
                {
                    EntityType = BoundaryEntityType.AdminDivision2,
                    LevelOfDetail = 3,
                    GetAllPolygons = true,
                    GetEntityMetadata = true,
                    Coordinate = new BingMapsSDSToolkit.GeodataLocation(latitude, longitude)
                };

                var stateRequest = new GetBoundaryRequest()
                {
                    EntityType = BoundaryEntityType.AdminDivision1,
                    LevelOfDetail = 3,
                    GetAllPolygons = true,
                    GetEntityMetadata = true,
                    Coordinate = new BingMapsSDSToolkit.GeodataLocation(latitude, longitude)
                };

                var countryRequest = new GetBoundaryRequest()
                {
                    EntityType = BoundaryEntityType.CountryRegion,
                    LevelOfDetail = 3,
                    GetAllPolygons = true,
                    GetEntityMetadata = true,
                    Coordinate = new BingMapsSDSToolkit.GeodataLocation(latitude, longitude)
                };
                var cityResponse = await GeodataManager.GetBoundary(cityRequest, tfm.Properties.Settings.Default.bingMapsAPIKey);
                var stateResponse = await GeodataManager.GetBoundary(stateRequest, tfm.Properties.Settings.Default.bingMapsAPIKey);
                var countryResponse = await GeodataManager.GetBoundary(countryRequest, tfm.Properties.Settings.Default.bingMapsAPIKey);

                // Check for existence of a country. If none present, most likely we are in a body of water.
                if (countryResponse == null)
                {
                    if (string.IsNullOrWhiteSpace(tfm.Properties.Settings.Default.GeonamesUsername))
                    {
                        Output(isGauge: false, output: "You must have a Geonames username to use this feature.");
                        return;
                    }
                    try
                    {
                        var xmlOcean = XElement.Load($"http://api.geonames.org/ocean?lat={latitude}&lng={longitude}&username={tfm.Properties.Settings.Default.GeonamesUsername}");
                        var ocean = xmlOcean.Descendants("ocean").Select(g => new
                        {
                            Name = g.Element("name").Value
                        });
                        if (ocean.Count() > 0)
                        {
                            var currentOcean = ocean.First();
                            Output(isGauge: false, output: $"{currentOcean.Name}. ");
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Debug($"error retrieving oceanic info: {ex.Message}");

                    }
                }
                else
                {
                    Output(isGauge: false, output: $"{cityResponse[0].Name.EntityName} {stateResponse[0].Name.EntityName}, {countryResponse[0].Name.EntityName}");
                }
                var xmlTimezone = XElement.Load($"http://api.geonames.org/timezone?lat={latitude}&lng={longitude}&username={tfm.Properties.Settings.Default.GeonamesUsername}&radius=50");
                var timezone = xmlTimezone.Descendants("timezone").Select(g => new
                {
                    Name = g.Element("timezoneId").Value
                });
                if (timezone.Count() > 0)
                {
                    var currentTimezone = timezone.First();
                    if (currentTimezone.Name != oldTimezone)
                    {
                        try
                        {
                            string tzName = TZConvert.IanaToWindows(currentTimezone.Name);
                            Output(isGauge: false, output: $"{tzName}. ");
                        }
                        catch (Exception)
                        {

                            Logger.Debug($"cannot convert timezone: {currentTimezone.Name}");
                        }
                    }
                    oldTimezone = currentTimezone.Name;
                }
            }
        }

        public void ReadPmdgFMCMessage(string? type = null)
        {
            PMDG_NGX_CDU_Screen cDU_Screen = new PMDG_NGX_CDU_Screen(0x5400);
            string message = string.Empty;

            if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("737"))
            {
                if (Aircraft.pmdg737.CDU_annunMSG[0].Value == 1)
                {
                    cDU_Screen.RefreshData();
                    message = cDU_Screen.Rows[13].ToString();
                }
            } // End 737 check.
            else if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("747"))
            {
                if (Aircraft.pmdg747.CDU_annunMSG[0].Value == 1)
                {
                    cDU_Screen.RefreshData();
                    message = cDU_Screen.Rows[13].ToString();
                }
            } // End 747 check.
            else if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("777"))
            {
                if (Aircraft.pmdg777.CDU_annunMSG[0].Value == 1)
                {
                    cDU_Screen.RefreshData();
                    message = cDU_Screen.Rows[13].ToString();
                }
            } // End 777 check.
            if (type == "requested")
            {
                Output(isGauge: false, useSAPI: true, output: message);
            } // End requested.
            else
            {
                if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("737"))
                {

                    if (Aircraft.pmdg737.CDU_annunMSG[0].ValueChanged)
                    {
                        switch (Aircraft.pmdg737.CDU_annunMSG[0].Value)
                        {
                            case 1:
                                Thread.Sleep(1000);
                                cDU_Screen.RefreshData();

                                Output(isGauge: false, useSAPI: true, output: $"{cDU_Screen.Rows[13].ToString()}");
                                break;
                        }
                    }
                } // End 737 check.
                if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("747"))
                {

                    if (Aircraft.pmdg747.CDU_annunMSG[0].ValueChanged)
                    {
                        switch (Aircraft.pmdg747.CDU_annunMSG[0].Value)
                        {
                            case 1:
                                cDU_Screen.RefreshData();
                                Output(isGauge: false, useSAPI: true, output: $"{cDU_Screen.Rows[13].ToString()}");
                                break;
                        }
                    }
                } // End 747 check.
                if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("777"))
                {

                    if (Aircraft.pmdg777.CDU_annunMSG[0].ValueChanged)
                    {
                        switch (Aircraft.pmdg777.CDU_annunMSG[0].Value)
                        {
                            case 1:
                                Thread.Sleep(1000);
                                cDU_Screen.RefreshData();
                                Output(isGauge: false, useSAPI: true, output: $"{cDU_Screen.Rows[13].ToString()}");
                                break;
                        }
                    }
                } // End 777 check.
            } // End else
        } // End ReadPmdgFmcMessage.

        private void ReadSimulatorTime()
        {


            Speak($"{Aircraft.simulatorTimeHours.Value}:{Aircraft.simulatorTimeMinutes.Value}:{Aircraft.simulatorTimeSeconds.Value}");
        } // ReadSimulatorTime

        private void ReadSimulatorZuluTime()
        {

        } // ReadSimulatorZuluTime

        public void OnDestinationRunway()
        {
            if (FlightPlan.DestinationRunway != null)
            {
                FlightPlan.DestinationRunway.Airport.SetReferenceLocation(AirportComponents.Runways);
                var ID = FlightPlan.DestinationRunway.ID.ToString();
                var course = Math.Round(FlightPlan.DestinationRunway.ILSInfo.Heading, 0);
                var threshholdDistanceNauticalMiles = Math.Round(FlightPlan.DestinationRunway.ThresholdLocation.DistanceFromInNauticalMiles(new FsLatLonPoint(Aircraft.aircraftLat.Value, Aircraft.aircraftLon.Value)), 0);
                var threshholdDistanceFeet = Math.Round(FlightPlan.DestinationRunway.ThresholdLocation.DistanceFromInFeet(new FsLatLonPoint(Aircraft.aircraftLat.Value, Aircraft.aircraftLon.Value)), 0);
                var bearingTo = Math.Round(FlightPlan.DestinationRunway.ThresholdLocation.BearingTo(new FsLatLonPoint(Aircraft.aircraftLat.Value, Aircraft.aircraftLon.Value)), 0);
                var distance = threshholdDistanceNauticalMiles <= 1 ? threshholdDistanceFeet : threshholdDistanceNauticalMiles;
                var distanceSuffix = threshholdDistanceNauticalMiles <= 1 ? "FT" : "NM";
                Output(isGauge: false, output: $"RWY: {ID}. CRS: {course} degrees. Bearing {bearingTo} degrees. Thd: {distance}{distanceSuffix}.");
            }
            else
            {
                Output(isGauge: false, output: "No destination runway assigned.");
            }
        }


    }
}
