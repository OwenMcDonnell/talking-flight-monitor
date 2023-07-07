using FSUIPC;
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

namespace tfm.Flight_planning
{
    public partial class DestinationRunwayWindow : Window
    {

        FsAirport airport;

        public DestinationRunwayWindow()
        {
            InitializeComponent();

            airportTextBox.Focus();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Tolk.Load();

            // Load the destination into the window.
            if(FlightPlan.Destination != null && FlightPlan.DestinationRunway != null)
            {
                airportTextBox.Text = FlightPlan.Destination.ICAO;


                // Load the runways.
                var runways = FlightPlan.Destination.Runways.Where(x => x.ILSInfo != null);

                foreach(FsRunway runway in runways)
                {
                    ComboBoxItem item = new()
                    {
                        Content = runway.ILSInfo.Slope == 0 ? $"LOC {runway.ID}" : $"ILS {runway.ID}",
                        Tag = runway,
                    };
                    runwayComboBox.Items.Add(item);
                }

                // Set the selected runway.
                var selectedItem = runwayComboBox.Items.Cast<ComboBoxItem>()
        .FirstOrDefault(item =>
        {
            FsRunway runway = item.Tag as FsRunway;
            return runway != null && runway.ID.ToString() == FlightPlan.DestinationRunway.ID.ToString();
        });

                if (selectedItem != null)
                {
                    runwayComboBox.SelectedItem = selectedItem;
                }
            }
        }

        private void airportTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                var database = FSUIPCConnection.AirportsDatabase;
                airport = database.Airports[airportTextBox.Text.ToUpper()];
                airport.LoadComponents(AirportComponents.Runways);

                try
                {
                    FlightPlan.Destination = airport;

                    var runways = FlightPlan.Destination.Runways.Where(x => x.ILSInfo != null).ToList();
                    runwayComboBox.Items.Clear();
                    
                    // Load the runways.
                                        foreach (FsRunway runway in runways)
                    {
                        ComboBoxItem item = new()
                        {
                            Content = runway.ILSInfo.Slope == 0 ? $"LOC {runway.ID}" : $"ILS {runway.ID}",
                            Tag = runway,
                        };
                        runwayComboBox.Items.Add(item);
                    }
                                                                                                                                          
                    runwayComboBox.SelectedIndex = 0;
                    Tolk.Output($"{runwayComboBox.Items.Count} runways loaded.");
                }
                catch(IndexOutOfRangeException ex)
                {
                    Tolk.Output("Airport or runways not found.");
                    airportTextBox.Text = string.Empty;
                }
                
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
                        try
            {
                var selectedComboBoxItem = runwayComboBox.SelectedItem as ComboBoxItem;
                var selectedRunway = selectedComboBoxItem.Tag as FsRunway;

                FlightPlan.DestinationRunway = FlightPlan.Destination.Runways[selectedRunway.ID.ToString()];
                if (tfm.Properties.Settings.Default.SaveDestination)
                {
                    tfm.Properties.Settings.Default.DestinationAirport = airportTextBox.Text.ToUpper();
                    tfm.Properties.Settings.Default.DestinationRunway = selectedRunway.ID.ToString();
                    tfm.Properties.Settings.Default.Save();
                }
                
                this.Close();
            }
            catch(IndexOutOfRangeException ex)
            {
                Tolk.Output("Choose a runway first!");
            }
        }

        private void runwayComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            // Get the current runway from the destination airport in the flight plan.
            if (runwayComboBox.SelectedItem != null)
            {

                var selectedComboBoxItem = runwayComboBox.SelectedItem as ComboBoxItem;
                var selectedRunway = selectedComboBoxItem.Tag as FsRunway;

                // Populate the ILS details textbox with the selected runway information.
                StringBuilder ilsDetails = new StringBuilder();
                ilsDetails.AppendLine($"Name: {selectedRunway.ILSInfo.Name}");
                ilsDetails.AppendLine($"Identifier: {selectedRunway.ILSInfo.ID}");
                ilsDetails.AppendLine($"Frequency: {selectedRunway.ILSInfo.Frequency}");
                ilsDetails.AppendLine($"Course: {selectedRunway.ILSInfo.Heading}");
                ilsDetails.AppendLine($"GS angle: {selectedRunway.ILSInfo.Slope}");
                ilsDetails.AppendLine($"Landing pattern: {selectedRunway.PatternInfo.DirectionLanding}/{selectedRunway.PatternInfo.AltitudeFeet}");
                runwayDetailsTextBox.Text = ilsDetails.ToString();
            }
                    }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }   
    }
    