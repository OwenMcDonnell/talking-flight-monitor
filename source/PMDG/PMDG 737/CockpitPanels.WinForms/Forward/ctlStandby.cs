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
    public partial class ctlStandby : UserControl, iPanelsPage
    {

        private System.Timers.Timer standbyTimer = new System.Timers.Timer();
        public ctlStandby()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void StandbyTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach(PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.MAIN_RMISelector1_VOR)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rmi1Button.Text = $"RMI #&1 {toggle.CurrentState.Value}";
                        rmi1Button.AccessibleName = $"RMI #1 {toggle.CurrentState.Value}";
                    }
                } // RMI 1

                if(toggle.Offset == Aircraft.pmdg737.MAIN_RMISelector2_VOR)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rmi2Button.Text = $"RMI #&2 {toggle.CurrentState.Value}";
                        rmi2Button.AccessibleName = $"RMI #2 {toggle.CurrentState.Value}";
                    }
                } // RMI 2
            } // loop
        } // TimerTick

        private void ctlStandby_Load(object sender, EventArgs e)
        {

            standbyTimer.Elapsed += new  System.Timers.ElapsedEventHandler(StandbyTimerTick);
            standbyTimer.Start();

            foreach(PanelObject control in PMDG737Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg737.MAIN_RMISelector1_VOR)
                {
                    rmi1Button.Text = $"RMI #&1 {toggle.CurrentState.Value}";
                    rmi1Button.AccessibleName = $"RMI #1 {toggle.CurrentState.Value}";
                } //RMI 1

                if(toggle.Offset == Aircraft.pmdg737.MAIN_RMISelector2_VOR)
                {
                    rmi2Button.Text = $"RMI #&2 {toggle.CurrentState.Value}";
                    rmi2Button.AccessibleName = $"RMI #2 {toggle.CurrentState.Value}";
                }
            } // loop
        }

        private void rmi1Button_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.RMI1();
        }

        private void rmi2Button_Click(object sender, EventArgs e)
        {
            PMDG737Aircraft.RMI2();
        }

        private void ctlStandby_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                standbyTimer.Start();
            }
            else
            {
                standbyTimer.Stop();
            }

        }
    }
}
