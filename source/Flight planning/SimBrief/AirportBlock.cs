using FSUIPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace tfm.Flight_planning.SimBrief
{
    public class AirportBlock
    {

        #region "private fields"
        private string _icaoCode = string.Empty;
        private string _iataCode = string.Empty;
        private int _elevation = 0;
        private FsLatitude _posLat;
        private FsLongitude _posLong;
        private string _name = string.Empty;
        private string _planRwy = string.Empty;
        private int _transAltitude = 0;
        private int _transLevel = 0;
        private string _metar = string.Empty;
        private DateTime _metarTime = DateTime.Now;
        private string _metarCategory = string.Empty;
        private int _metarVisibility;
        private int _metarCeiling;
        private string _taf = string.Empty;
        private DateTime _taffTime = DateTime.Now;
        private List<Atis> _atis;
        private List<Notam> _notams;
        private string _airportType = string.Empty; // Not in XML. Origin, destination, alternate ...
        #endregion

        #region "public properties"
        public string IcaoCode { get => _icaoCode; set => _icaoCode = value; }
        public string IataCode { get => _iataCode; set => _iataCode = value; }
        public int Elevation { get => _elevation; set => _elevation = value; }
        public FsLatitude PosLat { get => _posLat; set => _posLat = value; }
        public FsLongitude PosLong { get => _posLong; set => _posLong = value; }
        public string Name { get => _name; set => _name = value; }
        public string PlanRwy { get => _planRwy; set => _planRwy = value; }
        public int TransAltitude { get => _transAltitude; set => _transAltitude = value; }
        public int TransLevel { get => _transLevel; set => _transLevel = value; }
        public string Metar { get => _metar; set => _metar = value; }
        public string Taf { get => _taf; set => _taf = value; }
        public List<Atis> Atis { get => _atis; set => _atis = value; }
        public List<Notam> Notams { get => _notams; set => _notams = value; }
        public DateTime MetarTime { get => _metarTime; set => _metarTime = value; }
        public string MetarCategory { get => _metarCategory; set => _metarCategory = value; }
        public int MetarVisibility { get => _metarVisibility; set => _metarVisibility = value; }
        public int MetarCeiling { get => _metarCeiling; set => _metarCeiling = value; }
        public DateTime TaffTime { get => _taffTime; set => _taffTime = value; }
        public string AirportType { get => _airportType; set => _airportType = value; }
        #endregion

        #region "factory methods"
        
        public static AirportBlock LoadFromXElement(XElement airportElement, string airportType)
        {

            #region "airport"
            var airport = new AirportBlock()
            {
                IcaoCode = airportElement.Element("icao_code").Value,
                IataCode = airportElement.Element("iata_code").Value,
                Elevation = int.TryParse(airportElement.Element("elevation").Value, out int elevation) ? elevation : 0,

                                PosLat = new FsLatitude(double.TryParse(airportElement.Element("pos_lat").Value, out double latitude) ? latitude : 0, true),
                                                                PosLong = new FsLongitude(double.TryParse(airportElement.Element("pos_long").Value, out double longitude) ? longitude : 0, true),

                Name = airportElement.Element("name").Value,
                PlanRwy = airportElement.Element("plan_rwy").Value,
                TransAltitude = int.TryParse(airportElement.Element("trans_alt").Value, out int transAltitude)? transAltitude : 0,
                TransLevel = int.TryParse(airportElement.Element("trans_level").Value, out int transLevel)? transLevel : 0,
                Metar = airportElement.Element("metar").Value,
                MetarTime = DateTime.TryParse(airportElement.Element("metar_time").Value, out DateTime metarTime)? metarTime : default,
                MetarCategory = airportElement.Element("metar_category").Value,
                MetarVisibility = int.TryParse(airportElement.Element("metar_visibility").Value, out int metarVisibility)? metarVisibility : 0,
                MetarCeiling = int.TryParse(airportElement.Element("metar_ceiling").Value, out int metarCeiling)? metarCeiling : 0,
                Taf = airportElement.Element("taf").Value,
                TaffTime = DateTime.TryParse(airportElement.Element("taf_time").Value, out DateTime tafTime)? tafTime : default,
                AirportType = airportType,
            };
            #endregion

            #region "notams"
            var notamList = airportElement.Elements("notam");
            airport.Notams = new List<Notam>();

            foreach (XElement notamElement in notamList)
            {

                // Skip empty notam elements.
                if (notamElement.IsEmpty)
                {
                    continue;
                }

                Notam notam = new Notam()
                {
                    SourceID = notamElement.Element("source_id").Value,
                    AccountID = notamElement.Element("account_id").Value,
                    ID = notamElement.Element("notam_id").Value,
                    LocationID = notamElement.Element("location_id").Value,
                    LocationICAO = notamElement.Element("location_icao").Value,
                    LocationName = notamElement.Element("location_name").Value,
                    LocationType = notamElement.Element("location_type").Value,
                    DateCreated = DateTime.TryParse(notamElement.Element("date_created").Value, out DateTime dateCreated) ? dateCreated : default,
                    DateEffective = DateTime.TryParse(notamElement.Element("date_effective").Value, out DateTime dateEffective) ? dateEffective : default,
                    DateExpire = DateTime.TryParse(notamElement.Element("date_expire").Value, out DateTime dateExpire) ? dateExpire : default,
                    IsExpireDateEstimated = bool.TryParse(notamElement.Element("date_expire_is_estimated").Value, out bool isExpireDateEstimated) ? isExpireDateEstimated : false,
                    DateModified = DateTime.TryParse(notamElement.Element("date_modified").Value, out DateTime dateModified) ? dateModified : default,
                    Schedule = notamElement.Element("notam_schedule").Value,
                    HTML = notamElement.Element("notam_html").Value,
                    Text = notamElement.Element("notam_text").Value,
                    Raw = notamElement.Element("notam_raw").Value,
                    Nrc = notamElement.Element("notam_nrc").Value,
                    Code = notamElement.Element("notam_qcode").Value,
                    Category = notamElement.Element("notam_qcode_category").Value,
                    Subject = notamElement.Element("notam_qcode_subject").Value,
                    Status = notamElement.Element("notam_qcode_status").Value,
                    IsObstacle = bool.TryParse(notamElement.Element("notam_is_obstacle").Value, out bool isObsticle) ? isObsticle : false,
                };

                airport.Notams.Add(notam);
            }

            #endregion

            #region "atis"
            var atisList= airportElement.Elements("atis");
            airport.Atis = new List<Atis>();
            
            foreach (XElement atisElement in atisList)
            {

                // Skip empty atis elements.
                if (atisElement.IsEmpty)
                {
                    continue;
                }
                Atis atis = new Atis()
                {
                    Network = atisElement.Element("network").Value,
                    Issued = DateTime.TryParse(atisElement.Element("issued").Value, out DateTime issued) ? issued : default,
                    Message = atisElement.Element("message").Value,
                    Letter = char.TryParse(atisElement.Element("letter").Value, out char letter) ? letter : default,
                    Phonetic = atisElement.Element("phonetic").Value,
                    Type = atisElement.Element("type").Value,
                };

                airport.Atis.Add(atis);
            }
            #endregion

            return airport;
        }
        #endregion
    }
}
