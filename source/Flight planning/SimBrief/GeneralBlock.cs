using System.Xml;
using System.Xml.Linq;
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

        #region "public methods"
        public static GeneralBlock LoadFromXElement(XElement generalElement)
        {
            var general = new GeneralBlock()
            {
                Release = byte.TryParse(generalElement.Element("release").Value, out byte release) ? release : default,
            AirlineICAO = generalElement.Element("icao_airline").Value,
            FlightNumber = generalElement.Element("flight_number").Value,
            IsEtops = bool.TryParse(generalElement.Element("is_etops").Value, out bool isEtops)? isEtops : false,
            DxRemarks = generalElement.Element("dx_rmk").Value,
            IsDetailedProfile = bool.TryParse(generalElement.Element("is_detailed_profile").Value, out bool isDetailedProfile)? isDetailedProfile : false,
            CruiseProfile = generalElement.Element("cruise_profile").Value,
            ClimbProfile = generalElement.Element("climb_profile").Value,
            DescentProfile = generalElement.Element("descent_profile").Value,
            AlternateProfile = generalElement.Element("alternate_profile").Value,
            ReserveProfile = generalElement.Element("reserve_profile").Value,
            CostIndex = double.TryParse(generalElement.Element("costindex").Value, out double costIndex)? costIndex : -1,
            ContRule = generalElement.Element("cont_rule").Value,
            InitialAltitude = double.TryParse(generalElement.Element("initial_altitude").Value, out double initialAltitude)? initialAltitude : -1,
            StepClimbString = generalElement.Element("stepclimb_string").Value,
            Avg_temp_dev = double.TryParse(generalElement.Element("avg_temp_dev").Value, out double averageTempDev)? averageTempDev : -1,
            AvgTropoPause = double.TryParse(generalElement.Element("avg_tropopause").Value, out double averageTropopause)? averageTropopause : -1,
            AvgWindComp = double.TryParse(generalElement.Element("avg_wind_comp").Value, out double avgWindComp)? avgWindComp : -1,
            AvgWindDirection = double.TryParse(generalElement.Element("avg_wind_dir").Value, out double averageWindDirection)? averageWindDirection : -1,
            AvgWindSpeed = double.TryParse(generalElement.Element("avg_wind_spd").Value, out double averageWindSpeed)? averageWindSpeed : -1,
            GcDistance = double.TryParse(generalElement.Element("gc_distance").Value, out double gcDistance)? gcDistance : -1,
            RouteDistance = double.TryParse(generalElement.Element("route_distance").Value, out double routeDistance)? routeDistance : -1,
            AirDistance = double.TryParse(generalElement.Element("air_distance").Value, out double airDistance)? airDistance : -1,
            TotalBurn = double.TryParse(generalElement.Element("total_burn").Value, out double totalBurn)? totalBurn : -1,
            CruiseTas = double.TryParse(generalElement.Element("cruise_tas").Value, out double cruiseTAS)? cruiseTAS : -1,
            CruiseMach = double.TryParse(generalElement.Element("cruise_mach").Value, out double cruiseMach)? cruiseMach : -1,
            Passenger = double.TryParse(generalElement.Element("passengers").Value, out double passenger)? passenger : -1,
            Route = generalElement.Element("route").Value,
            RouteIFPS = generalElement.Element("route_ifps").Value,
            RouteNavigraph = generalElement.Element("route_navigraph").Value,
        };

            return general;
        }
        #endregion
    }
}
