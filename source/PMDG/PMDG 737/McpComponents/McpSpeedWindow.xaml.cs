using tfm.PMDG.PanelObjects;
using System.Windows.Automation;
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

namespace tfm.PMDG.PMDG_737.McpComponents
{


        public partial class McpSpeedWindow : Window
    {
        public McpSpeedWindow()
        {
            InitializeComponent();

            speedTextBox.Focus();
        }

        private async  void Window_Loaded(object sender, RoutedEventArgs e)
        {

                                    var interveneSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_IASBlank).First() as SingleStateToggle;
            var autoThrottleSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_ATArmSw).First() as SingleStateToggle;
            var n1Light = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunN1).First() as SingleStateToggle;
            var speedLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunSPEED).First() as SingleStateToggle;
            var spoilerASwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.FCTL_Spoiler_Sw[0]).First() as SingleStateToggle;
            var spoilerBSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.FCTL_Spoiler_Sw[1]).First() as SingleStateToggle;
            var autoBrakeSelector = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MAIN_AutobrakeSelector).First() as SingleStateToggle;
            var n1Selector = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MAIN_N1SetSelector).First() as SingleStateToggle;

                        App.UI.BuildButton(n1SelectorButton, n1Selector, "N1 selector");
            App.UI.BuildToggleButton(spoilerAToggleButton, spoilerASwitch, "Spoiler/A");
            App.UI.BuildToggleButton(spoilerBToggleButton, spoilerBSwitch, "Spoiler/B");
            App.UI.BuildToggleButton(speedToggleButton, speedLight, "Speed");
            App.UI.BuildToggleButton(autoThrottleToggleButton, autoThrottleSwitch);
            App.UI.BuildToggleButton(n1ToggleButton, n1Light, "N1");
            App.UI.BuildToggleButton(interveneToggleButton, interveneSwitch, reverse: true);

