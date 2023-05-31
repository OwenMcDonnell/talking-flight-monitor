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

        public void SelectFirstTreeViewItem(TreeView tree)
        {
            if(tree.Items != null)
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
                App.UI.ResetTreeView(tree, originalTreeViewItems);
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
                var match = App.UI.GetTreeViewItemByName(originalTreeViewItems, key);

                if (match != null)
                {
                    // Append the root treeview item's header to the found item's header.
                    var rootHeader = originalTreeViewItems.FirstOrDefault()?.Header?.ToString();
                    if (rootHeader != null)
                    {
                        // Remove any existing '(' and ')' characters from the root header.
                        rootHeader = rootHeader.Replace("(", "").Replace(")", "").Trim();
                        match.Header= match.Header.ToString().Replace("(", "").Replace(")", "").Trim();
                        match.Header = $"{match.Header} [{rootHeader}]";
                    }

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
        }

        public List<TreeViewItem> GetOriginalTreeViewItems(TreeView treeView)
        {
            List<TreeViewItem> originalItems = new List<TreeViewItem>();

            foreach (object item in treeView.Items)
            {
                if (item is TreeViewItem treeViewItem)
                {
                    TreeViewItem clonedItem = CloneTreeViewItem(treeViewItem);
                    originalItems.Add(clonedItem);
                    AddChildTreeViewItems(treeViewItem, clonedItem);
                }
            }

            return originalItems;
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

        private TreeViewItem CloneTreeViewItem(TreeViewItem originalItem)
        {
            string originalHeader = GetItemHeader(originalItem);

            TreeViewItem clonedItem = new TreeViewItem();
            clonedItem.Header = originalItem.Header;
            clonedItem.Name = originalItem.Name;

            // Clone child items recursively
            foreach (TreeViewItem childItem in originalItem.Items)
            {
                TreeViewItem clonedChild = CloneTreeViewItem(childItem);
                clonedItem.Items.Add(clonedChild);
            }

            // Retrieve the root parent's header
            TreeViewItem rootParentItem = FindRootParentItem(originalItem);
            string rootParentHeader = GetItemHeader(rootParentItem);

            // Add root parent's header to the cloned item's header
            clonedItem.Header = $"{originalHeader} ({rootParentHeader})";

            return clonedItem;
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

    }
}