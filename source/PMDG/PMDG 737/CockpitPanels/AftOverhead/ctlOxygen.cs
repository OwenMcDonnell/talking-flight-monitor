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
    public partial class ctlOxygen : UserControl, iPanelsPage
    {

        private System.Timers.Timer oxyTimer = new System.Timers.Timer();
        private PanelObject[] oxyControls = PMDG737Aircraft.PanelControls.Where(x => x.PanelName == "Aft Overhead" && x.PanelSection == "Oxygen").ToArray();
        public ctlOxygen()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void oxyTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {
            foreach(PanelObject control in oxyControls)
            {
                var toggle = (SingleStateToggle)control;
                                if(toggle.Offset == Aircraft.pmdg737.OXY_annunPASS_OXY_ON)
                {
                    passengerOxygenTextBox.Text = toggle.CurrentState.Value;
                                                        } // passenger oxygen
                if(toggle.Offset == Aircraft.pmdg737.OXY_SwNormal)
                {
                    oxygenButton.Text= $"&{toggle.ToString()}";
                    oxygenButton.AccessibleName = toggle.ToString();
                                                        } // Oxygen switch
                if(toggle.Offset == Aircraft.pmdg737.OXY_Needle)
                {
                                                                Offset<byte> offset = (Offset<byte>)toggle.Offset;
                    oxygenNeedleTextBox.Text = $"{toggle.percentageValue}%";
                                                        } // Oxygen needle.

            } // oxyControls loop.
        }

        private void ctlOxygen_Load(object sender, EventArgs e)
        {
            oxyTimer.Elapsed += new System.Timers.ElapsedEventHandler(oxyTimerTick);
            oxyTimer.Interval = 300;
            oxyTimer.Start();
        }

        private void oxygenButton_Click(object sender, EventArgs e)
        {
            var toggle = (SingleStateToggle)PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.OXY_SwNormal).ToArray()[0];
            if(toggle.CurrentState.Value == "off")
            {
                PMDG737Aircraft.PassengerOxygenNormal();
            }
            else
            {
                PMDG737Aircraft.PassengerOxygenOff();
                
            }
        }

        private void ctlOxygen_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                oxyTimer.Start();
            }
            else
            {
                oxyTimer.Stop();
            }

        }
    }
}
