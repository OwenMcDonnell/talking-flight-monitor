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
using System.Windows.Threading;
using UserControl = System.Windows.Controls.UserControl;

namespace tfm.PMDG.PMDG_737.CockpitPanels
{
        public partial class OverheadPressurization : UserControl
    {

        private SingleStateToggle flightAltitude = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_DisplayFltAlt).First() as SingleStateToggle;
        private SingleStateToggle landingAltitude = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_DisplayLandAlt).First() as SingleStateToggle;
        private SingleStateToggle pressurizationModeSelector = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_PressurizationModeSelector).First() as SingleStateToggle;

        public OverheadPressurization()
        {
            InitializeComponent();
        }

        private async  void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
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

                Dispatcher.Invoke(() =>
                {
                    pressurizationModeComboBox.SelectedIndex = pressurizationModeSelector.CurrentState.Key;
                    landingAltitudeTextBox.Text = landingAltitude.Offset.GetValue<string>();
                    flightAltitudeTextBox.Text = flightAltitude.Offset.GetValue<string>();
                });
            });
        }

        private void pressurizationModeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PMDG737Aircraft.PressModeSelector(pressurizationModeComboBox.SelectedIndex);
        }

        private void flightAltitudeTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
                {
            if (e.Key == Key.Enter)
            {
                if (int.TryParse(flightAltitudeTextBox.Text, out int altitude))
                {
                    PMDG737Aircraft.SetPressFltAlt(altitude);
                }
            }

        }

        private void landingAltitudeTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key== Key.Enter)
            {
                if (int.TryParse(landingAltitudeTextBox.Text, out int altitude))
                {
                    PMDG737Aircraft.SetPressLndAltitude(altitude);
                }
            }
            }
        }
}
