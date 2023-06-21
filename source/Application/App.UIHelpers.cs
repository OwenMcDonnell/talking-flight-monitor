using Newtonsoft.Json;
using tfm.Converters;
using tfm.PMDG.PanelObjects;
using tfm.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using TreeView = System.Windows.Controls.TreeView;
using System.Windows.Markup;
using tfm.Properties;
using System.Windows.Media;
using System.Windows;
using System.IO;
using System.Windows.Input;
using System.Xaml;
using XamlWriter = System.Windows.Markup.XamlWriter;
using BingMapsRESTToolkit;
using static System.Data.Entity.Infrastructure.Design.Executor;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;
using System.Drawing;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using System.Windows.Documents;
using System.Xml;
using Newtonsoft.Json;

namespace tfm
{
    public partial class App : System.Windows.Application
    {
        public static  UIHelpers UI
        {
            get => new UIHelpers();
        }
    }

    public class UIHelpers
    {
        private ByteToBoolConverter converter = new ByteToBoolConverter();

public TreeViewSerializer TreeViewHelper { get => new TreeViewSerializer(); }

        public void FocusWindow(System.Windows.Window targetWindow, System.Windows.Controls.Control targetControl)
        {
            targetWindow.Topmost = true;
            targetWindow.ShowDialog();
            targetWindow.Activate();
            targetControl.Focus();
            System.Windows.Input.Keyboard.Focus(targetControl);
            targetWindow.BringIntoView();
        }

                public void BuildToggleButton(ToggleButton control, SingleStateToggle toggle, string alternateName = null, bool reverse = false)
        {
            string name = alternateName == null ? toggle.Name : alternateName;
            control.Content = $"{name}";

            control.IsChecked = reverse ? !(bool?)converter.Convert(toggle.CurrentState.Key, typeof(bool?), null, CultureInfo.InvariantCulture) : (bool?)converter.Convert(toggle.CurrentState.Key, typeof(bool?), null, CultureInfo.InvariantCulture);
            AutomationProperties.SetName(control, $"{name}");
        }

        public void BuildButton(System.Windows.Controls.Button control, SingleStateToggle toggle, string alternateName = null)
        {
            string name = alternateName == null ? toggle.Name : alternateName;
            control.Content = $"{name} {toggle.CurrentState.Value}";
                                    AutomationProperties.SetName(control, $"{name} {toggle.CurrentState.Value}");
        }

        public void BuildIndicatorTextBox(System.Windows.Controls.TextBox control, SingleStateToggle toggle, string alternateName = null)
        {
            string name = alternateName == null ? toggle.Name : alternateName;
            control.Text = toggle.CurrentState.Value;
            control.IsReadOnly = true;
            control.IsReadOnlyCaretVisible = true;
            control.Focusable = true;
            AutomationProperties.SetName(control, $"{name}");

        }

    }

    public class TreeViewState
    {
        public List<TreeViewItemState> Items { get; set; }
    }

    public class TreeViewItemState
    {
        public string Name { get; set; }
        public string Header { get; set; }
        public List<TreeViewItemState> Children { get; set; }
    }

    public class TreeViewSerializer
    {

        public void SortTreeViewItemChildrenAscending(TreeView treeView, TreeViewItem rootItem)
        {
            if (treeView == null || rootItem == null)
                return;

            // Get the children of the root TreeViewItem
            List<TreeViewItem> children = rootItem.Items.Cast<TreeViewItem>().ToList();

            // Sort the children alphabetically by their header text
            List<TreeViewItem> sortedChildren = children.OrderBy(child => child.Header.ToString()).ToList();

            // Clear the existing children
            rootItem.Items.Clear();

            // Add the sorted children back to the root TreeViewItem
            foreach (TreeViewItem sortedChild in sortedChildren)
            {
                rootItem.Items.Add(sortedChild);
            }

            // Update the TreeView to reflect the changes
            treeView.UpdateLayout();
        }

        public void SortTreeViewItemChildrenDescending(TreeView treeView, TreeViewItem rootItem)
        {
            if (treeView == null || rootItem == null)
                return;

            // Get the children of the root TreeViewItem
            List<TreeViewItem> children = rootItem.Items.Cast<TreeViewItem>().ToList();

            // Sort the children alphabetically in descending order by their header text
            List<TreeViewItem> sortedChildren = children.OrderByDescending(child => child.Header.ToString()).ToList();

            // Clear the existing children
            rootItem.Items.Clear();

            // Add the sorted children back to the root TreeViewItem
            foreach (TreeViewItem sortedChild in sortedChildren)
            {
                rootItem.Items.Add(sortedChild);
            }

            // Update the TreeView to reflect the changes
            treeView.UpdateLayout();
        }

