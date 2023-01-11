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
    public partial class AltitudeBox : Form
    {

        private System.Timers.Timer altitudeTimer = new System.Timers.Timer();

        public AltitudeBox()
        {
            InitializeComponent();
        }

        private void AltitudeTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach(PanelObject control in PMDG747Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg747.MCP_annunVNAV)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        vNavButton.Text = $"&VNav {toggle.CurrentState.Value}";
                        vNavButton.AccessibleName = $"VNav {toggle.CurrentState.Value}";

                    }
                } // VNav

                if(toggle.Offset == Aircraft.pmdg747.MCP_annunFLCH)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        lvlChangeButton.Text = $"&LVLCH {toggle.CurrentState.Value}";
                        lvlChangeButton.AccessibleName = $"Level change {toggle.CurrentState.Value}";
                    }
                } // level change

                if(toggle.Offset == Aircraft.pmdg747.MCP_annunALT_HOLD)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        holdButton.Text = $"&Hold {toggle.CurrentState.Value}";
                        holdButton.AccessibleName = $"Hold {toggle.CurrentState.Value}";
                    }
                } // Hold
            } // loop

            if (Aircraft.pmdg747.MCP_Altitude.ValueChanged)
            {
                altitudeTextBox.Text = Aircraft.pmdg747.MCP_Altitude.Value.ToString();
            }
        } // AltitudeTimerTick

        private void AltitudeBox_Load(object sender, EventArgs e)
        {

            altitudeTimer.Elapsed += new System.Timers.ElapsedEventHandler(AltitudeTimerTick);
            altitudeTimer.Start();

            foreach (PanelObject control in PMDG747Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg747.MCP_annunVNAV)
                {
                                                                vNavButton.Text = $"&VNav {toggle.CurrentState.Value}";
                        vNavButton.AccessibleName = $"VNav {toggle.CurrentState.Value}";
                                                        } // VNav

                if (toggle.Offset == Aircraft.pmdg747.MCP_annunFLCH)
                {
                                                                lvlChangeButton.Text = $"&LVLCH {toggle.CurrentState.Value}";
                        lvlChangeButton.AccessibleName = $"Level change {toggle.CurrentState.Value}";
                                    } // level change

                if (toggle.Offset == Aircraft.pmdg747.MCP_annunALT_HOLD)
                {
                                            holdButton.Text = $"&Hold {toggle.CurrentState.Value}";
                        holdButton.AccessibleName = $"Hold {toggle.CurrentState.Value}";
                } // Hold
            } // loop

                                        altitudeTextBox.Text = Aircraft.pmdg747.MCP_Altitude.Value.ToString();
                    }

        private void altitudeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                PMDG747Aircraft.SetAltitude(altitudeTextBox.Text);
            }
        }

        private void interveneButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.AltitudeIntervene();
        }

        private void vNavButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.VNav();
        }

        private void lvlChangeButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.LevelChange();
        }

        private void holdButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.AltitudeHold();
        }

        private void AltitudeBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                Hide();
            }
        }

        private void AltitudeBox_KeyDown(object sender, KeyEventArgs e)
        {
            if((e.Alt && e.KeyCode == Keys.F4) || e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                Hide();
            }
        }
    }
}
