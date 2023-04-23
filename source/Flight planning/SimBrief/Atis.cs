using System.Xml;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSUIPC;

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

        #region "public methods"
        public static List<Atis> LoadFromXElement(IEnumerable<XElement> atisList)
        {

            var atisElements = new List<Atis>();

            foreach (XElement atisElement in atisList)
            {

                // Skip empty atis elements.
                if (atisElement.IsEmpty)
                {
                    continue;
                }
                Atis atis = new Atis()
                {
                    Network = atisElement.Element("network").Value,
                    Issued = DateTime.TryParse(atisElement.Element("issued").Value, out DateTime issued) ? issued : default,
                    Message = atisElement.Element("message").Value,
                    Letter = char.TryParse(atisElement.Element("letter").Value, out char letter) ? letter : default,
                    Phonetic = atisElement.Element("phonetic").Value,
                    Type = atisElement.Element("type").Value,
                };

                atisElements.Add(atis);
            }
            return atisElements;
        }
        #endregion
    }
}
