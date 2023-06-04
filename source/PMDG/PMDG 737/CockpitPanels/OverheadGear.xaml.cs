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
        public partial class OverheadGear : UserControl
    {

        private SingleStateToggle noseGearLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.GEAR_annunOvhdNOSE).First() as SingleStateToggle;
        private SingleStateToggle leftGearLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.GEAR_annunOvhdLEFT).First() as SingleStateToggle;
        private SingleStateToggle rightGearLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.GEAR_annunOvhdRIGHT).First() as SingleStateToggle;
        
        public OverheadGear()
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
                    App.UI.BuildIndicatorTextBox(noseGearTextBox, noseGearLight, "Nose gear indicator");
                    App.UI.BuildIndicatorTextBox(leftGearTextBox, leftGearLight, "Left gear indicator");
                    App.UI.BuildIndicatorTextBox(rightGearTextBox, rightGearLight, "Right gear indicator");
                });
            });
        }

    }
}
