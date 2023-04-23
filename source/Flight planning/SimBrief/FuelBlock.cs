using System.Xml;
using System.Xml.Linq;
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

        #region "public methods"
        public static FuelBlock LoadFromXElement(XElement fuelElement)
        {
var            Fuel = new FuelBlock()
            {
                Taxi = double.TryParse(fuelElement.Element("taxi").Value, out double taxi)? taxi : -1,
            EnrouteBurn = double.TryParse(fuelElement.Element("enroute_burn").Value, out double enrouteBurn)? enrouteBurn : -1,
            Contingency = double.TryParse(fuelElement.Element("contingency").Value, out double contingency)? contingency : -1,
            AlternateBurn = double.TryParse(fuelElement.Element("alternate_burn").Value, out double alternateBurn)? alternateBurn : -1,
            Reserve = double.TryParse(fuelElement.Element("reserve").Value, out double reserve)? reserve : -1,
            Etops = double.TryParse(fuelElement.Element("etops").Value, out double etops)? etops : -1,
            Extra = double.TryParse(fuelElement.Element("extra").Value, out double extra)? extra : -1,
            MinTakeoff = double.TryParse(fuelElement.Element("min_takeoff").Value, out double minTakeoff)? minTakeoff : -1,
            PlanTakeoff = double.TryParse(fuelElement.Element("plan_takeoff").Value, out double planTakeoff)? planTakeoff : -1,
            PlanRamp = double.TryParse(fuelElement.Element("plan_ramp").Value, out double planRamp)? planRamp : -1,
            PlanLanding = double.TryParse(fuelElement.Element("plan_landing").Value, out double planLanding)? planLanding : -1,
            AverageFuelFlow = double.TryParse(fuelElement.Element("avg_fuel_flow").Value, out double averageFuelFlow)? averageFuelFlow : -1,
            MaxFuel = double.TryParse(fuelElement.Element("max_tanks").Value, out double maxFuel)? maxFuel : -1,
        };
            return Fuel;
        }
        #endregion
    }
}
