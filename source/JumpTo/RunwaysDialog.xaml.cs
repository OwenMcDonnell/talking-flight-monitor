using FSUIPC;
using tfm.Properties;
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
using System.Windows.Threading;

namespace tfm.JumpTo
{
        public partial class RunwaysDialog : Window
    {

        private ObservableCollection<RunwayDataGridRow> runwayDataGridRows = new ObservableCollection<RunwayDataGridRow>();

        public RunwaysDialog()
        {
            InitializeComponent();

            airportIcaoTextBox.Focus();
        }

        private void airportIcaoTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

            if(e.Key == Key.Enter)
            {
                FsAirport airport = FSUIPCConnection.AirportsDatabase.Airports[airportIcaoTextBox.Text.ToUpper()];
                if (airport != null)
                {
                    airport.LoadComponents(AirportComponents.Runways);
                    runwaysDataGrid.ItemsSource = null;
                    runwayDataGridRows.Clear();

                    foreach (FsRunway runway in airport.Runways)
                    {

                        RunwayDataGridRow row = new RunwayDataGridRow()
                        {
                            ID = runway.ID.ToString(),
                            Heading = Math.Round(runway.HeadingMagnetic, 0),
                            Length = runway.LengthFeet,
                            Width = runway.WidthFeet,
                            InUse = runway.AIPlaneOnRunway != null || runway.IsPlayerOnRunway == true? "Yes" : "No",
                            CanTakeoff = runway.ClosedForTakeoff == true ? "No" : "Yes",
                            CanLand = runway.ClosedForLanding == true? "No" : "Yes",
                        };

                        runwayDataGridRows.Add(row);
                                            } // loop
                    runwaysDataGrid.ItemsSource = runwayDataGridRows;
                                        Tolk.Output($"{airport.Runways.Count()} runways loaded.");
                    Keyboard.Focus(runwaysDataGrid);
                } // airport not null
                else
                {
                    Tolk.Output("Airport not found.");
                }
                            }
        }

        private void runwaysDataGrid_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                var row = runwaysDataGrid.SelectedItem;
                                if(row is RunwayDataGridRow runwayData)
                {
                    var airport = FSUIPCConnection.AirportsDatabase.Airports[airportIcaoTextBox.Text.ToUpper()];
                    airport.LoadComponents(AirportComponents.Runways);
                    var runway = airport.Runways[runwayData.ID.ToString()];
                                        runway.MoveAircraftHere(false);
                    this.Close();                   
                }
            }
        }
    }
}
