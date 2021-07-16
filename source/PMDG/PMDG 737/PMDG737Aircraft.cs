using tfm.PMDG;
using DavyKager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm
{
public static class PMDG737Aircraft
    {

        private static double groundSpeed = ((double)Aircraft.GroundSpeed.Value * 3600d) / (65536d * 1852d);

        public static TimeSpan TimeToDestination
        {
            get
            {
                groundSpeed = Math.Round(groundSpeed);
                double time = Aircraft.pmdg737.FMC_DistanceToDest.Value / groundSpeed;
                return TimeSpan.FromHours(time);
            }
        } // End TimeToDestination.

        public static TimeSpan TimeToTOD
        {
            get
            {
                groundSpeed = Math.Round(groundSpeed);
                double time = Aircraft.pmdg737.FMC_DistanceToTOD.Value / groundSpeed;
                                return TimeSpan.FromHours(time);
            }
        } // End TimeToTOD.

        public static double CurrentFlapsPosition
        {
            get
            {
                return Math.Round(Aircraft.pmdg737.MAIN_TEFlapsNeedle[0].Value);
            }
        } // End CurrentFlapsPosition.
    } // End PMDG737Aircraft.
} // End namespace.
