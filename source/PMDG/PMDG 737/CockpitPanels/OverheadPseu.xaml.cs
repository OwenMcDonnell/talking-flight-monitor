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
using System.Windows.Threading;
using UserControl = System.Windows.Controls.UserControl;


namespace tfm.PMDG.PMDG_737.CockpitPanels
{
        public partial class OverheadPseu : UserControl
    {

        private SingleStateToggle pseuLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.WARN_annunPSEU).First() as SingleStateToggle;

        public OverheadPseu()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
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
                    App.UI.BuildIndicatorTextBox(pseuTextBox, pseuLight, "PSEU indicator");
                });
            });
        }


    }
}
