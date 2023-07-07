using FSUIPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm
{
    public partial class App: System.Windows.Application
    {

        public static InstrumentPanel instrumentPanel
        {
            get => new InstrumentPanel();
        }

        public static Utilities Utilities { get => new Utilities(); }
            }

    public class Utilities
    {
        public void LoadDestination()
        {
            if (tfm.Properties.Settings.Default.SaveDestination)
            {
                var airport = FSUIPCConnection.AirportsDatabase.Airports[tfm.Properties.Settings.Default.DestinationAirport];
                var runway = airport.Runways[tfm.Properties.Settings.Default.DestinationRunway];

                if(airport!= null)
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

            if(gate.Type.ToString() == "none")
            {
                gateType = "None";
            }
            else if(gate.Type.ToString() == "Ramp_GA")
            {
                gateType = "Ramp (GA)";
            }
            else if(gate.Type.ToString() == "Ramp_GA_Small")
            {
                gateType = "Ramp(GA small)";
            }
            else if(gate.Type.ToString() == "Ramp_GA_Medium")
            {
                gateType = "Ramp (GA medium)";
            }
            else if(gate.Type.ToString() == "Ramp_GA_Large")
            {
                gateType = "Ramp (GA large)";
            }
            else if(gate.Type.ToString() == "Ramp_Cargo")
            {
                gateType = "Ramp (cargo)";
            }
            else if(gate.Type.ToString() == "Ramp_Military_Cargo")
            {
                gateType = "Ramp (military cargo)";
            }
            else if(gate.Type.ToString() == "Ramp_Military_Combat")
            {
                gateType = "Ramp (military combat)";
            }
            else if(gate.Type.ToString() == "Gate_Small")
            {
                gateType = "Gate (small)";
            }
            else if(gate.Type.ToString() == "Gate_Medium")
            {
                gateType = "Gate (medium)";
            }
            else if(gate.Type.ToString() == "Gate_Heavy")
            {
                gateType = "Gate (heavy)";
            }
            else if(gate.Type.ToString() == "Dock_GA")
            {
                gateType = "Doc (GA)";
            }
            else if(gate.Type.ToString() == "Fuel")
            {
                gateType = "Fuel box";
            }
            else if(gate.Type.ToString() == "Vehicles")
            {
                gateType = "Vehicles";
            }

            return gateType;
        }
    }
}
