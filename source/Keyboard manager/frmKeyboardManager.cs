using NGeoNames.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.Keyboard_manager
{
    public partial class frmKeyboardManager : Form
    {
        KeysConverter kc = new KeysConverter();
        ResourceManager rm = new ResourceManager(typeof(KeyNames));
        
        ListView.SelectedListViewItemCollection selectedKey;
        private bool apTabSelected;
        private bool generalTabSelected;
        IOSubsystem IO = new IOSubsystem(AdditionalInstance: true);


        public frmKeyboardManager()
        {
            InitializeComponent();
            

        }

        void lvKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mods;
            string key;
            selectedKey = this.lvKeys.SelectedItems;
            apTabSelected = false;
            generalTabSelected = true;
            btnModify.Enabled = true;
        }
        void lvAutopilotKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mods;
            string key;
            selectedKey = this.lvAutopilotKeys.SelectedItems;
            apTabSelected = true;
            generalTabSelected = false;
            btnModify.Enabled = true;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            string name = null;
            string key = null;
            foreach (ListViewItem item in selectedKey)
            {
                name = item.SubItems[0].Text.Replace(" ", "_");
                key = item.SubItems[1].Text;

            }
            string tab = tcKeys.SelectedTab.Name;
            frmModifyKey frm = new frmModifyKey(name: name, tab: tab);
            frm.ShowDialog();
            
        }

        private void btnDefaults_Click(object sender, EventArgs e)
        {
            Properties.Hotkeys.Default.Reset();
            Properties.Hotkeys.Default.Reload();
            lvKeys.Items.Clear();
            lvAutopilotKeys.Items.Clear();
            updateListViews();

        }

        private void tabGeneral_Click(object sender, EventArgs e)
        {
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tcKeys_Selected(object sender, TabControlEventArgs e)
        {
        }

        private void frmKeyboardManager_Load(object sender, EventArgs e)
        {
            updateListViews();
        }

        private void updateListViews()
        {
            string keyName = null;

            lvKeys.BeginUpdate();
            foreach (SettingsProperty s in Properties.Hotkeys.Default.Properties)
            {
                keyName = s.Name.Replace("_", " ");
                if (s.Name.StartsWith("ap_")) continue;
                // split key string to extract the modifier
                string[] key = kc.ConvertToString(s.DefaultValue).Split('+');

                if (key.Count() == 1)
                {
                    lvKeys.Items.Add(keyName).SubItems.Add(rm.GetString(key[0]));
                }
                if (key.Count() == 2)
                {
                    lvKeys.Items.Add(keyName).SubItems.Add(key[0] + "+" + rm.GetString(key[1]));
                }

            }
            lvKeys.EndUpdate();
            lvAutopilotKeys.BeginUpdate();
            foreach (SettingsProperty s in Properties.Hotkeys.Default.Properties)
            {
                keyName = s.Name.Replace("_", " ");
                if (s.Name.StartsWith("ap_"))
                {
                    // split key string to extract the modifier
                    string[] key = kc.ConvertToString(s.DefaultValue).Split('+');

                    if (key.Count() == 1)
                    {
                        lvAutopilotKeys.Items.Add(keyName).SubItems.Add(rm.GetString(key[0]));
                    }
                    if (key.Count() == 2)
                    {
                        lvAutopilotKeys.Items.Add(keyName).SubItems.Add(key[0] + "+" + rm.GetString(key[1]));
                    }

                }
            }
            lvAutopilotKeys.EndUpdate();

        }

        private void updateListViewsAfterModify ()
        {
            string keyName;
            lvKeys.Items.Clear();
            lvKeys.BeginUpdate();
            foreach (SettingsPropertyValue s in Properties.Hotkeys.Default.PropertyValues)
            {
                keyName = s.Name.Replace("_", " ");
                if (s.Name.StartsWith("ap_")) continue;
                // split key string to extract the modifier
                string[] key = kc.ConvertToString(s.PropertyValue).Split('+');

                if (key.Count() == 1)
                {
                    lvKeys.Items.Add(keyName).SubItems.Add(rm.GetString(key[0]));
                }
                if (key.Count() == 2)
                {
                    lvKeys.Items.Add(keyName).SubItems.Add(key[0] + "+" + rm.GetString(key[1]));
                }

            }
            lvKeys.EndUpdate();
            lvAutopilotKeys.BeginUpdate();
            foreach (SettingsPropertyValue s in Properties.Hotkeys.Default.PropertyValues)
            {
                keyName = s.Name.Replace("_", " ");
                if (s.Name.StartsWith("ap_"))
                {
                    // split key string to extract the modifier
                    string[] key = kc.ConvertToString(s.PropertyValue).Split('+');

                    if (key.Count() == 1)
                    {
                        lvAutopilotKeys.Items.Add(keyName).SubItems.Add(rm.GetString(key[0]));
                    }
                    if (key.Count() == 2)
                    {
                        lvAutopilotKeys.Items.Add(keyName).SubItems.Add(key[0] + "+" + rm.GetString(key[1]));
                    }

                }
            }
            lvAutopilotKeys.EndUpdate();


        }





        private void btnExecute_Click(object sender, EventArgs e)
        {
            string name = selectedKey[0].Text.Replace(" ", "_");
            IO.ExecuteCommand(name);

            
        }
    }

}

