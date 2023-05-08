using tfm.Converters;
using tfm.PMDG.PanelObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Globalization;

namespace tfm.PMDG.PMDG_737.McpComponents
{
        public partial class McpAltitudeWindow : Window
    {

       ByteToBoolConverter converter = new ByteToBoolConverter();
        public McpAltitudeWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var vNavToggle = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunVNAV).ToArray()[0] as SingleStateToggle;
            var lvlChangeToggle = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunLVL_CHG).ToArray()[0] as SingleStateToggle;
            var holdToggle = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunALT_HOLD).ToArray()[0] as SingleStateToggle;

            BuildToggleButton(vNavButton, vNavToggle, "Vnav");
            BuildToggleButton(lvlChangeButton, lvlChangeToggle, "Level change");
            BuildToggleButton(holdButton, holdToggle, "Hold");
                    }

        private void BuildToggleButton(ToggleButton control, SingleStateToggle toggle, string alternateName = null, bool reverse = false)
        {
            string name = alternateName == null ? toggle.Name : alternateName;

            control.Content = $"{name} {toggle.CurrentState.Value}";
            control.IsChecked = reverse? !(bool?)converter.Convert(toggle.CurrentState.Key, typeof(bool?), null, CultureInfo.InvariantCulture) : (bool?)converter.Convert(toggle.CurrentState.Key, typeof(bool?), null, CultureInfo.InvariantCulture);
            AutomationProperties.SetName(control, $"{name} {toggle.CurrentState.Value}");
                                }
    }
}
