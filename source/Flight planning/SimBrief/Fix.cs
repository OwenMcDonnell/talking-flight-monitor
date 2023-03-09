using System.Xml;
using System.Xml.Linq;
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

        #region "public methods"
        public static List<Fix> LoadNavlogFromXElement(XElement navlogElement)
        {
            var navlog = new List<Fix>();
                        
            // Get the navlog.
            foreach(XElement fixElement in navlogElement.Elements())
            {

                var fix = new Fix()
                {
                    Ident = fixElement.Element("ident").Value,
                    Name = fixElement.Element("name").Value,
                    Type = fixElement.Element("type").Value,
                    Frequency = fixElement.Element("frequency").Value,
                    Latitude = new FsLatitude(double.TryParse(fixElement.Element("pos_lat").Value, out double latitude) ? latitude : default, true),
                    Longitude = new FsLongitude(double.TryParse(fixElement.Element("pos_long").Value, out double longitude) ? longitude : default, true),
                    Stage = fixElement.Element("stage").Value,
                    ViaAirway = fixElement.Element("via_airway").Value,
                    IsSidOrStar = bool.TryParse(fixElement.Element("is_sid_star").Value, out bool isSidStar) ? isSidStar : false,
                Distance = int.TryParse(fixElement.Element("distance").Value, out int distance)? distance : default,
                TrackTrue = int.TryParse(fixElement.Element("track_true").Value, out int trackTrue)? trackTrue : default,
                TrackMag = int.TryParse(fixElement.Element("track_mag").Value, out  int trackMag)? trackMag : default,
                HeadingTrue = int.TryParse(fixElement.Element("heading_true").Value, out int headingTrue)? headingTrue : default,
                HeadingMag = int.TryParse(fixElement.Element("heading_mag").Value, out int headingMag)? headingMag : default,
                AltitudeFeet = int.TryParse(fixElement.Element("altitude_feet").Value, out int altitudeFeet)? altitudeFeet : default,
                IndicatedAirSpeed = int.TryParse(fixElement.Element("ind_airspeed").Value, out int ias)? ias : default,
                TrueAirSpeed = int.TryParse(fixElement.Element("true_airspeed").Value, out int trueAirSpeed)? trueAirSpeed : default,
                MachSpeed = float.TryParse(fixElement.Element("mach").Value, out float mach)? mach : default,
                MachThousanths = float.TryParse(fixElement.Element("mach_thousandths").Value, out float machThousandths)? machThousandths : default,
                WindComponent = int.TryParse(fixElement.Element("wind_component").Value, out int windComponent)? windComponent : default,
                GroundSpeed = int.TryParse(fixElement.Element("groundspeed").Value, out int groundSpeed)? groundSpeed : default,
                TimeLeg = int.TryParse(fixElement.Element("time_leg").Value, out int timeLeg)? timeLeg : default,
                TimeTotal = int.TryParse(fixElement.Element("time_total").Value, out int timeTotal)? timeTotal : default,
                FuelFlow = int.TryParse(fixElement.Element("fuel_flow").Value, out int fuelFlow)? fuelFlow : default,
                FuelLeg = int.TryParse(fixElement.Element("fuel_leg").Value, out int fuelLeg)? fuelLeg : default,
                FuelTotalUsed = int.TryParse(fixElement.Element("fuel_totalused").Value, out int fuelTotalUsed)? fuelTotalUsed : default,
                FuelMinOnBoard = int.TryParse(fixElement.Element("fuel_min_onboard").Value, out int fuelMinOnboard)? fuelMinOnboard : default,
                FuelPlanOnBoard = int.TryParse(fixElement.Element("fuel_plan_onboard").Value, out int fuelPlanOnboard)? fuelPlanOnboard : default,
                Oat = int.TryParse(fixElement.Element("oat").Value, out int oat)? oat : default,
                OatIsaDev = int.TryParse(fixElement.Element("oat_isa_dev").Value, out int oatIsaDev)? oatIsaDev : default,
                WindDirection = int.TryParse(fixElement.Element("wind_dir").Value, out int windDirection)? windDirection : default,
                WindShear = int.TryParse(fixElement.Element("shear").Value, out int windShear)? windShear : default,
                WindSpeed = int.TryParse(fixElement.Element("wind_spd").Value, out int windSpeed)? windSpeed : default,
                TropoPauseFeet = int.TryParse(fixElement.Element("tropopause_feet").Value, out int tropoPause)? tropoPause : default,
                GroundHeight = int.TryParse(fixElement.Element("ground_height").Value, out int groundHeight)? groundHeight : default,
                Mora = int.TryParse(fixElement.Element("mora").Value, out int mora)? mora : default,
                Fir = fixElement.Element("fir").Value,
                FirUnits = fixElement.Element("fir_units").Value,
                FirCrossing = fixElement.Element("fir_crossing").Value,
                WindData = WindLevel.LoadFromXElement(fixElement.Element("wind_data")),
                            };
                navlog.Add(fix);
            }
            return navlog;
        }
        #endregion
    }
}
