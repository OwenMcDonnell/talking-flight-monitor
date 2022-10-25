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
    public partial class GatesForm : Form
    {
        public GatesForm()
        {
            InitializeComponent();
        }

        private void GatesForm_Load(object sender, EventArgs e)
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
                if (airport != null)
                {
                    gatesListView.Items.Clear();
                    foreach (FsGate gate in airport.Gates)
                    {
                        var item = new ListViewItem(gate.ID);
                        item.SubItems.Add(gate.Name);
                        item.SubItems.Add(gate.Number);
                        item.SubItems.Add(gate.Type.ToString());
                        item.SubItems.Add(gate.IsAIPlaneAtGate == true || gate.IsPlayerAtGate == true ? "Yes" : "No");
                        item.Tag = gate;
                        gatesListView.Items.Add(item);
                    } // loop.
                    Tolk.Output($"{airport.Gates.Count()} loaded.");
                    e.SuppressKeyPress = true;
                } // airport not null
                else
                {
                    Tolk.Output("Airport not found.");
                }
            } // key enter
        }

        private void gatesListView_ItemActivate(object sender, EventArgs e)
        {
            FsGate gate = (FsGate)gatesListView.SelectedItems[0].Tag;
            gate.MoveAircraftHere(false);
        }
    }
}
