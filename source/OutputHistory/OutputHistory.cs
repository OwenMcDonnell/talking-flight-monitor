using DavyKager;
using System;
using System.Collections.Generic;
using System.Linq;
// using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace tfm
{
    class OutputHistory
    {
        static List<string> History = new List<string>();

        public void AddItem(string item)
        {
            if (Properties.Settings.Default.UseDatabase)
            {
                TFMDatabase.InsertSpeechHistoryItem(item);
            }
            else
            {
            int maxHistory = (int)Properties.Settings.Default.OutputHistoryLength;
            if (History.Count >= maxHistory)
            {
                int removeItems = History.Count - maxHistory + 1;
                History.RemoveRange(0, removeItems);
                History.Add(item);

            }
            else
            {
                History.Add(item);
            }
        }

        }
        public List<string> GetItems()
        {
            if (Properties.Settings.Default.UseDatabase)
            {
                return TFMDatabase.GetAllSpeechHistoryItems();
            }
            else
            {
                return History;
            }
        }
        public void Clear()
        {
            if (Properties.Settings.Default.UseDatabase)
            {
                var result = TFMDatabase.DeleteAllSpeechHistoryItems();
                Tolk.Output($"{result} items deleted.");
            }
            else
            {
                var result = History.Count();
                History.Clear();
                Tolk.Output($"{result} items deleted.");
            }
            
        }
    }
}
