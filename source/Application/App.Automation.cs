using DavyKager;
using FSUIPC;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

using tfm.PMDG.PanelObjects;

namespace tfm
{
    public partial class App: System.Windows.Application
    {

        private void onWaypointTransitionTimerTick(object sender, ElapsedEventArgs e)
        {
            waypointTransition = false;
            readWaypointFlag = true;
        }

        private void onFlightFollowingTimerTick(object sender, ElapsedEventArgs e)
        {
            // this just reads the flight following info, same as the hotkey

            if (Properties.Settings.Default.GeonamesUsername == "") return;
            OnCityKey();
        }

        public void ReadAircraftState()
        {
            // If this is the first time through the loop, don't read instruments.

            if (!FirstRun || InstrumentationEnabled)
            {
                // Read when aircraft changes
                if (Aircraft.AircraftName.ValueChanged)
                {
                    string name = Aircraft.AircraftName.Value;
                    Output(isGauge: false, output: "Current aircraft: " + Aircraft.AircraftName.Value);
                    if (name.Contains("PMDG"))
                    {
                        if (name.Contains("737"))
                        {
                            PMDG737Detected = true;
                        }
                        if (name.Contains("747"))
                        {
                            PMDG747Detected = true;
                        }
                        if (name.Contains("777"))
                        {
                            PMDG777Detected = true;
                        }

                    }
                    DetectFuelTanks();
                }

                // read any instruments that are toggles
                ReadToggle(Aircraft.SimPauseIndicator, Aircraft.SimPauseIndicator.Value > 0, "", "paused", "unpaused");
                ReadToggle(Aircraft.SimSoundFlag, Aircraft.SimSoundFlag.Value > 0, "sound", "on", "off");
                ReadToggle(Aircraft.AvionicsMaster, Aircraft.AvionicsMaster.Value > 0, "avionics master", "active", "off");
                ReadToggle(Aircraft.SeatbeltSign, Aircraft.SeatbeltSign.Value > 0, "seatbelt sign", "on", "off");
                ReadToggle(Aircraft.NoSmokingSign, Aircraft.NoSmokingSign.Value > 0, "no smoking sign", "on", "off");
                ReadToggle(Aircraft.PitotHeat, Aircraft.PitotHeat.Value > 0, "Pitot Heat", "on", "off");
                ReadToggle(Aircraft.ParkingBrake, Aircraft.ParkingBrake.Value > 0, "Parking brake", "on", "off");
                ReadToggle(Aircraft.AutoFeather, Aircraft.AutoFeather.Value > 0, "Auto Feather", "Active", "off");
                ReadToggle(Aircraft.ApMaster, Aircraft.ApMaster.Value > 0, "Auto pilot master", "active", "off");
                ReadToggle(Aircraft.AutoThrottleArm, Aircraft.AutoThrottleArm.Value > 0, "Auto Throttle", "Armed", "off");
                ReadToggle(Aircraft.ApYawDamper, Aircraft.ApYawDamper.Value > 0, "Yaw Damper", "active", "off");
                ReadToggle(Aircraft.Toga, Aircraft.Toga.Value > 0, "take off power", "active", "off");
                // if approach mode is on, read altitude and heading lock using SAPI
                if (Aircraft.ApApproachHold.Value == 1)
                {
                    ReadToggle(Aircraft.ApAltitudeLock, Aircraft.ApAltitudeLock.Value > 0, "altitude lock", "active", "off", true);
                    ReadToggle(Aircraft.ApHeadingLock, Aircraft.ApHeadingLock.Value > 0, "Heading lock", "active", "off", true);
                }
                else
                {
                    ReadToggle(Aircraft.ApAltitudeLock, Aircraft.ApAltitudeLock.Value > 0, "altitude lock", "active", "off");
                    ReadToggle(Aircraft.ApHeadingLock, Aircraft.ApHeadingLock.Value > 0, "Heading lock", "active", "off");

                }
                ReadToggle(Aircraft.ApNavLock, Aircraft.ApNavLock.Value > 0, "nav lock", "active", "off");
                ReadToggle(Aircraft.ApFlightDirector, Aircraft.ApFlightDirector.Value > 0, "Flight Director", "Active", "off");
                ReadToggle(Aircraft.ApNavGPS, Aircraft.ApNavGPS.Value > 0, "Nav gps switch", "set to GPS", "set to nav");
                ReadToggle(Aircraft.ApWingLeveler, Aircraft.ApWingLeveler.Value > 0, "Wing leveler", "active", "off");
                ReadToggle(Aircraft.ApAutoRudder, Aircraft.ApAutoRudder.Value > 0, "Auto rudder", "active", "off");
                ReadToggle(Aircraft.ApApproachHold, Aircraft.ApApproachHold.Value > 0, "approach mode", "active", "off");
                ReadToggle(Aircraft.ApGlideSlopeHold, Aircraft.ApGlideSlopeHold.Value > 0, "Glide slope hold", "active", "off");
                ReadToggle(Aircraft.ApSpeedHold, Aircraft.ApSpeedHold.Value > 0, "Airspeed hold", "active", "off");
                ReadToggle(Aircraft.ApMachHold, Aircraft.ApMachHold.Value > 0, "Mach hold", "Active", "off");
                ReadToggle(Aircraft.PropSync, Aircraft.PropSync.Value > 0, "Propeller Sync", "active", "off");
                ReadToggle(Aircraft.BatteryMaster, Aircraft.BatteryMaster.Value > 0, "Battery Master", "active", "off");
                // TODO: add check for a2a since below toggles aren't needed for a2a
                ReadToggle(Aircraft.FuelPump, Aircraft.FuelPump.Value > 0, "Fuel pump", "active", "off");

                ReadLandingGear();
                if (Properties.Settings.Default.ReadAutopilot) ReadAutopilotInstruments();
                if (Properties.Settings.Default.ReadGroundSpeed) ReadGroundSpeed();
                readAutopilotAltitude();
                if (Properties.Settings.Default.AltitudeAnnouncements) ReadAltitudeAnnouncement();

                ReadTransponder();
                ReadRadios();
                ReadAutoBrake();
                ReadSpoilers();
                ReadTrim();
                ReadAltimeter(TriggeredByKey: false);
                NextWaypoint();
                ReadLights();
                ReadDoors();
                if (Properties.Settings.Default.ReadILS) ReadILSInfo();
                ReadSimulationRate(TriggeredByKey: false);
                readAPU();
                readOnGround();
                readWarnings();

                // TODO: engine select
                if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("737"))
                {
                    ReadPMDG737Toggles();
                    ReadPmdgFMCMessage();
                }

                if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("747"))
                {
                    foreach (KeyValuePair<string, Dictionary<string, Dictionary<Offset<byte>, string>>> panel in PMDG747.Lights)
                    {
                        foreach (KeyValuePair<string, Dictionary<Offset<byte>, string>> panelSection in panel.Value)
                        {
                            foreach (KeyValuePair<Offset<byte>, string> light in panelSection.Value)
                            {
                                ReadToggle(light.Key, light.Key.Value > 0, $"{light.Value} light", "On", "Off");
                            }
                        }
                    }

                    ReadPMDG747Toggles();
                    ReadPmdgFMCMessage();
                } // End read 747 toggles.
                if (PMDG777Detected)
                {
                    foreach (tfm.PMDG.PanelObjects.PanelObject control in PMDG777Aircraft.PanelControls)
                    {
                        if (control.Name == "Speedbrake") continue;
                        if (control.Offset.ValueChanged)
                        {
                            Output(isGauge: false, output: control.ToString());
                        }
                    }

                    foreach (SingleStateToggle toggle in PMDG777Aircraft.PanelControls)
                    {
                        if (toggle.Name == "Speedbrake")
                        {
                            if (toggle.Offset.ValueChanged)
                            {
                                pmdg777SpeedBrakeMoving = true;
                            }
                            else
                            {
                                if (pmdg777SpeedBrakeMoving)
                                {
                                    pmdg777SpeedBrakeMoving = false;
                                    Output(isGauge: false, output: toggle.ToString());
                                }
                            }
                        }// speedbrake
                    } // speedbrake silence routine.
                    ReadPmdgFMCMessage();
                } // End PMDG 777 toggles.
            }
            else
            {
                string name = Aircraft.AircraftName.Value;
                Output(isGauge: false, output: "Current aircraft: " + Aircraft.AircraftName.Value);
                if (name.Contains("PMDG"))
                {
                    if (name.Contains("737"))
                    {
                        PMDG737Detected = true;
                        Tolk.Output("737 detected");
                    }
                    if (name.Contains("747"))
                    {
                        PMDG747Detected = true;
                    }
                    if (name.Contains("777"))
                    {
                        PMDG777Detected = true;
                    }
                }

                DetectFuelTanks();
                FirstRun = false;
            }
        }

        private void readWarnings()
        {
            // if stall or overspeed warnings are active, read a SAPI message every 5 seconds
            if (WarningFlag == false)
            {
                if (Aircraft.StallWarning.Value == 1 || Aircraft.OverSpeedWarning.Value == 1)
                {
                    WarningFlag = true;

                    WarningsTimer.AutoReset = true;
                    WarningsTimer.Enabled = true;
                }
            }

        }

        private void WarningsTimer_Tick(object sender, ElapsedEventArgs e)
        {
            if (Aircraft.StallWarning.Value == 1)
            {
                Output(isGauge: false, useSAPI: true, output: "stall warning! ");
            }
            if (Aircraft.OverSpeedWarning.Value == 1)
            {
                Output(isGauge: false, useSAPI: true, output: "over speed warning! ");
            }
            if (Aircraft.StallWarning.Value == 0 && Aircraft.OverSpeedWarning.Value == 0)
            {
                WarningFlag = false;
                WarningsTimer.Stop();
            }
        }

        public void ReadLowPriorityInstruments()
        {
            ReadToggle(Aircraft.Eng1Starter, Aircraft.Eng1Starter.Value > 0, "Number 1 starter", "engaged", "off");
            ReadToggle(Aircraft.Eng2Starter, Aircraft.Eng2Starter.Value > 0, "Number 2 starter", "engaged", "off");
            ReadToggle(Aircraft.Eng3Starter, Aircraft.Eng3Starter.Value > 0, "Number 3 starter", "engaged", "off");
            ReadToggle(Aircraft.Eng4Starter, Aircraft.Eng4Starter.Value > 0, "Number 4 starter", "engaged", "off");
            ReadToggle(Aircraft.Eng1Combustion, Aircraft.Eng1Combustion.Value > 0, "Number 1 ignition", "on", "off");
            ReadToggle(Aircraft.Eng2Combustion, Aircraft.Eng2Combustion.Value > 0, "Number 2 ignition", "on", "off");
            ReadToggle(Aircraft.Eng3Combustion, Aircraft.Eng3Combustion.Value > 0, "Number 3 ignition", "on", "off");
            ReadToggle(Aircraft.Eng4Combustion, Aircraft.Eng4Combustion.Value > 0, "Number 4 ignition", "on", "off");
            ReadToggle(Aircraft.Eng1Generator, Aircraft.Eng1Generator.Value > 0, "Number 1 generator", "active", "off");
            ReadToggle(Aircraft.Eng2Generator, Aircraft.Eng2Generator.Value > 0, "Number 2 generator", "active", "off");
            ReadToggle(Aircraft.Eng3Generator, Aircraft.Eng3Generator.Value > 0, "Number 3 generator", "active", "off");
            ReadToggle(Aircraft.Eng4Generator, Aircraft.Eng4Generator.Value > 0, "Number 4 generator", "active", "off");
            ReadToggle(Aircraft.APUGenerator, Aircraft.APUGenerator.Value > 0, "A P U Generator", "active", "off");
            ReadToggle(Aircraft.Eng1FuelValve, Aircraft.Eng1FuelValve.Value > 0, "number 1 fuel valve", "open", "closed");
            ReadToggle(Aircraft.Eng2FuelValve, Aircraft.Eng2FuelValve.Value > 0, "number 2 fuel valve", "open", "closed");
            ReadToggle(Aircraft.Eng3FuelValve, Aircraft.Eng3FuelValve.Value > 0, "number 3 fuel valve", "open", "closed");
            ReadToggle(Aircraft.Eng4FuelValve, Aircraft.Eng4FuelValve.Value > 0, "number 4 fuel valve", "open", "closed");
            if (Properties.Settings.Default.ReadSimconnectMessages) ReadSimConnectMessages();
            ReadFlaps();
        }

        private void readOnGround()
        {
            if (Aircraft.OnGround.ValueChanged)
            {
                if (Aircraft.OnGround.Value == 1)
                {
                    Output(isGauge: false, useSAPI: true, output: "on ground. ");
                }
                else
                {
                    Output(isGauge: false, useSAPI: true, output: "airborn. ");
                }

            }
        }

        private void readAPU()
        {
            double apuPercent = Math.Round((double)Aircraft.APUPercentage.Value);
            if (Aircraft.APUPercentage.ValueChanged)
            {
                if (apuPercent > 4 && apuStarting == false && apuRunning == false && apuShuttingDown == false && apuOff == true)
                {
                    Output(isGauge: false, output: "A P U starting. ");
                    apuStarting = true;
                    apuOff = false;
                }
                if (apuPercent == 100 && apuStarting == true)
                {
                    apuStarting = false;
                    apuRunning = true;
                    Output(isGauge: false, output: "A P U at 100 percent. ");
                }
                if (apuPercent < 100 && apuRunning == true)
                {
                    apuRunning = false;
                    apuShuttingDown = true;
                    Output(isGauge: false, output: "A P U shutting down. ");
                }
                if (apuPercent == 0 && apuOff == false)
                {
                    apuRunning = false;
                    apuStarting = false;
                    apuShuttingDown = false;
                    apuOff = true;
                    Output(isGauge: false, output: "A P U shut down. ");
                }

            }
        }

        private void ReadAltitudeAnnouncement()
        {
            // read altitude every 1000 feet
            double alt = Math.Round((double)Aircraft.Altitude.Value);
            double radioAlt = Math.Round((double)Aircraft.RadioAltimeter.Value / 65536d * 3.28084d);
            double vSpeed = Math.Round((Aircraft.VerticalSpeed.Value * 3.28084) * -1);

            for (int i = 1000; i < 65000; i += 1000)
            {
                if (alt >= i - 10 && alt <= i + 10 && altitudeCalloutFlags[i] == false)
                {
                    Output(isGauge: false, output: $"{i} feet. ");
                    altitudeCalloutFlags[i] = true;

                }
                else
                {
                    if (alt >= i + 100)
                    {
                        altitudeCalloutFlags[i] = false;

                    }
                }
            }
            if (Properties.Settings.Default.ReadGPWS == true)
            {
                try
                {
                    if (radioAlt < 10000 && vSpeed < -50)
                    {
                        var gpwsKeys = new List<int>(gpwsFlags.Keys);
                        foreach (int key in gpwsKeys)
                        {
                            if (radioAlt <= key + 5 && radioAlt >= key - 5 && gpwsFlags[key] == false)
                            {
                                gpwsSound = new WaveFileReader("sounds\\" + key.ToString() + ".wav");
                                // SoundPlayer snd = new SoundPlayer("sounds\\" + key.ToString() + ".wav");
                                // snd.Play();
                                mixer.AddMixerInput(gpwsSound.ToSampleProvider().ToStereo());
                                gpwsFlags[key] = true;
                            }
                            else
                            {
                                if (radioAlt > key + 50)
                                {
                                    gpwsFlags[key] = false;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }

            }
        }

        private void DetectFuelTanks()
        {
            // clear fuel tank data
            ActiveTanks.Clear();
            // grab fuel tank data from the sim
            FSUIPCConnection.PayloadServices.RefreshData();
            // Assign the fuel tanks to our class level variable for easier access
            FuelTanks = FSUIPCConnection.PayloadServices.FuelTanks;
            foreach (FsFuelTank tank in FuelTanks)
            {
                if (tank.IsPresent)
                {
                    ActiveTanks.Add(tank);
                    Logger.Debug("found " + tank.Tank.ToString());
                }
            }

        }
        private void ReadTrim()
        {

            if (PMDG737Detected)
            {
                if (PMDG737Aircraft.CurrentElevatorTrim != OldElevatorTrim && TrimEnabled)
                {
                    Output(isGauge: false, output: $"{PMDG737Aircraft.CurrentElevatorTrim}");
                    OldElevatorTrim = PMDG737Aircraft.CurrentElevatorTrim;
                }
            } // end-pmdg737-trim
            else
            {
                // Elevator trim
                double elevator = (double)Aircraft.ConvertRadiansToDegrees(Aircraft.ElevatorTrim.Value);
                double aileron = (double)Aircraft.ConvertRadiansToDegrees(Aircraft.AileronTrim.Value);
                if (Aircraft.ElevatorTrim.ValueChanged && Aircraft.ApMaster.Value != 1 && TrimEnabled)

                {
                    if (elevator < 0)
                    {
                        Output(isGauge: false, output: $"Trim down {Math.Abs(Math.Round(elevator, 2)):F2}. ");
                    }
                    else
                    {
                        Output(isGauge: false, output: $"Trim up: {Math.Round(elevator, 2):F2}");
                    }

                }
                if (Aircraft.AileronTrim.ValueChanged && Aircraft.ApMaster.Value != 1 && TrimEnabled)
                {
                    if (aileron < 0)
                    {
                        Output(isGauge: false, output: $"Trim left {Math.Abs(Math.Round(aileron, 2))}. ");
                    }
                    else
                    {
                        Output(isGauge: false, output: $"Trim right {Math.Round(aileron, 2)}");
                    }
                }
            }// end-freeware-trim
        }

        private void ReadAltimeter(bool TriggeredByKey)
        {
            if (Aircraft.Altimeter.ValueChanged || TriggeredByKey)
            {
                double AltQNH = (double)Aircraft.Altimeter.Value / 16d;
                double AltHPA = Math.Floor(AltQNH + 0.5);
                double AltInches = Math.Floor(((100 * AltQNH * 29.92) / 1013.2) + 0.5);
                var isGauge = true;
                var gaugeName = "Altimeter";
                var gaugeValue = $"{AltHPA}, {AltInches / 100} inches. ";
                Output(gaugeName, gaugeValue, isGauge);
            }


        }


        private void ReadAutoBrake()
        {

            string AbState = null;
            if (Aircraft.AutoBrake.ValueChanged)
            {
                switch (Aircraft.AutoBrake.Value)
                {
                    case 0:
                        AbState = "R T O";
                        break;
                    case 1:
                        AbState = "off";
                        break;
                    case 2:
                        AbState = "position 1";
                        break;
                    case 3:
                        AbState = "position 2";
                        break;
                    case 4:
                        AbState = "position 3";
                        break;
                    case 5:
                        AbState = "maximum";
                        break;

                }
                Output(isGauge: false, output: "Autobrake " + AbState);
            }
        }

        private void ReadRadios()
        {
            FsFrequencyCOM com1Helper = new FsFrequencyCOM(Aircraft.Com1Freq.Value);
            FsFrequencyCOM com2Helper = new FsFrequencyCOM(Aircraft.Com2Freq.Value);
            FsFrequencyNAV nav1Helper = new FsFrequencyNAV(Aircraft.Nav1Freq.Value);
            FsFrequencyNAV nav2Helper = new FsFrequencyNAV(Aircraft.Nav2Freq.Value);
            bool isGauge = true;
            string gaugeName;
            string gaugeValue;
            if (Aircraft.Com1Freq.ValueChanged)
            {
                gaugeName = "Com1";
                gaugeValue = com1Helper.ToString();
                Output(gaugeName, gaugeValue, isGauge);

            }
            if (Aircraft.Com2Freq.ValueChanged)
            {
                gaugeName = "Com2";
                gaugeValue = com2Helper.ToString();
                Output(gaugeName, gaugeValue, isGauge);

            }
            if (Properties.Settings.Default.ReadNavRadios == true)
            {
                if (Aircraft.Nav1Freq.ValueChanged)
                {
                    gaugeName = "Nav1";
                    gaugeValue = nav1Helper.ToString();
                    Output(gaugeName, gaugeValue, isGauge);

                }
                if (Aircraft.Nav2Freq.ValueChanged)
                {
                    gaugeName = "Nav2";
                    gaugeValue = nav2Helper.ToString();
                    Output(gaugeName, gaugeValue, isGauge);

                }

            }
        }

        private void ReadTransponder()
        {

            FsTransponderCode txHelper = new FsTransponderCode(Aircraft.Transponder.Value);
            if (Aircraft.Transponder.ValueChanged)
            {
                var gaugeName = "Transponder";
                var gaugeValue = txHelper.ToString();
                var isGauge = true;
                Output(gaugeName, gaugeValue, isGauge);

            }

        }

        private void NextWaypoint()
        {
            // convert distance to nautical miles
            double dist = Aircraft.NextWPDistance.Value * 0.00053995D;

            if (waypointTransition == false && readWaypointFlag == true)
            {
                ReadWayPoint();
                return;
            }
            if (Aircraft.NextWPName.ValueChanged)
            {
                waypointTransitionTimer.AutoReset = false;
                waypointTransitionTimer.Start();

            }

        }

        private void ReadWayPoint()
        {
            double dist = Aircraft.NextWPDistance.Value * 0.00053995D;
            string name = Aircraft.NextWPName.Value;
            string strDist = dist.ToString("F0");
            TimeSpan TimeEnroute = TimeSpan.FromSeconds(Aircraft.NextWPETE.Value);
            double baring = Aircraft.ConvertRadiansToDegrees((double)Aircraft.NextWPBaring.Value);
            string strBaring = baring.ToString("F0");
            string strTime = string.Format("{0:%h} hours, {0:%m} minutes, {0:%s} seconds", TimeEnroute);
            readWaypointFlag = false;
            if (TimeEnroute.Hours == 0)
            {
                strTime = string.Format("{0:%m} minutes, {0:%s} seconds", TimeEnroute);
            }
            if (TimeEnroute.Minutes == 0 && TimeEnroute.Hours == 0)
            {
                strTime = string.Format("{0:%s} seconds", TimeEnroute);
            }
            Output(isGauge: false, output: $"Next waypoint: {name}.\nDistance: {strDist} nautical miles.\nBaring: {strBaring} degrees.\n{strTime}");
        }
        private void ReadLights()
        {
            // read when aircraft lights change
            if (Aircraft.Lights.ValueChanged)
            {
                string state = null;
                // loop through each bit and announce which values have changed.
                FsBitArray lightBits = Aircraft.Lights.Value;
                for (int i = 0; i < lightBits.Changed.Length; i++)
                {
                    if (lightBits.Changed[i])
                    {
                        string name = Enum.GetName(typeof(Aircraft.light), i);
                        // string state = (Aircraft.Lights.Value[i]) ? "off" : "on";
                        if (Aircraft.Lights.Value[i] == true)
                        {
                            state = "on";
                        }
                        else
                        {
                            state = "off";
                        }
                        Output(isGauge: false, output: $"{name} {state}. ");
                    }
                }
            }

        }
        private void ReadDoors()
        {
            // read aircraft exit status
            if (Aircraft.Doors.ValueChanged)
            {
                // loop through each bit and announce which values have changed.
                FsBitArray DoorBits = Aircraft.Doors.Value;
                for (int i = 0; i < DoorBits.Changed.Length; i++)
                {
                    if (DoorBits.Changed[i])
                    {
                        string state = (Aircraft.Doors.Value[i]) ? "open" : "closed";
                        Output(isGauge: false, output: $"door {i + 1} {state}. ");
                    }
                }
            }

        }

        private void ReadILSInfo()
        {
            double vspeed = (double)Aircraft.VerticalSpeed.Value * 3.28084d * -1;
            if (Properties.Settings.Default.ReadILS && Aircraft.OnGround.Value == 0 && vspeed < 200)
            {
                if (Aircraft.Nav1GS.Value == 1 && gsDetected == false)
                {
                    if (Properties.Settings.Default.SapiILSAnnouncements)
                    {
                        Output(isGauge: false, useSAPI: true, output: "glide slope is alive. ");
                    }
                    else
                    {
                        Output(isGauge: false, output: "glide slope is alive. ");
                    }

                    gsDetected = true;
                }
                if (Aircraft.Nav1Flags.Value[7] && hasLocaliser == false)
                {
                    if (Properties.Settings.Default.SapiILSAnnouncements)
                    {
                        Output(isGauge: false, useSAPI: true, output: "nav 1 has localiser.");
                    }
                    else
                    {
                        Output(isGauge: false, output: "nav 1 has localiser.");
                    }

                    hasLocaliser = true;
                }
                if (Aircraft.Nav1Signal.Value == 256 && localiserDetected == false && Aircraft.Nav1Flags.Value[7])
                {

                    double hdgTrue = (double)Aircraft.Heading.Value * 360d / (65536d * 65536d);
                    double magvar = (double)Aircraft.MagneticVariation.Value * 360d / 65536d;
                    double magHeading = hdgTrue - magvar;
                    double rwyHeading = (double)Aircraft.Nav1LocaliserInverseRunwayHeading.Value * 360d / 65536d + 180d - magvar;

                    if (Properties.Settings.Default.SapiILSAnnouncements)
                    {
                        Output(isGauge: false, useSAPI: true, output: "Localiser is alive. Runway heading" + rwyHeading.ToString("F0"));
                    }
                    else
                    {
                        Output(isGauge: false, output: "Localiser is alive. Runway heading" + rwyHeading.ToString("F0"));
                    }

                    localiserDetected = true;
                    ilsTimer.AutoReset = true;
                    ilsTimer.Enabled = true;

                }
                if (Aircraft.Nav1Flags.Value[6] && hasGlideSlope == false)
                {

                    if (Properties.Settings.Default.SapiILSAnnouncements)
                    {
                        Output(isGauge: false, useSAPI: true, output: "nav 1 has glide slope. ");
                    }
                    else
                    {
                        Output(isGauge: false, output: "nav 1 has glide slope. ");
                    }

                    hasGlideSlope = true;
                }

            }
            else
            {
                ilsTimer.Enabled = false;
                hasGlideSlope = false;
                hasLocaliser = false;
                localiserDetected = false;
                gsDetected = false;
            }
        }

        private void OnWeatherRefreshTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {
            if (FSUIPCConnection.IsOpen)
            {
                utility.CurrentWeather = FSUIPCConnection.WeatherServices.GetWeatherAtAircraft();
                utility.CurrentWeather.Name = "Weather auto refresh";
                utility.WeatherLastUpdated = elapsedEventArgs.SignalTime;
            }

        }

        private void onILSTimerTick(object sender, ElapsedEventArgs e)
        {
            FlightPlan.Destination.SetReferenceLocation(AirportComponents.Runways);
            double gsNeedle = (double)Aircraft.Nav1GSNeedle.Value;
            double locNeedle = (double)Aircraft.Nav1LocNeedle.Value;
            double locPercent;
            double gsPercent;
            double magvar = (double)Aircraft.MagneticVariation.Value * 360d / 65536d;
            double rwyHeading = (double)Aircraft.Nav1LocaliserInverseRunwayHeading.Value * 360d / 65536d + 180d - magvar;
            // if on ground, stop reading ILS values
            if (Aircraft.OnGround.Value == 1)
            {
                ilsTimer.Enabled = false;
                return;
            }
            // only read ils when approach mode is on
            if (Aircraft.ApApproachHold.Value == 1 || Aircraft.pmdg737.MCP_annunAPP.Value == 1 || Aircraft.pmdg747.MCP_annunAPP.Value == 1 || Aircraft.pmdg777.MCP_annunAPP.Value == 1)
            {
                if (Properties.Settings.Default.ReadGSAltitude)
                {
                    var gsHeight = utility.CalculateAngleHeight(FlightPlan.DestinationRunway.DistanceFeet, FlightPlan.DestinationRunway.ILSInfo.Slope);
                    var relativeGsHeight = Autopilot.AglAltitude - gsHeight;
                    relativeGsHeight = Math.Round(relativeGsHeight, 0);

                    if (relativeGsHeight > 0)
                    {
                        var gaugeName = "Glide slope";
                        var gaugeValue = $"{relativeGsHeight} down.";
                        var isGauge = true;

                        if (Properties.Settings.Default.SapiILSAnnouncements)
                        {
                            Output(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);
                        }
                        else
                        {
                            Output(gaugeName, gaugeValue, isGauge, textOutput: false);
                        }

                    }
                    if (relativeGsHeight < 0)
                    {
                        var gaugeName = "Glide slope";
                        var gaugeValue = $"{Math.Abs(relativeGsHeight)} up";
                        var isGauge = true;

                        if (Properties.Settings.Default.SapiILSAnnouncements)
                        {
                            Output(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);
                        }
                        else
                        {
                            Output(gaugeName, gaugeValue, isGauge, textOutput: false);
                        }
                    }
                    if (relativeGsHeight == 0)
                    {
                        var gaugeName = "Glide slope";
                        var gaugeValue = "Centered.";
                        var isGauge = true;

                        if (Properties.Settings.Default.SapiILSAnnouncements)
                        {
                            Output(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);
                        }
                        else
                        {
                            Output(gaugeName, gaugeValue, isGauge, textOutput: false);
                        }
                    }
                }
                else
                {
                    if (gsNeedle > 0 && gsNeedle < 119)
                    {
                        gsPercent = gsNeedle / 119 * 100;
                        string strPercent = gsPercent.ToString("F0");
                        var gaugeName = "Glide slope";
                        var gaugeValue = $"up {strPercent} percent. ";
                        var isGauge = true;

                        if (Properties.Settings.Default.SapiILSAnnouncements)
                        {
                            Output(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);
                        }
                        else
                        {
                            Output(gaugeName, gaugeValue, isGauge, textOutput: false);
                        }
                    }
                    if (gsNeedle < 0 && gsNeedle > -119)
                    {
                        gsPercent = Math.Abs(gsNeedle) / 119 * 100;
                        string strPercent = gsPercent.ToString("F0");
                        var gaugeName = "Glide slope";
                        var gaugeValue = $"down {strPercent} percent. ";
                        var isGauge = true;

                        if (Properties.Settings.Default.SapiILSAnnouncements)
                        {
                            Output(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);
                        }
                        else
                        {
                            Output(gaugeName, gaugeValue, isGauge, textOutput: false);
                        }
                    }
                }
                if (Properties.Settings.Default.ReadLocaliserHeadingOffsets)
                {

                    double heading = (double)Aircraft.Nav1LocaliserInverseRunwayHeading.Value * 360d / 65536d + 180d - magvar;
                    var headingOffset = utility.ReadHeadingOffset(Autopilot.Heading, heading);
                    headingOffset = Math.Round(headingOffset, 0);
                    if (headingOffset < 0)
                    {
                        var gaugeName = "Localiser";
                        var isGauge = true;
                        var gaugeValue = $"Left {Math.Abs(headingOffset)}";

                        if (Properties.Settings.Default.SapiILSAnnouncements)
                        {
                            Output(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);
                        }
                        else
                        {
                            Output(gaugeName, gaugeValue, isGauge, textOutput: false);
                        }

                    }
                    if (headingOffset > 0)
                    {
                        var gaugeName = "Localiser";
                        var isGauge = true;
                        var gaugeValue = $"Right {headingOffset}";

                        if (Properties.Settings.Default.SapiILSAnnouncements)
                        {
                            Output(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);
                        }
                        else
                        {
                            Output(gaugeName, gaugeValue, isGauge, textOutput: false);
                        }

                    }
                    if (headingOffset == 0)
                    {
                        var gaugeName = "Localiser";
                        var isGauge = true;
                        var gaugeValue = "Centered.";
                        if (Properties.Settings.Default.SapiILSAnnouncements)
                        {
                            Output(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);
                        }
                        else
                        {
                            Output(gaugeName, gaugeValue, isGauge, textOutput: false);
                        }


                    }
                }
                else
                {
                    if (locNeedle > 0 && locNeedle < 127)
                    {
                        locPercent = locNeedle / 127 * 100;
                        string strPercent = locPercent.ToString("F0");
                        var gaugeName = "Localiser";
                        var gaugeValue = $"{strPercent} percent right. ";
                        var isGauge = true;

                        if (Properties.Settings.Default.SapiILSAnnouncements)
                        {
                            Output(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);
                        }
                        else
                        {
                            Output(gaugeName, gaugeValue, isGauge, textOutput: false);
                        }

                    }
                    if (locNeedle < 0 && locNeedle > -127)
                    {
                        locPercent = Math.Abs(locNeedle) / 127 * 100;
                        string strPercent = locPercent.ToString("F0");
                        var gaugeName = "Localiser";
                        var gaugeValue = $"{strPercent} percent left. ";
                        var isGauge = true;

                        if (Properties.Settings.Default.SapiILSAnnouncements)
                        {
                            Output(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);
                        }
                        else
                        {
                            Output(gaugeName, gaugeValue, isGauge, textOutput: false);
                        }

                    }
                }
            }
        }

        private void ReadSimulationRate(bool TriggeredByKey)
        {
            double rate = (double)Aircraft.SimulationRate.Value / 256;
            if (TriggeredByKey)
            {
                Output(isGauge: false, output: $"simulation rate: {rate}");
            }
            if (Aircraft.SimulationRate.ValueChanged && rate >= 0.25)
            {
                Output(isGauge: false, output: $"simulation rate: {rate}");
            }
        }
        private void ReadSpoilers()
        {
            if (Aircraft.Spoilers.ValueChanged)
            {
                uint sp = Aircraft.Spoilers.Value;
                if (sp == 4800) Output(isGauge: false, output: "Spoilers armed. ");
                else if (sp == 16384) Output(isGauge: false, output: "Spoilers deployed. ");
                else if (sp == 0)
                {
                    if (OldSpoilersValue == 4800)
                    {
                        Output(isGauge: false, output: "arm spoilers off. ");
                    }
                    else
                    {
                        Output(isGauge: false, output: "spoilers retracted. ");
                    }

                }
            }
        }

        private void ReadFlaps()
        {
            if (PMDG737Detected)
            {
                if (Aircraft.pmdg737.MAIN_TEFlapsNeedle[0].ValueChanged)
                {
                    FlapsMoving = true;
                } // value changed.
                else
                {
                    if (FlapsMoving)
                    {
                        FlapsMoving = false;
                        var gaugeName = "Flaps";
                        var gaugeValue = PMDG737Aircraft.CurrentFlapsPosition.ToString();
                        var isGauge = true;
                        Output(gaugeName, gaugeValue, isGauge);
                    } // Flaps are moving.
                } // Report flaps position.
            } // PMDG 737.
            else if (PMDG747Detected)
            {
                if (Aircraft.Flaps.ValueChanged)
                {
                    FlapsMoving = true;
                } // value changed.
                else
                {
                    if (FlapsMoving)
                    {
                        FlapsMoving = false;
                        var gaugeName = "Flaps";
                        var gaugeValue = PMDG747Aircraft.CurrentFlapsPosition.ToString();
                        var isGauge = true;
                        Output(gaugeName, gaugeValue, isGauge);
                    } // Flaps are moving.
                } // Report flaps position.
            } // PMDG 747
            else if (PMDG777Detected)
            {
                if (Aircraft.Flaps.ValueChanged)
                {
                    FlapsMoving = true;
                } // value changed.
                else
                {
                    if (FlapsMoving)
                    {
                        FlapsMoving = false;
                        var gaugeName = "Flaps";
                        var gaugeValue = PMDG777Aircraft.CurrentFlapsPosition.ToString();
                        var isGauge = true;
                        Output(gaugeName, gaugeValue, isGauge);
                    } // Flaps are moving.
                } // Report flaps position.
            } // PMDG 777
            else
            {
                if (Aircraft.Flaps.ValueChanged)
                {
                    FlapsMoving = true;
                }
                else
                {
                    if (FlapsMoving)
                    {
                        FlapsMoving = false;
                        double FlapsAngle = (double)Aircraft.Flaps.Value / 256d;
                        var gaugeName = "Flaps";
                        var gaugeValue = FlapsAngle.ToString("f0");
                        var isGauge = true;
                        Output(gaugeName, gaugeValue, isGauge);
                    }
                }

            }

        }
        public void ReadLandingGear()
        {
            var gaugeName = "Gear";
            var isGauge = true;
            string gaugeValue;
            if (Aircraft.LandingGear.ValueChanged)
            {
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

            }
        }
        // read autopilot settings
        public void ReadAutopilotInstruments()
        {
            string gaugeName;
            string gaugeValue;
            bool isGauge = true;
            // heading
            if (PMDG737Detected)
            {
                if (Aircraft.pmdg737.MCP_Heading.ValueChanged)
                {
                    gaugeName = "AP heading";
                    gaugeValue = $"MCP heading {Aircraft.pmdg737.MCP_Heading.Value}";
                    Output(gaugeName, gaugeValue, isGauge);
                }
            }
            if (PMDG747Detected)
            {
                if (Aircraft.pmdg747.MCP_Heading.ValueChanged)
                {
                    gaugeName = "AP heading";
                    gaugeValue = Aircraft.pmdg747.MCP_Heading.Value.ToString();
                    Output(gaugeName, gaugeValue, isGauge);

                }
            }
            if (PMDG777Detected)
            {
                if (Aircraft.pmdg777.MCP_Heading.ValueChanged)
                {
                    gaugeName = "AP heading";
                    gaugeValue = Aircraft.pmdg777.MCP_Heading.Value.ToString();
                    Output(gaugeName, gaugeValue, isGauge);

                }
            }
            // read non-pmdg heading    
            if (Aircraft.ApHeading.ValueChanged)
            {
                gaugeName = "AP heading";
                gaugeValue = Autopilot.ApHeading.ToString();
                Output(gaugeName, gaugeValue, isGauge);
            }

            // speed
            if (PMDG737Detected)
            {
                if (Aircraft.pmdg737.MCP_IASMach.ValueChanged)
                {
                    if (PMDG737Aircraft.SpeedType == PMDG.AircraftSpeed.Indicated)
                    {
                        gaugeName = "AP airspeed";
                        gaugeValue = PMDG737Aircraft.IndicatedAirSpeed.ToString();
                        Output(gaugeName, gaugeValue, isGauge);
                    } // airspeed
                    else if (PMDG737Aircraft.SpeedType == PMDG.AircraftSpeed.Mach)
                    {
                        gaugeName = "AP mach";
                        gaugeValue = PMDG737Aircraft.MachSpeed.ToString();
                        Output(gaugeName, gaugeValue, isGauge);
                    } // mach speed
                }
            } // PMDG737
            if (PMDG747Detected)
            {
                if (Aircraft.pmdg747.MCP_IASMach.ValueChanged)
                {
                    gaugeName = "AP airspeed";
                    gaugeValue = Aircraft.pmdg747.MCP_IASMach.Value.ToString();
                    Output(gaugeName, gaugeValue, isGauge);

                }
            }
            if (PMDG777Detected)
            {
                if (Aircraft.pmdg777.MCP_IASMach.ValueChanged)
                {
                    if (PMDG777Aircraft.SpeedType == PMDG.AircraftSpeed.Indicated)
                    {
                        gaugeName = "AP airspeed";
                        gaugeValue = PMDG777Aircraft.IndicatedAirSpeed.ToString();
                        Output(gaugeName, gaugeValue, isGauge);
                    }
                    else if (PMDG777Aircraft.SpeedType == PMDG.AircraftSpeed.Mach)
                    {
                        gaugeName = "AP airspeed";
                        gaugeValue = PMDG777Aircraft.MachSpeed.ToString();
                        Output(gaugeName, gaugeValue, isGauge);
                    }

                }
                if (Aircraft.pmdg777.MCP_FPA.ValueChanged)
                {
                    gaugeName = "AP Flight path angle";
                    gaugeValue = Aircraft.pmdg777.MCP_FPA.Value.ToString();
                    Output(gaugeName, gaugeValue, isGauge);
                }
            }
            // handle speed for standard aircraft
            if (Aircraft.ApAirspeed.ValueChanged)
            {
                gaugeName = "AP airspeed";
                gaugeValue = Autopilot.ApAirspeed.ToString();
                Output(gaugeName, gaugeValue, isGauge);
            }
            // vertical speed
            if (Aircraft.ApVerticalSpeed.ValueChanged)
            {
                gaugeName = "AP vertical speed";
                gaugeValue = Autopilot.ApVerticalSpeed.ToString();
                Output(gaugeName, gaugeValue, isGauge);
            }
        }
        private void readAutopilotAltitude()
        {
            // Altitude
            var gaugeName = "AP altitude";
            var isGauge = true;
            if (Aircraft.AircraftName.Value.Contains("PMDG"))
            {
                if (PMDG737Detected)
                {
                    if (Aircraft.pmdg737.MCP_Altitude.ValueChanged)
                    {
                        var gaugeValue = Aircraft.pmdg737.MCP_Altitude.Value.ToString();
                        Output(gaugeName, gaugeValue, isGauge);

                    }
                }
                if (PMDG747Detected)
                {
                    if (Aircraft.pmdg747.MCP_Altitude.ValueChanged)
                    {
                        var gaugeValue = Aircraft.pmdg747.MCP_Altitude.Value.ToString();
                        Output(gaugeName, gaugeValue, isGauge);

                    }
                }
                if (PMDG777Detected)
                {
                    if (Aircraft.pmdg777.MCP_Altitude.ValueChanged)
                    {
                        var gaugeValue = Aircraft.pmdg777.MCP_Altitude.Value.ToString();
                        Output(gaugeName, gaugeValue, isGauge);
                    }
                }
            }

            else
            {
                if (Aircraft.ApAltitude.ValueChanged)
                {
                    var gaugeValue = Autopilot.ApAltitude.ToString();
                    Output(gaugeName, gaugeValue, isGauge);


                }
            }

        }
        public void ReadGroundSpeed()
        {
            if (!groundSpeedActive)
            {
                // only read if aircraft is on ground
                if (Aircraft.OnGround.Value == 1)
                {
                    if (GroundSpeed > 10)
                    {
                        groundSpeedActive = true;
                        GroundSpeedTimer.AutoReset = true;
                        GroundSpeedTimer.Enabled = true;

                    }



                }

            }
        }

        private void onGroundSpeedTimerTick(object sender, ElapsedEventArgs e)
        {

            if (GroundSpeed > 10)
            {
                Output(textOutput: false, isGauge: false, useSAPI: true, output: $"{GroundSpeed} knotts. ");
            }
            if (GroundSpeed < 10 || Aircraft.OnGround.Value == 0)
            {
                groundSpeedActive = false;
                GroundSpeedTimer.Stop();
            }
        }

        public void ReadSimConnectMessages()
        {
            Aircraft.textMenu.RefreshData();
            if (Aircraft.textMenu.Changed) // Check if the text/menu is different from the last time we called RefreshData()
            {
                if (!muteSimconnect)
                {
                    if (Aircraft.textMenu.IsMenu) // Check if it's a menu (true) or a simple message (false)
                    {
                        if (Aircraft.textMenu.ToString() == "") return;
                        string menu = Aircraft.textMenu.MenuTitleText + "\r\n";
                        menu += Aircraft.textMenu.MenuPromptText + "\r\n";

                        int count = 1;
                        foreach (string item in Aircraft.textMenu.MenuItems)
                        {
                            menu += $"{count}: {item}. \r\n";
                            count++;
                        }
                        Output(isGauge: false, output: menu);
                    }
                    else
                    {
                        if (Aircraft.textMenu.Message.Contains("Initialising All Systems") && PMDGInitializing == false)
                        {
                            PMDGInitializing = true;
                            Output(isGauge: false, output: "Initializing all systems. ");


                        }
                        if (Aircraft.textMenu.Message.Contains("hold Ctrl to skip"))
                        {
                            tickSound = new WaveFileReader(@"sounds\tick.wav");
                            mixer.AddMixerInput(tickSound);

                            OldSimConnectMessage = Aircraft.textMenu.ToString();
                            return;
                        }



                        if (Aircraft.textMenu.Message == "")
                        {
                            PMDGInitializing = false;
                            return;
                        }

                        if (PMDGInitializing == false)
                        {
                            Output(isGauge: false, output: Aircraft.textMenu.Message);
                        }

                    }

                }
                OldSimConnectMessage = Aircraft.textMenu.ToString();
            }
        }

        private void TrackCloudsOnClimb()
        {
            var weather = FSUIPCConnection.WeatherServices.GetWeatherAtAircraft();
            var currentCloud = weather.CloudLayers.Where(x => Autopilot.AslAltitude >= x.LowerAltitudeFeet && Autopilot.AslAltitude <= x.UpperAltitudeFeet).OrderBy(x => x.LowerAltitudeFeet).FirstOrDefault();
            inCloudAscending = currentCloud != null ? true : false;

            if (inCloudAscending == true && wasInCloudAscending == false)
            {
                if (Properties.Weather.Default.CloudLayers_UseSAPI)
                {
                    Output(isGauge: false, useSAPI: true, output: "In cloud.");
                }
                else
                {
                    Output(isGauge: false, output: "In cloud.");
                }
                wasInCloudAscending = true;
            }
            else if (inCloudAscending == false && wasInCloudAscending == true)
            {
                if (Properties.Weather.Default.CloudLayers_UseSAPI)
                {
                    Output(isGauge: false, useSAPI: true, output: "Out of cloud.");
                }
                else
                {
                    Output(isGauge: false, output: "Out of cloud.");
                }
                wasInCloudAscending = false;
            }
        }

        private void TrackCloudsOnDescent()
        {
            var weather = FSUIPCConnection.WeatherServices.GetWeatherAtAircraft();
            var currentCloud = weather.CloudLayers.Where(x => Autopilot.AslAltitude >= x.LowerAltitudeFeet && Autopilot.AslAltitude <= x.UpperAltitudeFeet).OrderByDescending(x => x.UpperAltitudeFeet).FirstOrDefault();
            inCloudDescending = currentCloud != null ? true : false;

            if (inCloudDescending == true && wasInCloudDescending == false)
            {
                if (Properties.Weather.Default.CloudLayers_UseSAPI)
                {
                    Output(isGauge: false, useSAPI: true, output: "In cloud.");
                }
                else
                {
                    Output(isGauge: false, output: "In cloud.");
                }
                wasInCloudDescending = true;
            }
            else if (inCloudDescending == false && wasInCloudDescending == true)
            {
                if (Properties.Weather.Default.CloudLayers_UseSAPI)
                {
                    Output(isGauge: false, useSAPI: true, output: "Out of cloud.");
                }
                else
                {
                    Output(isGauge: false, output: "Out of cloud.");
                }
                wasInCloudDescending = false;
            }

        }
        private void CloudTrackingTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {
            if (Autopilot.VerticalSpeed >= 0)
            {
                TrackCloudsOnClimb();
            }
            else
            {
                TrackCloudsOnDescent();
            }
        }

        private void OnRunwayGuidanceTickEvent(Object source, ElapsedEventArgs e)
        {
            pulse = new OffsetSampleProvider(pan)
            {
                Take = TimeSpan.FromMilliseconds(50),
            };
            mixer.RemoveAllMixerInputs();
            double hdg = (double)Math.Round(Aircraft.CompassHeading.Value);
            if (hdg > RunwayGuidanceTrackedHeading && hdg < HdgRight)
            {
                double freq = mapOneRangeToAnother(hdg, RunwayGuidanceTrackedHeading, HdgRight, 400, 800, 0);
                wg.Frequency = freq;
                pan.Pan = 1;
                mixer.AddMixerInput(pulse);
            }
            if (hdg < RunwayGuidanceTrackedHeading && hdg > HdgLeft)
            {
                double freq = mapOneRangeToAnother(hdg, HdgLeft, RunwayGuidanceTrackedHeading, 800, 400, 0);
                wg.Frequency = freq;
                pan.Pan = -1;
                mixer.AddMixerInput(pulse);
            }
            if (hdg == RunwayGuidanceTrackedHeading)
            {
                mixer.RemoveAllMixerInputs();
            }
                   }

        private void OnAttitudeModeTickEvent(Object source, ElapsedEventArgs e)
        {
            string attitudeModeSelect = Properties.Settings.Default.AttitudeAnnouncementMode;


            // pan = new PanningSampleProvider(bankSineProvider);
            FSUIPCConnection.Process("attitude");
            double Pitch = Math.Round((double)Aircraft.AttitudePitch.Value * 360d / (65536d * 65536d));
            double Bank = Math.Round((double)Aircraft.AttitudeBank.Value * 360d / (65536d * 65536d));
            // pitch down
            if (Pitch > 0 && Pitch < 20)
            {
                if (attitudeModeSelect == "Speech" || attitudeModeSelect == "Both")
                {
                    if (Pitch != oldPitch)
                    {
                        Output(isGauge: false, textOutput: false, interruptSpeech: true, output: $"down {Pitch}");
                        oldPitch = Pitch;
                        if (attitudeModeSelect == "Speech") return;
                    }
                }
                if (attitudeModeSelect == "Tones" || attitudeModeSelect == "Both")
                {
                    if (!AttitudePitchPlaying)
                    {
                        mixer.AddMixerInput(new SampleToWaveProvider(pitchSineProvider.ToStereo()));
                        Logger.Debug("pitch: " + Pitch);
                        AttitudePitchPlaying = true;
                    }

                    double freq = mapOneRangeToAnother(Pitch, 0, 20, 600, 200, 0);
                    pitchSineProvider.Frequency = freq;
                }

            }
            // pitch up
            if (Pitch < 0 && Pitch > -20)
            {
                if (attitudeModeSelect == "Speech" || attitudeModeSelect == "Both")
                {
                    if (Pitch != oldPitch)
                    {
                        Output(interruptSpeech: true, isGauge: false, textOutput: false, output: $"up {Math.Abs(Pitch)}");
                        oldPitch = Pitch;
                        if (attitudeModeSelect == "Speech") return;
                    }
                }

                if (attitudeModeSelect == "Tones" || attitudeModeSelect == "Both")
                {
                    if (!AttitudePitchPlaying)
                    {
                        mixer.AddMixerInput(new SampleToWaveProvider(pitchSineProvider.ToStereo()));
                        Logger.Debug("pitch: " + Pitch);
                        AttitudePitchPlaying = true;
                    }
                    double freq = mapOneRangeToAnother(Pitch, -20, 0, 1200, 800, 0);
                    pitchSineProvider.Frequency = freq;
                }

            }
            // bank left
            if (Bank > 0 && Bank < 90)
            {
                if (attitudeModeSelect == "Speech" || attitudeModeSelect == "Both")
                {
                    if (Bank != OldBank)
                    {
                        Output(interruptSpeech: true, isGauge: false, textOutput: false, output: $"left {Bank}");
                        OldBank = Bank;
                        if (attitudeModeSelect == "Speech") return;
                    }
                }
                if (attitudeModeSelect == "Tones" || attitudeModeSelect == "Both")
                {
                    double freq = mapOneRangeToAnother(Bank, 1, 90, 400, 800, 0);
                    // bankSineProvider.Frequency = freq;
                    wg.Frequency = freq;
                    if (!AttitudeBankLeftPlaying)
                    {
                        mixer.RemoveAllMixerInputs();
                        pan.Pan = -1;
                        mixer.AddMixerInput(pan);
                        mixer.AddMixerInput(new SampleToWaveProvider(pitchSineProvider.ToStereo()));
                        AttitudeBankLeftPlaying = true;
                        AttitudeBankRightPlaying = false;
                    }

                }


            }
            // bank right
            if (Bank < 0 && Bank > -90)
            {
                Bank = Math.Abs(Bank);
                if (attitudeModeSelect == "Speech" || attitudeModeSelect == "Both")
                {
                    if (Bank != OldBank)
                    {
                        Output(interruptSpeech: true, isGauge: false, textOutput: false, output: $"right {Bank}");
                        OldBank = Bank;
                        if (attitudeModeSelect == "Speech") return;
                    }
                }

                if (attitudeModeSelect == "Tones" || attitudeModeSelect == "Both")
                {
                    double freq = mapOneRangeToAnother(Bank, 1, 90, 400, 800, 0);
                    // bankSineProvider.Frequency = freq;
                    wg.Frequency = freq;
                    if (!AttitudeBankRightPlaying)
                    {
                        mixer.RemoveAllMixerInputs();
                        pan.Pan = 1;
                        mixer.AddMixerInput(pan);
                        mixer.AddMixerInput(new SampleToWaveProvider(pitchSineProvider.ToStereo()));
                        AttitudeBankLeftPlaying = false;
                        AttitudeBankRightPlaying = true;
                    }

                }
            }
            if (Bank == 0)
            {
                if (attitudeModeSelect == "Tones" || attitudeModeSelect == "Both")
                {
                    mixer.RemoveAllMixerInputs();
                    mixer.AddMixerInput(new SampleToWaveProvider(pitchSineProvider.ToStereo()));
                    AttitudeBankLeftPlaying = false;
                    AttitudeBankRightPlaying = false;
                    AttitudePitchPlaying = true;

                }
            }

        }



    }
}
