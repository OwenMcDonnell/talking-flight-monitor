using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm.Flight_planning.SimBrief
{
    public class Atis
    {
        #region "private fields"
        private string _network = string.Empty;
        private DateTime _issued;
        private char _letter;
        private string _phonetic = string.Empty;
        private string _type = string.Empty;
        private string _message = string.Empty;
        #endregion

        #region "public properties"
        public string Network { get => _network; set => _network = value; }
        public DateTime Issued { get => _issued; set => _issued = value; }
        public char Letter { get => _letter; set => _letter = value; }
        public string Phonetic { get => _phonetic; set => _phonetic = value; }
        public string Type { get => _type; set => _type = value; }
        public string Message { get => _message; set => _message = value; }
        #endregion
    }
}
