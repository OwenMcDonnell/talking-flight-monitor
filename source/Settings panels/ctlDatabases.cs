﻿using FSUIPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm
{
    public partial class ctlDatabases : UserControl, iSettingsPage
    {
        public ctlDatabases()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void p3dBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                p3dPathTextBox.Text = fbd.SelectedPath;
                Properties.Settings.Default.P3DAirportsDatabasePath = fbd.SelectedPath;
            }
                } // p3dBrowse_click.

        private void ctlDatabases_Load(object sender, EventArgs e)
        {

            // P3D
            if(Properties.Settings.Default.P3DAirportsDatabasePath == String.Empty || string.IsNullOrWhiteSpace(Properties.Settings.Default.P3DAirportsDatabasePath))
            {
                p3dPathTextBox.Text = "(none selected)";
            }
            else
            {
                p3dPathTextBox.Text = Properties.Settings.Default.P3DAirportsDatabasePath;
            }

            // MSFS folder.
            if (Properties.Settings.Default.MSFSAirportsDatabasePath == String.Empty || string.IsNullOrWhiteSpace(Properties.Settings.Default.MSFSAirportsDatabasePath))
            {
                msfsTextBox.Text = "(none selected)";
            }
            else
            {
                msfsTextBox.Text = Properties.Settings.Default.MSFSAirportsDatabasePath;
            }

        }

        private void msfsBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                msfsTextBox.Text = fbd.SelectedPath;
                Properties.Settings.Default.MSFSAirportsDatabasePath = fbd.SelectedPath;
            }

        }

        private async  void rebuildAirportsDatabaseButton_Click(object sender, EventArgs e)
        {
            await FSUIPCConnection.AirportsDatabase.RebuildDatabaseAsync();

            MessageBox.Show($"Done loading from {FSUIPCConnection.AirportsDatabase.MakeRunwaysFolder}");
        }
    }
}
