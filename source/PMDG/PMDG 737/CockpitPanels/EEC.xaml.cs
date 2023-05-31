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
        public partial class EEC : UserControl
    {
        public EEC()
        {
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
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
                var leftControlSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ENG_EECSwitch[0]).First() as SingleStateToggle;
                var rightControlSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ENG_EECSwitch[1]).First() as SingleStateToggle;
                var leftControlLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ENG_annunENGINE_CONTROL[0]).First() as SingleStateToggle;
                var rightControlLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ENG_annunENGINE_CONTROL[1]).First() as SingleStateToggle;
                var leftAlternateLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ENG_annunALTN[0]).First() as SingleStateToggle;
                var rightAlternateLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ENG_annunALTN[1]).First() as SingleStateToggle;
                var leftReverserLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ENG_annunREVERSER[0]).First() as SingleStateToggle;
                var rightReverserLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ENG_annunREVERSER[1]).First() as SingleStateToggle;

                Dispatcher.Invoke(() =>
                {
                    App.UI.BuildToggleButton(leftControlToggleButton, leftControlSwitch, "#1");
                    App.UI.BuildToggleButton(rightControlToggleButton, rightControlSwitch, "#2");

                    leftControlTextBox.Text = leftControlLight.CurrentState.Value;
                    rightControlTextBox.Text = rightControlLight.CurrentState.Value;
                    leftAlternateTextBox.Text = leftAlternateLight.CurrentState.Value;
                    rightAlternateTextBox.Text = rightAlternateLight.CurrentState.Value;
                    leftReverserTextBox.Text = leftReverserLight.CurrentState.Value;
                    RightReverserTextBox.Text = rightReverserLight.CurrentState.Value;
                });
            });
        }

        private void leftControlToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var toggle = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ENG_EECSwitch[0]).First() as SingleStateToggle;
            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.EngineEEC1Off();
            }
            else
            {
                PMDG737Aircraft.EngineEEC1On();
            }
        }

        private void rightControlToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var toggle = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ENG_EECSwitch[1]).First() as SingleStateToggle;
            if(toggle.CurrentState.Value == "off")
            {
                PMDG737Aircraft.EngineEEC2Off();
            }
            else
            {
                PMDG737Aircraft.EngineEEC2On();
            }
        }
    }
}
