using System.IO;
using FSUIPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
//using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;
namespace tfm.Settings_panels
{
    /// <summary>
    /// Interaction logic for usrGeneral.xaml
    /// </summary>
    public partial class ctlAirportsDatabase : UserControl
    {
        private bool P3DLoaded;
        private bool MSFSLoaded;
        string databasePath;
        public ctlAirportsDatabase()
        {
            InitializeComponent();
        }

        private void btnBrowseP3D_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = txtP3D.Text;
            
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtP3D.Text = dlg.SelectedPath;
            }

        }

        private void btnBrowseMSFS_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
          txtMSFS.Text = dlg.SelectedPath;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtMSFS.Text = dlg.SelectedPath;
            }

        }

        private async void btnRebuild_Click(object sender, RoutedEventArgs e)
        {
            string strMakeRunwaysPath = string.Empty;
            if (FSUIPCConnection.AirportsDatabase.IsLoaded)
            {
                FSUIPCConnection.AirportsDatabase.Clear();
            }
            try
            {
                if (App.IsP3DLoaded)
                {
                    strMakeRunwaysPath = txtP3D.Text;
                                   }
                else if (App.isMSFSLoaded)
                {
                    strMakeRunwaysPath = txtMSFS.Text;
                                   }
                FSUIPCConnection.AirportsDatabase.MakeRunwaysFolder = strMakeRunwaysPath;
                FSUIPCConnection.AirportsDatabase.DatabaseFolder = App.AirportsDatabaseFolder;
                if (FSUIPCConnection.AirportsDatabase.MakeRunwaysFilesExist)
                {
                    await FSUIPCConnection.AirportsDatabase.RebuildDatabaseAsync();
                                        App.LoadAirportsDatabase();
                    System.Windows.MessageBox.Show($"Loaded airports database from {FSUIPCConnection.AirportsDatabase.DatabaseFolder}");
                }
                else 
                {
                    System.Windows.MessageBox.Show("Incorrect MakeRunways folder. Check that files exist in the specified folder.");
                }


            }
            catch (Exception x)
            {
                System.Windows.MessageBox.Show("An error occured. Check that the MakeRunways files are in the specified folder.");
                            }
            



        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
                if (FSUIPCConnection.IsOpen)
                {

                    if (FSUIPCConnection.FSUIPCVersion.Major <= 6)
                    {
                        P3DLoaded = true;
                        btnRebuild.Content = "B_uild P3D database";
                        
                        btnRebuild.IsEnabled = true;
                    }
                    else if (FSUIPCConnection.FSUIPCVersion.Major >= 7)
                    {
                        MSFSLoaded = true;
                        btnRebuild.Content = "B_uild MSFS Database";
                        
                        btnRebuild.IsEnabled = true;
                    }
                }
                else
                {
                    btnRebuild.Content = "Sim not found";
                    
                    btnRebuild.IsEnabled = false;
                }
                // P3D
                if (Properties.Settings.Default.P3DAirportsDatabasePath == String.Empty || string.IsNullOrWhiteSpace(Properties.Settings.Default.P3DAirportsDatabasePath))
                {
                    txtP3D.Text = "(none selected)";
                }
                else
                {
                    txtP3D.Text = Properties.Settings.Default.P3DAirportsDatabasePath;
                }

                // MSFS folder.
                if (Properties.Settings.Default.MSFSAirportsDatabasePath == String.Empty || string.IsNullOrWhiteSpace(Properties.Settings.Default.MSFSAirportsDatabasePath))
                {
                    txtMSFS.Text = "(none selected)";
                }
                else
                {
                    txtMSFS.Text = Properties.Settings.Default.MSFSAirportsDatabasePath;
                }

            }
        }
    }

