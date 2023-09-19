using FSUIPC;
using NLog;
using NLog.Config;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NHotkey.WindowsForms;
using tfm.Properties;
using NAudio.Wave.SampleProviders;
using DavyKager;
using System.Diagnostics;

namespace tfm
{
    public partial class App: System.Windows.Application
    {
                public void LoadDestination()
        {
            if (tfm.Properties.Settings.Default.SaveDestination)
            {
                var airport = FSUIPCConnection.AirportsDatabase.Airports[tfm.Properties.Settings.Default.DestinationAirport];
                var runway = airport.Runways[tfm.Properties.Settings.Default.DestinationRunway];

                if (airport != null)
                {
                    FlightPlan.Destination = airport;
                    FlightPlan.Destination.LoadComponents(AirportComponents.Runways);
                    FlightPlan.DestinationRunway = FlightPlan.Destination.Runways[tfm.Properties.Settings.Default.DestinationRunway];
                }
            }
        }

        public static string GetGateType(FsGate gate)
        {

            string gateType = string.Empty;

            if (gate.Type.ToString() == "none")
            {
                gateType = "None";
            }
            else if (gate.Type.ToString() == "Ramp_GA")
            {
                gateType = "Ramp (GA)";
            }
            else if (gate.Type.ToString() == "Ramp_GA_Small")
            {
                gateType = "Ramp(GA small)";
            }
            else if (gate.Type.ToString() == "Ramp_GA_Medium")
            {
                gateType = "Ramp (GA medium)";
            }
            else if (gate.Type.ToString() == "Ramp_GA_Large")
            {
                gateType = "Ramp (GA large)";
            }
            else if (gate.Type.ToString() == "Ramp_Cargo")
            {
                gateType = "Ramp (cargo)";
            }
            else if (gate.Type.ToString() == "Ramp_Military_Cargo")
            {
                gateType = "Ramp (military cargo)";
            }
            else if (gate.Type.ToString() == "Ramp_Military_Combat")
            {
                gateType = "Ramp (military combat)";
            }
            else if (gate.Type.ToString() == "Gate_Small")
            {
                gateType = "Gate (small)";
            }
            else if (gate.Type.ToString() == "Gate_Medium")
            {
                gateType = "Gate (medium)";
            }
            else if (gate.Type.ToString() == "Gate_Heavy")
            {
                gateType = "Gate (heavy)";
            }
            else if (gate.Type.ToString() == "Dock_GA")
            {
                gateType = "Doc (GA)";
            }
            else if (gate.Type.ToString() == "Fuel")
            {
                gateType = "Fuel box";
            }
            else if (gate.Type.ToString() == "Vehicles")
            {
                gateType = "Vehicles";
            }

            return gateType;
        }

        public static double CalculateInterceptTurn(double bearing)
        {
            double heading = App.instrumentPanel.Heading;

            double interceptTurn;

            if (bearing >= 0 && bearing <= 180)
            {
                interceptTurn = bearing - heading;
            }
            else if (bearing > 180 && bearing <= 360)
            {
                if (heading < 180)
                {
                    interceptTurn = bearing - heading;
                }
                else
                {
                    interceptTurn = bearing - (heading - 360);
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid bearing value. Bearing must be between 0 and 360.");
            }

            return interceptTurn;
        }

        public void SetupAudio()
        {
            driverOut = new WaveOutEvent() { DesiredLatency = 50 };

        mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 2))
            {
                ReadFully = true
            };
    driverOut.Init(mixer);
            // start the mixer. We can then add audio sources as needed.
            driverOut.Play();
                }

public void SetupFlightFollowing()
{
    flightFollowingTimer = new System.Timers.Timer(TimeSpan.FromMinutes(double.Parse(tfm.Properties.Settings.Default.FlightFollowingTimeInterval)).TotalMilliseconds);
    flightFollowingTimer.Elapsed += onFlightFollowingTimerTick;
    if (tfm.Properties.Settings.Default.FlightFollowing)
    {
        flightFollowingTimer.AutoReset = true;
        flightFollowingTimer.Enabled = true;

    }
    else
    {
        flightFollowingTimer.Stop();
    }
}

public static double mapOneRangeToAnother(double sourceNumber, double fromA, double fromB, double toA, double toB, int decimalPrecision)
{
    double deltaA = fromB - fromA;
    double deltaB = toB - toA;
    double scale = deltaB / deltaA;
    double negA = -1 * fromA;
    double offset = (negA * scale) + toA;
    double finalNumber = (sourceNumber * scale) + offset;
    int calcScale = (int)Math.Pow(10, decimalPrecision);
    return (double)Math.Round(finalNumber * calcScale) / calcScale;
}

public void ResetHotkeys()
{
    HotkeyManager.Current.Remove("Command_Key");
    HotkeyManager.Current.Remove("ap_Command_Key");
    foreach (string k in hotkeys)
    {
        HotkeyManager.Current.Remove(k);
    }
    foreach (string k in autopilotHotkeys)
    {
        HotkeyManager.Current.Remove(k);
    }
    if (CommandKeyEnabled)
    {
                HotkeyManager.Current.AddOrReplace("Command_Key", (Keys)tfm.Properties.Hotkeys.Default.Command_Key, commandMode);
        HotkeyManager.Current.AddOrReplace("ap_Command_Key", (Keys)tfm.Properties.Hotkeys.Default.ap_Command_Key, autopilotCommandMode);
    }
}

