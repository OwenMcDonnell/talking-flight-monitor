using tfm.Flight_planning.SimBrief;
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
    public partial class ctlNavlog : UserControl, iPanelsPage
    {
        public ctlNavlog()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private async  void ctlNavlog_Load(object sender, EventArgs e)
        {
            navlogListView.BeginUpdate();
            foreach(Fix entry in FlightPlan.Navlog)
            {
                var item = new ListViewItem(entry.Ident);
                item.SubItems.Add(entry.Type);
                item.SubItems.Add(entry.Name);
                item.SubItems.Add(entry.Distance.ToString());
                item.SubItems.Add(entry.AltitudeFeet.ToString());
                navlogListView.Items.Add(item);
            }
            navlogListView.EndUpdate();

        }
    }
}
