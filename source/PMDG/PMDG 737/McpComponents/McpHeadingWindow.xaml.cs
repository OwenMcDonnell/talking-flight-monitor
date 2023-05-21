using tfm.Converters;
using tfm.PMDG.PanelObjects;
using System;
using System.Globalization;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace tfm.PMDG.PMDG_737.McpComponents
{
            public partial class McpHeadingWindow : Window
    {

                public McpHeadingWindow()
        {
            InitializeComponent();

            headingTextBox.Focus();
        }

        private async  void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var hdgSelSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunHDG_SEL).ToArray()[0] as SingleStateToggle;
            var lNavSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunLNAV).ToArray()[0] as SingleStateToggle;
            headingTextBox.Text = Aircraft.pmdg737.MCP_Heading.Value.ToString();
            App.UI.BuildToggleButton(hdgSelToggleButton, hdgSelSwitch, "Heading select");
            App.UI.BuildToggleButton(lNavToggleButton, lNavSwitch, "LNav");

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
                var hdgSelSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunHDG_SEL).ToArray()[0] as SingleStateToggle;
                var lNavSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunLNAV).ToArray()[0] as SingleStateToggle;

                Dispatcher.Invoke(() =>
                {
                    if (Aircraft.pmdg737.MCP_Heading.ValueChanged)
                    {
                        headingTextBox.Text = Aircraft.pmdg737.MCP_Heading.Value.ToString();
                    }
                                                                App.UI.BuildToggleButton(hdgSelToggleButton, hdgSelSwitch, "Heading select");
                                                                App.UI.BuildToggleButton(lNavToggleButton, lNavSwitch, "LNav");
                                                       });
            });
        }

                private void hdgSelToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.ToggleHeadingSelect();
        }

        private void lNavToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.ToggleLNav();
        }

        private void headingTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                PMDG737Aircraft.SetHeading(headingTextBox.Text);
            }
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (((e.Key == Key.LeftAlt || e.Key == Key.RightAlt) && e.Key == Key.F4) || e.Key == Key.Escape)
            {
                this.Hide();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
        }

        private void headingTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            headingTextBox.SelectAll();
        }

        private void FocusHeadingInput(object sender, ExecutedRoutedEventArgs e)
        {
            Keyboard.Focus(headingTextBox);
        }

        private void ToggleHdgSel(object sender, ExecutedRoutedEventArgs e)
        {
            hdgSelToggleButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ToggleLNav(object sender, ExecutedRoutedEventArgs e)
        {
            lNavToggleButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }
    }
}
