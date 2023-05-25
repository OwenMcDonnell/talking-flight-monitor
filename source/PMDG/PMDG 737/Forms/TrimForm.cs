using FSUIPC;
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

namespace tfm.PMDG.PMDG_737.Forms
{
    public partial class TrimForm : Form
    {

        private double oldElevatorTrim = 0.0;
        private double oldAileronTrim = 0.0;
        private double oldStabTrim = 0.0;

        System.Timers.Timer trimTimer = new System.Timers.Timer();
        
        public TrimForm()
        {
            InitializeComponent();
        }

        private void TrimTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

                        if (PMDG737Aircraft.CurrentElevatorTrim != oldElevatorTrim)
            {
                trimTextBox.Text = PMDG737Aircraft.CurrentElevatorTrim.ToString();
                oldElevatorTrim = PMDG737Aircraft.CurrentElevatorTrim;
            }

            if(oldStabTrim != PMDG737Aircraft.CurrentStabTrim)
            {
                stabTrimTextBox.Text = PMDG737Aircraft.CurrentStabTrim.ToString();
                oldStabTrim = PMDG737Aircraft.CurrentStabTrim;
            }

            if(oldAileronTrim != PMDG737Aircraft.CurrentAileronTrim)
            {
                aileronTrimTextBox.Text = PMDG737Aircraft.CurrentAileronTrim.ToString();
                oldAileronTrim = PMDG737Aircraft.CurrentAileronTrim;
            }
            foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.TRIM_StabTrimMainElecSw_NORMAL)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        trimElectricalButton.Text = $"Stab trim &elec {toggle.CurrentState.Value}";
                        trimElectricalButton.AccessibleName = $"Electrical stab trim {toggle.CurrentState.Value}";
                    }
                } // Stab trim electrical

                if (toggle.Offset == Aircraft.pmdg737.TRIM_StabTrimAutoPilotSw_NORMAL)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        trimAutopilotButton.Text = $"Stab trim &AP {toggle.CurrentState.Value}";
                        trimAutopilotButton.AccessibleName = $"Auto pilot stab trim {toggle.CurrentState.Value}";
                    }
                } // stab trim AP

                if (toggle.Offset == Aircraft.pmdg737.TRIM_StabTrimSw_NORMAL)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                            stabTrimButton.Text = $"&Stab trim {toggle.CurrentState.Value}";
                        stabTrimButton.AccessibleName = $"Stab trim {toggle.CurrentState.Value}";
                    }
                } // Stab trim
            } // loop.
        }

        private void TrimForm_Load(object sender, EventArgs e)
        {
            trimTimer.Elapsed += new System.Timers.ElapsedEventHandler(TrimTimerTick);
            trimTimer.Start();

            trimTextBox.Text = PMDG737Aircraft.CurrentElevatorTrim.ToString();
            aileronTrimTextBox.Text = PMDG737Aircraft.CurrentAileronTrim.ToString();
            stabTrimTextBox.Text = PMDG737Aircraft.CurrentStabTrim.ToString();

            foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.TRIM_StabTrimMainElecSw_NORMAL)
                {
                    trimElectricalButton.Text = $"Stab trim &elec {toggle.CurrentState.Value}";
                    trimElectricalButton.AccessibleName = $"Electrical stab trim {toggle.CurrentState.Value}";
                } // Stab trim electrical

                if (toggle.Offset == Aircraft.pmdg737.TRIM_StabTrimAutoPilotSw_NORMAL)
                {
                    trimAutopilotButton.Text = $"Stab trim &AP {toggle.CurrentState.Value}";
                    trimAutopilotButton.AccessibleName = $"Auto pilot stab trim {toggle.CurrentState.Value}";
                } // stab trim AP

                if (toggle.Offset == Aircraft.pmdg737.TRIM_StabTrimSw_NORMAL)
                {
                    stabTrimButton.Text = $"&Stab trim {toggle.CurrentState.Value}";
                    stabTrimButton.AccessibleName = $"Stab trim {toggle.CurrentState.Value}";
                } // Stab trim
            } // loop.

        }

        private void trimTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.U)
            {
                PMDG737Aircraft.TrimWheelUp();
            }

            if (e.KeyCode == Keys.D)
            {
                PMDG737Aircraft.TrimWheelDown();
            }

        }

        private void trimTextBox_Enter(object sender, EventArgs e)
        {
            trimTextBox.SelectionStart = trimTextBox.SelectionLength;
        }

        private void trimElectricalButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.StabTrimElectrical();
        }

        private void trimAutopilotButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.StabTrimAutoPilot();
        }

        private void stabTrimButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.StabTrim();
        }

        private void aileronTrimTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.R)
            {
                PMDG737Aircraft.AileronTrimRight();
            }
            if(e.KeyCode == Keys.L)
            {
                PMDG737Aircraft.AileronTrimLeft();
            }
        }
    }
}
