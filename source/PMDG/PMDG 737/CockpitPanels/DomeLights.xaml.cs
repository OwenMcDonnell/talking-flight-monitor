using FSUIPC;
using tfm.PMDG.PanelObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;
using System.Windows.Threading;
using FSUIPC;

namespace tfm.PMDG.PMDG_737.CockpitPanels
{
    /// <summary>
    /// Interaction logic for DomeLights.xaml
    /// </summary>
    public partial class DomeLights : UserControl
    {
        public DomeLights()
        {
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var domeLightsSelector = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.LTS_DomeWhiteSw).First() as SingleStateToggle;

            domeLightsComboBox.SelectedIndex = domeLightsSelector.CurrentState.Key;

            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(300)
            };
            timer.Tick += async (s, args) => await UpdatePanelControlsAsync();
            timer.Start();
        }

        private async Task UpdatePanelControlsAsync()
        {
            await Task.Run(() =>
            {

                var domeLightsSelector = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.LTS_DomeWhiteSw).First() as SingleStateToggle;

                Dispatcher.Invoke(() =>
                {
                    domeLightsComboBox.SelectedIndex = domeLightsSelector.CurrentState.Key;
                                    });
            });
        }

        private void domeLightsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var domeLightsSelector = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.LTS_DomeWhiteSw).First() as SingleStateToggle;
            PMDG737Aircraft.CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_DOME_SWITCH, domeLightsSelector.CurrentState.Key, domeLightsComboBox.SelectedIndex, true);
        }
    }
}
