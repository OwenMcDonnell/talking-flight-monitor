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
    public partial class ctlServiceInterphone : UserControl, iPanelsPage
    {
        private Timer phoneTimer = new Timer();

        public ctlServiceInterphone()
        {
            InitializeComponent();
        }

        private void phoneTimerTick(object Sender, EventArgs eventArgs)
        {
        foreach(PanelObjects.SingleStateToggle toggle in PMDG737Aircraft.PanelControls)
            {
                if(toggle.Offset == Aircraft.pmdg737.COMM_ServiceInterphoneSw)
                {
                    phoneButton.Text = $"&Service interphone {toggle.CurrentState.Value}";
                    phoneButton.AccessibleName = $"Service interphone {toggle.CurrentState.Value}";
                }
            }

        }

        public void SetDocking()
        {
                    }

        private void phoneButton_Click(object sender, EventArgs e)
        {
            PanelObjects.SingleStateToggle toggle = (PanelObjects.SingleStateToggle)PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.COMM_ServiceInterphoneSw).ToArray()[0];

            if(toggle.CurrentState.Key == 0)
            {
                PMDG737Aircraft.CalculateSwitchPosition(FSUIPC.PMDG_737_NGX_Control.EVT_OH_SERVICE_INTERPHONE_SWITCH, toggle.CurrentState.Key, 1, true);
            }
            else
            {
                PMDG737Aircraft.CalculateSwitchPosition(FSUIPC.PMDG_737_NGX_Control.EVT_OH_SERVICE_INTERPHONE_SWITCH, toggle.CurrentState.Key, 0, true);
            }
        }

        private void ctlServiceInterphone_Load(object sender, EventArgs e)
        {
            phoneTimer.Tick += new EventHandler(phoneTimerTick);
            phoneTimer.Start();
        }
    }
}
