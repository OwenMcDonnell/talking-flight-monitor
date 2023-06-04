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
        public partial class OverheadOxygen : UserControl
    {

        private SingleStateToggle oxyLevel = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.OXY_Needle).First() as SingleStateToggle;
        private SingleStateToggle oxyLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.OXY_annunPASS_OXY_ON).First() as SingleStateToggle;
        private SingleStateToggle oxySwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.OXY_SwNormal).First() as SingleStateToggle;

        public OverheadOxygen()
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

                Dispatcher.Invoke(() =>
                {
                    oxyLevelTextBox.Text = $"{oxyLevel.percentageValue}%";
                    App.UI.BuildToggleButton(oxyToggleButton, oxyLight, "Oxygen");
                    App.UI.BuildIndicatorTextBox(pacxOxyTextBox, oxyLight, "Pacx oxygen indicator");
                });
            });
        }

        private void oxyToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if(oxySwitch.CurrentState.Value == "on")
            {
                PMDG737Aircraft.PassengerOxygenNormal();
            }
            else
            {
                PMDG737Aircraft.PassengerOxygenOn();
            }
        }
    }
}
