using tfm.Vatsim;
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
            var vatsimData = await GetVatsimDataAsync();
                        foreach(Pilot user in vatsimData.Pilots)
            {
                               user.RatingShortName = vatsimData.PilotRatings.Where(x => user.PilotRating == x.Id).ToArray()[0].ShortName;
                pilots.Add(user);
            }

            return pilots;
        } // GetPilots

        public static  async Task<List<Ati>> GetControllersAsync()
        {
                        List<Ati> controllers = new List<Ati>();
            var vatsimData = await GetVatsimDataAsync();

            foreach(Ati user in vatsimData.Controllers)
            {
                user.FacilityShortName = vatsimData.Facilities.Where(x => user.Facility == x.Id).ToArray()[0].Short;
                user.RatingShortName = vatsimData.Ratings.Where(x => user.Rating == x.Id).ToArray()[0].Short;
                controllers.Add(user);
            }
            return controllers;
                    } // GetControllersAsync

private static  async Task<VatsimDataBlock> GetVatsimDataAsync()
        {
            HttpClient client = new HttpClient();
            var response = client.GetStringAsync("https://data.vatsim.net/v3/vatsim-data.json");

            VatsimDataBlock vatsimData = null;
                                if(response.Status == TaskStatus.Faulted)
                {
                    System.Windows.Forms.MessageBox.Show("hi");
                return vatsimData;
            }
                else
                {
                  var dataBlock = tfm.Vatsim.VatsimDataBlock.FromJson(response.Result);
                    return dataBlock;                                        
                }

        } // GetVatsimData
    } // VatsimUtilities
} // Vatsim