        private void ReadToggle(Offset instrument, bool toggleStateOn, string name, string OnMsg = "on", string OffMsg = "off", bool SAPI = false)
        {
            if (instrument.ValueChanged)
            {
                if (toggleStateOn)
                {
                    Output(isGauge: false, useSAPI: SAPI, output: $"{name} {OnMsg}");
                }
                else
                {
                    Output(isGauge: false, useSAPI: SAPI, output: $"{name} {OffMsg}");
                }
            }
        }

        public void AnnounceCurrentSpeedBrake()
        {
            Thread.Sleep(250);
            switch (PMDG737Aircraft.CurrentSpeedBrakePosition)
            {
                case 0:
                    Tolk.Output("Speed brake off.");
                    break;
                case 100:
                    Tolk.Output("Speed brake armed.");
                    break;
                case 250:
                    Tolk.Output("Speed brake 50%.");
                    break;
                case 272:
                    Tolk.Output("Speed brake FLT.");
                    break;
                case 400:
                    Tolk.Output("Speed brake 100%.");
                    break;
                default:
                    Tolk.Output($"Speed brake {PMDG737Aircraft.CurrentSpeedBrakePosition}.");
                    break;
            }
        }

        public static double ReadHeadingOffset(double current, double target)
        {
            double left = current - target;
            double right = target - current;
            if (left < 0) left += 360;
            if (right < 0) right += 360;
            return left < right ? -left : right;
        }

        public static double CalculateAngleHeight(double distanceFeet, double slopeAngle)
        {
            var radians = slopeAngle * (Math.PI / 180);
            var height = distanceFeet * Math.Tan(radians);
            return height;
        }

        public static  void LoadAirportsDatabase()
        {

            if (FSUIPCConnection.IsOpen)
            {
                FSUIPCConnection.AirportsDatabase.Clear();
                AirportsDatabase database = FSUIPCConnection.AirportsDatabase;
                if (IsP3DLoaded)
                {
                    database.DatabaseFolder = p3dAirportsDatabaseFolder;
                    database.MakeRunwaysFolder = p3dMakeRunwaysOutputPath;
                }
                else if (isMSFSLoaded)
                {
                    database.DatabaseFolder = msfsAirportsDatabaseFolder;
                    database.MakeRunwaysFolder = msfsMakeRunwaysOutputPath;
                                    }

                if (database.DatabaseFilesExist)
                {

                    database.Load();
Tolk.Output($"Loaded {database.Airports.Count} airports.");
                    logger.Info($"Airports database loaded. Total {database.Airports.Count} airports.");
                }
                else
                {
                    Tolk.Output("Airports database not found.");
                    logger.Debug("Airports database failed to load.");
                }
            } // open connection.
            else
            {
                Tolk.Output("Simulator not found. Unable to load airports database.");
            }
        } // LoadAirportsDatabase


