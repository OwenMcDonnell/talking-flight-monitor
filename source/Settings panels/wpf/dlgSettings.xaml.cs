using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using tfm.Settings_panels.wpf;
using TreeView = System.Windows.Controls.TreeView;
using UserControl = System.Windows.Controls.UserControl;

namespace tfm.Settings_panels
{
    /// <summary>
    /// Interaction logic for dlgSettings.xaml
    /// </summary>
    public partial class dlgSettings : Window
    {
        // Add a new UserControl for each settings panel
        private readonly Dictionary<string, UserControl> pageMappings = new Dictionary<string, UserControl>();
        private bool searchdeep = true;             // Searches in subitems
        private bool searchstartfound = false;      // true when current selected item is found. Ensures that you don't seach backwards and that you only search on the current level (if not searchdeep is true)
        private string searchterm = "";             // what to search for
        private DateTime LastSearch = DateTime.Now; // resets searchterm if last input is older than 1 second.
        public dlgSettings()
        {
            // Initialize the user controls and add them to the dictionary
            pageMappings["General"] = new ctlGeneral();
                        pageMappings["Output"] = new ctlOutput();
            pageMappings["Aircraft"] = new tfm.Settings_panels.wpf.ctlAircraft();

            pageMappings["Timing"] = new ctlTiming();
            pageMappings["AirportsDatabase"] = new tfm.Settings_panels.wpf.ctlAirportsDatabase();

            /* pageMappings["UserInterface"] = new UserInterfacePage();
            pageMappings["AutomaticAnnouncements"] = new AutomaticAnnouncementsPage();
            pageMappings["WindCommand"] = new WindCommandPage();
            pageMappings["CloudsCommand"] = new CloudsCommandPage();
            pageMappings["ADIRU"] = new ADIRUPage();
            pageMappings["PSEU"] = new PSEUPage();
            pageMappings["ServiceInterphone"] = new ServiceInterphonePage();
            pageMappings["DomeLights"] = new DomeLightsPage();
            pageMappings["EEC"] = new EECPage();
            pageMappings["Oxygen"] = new OxygenPage();
            pageMappings["Gear737"] = new Gear737Page();
            pageMappings["FlightRecorder"] = new FlightRecorderPage();
            pageMappings["FlightControls"] = new FlightControlsPage();
            pageMappings["NavigationDisplays"] = new NavigationDisplaysPage();
            pageMappings["Fuel737"] = new Fuel737Page();
            pageMappings["Electrical737"] = new Electrical737Page();
            pageMappings["APU"] = new APUPage();
            pageMappings["Wipers"] = new WipersPage();
            pageMappings["AntiIce"] = new AntiIcePage();
            pageMappings["Hydraulics737"] = new Hydraulics737Page();
            pageMappings["AirSystems"] = new AirSystemsPage();
            pageMappings["Engines"] = new EnginesPage();
            pageMappings["Lights"] = new LightsPage();
            pageMappings["AFS"] = new AFSPage();
            pageMappings["Warnings"] = new WarningsPage();
            pageMappings["MCP"] = new MCPPage();
            pageMappings["Forward"] = new ForwardPage();
            pageMappings["DU"] = new DUPage();
            pageMappings["Standby"] = new StandbyPage();
            pageMappings["Speed"] = new SpeedPage();
            pageMappings["Brakes"] = new BrakesPage();
            pageMappings["Flaps"] = new FlapsPage();
            pageMappings["Gear737_2"] = new Gear737_2Page();
            pageMappings["LowerForward"] = new LowerForwardPage();
            pageMappings["CDU"] = new CDUPage();
            pageMappings["Trim"] = new TrimPage();
            pageMappings["Pedestal"] = new PedestalPage();
            pageMappings["FireProtection"] = new FireProtectionPage();
            pageMappings["CargoFireProtection"] = new CargoFireProtectionPage();
            pageMappings["Transponder"] = new TransponderPage();
            pageMappings["Electrical747"] = new Electrical747Page();
            pageMappings["Fuel747"] = new Fuel747Page();
            pageMappings["Hydraulics747"] = new Hydraulics747Page();
*/            // Add more user controls to the dictionary as needed
            InitializeComponent();
            tvCategories.Focus();

        }

        private void Options_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            // clear the content area
            contentArea.Content = null;

            TreeViewItem selectedItem = (TreeViewItem)e.NewValue;

            // Check if the selected item's name is in the dictionary
            if (pageMappings.TryGetValue(selectedItem.Name, out UserControl userControl))
            {
                contentArea.Content = userControl;
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Properties.Settings.Default.Save();
        }

        private void tvCategories_Loaded(object sender, RoutedEventArgs e)
        {
            TreeViewItem firstItem = tvCategories.Items[0] as TreeViewItem;
            if (firstItem != null)
            {
                firstItem.IsSelected = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void tvCategories_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // reset searchterm if any "special" key is pressed
            if (e.Key < Key.A)
                searchterm = "";

        }
        private void tvCategories_TextInput(object sender, TextCompositionEventArgs e)
        {
          TreeView treeView = sender as TreeView;
            if (treeView == null || string.IsNullOrEmpty(e.Text)) return;

            char firstChar = Char.ToUpperInvariant(e.Text[0]);
            SelectItemByFirstCharacter(treeView, firstChar);
            e.Handled = true;
        }

        private void SelectItemByFirstCharacter(ItemsControl itemsControl, char firstChar)
        {
            if (itemsControl == null) return;

            for (int i = 0; i < itemsControl.Items.Count; i++)
            {
                object item = itemsControl.Items[i];
                TreeViewItem treeViewItem = itemsControl.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;

                if (treeViewItem == null) continue;

                string headerText = treeViewItem.Header.ToString().ToUpperInvariant();

                if (headerText.Length > 0 && headerText[0] == firstChar)
                {
                    treeViewItem.IsSelected = true;
                    treeViewItem.Focus();
                    break;
                }
                else
                {
                    SelectItemByFirstCharacter(treeViewItem, firstChar);
                }
            }
        }



        private bool SearchTreeView(TreeViewItem node, string searchterm)
        {
            if (node.IsSelected)
                searchstartfound = true; 

            // Search current level first
            foreach (TreeViewItem subnode in node.Items)
            {
                // Search subnodes to the current node first
                if (subnode.IsSelected)
                {
                    searchstartfound = true;
                    if (subnode.IsExpanded)
                        foreach (TreeViewItem subsubnode in subnode.Items)
                            if (searchstartfound && subsubnode.Header.ToString().ToLower().StartsWith(searchterm))
                            {
                                subsubnode.IsSelected = true;
                                subsubnode.IsExpanded = true;
                                subsubnode.BringIntoView();
                                return true;
                            }
                }
                // Then search nodes on the same level
                if (searchstartfound && subnode.Header.ToString().ToLower().StartsWith(searchterm))
                {
                    subnode.IsSelected = true;
                    subnode.BringIntoView();
                    return true;
                }
            }

            // If not found, search subnodes
            foreach (TreeViewItem subnode in node.Items)
            {
                if (!searchstartfound || searchdeep)
                    if (SearchTreeView(subnode, searchterm))
                    {
                        node.IsExpanded = true;
                        return true;
                    }
            }

            return false;
        }
    }
}
