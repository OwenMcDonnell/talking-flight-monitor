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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace tfm.PMDG.PMDG_737.Forms
{
        public partial class TrimDialog : Window
    {
        public TrimDialog()
        {
            InitializeComponent();

            elevatorTrimTextBox.Focus();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var electricalTrimSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.TRIM_StabTrimMainElecSw_NORMAL).First() as SingleStateToggle;
            var autoPilotStabTrimSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.TRIM_StabTrimAutoPilotSw_NORMAL).First() as SingleStateToggle;
            var stabTrimSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.TRIM_StabTrimSw_NORMAL).First() as SingleStateToggle;
            var stabOutOfTrimLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MAIN_annunSTAB_OUT_OF_TRIM).First() as SingleStateToggle;

            App.UI.BuildButton(elecStabButton, electricalTrimSwitch);
            App.UI.BuildButton(apStabButton, autoPilotStabTrimSwitch);
            App.UI.BuildButton(stabButton, stabTrimSwitch);
                        elevatorTrimTextBox.Text = PMDG737Aircraft.CurrentElevatorTrim.ToString();
            aileronTrimTextBox.Text = PMDG737Aircraft.CurrentAileronTrim.ToString();
            stabTrimTextBox.Text = PMDG737Aircraft.CurrentStabTrim.ToString();
            stabOutOfTrimLightTextBox.Text = stabOutOfTrimLight.CurrentState.Value;

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
                var electricalTrimSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.TRIM_StabTrimMainElecSw_NORMAL).First() as SingleStateToggle;
                var autoPilotStabTrimSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.TRIM_StabTrimAutoPilotSw_NORMAL).First() as SingleStateToggle;
                var stabTrimSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.TRIM_StabTrimSw_NORMAL).First() as SingleStateToggle;
                var stabOutOfTrimLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MAIN_annunSTAB_OUT_OF_TRIM).First() as SingleStateToggle;

                Dispatcher.Invoke(() =>
                {
                    App.UI.BuildButton(elecStabButton, electricalTrimSwitch);
                    App.UI.BuildButton(apStabButton, autoPilotStabTrimSwitch);
                    App.UI.BuildButton(stabButton, stabTrimSwitch);
                    elevatorTrimTextBox.Text = PMDG737Aircraft.CurrentElevatorTrim.ToString();
                    aileronTrimTextBox.Text = PMDG737Aircraft.CurrentAileronTrim.ToString();
                    stabTrimTextBox.Text = PMDG737Aircraft.CurrentStabTrim.ToString();
                    stabOutOfTrimLightTextBox.Text = stabOutOfTrimLight.CurrentState.Value;
                });
            });
        }

        private void elecStabButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.StabTrimElectrical();
        }

        private void apStabButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.StabTrimAutoPilot();
        }

        private void stabButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.StabTrim();
        }

        private void FocusElevatorTrim(object sender, ExecutedRoutedEventArgs e)
        {
            Keyboard.Focus(elevatorTrimTextBox);
        }

        private void FocusAileronTrim(object sender, ExecutedRoutedEventArgs e)
        {
            Keyboard.Focus(aileronTrimTextBox);
        }

        private void FocusStabTrim(object sender, ExecutedRoutedEventArgs e)
        {
            Keyboard.Focus(stabTrimTextBox);
        }

        private void ActivateElectricalTrim(object sender, ExecutedRoutedEventArgs e)
        {
            elecStabButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ActivateAutoPilotTrim(object sender, ExecutedRoutedEventArgs e)
        {
            apStabButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ActivateStabTrim(object sender, ExecutedRoutedEventArgs e)
        {
            stabButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void FocusOutOfTrimIndicator(object sender, ExecutedRoutedEventArgs e)
        {
            Keyboard.Focus(stabOutOfTrimLightTextBox);
        }

        private void ActivateKeyboardHelp(object sender, ExecutedRoutedEventArgs e)
        {
            WindowBindingsHelp w = new WindowBindingsHelp(CommandBindings);
            w.Show();
        }

        private void IncreaseElevatorTrim(object sender, ExecutedRoutedEventArgs e)
        {
            PMDG737Aircraft.TrimWheelUp();
        }

        private void DecreaseElevatorTrim(object sender, ExecutedRoutedEventArgs e)
        {
            PMDG737Aircraft.TrimWheelDown();
        }

        private void AileronTrimLeft(object sender, ExecutedRoutedEventArgs e)
        {
            PMDG737Aircraft.AileronTrimLeft();
        }

        private void AileronTrimRight(object sender, ExecutedRoutedEventArgs e)
        {
            PMDG737Aircraft.AileronTrimRight();
        }
    }
}
