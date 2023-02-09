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

namespace tfm.PMDG.PMDG_737.CockpitPanels.Forward
{
    public partial class ctlForwardSpeed : UserControl, iPanelsPage
    {

        private System.Timers.Timer speedTimer = new System.Timers.Timer();
        public ctlForwardSpeed()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        public void SpeedTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach(PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.MAIN_N1SetSelector)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        n1SelectorButton.Text = $"&N1 selector {toggle.CurrentState.Value}";
                        n1SelectorButton.AccessibleName = $"N1 selector {toggle.CurrentState.Value}";
                    }
                } // N1 selector

                if(toggle.Offset == Aircraft.pmdg737.MAIN_SpdRefSelector)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        speedRefButton.Text = $"&Speed ref {toggle.CurrentState.Value}";
                        speedRefButton.AccessibleName = $"Speed ref {toggle.CurrentState.Value}";
                    }
                } // speed ref
            } // loop
        } // TimerTick

        private void ctlForwardSpeed_Load(object sender, EventArgs e)
        {

            speedTimer.Elapsed += new System.Timers.ElapsedEventHandler(SpeedTimerTick);
            speedTimer.Start();
            foreach (PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg737.MAIN_N1SetSelector)
                {
                                                                n1SelectorButton.Text = $"&N1 selector {toggle.CurrentState.Value}";
                        n1SelectorButton.AccessibleName = $"N1 selector {toggle.CurrentState.Value}";
                                    } // N1 selector

                if (toggle.Offset == Aircraft.pmdg737.MAIN_SpdRefSelector)
                {
                                            speedRefButton.Text = $"&Speed ref {toggle.CurrentState.Value}";
                        speedRefButton.AccessibleName = $"Speed ref {toggle.CurrentState.Value}";
                } // speed ref
            } // loop

                    }

        private void n1SelectorButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.N1SetSelector();
        }

        private void speedRefButton_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.SpeedRef();
        }

        private void ctlForwardSpeed_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                speedTimer.Start();
            }
            else
            {
                speedTimer.Stop();
            }

        }
    }
}
