using tfm.PMDG;
using FSUIPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm
{
    public static      class PMDG747Aircraft
    {
        private static double groundSpeed = ((double)Aircraft.GroundSpeed.Value * 3600d) / (65536d * 1852d);

        public static TimeSpan TimeToDestination
        {
            get
            {
                groundSpeed = Math.Round(groundSpeed);
                var time = Aircraft.pmdg747.FMC_DistanceToDest.Value / groundSpeed;
                return TimeSpan.FromHours(time);
            }
        } // TimeToDestination

        public static TimeSpan TimeToTOD
        {
            get
            {
                groundSpeed = Math.Round(groundSpeed);
                var time = Aircraft.pmdg747.FMC_DistanceToTOD.Value / groundSpeed;
                return TimeSpan.FromHours(time);
            }
        } // TimeToTOD

        public static byte CurrentFlapsPosition
        {
            get
            {
                byte flaps = 0;

                switch (Aircraft.pmdg747.FCTL_Flaps_Lever.Value)
                {
                    case 0:
                        flaps = 0;
                        break;
                    case 1:
                        flaps = 1;
                        break;
                    case 2:
                        flaps = 5;
                        break;
                    case 3:
                        flaps = 10;
                        break;
                    case 4:
                        flaps = 20;
                        break;
                    case 5:
                        flaps = 25;
                        break;
                    case 6:
                        flaps = 30;
                        break;
                }
                return flaps;
            }
                    } // CurrentFlapsPosition
    } // End PMDG747Aircraft.
} // End namespace.
