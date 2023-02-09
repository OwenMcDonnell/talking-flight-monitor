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

namespace tfm.PMDG.PMDG_737.CockpitPanels.AftOverhead
{
    public partial class ctlDomeLights : UserControl, iPanelsPage
    {
        private System.Timers.Timer lightsTimer = new System.Timers.Timer();
        PanelObjects.SingleStateToggle domeLights = (PanelObjects.SingleStateToggle)PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.LTS_DomeWhiteSw).ToArray()[0];
        public ctlDomeLights()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void LightsTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {
            if (domeLights.Offset.ValueChanged)
            {
                domeLightsComboBox.SelectedIndex = domeLights.CurrentState.Key;
            }
                                                }

                private void ctlDomeLights_Load(object sender, EventArgs e)
        {
            lightsTimer.Elapsed += new System.Timers.ElapsedEventHandler(LightsTimerTick);
            lightsTimer.Interval = 300;
            lightsTimer.Start();
            domeLightsComboBox.SelectedIndex = domeLights.CurrentState.Key;
                        Tolk.Load();
            Tolk.Silence();
        }

        private void domeLightsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Tolk.DetectScreenReader() == "NVDA")
            {
                Tolk.Output(domeLightsComboBox.SelectedItem.ToString());
            }
            PMDG737Aircraft.CalculateSwitchPosition(PMDG_737_NGX_Control.EVT_OH_DOME_SWITCH, domeLights.CurrentState.Key, domeLightsComboBox.SelectedIndex, true);
                    }

        private void ctlDomeLights_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                lightsTimer.Start();
            }
            else
            {
                lightsTimer.Stop();
            }

        }
    }
}
