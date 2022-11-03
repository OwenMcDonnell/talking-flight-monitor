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
        private System.Windows.Forms.Timer pseuTimer = new System.Windows.Forms.Timer();


        public ctlPSEU()
        {
            InitializeComponent();
        }

        private void PSEUTimerTick(object Sender, EventArgs eventArgs)
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
            pseuTimer.Tick += new EventHandler(PSEUTimerTick);
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
