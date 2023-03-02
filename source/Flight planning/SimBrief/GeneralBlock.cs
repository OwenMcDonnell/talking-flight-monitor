using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm.Flight_planning.SimBrief
{
    public class GeneralBlock
    {

        #region "private fields"
        private byte _release = 0;
        private string _airlineICAO = string.Empty;
        private string _flightNumber = string.Empty;
        private bool _isEtops = false;
        private string _dxRemarks = string.Empty;
        private bool _isDetailedProfile = false;
        private string _cruiseProfile = string.Empty;
        private string _climbProfile = string.Empty;
        private string _descentProfile = string.Empty;
        private string _alternateProfile = string.Empty;
        private string _reserveProfile = string.Empty;
        private double _costIndex = 0;
        private string _contRule = string.Empty;
        private double _initialAltitude = 0;
        private string _stepClimbString = string.Empty;
        private double _avg_temp_dev = 0;
        private double _avgTropoPause = 0;
        private double _avgWindComp = 0;
        private double _avgWindDirection = 0;
        private double _avgWindSpeed = 0;
        private double _gcDistance = 0;
        private double _routeDistance = 0;
        private double _airDistance = 0;
        private double _totalBurn = 0;
        private double _cruiseTas = 0;
        private double _cruiseMach = 0.0;
        private double _passenger = 0;
        private string _route = string.Empty;
        private string _routeIFPS = string.Empty;
        private string _routeNavigraph = string.Empty;
        #endregion

        #region "properties"
        public byte Release { get => _release; set => _release = value; }
        public string AirlineICAO { get => _airlineICAO; set => _airlineICAO = value; }
        public string FlightNumber { get => _flightNumber; set => _flightNumber = value; }
        public bool IsEtops { get => _isEtops; set => _isEtops = value; }
        public string DxRemarks { get => _dxRemarks; set => _dxRemarks = value; }
        public bool IsDetailedProfile { get => _isDetailedProfile; set => _isDetailedProfile = value; }
        public string CruiseProfile { get => _cruiseProfile; set => _cruiseProfile = value; }
        public string ClimbProfile { get => _climbProfile; set => _climbProfile = value; }
        public string DescentProfile { get => _descentProfile; set => _descentProfile = value; }
        public string AlternateProfile { get => _alternateProfile; set => _alternateProfile = value; }
        public string ReserveProfile { get => _reserveProfile; set => _reserveProfile = value; }
        public double CostIndex { get => _costIndex; set => _costIndex = value; }
        public string ContRule { get => _contRule; set => _contRule = value; }
        public double InitialAltitude { get => _initialAltitude; set => _initialAltitude = value; }
        public string StepClimbString { get => _stepClimbString; set => _stepClimbString = value; }
        public double Avg_temp_dev { get => _avg_temp_dev; set => _avg_temp_dev = value; }
        public double AvgTropoPause { get => _avgTropoPause; set => _avgTropoPause = value; }
        public double AvgWindComp { get => _avgWindComp; set => _avgWindComp = value; }
        public double AvgWindDirection { get => _avgWindDirection; set => _avgWindDirection = value; }
        public double AvgWindSpeed { get => _avgWindSpeed; set => _avgWindSpeed = value; }
        public double GcDistance { get => _gcDistance; set => _gcDistance = value; }
        public double RouteDistance { get => _routeDistance; set => _routeDistance = value; }
        public double AirDistance { get => _airDistance; set => _airDistance = value; }
        public double TotalBurn { get => _totalBurn; set => _totalBurn = value; }
        public double CruiseTas { get => _cruiseTas; set => _cruiseTas = value; }
        public double CruiseMach { get => _cruiseMach; set => _cruiseMach = value; }
        public double Passenger { get => _passenger; set => _passenger = value; }
        public string Route { get => _route; set => _route = value; }
        public string RouteIFPS { get => _routeIFPS; set => _routeIFPS = value; }
        public string RouteNavigraph { get => _routeNavigraph; set => _routeNavigraph = value; }

        #endregion
    }
}
