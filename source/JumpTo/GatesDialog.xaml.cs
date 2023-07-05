using tfm.Properties;
using FSUIPC;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DavyKager;
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

namespace tfm.JumpTo
{
        public partial class GatesDialog : Window
    {

        
        private ObservableCollection<GatesDataGridRow> gatesData = new ObservableCollection<GatesDataGridRow>();

        public GatesDialog()
        {
            InitializeComponent();
                        airportIcaoTextBox.Focus();
        }

                private void airportIcaoTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                                FsAirport airport = FSUIPCConnection.AirportsDatabase.Airports[airportIcaoTextBox.Text.ToUpper()];

                if(airport != null)
                {
                    airport.LoadComponents(AirportComponents.Gates);
                    GatesListView.ItemsSource = null;
                    gatesData.Clear();
                    foreach(FsGate gate in airport.Gates)
                    {
                        GatesDataGridRow row = new GatesDataGridRow()
                        {
                            ID = gate.ID.ToString(),
Type = App.Utilities.GetGateType(gate),
                                                        RadiusFeet = Math.Round(gate.RadiusFeet, 2),
                            InUse = gate.IsAIPlaneAtGate == true || gate.IsPlayerAtGate == true? "yes" : "No",
                        };
                        gatesData.Add(row);
                    }

                    GatesListView.ItemsSource = gatesData;
                    Tolk.Output($"{gatesData.Count} gates loaded.");
                }
                else
                {
                    Tolk.Output("Airport not found");
                }
            }
        }

        private void GatesListView_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

            if(e.Key == Key.Enter)
            {
                var row = GatesListView.SelectedItem;

                if(row is GatesDataGridRow gateData)
                {

                    var airport = FSUIPCConnection.AirportsDatabase.Airports[airportIcaoTextBox.Text.ToUpper()];
                    airport.LoadComponents(AirportComponents.Gates);
                    var gate = airport.Gates[gateData.ID.ToString()];
                    gate.MoveAircraftHere(false);
                }
                this.Close();
            }
        }

        private void allRampsMenuItem_Click(object sender, RoutedEventArgs e)
        {
                        var filteredData = gatesData.Where(x => x.Type.Contains("Ramp"));
            GatesListView.ItemsSource = filteredData;
            Tolk.Output($"{filteredData.Count()} gates loaded.");

        }

        private void allGAMenuItem_Click(object sender, RoutedEventArgs e)
        {
                        var filteredData = gatesData.Where(x => x.Type.Contains("Ramp") && x.Type.Contains("GA"));
            GatesListView.ItemsSource = filteredData;
            Tolk.Output($"{filteredData.Count()} gates loaded.");

        }

        private void gaSmallMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var filteredData = gatesData.Where(x => x.Type.Contains("Ramp") && x.Type.Contains("GA") && x.Type.Contains("small"));
            GatesListView.ItemsSource = filteredData;
            Tolk.Output($"{filteredData.Count()} gates loaded.");

        }

        private void gaMediumMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var filteredData = gatesData.Where(x => x.Type.Contains("Ramp") && x.Type.Contains("GA") && x.Type.Contains("medium"));
            GatesListView.ItemsSource = filteredData;
            Tolk.Output($"{filteredData.Count()} gates loaded.");
        }

        private void gaLargeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var filteredData = gatesData.Where(x => x.Type.Contains("Ramp") && x.Type.Contains("GA") && x.Type.Contains("large"));
            GatesListView.ItemsSource = filteredData;
            Tolk.Output($"{filteredData.Count()} gates loaded.");
                    }

        private void cargoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var filteredData = gatesData.Where(x => x.Type.Contains("Ramp") && x.Type.Contains("cargo") && !x.Type.Contains("military"));
            GatesListView.ItemsSource = filteredData;
            Tolk.Output($"{filteredData.Count()} gates loaded.");
                    }

        private void allGatesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var filteredData = gatesData.Where(x => x.Type.Contains("Gate"));
            GatesListView.ItemsSource = filteredData;
            Tolk.Output($"{filteredData.Count()} gates loaded.");
                    }

        private void smallGatesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var filteredData = gatesData.Where(x => x.Type.Contains("Gate") && x.Type.Contains("small"));
            GatesListView.ItemsSource = filteredData;
            Tolk.Output($"{filteredData.Count()} gates loaded.");
                    }

        private void mediumGatesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var filteredData = gatesData.Where(x => x.Type.Contains("Gate") && x.Type.Contains("medium"));
            GatesListView.ItemsSource = filteredData;
            Tolk.Output($"{filteredData.Count()} gates loaded.");
                    }

        private void heavyGatesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var filteredData = gatesData.Where(x => x.Type.Contains("Gate") && x.Type.Contains("heavy"));
            GatesListView.ItemsSource = filteredData;
            Tolk.Output($"{filteredData.Count()} gates loaded.");
                    }
                   }
}
