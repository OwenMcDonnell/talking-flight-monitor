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
        public partial class TransponderDialog : Window
    {
        public TransponderDialog()
        {
            InitializeComponent();

            transponderCodeTextBox.Focus();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var sourceSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.XPDR_XpndrSelector_2).First() as SingleStateToggle;
            var alternateSourceSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.XPDR_AltSourceSel_2).First() as SingleStateToggle;
            var modeSelector = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.XPDR_ModeSel).First() as SingleStateToggle;
            var failIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.XPDR_annunFAIL).First() as SingleStateToggle;
            App.UI.BuildButton(sourceButton, sourceSwitch, "Source");
            App.UI.BuildButton(altSourceButton, alternateSourceSwitch, "Alternate source");
            App.UI.BuildButton(modeButton, modeSelector, "Mode");
            transponderCodeTextBox.Text = App.instrumentPanel.Transponder.ToString();
            failLightTextBox.Text = failIndicator.CurrentState.Value;

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
                var sourceSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.XPDR_XpndrSelector_2).First() as SingleStateToggle;
                var alternateSourceSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.XPDR_AltSourceSel_2).First() as SingleStateToggle;
                var modeSelector = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.XPDR_ModeSel).First() as SingleStateToggle;
                var failIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.XPDR_annunFAIL).First() as SingleStateToggle;

                Dispatcher.Invoke(() =>
                {
                    App.UI.BuildButton(sourceButton, sourceSwitch, "Source");
                    App.UI.BuildButton(altSourceButton, alternateSourceSwitch, "Alternate source");
                    App.UI.BuildButton(modeButton, modeSelector, "Mode");
                    if (Aircraft.Transponder.ValueChanged)
                    {
                        transponderCodeTextBox.Text = App.instrumentPanel.Transponder.ToString();
                    }
                    
                    failLightTextBox.Text = failIndicator.CurrentState.Value;
                });
            });
        }

        private void transponderCodeTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                PMDG737Aircraft.SetTransponder(transponderCodeTextBox.Text);
            }
        }

        private void transponderCodeTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            transponderCodeTextBox.SelectAll();
        }

        private void sourceButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.TransponderSource();
        }

        private void altSourceButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.TransponderAlternateSource();
        }

        private void modeButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.TransponderMode();
        }

        private void identButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.TransponderIdent();
        }

        private void testButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.TransponderTest();
        }

        private void FocusTransponderCodeInput(object sender, ExecutedRoutedEventArgs e)
        {
            Keyboard.Focus(transponderCodeTextBox);
        }

        private void CycleSource(object sender, ExecutedRoutedEventArgs e)
        {
            sourceButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void CycleAlternateSource(object sender, ExecutedRoutedEventArgs e)
        {
            altSourceButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void CycleModes(object sender, ExecutedRoutedEventArgs e)
        {
            modeButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ActivateIdent(object sender, ExecutedRoutedEventArgs e)
        {
            identButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ActivateTest(object sender, ExecutedRoutedEventArgs e)
        {
            testButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void FocusFailureLight(object sender, ExecutedRoutedEventArgs e)
        {
            Keyboard.Focus(failLightTextBox);
        }

        private void ActivateKeyboardHelp(object sender, ExecutedRoutedEventArgs e)
        {
            WindowBindingsHelp w = new WindowBindingsHelp(CommandBindings);
            w.Show();
        }
    }
}
