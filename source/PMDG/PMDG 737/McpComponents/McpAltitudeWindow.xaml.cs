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
using System.Windows.Threading;
using System.Globalization;

namespace tfm.PMDG.PMDG_737.McpComponents
{
        public partial class McpAltitudeWindow : Window
    {

       ByteToBoolConverter converter = new ByteToBoolConverter();
        public McpAltitudeWindow()
        {
            InitializeComponent();
            altitudeTextBox.Focus();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var vNavToggle = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunVNAV).ToArray()[0] as SingleStateToggle;
            var lvlChangeToggle = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunLVL_CHG).ToArray()[0] as SingleStateToggle;
            var holdToggle = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunALT_HOLD).ToArray()[0] as SingleStateToggle;
            altitudeTextBox.Text = Aircraft.pmdg737.MCP_Altitude.Value.ToString();
            App.UI.BuildToggleButton(vNavToggleButton, vNavToggle, "VNav");
            App.UI.BuildToggleButton(lvlChangeToggleButton, lvlChangeToggle, "Level change");
            App.UI.BuildToggleButton(holdToggleButton, holdToggle, "Hold");

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
                var vNavToggle = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunVNAV).ToArray()[0] as SingleStateToggle;
                var lvlChangeToggle = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunLVL_CHG).ToArray()[0] as SingleStateToggle;
                var holdToggle = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunALT_HOLD).ToArray()[0] as SingleStateToggle;

                Dispatcher.Invoke(() =>
                {
                    if (Aircraft.pmdg737.MCP_Altitude.ValueChanged)
                    {
                        altitudeTextBox.Text = Aircraft.pmdg737.MCP_Altitude.Value.ToString();
                    }
                                                                App.UI.BuildToggleButton(vNavToggleButton, vNavToggle, "VNav");
                                                                                    App.UI.BuildToggleButton(lvlChangeToggleButton, lvlChangeToggle, "Level change");
                                                                                    App.UI.BuildToggleButton(holdToggleButton, holdToggle, "Hold");
                                                        });
            });
        }

                private void interveneButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.AltitudeIntervene();
        }

        private void vNavButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.ToggleVNav();
                    }

        private void lvlChangeButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.ToggleLevelChange();
        }

        private void holdButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.ToggleAltitudeHold();
        }

        private void altitudeTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                PMDG737Aircraft.SetAltitude(altitudeTextBox.Text);
            }
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(((e.Key == Key.LeftAlt || e.Key == Key.RightAlt) && e.Key == Key.F4) || e.Key == Key.Escape)
            {
                this.Hide();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
        }

        private void altitudeTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            altitudeTextBox.SelectAll();
        }

        private void FocusAltitudeInputExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Keyboard.Focus(altitudeTextBox);
        }

        private void ActivateAltitudeIntervene(object sender, ExecutedRoutedEventArgs e)
        {
            interveneButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ToggleVNav(object sender, ExecutedRoutedEventArgs e)
        {
            vNavToggleButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));            
        }

        private void ToggleLevelChange(object sender, ExecutedRoutedEventArgs e)
        {
            lvlChangeToggleButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));            
        }

        private void ToggleAltitudeHold(object sender, ExecutedRoutedEventArgs e)
        {
            holdToggleButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ActivateKeyCommandHelp(object sender, ExecutedRoutedEventArgs e)
        {
            WindowBindingsHelp w = new WindowBindingsHelp(CommandBindings);
            w.Show();
                    }
    }
}
