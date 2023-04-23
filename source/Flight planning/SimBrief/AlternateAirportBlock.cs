using System.Xml;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSUIPC;

namespace tfm.Flight_planning.SimBrief
{
    public class AlternateAirportBlock : AirportBlock
    {
        #region "private fields"
        private double _cruiseAltitude = 0;
        private double _distance = 0;
        private double _gcDistance = 0;
        private double _airDistance = 0;
        private double _trackTrue = 0;
        private double _trackMag = 0;
        private double _tas = 0;
        private double _groundSpeed = 0;
        private string _averageWindComposition = string.Empty;
        private double _averageWindDirection = 0;
        private double _averageWindSpeed = 0;
        private double _averageTropopause = 0;
        private string _averageTDV = string.Empty;
        private double _timeEnroute = 0;
        private double _burn = 0;
        private string _route = string.Empty;
        private string _routeIfps = string.Empty;
        #endregion

        #region "public properties"
        public double CruiseAltitude { get => _cruiseAltitude; set => _cruiseAltitude = value; }
        public double Distance { get => _distance; set => _distance = value; }
        public double GcDistance { get => _gcDistance; set => _gcDistance = value; }
        public double AirDistance { get => _airDistance; set => _airDistance = value; }
        public double TrackTrue { get => _trackTrue; set => _trackTrue = value; }
        public double TrackMag { get => _trackMag; set => _trackMag = value; }
        public double Tas { get => _tas; set => _tas = value; }
        public double GroundSpeed { get => _groundSpeed; set => _groundSpeed = value; }
        public string AverageWindComposition { get => _averageWindComposition; set => _averageWindComposition = value; }
        public double AverageWindDirection { get => _averageWindDirection; set => _averageWindDirection = value; }
        public double AverageWindSpeed { get => _averageWindSpeed; set => _averageWindSpeed = value; }
        public double AverageTropopause { get => _averageTropopause; set => _averageTropopause = value; }
        public string AverageTDV { get => _averageTDV; set => _averageTDV = value; }
        public double TimeEnroute { get => _timeEnroute; set => _timeEnroute = value; }
        public double Burn { get => _burn; set => _burn = value; }
        public string Route { get => _route; set => _route = value; }
        public string RouteIfps { get => _routeIfps; set => _routeIfps = value; }

        #endregion

        #region "public methods"
        public static List<AlternateAirportBlock> LoadFromXElement(IEnumerable<XElement> alternateAirports, string airportType)
        {

            var airports = new List<AlternateAirportBlock>();

            foreach (XElement alternateElement in alternateAirports)
            {
                // Skip empty alternat elements.
                if (alternateElement.IsEmpty)
                {
                    continue;
                }

                var alternateAirport = new AlternateAirportBlock()
                {
                    IcaoCode = alternateElement.Element("icao_code").Value,
                    IataCode = alternateElement.Element("iata_code").Value,
                    Elevation = int.TryParse(alternateElement.Element("elevation").Value, out int elevation) ? elevation : default,
                    PosLat = new FsLatitude(double.TryParse(alternateElement.Element("pos_lat").Value, out double latitude) ? latitude : default, true),
                    PosLong = new FsLongitude(double.TryParse(alternateElement.Element("pos_long").Value, out double longitude) ? longitude : default, true),
                    Name = alternateElement.Element("name").Value,
                    PlanRwy = alternateElement.Element("plan_rwy").Value,
                    TransAltitude = int.TryParse(alternateElement.Element("trans_alt").Value, out int transAltitude) ? transAltitude : -1,
                    TransLevel = int.TryParse(alternateElement.Element("trans_level").Value, out int transLevel) ? transLevel : -1,
                    CruiseAltitude = int.TryParse(alternateElement.Element("cruise_altitude").Value, out int cruiseAltitude) ? cruiseAltitude : -1,
                    Distance = int.TryParse(alternateElement.Element("distance").Value, out int distance) ? distance : -1,
                    GcDistance = int.TryParse(alternateElement.Element("gc_distance").Value, out int gcDistance) ? gcDistance : -1,
                    AirDistance = int.TryParse(alternateElement.Element("air_distance").Value, out int airDistance) ? airDistance : -1,
                    TrackTrue = int.TryParse(alternateElement.Element("track_true").Value, out int trackTrue) ? trackTrue : -1,
                    TrackMag = int.TryParse(alternateElement.Element("track_mag").Value, out int trackMag) ? trackMag : -1,
                    Tas = int.TryParse(alternateElement.Element("tas").Value, out int tas) ? tas : -1,
                    GroundSpeed = int.TryParse(alternateElement.Element("gs").Value, out int groundSpeed) ? groundSpeed : -1,
                AverageWindComposition = alternateElement.Element("avg_wind_comp").Value,
                AverageWindDirection = int.TryParse(alternateElement.Element("avg_wind_dir").Value, out int averageWindDirection)? averageWindDirection : -1,
                AverageWindSpeed = int.TryParse(alternateElement.Element("avg_wind_spd").Value, out int averageWindSpeed)? averageWindSpeed : -1,
                AverageTropopause = int.TryParse(alternateElement.Element("avg_tropopause").Value, out int averageTropopause)? averageTropopause : -1,
                AverageTDV = alternateElement.Element("avg_tdv").Value,
                TimeEnroute = int.TryParse(alternateElement.Element("ete").Value, out int timeEnroute)? timeEnroute : -1,
                Burn = int.TryParse(alternateElement.Element("burn").Value, out int burn)? burn : -1,
                Route = alternateElement.Element("route").Value,
                RouteIfps = alternateElement.Element("route_ifps").Value,
                Metar = alternateElement.Element("metar").Value,
                MetarTime = DateTime.TryParse(alternateElement.Element("metar_time").Value, out DateTime metarTime)? metarTime : default,
                MetarCategory = alternateElement.Element("metar_category").Value,
                MetarVisibility = int.TryParse(alternateElement.Element("metar_visibility").Value, out int metarVisibility)? metarVisibility : -1,
                MetarCeiling = int.TryParse(alternateElement.Element("metar_ceiling").Value, out int metarCeiling)? metarCeiling : -1,
                Taf = alternateElement.Element("taf").Value,
                TaffTime = DateTime.TryParse(alternateElement.Element("taf_time").Value, out DateTime tafTime)? tafTime : default,
                AirportType = airportType,
                Notams = Notam.LoadFromXElement(alternateElement.Elements("notam")),
                Atis = SimBrief.Atis.LoadFromXElement(alternateElement.Elements("atis")),
                };
                airports.Add(alternateAirport);
                    }
            return airports;
            }
            #endregion
        }
}
