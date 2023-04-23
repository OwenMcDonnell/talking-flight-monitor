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
            textBox1.Text += $"atis: {FlightPlan.AlternateAirports[0].Atis.Count()}\r\n";
            textBox1.Text += $"notams: {FlightPlan.AlternateAirports[0].Notams.Count()}\r\n";
            foreach(PropertyInfo property in FlightPlan.AlternateAirports[0].GetType().GetProperties())
            {
                textBox1.Text += $"{property.Name}: {property.GetValue(FlightPlan.AlternateAirports[0], null)}\r\n";
                       }

                   }
    }
}
