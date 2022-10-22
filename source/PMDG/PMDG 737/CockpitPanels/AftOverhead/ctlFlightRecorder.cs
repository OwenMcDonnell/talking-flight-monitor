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
    public partial class ctlFlightRecorder : UserControl, iPanelsPage
    {

        private Timer flightRecorderTimer = new Timer();
        private PanelObject[] flightRecorderControls = PMDG737Aircraft.PanelControls.Where(x => x.PanelName == "Aft Overhead" && x.PanelSection == "Flight recorder").ToArray();

        public ctlFlightRecorder()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void flightRecorderTimerTick(object Sender, EventArgs eventArgs)
        {
            foreach(PanelObject control in flightRecorderControls)
            {
                var toggle = (SingleStateToggle)control;
                if(toggle.Offset == Aircraft.pmdg737.FLTREC_SwNormal)
                {
                    flightRecorderButton.Text = $"&{toggle.ToString()}";
                    flightRecorderButton.AccessibleName = toggle.ToString();
                }
                if(toggle.Offset == Aircraft.pmdg737.FLTREC_annunOFF)
                {
                    flightRecorderTextBox.Text = toggle.CurrentState.Value;
                }
            }
        }

        private void flightRecorderButton_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle)PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.FLTREC_SwNormal).ToArray()[0];

            if(toggle.CurrentState.Value == "normal")
            {
                PMDG737Aircraft.FlightRecorderTest();
            }
            else
            {
                PMDG737Aircraft.FlightRecorderNormal();
            }
        }

        private void ctlFlightRecorder_Load(object sender, EventArgs e)
        {
            flightRecorderTimer.Tick += new EventHandler(flightRecorderTimerTick);
            flightRecorderTimer.Start();
        }

        private void ctlFlightRecorder_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                flightRecorderTimer.Start();
            }
            else
            {
                flightRecorderTimer.Stop();
            }

        }
    }
}
