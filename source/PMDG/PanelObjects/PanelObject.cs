using tfm.PMDG;
using FSUIPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm.PMDG.PanelObjects
{
 public abstract class PanelObject
    {

        private string _name = string.Empty;
        private string _panelName = string.Empty;
        private string _panelSection = string.Empty;
        private AircraftVerbosity _verbosity = AircraftVerbosity.None;
        private PanelObjectType _type;
        private Offset _offset;
        private bool _shouldSpeak = true;


                                        public string Name { get => _name; set => _name = value; }
        public string PanelName { get => _panelName; set => _panelName = value; }
        public string PanelSection { get => _panelSection; set => _panelSection = value; }
public AircraftVerbosity Verbosity { get => _verbosity; set => _verbosity = value; }
        public virtual  PanelObjectType Type { get => _type; set => this._type = value; }
        public  virtual  Offset Offset { get => _offset; set => _offset = value; }
        public bool shouldSpeak { get => _shouldSpeak; set => _shouldSpeak = value; }
                   } // End PanelObject.
} // End namespace.
