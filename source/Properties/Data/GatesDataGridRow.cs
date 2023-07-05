using FSUIPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm.Properties
{
    public class GatesDataGridRow
    {
public string ID { get; set; }
                public string Type { get; set; }
        public string InUse { get; set; }
        public double RadiusFeet { get; set; }
        public override string ToString()
        {
            return $"ID: {ID}, Type: {Type}, InUse: {InUse}, Radias: {RadiusFeet}.";
        }
    }
}
