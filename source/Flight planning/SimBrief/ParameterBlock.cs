using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm.Flight_planning.SimBrief
{
    public class ParameterBlock
    {

        #region "private fields"
private uint _requestID = 0;
private uint _userID = 0;
private DateTime _timeGenerated;
private string _ofpLayout = string.Empty;
private int _airac = 0;
private string _units = string.Empty;
        #endregion
        #region "public properties"
        public uint RequestID { get => _requestID; set => _requestID = value; }
        public uint UserID { get => _userID; set => _userID = value; }
        public DateTime TimeGenerated { get => _timeGenerated; set => _timeGenerated = value; }
        public string OfpLayout { get => _ofpLayout; set => _ofpLayout = value; }
        public int Airac { get => _airac; set => _airac = value; }
        public string Units { get => _units; set => _units = value; }
        #endregion
    }
}
