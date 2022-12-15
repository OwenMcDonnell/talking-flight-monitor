using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.Settings_panels.PMDG737
{
    public partial class ctlLowerForward : UserControl, iSettingsPage
    {
        public ctlLowerForward()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlLowerForward_Load(object sender, EventArgs e)
        {

            leftMainPanelBrtCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_MainPanelKnob1");
            rightMainPanelBrtCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_MainPanelKnob2");
            mainPanelBrtBckGdCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_BackgroundKnob");
            afdsBrtCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_AFDSFloodKnob");
            flapsInhibitCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "GPWS_FlapInhibitSw_NORM");
            gearInhibitCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "GPWS_GearInhibitSw_NORM");
            terrainInhibitCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "GPWS_TerrInhibitSw_NORM");
            gpwsInopCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "GPWS_annunINOP");
            leftOutbdDuBrtCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_OutbdDUBrtKnob1");
            rightOutbdDuBrtCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_OutbdDUBrtKnob2");
            leftInbdDuBrtCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_InbdDUBrtKnob1");
            rightInbdDuBrtCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_InbdDUBrtKnob2");
            leftInbdMapBrtCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_InbdDUMapBrtKnob1");
            rightInbdMapBrtCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_InbdDUMapBrtKnob2");
            upperDuBrtCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_UpperDUBrtKnob");
            lowerDuBrtCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_LowerDUBrtKnob");
            lowerMapBrtCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "LTS_LowerDUMapBrtKnob");
        }
    }
}
