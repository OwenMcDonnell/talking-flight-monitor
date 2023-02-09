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
    public partial class HeadingBox : Form
    {

        private System.Timers.Timer headingTimer = new System.Timers.Timer();

        public HeadingBox()
        {
            InitializeComponent();
        }

        private void HeadingTimerTick(object Sender, System.Timers.ElapsedEventArgs eventArgs)
        {

            foreach(PanelObject control in PMDG747Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg747.MCP_annunLNAV)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        lNavButton.Text = $"&LNav {toggle.CurrentState.Value}";
                        lNavButton.AccessibleName = $"LNav {toggle.CurrentState.Value}";
                    }
                } // LNav

                if(toggle.Offset == Aircraft.pmdg747.MCP_annunHDG_HOLD)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        holdButton.Text = $"&Hold {toggle.CurrentState.Value}";
                        holdButton.AccessibleName = $"Hold {toggle.CurrentState.Value}";

                    }
                } // hold
            } // loop

            if (Aircraft.pmdg747.MCP_Heading.ValueChanged)
            {
                headingTextBox.Text = Aircraft.pmdg747.MCP_Heading.Value.ToString();
            }
        } // HeadingTimerTick

        private void HeadingBox_Load(object sender, EventArgs e)
        {

            headingTimer.Elapsed += new System.Timers.ElapsedEventHandler(HeadingTimerTick);
            headingTimer.Start();

            foreach (PanelObject control in PMDG747Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg747.MCP_annunLNAV)
                {
                                                                lNavButton.Text = $"&LNav {toggle.CurrentState.Value}";
                        lNavButton.AccessibleName = $"LNav {toggle.CurrentState.Value}";
                                    } // LNav

                if (toggle.Offset == Aircraft.pmdg747.MCP_annunHDG_HOLD)
                {
                                            holdButton.Text = $"&Hold {toggle.CurrentState.Value}";
                        holdButton.AccessibleName = $"Hold {toggle.CurrentState.Value}";
                                                        } // hold
            } // loop

                                        headingTextBox.Text = Aircraft.pmdg747.MCP_Heading.Value.ToString();
                                }

        private void headingTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                PMDG747Aircraft.SetHeading(headingTextBox.Text);
            }
        }

        private void interveneButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.HeadingIntervene();
        }

        private void lNavButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.LNav();
        }

        private void holdButton_Click(object sender, EventArgs e)
        {
            PMDG747Aircraft.HeadingHold();
        }

        private void HeadingBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                Hide();
            }
        }

        private void HeadingBox_KeyDown(object sender, KeyEventArgs e)
        {
            if((e.Alt && e.KeyCode == Keys.F4) || e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                Hide();
            }
        }
    }
}
