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

namespace tfm.PMDG.PMDG_747.CockpitPanels
{
    public partial class ctlOverheadMaint_Fuel : UserControl, iPanelsPage
    {

        private System.Timers.Timer fuelTimer = new System.Timers.Timer();

        public ctlOverheadMaint_Fuel()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void FuelTimerTick(object Sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {

            foreach(PanelObject control in PMDG747Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if(toggle.Offset == Aircraft.pmdg747.FUEL_CWTScavengePump_Sw_ON)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        scavengePumpButton.Text = $"&Scavenge pump {toggle.CurrentState.Value}";
                        scavengePumpButton.AccessibleName = $"CWT scavenge pump {toggle.CurrentState.Value}";
                    }
                } // scavenge pump

                if(toggle.Offset == Aircraft.pmdg747.FUEL_Reserve23Xfer_Sw_OPEN)
                {
                    if (toggle.Offset.ValueChanged)
                    {
                        rsv23XferButton.Text = $"&RSV 2-3 xfer {toggle.CurrentState.Value}";
                        rsv23XferButton.AccessibleName = $"Reserve fuel 2 - 3 transfer valve {toggle.CurrentState.Value}";
                    }
                } // RSV 2-3 xfer
            } // loop.
        } // FuelTimerTick

        private void ctlOverheadMaint_Fuel_Load(object sender, EventArgs e)
        {

            fuelTimer.Elapsed += new System.Timers.ElapsedEventHandler(FuelTimerTick);
            fuelTimer.Start();

            foreach (PanelObject control in PMDG747Aircraft.PanelControls)
            {

                var toggle = (SingleStateToggle)control;

                if (toggle.Offset == Aircraft.pmdg747.FUEL_CWTScavengePump_Sw_ON)
                {
                                                                scavengePumpButton.Text = $"&Scavenge pump {toggle.CurrentState.Value}";
                        scavengePumpButton.AccessibleName = $"CWT scavenge pump {toggle.CurrentState.Value}";
                                    } // scavenge pump

                if (toggle.Offset == Aircraft.pmdg747.FUEL_Reserve23Xfer_Sw_OPEN)
                {
                                            rsv23XferButton.Text = $"&RSV 2-3 xfer {toggle.CurrentState.Value}";
                        rsv23XferButton.AccessibleName = $"Reserve fuel 2 - 3 transfer valve {toggle.CurrentState.Value}";
                } // RSV 2-3 xfer
            } // loop.
        }
    }
}
