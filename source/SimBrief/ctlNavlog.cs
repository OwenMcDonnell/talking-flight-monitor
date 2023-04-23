using DavyKager;
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
            Tolk.Load();
                        LoadNavlogListView();
            SetMenuState();
                               }

        private async void LoadNavlogListView()
        {
            var navlogColumns = Properties.NavlogColumns.Default;

            #region "Context menu"
            typeMenuItem.Checked = navlogColumns.Type ? true : false;
            typeMenuItem.AccessibleName = navlogColumns.Type ? "Hide type" : "Show type";
            nameMenuItem.Checked = navlogColumns.Name ? true : false;
            nameMenuItem.AccessibleName = navlogColumns.Name ? "Hide name" : "Show name";
            distanceMenuItem.Checked = navlogColumns.Distance ? true : false;
            distanceMenuItem.AccessibleName = navlogColumns.Distance ? "Hide distance" : "Show distance";
            altitudeMenuItem.Checked = navlogColumns.Altitude ? true : false;
            altitudeMenuItem.AccessibleName = navlogColumns.Altitude ? "Hide altitude" : "Show altitude";
            #endregion
            
            navlogListView.Items.Clear();
            navlogListView.Columns.Clear();
                                                                                   
            // Ident is a required column.
            navlogListView.Columns.Add(CreateColumnHeader("Ident", -2));
            
            // Optional columns.
            _ = navlogColumns.Type ? navlogListView.Columns.Add(CreateColumnHeader("Type", -2)) : default;
            _ = navlogColumns.Name ? navlogListView.Columns.Add(CreateColumnHeader("Name", -2)) : default;
            _ = navlogColumns.Distance ? navlogListView.Columns.Add(CreateColumnHeader("Distance", -2)) : default;
            _ = navlogColumns.Altitude ? navlogListView.Columns.Add(CreateColumnHeader("Altitude", -2)) : default;
            navlogListView.BeginUpdate();
            foreach (Fix entry in FlightPlan.Navlog)
            {
                var item = new ListViewItem(entry.Ident);
                _ = navlogColumns.Type ? item.SubItems.Add(entry.Type) : default;
                _ = navlogColumns.Name ? item.SubItems.Add(entry.Name) : default;
                _ = navlogColumns.Distance ? item.SubItems.Add(entry.Distance.ToString()) : default;
                _ = navlogColumns.Altitude ? item.SubItems.Add(entry.AltitudeFeet.ToString()) : default;
                item.Tag = (object)entry;
                navlogListView.Items.Add(item);
            }
            navlogListView.EndUpdate();
                                                                    }

        private ColumnHeader CreateColumnHeader(string text, int width)
        {
            return new ColumnHeader()
            {
                Text = text,
                Width = width,
            };
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

        private void navlogListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetMenuState();
                    }

        private void SetMenuState()
        {
            if (navlogListView.SelectedItems.Count > 0)
            {
                moreDetailsMenuItem.Enabled = true;
                windDataMenuItem.Enabled = true;
            }
            else
            {
                windDataMenuItem.Enabled = false;
                moreDetailsMenuItem.Enabled = false;
            }

        }

        private void moreDetailsMenuItem_Click(object sender, EventArgs e)
        {
            if (navlogListView.SelectedItems.Count > 0)
            {
                var selectedWaypoint = (Fix)navlogListView.SelectedItems[0].Tag;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is SimBrief.Forms.WaypointMoreDetails)
                    {
                        Tolk.Output("The more details window is already open. Close it before selecting another waypoint.");
                    }
                    else
                    {
                        var md = new SimBrief.Forms.WaypointMoreDetails(selectedWaypoint);
                        md.ShowDialog();
                        break;
                    }
                }
            }
            else
            {
                Tolk.Output("Choose a waypoint first.");
           }
            }
        }
    }
