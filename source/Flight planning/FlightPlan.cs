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
        public static AirportBlock SimbriefAlternate { get => _simbriefAlternate; set => _simbriefAlternate = value; }
        public static string SimBriefURL { get => _url; }
        public static FuelBlock Fuel { get => _fuel; set => _fuel = value; }
        public static WeightsBlock Weights { get => _weights; set => _weights = value; }
        public static GeneralBlock General { get => _general; set => _general = value; }
        #endregion

        #region "private methods"
        private static async void LoadSimBriefOriginAsync()
        {
            if (SimbriefOrigin != null)
            {
                SimbriefOrigin = null;
            }

            var client = new HttpClient();
            var rawXML = await client.GetStringAsync(SimBriefURL);
            var xmlFlightPlan = XDocument.Parse(rawXML);

            #region "origin airport"
            var origin = new AirportBlock();
            origin.IcaoCode = xmlFlightPlan.Root.Element("origin").Element("icao_code").Value;
            origin.IataCode = xmlFlightPlan.Root.Element("origin").Element("iata_code").Value;
            origin.Elevation = int.Parse(xmlFlightPlan.Root.Element("origin").Element("elevation").Value);
            origin.PosLat = new FsLatitude(double.Parse(xmlFlightPlan.Root.Element("origin").Element("pos_lat").Value), true);
            origin.PosLong = new FsLongitude(double.Parse(xmlFlightPlan.Root.Element("origin").Element("pos_long").Value), true);
            origin.Name = xmlFlightPlan.Root.Element("origin").Element("name").Value;
            origin.PlanRwy = xmlFlightPlan.Root.Element("origin").Element("plan_rwy").Value;
            origin.TransAltitude = int.Parse(xmlFlightPlan.Root.Element("origin").Element("trans_alt").Value);
            origin.TransLevel = int.Parse(xmlFlightPlan.Root.Element("origin").Element("trans_level").Value);
            origin.Metar = xmlFlightPlan.Root.Element("origin").Element("metar").Value;
            origin.MetarTime = DateTime.Parse(xmlFlightPlan.Root.Element("origin").Element("metar_time").Value);
            origin.MetarCategory = xmlFlightPlan.Root.Element("origin").Element("metar_category").Value;
            origin.MetarVisibility = int.Parse(xmlFlightPlan.Root.Element("origin").Element("metar_visibility").Value);
            origin.MetarCeiling = int.Parse(xmlFlightPlan.Root.Element("origin").Element("metar_ceiling").Value);
            origin.Taf = xmlFlightPlan.Root.Element("origin").Element("taf").Value;
            origin.TaffTime = DateTime.Parse(xmlFlightPlan.Root.Element("origin").Element("taf_time").Value);
            origin.AirportType = "origin";
            #endregion

            #region "notams"
            IEnumerable<XElement> notamList = xmlFlightPlan.Root.Element("origin").Descendants("notam");
            if(notamList.Count() > 0)
            {
                if(origin.Notams != null)
                {
                    origin.Notams = null;
                }

                origin.Notams = new List<Notam>();

                foreach(XElement element in notamList)
                {

                    // Skip empty notam elements.
                    if(element.Elements().Count() == 0)
                    {
                        break;
                    }
                    Notam notam = new Notam();

                    notam.SourceID = element.Element("source_id").Value;
                    notam.AccountID = element.Element("account_id").Value;
                    notam.ID = element.Element("notam_id").Value;
                    notam.LocationID = element.Element("location_id").Value;
                    notam.LocationICAO = element.Element("location_icao").Value;
                    notam.LocationName = element.Element("location_name").Value;
                    notam.LocationType = element.Element("location_type").Value;
                    notam.DateCreated = DateTime.Parse(element.Element("date_created").Value);
                    notam.DateEffective = DateTime.Parse(element.Element("date_effective").Value);
                    notam.DateExpire = DateTime.Parse(element.Element("date_expire").Value);
                    if(string.IsNullOrEmpty(element.Element("date_expire_is_estimated").Value) || element.Element("date_expire_is_estimated").Value == "0")
                    {
                        notam.IsExpireDateEstimated = false;
                    }
                    else
                    {
                        notam.IsExpireDateEstimated = true;
                    }
                    
                    notam.DateModified = DateTime.Parse(element.Element("date_modified").Value);
                    notam.Schedule = element.Element("notam_schedule").Value;
                    notam.HTML = element.Element("notam_html").Value;
                    notam.Text = element.Element("notam_text").Value;
                    notam.Raw = element.Element("notam_raw").Value;
                    notam.Nrc = element.Element("notam_nrc").Value;
                    notam.Code = element.Element("notam_qcode").Value;
                    notam.Category = element.Element("notam_qcode_category").Value;
                    notam.Subject = element.Element("notam_qcode_subject").Value;
                    notam.Status = element.Element("notam_qcode_status").Value;
                    
                    if(string.IsNullOrEmpty(element.Element("notam_is_obstacle").Value) || element.Element("notam_is_obstacle").Value == "0")
                    {
                        notam.IsObstacle = false;
                    }
                    else
                    {
                        notam.IsObstacle = true;
                    }
                    origin.Notams.Add(notam);
                }
            }
            #endregion
            
                                    #region "atis"
            IEnumerable<XElement> list = xmlFlightPlan.Root.Element("origin").Descendants("atis");

            if (list.Count() > 0)
            {
// Clear items before adding a new set.
if(origin.Atis != null)
                {
                    origin.Atis = null;
                }
                origin.Atis = new List<Atis>();
                foreach (XElement element in list)
                {

                    // Skip empty atis elements.
                    if(element.Elements().Count() == 0)
                    {
                        break;
                    }
                    Atis atis = new Atis();
                    atis.Network = element.Element("network").Value;
                    atis.Issued = DateTime.Parse(element.Element("issued").Value);
                    atis.Message = element.Element("message").Value;
                    atis.Letter = char.Parse(element.Element("letter").Value);
                    atis.Phonetic = element.Element("phonetic").Value;
                    atis.Type = element.Element("type").Value;
                    origin.Atis.Add(atis);
                }
                }
            #endregion
            SimbriefOrigin = origin;
                                                                    } // LoadSimBriefOrigin

        private async static void LoadSimBriefDestinationAsync()
        {

            if(SimbriefDestination != null)
            {
                SimbriefDestination = null;
            }
            var client = new HttpClient();
            var rawXML = await client.GetStringAsync(SimBriefURL);
            var xmlFlightPlan = XDocument.Parse(rawXML);

            #region "destination airport"
            var destination = new AirportBlock();
            destination.IcaoCode = xmlFlightPlan.Root.Element("destination").Element("icao_code").Value;
            destination.IataCode = xmlFlightPlan.Root.Element("destination").Element("iata_code").Value;
            destination.Elevation = int.Parse(xmlFlightPlan.Root.Element("destination").Element("elevation").Value);
            destination.PosLat = new FsLatitude(double.Parse(xmlFlightPlan.Root.Element("destination").Element("pos_lat").Value), true);
            destination.PosLong = new FsLongitude(double.Parse(xmlFlightPlan.Root.Element("destination").Element("pos_long").Value), true);
            destination.Name = xmlFlightPlan.Root.Element("destination").Element("name").Value;
            destination.PlanRwy = xmlFlightPlan.Root.Element("destination").Element("plan_rwy").Value;
            destination.TransAltitude = int.Parse(xmlFlightPlan.Root.Element("destination").Element("trans_alt").Value);
            destination.TransLevel = int.Parse(xmlFlightPlan.Root.Element("destination").Element("trans_level").Value);
            destination.Metar = xmlFlightPlan.Root.Element("destination").Element("metar").Value;
            destination.MetarTime = DateTime.Parse(xmlFlightPlan.Root.Element("destination").Element("metar_time").Value);
            destination.MetarCategory = xmlFlightPlan.Root.Element("destination").Element("metar_category").Value;
            destination.MetarVisibility = int.Parse(xmlFlightPlan.Root.Element("destination").Element("metar_visibility").Value);
            destination.MetarCeiling = int.Parse(xmlFlightPlan.Root.Element("destination").Element("metar_ceiling").Value);
            destination.Taf = xmlFlightPlan.Root.Element("destination").Element("taf").Value;
            destination.TaffTime = DateTime.Parse(xmlFlightPlan.Root.Element("destination").Element("taf_time").Value);
            destination.AirportType = "destination";
            #endregion

            #region "notams"
            IEnumerable<XElement> notamList = xmlFlightPlan.Root.Element("destination").Descendants("notam");
            if (notamList.Count() > 0)
            {
                if (destination.Notams != null)
                {
                    destination.Notams = null;
                }

                destination.Notams = new List<Notam>();

                foreach (XElement element in notamList)
                {

                    // Skip empty notam elements.
                    if(element.Elements().Count() == 0)
                    {
                        break;
                    }
                    
                    Notam notam = new Notam();

                    notam.SourceID = element.Element("source_id").Value;
                    notam.AccountID = element.Element("account_id").Value;
                    notam.ID = element.Element("notam_id").Value;
                    notam.LocationID = element.Element("location_id").Value;
                    notam.LocationICAO = element.Element("location_icao").Value;
                    notam.LocationName = element.Element("location_name").Value;
                    notam.LocationType = element.Element("location_type").Value;
                    notam.DateCreated = DateTime.Parse(element.Element("date_created").Value);
                    notam.DateEffective = DateTime.Parse(element.Element("date_effective").Value);
                    notam.DateExpire = DateTime.Parse(element.Element("date_expire").Value);
                    if (string.IsNullOrEmpty(element.Element("date_expire_is_estimated").Value) || element.Element("date_expire_is_estimated").Value == "0")
                    {
                        notam.IsExpireDateEstimated = false;
                    }
                    else
                    {
                        notam.IsExpireDateEstimated = true;
                    }

                    notam.DateModified = DateTime.Parse(element.Element("date_modified").Value);
                    notam.Schedule = element.Element("notam_schedule").Value;
                    notam.HTML = element.Element("notam_html").Value;
                    notam.Text = element.Element("notam_text").Value;
                    notam.Raw = element.Element("notam_raw").Value;
                    notam.Nrc = element.Element("notam_nrc").Value;
                    notam.Code = element.Element("notam_qcode").Value;
                    notam.Category = element.Element("notam_qcode_category").Value;
                    notam.Subject = element.Element("notam_qcode_subject").Value;
                    notam.Status = element.Element("notam_qcode_status").Value;

                    if (string.IsNullOrEmpty(element.Element("notam_is_obstacle").Value) || element.Element("notam_is_obstacle").Value == "0")
                    {
                        notam.IsObstacle = false;
                    }
                    else
                    {
                        notam.IsObstacle = true;
                    }
                    destination.Notams.Add(notam);
                }
            }
            #endregion

            #region "atis"
            IEnumerable<XElement> list = xmlFlightPlan.Root.Element("destination").Descendants("atis");

            if (list.Count() > 0)
            {
                // Clear items before adding a new set.
                if (destination.Atis != null)
                {
                    destination.Atis = null;
                }
                destination.Atis = new List<Atis>();
                foreach (XElement element in list)
                {

                    // Skip empty atis elements.
if(element.Elements().Count() == 0)
                    {
                        break;
                    }

                    Atis atis = new Atis();
                    atis.Network = element.Element("network").Value;
                    atis.Issued = DateTime.Parse(element.Element("issued").Value);
                    atis.Message = element.Element("message").Value;
                    atis.Letter = char.Parse(element.Element("letter").Value);
                    atis.Phonetic = element.Element("phonetic").Value;
                    atis.Type = element.Element("type").Value;
                    destination.Atis.Add(atis);
                }
            }
            #endregion

            SimbriefDestination = destination;
        } // LoadSymBriefDestinationAsync

        private static async void LoadSimbriefNavlogAsync()
        {

            if(Navlog != null)
            {
                Navlog.Clear();
            }
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

        private static async void LoadSimBriefFuelAsync()
        {

            HttpClient client = new HttpClient();
            var rawXML = await client.GetStringAsync(SimBriefURL);
            var XMLFlightPlan = XDocument.Parse(rawXML);

            if(Fuel != null)
            {
                Fuel = null;
            }

            Fuel = new FuelBlock();

            Fuel.Taxi = double.Parse(XMLFlightPlan.Root.Element("fuel").Element("taxi").Value);
            Fuel.EnrouteBurn = double.Parse(XMLFlightPlan.Root.Element("fuel").Element("enroute_burn").Value);
            Fuel.Contingency = double.Parse(XMLFlightPlan.Root.Element("fuel").Element("contingency").Value);
            Fuel.AlternateBurn = double.Parse(XMLFlightPlan.Root.Element("fuel").Element("alternate_burn").Value);
            Fuel.Reserve = double.Parse(XMLFlightPlan.Root.Element("fuel").Element("reserve").Value);
            Fuel.Etops = double.Parse(XMLFlightPlan.Root.Element("fuel").Element("etops").Value);
            Fuel.Extra = double.Parse(XMLFlightPlan.Root.Element("fuel").Element("extra").Value);
            Fuel.MinTakeoff = double.Parse(XMLFlightPlan.Root.Element("fuel").Element("min_takeoff").Value);
            Fuel.PlanTakeoff = double.Parse(XMLFlightPlan.Root.Element("fuel").Element("plan_takeoff").Value);
            Fuel.PlanRamp = double.Parse(XMLFlightPlan.Root.Element("fuel").Element("plan_ramp").Value);
            Fuel.PlanLanding = double.Parse(XMLFlightPlan.Root.Element("fuel").Element("plan_landing").Value);
            Fuel.AverageFuelFlow = double.Parse(XMLFlightPlan.Root.Element("fuel").Element("avg_fuel_flow").Value);
            Fuel.MaxFuel = double.Parse(XMLFlightPlan.Root.Element("fuel").Element("max_tanks").Value);

        } // LoadSimBriefFuel

        private static async void LoadSimBriefWeightsAsync()
        {

            HttpClient client = new HttpClient();
            var rawXML = await client.GetStringAsync(SimBriefURL);
            var XMLFlightPlan = XDocument.Parse(rawXML);

            if(Weights != null)
            {
                Weights = null;
            }

            WeightsBlock weights = new WeightsBlock();

            var weightsElement = XMLFlightPlan.Root.Element("weights");
            weights.OEW = double.Parse(weightsElement.Element("oew").Value);
            weights.PaxCount = double.Parse(weightsElement.Element("pax_count").Value);
            weights.BagCount = double.Parse(weightsElement.Element("bag_count").Value);
            weights.PaxCountActual = double.Parse(weightsElement.Element("pax_count_actual").Value);
            weights.BagCountActual = double.Parse(weightsElement.Element("bag_count_actual").Value);
            weights.PaxWeight = double.Parse(weightsElement.Element("pax_weight").Value);
            weights.BagWeight = double.Parse(weightsElement.Element("bag_weight").Value);
            weights.FreightAdded = double.Parse(weightsElement.Element("freight_added").Value);
            weights.Cargo = double.Parse(weightsElement.Element("cargo").Value);
            weights.Payload = double.Parse(weightsElement.Element("payload").Value);
            weights.EstimatedZFW = double.Parse(weightsElement.Element("est_zfw").Value);
            weights.MaxZFW = double.Parse(weightsElement.Element("max_zfw").Value);
            weights.EstimatedTOW = double.Parse(weightsElement.Element("max_tow").Value);
            weights.MaxTOW = double.Parse(weightsElement.Element("max_tow").Value);
            weights.MaxTOWStruct = double.Parse(weightsElement.Element("max_tow_struct").Value);
            weights.MaxTOWLimitCode = weightsElement.Element("tow_limit_code").Value;
            weights.EstimatedLDW = double.Parse(weightsElement.Element("est_ldw").Value);
            weights.MaxLDW = double.Parse(weightsElement.Element("max_ldw").Value);
            weights.EstimatedRamp = double.Parse(weightsElement.Element("est_ramp").Value);

            Weights = weights;
        } // LoadSimBriefWeightsAsync

        private async static void LoadSimBriefGeneralBlock()
        {

            HttpClient client = new HttpClient();
            var rawXML = await client.GetStringAsync(SimBriefURL);
            var XMLFlightPlan = XDocument.Parse(rawXML);

            if(General != null)
            {
                General = null;
            }

            GeneralBlock general = new GeneralBlock();

            var generalElement = XMLFlightPlan.Root.Element("general");
            general.Release = byte.Parse(generalElement.Element("release").Value);
            general.AirlineICAO = generalElement.Element("icao_airline").Value;
            general.FlightNumber = generalElement.Element("flight_number").Value;
            general.IsEtops = generalElement.Element("is_etops").Value == "1" ? true : false;
            general.DxRemarks = generalElement.Element("dx_rmk").Value;
            general.IsDetailedProfile = generalElement.Element("is_detailed_profile").Value == "1" ? true : false;
            general.CruiseProfile = generalElement.Element("cruise_profile").Value;
            general.ClimbProfile = generalElement.Element("climb_profile").Value;
            general.DescentProfile = generalElement.Element("descent_profile").Value;
            general.AlternateProfile = generalElement.Element("alternate_profile").Value;
            general.ReserveProfile = generalElement.Element("reserve_profile").Value;
            general.CostIndex = double.Parse(generalElement.Element("costindex").Value);
            general.ContRule = generalElement.Element("cont_rule").Value;
            general.InitialAltitude = double.Parse(generalElement.Element("initial_altitude").Value);
            general.StepClimbString = generalElement.Element("stepclimb_string").Value;
            general.Avg_temp_dev = double.Parse(generalElement.Element("avg_temp_dev").Value);
            general.AvgTropoPause = double.Parse(generalElement.Element("avg_tropopause").Value);
            general.AvgWindComp = double.Parse(generalElement.Element("avg_wind_comp").Value);
            general.AvgWindDirection = double.Parse(generalElement.Element("avg_wind_dir").Value);
            general.AvgWindSpeed = double.Parse(generalElement.Element("avg_wind_spd").Value);
            general.GcDistance = double.Parse(generalElement.Element("gc_distance").Value);
            general.RouteDistance = double.Parse(generalElement.Element("route_distance").Value);
            general.AirDistance = double.Parse(generalElement.Element("air_distance").Value);
            general.TotalBurn = double.Parse(generalElement.Element("total_burn").Value);
            general.CruiseTas = double.Parse(generalElement.Element("cruise_tas").Value);
            general.CruiseMach = double.Parse(generalElement.Element("cruise_mach").Value);
            general.Passenger = double.Parse(generalElement.Element("passengers").Value);
            general.Route = generalElement.Element("route").Value;
            general.RouteIFPS = generalElement.Element("route_ifps").Value;
            general.RouteNavigraph = generalElement.Element("route_navigraph").Value;
            General = general;
        } // LoadSimBriefGeneralBlock
        #endregion

        #region "public methods"
        public static async void LoadFromXMLAsync()
        {
            LoadSimBriefOriginAsync();
            LoadSimBriefDestinationAsync();
            LoadSimBriefFuelAsync();
            LoadSimBriefWeightsAsync();
            LoadSimBriefGeneralBlock();
            LoadSimbriefNavlogAsync();
                   } // LoadFromXMLAsync

        #endregion
    }
}
