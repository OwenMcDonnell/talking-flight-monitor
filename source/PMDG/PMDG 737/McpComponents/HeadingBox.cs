using DavyKager;
using FSUIPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.PMDG.PMDG737.McpComponents
{
    public partial class HeadingBox : Form
    {

        private System.Windows.Forms.Timer headingTimer = new System.Windows.Forms.Timer();

        public HeadingBox()
        {
            InitializeComponent();
            Tolk.Load();

            headingTimer.Tick += new EventHandler(TimerTick);
            headingTimer.Start();
        } // End constructor.

        private void TimerTick(object Sender, EventArgs eventArgs)
        {
                                        if (Aircraft.pmdg737.MCP_Heading.ValueChanged)
                {
                    hdgTrkTextBox.Text = Aircraft.pmdg737.MCP_Heading.Value.ToString();
                }
            if (Aircraft.pmdg737.MCP_annunHDG_SEL.ValueChanged)
            {
                switch (Aircraft.pmdg737.MCP_annunHDG_SEL.Value)
                {
                    case 0:
                        hdgHoldButton.Text = "Heading &select off";
                        hdgHoldButton.AccessibleName = "Heading select off";
                        break;
                    case 1:
                        hdgHoldButton.Text = "Heading &select on";
                        hdgHoldButton.AccessibleName = "Heading select on";
                        break;
                }
            }
                    if (Aircraft.pmdg737.MCP_annunLNAV.ValueChanged)
                    {
                        switch (Aircraft.pmdg737.MCP_annunLNAV.Value)
                        {
                            case 0:
                                lNavButton.Text = "&LNav off";
                                lNavButton.AccessibleName = "LNav off";
                                break;
                            case 1:
                                lNavButton.Text = "&LNav on";
                                lNavButton.AccessibleName = "LNav on";
                        break;
                        }
                    }
                        } // End TimerTick.

        private void HeadingBox_Load(object sender, EventArgs e)
        {
            hdgTrkTextBox.Text = Aircraft.pmdg737.MCP_Heading.Value.ToString();

            if (Aircraft.pmdg737.MCP_annunHDG_SEL.Value == 0)
            {
                hdgHoldButton.Text = "Heading &select off";
                hdgHoldButton.AccessibleName = "Heading select off";
            }
            else
            {
                hdgHoldButton.Text = "Heading &select on";
                hdgHoldButton.AccessibleName = "Heading select on";
            }
            if (Aircraft.pmdg737.MCP_annunLNAV.Value == 0)
            {
                lNavButton.Text = "&LNav off";
                lNavButton.AccessibleName = "LNav off";
            }
            else
            {
                lNavButton.Text = "&LNav on";
                lNavButton.AccessibleName = "LNav on";
            }
        } // End form load.

        private void HeadingBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        } // End form closing.

        private void HeadingBox_KeyDown(object sender, KeyEventArgs e)
        {
            if((e.Alt) && (e.KeyCode == Keys.E))
            {
                hdgTrkTextBox.Focus();
            }
            if(e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                Hide();
            }
        } // End form keydown.

                private void hdgHoldButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.ToggleHeadingSelect();
        } // End heading hold button click.

        private void lNavButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.ToggleLNav();
        } // End LNavButton click.

                private void hdgTrkTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                PMDG737Aircraft.SetHeading(hdgTrkTextBox.Text);
            }
        } // End hdgTrkTextBox KeyDown.
    } // End heading box.
} // End namespace.
