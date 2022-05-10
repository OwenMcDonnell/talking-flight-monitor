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
    }
}
