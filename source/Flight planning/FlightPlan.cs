using tfm.Flight_planning.SimBrief;
using System;
using System.Xml;
using System.Xml.Linq;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSUIPC;

namespace tfm
{
    static public  class FlightPlan
    {
        #region Private fields
        private static string _url = $"https://www.simbrief.com/api/xml.fetcher.php?userid={Properties.Settings.Default.SimBriefUserID}";
        private static ParameterBlock _parameters = null;
        private static GeneralBlock _general = null;
        private static AirportBlock _simbriefOrigin = null;
        private static AirportBlock _simbriefDestination = null;
        private static List<AlternateAirportBlock> _alternateAirports = null;
        private static FuelBlock _fuel = null;
        private static WeightsBlock _weights = null;
        private static List<Fix> _navlog = null;
        private static string _title = string.Empty;
        private static FsAirport _departureAirport = null;
        private static FsAirport _destinationAirport = null;
        private static FsRunway _destinationRunway = null;
        #endregion

                #region Public properties
        static public string Title
        {
            get
            {
                if(Destination != null && Departure != null)
                {
                    return $"{Departure.Name} to {Destination.Name}";
                }
                else
                {
                    return "Untitled flight plan";
                }
            }
            set
            {
                if(value.Length < 4)
                {
                    throw new ArgumentException("The flight plan title must be longer than 4 characters in length.");
                }
                else
                {
                    _title = value;
                }
            }
        }
        static public FsAirport Departure
        {
            get
            {
                return _departureAirport;
            }
            set
            {
                _departureAirport = value;
            }
        }
        static public FsAirport Destination
        {
            get
            {
                return _destinationAirport;
            }
            set
            {
                _destinationAirport = value;
            }
        }
                public static FsRunway DestinationRunway
        {
            get => _destinationRunway;
            set => _destinationRunway = value;
        }
        public static List<Fix> Navlog { get => _navlog; set => _navlog = value; }
        public static ParameterBlock Parameters { get => _parameters; set => _parameters = value; }
        public static AirportBlock SimbriefOrigin { get => _simbriefOrigin; set => _simbriefOrigin = value; }
        public static AirportBlock SimbriefDestination { get => _simbriefDestination; set => _simbriefDestination = value; }
        public static List<AlternateAirportBlock> AlternateAirports{ get => _alternateAirports; set => _alternateAirports = value; }
        public static string SimBriefURL { get => _url; }
        public static XDocument XMLFlightPlan
        {
            get
            {
                HttpClient client = new HttpClient();
                var rawXML = client.GetStringAsync(SimBriefURL);
                return XDocument.Parse(rawXML.Result);
            }
                   }

        public static FuelBlock Fuel { get => _fuel; set => _fuel = value; }
        public static WeightsBlock Weights { get => _weights; set => _weights = value; }
        public static GeneralBlock General { get => _general; set => _general = value; }
        #endregion

        #region "private methods"
        private static void LoadSimBriefOrigin()
        {
            var originElement = XMLFlightPlan.Root.Element("origin");
            SimbriefOrigin = AirportBlock.LoadFromXElement(originElement, "origin");
                                                                                } // LoadSimBriefOrigin

        private static void LoadSimBriefDestination()
        {
            var destinationElement = XMLFlightPlan.Root.Element("destination");
            SimbriefDestination = AirportBlock.LoadFromXElement(destinationElement, "destination");
       } // LoadSymBriefDestination

        private static void LoadSimbriefNavlog()
        {

            var navlogElement = XMLFlightPlan.Root.Element("navlog");
            Navlog = Fix.LoadNavlogFromXElement(navlogElement);
       }         // LoadSimbriefNavlog

        private static void LoadSimBriefFuel()
        {
            var fuelElement = XMLFlightPlan.Root.Element("fuel");
            Fuel = FuelBlock.LoadFromXElement(fuelElement);
        } // LoadSimBriefFuel

        private static void LoadSimBriefWeights()
        {

                                                                        var weightsElement = XMLFlightPlan.Root.Element("weights");

            Weights = WeightsBlock.LoadFromXElement(weightsElement);
        } // LoadSimBriefWeights

        private static void LoadSimBriefGeneralBlock()
        {
                                                            var generalElement = XMLFlightPlan.Root.Element("general");
            General = GeneralBlock.LoadFromXElement(generalElement);
        } // LoadSimBriefGeneralBlock

        private static void LoadSimBriefAlternateAirports()
        {
                                                           
            var alternateAirportsList = XMLFlightPlan.Root.Elements("alternate");

            AlternateAirports = AlternateAirportBlock.LoadFromXElement(alternateAirportsList, "alternate");
                                              } // LoadSimBriefAlternateAirports

               #endregion

        #region "public methods"
        public static async void LoadFromXML()
        {


            var originTask = Task.Run(() => LoadSimBriefOrigin());
            var destinationTask = Task.Run(() => LoadSimBriefDestination());
            var alternateAirportsTask = Task.Run(() => LoadSimBriefAlternateAirports());
            var fuelTask = Task.Run(() => LoadSimBriefFuel());
            var weightsTask = Task.Run(() => LoadSimBriefWeights());
            var generalTask = Task.Run(() => LoadSimBriefGeneralBlock());
            var navlogTask = Task.Run(() => LoadSimbriefNavlog());
                   } // LoadFromXML

        #endregion
    }
}
