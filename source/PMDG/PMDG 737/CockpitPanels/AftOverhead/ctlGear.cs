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
    public partial class ctlGear : UserControl, iPanelsPage
    {

        private Timer gearTimer = new Timer();
        private PanelObject[] gearControls = PMDG737Aircraft.PanelControls.Where(x => x.PanelName == "Aft Overhead" && x.PanelSection == "Gear").ToArray();

        public ctlGear()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void gearTimerTick(object Sender, EventArgs eventArgs)
        {
            foreach(PanelObject control in gearControls)
            {
                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.GEAR_annunOvhdNOSE)
                {
                    noseGearTextBox.Text = toggle.CurrentState.Value;
                }
                if(toggle.Offset == Aircraft.pmdg737.GEAR_annunOvhdLEFT)
                {
                    leftGearTextBox.Text = toggle.CurrentState.Value;
                }
                if(toggle.Offset == Aircraft.pmdg737.GEAR_annunOvhdRIGHT)
                {
                    rightGearTextBox.Text = toggle.CurrentState.Value;
                }
            }
        }

        private void ctlGear_Load(object sender, EventArgs e)
        {
            gearTimer.Tick += new EventHandler(gearTimerTick);
            gearTimer.Interval = 300;
            gearTimer.Start();
        }

        private void ctlGear_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                gearTimer.Start();
            }
            else
            {
                gearTimer.Stop();
            }

        }
    }
}
