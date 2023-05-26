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

namespace tfm.PMDG.PMDG_737.CockpitPanels
{
    public partial class ctlAFS : UserControl, iPanelsPage
    {

        System.Timers.Timer afsTimer = new System.Timers.Timer();

        public ctlAFS()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void AfsTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach(PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.AFS_AutothrottleServosConnected)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        servosTextBox.Text = toggle.CurrentState.Value;
                    }
                } // Servos

                if(toggle.Offset == Aircraft.pmdg737.AFS_ControlsPitch)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        pitchTextBox.Text = toggle.CurrentState.Value;
                    }
                } // pitch

                if(toggle.Offset == Aircraft.pmdg737.AFS_ControlsRoll)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rollTextBox.Text = toggle.CurrentState.Value;
                    }
                } // roll
            } // loop.
        }

        private void ctlAFS_Load(object sender, EventArgs e)
        {

            afsTimer.Elapsed += new System.Timers.ElapsedEventHandler(AfsTimerTick);
            afsTimer.Start();

            foreach(PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.AFS_AutothrottleServosConnected)
                {
                    servosTextBox.Text = toggle.CurrentState.Value;
                } // servos

                if(toggle.Offset == Aircraft.pmdg737.AFS_ControlsPitch)
                {
                    pitchTextBox.Text = toggle.CurrentState.Value;
                } // pitch

                if(toggle.Offset == Aircraft.pmdg737.AFS_ControlsRoll)
                {
                    rollTextBox.Text = toggle.CurrentState.Value;
                } // roll.
            } // loop.
        }
    }
}
