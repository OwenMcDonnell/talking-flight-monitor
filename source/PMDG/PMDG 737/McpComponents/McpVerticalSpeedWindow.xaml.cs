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

namespace tfm.PMDG.PMDG_737.McpComponents
{

        public partial class McpVerticalSpeedWindow : Window
    {
        public McpVerticalSpeedWindow()
        {
            InitializeComponent();
            if ((bool)(vertSpeedToggleButton.IsChecked))
            {
                vertSpeedTextBox.Visibility = Visibility.Visible;
            }
            else
            {
                vertSpeedTextBox.Visibility = Visibility.Hidden;
            }

            if(vertSpeedTextBox.Visibility == Visibility.Visible)
            {
                vertSpeedTextBox.Focus();
            }
            else
            {
                vertSpeedToggleButton.Focus();
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var verticalSpeedSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_VertSpeedBlank).First() as SingleStateToggle;
            App.UI.BuildToggleButton(vertSpeedToggleButton, verticalSpeedSwitch, "Vertical speed", true);

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
                var verticalSpeedSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_VertSpeedBlank).First() as SingleStateToggle;
                
                                Dispatcher.Invoke(() =>
                {
                    vertSpeedTextBox.Text = Aircraft.pmdg737.MCP_VertSpeed.Value.ToString();
                    App.UI.BuildToggleButton(vertSpeedToggleButton, verticalSpeedSwitch, "Vertical speed", true);

                    if ((bool)(vertSpeedToggleButton.IsChecked))
                    {
                        vertSpeedTextBox.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        vertSpeedTextBox.Visibility = Visibility.Hidden;
                    }

                });
            });
        }

        private void vertSpeedTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                PMDG737Aircraft.SetVerticalSpeed(vertSpeedTextBox.Text);
            }
        }

        private void vertSpeedToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.VerticalSpeedIntervene();
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
