using FSUIPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm.PMDG.PanelObjects
{
    public class SingleStateToggle: PanelObject
    {

        //private Offset<float> _offsetFloat;
        //private Offset<uint> _offsetInt;
        private Offset _offset;
        private PanelObjectType _type = PanelObjectType.SingleState;
                private Dictionary<byte, string> _availableStates = null;
        private KeyValuePair<byte, string> _currentState;
        private double _percentageValue;

        public double percentageValue
        {
            get
            {
                if(this.Offset == Aircraft.pmdg777.FCTL_Speedbrake_Lever)
                {
                    _percentageValue = Math.Truncate((double)((_offset.GetValue<byte>() - 26) * 100) / 74);
                }
                else if(this.Offset == Aircraft.pmdg737.OXY_Needle)
                {
                    _percentageValue = Math.Truncate((double)((_offset.GetValue<byte>() - 0) * 100) / 240);
                }
                return _percentageValue;
            }
        }

        public Dictionary<byte, string> AvailableStates { get => _availableStates; set => _availableStates = value; }
        public KeyValuePair<byte, string> CurrentState
        {
            get
            {
                                                               KeyValuePair<byte, string> item = new KeyValuePair<byte, string>();
                               foreach (KeyValuePair<byte, string> pair in this._availableStates)
                {
                    uint key = this.Offset.GetValue<byte>();
                    if (key == pair.Key)
                    {
                        item = pair;
                        break;
                    }
                }
                                return item;
            } // End Get    
        } // End CurrentState.
                public override PanelObjectType Type
        {
            get => this._type;
            set
            {
                this._type = value;
                base.Type = value;
            }
        }

        public override Offset Offset
        {
            get
            {
                return _offset;
                            }
            set
            {
                _offset = value;
                                base.Offset = value;
            }
        }


        public override string ToString()
        {
            string output = string.Empty;
            // PMDG 777 speedbrake.
            if(this.Offset == Aircraft.pmdg777.FCTL_Speedbrake_Lever)
            {

                                if(_offset.GetValue<byte>() > 0 && _offset.GetValue<byte>() <= 24)
                {
                    output = string.Empty;
                } // ignore conditions.
                // Force TFM to announce off/armed states.
                else if(_offset.GetValue<byte>() == 0 || _offset.GetValue<byte>() == 25)
                {
                    output = $"{this.Name} {this.CurrentState.Value}";
                } // off/armed conditions.

                // Everything else is a free turning knob with a percent deployed value.
                else if(_offset.GetValue<byte>() >= 26)
                {
                                                                                        output = $"{this.Name} {this.percentageValue}%";
                                                                                                                                               } // Everything else.
                           } // Speedbrake.
else             if(this.Offset == Aircraft.pmdg737.OXY_Needle)
            {
                               output = $"{this.Name} {this.percentageValue}%";
            }
            else if(this.Offset == Aircraft.pmdg737.FUEL_FuelTempNeedle)
            {
                output = $"{this.Name} {_offset.GetValue<float>()}";
            }
            else if(this.Offset == Aircraft.pmdg737.APU_EGTNeedle)
            {
                output = $"{this.Name} {_offset.GetValue<float>()}";
            }
            else
            {
                output = $"{this.Name} {this.CurrentState.Value}";
            }
                                                                           
                        return output;
                                            } // End ToString.
           } // End SingleStateToggle.
}// End namespace.
