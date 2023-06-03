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
        public partial class OverheadCvr: UserControl
    {

        private SingleStateToggle cvrSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.FLTREC_SwNormal).First() as SingleStateToggle;
        private SingleStateToggle cvrLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.FLTREC_annunOFF).First() as SingleStateToggle;

        public OverheadCvr()
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

                    App.UI.BuildButton(cvrButton, cvrSwitch, "CVR");
                    App.UI.BuildIndicatorTextBox(cvrTextBox, cvrLight, "CVR indicator");
                });
            });
        }

        private void cvrButton_Click(object sender, RoutedEventArgs e)
        {
            if(cvrSwitch.CurrentState.Value == "normal")
            {
                PMDG737Aircraft.FlightRecorderTest();
            }
            else
            {
                PMDG737Aircraft.FlightRecorderNormal();
            }
        }

        private void eraseButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.FlightRecorderErase();
        }
    }
}
