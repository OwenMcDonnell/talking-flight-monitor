using System;
using System.Collections.Generic;
using System.Linq;
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

namespace tfm
{
    /// <summary>
    /// Interaction logic for firstRunHelp.xaml
    /// </summary>
    public partial class firstRunHelp : Window
    {
        public firstRunHelp()
        {
            InitializeComponent();
txtFirstRun.Text= @"Welcome to Talking Flight Monitor (TFM)!
TFM is controlled entirely through keyboard commands. All commands start with either the left or right Square Bracket keys.
Left Square Bracket: autopilot commands
Right square bracket: aircraft information
Right Bracket, then Question Mark: Turns on help mode, pressing any command will read it's function.
Right Bracket, then Ctrl+K: keyboard manager";

            this.BringIntoView();
            txtFirstRun.Focus();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
