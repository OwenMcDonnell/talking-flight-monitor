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

namespace tfm.Properties.Data.AirportsDatabase
{
    /// <summary>
    /// Interaction logic for Simulator.xaml
    /// </summary>
    public partial class Simulator : Window
    {
        public Simulator()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = simulatorComboBox.SelectedItem as ComboBoxItem;
            
            if(selectedItem.Name == "p3dComboBoxItem")
            {
                App.RunMakeRunways("P3D");
            }
            else if(selectedItem.Name == "msfsComboBoxItem")
            {
                App.RunMakeRunways("MSFS");
            }
            Close();            
        }

        private void p3dBrowseButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog d = new();
            if(d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tfm.Properties.Settings.Default.P3DInstallPath = d.SelectedPath;
                tfm.Properties.Settings.Default.Save();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
