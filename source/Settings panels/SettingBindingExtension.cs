using System.Windows.Data;

namespace tfm
{
    public class SettingBindingExtension : System.Windows.Data.Binding
    {
        public SettingBindingExtension()
        {
            Initialize();
        }

        public SettingBindingExtension(string path)
            : base(path)
        {
            Initialize();
        }

        private void Initialize()
        {
            this.Source = tfm.Properties.Settings.Default;
            this.Mode = BindingMode.TwoWay;
        }
    }
}