/*            The speed input is not available when
          Intervene is off. So, disable it when
            speed intervene is off, and enable it when intervene is on. */
            #region "Intervene"
            if (interveneSwitch.CurrentState.Value == "on")
            {
                speedTextBox.IsEnabled = true;
                speedTextBox.Text = Aircraft.pmdg737.MCP_IASMach.Value.ToString();
            }
            else
            {
                speedTextBox.Text = string.Empty;
                speedTextBox.IsEnabled = false;
            }
            #endregion

            // Auto brake.
            #region "Auto brake"
            autoBrakeTextBox.Text = autoBrakeSelector.CurrentState.Value;
            #endregion

            // Changeover button.
            #region "C/O"
            string changeOverText = PMDG737Aircraft.SpeedType == AircraftSpeed.Indicated ? "C/O - indicated" : "C/O - Mach";
            string speedInputName = PMDG737Aircraft.SpeedType == AircraftSpeed.Indicated ? "Indicated airspeed" : "Mach speed";
            changeOverButton.Content = changeOverText;
            AutomationProperties.SetName(changeOverButton, changeOverText);
            AutomationProperties.SetName(speedTextBox, speedInputName);

            #endregion

            // Speed brake.
            #region "Speed brake"
            switch (PMDG737Aircraft.CurrentSpeedBrakePosition)
            {
                case 0:
                    speedBrakeTextBox.Text = "off";
                    break;
                case 100:
                    speedBrakeTextBox.Text = "arm";
                    break;
                case 250:
                    speedBrakeTextBox.Text = "50%";
                    break;
                case 272:
                    speedBrakeTextBox.Text = "FLT";
                    break;
                case 400:
                    speedBrakeTextBox.Text = "100%";
                    break;
                default:
                    speedBrakeTextBox.Text = PMDG737Aircraft.CurrentSpeedBrakePosition.ToString();
                    break;
            }
            #endregion


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

                var interveneSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_IASBlank).First() as SingleStateToggle;
                var autoThrottleSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_ATArmSw).First() as SingleStateToggle;
                var n1Light = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunN1).First() as SingleStateToggle;
                var speedLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunSPEED).First() as SingleStateToggle;
                var spoilerASwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.FCTL_Spoiler_Sw[0]).First() as SingleStateToggle;
                var spoilerBSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.FCTL_Spoiler_Sw[1]).First() as SingleStateToggle;
                var autoBrakeSelector = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MAIN_AutobrakeSelector).First() as SingleStateToggle;
                var n1Selector = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MAIN_N1SetSelector).First() as SingleStateToggle;

                Dispatcher.Invoke(() =>
                {
                    
                    App.UI.BuildButton(n1SelectorButton, n1Selector, "N1 selector"); 
                    App.UI.BuildToggleButton(spoilerAToggleButton, spoilerASwitch, "Spoiler/A");
                    App.UI.BuildToggleButton(spoilerBToggleButton, spoilerBSwitch, "Spoiler/B");
                    App.UI.BuildToggleButton(speedToggleButton, speedLight, "Speed");
                    App.UI.BuildToggleButton(n1ToggleButton, n1Light, "N1");
                    App.UI.BuildToggleButton(autoThrottleToggleButton, autoThrottleSwitch);
                    App.UI.BuildToggleButton(interveneToggleButton, interveneSwitch, reverse: true);

                    /*            The speed input is not available when
          Intervene is off. So, disable it when
            speed intervene is off, and enable it when intervene is on. */

                    #region "interveen"
                    if (interveneSwitch.Offset.ValueChanged)
                    {
                        if (interveneSwitch.CurrentState.Value == "on")
                        {
                            speedTextBox.IsEnabled = true;
                            speedTextBox.Text = Aircraft.pmdg737.MCP_IASMach.Value.ToString();
                        }
                        else
                        {
                            speedTextBox.Text = string.Empty;
                            speedTextBox.IsEnabled = false;
                        }
                    }
                    #endregion

                    // Auto brake.
                    #region "Auto brake"
                    if (Aircraft.pmdg737.MAIN_AutobrakeSelector.ValueChanged)
                    {
                        autoBrakeTextBox.Text = autoBrakeSelector.CurrentState.Value;
                    }
                    #endregion

                    // Changeover button.
                    #region "C/O"
                    string changeOverText = PMDG737Aircraft.SpeedType == AircraftSpeed.Indicated ? "C/O - indicated" : "C/O - Mach";
                    string speedInputName = PMDG737Aircraft.SpeedType == AircraftSpeed.Indicated ? "Indicated airspeed" : "Mach speed";
                    changeOverButton.Content = changeOverText;
                    AutomationProperties.SetName(changeOverButton, changeOverText);
                    AutomationProperties.SetName(speedTextBox, speedInputName);

                    #endregion

                    // Speed brake.
                    #region "Speed brake"
                    switch (PMDG737Aircraft.CurrentSpeedBrakePosition)
                    {
                        case 0:
                            speedBrakeTextBox.Text = "off";
                            break;
                        case 100:
                            speedBrakeTextBox.Text = "arm";
                            break;
                        case 250:
                            speedBrakeTextBox.Text = "50%";
                            break;
                        case 272:
                            speedBrakeTextBox.Text = "FLT";
                            break;
                        case 400:
                            speedBrakeTextBox.Text = "100%";
                            break;
                        default:
                            speedBrakeTextBox.Text = PMDG737Aircraft.CurrentSpeedBrakePosition.ToString();
                            break;
                    }
                    #endregion

                });
            });
        }

        private void interveneToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.SpeedIntervene();
        }

        private void changeOverButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.ChangeOver();
        }

        private void autoThrottleToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.AutoThrottle();
        }

        private void n1SelectorButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.N1SetSelector();
        }

        private void n1ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.N1();
        }

        private void speedToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.SpeedHold();
        }

        private void atDisengageButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.AutoThrottleDisengage();
        }

        private void spoilerAToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.SpoilerAToggle();
        }

        private void spoilerBToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.SpoilerBToggle();
        }

        private void speedTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                PMDG737Aircraft.SetSpeed(speedTextBox.Text);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Hide();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (((e.Key == Key.LeftAlt || e.Key == Key.RightAlt) && e.Key == Key.F4) || e.Key == Key.Escape)
            {
                Hide();
            }
        }
    }
}
