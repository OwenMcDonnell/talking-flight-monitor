using DavyKager;
using FSUIPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.JumpTo
{
    public partial class RunwaysForm : Form
    {
        public RunwaysForm()
        {
            InitializeComponent();
        }

        private void RunwaysForm_Load(object sender, EventArgs e)
        {
            Tolk.Load();
            if (FSUIPCConnection.IsOpen)
            {
                FSUIPCConnection.AirportsDatabase.SetReferenceLocation();
            } // connection
            else
            {
                MessageBox.Show("Not connected to FSUIPC. This window will now close.");
                this.Close();
            }

        }

        private void airportTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                FsAirport airport = FSUIPCConnection.AirportsDatabase.Airports[airportTextBox.Text.ToUpper()];
                if(airport != null)
                {
                    runwaysListView.Items.Clear();

                    foreach(FsRunway runway in airport.Runways)
                    {
                        var item = new ListViewItem(runway.ID.ToString());
                        item.SubItems.Add(runway.IsPlayerOnRunway == true || runway.AIPlaneOnRunway != null ? "Yes" : "No");
                        item.SubItems.Add(runway.HeadingTrue.ToString());
                        item.SubItems.Add(runway.LengthFeet.ToString());
                        item.SubItems.Add(runway.WidthFeet.ToString());
                        item.SubItems.Add(runway.ClosedForTakeoff == true ? "No" : "Yes");
                        item.SubItems.Add(runway.ClosedForLanding == true ? "No" : "Yes");
                        item.Tag = runway;
                        runwaysListView.Items.Add(item);
                    } // loop
                    Tolk.Output($"{airport.Runways.Count()} runways loaded.");
                } // airport not null
                else
                {
                    Tolk.Output("Airport not found.");
                }
                e.SuppressKeyPress = true;
            } // key ENTER
        }

        private void runwaysListView_ItemActivate(object sender, EventArgs e)
        {
            FsRunway runway = (FsRunway)runwaysListView.SelectedItems[0].Tag;
            runway.MoveAircraftHere(false);
            this.Close();
        }
    }
}
