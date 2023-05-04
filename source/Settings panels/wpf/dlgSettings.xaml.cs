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
        public dlgSettings()
        {
            InitializeComponent();
            // Initialize the user controls and add them to the dictionary
            pageMappings["General"] = new ctlGeneral();
                        pageMappings["Output"] = new ctlOutput();
            pageMappings["Aircraft"] = new tfm.Settings_panels.wpf.ctlAircraft();

            /* pageMappings["Timing"] = new TimingPage();
            pageMappings["AirportsDatabase"] = new AirportsDatabasePage();

            pageMappings["UserInterface"] = new UserInterfacePage();
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
            tvCategories.Focus();
        }
    }
}
