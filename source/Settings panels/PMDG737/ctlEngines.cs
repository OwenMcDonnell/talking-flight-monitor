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
    public partial class ctlEngines : UserControl, iSettingsPage
    {
        public ctlEngines()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlEngines_Load(object sender, EventArgs e)
        {
            apuSelectorCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "APU_Selector");
            engine1SelectorCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "ENG_StartSelector1");
            engine2Selectorh.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "ENG_StartSelector2");
            ignitionSelectorCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "ENG_IgnitionSelector");
        }
    }
}
