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
    }
}
