using System.Xml;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.SimBrief
{
    public partial class SimBriefForm : Form
    {

        private Dictionary<string, iPanelsPage> pages = new Dictionary<string, iPanelsPage>();
        iPanelsPage currentPage = null;
        public SimBriefForm()
        {
            InitializeComponent();
            if(FlightPlan.XMLFlightPlan.Root.Element("fetch").Element("status").Value != "Success")
            {
                MessageBox.Show("There was a problem downloading your most recent flight plan. Try generating it again, or creating a new one before trying next time.");
                this.Close();
            }
            LoadPages();
        }

        private void LoadPages()
        {
            pages.Add("navlogNode", new tfm.SimBrief.ctlNavlog());
            pages.Add("airportsNode", new SimBrief.ctlAirports());
            // Set parent and hide pages.
            foreach (iPanelsPage page in this.pages.Values)
            {
                page.Parent = this.contentPanel;
                page.SetDocking();
                page.Hide();
            }
        } // LoadPages

        private void flightPlanCategoriesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
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
