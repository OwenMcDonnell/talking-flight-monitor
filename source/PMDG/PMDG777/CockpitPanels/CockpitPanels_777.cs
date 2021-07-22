using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm
{
    public partial class CockpitPanels_777 : Form
    {

        private Dictionary<string, iPanelsPage> pages = new Dictionary<string, iPanelsPage>();
        iPanelsPage currentPage = null;

        public CockpitPanels_777()
        {
            InitializeComponent();
            LoadPages();
        }
        private void LoadPages()
        {
            pages.Add("electricalNode", new ctlElectrical_777());
            pages.Add("MCPNode", new ctlMCP_777());
            foreach(iPanelsPage page in this.pages.Values)
            {
                page.Parent = this.contentPanel;
                page.SetDocking();
                page.Hide();

            }
        }
        private void cockpitPanelsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(this.pages.ContainsKey(e.Node.Name))
            {
                if(this.currentPage != null)
                {
                    this.currentPage.Hide();
                }
                this.currentPage = pages[e.Node.Name];
                this.currentPage.Show();
            }
        }
    }
}
