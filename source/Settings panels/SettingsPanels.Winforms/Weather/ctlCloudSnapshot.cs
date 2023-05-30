using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.Settings_panels.Weather
{
    public partial class ctlCloudSnapshot : UserControl, iSettingsPage
    {
        public ctlCloudSnapshot()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void ctlCloudSnapshot_Load(object sender, EventArgs e)
        {
            inCloudCheckBox.DataBindings.Add("Checked", Properties.Weather.Default, "CloudLayer_InCloud");
            cloudTypeCheckBox.DataBindings.Add("Checked", Properties.Weather.Default, "CloudLayer_CloudType");
            cloudCoverageCheckBox.DataBindings.Add("Checked", Properties.Weather.Default, "CloudLayer_CloudCoverage");
            icingCheckBox.DataBindings.Add("Checked", Properties.Weather.Default, "CloudLayer_Icing");
            precipitationRateCheckBox.DataBindings.Add("Checked", Properties.Weather.Default, "CloudLayer_PrecipitationRate");
            precipitationTypeCheckBox.DataBindings.Add("Checked", Properties.Weather.Default, "CloudLayer_PrecipitationType");
            turbulenceCheckBox.DataBindings.Add("Checked", Properties.Weather.Default, "CloudLayer_Turbulence");
            distanceToTopCheckBox.DataBindings.Add("Checked", Properties.Weather.Default, "CloudLayer_DistanceToTop");
            distanceToBottomCheckBox.DataBindings.Add("Checked", Properties.Weather.Default, "CloudLayer_DistanceToBottom");
            notInCloudCheckBox.DataBindings.Add("Checked", Properties.Weather.Default, "CloudLayer_OutOfCloud");
            distanceToCloudAboveCheckBox.DataBindings.Add("Checked", Properties.Weather.Default, "CloudLayer_DistanceToCloudAbove");
            noCloudAboveCheckBox.DataBindings.Add("Checked", Properties.Weather.Default, "CloudLayer_NoCloudsAbove");
            distanceToCloudBelowCheckBox.DataBindings.Add("Checked", Properties.Weather.Default, "CloudLayer_DistanceToCloudBelow");
            noCloudsBelowCheckBox.DataBindings.Add("Checked", Properties.Weather.Default, "CloudLayer_NoCloudsBelow");
        }
    }
}
