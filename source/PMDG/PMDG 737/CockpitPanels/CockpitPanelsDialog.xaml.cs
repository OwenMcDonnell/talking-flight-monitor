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

        private readonly Dictionary<string, UserControl> panelMappings = new Dictionary<string, UserControl>();

        public CockpitPanelsDialog()
        {
            InitializeComponent();
            SelectFirstTreeviewItem();
            LoadPanels();
            panelsTreeView.Focus();
                                            }

        private void LoadPanels()
        {

            panelMappings["adiru"] = new adiru();
            panelMappings["domeLights"] = new DomeLights();
        }

        private void SelectFirstTreeviewItem()
        {
            if(panelsTreeView.Items != null)
            {
                var firstItem = panelsTreeView.Items[0] as TreeViewItem;
                firstItem.IsSelected = true;
            }
        }

        private void panelsTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

            contentArea.Content = null;
            var selectedItem = e.NewValue as TreeViewItem;

            if(panelMappings.TryGetValue(selectedItem.Name, out UserControl userControl))
            {
                contentArea.Content = userControl;
            }
        }
    }
}
