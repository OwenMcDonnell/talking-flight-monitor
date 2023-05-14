using tfm.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Controls.Primitives;

using tfm.PMDG.PanelObjects;

namespace tfm
{
    public partial class App : System.Windows.Application
    {
        public static  UIHelpers UI
        {
            get => new UIHelpers();
        }
    }

    public class UIHelpers
    {
        private ByteToBoolConverter converter = new ByteToBoolConverter();

        public void BuildToggleButton(ToggleButton control, SingleStateToggle toggle, string alternateName = null, bool reverse = false)
        {
            string name = alternateName == null ? toggle.Name : alternateName;
            control.Content = $"{name}";

            control.IsChecked = reverse ? !(bool?)converter.Convert(toggle.CurrentState.Key, typeof(bool?), null, CultureInfo.InvariantCulture) : (bool?)converter.Convert(toggle.CurrentState.Key, typeof(bool?), null, CultureInfo.InvariantCulture);
            AutomationProperties.SetName(control, $"{name}");
        }
    }


}