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
            #region "origin airport"
            var origin = new AirportBlock()
            {
                IcaoCode = XMLFlightPlan.Root.Element("origin").Element("icao_code").Value,
            IataCode = XMLFlightPlan.Root.Element("origin").Element("iata_code").Value,
            Elevation = int.Parse(XMLFlightPlan.Root.Element("origin").Element("elevation").Value),
            PosLat = new FsLatitude(double.Parse(XMLFlightPlan.Root.Element("origin").Element("pos_lat").Value), true),
            PosLong = new FsLongitude(double.Parse(XMLFlightPlan.Root.Element("origin").Element("pos_long").Value), true),
            Name = XMLFlightPlan.Root.Element("origin").Element("name").Value,
            PlanRwy = XMLFlightPlan.Root.Element("origin").Element("plan_rwy").Value,
            TransAltitude = int.Parse(XMLFlightPlan.Root.Element("origin").Element("trans_alt").Value),
            TransLevel = int.Parse(XMLFlightPlan.Root.Element("origin").Element("trans_level").Value),
            Metar = XMLFlightPlan.Root.Element("origin").Element("metar").Value,
            MetarTime = DateTime.Parse(XMLFlightPlan.Root.Element("origin").Element("metar_time").Value),
            MetarCategory = XMLFlightPlan.Root.Element("origin").Element("metar_category").Value,
            MetarVisibility = int.Parse(XMLFlightPlan.Root.Element("origin").Element("metar_visibility").Value),
            MetarCeiling = int.Parse(XMLFlightPlan.Root.Element("origin").Element("metar_ceiling").Value),
            Taf = XMLFlightPlan.Root.Element("origin").Element("taf").Value,
            TaffTime = DateTime.Parse(XMLFlightPlan.Root.Element("origin").Element("taf_time").Value),
            AirportType = "origin",
                    };
                       #endregion

            #region "notams"
            var notamList = XMLFlightPlan.Root.Element("origin").Elements("notam");
                            origin.Notams = new List<Notam>();

                foreach(XElement element in notamList)
                {

                    // Skip empty notam elements.
                    if(element.IsEmpty)
                    {
                        continue;
                    }

                Notam notam = new Notam()
                {
                    SourceID = element.Element("source_id").Value,
                AccountID = element.Element("account_id").Value,
                ID = element.Element("notam_id").Value,
                LocationID = element.Element("location_id").Value,
                LocationICAO = element.Element("location_icao").Value,
                LocationName = element.Element("location_name").Value,
                LocationType = element.Element("location_type").Value,
                DateCreated = DateTime.TryParse(element.Element("date_created").Value, out DateTime dateCreated)? dateCreated : default,
                DateEffective = DateTime.TryParse(element.Element("date_effective").Value, out DateTime dateEffective)? dateEffective : default,
                DateExpire = DateTime.TryParse(element.Element("date_expire").Value, out DateTime  dateExpire)? dateExpire : default,
                                    IsExpireDateEstimated = bool.TryParse(element.Element("date_expire_is_estimated").Value, out bool isExpireDateEstimated)? isExpireDateEstimated : false,
                               DateModified = DateTime.TryParse(element.Element("date_modified").Value, out DateTime dateModified)? dateModified : default,
                Schedule = element.Element("notam_schedule").Value,
                HTML = element.Element("notam_html").Value,
                Text = element.Element("notam_text").Value,
                Raw = element.Element("notam_raw").Value,
                Nrc = element.Element("notam_nrc").Value,
                Code = element.Element("notam_qcode").Value,
                Category = element.Element("notam_qcode_category").Value,
                Subject = element.Element("notam_qcode_subject").Value,
                Status = element.Element("notam_qcode_status").Value,
                                                                   IsObstacle = bool.TryParse(element.Element("notam_is_obstacle").Value, out bool isObsticle)? isObsticle : false,
                                                                                              };

                                       origin.Notams.Add(notam);
                            }
            #endregion
            
                                    #region "atis"
            var list = XMLFlightPlan.Root.Element("origin").Elements("atis");
                                       origin.Atis = new List<Atis>();
                foreach (XElement atisElement in list)
                {

                    // Skip empty atis elements.
                    if(atisElement.IsEmpty)
                    {
                    continue;
                    }
                    Atis atis = new Atis()
                    {
                        Network = atisElement.Element("network").Value,
                Issued = DateTime.TryParse(atisElement.Element("issued").Value, out DateTime issued)? issued : default,
                Message = atisElement.Element("message").Value,
                Letter = char.TryParse(atisElement.Element("letter").Value, out char letter)? letter : default,
                Phonetic = atisElement.Element("phonetic").Value,
                Type = atisElement.Element("type").Value,
            };

            origin.Atis.Add(atis);
                                }
            #endregion
            SimbriefOrigin = origin;
                                                                    } // LoadSimBriefOrigin

        private static void LoadSimBriefDestination()
        {

            if(SimbriefDestination != null)
            {
                SimbriefDestination = null;
            }
                                    
            #region "destination airport"
            var destination = new AirportBlock();
            destination.IcaoCode = XMLFlightPlan.Root.Element("destination").Element("icao_code").Value;
            destination.IataCode = XMLFlightPlan.Root.Element("destination").Element("iata_code").Value;
            destination.Elevation = int.Parse(XMLFlightPlan.Root.Element("destination").Element("elevation").Value);
            destination.PosLat = new FsLatitude(double.Parse(XMLFlightPlan.Root.Element("destination").Element("pos_lat").Value), true);
            destination.PosLong = new FsLongitude(double.Parse(XMLFlightPlan.Root.Element("destination").Element("pos_long").Value), true);
            destination.Name = XMLFlightPlan.Root.Element("destination").Element("name").Value;
            destination.PlanRwy = XMLFlightPlan.Root.Element("destination").Element("plan_rwy").Value;
            destination.TransAltitude = int.Parse(XMLFlightPlan.Root.Element("destination").Element("trans_alt").Value);
            destination.TransLevel = int.Parse(XMLFlightPlan.Root.Element("destination").Element("trans_level").Value);
            destination.Metar = XMLFlightPlan.Root.Element("destination").Element("metar").Value;
            destination.MetarTime = DateTime.Parse(XMLFlightPlan.Root.Element("destination").Element("metar_time").Value);
            destination.MetarCategory = XMLFlightPlan.Root.Element("destination").Element("metar_category").Value;
            destination.MetarVisibility = int.Parse(XMLFlightPlan.Root.Element("destination").Element("metar_visibility").Value);
            destination.MetarCeiling = int.Parse(XMLFlightPlan.Root.Element("destination").Element("metar_ceiling").Value);
            destination.Taf = XMLFlightPlan.Root.Element("destination").Element("taf").Value;
            destination.TaffTime = DateTime.Parse(XMLFlightPlan.Root.Element("destination").Element("taf_time").Value);
            destination.AirportType = "destination";
            #endregion

            #region "notams"
            IEnumerable<XElement> notamList = XMLFlightPlan.Root.Element("destination").Descendants("notam");
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
            IEnumerable<XElement> list = XMLFlightPlan.Root.Element("destination").Descendants("atis");

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
        } // LoadSymBriefDestination

        private static void LoadSimbriefNavlog()
        {

            if(Navlog != null)
            {
                Navlog.Clear();
            }
            Navlog = new List<Fix>();
                                               
            // Get the navlog.
            foreach(XElement fixElement in XMLFlightPlan.Root.Element("navlog").Elements())
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
        }         // LoadSimbriefNavlog

        private static void LoadSimBriefFuel()
        {

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

        private static void LoadSimBriefWeights()
        {

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
        } // LoadSimBriefWeights

        private static void LoadSimBriefGeneralBlock()
        {

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

        private static void LoadSimBriefAlternateAirports()
        {

            if(AlternateAirports != null)
            {
                AlternateAirports = null;
            }
            AlternateAirports = new List<AlternateAirportBlock>();

            #region "airport"
            IEnumerable<XElement> alternateAirportsList = XMLFlightPlan.Root.Elements("alternate");

            foreach(XElement alternateElement in alternateAirportsList)
            {
                // Skip empty alternat elements.
                if(alternateElement.Elements().Count() == 0)
                {
                    break;
                }

                AlternateAirportBlock alternateAirport = new AlternateAirportBlock();
                alternateAirport.IcaoCode = alternateElement.Element("icao_code").Value;
                alternateAirport.IataCode = alternateElement.Element("iata_code").Value;
                alternateAirport.Elevation = int.Parse(alternateElement.Element("elevation").Value);
                alternateAirport.PosLat = new FsLatitude(double.Parse(alternateElement.Element("pos_lat").Value), true);
                alternateAirport.PosLong = new FsLongitude(double.Parse(alternateElement.Element("pos_long").Value), true);
                alternateAirport.Name = alternateElement.Element("name").Value;
                alternateAirport.PlanRwy = alternateElement.Element("plan_rwy").Value;
                alternateAirport.TransAltitude = int.Parse(alternateElement.Element("trans_alt").Value);
                alternateAirport.TransLevel = int.Parse(alternateElement.Element("trans_level").Value);
                alternateAirport.CruiseAltitude = int.Parse(alternateElement.Element("cruise_altitude").Value);
                alternateAirport.Distance = int.Parse(alternateElement.Element("distance").Value);
                alternateAirport.GcDistance = int.Parse(alternateElement.Element("gc_distance").Value);
                alternateAirport.AirDistance = int.Parse(alternateElement.Element("air_distance").Value);
                alternateAirport.TrackTrue = int.Parse(alternateElement.Element("track_true").Value);
                alternateAirport.TrackMag = int.Parse(alternateElement.Element("track_mag").Value);
                alternateAirport.Tas = int.Parse(alternateElement.Element("tas").Value);
                alternateAirport.GroundSpeed = int.Parse(alternateElement.Element("gs").Value);
                alternateAirport.AverageWindComposition = alternateElement.Element("avg_wind_comp").Value;
                alternateAirport.AverageWindDirection = int.Parse(alternateElement.Element("avg_wind_dir").Value);
                alternateAirport.AverageWindSpeed = int.Parse(alternateElement.Element("avg_wind_spd").Value);
                alternateAirport.AverageTropopause = int.Parse(alternateElement.Element("avg_tropopause").Value);
                alternateAirport.AverageTDV = alternateElement.Element("avg_tdv").Value;
                alternateAirport.TimeEnroute = int.Parse(alternateElement.Element("ete").Value);
                alternateAirport.Burn = int.Parse(alternateElement.Element("burn").Value);
                alternateAirport.Route = alternateElement.Element("route").Value;
                alternateAirport.RouteIfps = alternateElement.Element("route_ifps").Value;
                alternateAirport.Metar = alternateElement.Element("metar").Value;
                alternateAirport.MetarTime = DateTime.Parse(alternateElement.Element("metar_time").Value);
                alternateAirport.MetarCategory = alternateElement.Element("metar_category").Value;
                alternateAirport.MetarVisibility = int.Parse(alternateElement.Element("metar_visibility").Value);
                alternateAirport.MetarCeiling = int.Parse(alternateElement.Element("metar_ceiling").Value);
                alternateAirport.Taf = alternateElement.Element("taf").Value;
                alternateAirport.TaffTime = DateTime.Parse(alternateElement.Element("taf_time").Value);
                alternateAirport.AirportType = "alternate";

                                #region "atis"
                IEnumerable<XElement> atisList = alternateElement.Elements("atis");

                if(atisList.Count() > 0)
                {
                    if(alternateAirport.Atis != null)
                    {
                        alternateAirport.Atis = null;
                    }
                }

                alternateAirport.Atis = new List<Atis>();

                foreach(XElement atisElement in atisList)
                {

                    // Skip empty atis elements.
                    if(atisElement.Elements().Count() == 0)
                    {
                        break;
                    }

                    Atis atis = new Atis();

                    atis.Network = atisElement.Element("network").Value;
                    atis.Issued = DateTime.Parse(atisElement.Element("issued").Value);
                    atis.Message = atisElement.Element("message").Value;
                    atis.Letter = char.Parse(atisElement.Element("letter").Value);
                    atis.Phonetic = atisElement.Element("phonetic").Value;
                    atis.Type = atisElement.Element("type").Value;
                    alternateAirport.Atis.Add(atis);
                }
                #endregion

                #region "notams"
                IEnumerable<XElement> notamList = alternateElement.Elements("notam");
                if (notamList.Count() > 0)
                {
                    if (alternateAirport.Notams != null)
                    {
                        alternateAirport.Notams = null;
                    }

                    alternateAirport.Notams = new List<Notam>();

                    foreach (XElement notamElement in notamList)
                    {

                        // Skip empty notam elements.
                        if (notamElement.Elements().Count() == 0)
                        {
                            break;
                        }

                        Notam notam = new Notam();

                        notam.SourceID = notamElement.Element("source_id").Value;
                        notam.AccountID = notamElement.Element("account_id").Value;
                        notam.ID = notamElement.Element("notam_id").Value;
                        notam.LocationID = notamElement.Element("location_id").Value;
                        notam.LocationICAO = notamElement.Element("location_icao").Value;
                        notam.LocationName = notamElement.Element("location_name").Value;
                        notam.LocationType = notamElement.Element("location_type").Value;
                        notam.DateCreated = DateTime.Parse(notamElement.Element("date_created").Value);
                        notam.DateEffective = DateTime.Parse(notamElement.Element("date_effective").Value);
                        notam.DateExpire = DateTime.Parse(notamElement.Element("date_expire").Value);
                        if (string.IsNullOrEmpty(notamElement.Element("date_expire_is_estimated").Value) || notamElement.Element("date_expire_is_estimated").Value == "0")
                        {
                            notam.IsExpireDateEstimated = false;
                        }
                        else
                        {
                            notam.IsExpireDateEstimated = true;
                        }

                        notam.DateModified = DateTime.Parse(notamElement.Element("date_modified").Value);
                        notam.Schedule = notamElement.Element("notam_schedule").Value;
                        notam.HTML = notamElement.Element("notam_html").Value;
                        notam.Text = notamElement.Element("notam_text").Value;
                        notam.Raw = notamElement.Element("notam_raw").Value;
                        notam.Nrc = notamElement.Element("notam_nrc").Value;
                        notam.Code = notamElement.Element("notam_qcode").Value;
                        notam.Category = notamElement.Element("notam_qcode_category").Value;
                        notam.Subject = notamElement.Element("notam_qcode_subject").Value;
                        notam.Status = notamElement.Element("notam_qcode_status").Value;

                        if (string.IsNullOrEmpty(notamElement.Element("notam_is_obstacle").Value) || notamElement.Element("notam_is_obstacle").Value == "0")
                        {
                            notam.IsObstacle = false;
                        }
                        else
                        {
                            notam.IsObstacle = true;
                        }
                        alternateAirport.Notams.Add(notam);
                    }
                }
                #endregion

                AlternateAirports.Add(alternateAirport);
            }
            #endregion
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
