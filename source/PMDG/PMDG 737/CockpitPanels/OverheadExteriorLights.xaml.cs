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
        public partial class OverheadExteriorLights : UserControl
    {
        private SingleStateToggle leftRetractableLandingLights = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.LTS_LandingLtRetractableSw[0]).First() as SingleStateToggle;
        private SingleStateToggle rightRetractableLandingLights = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.LTS_LandingLtRetractableSw[1]).First() as SingleStateToggle;
        private SingleStateToggle leftFixedLandingLights = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.LTS_LandingLtFixedSw[0]).First() as SingleStateToggle;
        private SingleStateToggle rightFixedLandingLights = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.LTS_LandingLtFixedSw[1]).First() as SingleStateToggle;
        private SingleStateToggle leftTurnOffLights = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.LTS_RunwayTurnoffSw[0]).First() as SingleStateToggle;
        private SingleStateToggle rightTurnOffLights = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.LTS_RunwayTurnoffSw[1]).First() as SingleStateToggle;
        private SingleStateToggle taxiLights = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.LTS_TaxiSw).First() as SingleStateToggle;
        private SingleStateToggle logoLights = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.LTS_LogoSw).First() as SingleStateToggle;
        private SingleStateToggle positionLights = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.LTS_PositionSw).First() as SingleStateToggle;
        private SingleStateToggle antiCollisionLights = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.LTS_AntiCollisionSw).First() as SingleStateToggle;
        private SingleStateToggle wingLights = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.LTS_WingSw).First() as SingleStateToggle;
        private SingleStateToggle wheelWellLights = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.LTS_WheelWellSw).First() as SingleStateToggle;

                public OverheadExteriorLights()
        {
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(500)
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

                    leftRetractableComboBox.SelectedIndex = leftRetractableLandingLights.CurrentState.Key;
                    rightRetractableComboBox.SelectedIndex = rightRetractableLandingLights.CurrentState.Key;
                    App.UI.BuildToggleButton(leftFixedToggleButton, leftFixedLandingLights);
                    App.UI.BuildToggleButton(rightFixedToggleButton, rightFixedLandingLights);
                    App.UI.BuildToggleButton(leftTurnOffToggleButton, leftTurnOffLights);
                    App.UI.BuildToggleButton(rightTurnOffToggleButton, rightTurnOffLights);
                    App.UI.BuildToggleButton(taxiToggleButton, taxiLights);
                    App.UI.BuildToggleButton(logoToggleButton, logoLights);
                    App.UI.BuildButton(positionButton, positionLights);
                    App.UI.BuildToggleButton(antiCollisionToggleButton, antiCollisionLights);
                    App.UI.BuildToggleButton(wingToggleButton, wingLights);
                    App.UI.BuildToggleButton(wheelWellToggleButton, wheelWellLights);

                });
            });
        }

        private void leftRetractableComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PMDG737Aircraft.LeftRetractableLandingLights(leftRetractableComboBox.SelectedIndex);
        }

        private void rightRetractableComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PMDG737Aircraft.RightRetractableLandingLights(rightRetractableComboBox.SelectedIndex);
        }

        private void leftFixedToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.LeftFixedLandingLight();
        }

        private void rightFixedToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.RightFixedLandingLights();
        }

        private void leftTurnOffToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.LeftTurnOffLights();
        }

        private void rightTurnOffToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.RightTurnOffLights();
        }

        private void taxiToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.TaxiLights();
        }

        private void logoToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.LogoLights();
        }

        private void antiCollisionToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.AntiCollisionLights();
        }

        private void wingToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.WingLights();
        }

        private void wheelWellToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.WheelWellLights();
        }

        private void positionButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.PositionLights();
        }
    }
}
