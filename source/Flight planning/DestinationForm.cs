using FSUIPC;
using DavyKager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm
{
    public partial class DestinationForm : Form
    {
        FsAirport airport = new FsAirport();
                public DestinationForm()
        {
            InitializeComponent();
        }

        private void DestinationForm_Load(object sender, EventArgs e)
        {
            Tolk.Load();
            if(FlightPlan.Destination != null && FlightPlan.DestinationRunway != null)
            {
                airportTextBox.Text = FlightPlan.Destination.ICAO;
                foreach(FsRunway runway in FlightPlan.Destination.Runways)
                {
                    runwayComboBox.Items.Add(runway.ID.ToString());
                }
                runwayComboBox.SelectedItem = FlightPlan.DestinationRunway.ID.ToString();
            }
        }

                private void airportTextBox_KeyDown(object sender, KeyEventArgs e)
        {
                        if(e.KeyCode == Keys.Enter)
            {
                var database = FSUIPCConnection.AirportsDatabase;
                database.SetReferenceLocation();

                try
                {
                                                    FlightPlan.Destination = database.Airports.Where(x => x.ICAO == airportTextBox.Text).ToArray()[0];
                    runwayComboBox.Items.Clear();
                                                    foreach(FsRunway runway in FlightPlan.Destination.Runways)
                    {
                        runwayComboBox.Items.Add(runway.ID.ToString());
                                                                                            }
                    runwayComboBox.SelectedIndex = 0;
                    // Stop speech from announcing the selected runway as they load.
                    Tolk.Silence();
                    Tolk.Output($"{FlightPlan.Destination.Runways.Count()} runways loaded.");
                }
                catch(IndexOutOfRangeException ex)
                {
                    Tolk.Output("Airport not in database.");
                    airportTextBox.Text = String.Empty;
                }
                e.SuppressKeyPress = true;
            }
                    }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                FlightPlan.DestinationRunway = FlightPlan.Destination.Runways.Where(x => x.ID.ToString() == (string)runwayComboBox.SelectedItem).ToArray()[0];
                this.Close();
            }
            catch(IndexOutOfRangeException ex)
            {
                Tolk.Output("You must choose a runway before continuing.");
            }
                                }

        private void runwayComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tolk.DetectScreenReader() == "NVDA")
            {
                Tolk.Output(runwayComboBox.SelectedItem.ToString());
            }
            var runway = FlightPlan.Destination.Runways.Where(x => x.ID.ToString() == (string)runwayComboBox.SelectedItem).ToArray()[0];
            StringBuilder ilsInfo = new StringBuilder();
            ilsInfo.AppendLine($"Identifier: {runway.ILSInfo.ID}");
            ilsInfo.AppendLine($"Name: {runway.ILSInfo.Name}");
            ilsInfo.AppendLine($"Frequency: {runway.ILSInfo.Frequency}");
                        ilsInfo.AppendLine($"Course: {runway.ILSInfo.Heading}");
            ilsInfo.AppendLine($"Slope: {runway.ILSInfo.Slope}°");
            try
            {
                ilsInfo.AppendLine($"Distance feet: {FlightPlan.DestinationRunway.DistanceFeet}");
                ilsInfo.AppendLine($"Distance NM: {FlightPlan.DestinationRunway.DistanceNauticalMiles}");
            }
            catch(NullReferenceException)
            {
                ilsInfo.AppendLine($"Distance: Not available");
                            }
                        ilsDetailsTextBox.Text = ilsInfo.ToString();
                }

        }
    }