        public bool MoveTreeViewItemUp(TreeView treeView, TreeViewItem item)
        {
            if (item == null || item.Parent == null || !(item.Parent is ItemsControl parentItemsControl))
                return false;

            int currentIndex = parentItemsControl.Items.IndexOf(item);
            if (currentIndex > 0)
            {
                parentItemsControl.Items.RemoveAt(currentIndex);
                parentItemsControl.Items.Insert(currentIndex - 1, item);
                // Disable focusability and hit test on the moved item
                item.Focusable = false;
                item.IsHitTestVisible = false;

                // Set focus to the treeView to restore keyboard access
                treeView.Focus();

                // Enable focusability and hit test on the moved item
                item.Focusable = true;
                item.IsHitTestVisible = true;

                // Set focus back to the moved item
                item.Focus();

                return true;
            }

            return false;
        }

        public bool MoveTreeViewItemDown(TreeView treeView, TreeViewItem item)
        {
            if (item == null || item.Parent == null || !(item.Parent is ItemsControl parentItemsControl))
                return false;

            int currentIndex = parentItemsControl.Items.IndexOf(item);
            int maxIndex = parentItemsControl.Items.Count - 1;
            if (currentIndex < maxIndex)
            {
                parentItemsControl.Items.RemoveAt(currentIndex);
                parentItemsControl.Items.Insert(currentIndex + 1, item);

                // Disable focusability and hit test on the moved item
                item.Focusable = false;
                item.IsHitTestVisible = false;

                // Set focus to the treeView to restore keyboard access
                treeView.Focus();

                // Enable focusability and hit test on the moved item
                item.Focusable = true;
                item.IsHitTestVisible = true;

                // Set focus back to the moved item
                item.Focus();

                return true;
            }

            return false;
        }

        public void SelectFirstTreeViewItem(TreeView tree)
        {
            if (tree.Items != null)
            {
                var firstItem = tree.Items[0] as TreeViewItem;
                firstItem.IsSelected = true;
            }
        }

        public void SearchTreeView(string keyword, TreeView tree, List<TreeViewItem> originalTreeViewItems, Dictionary<string, UserControlInfo> mappings)
        {
            var matchingKeys = new List<string>();
            var matchingTreeViewItems = new List<TreeViewItem>();

            // Reset the treeview if no search is provided.
            if (string.IsNullOrEmpty(keyword))
            {
                ResetTreeView(tree, originalTreeViewItems);
                return;
            }

            string[] keywordsArray = keyword.Split(',');

            // Find all mapping keys matching the provided keywords.
            foreach (var mapping in mappings)
            {
                var match = mapping.Value.Keywords.Where(x => keywordsArray.Any(kw => x.Contains(kw.Trim())));

                // If all keywords match, add the key to the list.
                if (match.Count() > 0)
                {
                    matchingKeys.Add(mapping.Key);
                }
            }

            // Look for TreeViewItems matching each key found.
            foreach (var key in matchingKeys)
            {
                var match = GetTreeViewItemByName(originalTreeViewItems, key);

                if (match != null)
                {
                    matchingTreeViewItems.Add(match);
                }
            }

            // Load the TreeView with the results.
            tree.Items.Clear();

            if (matchingTreeViewItems.Count > 0)
            {
                foreach (var item in matchingTreeViewItems)
                {
                    if (item != null)
                    {
                        tree.Items.Add(item);
                    }
                }

                // Select the first item in the tree if it is available.
                SelectFirstTreeViewItem(tree);
            }
            else
            {
                // No search results found.
                TreeViewItem notFoundTreeViewItem = new TreeViewItem
                {
                    Header = "No results found",
                    Name = "notFoundTreeViewItem",
                };
                tree.Items.Add(notFoundTreeViewItem);
                SelectFirstTreeViewItem(tree);
            }
        }

        public TreeViewItem GetTreeViewItemByName(List<TreeViewItem> originalItems, string key)
        {
            foreach (TreeViewItem item in originalItems)
            {
                TreeViewItem result = FindTreeViewItemByName(item, key);
                if (result != null)
                    return CloneTreeViewItem(result);
            }

            return null;
        }

        private TreeViewItem FindTreeViewItemByName(TreeViewItem parentItem, string key)
        {
            if (parentItem.Name == key)
                return parentItem;

            foreach (object item in parentItem.Items)
            {
                if (item is TreeViewItem childItem)
                {
                    TreeViewItem result = FindTreeViewItemByName(childItem, key);
                    if (result != null)
                        return result;
                }
            }

            return null;
        }

