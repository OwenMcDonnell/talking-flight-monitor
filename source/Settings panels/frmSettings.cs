using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tfm.Settings_panels;

namespace tfm
{
    public partial class frmSettings : Form
    {
        private Dictionary<string, iSettingsPage> pages = new Dictionary<string, iSettingsPage>();
        iSettingsPage currentPage = null;

        public frmSettings()
        {
            InitializeComponent();
            loadPages();
        }

        private void loadPages()
        {
            pages.Add("nodGeneral", new ctlGeneral());
            pages.Add("nodSpeechOutput", new ctlSpeechOutput());
            pages.Add("nodTiming", new ctlTiming());
            pages.Add("airportsDatabaseNode", new ctlDatabases());
            pages.Add("nodAircraft", new ctlAircraft());
            pages.Add("nodeUserInterface", new ctlUserInterface());
            pages.Add("nodPMDG", new ctlPMDG());
            pages.Add("737AdiruNode", new Settings_panels.PMDG737.ctlADIRU());
            pages.Add("737PseuNode", new Settings_panels.PMDG737.ctlPSEU());
            pages.Add("737ServiceInterPhoneNode", new Settings_panels.PMDG737.ctlServiceInterPhone());
            pages.Add("737DomeLightsNode", new Settings_panels.PMDG737.ctlDomeLights());
            pages.Add("737EecNode", new Settings_panels.PMDG737.ctlEEC());
            pages.Add("737OxygenNode", new Settings_panels.PMDG737.ctlOxygen());
            pages.Add("737GearNode", new Settings_panels.PMDG737.ctlGear());
            pages.Add("737FlightRecorderNode", new Settings_panels.PMDG737.ctlFlightRecorder());
            pages.Add("737FlightControlsNode", new Settings_panels.PMDG737.ctlFlightControls());
            pages.Add("737NavDisNode", new Settings_panels.PMDG737.ctlNav_Dis());
            pages.Add("737FuelNode", new Settings_panels.PMDG737.ctlFuel());
            pages.Add("737ElectricalNode", new Settings_panels.PMDG737.ctlElectrical());
            pages.Add("737ApuNode", new Settings_panels.PMDG737.ctlAPU());
            pages.Add("737WipersNode", new Settings_panels.PMDG737.ctlWipers());

            // Center overhead...
            pages.Add("737CenterOverheadNode", new Settings_panels.PMDG737.ctlCenterMain());
            pages.Add("737AntiIceNode", new Settings_panels.PMDG737.ctlAntiIce());
            pages.Add("737HydraulicsNode", new Settings_panels.PMDG737.ctlHydraulics());
            pages.Add("737AirSystemsNode", new tfm.Settings_panels.PMDG737.ctlAirSystems());

            // --section: bottom overhead
            pages.Add("737EnginesNode", new tfm.Settings_panels.PMDG737.ctlEngines());
            pages.Add("737LightsNode", new tfm.Settings_panels.PMDG737.ctlLights());

            // ---panel: glare shield
            pages.Add("737WarningsNode", new Settings_panels.PMDG737.ctlWarnings());
            pages.Add("737mcpNode", new Settings_panels.PMDG737.ctlMCP());

            // --panel: Forward
            pages.Add("737ForwardNode", new tfm.Settings_panels.PMDG737.ctlForwardMain());
            pages.Add("737ForwardMcpNode", new tfm.Settings_panels.PMDG737.ctlForwardMcp());
            pages.Add("737DUNode", new tfm.Settings_panels.PMDG737.ctlDU());
            pages.Add("737StandbyNode", new tfm.Settings_panels.PMDG737.ctlStandby());
            pages.Add("737ForwardSpeedNode", new tfm.Settings_panels.PMDG737.ctlForwardSpeed());
            pages.Add("737ForwardBrakesNode", new tfm.Settings_panels.PMDG737.ctlForwardBrakes());
            pages.Add("737ForwardFlapsNode", new tfm.Settings_panels.PMDG737.ctlForwardFlaps());
            pages.Add("737ForwardGearNode", new tfm.Settings_panels.PMDG737.ctlForwardGear());

            // --panel: Lower forward
            pages.Add("737LowerForwardNode", new tfm.Settings_panels.PMDG737.ctlLowerForward());

            // --panel: Control Stand
            pages.Add("737ControlStandCDUNode", new tfm.Settings_panels.PMDG737.ctlControlStandCDU());
            pages.Add("737ControlStandTrimNode", new tfm.Settings_panels.PMDG737.ctlControlStandTrim());
            pages.Add("737PedestalNode", new tfm.Settings_panels.PMDG737.ctlControlStandPedestal());
            pages.Add("737FireNode", new tfm.Settings_panels.PMDG737.ctlFire());
            pages.Add("737CargoFireNode", new tfm.Settings_panels.PMDG737.ctlCargoFire());
            pages.Add("737TransponderNode", new tfm.Settings_panels.PMDG737.ctlTransponder());

            // --panel: AFS
            pages.Add("737AfsNode", new tfm.Settings_panels.PMDG737.ctlAFS());
                        // set the parent and hide them all
            foreach (iSettingsPage page in this.pages.Values)
            {
                page.Parent = this.pnlContent;
                page.SetDocking();
                page.Hide();
            }

        }

        private void tvCategory_AfterSelect(object sender, TreeViewEventArgs e)
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

        private void frmSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F6)
            {
                tvCategories.Focus();
            }
        }
    }
}
