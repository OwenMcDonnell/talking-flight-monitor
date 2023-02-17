using FSUIPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm.Flight_planning.SimBrief
{
    public class Fix
    {

        #region "private fields"
        private string _ident = string.Empty;
        private string _name = string.Empty;
        private string _type = string.Empty;
        private string _frequency = string.Empty;
        private FsLatitude _latitude;
        private FsLongitude _longitude;
        private string _stage = string.Empty;
        private string _viaAirway = string.Empty;
        private bool _isSidOrStar = false;
        private int _distance = 0;
        private int _trackTrue = 0;
        private int _trackMag = 0;
        private int _headingTrue = 0;
        private int _headingMag = 0;
        private int _altitudeFeet = 0;
        private int _indicatedAirSpeed = 0;
        private int _trueAirSpeed = 0;
        private double _machSpeed = 0.00;
        private double _machThousanths = 0.00;
        private int _windComponent = 0;
        private int _groundSpeed = 0;
        private int _timeLeg = 0;
        private int _timeTotal = 0;
        private int _fuelFlow = 0;
        private int _fuelLeg = 0;
        private int _fuelTotalUsed = 0;
        private int _fuelMinOnBoard = 0;
        private int _fuelPlanOnBoard = 0;
        private int _oat = 0;
        private int _oatIsaDev = 0;
        private int _windDirection = 0;
        private int _windSpeed = 0;
        private int _windShear = 0;
        private int _tropoPauseFeet = 0;
        private int _groundHeight = 0;
        private int _mora = 0;
        private string _fir = string.Empty;
        private string _firUnits = string.Empty;
        private int[] _firValidLevels;
        private List<WindLevel> _windData;
        private string _firCrossing = string.Empty;
        #endregion

        #region "public properties"
        public string Ident { get => _ident; set => _ident = value; }
        public string Name { get => _name; set => _name = value; }
        public string Type { get => _type; set => _type = value; }
        public string Frequency { get => _frequency; set => _frequency = value; }
        public FsLatitude Latitude { get => _latitude; set => _latitude = value; }
        public FsLongitude Longitude { get => _longitude; set => _longitude = value; }
        public string Stage { get => _stage; set => _stage = value; }
        public string ViaAirway { get => _viaAirway; set => _viaAirway = value; }
        public bool IsSidOrStar { get => _isSidOrStar; set => _isSidOrStar = value; }
        public int Distance { get => _distance; set => _distance = value; }
        public int TrackTrue { get => _trackTrue; set => _trackTrue = value; }
        public int TrackMag { get => _trackMag; set => _trackMag = value; }
        public int HeadingTrue { get => _headingTrue; set => _headingTrue = value; }
        public int HeadingMag { get => _headingMag; set => _headingMag = value; }
        public int AltitudeFeet { get => _altitudeFeet; set => _altitudeFeet = value; }
        public int IndicatedAirSpeed { get => _indicatedAirSpeed; set => _indicatedAirSpeed = value; }
        public int TrueAirSpeed { get => _trueAirSpeed; set => _trueAirSpeed = value; }
        public double MachSpeed { get => _machSpeed; set => _machSpeed = value; }
        public double MachThousanths { get => _machThousanths; set => _machThousanths = value; }
        public int WindComponent { get => _windComponent; set => _windComponent = value; }
        public int GroundSpeed { get => _groundSpeed; set => _groundSpeed = value; }
        public int TimeLeg { get => _timeLeg; set => _timeLeg = value; }
        public int TimeTotal { get => _timeTotal; set => _timeTotal = value; }
        public int FuelFlow { get => _fuelFlow; set => _fuelFlow = value; }
        public int FuelLeg { get => _fuelLeg; set => _fuelLeg = value; }
        public int FuelTotalUsed { get => _fuelTotalUsed; set => _fuelTotalUsed = value; }
        public int FuelMinOnBoard { get => _fuelMinOnBoard; set => _fuelMinOnBoard = value; }
        public int FuelPlanOnBoard { get => _fuelPlanOnBoard; set => _fuelPlanOnBoard = value; }
        public int Oat { get => _oat; set => _oat = value; }
        public int OatIsaDev { get => _oatIsaDev; set => _oatIsaDev = value; }
        public int WindDirection { get => _windDirection; set => _windDirection = value; }
        public int WindSpeed { get => _windSpeed; set => _windSpeed = value; }
        public int WindShear { get => _windShear; set => _windShear = value; }
        public int TropoPauseFeet { get => _tropoPauseFeet; set => _tropoPauseFeet = value; }
        public int GroundHeight { get => _groundHeight; set => _groundHeight = value; }
        public int Mora { get => _mora; set => _mora = value; }
        public string Fir { get => _fir; set => _fir = value; }
        public string FirUnits { get => _firUnits; set => _firUnits = value; }
        public int[] FirValidLevels { get => _firValidLevels; set => _firValidLevels = value; }
        public List<WindLevel> WindData { get => _windData; set => _windData = value; }
        public string FirCrossing { get => _firCrossing; set => _firCrossing = value; }

        #endregion
    }
}
