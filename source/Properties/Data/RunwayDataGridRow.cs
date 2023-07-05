using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm.Properties
{
    public class RunwayDataGridRow
    {

        public string ID { get; set; }
        public string InUse { get; set; }
        public double Heading { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public string CanLand { get; set; }
        public string CanTakeoff { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}, Heading: {Heading}, Length: {Length}, Width: {Width}, In use: {InUse}, Can takeoff: {CanTakeoff}, Can land: {CanLand}.";
        }
    }
}
