using tfm.Vatsim.Feed;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm.Vatsim
{
    static class VatsimUtilities
    {

                               public static async Task<List<Pilot>> GetPilotsAsync()
        {

            List<Pilot> pilots = new List<Pilot>();
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://data.vatsim.net/v3/vatsim-data.json");
var            vatsimData = tfm.Vatsim.Feed.VatsimDataBlock.FromJson(response);

            foreach(Pilot user in vatsimData.Pilots)
            {
                user.RatingShortName = vatsimData.PilotRatings.Where(x => user.PilotRating == x.Id).ToArray()[0].ShortName;
                pilots.Add(user);
            }

            return pilots;
        } // GetPilots


    } // VatsimUtilities
} // Vatsim
