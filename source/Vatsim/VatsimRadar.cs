using System.Net.Http;
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
                        var pilots = await GetPilots();
                        usersListView.BeginUpdate();
            foreach (Pilot user in pilots)
            {
                                string[] item = { user.Callsign, user.DistanceFrom.ToString(), user.Altitude.ToString(), user.Heading.ToString(), user.BearingTo.ToString(), user.Groundspeed.ToString(), user.PilotRating.ToString() };
                usersListView.Items.Add(new ListViewItem(item));
            }
            usersListView.EndUpdate();
        } // load

        private async Task<Pilot[]> GetPilots()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://data.vatsim.net/v3/vatsim-data.json");
            var block =tfm.Vatsim.Feed.VatsimDataBlock.FromJson(response);
            return block.Pilots.ToArray();
        } // GetPilots
    } // form
} // namespace
