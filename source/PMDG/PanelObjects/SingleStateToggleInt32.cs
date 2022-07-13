using FSUIPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm.PMDG.PanelObjects
{
    public class SingleStateToggleInt32: PanelObject
    {

        private Offset<uint> _offset;
        private PanelObjectType _type = PanelObjectType.SingleState;
        private Dictionary<uint, string> _availableStates = null;
        private KeyValuePair<uint, string> _currentState;

        public Dictionary<uint, string> AvailableStates { get => _availableStates; set => _availableStates = value; }

        public KeyValuePair<uint, string> CurrentState
        {
            get
            {
                KeyValuePair<uint, string> item = new KeyValuePair<uint, string>();

                foreach(KeyValuePair<uint, string> pair in this._availableStates)
                {
                    if(_offset.Value == pair.Key)
                    {
                        item = pair;
                        break;
                    }
                }
                return item;
            } // get
        } // CurrentState

        public override PanelObjectType Type
        {
            get => this._type;
            set
            {
                this._type = value;
                base.Type = value;
            }
                                } // Type

        public override Offset Offset
        {
            get => this._offset;
            set
            {
                this._offset = (Offset<uint>)value;
                base.Offset = value;
            }
        } // Offset

        public override string ToString()
        {
            return $"{this.Name} {this.CurrentState.Value}";
                    } // ToString
    }
} 
