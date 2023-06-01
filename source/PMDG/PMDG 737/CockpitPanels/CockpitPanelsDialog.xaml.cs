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
using tfm.PMDG.PMDG_737.Forms;

namespace tfm.PMDG.PMDG_737.CockpitPanels
{
        public partial class CockpitPanelsDialog : Window
    {
        private bool isSearchResultsDisplayed = false; // flag for determining if search results are displayed in the panels tree.
        private string fileName = "737CockpitPanels.json"; // Filename used to save and load the panel state.
        TreeViewSerializer treeHelper = new TreeViewSerializer(); // Helper class to manage the panels tree state.
        private readonly Dictionary<string, UserControlInfo> panelMappings = new Dictionary<string, UserControlInfo>(); // Dictionary used to map panels to their content.
        private readonly List<TreeViewItem> originalTreeViewItems; // Factory default panel tree layout. Used to reset it when needed.

        // Key commands
        #region "Key commands"
        public static readonly RoutedUICommand focusSearchBox = new RoutedUICommand("Focus search box", "Focus the search box", typeof(CockpitPanelsDialog), new InputGestureCollection { new KeyGesture(Key.F2, ModifierKeys.None) });
        public static readonly RoutedUICommand focusPanelsTreeView = new RoutedUICommand("Focus panels tree", "Focus the panels tree view", typeof(CockpitPanelsDialog), new InputGestureCollection { new KeyGesture(Key.F3, ModifierKeys.None) });
        public static readonly RoutedUICommand clearSearchResults = new RoutedUICommand("Clear search results", "Clear search results", typeof(CockpitPanelsDialog), new InputGestureCollection { new KeyGesture(Key.F4, ModifierKeys.None) });
        public static readonly RoutedUICommand resetTreeView = new RoutedUICommand("Reset panels tree", "Reset the panel order to defaults", typeof(CockpitPanelsDialog), new InputGestureCollection { new KeyGesture(Key.F5, ModifierKeys.None) });
        #endregion

        public CockpitPanelsDialog()
        {
            InitializeComponent();
            Tolk.Load();
            LoadPanels();
            originalTreeViewItems = treeHelper.GetOriginalTreeViewItems(panelsTreeView); // Get the default panels tree layout before the user changes it.
                        treeHelper.LoadTreeViewStateFromDisk(panelsTreeView, fileName); // Load the saved state of the panels tree layout.
                           

            panelsTreeView.Focus();
            treeHelper.SelectFirstTreeViewItem(panelsTreeView);
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
                if (!selectedItem.HasItems)
                {
                    sortAscendingMenuItem.Visibility = Visibility.Collapsed;
                    sortDescendingMenuItem.Visibility = Visibility.Collapsed;
                }
                else
                {
                    sortAscendingMenuItem.Visibility = Visibility.Visible;
                    sortDescendingMenuItem.Visibility = Visibility.Visible;
                                                    }
            }
        }

        private void searchTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                treeHelper.SearchTreeView(searchTextBox.Text, panelsTreeView, originalTreeViewItems, panelMappings);
                                                treeHelper.SelectFirstTreeViewItem(panelsTreeView);
                panelsTreeView.UpdateLayout();
                panelsTreeView.Focus();
                isSearchResultsDisplayed = true; // Search results are in the panels tree.
                            }
        }

        private void clearSearchButton_Click(object sender, RoutedEventArgs e)
        {
            treeHelper.LoadTreeViewStateFromDisk(panelsTreeView, fileName);
            treeHelper.SelectFirstTreeViewItem(panelsTreeView);
            panelsTreeView.Focus();
            isSearchResultsDisplayed = false; // No longer showing search results.
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
                    var isMoved = treeHelper.MoveTreeViewItemUp(panelsTreeView, selectedItem);
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
                    var isMoved = treeHelper.MoveTreeViewItemDown(panelsTreeView, selectedItem);
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

        private void sortAscendingMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = panelsTreeView.SelectedItem as TreeViewItem;

            if(selectedItem != null && selectedItem.Items.Count > 0)
            {
                treeHelper.SortTreeViewItemChildrenAscending(panelsTreeView, selectedItem);
            }
        }

        private void sortDescendingMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = panelsTreeView.SelectedItem as TreeViewItem;

            if (selectedItem != null && selectedItem.HasItems)
            {
                treeHelper.SortTreeViewItemChildrenDescending(panelsTreeView, selectedItem);
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!isSearchResultsDisplayed)
            {
                //Only save if there are no search results displayed.
                treeHelper.SaveTreeViewStateToDisk(panelsTreeView, fileName);
            }
                    }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            treeHelper.ResetTreeView(panelsTreeView, originalTreeViewItems);
            treeHelper.SelectFirstTreeViewItem(panelsTreeView);
            panelsTreeView.UpdateLayout();
            panelsTreeView.Focus();
            isSearchResultsDisplayed = false; //Search results are no longer displayed.
        }

        private void FocusSearchBox(object sender, ExecutedRoutedEventArgs e)
        {
            Keyboard.Focus(searchTextBox);
        }

        private void FocusPanelsTreeView(object sender, ExecutedRoutedEventArgs e)
        {
            Keyboard.Focus(panelsTreeView);
        }

        private void ClearSearchResults(object sender, ExecutedRoutedEventArgs e)
        {
            clearSearchButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ResetPanelsTreeView(object sender, ExecutedRoutedEventArgs e)
        {
            resetButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void savePanelLayoutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            treeHelper.SaveTreeViewStateToDisk(panelsTreeView, fileName);
            Tolk.Output("Layout saved.");
        }
    }
}