        public static string AddSpacesToMixedCaseStringAndLowercaseFirstChar(string mixedCaseString)
        {
            string result = "";
            bool isFirstCharOfWord = true;
            for (int i = 0; i < mixedCaseString.Length; i++)
            {
                char currentChar = mixedCaseString[i];
                if (currentChar == '_')
                {
                    result += " "; // replace underscore with a space
                    isFirstCharOfWord = true;
                }
                else if (i > 0 && char.IsUpper(currentChar))
                {
                    if (!isFirstCharOfWord)
                    {
                        result += " ";
                    }
                    result += char.ToLower(currentChar);
                    isFirstCharOfWord = false;
                }
                else
                {
                    result += isFirstCharOfWord ? char.ToUpper(currentChar) : currentChar;
                    isFirstCharOfWord = false;
                }
            }
            return result;
        }

        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch
            {
                // An error occurred trying to open the URL in a browser.
                // This could be due to no browser being installed, etc.
                Output(isGauge: false, output: "Failed to open website.");
            }
        }

        public static async void RunMakeRunways(string simulator)
        {
            try
            {
                List<string> makeRwysOutputFiles = new() {"airports.fsm", "f4.csv", "f4x.csv", "f5.csv", "f5x.csv", "FstarRC.rws", "g5.csv", "helipads.csv", "r4.csv", "r5.bin", "r5.csv", "runways.csv", "runways.xml", "SceneryList.txt", "t5.gin", "t5.csv"};
                string fileName = "MakeRwys.exe";
                string sourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "MakeRwys", fileName);
                // Make runways for MSFS.
                #region
                if (simulator == "MSFS")
                {
                    string target = Path.Combine(msfsMakeRunwaysOutputPath, fileName);
                    
                    // Create the make runways output folder.
                    #region
                    if (!Directory.Exists(msfsMakeRunwaysOutputPath))
                    {
                        Directory.CreateDirectory(msfsMakeRunwaysOutputPath);
                        logger.Debug("Creating MSFS make runways output folder.");
                    }
                    else
                    {
                        Directory.Delete(msfsMakeRunwaysOutputPath, true);
                        logger.Debug("Deleting existing MSFS make runways output folder.");
                        Directory.CreateDirectory(msfsMakeRunwaysOutputPath);
                        logger.Debug("Creating MSFS make runways output folder.");
                    }
                    #endregion
                    
                    File.Copy(sourceFile, target, true);
                    logger.Debug($"Copying {sourceFile} to {target}.");
                    logger.Debug("Waiting for make runways to finish.");
                                       ProcessStartInfo startInfo = new ProcessStartInfo(target)
                    {
                        UseShellExecute = true,
                        Verb = "runas",
                        WorkingDirectory = msfsMakeRunwaysOutputPath,
                    };
                    Process makeRunways = Process.Start(startInfo);

                                        makeRunways.WaitForExit();
                    Task.Run(() => BuildAirportsDatabaseAsync(simulator));
                }
                #endregion
                // Make runways for P3D.
                #region
                else if (simulator == "P3D")
                {
                    string p3dTarget = Path.Combine(tfm.Properties.Settings.Default.P3DInstallPath, fileName);
                    File.Copy(sourceFile, p3dTarget, true);

                    // Create the make runways output folder.
                    #region
                    if (!Directory.Exists(p3dMakeRunwaysOutputPath))
                    {
                        Directory.CreateDirectory(p3dMakeRunwaysOutputPath);
                    }
                    else
                    {
                        Directory.Delete(p3dMakeRunwaysOutputPath, true);
                        Directory.CreateDirectory(p3dMakeRunwaysOutputPath);
                    }
                    #endregion
                    
                    ProcessStartInfo startInfo = new ProcessStartInfo(p3dTarget)
                    {
                        WorkingDirectory = tfm.Properties.Settings.Default.P3DInstallPath,
                        UseShellExecute = true,
                        Verb = "runas",
                    };
                    Process makeRunways = Process.Start(startInfo);
                    makeRunways.WaitForExit();

                    // Copy all the make runways output.
                    #region
                    string airports_fsm = Path.Combine(tfm.Properties.Settings.Default.P3DInstallPath, "airports.fsm");
                    string f4_csv = Path.Combine(tfm.Properties.Settings.Default.P3DInstallPath, "f4.csv");
                    string f4x_csv = Path.Combine(tfm.Properties.Settings.Default.P3DInstallPath, "f4x.csv");
                    string f5_csv = Path.Combine(tfm.Properties.Settings.Default.P3DInstallPath, "f5.csv");
                    string f5x_csv = Path.Combine(tfm.Properties.Settings.Default.P3DInstallPath, "f5x.csv");
                    string fstarrc_rws = Path.Combine(tfm.Properties.Settings.Default.P3DInstallPath, "FstarRC.rws");
                    string g5_csv = Path.Combine(tfm.Properties.Settings.Default.P3DInstallPath, "g5.csv");
                    string helipads_csv = Path.Combine(tfm.Properties.Settings.Default.P3DInstallPath, "helipads.csv");
                    string r4_csv = Path.Combine(tfm.Properties.Settings.Default.P3DInstallPath, "r4.csv");
                    string r5_bin = Path.Combine(tfm.Properties.Settings.Default.P3DInstallPath, "r5.bin");
                    string r5_csv = Path.Combine(tfm.Properties.Settings.Default.P3DInstallPath, "r5.csv");
                    string runways_csv = Path.Combine(tfm.Properties.Settings.Default.P3DInstallPath, "runways.csv");
                    string runways_xml = Path.Combine(tfm.Properties.Settings.Default.P3DInstallPath, "runways.xml");
                    string scenery_list_txt = Path.Combine(tfm.Properties.Settings.Default.P3DInstallPath, "SceneryList.txt");
                    string t5_bin = Path.Combine(tfm.Properties.Settings.Default.P3DInstallPath, "t5.bin");
                    string t5_csv = Path.Combine(tfm.Properties.Settings.Default.P3DInstallPath, "t5.csv");

                    if (File.Exists(airports_fsm)) File.Copy(airports_fsm, Path.Combine(p3dMakeRunwaysOutputPath, "airports.fsm"), true);
                    if (File.Exists(f4_csv)) File.Copy(f4_csv, Path.Combine(p3dMakeRunwaysOutputPath, "f4.csv"), true);
                    if (File.Exists(f4x_csv)) File.Copy(f4x_csv, Path.Combine(p3dMakeRunwaysOutputPath, "f4x.csv"), true);
                    if (File.Exists(f5_csv)) File.Copy(f5_csv, Path.Combine(p3dMakeRunwaysOutputPath, "f5.csv"), true);
                    if (File.Exists(f5x_csv)) File.Copy(f5x_csv, Path.Combine(p3dMakeRunwaysOutputPath, "f5x.csv"), true);
                    if (File.Exists(fstarrc_rws)) File.Copy(fstarrc_rws, Path.Combine(p3dMakeRunwaysOutputPath, "FstarRC.rws"), true);
                    if (File.Exists(g5_csv)) File.Copy(g5_csv, Path.Combine(p3dMakeRunwaysOutputPath, "g5.csv"), true);
                    if (File.Exists(helipads_csv)) File.Copy(helipads_csv, Path.Combine(p3dMakeRunwaysOutputPath, "helipads.csv"), true);
                    if (File.Exists(r4_csv)) File.Copy(r4_csv, Path.Combine(p3dMakeRunwaysOutputPath, "r4.csv"), true);
                    if (File.Exists(r5_bin)) File.Copy(r5_bin, Path.Combine(p3dMakeRunwaysOutputPath, "r5.bin"), true);
                    if (File.Exists(r5_csv)) File.Copy(r5_csv, Path.Combine(p3dMakeRunwaysOutputPath, "r5.csv"), true);
                    if (File.Exists(runways_csv)) File.Copy(runways_csv, Path.Combine(p3dMakeRunwaysOutputPath, "runways.csv"), true);
                    if (File.Exists(runways_xml)) File.Copy(runways_xml, Path.Combine(p3dMakeRunwaysOutputPath, "runways.xml"), true);
                    if (File.Exists(scenery_list_txt)) File.Copy(scenery_list_txt, Path.Combine(p3dMakeRunwaysOutputPath, "SceneryList.txt"), true);
                    if (File.Exists(t5_bin)) File.Copy(t5_bin, Path.Combine(p3dMakeRunwaysOutputPath, "t5.bin"), true);
                    if (File.Exists(t5_csv)) File.Copy(t5_csv, Path.Combine(p3dMakeRunwaysOutputPath, "t5.csv"), true);
                    #endregion
                    Task.Run(() => BuildAirportsDatabaseAsync(simulator));
                }
                #endregion
            }
            catch (FileNotFoundException ex)
            {
                System.Windows.MessageBox.Show($"Cannot continue. {ex.Message}");
                logger.Error($"{ex.FileName}[{ex.Source}]:{ex.Message}");
            }
            catch(UnauthorizedAccessException ex)
            {
                System.Windows.MessageBox.Show("Access denied. Run TFM as an administrator and try again.");
                logger.Error(ex.Message);
            }
        }

        public static async void BuildAirportsDatabaseAsync(string simulator)
        {

                            if (FSUIPCConnection.AirportsDatabase.IsLoaded)
                {
                    FSUIPCConnection.AirportsDatabase.Clear();
                logger.Debug("Clearing existing database.");
                }

            try
            {
                var db = FSUIPCConnection.AirportsDatabase;
                logger.Debug("Getting a copy of the current airports database.");
                if (simulator == "MSFS")
                {
                                        db.MakeRunwaysFolder = msfsMakeRunwaysOutputPath;
                    logger.Debug($"Assigned MSFS make runways output folder: {msfsMakeRunwaysOutputPath}.");
                    db.DatabaseFolder = msfsAirportsDatabaseFolder;
                    logger.Debug($"Assigned MSFS airports database folder: {db.DatabaseFolder}");
                }

              if(simulator == "P3D")
                {
                    db.DatabaseFolder = p3dAirportsDatabaseFolder;
                    db.MakeRunwaysFolder = p3dMakeRunwaysOutputPath;
                }

                if (db.MakeRunwaysFilesExist)
                {
                    Progress<string> progress = new Progress<string>();
                    progress.ProgressChanged += (o, s) => logger.Info(s);
                    await db.RebuildDatabaseAsync(progress);
                                        db.Load();
                                        System.Windows.MessageBox.Show($"{simulator} airports build successfully. Total {db.Airports.Count}");
                    logger.Info($"{simulator} airports build successfully. Total {db.Airports.Count}");
                }
            }
            catch(Exception x)
            {
                System.Windows.MessageBox.Show($"{x.Message}");
            }
            
                        }
}
}

