using tfm.Converters;
using tfm.PMDG.PanelObjects;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace tfm.PMDG.PMDG_737.McpComponents
{
        public partial class McpNavAidsWindow : Window
    {
        public McpNavAidsWindow()
        {
            InitializeComponent();
            fdLToggleButton.Focus();
        }

        private async  void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var fdLSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_FDSw[0]).First() as SingleStateToggle;
            var fdRSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_FDSw      [1]).First() as SingleStateToggle;
            var appModeLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunAPP).First() as SingleStateToggle;
            var vorLocLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunVOR_LOC).First() as SingleStateToggle;
            var cmdALight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunCMD_A).First() as SingleStateToggle;
            var cwsALight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunCWS_A).First() as SingleStateToggle;
            var cmdBLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunCMD_B).First() as SingleStateToggle;
            var cwsBLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunCWS_B).First() as SingleStateToggle;
            var bankLimitSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_BankLimitSel).First() as SingleStateToggle;
            var disengageBarSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_DisengageBar).First() as SingleStateToggle;

            App.UI.BuildToggleButton(fdLToggleButton, fdLSwitch, "FD/L");
            App.UI.BuildToggleButton(fdRToggleButton, fdRSwitch, "FD/R");
            App.UI.BuildToggleButton(appModeToggleButton, appModeLight, "APP");
            App.UI.BuildToggleButton(vorLocToggleButton, vorLocLight, "VOR/LOC");
            App.UI.BuildToggleButton(cmdAToggleButton, cmdALight, "CMD/A");
            App.UI.BuildToggleButton(cwsAToggleButton, cwsALight, "CWS/A");
            App.UI.BuildToggleButton(cmdBToggleButton, cmdBLight, "CMD/B");
            App.UI.BuildToggleButton(cwsBToggleButton, cwsBLight, "CWS/B");
            App.UI.BuildToggleButton(disengageBarToggleButton, disengageBarSwitch, "Disengage bar");
            App.UI.BuildButton(bankLimitButton, bankLimitSwitch);

            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(500)
            };
            timer.Tick += async (s, args) => await UpdatePanelControlsAsync();
            timer.Start();
                    }

        private async Task UpdatePanelControlsAsync()
        {
            await Task.Run(() =>
            {
                var fdLSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_FDSw[0]).First() as SingleStateToggle;
                var fdRSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_FDSw[1]).First() as SingleStateToggle;
                var appModeLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunAPP).First() as SingleStateToggle;
                var vorLocLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunVOR_LOC).First() as SingleStateToggle;
                var cmdALight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunCMD_A).First() as SingleStateToggle;
                var cwsALight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunCWS_A).First() as SingleStateToggle;
                var cmdBLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunCMD_B).First() as SingleStateToggle;
                var cwsBLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_annunCWS_B).First() as SingleStateToggle;
                var bankLimitSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_BankLimitSel).First() as SingleStateToggle;
                var disengageBarSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.MCP_DisengageBar).First() as SingleStateToggle;

                Dispatcher.Invoke(() =>
                {
                    App.UI.BuildToggleButton(fdLToggleButton, fdLSwitch, "FD/L");
                    App.UI.BuildToggleButton(fdRToggleButton, fdRSwitch, "FD/R");
                    App.UI.BuildToggleButton(appModeToggleButton, appModeLight, "APP");
                    App.UI.BuildToggleButton(vorLocToggleButton, vorLocLight, "VOR/LOC");
                    App.UI.BuildToggleButton(cmdAToggleButton, cmdALight, "CMD/A");
                    App.UI.BuildToggleButton(cwsAToggleButton, cwsALight, "CWS/A");
                    App.UI.BuildToggleButton(cmdBToggleButton, cmdBLight, "CMD/B");
                    App.UI.BuildToggleButton(cwsBToggleButton, cwsBLight, "CWS/B");
                    App.UI.BuildToggleButton(disengageBarToggleButton, disengageBarSwitch, "Disengage bar");

                    if (Aircraft.pmdg737.MCP_BankLimitSel.ValueChanged)
                    {
                        App.UI.BuildButton(bankLimitButton, bankLimitSwitch);
                    }
                                                        });
            });
        }

        private void fdLToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.FD1();
        }

        private void fdRToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.FD2();
        }

        private void cmdAToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.CMDA();
        }

        private void cmdBToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.CMDB();
        }

        private void appModeToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.ApproachMode();
        }

        private void bankLimitButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.BankLimiter();
        }

        private void vorLocToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.LocalizerHold();
        }

        private void autoPilotDisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.DisengageAutoPilot();
        }

        private void cwsAToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.CWSA();
        }

        private void cwsBToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.CWSB();
        }

        private void disengageBarToggleButton_Click(object sender, RoutedEventArgs e)
        {
            PMDG737Aircraft.DisengageBar();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (((e.Key == Key.LeftAlt || e.Key == Key.RightAlt) && e.Key == Key.F4) || e.Key == Key.Escape)
            {
                this.Hide();
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
        }

        private void ToggleFDL(object sender, ExecutedRoutedEventArgs e)
        {
            fdLToggleButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ToggleFDR(object sender, ExecutedRoutedEventArgs e)
        {
            fdRToggleButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ToggleCMDA(object sender, ExecutedRoutedEventArgs e)
        {
            cmdAToggleButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ToggleCMDB(object sender, ExecutedRoutedEventArgs e)
        {
            cmdBToggleButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ToggleApproachMode(object sender, ExecutedRoutedEventArgs e)
        {
            appModeToggleButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void CycleBankLimit(object sender, ExecutedRoutedEventArgs e)
        {
            bankLimitButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ToggleVorLoc(object sender, ExecutedRoutedEventArgs e)
        {
            vorLocToggleButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ToggleCWSA(object sender, ExecutedRoutedEventArgs e)
        {
            cwsAToggleButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ToggleCWSB(object sender, ExecutedRoutedEventArgs e)
        {
            cwsBToggleButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void ToggleDisengageBar(object sender, ExecutedRoutedEventArgs e)
        {
            disengageBarToggleButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void DisconnectAutoPilot(object sender, ExecutedRoutedEventArgs e)
        {
            autoPilotDisconnectButton.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }
            }
}
