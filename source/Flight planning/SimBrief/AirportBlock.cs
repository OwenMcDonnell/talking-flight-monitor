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
        private FsLatLonPoint _posLat;
        private FsLatLonPoint _posLong;
        private string _name = string.Empty;
        private string _planRwy = string.Empty;
        private int _transAltitude = 0;
        private int _transLevel = 0;
        private string _metar = string.Empty;
        private string _taf = string.Empty;
        private List<Atis> _atis;
        private string _notams = string.Empty;
        #endregion

        #region "public properties"
        public string IcaoCode { get => _icaoCode; set => _icaoCode = value; }
        public string IataCode { get => _iataCode; set => _iataCode = value; }
        public int Elevation { get => _elevation; set => _elevation = value; }
        public FsLatLonPoint PosLat { get => _posLat; set => _posLat = value; }
        public FsLatLonPoint PosLong { get => _posLong; set => _posLong = value; }
        public string Name { get => _name; set => _name = value; }
        public string PlanRwy { get => _planRwy; set => _planRwy = value; }
        public int TransAltitude { get => _transAltitude; set => _transAltitude = value; }
        public int TransLevel { get => _transLevel; set => _transLevel = value; }
        public string Metar { get => _metar; set => _metar = value; }
        public string Taf { get => _taf; set => _taf = value; }
        public List<Atis> Atis { get => _atis; set => _atis = value; }
        public string Notams { get => _notams; set => _notams = value; }
        #endregion
    }
}
