using System;
using System.Reflection;
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
    public partial class ctlAirports : UserControl, iPanelsPage
    {
        public ctlAirports()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void ctlAirports_Load(object sender, EventArgs e)
        {
            //textBox1.Text += $"atis: {FlightPlan.SimbriefDestination.Atis.Count()}\r\n";
            //textBox1.Text += $"notams: {FlightPlan.SimbriefDestination.Notams.Count()}\r\n";
            foreach(PropertyInfo property in FlightPlan.Weights.GetType().GetProperties())
            {
                textBox1.Text += $"{property.Name}: {property.GetValue(FlightPlan.Weights, null)}\r\n";
                       }

                   }
    }
}
