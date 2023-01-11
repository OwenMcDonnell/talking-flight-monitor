using tfm.PMDG.PanelObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.PMDG.PMDG_747.McpComponents
{
    public partial class VerticalSpeedBox : Form
    {

        private System.Timers.Timer vsTimer = new System.Timers.Timer();

        public VerticalSpeedBox()
        {
            InitializeComponent();
        }

        public void VsTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach(PanelObject control in PMDG747Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg747.MCP_VertSpeedBlank)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        if(toggle.CurrentState.Value == "on")
                        {
                            vsTextBox.ReadOnly = true;
                        }
                        else
                        {
                            vsTextBox.ReadOnly = false;
                        }
                    }
                } // VS blank

                if(toggle.Offset == Aircraft.pmdg747.MCP_annunVS)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        vsButton.Text = $"&VS mode {toggle.CurrentState.Value}";
                        vsButton.AccessibleName = $"Vertical speed mode {toggle.CurrentState.Value}";

                    }
                } // vs mode
            } // loop

            if (Aircraft.pmdg747.MCP_VertSpeed.ValueChanged)
            {
                vsTextBox.Text = Aircraft.pmdg747.MCP_VertSpeed.Value.ToString();
            }
        } // VsTimerTick

        private void VerticalSpeedBox_Load(object sender, EventArgs e)
        {

            vsTimer.Elapsed += new System.Timers.ElapsedEventHandler(VsTimerTick);
            vsTimer.Start();

            foreach (PanelObject control in PMDG747Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg747.MCP_VertSpeedBlank)
                {
                                                                if (toggle.CurrentState.Value == "on")
                        {
                            vsTextBox.ReadOnly = true;
                        }
                        else
                        {
                            vsTextBox.ReadOnly = false;
                        }
                                    } // VS blank

                if (toggle.Offset == Aircraft.pmdg747.MCP_annunVS)
                {
                                            vsButton.Text = $"&VS mode {toggle.CurrentState.Value}";
                        vsButton.AccessibleName = $"Vertical speed mode {toggle.CurrentState.Value}";
                                                        } // vs mode
            } // loop

                                        vsTextBox.Text = Aircraft.pmdg747.MCP_VertSpeed.Value.ToString();
                    }

        private void vsTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                PMDG747Aircraft.SetVerticalSpeed(vsTextBox.Text);
            }
        }

        private void vsButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.VerticalSpeedMode();
        }

        private void VerticalSpeedBox_KeyDown(object sender, KeyEventArgs e)
        {
            if((e.Alt && e.KeyCode == Keys.F4) || e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                Hide();
            }
        }

        private void VerticalSpeedBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                Hide();
            }
        }
    }
}
