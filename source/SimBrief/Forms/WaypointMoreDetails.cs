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
        }

        private void WaypointMoreDetails_Load(object sender, EventArgs e)
        {
            waypointDetailsTextBox.SelectionStart = 0;
            // Dynamically get the properties from the Fix object.
            foreach (PropertyInfo property in this.waypoint.GetType().GetProperties())
            {
                waypointDetailsTextBox.Text += $"{utility.AddSpacesToMixedCaseStringAndLowercaseFirstChar(property.Name)}: {property.GetValue(this.waypoint, null)}\r\n";
            }

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void waypointDetailsTextBox_Enter(object sender, EventArgs e)
        {
            waypointDetailsTextBox.SelectionLength = 0;
        }
    }
}
