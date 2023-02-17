using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm.Flight_planning.SimBrief
{
    public class WindLevel
    {
        #region "private fields"
        private int _altitude = 0;
        private int _windDirection = 0;
        private int _windSpeed = 0;
        private int _oat = 0;
        #endregion

        #region "public properties"
        public int Altitude { get => _altitude; set => _altitude = value; }
        public int WindDirection { get => _windDirection; set => _windDirection = value; }
        public int WindSpeed { get => _windSpeed; set => _windSpeed = value; }
        public int Oat { get => _oat; set => _oat = value; }
        #endregion
    }
}
