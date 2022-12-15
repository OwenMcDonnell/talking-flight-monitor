using DavyKager;
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
    public partial class ctlPSEU : UserControl, iPanelsPage
    {
        private System.Timers.Timer pseuTimer = new System.Timers.Timer();

                public ctlPSEU()
        {
            InitializeComponent();
        }

        private void PSEUTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {
            foreach(PanelObjects.SingleStateToggle light in PMDG737Aircraft.PanelControls)
            {
                if(light.Offset == Aircraft.pmdg737.WARN_annunPSEU)
                {
                    pseuWarningTextBox.Text = light.CurrentState.Value;
                }
            }
        }

        private void ctlPSEU_Load(object sender, EventArgs e)
        {
            Tolk.Load();
            pseuTimer.Elapsed += new System.Timers.ElapsedEventHandler(PSEUTimerTick);
            pseuTimer.Interval = 300;
            pseuTimer.Start();
        }

        private void pseuWarningTextBox_Enter(object sender, EventArgs e)
        {
            
        }

        public void SetDocking()
        {
                    }

        private void ctlPSEU_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                pseuTimer.Start();
            }
            else
            {
                pseuTimer.Stop();
            }

        }
    }
}
