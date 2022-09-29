﻿using System.Net.Http;
using Newtonsoft.Json;
using tfm.Vatsim.Feed;
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
            VatsimUtilities.GetPilotsAsync().ContinueWith(x =>
            {
                if(x.Status == TaskStatus.Faulted)
                {
                    MessageBox.Show("failed");
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
                        string[] item = { user.Callsign, user.FacilityShortName, user.Frequency, user.VisualRange.ToString(), user.RatingShortName };
                        controllersListView.Items.Add(new ListViewItem(item));
                                            }
                    controllersListView.EndUpdate();
                }
            });
        } // load

        private async Task<Pilot[]> GetPilots()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://data.vatsim.net/v3/vatsim-data.json");
            var block =tfm.Vatsim.Feed.VatsimDataBlock.FromJson(response);
            return block.Pilots.ToArray();
        } // GetPilots

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
    } // form
} // namespace