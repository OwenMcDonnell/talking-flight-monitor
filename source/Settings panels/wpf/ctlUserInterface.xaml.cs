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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tfm.Settings_panels.wpf
{
        public partial class ctlUserInterface : System.Windows.Controls.UserControl
    {
        public ctlUserInterface()
        {
            InitializeComponent();

            // Load font names.
            foreach(var family in Fonts.SystemFontFamilies)
            {
                FontNameComboBox.Items.Add(family.Source);
            }

            // Load font sizes.
            for (double size = 8; size <= 72; size += 2)
            {
                FontSizeComboBox.Items.Add(size);
            }
        }
    }
}
