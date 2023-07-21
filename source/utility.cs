using DavyKager;
using FSUIPC;

using NLog;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm
{
    public static class utility
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public static InstrumentPanel InstrumentPanel { get => new InstrumentPanel(); }
        // public static TFMMainForm TFMMainForm { get; internal set; } 
        public static FsWeather CurrentWeather { get; internal set; }
        public static DateTime WeatherLastUpdated { get; internal set; }
                                public static bool DebugEnabled { get; internal set; }
        public static bool flgMuteFlows { get; internal set; }

        public static void UpdateControl(bool toggleStateOn, CheckBox ctrl)
        {

            if (toggleStateOn)
            {
                if (ctrl.Checked != true)
                {
                    ctrl.Checked = true;
                }

            }
            else
            {
                if (ctrl.Checked != false)
                {
                    ctrl.Checked = false;
                }

            }
        }

        public static void UpdateControl(bool toggleStateOn, RadioButton ctrl)
        {

            if (toggleStateOn)
            {
                if (ctrl.Checked != true)
                {
                    ctrl.Checked = true;
                }

            }
            else
            {
                if (ctrl.Checked != false)
                {
                    ctrl.Checked = false;
                }

            }
        }

/*        public static void ApplicationShutdown()
        {
            TFMMainForm.Shutdown();
        }
*/
        public static double ReadHeadingOffset(double current, double target)
        {
            double left = current - target;
            double right = target - current;
            if (left < 0) left += 360;
            if (right < 0) right += 360;
            return left < right ? -left : right;
        }

        public static  double CalculateAngleHeight( double distanceFeet, double slopeAngle)
        {
            var radians = slopeAngle * (Math.PI / 180);
            var height = distanceFeet * Math.Tan(radians);
            return height;
        }

                public static async void LoadAirportsDatabase(string MakeRunwaysPath = null)
        {

            if (FSUIPCConnection.IsOpen)
            {
                AirportsDatabase database = FSUIPCConnection.AirportsDatabase;
                database.DatabaseFolder = App.Utilities.airportsDatabaseFolder;
                if (FSUIPCConnection.FSUIPCVersion.Major <= 6)
                {
                    if (MakeRunwaysPath != null)
                    {
                        database.MakeRunwaysFolder = MakeRunwaysPath;
                    }
                    else
                    {
                        database.MakeRunwaysFolder = Properties.Settings.Default.P3DAirportsDatabasePath;
                    }
                }
                else
                {
                    if (MakeRunwaysPath != null)
                    {
                        database.MakeRunwaysFolder = MakeRunwaysPath;
                    }
                    else
                    {
                        database.MakeRunwaysFolder = Properties.Settings.Default.MSFSAirportsDatabasePath;
                    }

                }

                if (database.DatabaseFilesExist)
                {
                    
                    database.Load();
                    Tolk.Output($"Airports database loaded. Total {database.Airports.Count} airports.");
                    logger.Info($"Airports database loaded. Total {database.Airports.Count} airports.");
                }
                else
                {
                    Tolk.Output("Database failed to load. see the log for more details.");
                    logger.Debug("Airports database failed to load.");
                }
                                                                                                            } // open connection.
        } // LoadAirportsDatabase


        public static string AddSpacesToMixedCaseStringAndLowercaseFirstChar(string mixedCaseString)
        {
            string result = "";
            bool isFirstCharOfWord = true;
            for (int i = 0; i < mixedCaseString.Length; i++)
            {
                char currentChar = mixedCaseString[i];
                if (currentChar == '_')
                {
                    result += " "; // replace underscore with a space
                    isFirstCharOfWord = true;
                }
                else if (i > 0 && char.IsUpper(currentChar))
                {
                    if (!isFirstCharOfWord)
                    {
                        result += " ";
                    }
                    result += char.ToLower(currentChar);
                    isFirstCharOfWord = false;
                }
                else
                {
                    result += isFirstCharOfWord ? char.ToUpper(currentChar) : currentChar;
                    isFirstCharOfWord = false;
                }
            }
            return result;
        }

    }
}
