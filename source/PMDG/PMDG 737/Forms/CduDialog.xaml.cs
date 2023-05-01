using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace tfm.PMDG.PMDG_737.Forms
{
        public partial class CduDialog : Window
    {

        private System.Timers.Timer cduTimer = new System.Timers.Timer();

        public CduDialog()
        {
            InitializeComponent();

            RefreshCDU();
        }

        private void RefreshCDU()
        {

            cduDisplay.Clear();

            Thread.Sleep(500);
            string displayText = PMDG737Aircraft.RefreshCDU(0);

            // Set the title of the window if the CDU is powered.
            if (PMDG737Aircraft.cdu0.Powered)
            {
                this.Title = PMDG737Aircraft.cdu0.Rows[0].ToString().Trim();
                cduDisplay.Text = displayText;
            }
            else
            {
                this.Title = "CDU not powered";
                cduDisplay.Text = "The CDU is powered off.";
            }


        }

    }
}
