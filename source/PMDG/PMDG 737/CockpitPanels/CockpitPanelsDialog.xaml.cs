using DavyKager;
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
            Tolk.Load();
            LoadPanels();
            originalTreeViewItems = App.UI.GetOriginalTreeViewItems(panelsTreeView);
            App.UI.LoadTreeViewStateFromDisk(panelsTreeView);            panelsTreeView.Focus();
            App.UI.SelectFirstTreeViewItem(panelsTreeView);
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
            // Move the item up.
            #region "Move up"
            if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && e.Key == Key.Up)
            {
                var selectedItem = panelsTreeView.SelectedItem as TreeViewItem;

                if(selectedItem != null)
                {
                    var isMoved = App.UI.MoveTreeViewItemUp(panelsTreeView, selectedItem);
// Moved the item successfully.
                    if (isMoved)
                    {
                        Tolk.Output($"{selectedItem.Header} moved up.");
                    }
                    else
                    {
                        Tolk.Output($"Could not move {selectedItem.Header}.");
                    }
                }
            }
            #endregion

            // Move the item down.
            #region "Move down"
            if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && e.Key == Key.Down)
            {
                var selectedItem = panelsTreeView.SelectedItem as TreeViewItem;

                if (selectedItem != null)
                {
                    var isMoved = App.UI.MoveTreeViewItemDown(panelsTreeView, selectedItem);
                    // Moved the item successfully.
                    if (isMoved)
                    {
                        Tolk.Output($"{selectedItem.Header} moved down.");
                    }
                    else
                    {
                        Tolk.Output($"Could not move {selectedItem.Header}.");
                    }
                }
            }

            #endregion
        }
    }
}
