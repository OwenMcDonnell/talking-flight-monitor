using tfm.Properties;
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

using UserControl = System.Windows.Controls.UserControl;

namespace tfm.PMDG.PMDG_737.CockpitPanels
{
        public partial class CockpitPanelsDialog : Window
    {

        private readonly Dictionary<string, UserControlInfo> panelMappings = new Dictionary<string, UserControlInfo>();
        private readonly List<TreeViewItem> originalTreeViewItems;

        public CockpitPanelsDialog()
        {
            InitializeComponent();
            App.UI.SelectFirstTreeViewItem(panelsTreeView);
            LoadPanels();
            originalTreeViewItems = App.UI.GetOriginalTreeViewItems(panelsTreeView);
            App.UI.LoadTreeViewStateFromDisk(panelsTreeView);
            panelsTreeView.Focus();
                                                        }

        private void LoadPanels()
        {

            panelMappings["adiru"] = new UserControlInfo { control = new adiru(), Keywords = new[] { "gps", "reference", "unit", "navigation" } };
            panelMappings["domeLights"] = new UserControlInfo { control = new DomeLights(), Keywords = new[] { "dome", "lights", "interior" } };
            panelMappings["eec"] = new UserControlInfo { control = new EEC(), Keywords = new[] { "electrical", "engines", "power", "navigation" } };
        }
              
                private void panelsTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

            contentArea.Content = null;
            var selectedItem = e.NewValue as TreeViewItem;
            if (selectedItem != null)
            {
                if (panelMappings.TryGetValue(selectedItem.Name, out UserControlInfo info))
                {
                    contentArea.Content = info.control;
                }
            }
        }

        private void searchTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                App.UI.SearchTreeView(searchTextBox.Text, panelsTreeView, originalTreeViewItems, panelMappings);
                            }
        }

        private void clearSearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void panelsTreeView_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && e.Key == Key.Up)
            {
                App.UI.MoveTreeViewItemUp(panelsTreeView, panelsTreeView.SelectedItem as TreeViewItem);
            }

        }
    }
}
