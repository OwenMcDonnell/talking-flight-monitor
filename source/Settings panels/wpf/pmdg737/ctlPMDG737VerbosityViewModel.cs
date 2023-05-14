using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tfm.PMDG.PanelObjects;
using tfm.PMDG;

namespace tfm.Settings_panels.wpf.pmdg737
{
    public class ctlPMDG737VerbosityViewModel
    {
        public ObservableCollection<PMDGVerbosityViewModel> Settings { get; set; }
        
        public ctlPMDG737VerbosityViewModel (string PanelName = null, string PanelSection = null)
        {
            // Initialize Settings and add SettingViewModel instances
            Settings = new ObservableCollection<PMDGVerbosityViewModel>();
           PMDGVerbositySetting[] Controls = PMDG737VerbosityItems.pMDGVerbositySettings.Where(x => x.PanelSection == PanelSection && x.PanelName == PanelName).ToArray();
            foreach (PMDGVerbositySetting Control in Controls)
            {
                
                Settings.Add(new PMDGVerbosityViewModel(Control.Name, Control.SettingKey));
            }
        }
    }
}
