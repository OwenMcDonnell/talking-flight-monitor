using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace tfm.Settings_panels.wpf
{
    public class PMDGVerbosityViewModel
    {
        private string _key;

        public string Name { get; set; }

        public bool IsChecked
        {
            get {   return (bool)tfm.Properties.pmdg737_offsets.Default[_key]; }
            set
            {
                if ((bool)tfm.Properties.pmdg737_offsets.Default[_key] != value)
                {
                    tfm.Properties.pmdg737_offsets.Default[_key] = value;
                    
                    OnPropertyChanged();
                }
            }
        }

        public PMDGVerbosityViewModel(string name, string key)
        {
            _key = key;
            Name = name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
