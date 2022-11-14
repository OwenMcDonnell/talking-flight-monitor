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

namespace tfm.PMDG.PMDG_737.CockpitPanels.ForwardOverhead
{
    public partial class ctlAPU : UserControl, iPanelsPage
    {

        private System.Timers.Timer apuTimer = new System.Timers.Timer();
        private PanelObject[] apuControls = PMDG737Aircraft.PanelControls.Where(x => x.PanelName == "Forward Overhead" && x.PanelSection == "APU").ToArray();

        public ctlAPU()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ApuTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {
            foreach(PanelObject control in apuControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.APU_EGTNeedle)
                {
                    Offset<float> offset = (Offset<float>)toggle.Offset;
                    egtTextBox.Text = offset.Value.ToString();
                } // EGT

                if(toggle.Offset == Aircraft.pmdg737.APU_annunMAINT)
                {
                    maintTextBox.Text = toggle.CurrentState.Value;
                } // maint.

                if(toggle.Offset == Aircraft.pmdg737.APU_annunLOW_OIL_PRESSURE)
                {
                    lowOilPressureTextBox.Text = toggle.CurrentState.Value;
                } // Low oil pressure.

                if(toggle.Offset == Aircraft.pmdg737.APU_annunFAULT)
                {
                    faultTextBox.Text = toggle.CurrentState.Value;
                } // fault

                if(toggle.Offset == Aircraft.pmdg737.APU_annunOVERSPEED)
                {
                    overSpeedTextBox.Text = toggle.CurrentState.Value;
                } // overspeed.
            }
        }

        private void ctlAPU_Load(object sender, EventArgs e)
        {
            apuTimer.Elapsed += new System.Timers.ElapsedEventHandler(ApuTimerTick);
            apuTimer.Interval = 300;
            apuTimer.Start();
        }

        private void ctlAPU_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                apuTimer.Start();
            }
            else
            {
                apuTimer.Stop();
            }

        }
    }
}
