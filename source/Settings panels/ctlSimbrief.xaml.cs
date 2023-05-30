using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using MessageBox = System.Windows.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

namespace tfm.Settings_panels.wpf
{
    /// <summary>
    /// Interaction logic for ctlSimbrief.xaml
    /// </summary>
    public partial class ctlSimbrief : UserControl
    {
        public ctlSimbrief()
        {
            InitializeComponent();
        }

        private void btnValidate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();
                var rawXml = client.GetStringAsync($"https://www.simbrief.com/api/xml.fetcher.php?userid={txtSimbrief.Text}");
                var fp = XDocument.Parse(rawXml.Result);
                MessageBox.Show("SimBrief user ID validated!");
                Properties.Settings.Default.IsSimBriefUserIDValid = true;
            }
            catch (Exception ex)
            {
                txtSimbrief.Text = "Enter valid user ID";
                txtSimbrief.Focus();
            }

        }
    }
}
