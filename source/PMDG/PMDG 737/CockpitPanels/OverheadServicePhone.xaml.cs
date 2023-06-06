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
using UserControl = System.Windows.Controls.UserControl;
using System.Windows.Threading;

namespace tfm.PMDG.PMDG_737.CockpitPanels
{
        public partial class OverheadServicePhone : UserControl
    {

        private SingleStateToggle servicePhone = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.COMM_ServiceInterphoneSw).First() as SingleStateToggle;

        public OverheadServicePhone()
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
                    App.UI.BuildToggleButton(servicePhoneToggleButton, servicePhone);
                });
            });
        }

        private void servicePhoneToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if(servicePhone.CurrentState.Value == "on")
            {
                PMDG737Aircraft.ServiceInterPhoneOff();
            }
            else
            {
                PMDG737Aircraft.ServiceInterPhoneOn();
            }
        }
    }
}
