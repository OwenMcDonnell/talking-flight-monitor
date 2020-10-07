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
using System.Diagnostics;
namespace tfm
{
    public partial class TemplateForm : Form
    {
        public IOSubsystem inst = new IOSubsystem();
        public TemplateForm()
        {
            InitializeComponent();
            configureForm();
            // Start the connection timer to look for a flight sim
            this.timerConnection.Start();
        }

        // This method is called every 1 second by the connection timer.
        private void timerConnection_Tick(object sender, EventArgs e)
        {
            // Try to open the connection
            try
            {
                FSUIPCConnection.Open();
                // If there was no problem, stop this timer and start the main timer
                this.timerConnection.Stop();
                this.timerMain.Start();
                // Update the connection status
                configureForm();
                
            }
            catch
            {
                // No connection found. Don't need to do anything, just keep trying
            }
        }

        // This method runs 10 times per second (every 100ms). This is set on the timerMain properties.
        private void timerMain_Tick(object sender, EventArgs e)
        {
            // Call process() to read/write data to/from FSUIPC
            // We do this in a Try/Catch block incase something goes wrong
            try
            {
                FSUIPCConnection.Process();
                inst.ReadAircraftState();
                // Update the information on the form
                // (See the Examples Application for more information on using Offsets).

                // 1. Airspeed
                double airspeedKnots = (double)Aircraft.AirspeedTrue.Value / 128d;
                this.txtAirspeed.Text = airspeedKnots.ToString("F0");

                // 2. Master Avionics
                this.chkAvionicsMaster.Checked = Aircraft.AvionicsMaster.Value > 0;
            }
            catch (Exception ex)
            {
                // An error occured. Tell the user and stop this timer.
                this.timerMain.Stop();
                MessageBox.Show("Communication with FSUIPC Failed\n\n" + ex.Message, "FSUIPC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // Update the connection status
                configureForm();
                // start the connection timer
                this.timerConnection.Start();
            }
        }

        // This runs when the master avionics tick has been changed
        private void chkAvionicsMaster_CheckedChanged(object sender, EventArgs e)
        {
            // Update the FSUIPC offset with the new value (1 = Checked/On, 0 = Unchecked/Off)
            Aircraft.AvionicsMaster.Value = (uint)(this.chkAvionicsMaster.Checked ? 1 : 0);
        }

        // Configures the status label depending on if we're connected or not 
        private void configureForm()
        {
            if (FSUIPCConnection.IsOpen)
            {
                this.lblConnectionStatus.Text = "Connected to " + FSUIPCConnection.FlightSimVersionConnected.ToString();
                this.lblConnectionStatus.ForeColor = Color.Green;
            }
            else
            {
                this.lblConnectionStatus.Text = "Disconnected. Looking for Flight Simulator...";
                this.lblConnectionStatus.ForeColor = Color.Red;
            }
        }

        // Form is closing so stop all the timers and close FSUIPC Connection
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timerConnection.Stop();
            this.timerMain.Stop();
            FSUIPCConnection.Close();
        }
    }
}
