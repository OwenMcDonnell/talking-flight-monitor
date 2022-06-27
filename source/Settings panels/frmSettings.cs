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
        }
}
