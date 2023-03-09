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
