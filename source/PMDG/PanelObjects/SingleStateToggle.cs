﻿using FSUIPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm.PMDG.PanelObjects
{
    public class SingleStateToggle: PanelObject
    {

        private Offset<byte> _offset;
        private PanelObjectType _type = PanelObjectType.SingleState;
                private Dictionary<byte, string> _availableStates = null;
        private KeyValuePair<byte, string> _currentState;

        public Dictionary<byte, string> AvailableStates { get => _availableStates; set => _availableStates = value; }
        public KeyValuePair<byte, string> CurrentState
        {
            get
            {
                                KeyValuePair<byte, string> item = new KeyValuePair<byte, string>();

                foreach (KeyValuePair<byte, string> pair in this._availableStates)
                {
                    if (_offset.Value == pair.Key)
                    {
                        item = pair;
                        break;
                    }
                }
                                return item;
            } // End Get    
        } // End CurrentState.
                public override PanelObjectType Type => this._type;

        public override Offset Offset
        {
            get => this._offset;
            set
            {
                this._offset = (Offset<byte>)value;
                base.Offset = value;
            }
        }


        public override string ToString()
        {
            string output = string.Empty;
            if(this.Name == "Speedbrake")
            {

                                if(_offset.Value > 0 && _offset.Value <= 24)
                {
                    output = string.Empty;
                } // ignore conditions.
                // Force TFM to announce off/armed states.
                else if(_offset.Value == 0 || _offset.Value == 25)
                {
                    output = $"{this.Name} {this.CurrentState.Value}";
                } // off/armed conditions.

                // Everything else is a free turning knob with a percent deployed value.
                else if(_offset.Value >= 26)
                {
                                        {
                        var percent = Math.Truncate((double)((_offset.Value - 26) * 100) / 74);
                        output = $"{this.Name} {percent}%";
                    }
                                                                                                                           } // Everything else.
                           } // Speedbrake.
            else
            {
                output = $"{this.Name} {this.CurrentState.Value}";
            }
                                                                           
                        return output;
                                            } // End ToString.
           } // End SingleStateToggle.
}// End namespace.
