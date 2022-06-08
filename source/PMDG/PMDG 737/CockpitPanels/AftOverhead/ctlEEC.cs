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

namespace tfm.PMDG.PMDG_737.CockpitPanels.AftOverhead
{
    public partial class ctlEEC : UserControl, iPanelsPage
    {
        private Timer eecTimer = new Timer();
        private PanelObject[] toggles = PMDG737Aircraft.PanelControls.Where(x => x.PanelName == "Aft Overhead" && x.PanelSection == "Engines").ToArray();

        public ctlEEC()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void eecTimerTick(object Sender, EventArgs eventArgs)
        {
            foreach(PanelObject control in toggles)
            {
                var toggle = (SingleStateToggle)control;
                // Control switch #1...
                if(toggle.Offset == Aircraft.pmdg737.ENG_EECSwitch[0])
                {
                    leftEECButton.AccessibleName = toggle.ToString();
                            leftEECButton.Text = $"&Left {toggle.CurrentState.Value}";
                                    } // EEC #1
                if(toggle.Offset == Aircraft.pmdg737.ENG_EECSwitch[1])
                {
                    rightEECButton.AccessibleName = toggle.ToString();
                    rightEECButton.Text = $"&Right {toggle.CurrentState.Value}";
                } // EEC #2

                // Control indicator #1
                if(toggle.Offset == Aircraft.pmdg737.ENG_annunENGINE_CONTROL[0])
                {
                    leftControlTextBox.Text = toggle.CurrentState.Value;
                } // Control indicator #1

                // Control indicator #2...
                if(toggle.Offset == Aircraft.pmdg737.ENG_annunENGINE_CONTROL[1])
                {
                    rightControlTextBox.Text = toggle.CurrentState.Value;
                } // Control indicator #2.

                // Alternate control indicator #1...
                if(toggle.Offset == Aircraft.pmdg737.ENG_annunALTN[0])
                {
                    leftAlternateTextBox.Text = toggle.CurrentState.Value;
                } // Alternate control indicator #1.

                // Alternate control indicator #2...
                if(toggle.Offset == Aircraft.pmdg737.ENG_annunALTN[1])
                {
                    rightAlternateTextBox.Text = toggle.CurrentState.Value;
                } // Alternate control indicator #2.

                // Reverser indicator #1.
                if(toggle.Offset == Aircraft.pmdg737.ENG_annunREVERSER[0])
                {
                    leftReverserTextBox.Text = toggle.CurrentState.Value;
                } // Reverser indicator #1.

                // Reverser indicator #2...
                if(toggle.Offset == Aircraft.pmdg737.ENG_annunREVERSER[1])
                {
                    rightReverserTextBox.Text = toggle.CurrentState.Value;
                } // Reverser indicator #2.
            }
        }

        private void ctlEEC_Load(object sender, EventArgs e)
        {
            eecTimer.Tick += new EventHandler(eecTimerTick);
            eecTimer.Start();
        }

        private void leftEECButton_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle)PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ENG_EECSwitch[0]).ToArray()[0];
            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.EngineEEC1Off();
            }
            else
            {
                PMDG737Aircraft.EngineEEC1On();
            }
        }

        private void rightEECButton_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle)PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ENG_EECSwitch[1]).ToArray()[0];

            if(toggle.CurrentState.Value == "on")
            {
                PMDG737Aircraft.EngineEEC2Off();
            }
            else
            {
                PMDG737Aircraft.EngineEEC2On();
            }
        }
    }
}
