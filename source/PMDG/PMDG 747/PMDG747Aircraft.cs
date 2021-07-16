using tfm.PMDG;
using FSUIPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm.PMDG.PMDG_747
{
    public static      class PMDG747Aircraft
    {
        private static double groundSpeed = ((double)Aircraft.GroundSpeed.Value * 3600d) / (65536d * 1852d);

    } // End PMDG747Aircraft.
} // End namespace.
