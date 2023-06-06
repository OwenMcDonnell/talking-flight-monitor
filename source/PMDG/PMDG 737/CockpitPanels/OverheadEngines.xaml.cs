using tfm.PMDG.PanelObjects;
using FSUIPC;
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
        public partial class OverheadEngines : UserControl
    {
        private SingleStateToggle apuSelector = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.APU_Selector).First() as SingleStateToggle;
        private SingleStateToggle engine1Starter = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ENG_StartSelector[0]).First() as SingleStateToggle;
        private SingleStateToggle engine2Starter = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ENG_StartSelector[1]).First() as SingleStateToggle;
        private SingleStateToggle ignitionSelector = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ENG_IgnitionSelector).First() as SingleStateToggle;
                      
        public OverheadEngines()
        {
            InitializeComponent();
                }

        private async  void UserControl_Loaded(object sender, RoutedEventArgs e)
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
                    engineStarter2ComboBox.SelectedIndex = engine2Starter.CurrentState.Key;
                    engineStarter1ComboBox.SelectedIndex = engine1Starter.CurrentState.Key;
                    ignitionComboBox.SelectedIndex = ignitionSelector.CurrentState.Key;
                    apuStarterComboBox.SelectedIndex = apuSelector.CurrentState.Key;
                    fuelFlow1ComboBox.SelectedIndex = ((int)FSUIPCConnection.ReadLVar("switch_688_73X"));
                    fuelFlow2ComboBox.SelectedIndex = ((int)FSUIPCConnection.ReadLVar("switch_689_73X"));
                });
            });
        }

        private void apuStarterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PMDG737Aircraft.APUSelector(apuStarterComboBox.SelectedIndex);
        }

        private void ignitionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PMDG737Aircraft.IgnitionSelector(ignitionComboBox.SelectedIndex);
        }

        private void engineStarter1ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PMDG737Aircraft.Engine1StartSelector(engineStarter1ComboBox.SelectedIndex);
        }

        private void fuelFlow1ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PMDG737Aircraft.Eng1FuelSelector(fuelFlow1ComboBox.SelectedIndex);
        }

        private void engineStarter2ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PMDG737Aircraft.Engine2StartSelector(engineStarter2ComboBox.SelectedIndex);
        }

        private void fuelFlow2ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PMDG737Aircraft.Eng2FuelSelector(fuelFlow2ComboBox.SelectedIndex);
        }
    }
}
