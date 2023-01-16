using DavyKager;
using FSUIPC;

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

        public static InstrumentPanel InstrumentPanel { get => new InstrumentPanel(); }
        public static TFMMainForm TFMMainForm { get; internal set; } 
                public static bool DebugEnabled { get; internal set; }

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

        public static void ApplicationShutdown()
        {
            TFMMainForm.Shutdown();
        }

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

        public static  TblHeader LoadAiracCycle()
        {
            // Get the navigraph database header. No checks against the array index because we already know
            // That there is only 1 header returned.
            var airacCycle = new navigraphContext().TblHeader.ToArray()[0];
            return airacCycle;
        } // End LoadAiracCycle method.

        public static async void LoadAirportsDatabase()
        {

            if (FSUIPCConnection.IsOpen)
            {
                AirportsDatabase database = FSUIPCConnection.AirportsDatabase;

                if(FSUIPCConnection.FSUIPCVersion.Major <= 6)
                {
                    database.MakeRunwaysFolder = Properties.Settings.Default.P3DAirportsDatabasePath;
                }
                else
                {
                    database.MakeRunwaysFolder = Properties.Settings.Default.MSFSAirportsDatabasePath;
                }

                if (database.DatabaseFilesExist)
                {
                    database.Load();
                    Tolk.Output("Airports database loaded.");
                }
                else
                {
                    Tolk.Output("Database failed to load. see the log for more details.");
                }
                                                                                                            } // open connection.
        } // LoadAirportsDatabase
    }
}
