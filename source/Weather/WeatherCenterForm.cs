using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace tfm.Weather
{
    public partial class WeatherCenterForm : Form
    {

        private Dictionary<string, iPanelsPage> pages = new Dictionary<string, iPanelsPage>();
        iPanelsPage currentPage = null;

        public WeatherCenterForm()
        {
            InitializeComponent();
            LoadPages();
        }

        private void LoadPages()
        {

            pages.Add("windNode", new Weather.ctlWindLayers());
            pages.Add("cloudsNode", new Weather.ctlClouds());
            pages.Add("tempraturesNode", new Weather.ctlTempratures());

            // Set parent and hide pages.
            foreach(iPanelsPage page in this.pages.Values)
            {
                page.Parent = this.contentPanel;
                page.SetDocking();
                page.Hide();
            }
        } // LoadPages

        private void weatherCategoriesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (this.pages.ContainsKey(e.Node.Name))
            {
                if(this.currentPage != null)
                {
                    this.currentPage.Hide();
                }
                this.currentPage = this.pages[e.Node.Name];
                this.currentPage.Show();
            }
        }

        private void WeatherCenterForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F6)
            {
                weatherCategoriesTreeView.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
