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
            if (Properties.NavlogColumns.Default.Type)
            {
                typeMenuItem.Checked = true;
                typeMenuItem.AccessibleName = "Hide type";
            }
            else
            {
                typeMenuItem.Checked = false;
                typeMenuItem.AccessibleName = "Show type";
            }
            distanceMenuItem.Checked = Properties.NavlogColumns.Default.Distance;
            altitudeMenuItem.Checked = Properties.NavlogColumns.Default.Altitude;
            nameMenuItem.Checked = Properties.NavlogColumns.Default.Name;
            LoadNavlogListView();
                    }

        private async void LoadNavlogListView()
        {
            navlogListView.BeginUpdate();
            navlogListView.Items.Clear();
            navlogListView.Columns.Clear();
                                       ColumnHeader identColumnHeader = new ColumnHeader("Ident");
            identColumnHeader.Text = "Ident";
                identColumnHeader.Width = -2;
                navlogListView.Columns.Add(identColumnHeader);
            if (Properties.NavlogColumns.Default.Type)
            {
                ColumnHeader typeColumnHeader = new ColumnHeader("Type");
                typeColumnHeader.Text = "Type";
                typeColumnHeader.Width = -2;
                navlogListView.Columns.Add(typeColumnHeader);
            }
            if (Properties.NavlogColumns.Default.Name)
            {
                ColumnHeader nameColumnHeader = new ColumnHeader("Name");
                nameColumnHeader.Text = "Name";
                nameColumnHeader.Width = -2;
                navlogListView.Columns.Add(nameColumnHeader);
            }
            if (Properties.NavlogColumns.Default.Distance)
            {
                ColumnHeader distanceColumnHeader = new ColumnHeader("Distance");
                distanceColumnHeader.Text = "Distance";
                distanceColumnHeader.Width = -2;
                navlogListView.Columns.Add(distanceColumnHeader);
            }
            if (Properties.NavlogColumns.Default.Altitude)
            {
                ColumnHeader altitudeColumnHeader = new ColumnHeader("Altitude");
                altitudeColumnHeader.Text = "Altitude";
                altitudeColumnHeader.Width = -2;
                navlogListView.Columns.Add(altitudeColumnHeader);
            }

            foreach (Fix entry in FlightPlan.Navlog)
            {
                var item = new ListViewItem(entry.Ident);
                if (Properties.NavlogColumns.Default.Type)
                {
                    item.SubItems.Add(entry.Type);
                }
                if (Properties.NavlogColumns.Default.Name)
                {
                    item.SubItems.Add(entry.Name);
                }
                if (Properties.NavlogColumns.Default.Distance)
                {
                    item.SubItems.Add(entry.Distance.ToString());
                }
                if (Properties.NavlogColumns.Default.Altitude)
                {
                    item.SubItems.Add(entry.AltitudeFeet.ToString());
                }
                navlogListView.Items.Add(item);
            }
            navlogListView.EndUpdate();

        }

        private void altitudeMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (altitudeMenuItem.Checked)
            {
                Properties.NavlogColumns.Default.Altitude = true;
                altitudeMenuItem.AccessibleName = "Hide altitude";
            }
            else
            {
                Properties.NavlogColumns.Default.Altitude = false;
                altitudeMenuItem.AccessibleName = "Show altitude";
            }
            Properties.NavlogColumns.Default.Save();
            LoadNavlogListView();
        }

        private void distanceMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (distanceMenuItem.Checked)
            {
                Properties.NavlogColumns.Default.Distance = true;
                distanceMenuItem.AccessibleName = "Hide distance";
            }
            else
            {
                Properties.NavlogColumns.Default.Distance = false;
                distanceMenuItem.AccessibleName = "Show distance";
            }
            Properties.NavlogColumns.Default.Save();
            LoadNavlogListView();
        }

        private void nameMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (nameMenuItem.Checked)
            {
                Properties.NavlogColumns.Default.Name = true;
                nameMenuItem.AccessibleName = "Hide name";
            }
            else
            {
                Properties.NavlogColumns.Default.Name = false;
                nameMenuItem.AccessibleName = "Show name";
            }
            Properties.NavlogColumns.Default.Save();
            LoadNavlogListView();
        }

        private void typeMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (typeMenuItem.Checked)
            {
                Properties.NavlogColumns.Default.Type = true;
                typeMenuItem.AccessibleName = "Hide type";
            }
            else
            {
                Properties.NavlogColumns.Default.Type = false;
                typeMenuItem.AccessibleName = "Show type";
            }
            Properties.NavlogColumns.Default.Save();
            LoadNavlogListView();
        }
    }
}
