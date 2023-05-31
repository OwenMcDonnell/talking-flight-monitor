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
using tfm.Properties;
using tfm.Settings_panels.Weather;
using tfm.Settings_panels.wpf;
using tfm.Settings_panels.wpf.pmdg737;
using tfm.Settings_panels.wpf.weather;
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
        private readonly Dictionary<string, UserControlInfo> pageMappings = new Dictionary<string, UserControlInfo>();
        private readonly List<TreeViewItem> originalTreeViewItems;
        public dlgSettings()
        {
            InitializeComponent();
            LoadPanels();
            originalTreeViewItems = App.UI.GetOriginalTreeViewItems(tvCategories);
            App.UI.LoadTreeViewStateFromDisk(tvCategories); 
            tvCategories.Focus();
            App.UI.SelectFirstTreeViewItem(tvCategories);

        }

        private void LoadPanels()
        {
            // Initialize the user controls and add them to the dictionary
            pageMappings["General"] = new UserControlInfo
            {
                control = new ctlGeneral(),
                Keywords = new[] { "general", "geonames", "bing", "api", "database" }
            };
            pageMappings["Output"] = new UserControlInfo
            {
                control = new ctlOutput(),
                Keywords = new[] { "speech", "sapi", "rate", "attitude", "pitch", "bank", "history" }
            };
            pageMappings["Sound"] = new UserControlInfo
            {
                control = new ctlSound(),
                Keywords = new[] { "sound", "startup", "shutdown" }
            };
            pageMappings["Aircraft"] = new UserControlInfo
            {
                control = new ctlAircraft(),
                Keywords = new[] { "aircraft", "altitude", "instruments", "heading", "ground", "simconnect", "mute", "flight", "following", "follow" }
            };
            pageMappings["Timing"] = new UserControlInfo
            {
                control = new ctlTiming(),
                Keywords = new[] { "interval", "timing", "flight", "following", "ils" }
            };
            pageMappings["Simbrief"] = new UserControlInfo
            {
                control = new ctlSimbrief(),
                Keywords = new[] { "simbrief", "user", "pilot", "id" }
            };
            pageMappings["AirportsDatabase"] = new UserControlInfo
            {
                control = new ctlAirportsDatabase(),
                Keywords = new[] { "airport", "database", "runways" }
            };
            pageMappings["UserInterface"] = new UserControlInfo
            {
                control = new ctlUserInterface(),
                Keywords = new[] { "font", "size", "ui", "user", "interface" }
            };
            pageMappings["Weather"] = new UserControlInfo
            {
                control = new ctlWeather(),
                Keywords = new[] { "weather", "refresh" }
            };
            pageMappings["AutomaticAnnouncements"] = new UserControlInfo
            {
                control = new ctlAutomaticAnnouncements(),
                Keywords = new[] { "weather", "automatic", "announcement", "sapi" }
            };
            pageMappings["WindCommand"] = new UserControlInfo
            {
                control = new ctlWindSnapshot(),
                Keywords = new[] { "weather", "wind", "direction", "gust", "turbulence", "sheer" }
            };
            pageMappings["CloudsCommand"] = new UserControlInfo
            {
                control = new ctlCloudSnapshot(),
                Keywords = new[] { "weather", "clouds", "turbulence" }
            };
            pageMappings["ADIRU737"] = new UserControlInfo
            {
                control = new ctlPMDG737Verbosity
                {
                    DataContext = new ctlPMDG737VerbosityViewModel(PanelName: "Aft Overhead", PanelSection: "ADIRU")
                },
                Keywords = new[] { "gps", "reference", "unit", "navigation" }
            };
            pageMappings["PSEU737"] = new UserControlInfo
            {
                control = new ctlPMDG737Verbosity
                {
                    DataContext = new ctlPMDG737VerbosityViewModel(PanelName: "Aft Overhead", PanelSection: "PSEU")
                },
                Keywords = new[] { "psu", "service", "passenger" }
            };
            pageMappings["ServiceInterphone737"] = new UserControlInfo
            {
                control = new ctlPMDG737Verbosity
                {
                    DataContext = new ctlPMDG737VerbosityViewModel(PanelName: "Aft Overhead", PanelSection: "Service interphone")
                },
                Keywords = new[] { "service", "interphone", "overhead" }
            };

            pageMappings["DomeLights737"] = new UserControlInfo
            {
                control = new ctlPMDG737Verbosity
                {
                    DataContext = new ctlPMDG737VerbosityViewModel(PanelName: "Aft Overhead", PanelSection: "Lights")
                },
                Keywords = new[] { "lights", "dome", "overhead" }
            };
            pageMappings["Engines737"] = new UserControlInfo
            {
                control = new ctlPMDG737Verbosity
                {
                    DataContext = new ctlPMDG737VerbosityViewModel(PanelName: "Aft Overhead", PanelSection: "Engines")
                },
                Keywords = new[] { "engines", "eec", "overhead" }
            };
            pageMappings["Oxygen737"] = new UserControlInfo
            {
                control = new ctlPMDG737Verbosity
                {
                    DataContext = new ctlPMDG737VerbosityViewModel(PanelName: "Aft Overhead", PanelSection: "Oxygen")
                },
                Keywords = new[] { "engines", "oxygen", "overhead" }
            };
            pageMappings["Gear737"] = new UserControlInfo
            {
                control = new ctlPMDG737Verbosity
                {
                    DataContext = new ctlPMDG737VerbosityViewModel(PanelName: "Aft Overhead", PanelSection: "Gear")
                },
                Keywords = new[] { "overhead", "gear", "landing" }
            };
            pageMappings["FlightRecorder737"] = new UserControlInfo
            {
                control = new ctlPMDG737Verbosity
                {
                    DataContext = new ctlPMDG737VerbosityViewModel(PanelName: "Aft Overhead", PanelSection: "Flight recorder")
                },
                Keywords = new[] { "overhead", "recorder", "test" }
            };
            pageMappings["FlightControls737"] = new UserControlInfo
            {
                control = new ctlPMDG737Verbosity
                {
                    DataContext = new ctlPMDG737VerbosityViewModel(PanelName: "Forward Overhead", PanelSection: "Flight controls")
                },
                Keywords = new[] { "controls", "flaps", "gear", "alternate" }
            };
            //pageMappings["NavigationDisplays"] = new UserControlInfo { control = new NavigationDisplaysPage();
            //pageMappings["Fuel737"] = new UserControlInfo { control = new Fuel737Page();
            //pageMappings["Electrical737"] = new UserControlInfo { control = new Electrical737Page();
            //pageMappings["APU"] = new UserControlInfo { control = new APUPage();
            //pageMappings["Wipers"] = new UserControlInfo { control = new WipersPage();
            //pageMappings["AntiIce"] = new UserControlInfo { control = new AntiIcePage();
            //pageMappings["Hydraulics737"] = new UserControlInfo { control = new Hydraulics737Page();
            //pageMappings["AirSystems"] = new UserControlInfo { control = new AirSystemsPage();
            //pageMappings["Engines"] = new UserControlInfo { control = new EnginesPage();
            //pageMappings["Lights"] = new UserControlInfo { control = new LightsPage();
            //pageMappings["AFS"] = new UserControlInfo { control = new AFSPage();
            //pageMappings["Warnings"] = new UserControlInfo { control = new WarningsPage();
            //pageMappings["MCP"] = new UserControlInfo { control = new MCPPage();
            //pageMappings["Forward"] = new UserControlInfo { control = new ForwardPage();
            //pageMappings["DU"] = new UserControlInfo { control = new DUPage();
            //pageMappings["Standby"] = new UserControlInfo { control = new StandbyPage();
            //pageMappings["Speed"] = new UserControlInfo { control = new SpeedPage();
            //pageMappings["Brakes"] = new UserControlInfo { control = new BrakesPage();
            //pageMappings["Flaps"] = new UserControlInfo { control = new FlapsPage();
            //pageMappings["Gear737_2"] = new UserControlInfo { control = new Gear737_2Page();
            //pageMappings["LowerForward"] = new UserControlInfo { control = new LowerForwardPage();
            //pageMappings["CDU"] = new UserControlInfo { control = new CDUPage();
            //pageMappings["Trim"] = new UserControlInfo { control = new TrimPage();
            //pageMappings["Pedestal"] = new UserControlInfo { control = new PedestalPage();
            //pageMappings["FireProtection"] = new UserControlInfo { control = new FireProtectionPage();
            //pageMappings["CargoFireProtection"] = new UserControlInfo { control = new CargoFireProtectionPage();
            //pageMappings["Transponder"] = new UserControlInfo { control = new TransponderPage();
            //pageMappings["Electrical747"] = new UserControlInfo { control = new Electrical747Page();
            //pageMappings["Fuel747"] = new UserControlInfo { control = new Fuel747Page();
            //pageMappings["Hydraulics747"] = new UserControlInfo { control = new Hydraulics747Page();
            //// Add more user controls to the dictionary as needed

        }
        private void Options_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            // clear the content area
            contentArea.Content = null;

            var selectedItem = e.NewValue as TreeViewItem;

            // Check if the selected item's name is in the dictionary
            if (selectedItem != null)
            {
                if (pageMappings.TryGetValue(selectedItem.Name, out UserControlInfo info))
                {
                    contentArea.Content = info.control;
                }
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

        private void searchTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                App.UI.SearchTreeView(searchTextBox.Text, tvCategories, originalTreeViewItems, pageMappings);
            }

        }
    }
}
