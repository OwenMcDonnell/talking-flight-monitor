using System.Net.Http;
using Newtonsoft.Json;
using tfm.Vatsim;
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

namespace tfm.Vatsim
{
    public partial class VatsimRadar : Form
    {

                public VatsimRadar()
        {
            InitializeComponent();
        
        }   

        private async void VatsimRadar_Load(object sender, EventArgs e)
        {

            // Load the pilots.
await VatsimUtilities.GetPilotsAsync().ContinueWith(x =>
{
                                                                                   if(x.Status == TaskStatus.Faulted)
                {
                    MessageBox.Show(x.Result.Count.ToString());
                }
                else
                {
                                                            usersListView.BeginUpdate();
                    foreach (Pilot user in x.Result)
                    {
                        string[] item = { user.Callsign, user.DistanceFrom.ToString(), user.Altitude.ToString(), user.Heading.ToString(), user.BearingTo.ToString(), user.Groundspeed.ToString(), user.RatingShortName };
                        usersListView.Items.Add(new ListViewItem(item));
                    }
                    usersListView.EndUpdate();
                                    }
            }); // loading the pilots.

            // Load controllers.
            VatsimUtilities.GetControllersAsync().ContinueWith(x =>
            {

                if(x.Status == TaskStatus.Faulted)
                {
                    MessageBox.Show("Failed to get list of controllers.");
                }
                else
                {

                    controllersListView.BeginUpdate();
                    foreach(Ati user in x.Result)
                    {
                        string[] cells = { user.Callsign, user.FacilityShortName, user.Frequency, user.VisualRange.ToString(), user.RatingShortName };

                        ListViewItem row = new ListViewItem(cells[0]);
                        row.SubItems.Add(cells[1]);
                        row.SubItems.Add(cells[2]);
                        row.SubItems.Add(cells[3]);
                        row.SubItems.Add(cells[4]);
                        controllersListView.Items.Add(row);
                                            }
                    controllersListView.EndUpdate();
                }
            });
        } // load
                        private async  void distanceNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

            usersListView.Items.Clear();

            var pilots = await VatsimUtilities.GetPilotsAsync();
            var usersWithinRange = pilots.Where(x => x.DistanceFrom <= (double)distanceNumericUpDown.Value).ToArray();
                        foreach (Pilot user in usersWithinRange)
            {
                string[] item = { user.Callsign, user.DistanceFrom.ToString(), user.Altitude.ToString(), user.Heading.ToString(), user.BearingTo.ToString(), user.Groundspeed.ToString(), user.RatingShortName };
                usersListView.Items.Add(new ListViewItem(item));
            }
                    }

        private void VatsimRadar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Alt && e.KeyCode == Keys.L)
            {
                e.SuppressKeyPress = true;
                                                usersListView.Focus();
                                                            }
        }

        private void controllersListView_ItemActivate(object sender, EventArgs e)
        {
            var lv = (ListView)sender;
            var ap = new InstrumentPanel();

            ap.Com1Freq = decimal.Parse(lv.SelectedItems[0].SubItems[2].Text);
                                            }

        private void usersListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
       }

        private void usersListView_KeyDown(object sender, KeyEventArgs e)
        {

            // Sort columns based on key presses...
            if((e.Control && e.KeyCode == Keys.D1))
            {
                ColumnClickEventArgs eventArgs = new ColumnClickEventArgs(0);
                usersListView_ColumnClick(usersListView, eventArgs);
            }

            if((e.Control && e.KeyCode == Keys.D2))
            {
                ColumnClickEventArgs eventArgs = new ColumnClickEventArgs(1);
                usersListView_ColumnClick(usersListView, eventArgs);
                            }
        } // usersListView_ColumnClick
    } // form
} // namespace
