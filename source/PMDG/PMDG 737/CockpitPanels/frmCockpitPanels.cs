using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tfm.PMDG.PMDG_737.CockpitPanels.AftOverhead;
using tfm.PMDG.PMDG_737.CockpitPanels.ForwardOverhead;

namespace tfm
{
    public partial class frmCockpitPanels : Form
    {
        private Dictionary<string, iPanelsPage> pages = new Dictionary<string, iPanelsPage>();
        iPanelsPage currentPage = null;

        public frmCockpitPanels()
        {
            InitializeComponent();
            loadPages();
        }

        
        private void loadPages()
        {
                                    pages.Add("nodMCP", new ctlMCP());
            pages.Add("nodHydraulics", new ctlHydraulics());
            pages.Add("nodEngines", new ctlEngines_737());      
            pages.Add("nodAirSystems", new ctlAirSystems());
            pages.Add("nodAntiIce", new ctlAntiIce());
            pages.Add("nodPressurization", new ctlPressurization());
            // redesigned pages. keep the ones above for backups.
            // --panel: Aft Overhead
            pages.Add("adiruNode", new ctlADIRU());
            pages.Add("PSEUNode", new ctlPSEU());
            pages.Add("serviceInterPhoneNode", new ctlServiceInterphone());
            pages.Add("domeLightsNode", new ctlDomeLights());
            pages.Add("eecNode", new ctlEEC());
            pages.Add("oxygenNode", new ctlOxygen());
            pages.Add("gearNode", new ctlGear());
            pages.Add("flightRecorderNode", new ctlFlightRecorder());

            // --panel: Forward Overhead
            pages.Add("flightControlsNode", new ctlFlightControls());
            pages.Add("navDisNode", new ctlNav_displays());
            pages.Add("fuelNode", new ctlFuel());
            pages.Add("electricalNode", new ctlElectrical());
            pages.Add("apuNode", new ctlAPU());
            pages.Add("wipersNode", new ctlWipers());
            // set the parent and hide them all
            foreach (iPanelsPage page in this.pages.Values)
            {
                page.Parent = this.pnlContent;
                page.SetDocking();
                page.Hide();
            }

        }

        private void tvPanels_AfterSelect(object sender, TreeViewEventArgs e)
        {
                                    if (this.pages.ContainsKey(e.Node.Name))
            {
                if (this.currentPage != null)
                {
                    this.currentPage.Hide();
                }
                this.currentPage = this.pages[e.Node.Name];
                this.currentPage.Show();
            }

        }
    }
}
