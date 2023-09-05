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

        public string GetGateType(FsGate gate)
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

        ()
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
    flightFollowingTimer = new System.Timers.Timer(TimeSpan.FromMinutes(double.Parse(Properties.Settings.Default.FlightFollowingTimeInterval)).TotalMilliseconds);
    flightFollowingTimer.Elapsed += onFlightFollowingTimerTick;
    if (Properties.Settings.Default.FlightFollowing)
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
        HotkeyManager.Current.AddOrReplace("Command_Key", (Keys)Properties.Hotkeys.Default.Command_Key, commandMode);
        HotkeyManager.Current.AddOrReplace("ap_Command_Key", (Keys)Properties.Hotkeys.Default.ap_Command_Key, autopilotCommandMode);
    }
}




    }
        }
