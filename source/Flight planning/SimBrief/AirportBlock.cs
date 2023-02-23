using FSUIPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private string _notams = string.Empty;
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
        public string Notams { get => _notams; set => _notams = value; }
        public DateTime MetarTime { get => _metarTime; set => _metarTime = value; }
        public string MetarCategory { get => _metarCategory; set => _metarCategory = value; }
        public int MetarVisibility { get => _metarVisibility; set => _metarVisibility = value; }
        public int MetarCeiling { get => _metarCeiling; set => _metarCeiling = value; }
        public DateTime TaffTime { get => _taffTime; set => _taffTime = value; }
        public string AirportType { get => _airportType; set => _airportType = value; }
        #endregion
    }
}
