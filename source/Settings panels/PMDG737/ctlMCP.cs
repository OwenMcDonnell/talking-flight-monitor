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
    public partial class ctlMCP : UserControl, iSettingsPage
    {
        public ctlMCP()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
                    }

        private void ctlMCP_Load(object sender, EventArgs e)
        {
            speedInterveneCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_IASBlank");
            mcpOverspeedLightCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_IASOverspeedFlash");
            underSpeedCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_IASUnderspeedFlash");
            autoThrottleCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_ATArmSw");
            autothrottleArmedCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_annunATArm");
            n1LightCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_annunN1");
            speedLightCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_annunSPEED");
            hdgSelLightCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_annunHDG_SEL");
            lNavLightCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_annunLNAV");
            vsModeCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_VertSpeedBlank");
            vsLightCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_annunVS");
            vNavLightCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_annunVNAV");
            lvlChangeCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_annunLVL_CHG");
            altitudeHoldLightCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_annunALT_HOLD");
            fd1CheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_FDSw1");
            fd2CheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_FDSw2");
            bankLimitCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_BankLimitSel");
            disengageBarCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_DisengageBar");
            fd1LightCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_annunFD1");
            fd2LightCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_annunFD2");
            appLightCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_annunAPP");
            vorLocLightCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_annunVOR_LOC");
            cmdaLightCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_annunCMD_A");
            cwsaLightCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_annunCWS_A");
            cmdbLightCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_annunCMD_B");
            cwsbLightCheckBox.DataBindings.Add("Checked", Properties.pmdg737_offsets.Default, "MCP_annunCWS_B");
        }
    }
}