        public void ResetTreeView(TreeView treeView, List<TreeViewItem> items)
        {

            treeView.Items.Clear();
            foreach (TreeViewItem item in items)
            {
                treeView.Items.Add(item);
            }
            treeView.Items.Refresh();
            treeView.UpdateLayout();
                                }

        public List<TreeViewItem> GetOriginalTreeViewItems(TreeView treeView)
        {
            List<TreeViewItem> originalItems = new List<TreeViewItem>();
            foreach (TreeViewItem item in treeView.Items)
            {
                TreeViewItem clonedItem = CloneTreeViewItem(item);
                originalItems.Add(clonedItem);
            }
            return originalItems;
        }

        private TreeViewItem CloneTreeViewItem(TreeViewItem originalItem)
        {
            TreeViewItem clonedItem = new TreeViewItem();
            clonedItem.Header = originalItem.Header;
            clonedItem.Name = originalItem.Name;

            CloneChildTreeViewItems(originalItem, clonedItem);

            return clonedItem;
        }

        private void CloneChildTreeViewItems(TreeViewItem originalItem, TreeViewItem clonedItem)
        {
            foreach (object item in originalItem.Items)
            {
                if (item is TreeViewItem childItem)
                {
                    TreeViewItem clonedChildItem = CloneTreeViewItem(childItem);
                    clonedItem.Items.Add(clonedChildItem);
                    CloneChildTreeViewItems(childItem, clonedChildItem);
                }
            }
        }

        private void AddChildTreeViewItems(TreeViewItem parentItem, TreeViewItem clonedParent)
        {
            foreach (object item in parentItem.Items)
            {
                if (item is TreeViewItem childItem)
                {
                    TreeViewItem clonedChildItem = CloneTreeViewItem(childItem);
                    clonedParent.Items.Add(clonedChildItem);
                    AddChildTreeViewItems(childItem, clonedChildItem);
                }
            }
        }

        private TreeViewItem FindRootParentItem(TreeViewItem item)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(item);

            while (parent != null && !(parent is TreeView))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            return parent as TreeViewItem;
        }

        private string GetItemHeader(TreeViewItem item)
        {
            return item?.Header?.ToString() ?? string.Empty;
        }

        public void SaveTreeViewStateToDisk(TreeView treeView, string fileName)
        {
            TreeViewState state = CreateTreeViewState(treeView);
            SerializeTreeViewState(state, fileName);
        }

        public void LoadTreeViewStateFromDisk(TreeView treeView, string fileName)
        {
            TreeViewState state = DeserializeTreeViewState(fileName);
            if (state != null)
            {
                RestoreTreeViewState(treeView, state);
                treeView.UpdateLayout();
            }
        }

        private TreeViewState CreateTreeViewState(TreeView treeView)
        {
            TreeViewState state = new TreeViewState();
            state.Items = treeView.Items.Cast<TreeViewItem>().Select(item => CreateTreeViewItemState(item)).ToList();
            return state;
        }

        private TreeViewItemState CreateTreeViewItemState(TreeViewItem treeViewItem)
        {
            TreeViewItemState itemState = new TreeViewItemState();
            itemState.Name = treeViewItem.Name;
            itemState.Header = treeViewItem.Header.ToString();
            itemState.Children = treeViewItem.Items.Cast<TreeViewItem>().Select(item => CreateTreeViewItemState(item)).ToList();
            return itemState;
        }

        private void SerializeTreeViewState(TreeViewState state, string fileName)
        {
            string json = JsonConvert.SerializeObject(state, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        private TreeViewState DeserializeTreeViewState(string fileName)
        {
            try
            {
                string json = File.ReadAllText(fileName);
                return JsonConvert.DeserializeObject<TreeViewState>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while deserializing TreeView state: " + ex.Message);
                return null;
            }
        }

        private void RestoreTreeViewState(TreeView treeView, TreeViewState state)
        {
            treeView.Items.Clear();
            foreach (TreeViewItemState itemState in state.Items)
            {
                TreeViewItem treeViewItem = CreateTreeViewItem(itemState);
                treeView.Items.Add(treeViewItem);
            }
        }

        private TreeViewItem CreateTreeViewItem(TreeViewItemState itemState)
        {
            TreeViewItem treeViewItem = new TreeViewItem();
            treeViewItem.Name = itemState.Name;
            treeViewItem.Header = itemState.Header;

            if (itemState.Children != null)
            {
                foreach (TreeViewItemState childState in itemState.Children)
                {
                    TreeViewItem childTreeViewItem = CreateTreeViewItem(childState);
                    treeViewItem.Items.Add(childTreeViewItem);
                }
            }

            return treeViewItem;
        }
    }
}