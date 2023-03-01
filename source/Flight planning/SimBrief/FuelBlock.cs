using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm.Flight_planning.SimBrief
{
    public class FuelBlock 
    {

        #region "private fields"
        private double _taxi = 0;
        private double _enrouteBurn = 0;
        private double _contingency = 0;
        private double _alternateBurn = 0;
        private double _reserve = 0;
        private double _etops = 0;
        private double _extra = 0;
        private double _minTakeoff = 0;
        private double _planTakeoff = 0;
        private double _planRamp = 0;
        private double _planLanding = 0;
        private double _averageFuelFlow = 0;
        private double _maxFuel = 0;
        #endregion

        #region "public properties"
        public double Taxi { get => _taxi; set => _taxi = value; }
        public double EnrouteBurn { get => _enrouteBurn; set => _enrouteBurn = value; }
        public double Contingency { get => _contingency; set => _contingency = value; }
        public double AlternateBurn { get => _alternateBurn; set => _alternateBurn = value; }
        public double Reserve { get => _reserve; set => _reserve = value; }
        public double Etops { get => _etops; set => _etops = value; }
        public double Extra { get => _extra; set => _extra = value; }
        public double MinTakeoff { get => _minTakeoff; set => _minTakeoff = value; }
        public double PlanTakeoff { get => _planTakeoff; set => _planTakeoff = value; }
        public double PlanRamp { get => _planRamp; set => _planRamp = value; }
        public double PlanLanding { get => _planLanding; set => _planLanding = value; }
        public double AverageFuelFlow { get => _averageFuelFlow; set => _averageFuelFlow = value; }
        public double MaxFuel { get => _maxFuel; set => _maxFuel = value; }
        #endregion

    }
}
