using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Net.Http;


namespace tfm.Settings_panels
{
    public partial class ctlSimBrief : UserControl, iSettingsPage
    {
        public ctlSimBrief()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void simBriefCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (simBriefCheckBox.Checked)
            {
                userIDLabel.Visible = true;
                userIDTextBox.Visible = true;
                validateUserIdButton.Visible = true;
            }
            else
            {
                userIDLabel.Visible = false;
                userIDTextBox.Visible = false;
                validateUserIdButton.Visible = false;
            }
        }

        private  async void validateUserIdButton_Click(object sender, EventArgs e)
        {
                        try
            {
                HttpClient client = new HttpClient();
                var rawXml = client.GetStringAsync($"https://www.simbrief.com/api/xml.fetcher.php?userid={userIDTextBox.Text}");
                var fp = XDocument.Parse(rawXml.Result);
               MessageBox.Show("SimBrief user ID validated!");
                Properties.Settings.Default.IsSimBriefUserIDValid = true;
            }
            catch(Exception ex)
            {
                userIDTextBox.Text = "Enter valid user ID";
                userIDTextBox.Focus();
            }
                   }
    }
}
