using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
