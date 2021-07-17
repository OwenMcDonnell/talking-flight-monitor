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
    public partial class VerticalSpeedBox : Form
    {
        System.Windows.Forms.Timer verticalSpeedTimer = new System.Windows.Forms.Timer();

        public VerticalSpeedBox()
        {
            InitializeComponent();

            verticalSpeedTimer.Tick += new EventHandler(TimerTick);
            verticalSpeedTimer.Start();
            Tolk.Load();
        } // End constructor.

        private void TimerTick(object Sender, EventArgs eventArgs)
        {

                        if(Aircraft.pmdg737.MCP_VertSpeed.ValueChanged)
            {
                vsFpaTextBox.Text = Aircraft.pmdg737.MCP_VertSpeed.Value.ToString();
            }
                    } // End TimerTick.

        private void VerticalSpeedBox_Load(object sender, EventArgs e)
        {
            if(Aircraft.pmdg737.MCP_VertSpeedBlank.Value == 0)
            {
                vsFpaTextBox.Text = Aircraft.pmdg737.MCP_VertSpeed.Value.ToString();
            }
            else
            {
                vsFpaTextBox.Text = "0";
            }
        } // End form load.

        private void interveneButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.VerticalSpeedIntervene();
        } // End intervene

        private void VerticalSpeedBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            } // End form closing.
        }

        private void VerticalSpeedBox_KeyDown(object sender, KeyEventArgs e)
        {
            
            if((e.Alt) && (e.KeyCode == Keys.E))
            {
                e.SuppressKeyPress = true;
                vsFpaTextBox.Focus();
            }
        } // End key down event.

                private void vsFpaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
                        if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                PMDG737Aircraft.SetVerticalSpeed(vsFpaTextBox.Text);
                                            } // End key check.
                                } // End vsFPATextBox KeyDown event
    } // End VerticalSpeedBox.
} // End namespace.
