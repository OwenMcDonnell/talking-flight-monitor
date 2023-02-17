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
        private static AirportBlock _simbriefAlternate = null;
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
        public static AirportBlock SimbriefAlternate { get => _simbriefAlternate; set => _simbriefAlternate = value; }
        public static string SimBriefURL { get => _url; }
        #endregion

#region "private methods"

private static async void LoadSimbriefNavlogAsync()
        {

            Navlog = new List<Fix>();
            // Get the simbrief flight plan in raw xml format.
            HttpClient client = new HttpClient();
            var rawXml = client.GetStringAsync(_url);

            // Parse the raw xml into a structured document.
            var xmlFlightPlan = XDocument.Parse(rawXml.Result);

            // Get the navlog.
            foreach(XElement fixElement in xmlFlightPlan.Root.Element("navlog").Elements())
            {
                var fix = new Fix();
                fix.Ident = fixElement.Element("ident").Value;
                fix.Name = fixElement.Element("name").Value;
                fix.Type = fixElement.Element("type").Value;
                fix.Frequency = fixElement.Element("frequency").Value;
                fix.Latitude = new FsLatitude(double.Parse(fixElement.Element("pos_lat").Value), true);
                fix.Longitude = new FsLongitude(double.Parse(fixElement.Element("pos_long").Value), true);
                fix.Stage = fixElement.Element("stage").Value;
                fix.ViaAirway = fixElement.Element("via_airway").Value;
                fix.IsSidOrStar = fixElement.Element("is_sid_star").Value == "1" ? true : false;
                fix.Distance = int.Parse(fixElement.Element("distance").Value);
                fix.TrackTrue = int.Parse(fixElement.Element("distance").Value);
                fix.TrackMag = int.Parse(fixElement.Element("track_mag").Value);
                fix.HeadingTrue = int.Parse(fixElement.Element("heading_true").Value);
                fix.HeadingMag = int.Parse(fixElement.Element("heading_mag").Value);
                fix.AltitudeFeet = int.Parse(fixElement.Element("altitude_feet").Value);
                fix.IndicatedAirSpeed = int.Parse(fixElement.Element("ind_airspeed").Value);
                fix.TrueAirSpeed = int.Parse(fixElement.Element("true_airspeed").Value);
                fix.MachSpeed = float.Parse(fixElement.Element("mach").Value);
                fix.MachThousanths = float.Parse(fixElement.Element("mach_thousandths").Value);
                fix.WindComponent = int.Parse(fixElement.Element("wind_component").Value);
                fix.GroundSpeed = int.Parse(fixElement.Element("groundspeed").Value);
                fix.TimeLeg = int.Parse(fixElement.Element("time_leg").Value);
                fix.TimeTotal = int.Parse(fixElement.Element("time_total").Value);
                fix.FuelFlow = int.Parse(fixElement.Element("fuel_flow").Value);
                fix.FuelLeg = int.Parse(fixElement.Element("fuel_leg").Value);
                fix.FuelTotalUsed = int.Parse(fixElement.Element("fuel_totalused").Value);
                fix.FuelMinOnBoard = int.Parse(fixElement.Element("fuel_min_onboard").Value);
                fix.FuelPlanOnBoard = int.Parse(fixElement.Element("fuel_plan_onboard").Value);
                fix.Oat = int.Parse(fixElement.Element("oat").Value);
                fix.OatIsaDev = int.Parse(fixElement.Element("oat_isa_dev").Value);
                fix.WindDirection = int.Parse(fixElement.Element("wind_dir").Value);
                fix.WindShear = int.Parse(fixElement.Element("shear").Value);
                fix.WindSpeed = int.Parse(fixElement.Element("wind_spd").Value);
                fix.TropoPauseFeet = int.Parse(fixElement.Element("tropopause_feet").Value);
                fix.GroundHeight = int.Parse(fixElement.Element("ground_height").Value);
                fix.Mora = int.Parse(fixElement.Element("mora").Value);
                fix.Fir = fixElement.Element("fir").Value;
                fix.FirUnits = fixElement.Element("fir_units").Value;
                fix.FirCrossing = fixElement.Element("fir_crossing").Value == null ? "none" : fixElement.Element("fir_crossing").Value;

                    
                Navlog.Add(fix);
                //FirValidLevels = new int[] { fixElement.Element("fir_valid_levels").Value },
                // wind levels
            } // loop through fixes.
        }         // LoadSimbriefNavlogAsync
#endregion

        #region "public methods"
        public static async void LoadFromXMLAsync()
        {
            LoadSimbriefNavlogAsync();
                   } // LoadFromXMLAsync

        #endregion
    }
}
