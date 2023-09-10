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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;

namespace tfm.SimBrief.Forms
{
    public partial class WaypointMoreDetails : Form
    {

        private Fix waypoint;

        public WaypointMoreDetails(Fix waypoint)
        {
            InitializeComponent();

            this.waypoint = waypoint;
            this.Text = $"{waypoint.Name} - More details";
            waypointDetailsTextBox.AccessibleName = $"{waypoint.Name} details.";
            waypointDetailsTextBox.SelectionStart = waypointDetailsTextBox.TextLength - waypointDetailsTextBox.SelectionLength;
            
        }

        private void WaypointMoreDetails_Load(object sender, EventArgs e)
        {
            waypointDetailsTextBox.SelectionStart = 0;
            // Dynamically get the properties from the Fix object.
            foreach (PropertyInfo property in this.waypoint.GetType().GetProperties())
            {
                var propertyValue = property.GetValue(this.waypoint, null);
                // Skip properties already displayed in the navlog listview.
                if (property.Name == "Ident" || property.Name == "Type" || property.Name == "Name" || property.Name == "Distance" || property.Name == "AltitudeFeet" || property.Name == "WindData")
                {
                    continue;
                }
                // if property values are empty, skip the property.
                if(propertyValue == null || string.IsNullOrEmpty(propertyValue.ToString()))
                {
                    continue;
                }

                // round mach speed.
                if(property.Name == "MachSpeed" || property.Name == "MachThousanths")
                {
                    propertyValue =(float)Math.Round((double)propertyValue, 2);
                }
                waypointDetailsTextBox.Text += $"{App.AddSpacesToMixedCaseStringAndLowercaseFirstChar(property.Name)}: {propertyValue}\r\n";
            }

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void waypointDetailsTextBox_Enter(object sender, EventArgs e)
        {
            
        }
    }
}
