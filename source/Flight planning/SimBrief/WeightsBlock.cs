using System.Xml;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm.Flight_planning.SimBrief
{
    public class WeightsBlock
    {

        #region "private fields"
        private double _OEW = 0;
        private double _paxCount = 0;
        private double _bagCount = 0;
        private double _paxCountActual = 0;
        private double _bagCountActual = 0;
        private double _paxWeight = 0;
        private double _bagWeight = 0;
        private double _freightAdded = 0;
        private double _cargo = 0;
        private double _payload = 0;
        private double _estimatedZFW = 0;
        private double _maxZFW = 0;
        private double _estimatedTOW = 0;
        private double _maxTOW = 0;
        private double _maxTOWStruct = 0;
        private string _maxTOWLimitCode = string.Empty;
        private double _estimatedLDW = 0;
        private double _maxLDW = 0;
        private double _estimatedRamp = 0;
        #endregion

        #region "public properties"
        public double OEW { get => _OEW; set => _OEW = value; }
        public double PaxCount { get => _paxCount; set => _paxCount = value; }
        public double BagCount { get => _bagCount; set => _bagCount = value; }
        public double PaxCountActual { get => _paxCountActual; set => _paxCountActual = value; }
        public double BagCountActual { get => _bagCountActual; set => _bagCountActual = value; }
        public double PaxWeight { get => _paxWeight; set => _paxWeight = value; }
        public double BagWeight { get => _bagWeight; set => _bagWeight = value; }
        public double FreightAdded { get => _freightAdded; set => _freightAdded = value; }
        public double Cargo { get => _cargo; set => _cargo = value; }
        public double Payload { get => _payload; set => _payload = value; }
        public double EstimatedZFW { get => _estimatedZFW; set => _estimatedZFW = value; }
        public double MaxZFW { get => _maxZFW; set => _maxZFW = value; }
        public double EstimatedTOW { get => _estimatedTOW; set => _estimatedTOW = value; }
        public double MaxTOW { get => _maxTOW; set => _maxTOW = value; }
        public double MaxTOWStruct { get => _maxTOWStruct; set => _maxTOWStruct = value; }
        public string MaxTOWLimitCode { get => _maxTOWLimitCode; set => _maxTOWLimitCode = value; }
        public double EstimatedLDW { get => _estimatedLDW; set => _estimatedLDW = value; }
        public double MaxLDW { get => _maxLDW; set => _maxLDW = value; }
        public double EstimatedRamp { get => _estimatedRamp; set => _estimatedRamp = value; }
        #endregion

        #region "public methods"
        public static WeightsBlock LoadFromXElement(XElement weightsElement)
        {
            var loadSheet = new WeightsBlock()
            {
                OEW = double.TryParse(weightsElement.Element("oew").Value, out double oew)? oew : -1,
            PaxCount = double.TryParse(weightsElement.Element("pax_count").Value, out double paxCount)? paxCount : -1,
            BagCount = double.TryParse(weightsElement.Element("bag_count").Value, out double bagCount)? bagCount : -1,
            PaxCountActual = double.TryParse(weightsElement.Element("pax_count_actual").Value, out double paxCountActual)? paxCountActual : -1,
            BagCountActual = double.TryParse(weightsElement.Element("bag_count_actual").Value, out double bagCountActual)? bagCountActual : -1,
            PaxWeight = double.TryParse(weightsElement.Element("pax_weight").Value, out double paxWeight)? paxWeight : -1,
            BagWeight = double.TryParse(weightsElement.Element("bag_weight").Value, out double bagWeight)? bagWeight : -1,
            FreightAdded = double.TryParse(weightsElement.Element("freight_added").Value, out double freightAdded)? freightAdded : -1,
            Cargo = double.TryParse(weightsElement.Element("cargo").Value, out double cargo)? cargo : -1,
            Payload = double.TryParse(weightsElement.Element("payload").Value, out double payload)? payload : -1,
            EstimatedZFW = double.TryParse(weightsElement.Element("est_zfw").Value, out double estimatedZFW)? estimatedZFW : -1,
            MaxZFW = double.TryParse(weightsElement.Element("max_zfw").Value, out double maxZFW)? maxZFW : -1,
            EstimatedTOW = double.TryParse(weightsElement.Element("max_tow").Value, out double estimatedTOW)? estimatedTOW : -1,
            MaxTOW = double.TryParse(weightsElement.Element("max_tow").Value, out double maxTOW)? maxTOW : -1,
            MaxTOWStruct = double.TryParse(weightsElement.Element("max_tow_struct").Value, out double maxTOWStruct)? maxTOWStruct : -1,
            MaxTOWLimitCode = weightsElement.Element("tow_limit_code").Value,
            EstimatedLDW = double.TryParse(weightsElement.Element("est_ldw").Value, out double estimatedLDW)? estimatedLDW : -1,
            MaxLDW = double.TryParse(weightsElement.Element("max_ldw").Value, out double maxLDW)? maxLDW : -1,
            EstimatedRamp = double.TryParse(weightsElement.Element("est_ramp").Value, out double estimatedRamp)? estimatedRamp : -1,
        };

            return loadSheet;
        }
        #endregion
    }
}
