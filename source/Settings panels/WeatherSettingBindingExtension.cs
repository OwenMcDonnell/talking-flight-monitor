using System.Windows.Data;

namespace tfm
{
    public class WeatherSettingBindingExtension : System.Windows.Data.Binding
    {
        public WeatherSettingBindingExtension()
        {
            Initialize();
        }

        public WeatherSettingBindingExtension(string path)
            : base(path)
        {
            Initialize();
        }

        private void Initialize()
        {
            this.Source = tfm.Properties.Weather.Default;
            this.Mode = BindingMode.TwoWay;
        }
    }
}