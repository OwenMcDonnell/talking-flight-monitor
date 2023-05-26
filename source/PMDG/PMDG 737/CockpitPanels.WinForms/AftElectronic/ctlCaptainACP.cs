using DavyKager;
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

namespace tfm.PMDG.PMDG_737.CockpitPanels.AftElectronic
{
    public partial class ctlCaptainACP : UserControl, iPanelsPage
    {

        System.Timers.Timer acpTimer = new System.Timers.Timer();

        public ctlCaptainACP()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void AcpTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach(PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.COMM_SelectedMic[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        micComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }
                } // microphone

                if(toggle.Offset == Aircraft.pmdg737.COMM_ReceiverSwitches[0])
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        receiverComboBox.SelectedIndex = toggle.CurrentState.Key;
                    }
                }
            } // loop.
        }

        private void ctlCaptainACP_Load(object sender, EventArgs e)
        {
            Tolk.Load();
            acpTimer.Elapsed += new System.Timers.ElapsedEventHandler(AcpTimerTick);
                                        acpTimer.Start();
            

            foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.COMM_SelectedMic[0])
                {
                    micComboBox.SelectedIndex = toggle.CurrentState.Key;
                } // microphone
                                if(toggle.Offset == Aircraft.pmdg737.COMM_ReceiverSwitches[0])
                {
                    receiverComboBox.SelectedIndex = toggle.CurrentState.Key;
                }
            } // loop.

        }

        private void micComboBox_Enter(object sender, EventArgs e)
        {
            if(Tolk.DetectScreenReader() == "NVDA")
            {
                Tolk.Output(micComboBox.SelectedItem.ToString());
            }
        }

        private void micComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
                        PMDG737Aircraft.CaptainMicrophoneSelector(micComboBox.SelectedItem.ToString());
        }

           }
}
