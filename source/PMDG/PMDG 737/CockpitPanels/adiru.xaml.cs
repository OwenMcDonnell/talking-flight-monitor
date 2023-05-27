using tfm.PMDG.PanelObjects;
using System.Windows.Automation;
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

using UserControl = System.Windows.Controls.UserControl;
using System.Windows.Threading;

namespace tfm.PMDG.PMDG_737.CockpitPanels
{
        public partial class adiru : UserControl
    {
        public adiru()
        {
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // IRU display.
            #region "Display"
            var displaySelector = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_DisplaySelector).First() as SingleStateToggle;
            switch (displaySelector.CurrentState.Key)
            {
                case 1:
                    displayModeComboBox.SelectedIndex = 0;
                    AutomationProperties.SetName(leftDisplayTextBox, "Track");
                    AutomationProperties.SetName(rightDisplayTextBox, "Ground speed");
                    break;
                case 2:
                    displayModeComboBox.SelectedIndex = 1;
                    AutomationProperties.SetName(leftDisplayTextBox, "Latitude");
                    AutomationProperties.SetName(rightDisplayTextBox, "Longitude");
                    break;
                case 3:
                    displayModeComboBox.SelectedIndex = 2;
                    AutomationProperties.SetName(leftDisplayTextBox, "Wind direction");
                    AutomationProperties.SetName(rightDisplayTextBox, "Wind speed");
                    break;
                case 4:
                    displayModeComboBox.SelectedIndex = 3;
                    AutomationProperties.SetName(leftDisplayTextBox, "Heading");
                    AutomationProperties.SetName(rightDisplayTextBox, "Status");
                    break;
            }            
            leftDisplayTextBox.Text = Aircraft.pmdg737.IRS_DisplayLeft.Value;
            rightDisplayTextBox.Text = Aircraft.pmdg737.IRS_DisplayRight.Value;
            #endregion

            // Left mode selector.
            #region "Left mode selector"
            var leftModeSelector = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_ModeSelector[0]).First() as SingleStateToggle;
            switch (leftModeSelector.CurrentState.Key)
            {
                case 0:
                    leftModeSelectorComboBox.SelectedIndex = 0;
                    break;
                case 1:
                    leftModeSelectorComboBox.SelectedIndex = 1;
                    break;
                case 2:
                    leftModeSelectorComboBox.SelectedIndex = 2;
                    break;
                case 3:
                    leftModeSelectorComboBox.SelectedIndex = 3;
                    break;
            }
            #endregion

            // Right mode selector.
            #region "Right mode selector"
            var rightModeSelector = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_ModeSelector[1]).First() as SingleStateToggle;
            switch (rightModeSelector.CurrentState.Key)
            {
                case 0:
                    rightModeSelectorComboBox.SelectedIndex = 0;
                    break;
                case 1:
                    rightModeSelectorComboBox.SelectedIndex = 1;
                    break;
                case 2:
                    rightModeSelectorComboBox.SelectedIndex = 2;
                    break;
                case 3:
                    rightModeSelectorComboBox.SelectedIndex = 3;
                    break;
            }
            #endregion

            // Indicators.
            #region "Indicators"
            var leftDcFailLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_annunDC_FAIL[0]).First() as SingleStateToggle;
            var rightDcFailLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_annunDC_FAIL[1]).First() as SingleStateToggle;
            var leftIruFaultLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_annunFAULT[0]).First() as SingleStateToggle;
            var rightIruFaultLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_annunFAULT[1]).First() as SingleStateToggle;
            var gpsLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_annunGPS).First() as SingleStateToggle;
            var leftIruLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_annunALIGN[0]).First() as SingleStateToggle;
            var rightIruLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_annunALIGN[1]).First() as SingleStateToggle;
            var leftDcLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_annunON_DC[0]).First() as SingleStateToggle;
            var rightDcLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_annunON_DC[1]).First() as SingleStateToggle;

            dcFailLeftTextBox.Text = leftDcFailLight.CurrentState.Value;
            dcFailRightTextBox.Text = rightDcFailLight.CurrentState.Value;
            faultLeftTextBox.Text = leftIruFaultLight.CurrentState.Value;
            faultRightTextBox.Text = rightIruFaultLight.CurrentState.Value;
            gpsTextBox.Text = gpsLight.CurrentState.Value;
            iruLeftTextBox.Text = leftIruLight.CurrentState.Value;
            iruRightTextBox.Text = rightIruLight.CurrentState.Value;
            dcLeftTextBox.Text = leftDcLight.CurrentState.Value;
            dcRightTextBox.Text = rightDcLight.CurrentState.Value;

            #endregion
            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(300)
            };
            timer.Tick += async (s, args) => await UpdatePanelControlsAsync();
            timer.Start();
        }

        private async Task UpdatePanelControlsAsync()
        {
            await Task.Run(() =>
            {
                var displaySelector = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_DisplaySelector).First() as SingleStateToggle;
                var leftModeSelector = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_ModeSelector[0]).First() as SingleStateToggle;
                var rightModeSelector = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_ModeSelector[1]).First() as SingleStateToggle;
                var leftDcFailLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_annunDC_FAIL[0]).First() as SingleStateToggle;
                var rightDcFailLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_annunDC_FAIL[1]).First() as SingleStateToggle;
                var leftIruFaultLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_annunFAULT[0]).First() as SingleStateToggle;
                var rightIruFaultLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_annunFAULT[1]).First() as SingleStateToggle;
                var gpsLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_annunGPS).First() as SingleStateToggle;
                var leftIruLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_annunALIGN[0]).First() as SingleStateToggle;
                var rightIruLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_annunALIGN[1]).First() as SingleStateToggle;
                var leftDcLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_annunON_DC[0]).First() as SingleStateToggle;
                var rightDcLight = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.IRS_annunON_DC[1]).First() as SingleStateToggle;

                Dispatcher.Invoke(() =>
                {
                    // IRU display.
                    #region "Display"
                    switch (displaySelector.CurrentState.Key)
                    {
                        case 1:
                            displayModeComboBox.SelectedIndex = 0;
                            AutomationProperties.SetName(leftDisplayTextBox, "Track");
                            AutomationProperties.SetName(rightDisplayTextBox, "Ground speed");
                            break;
                        case 2:
                            displayModeComboBox.SelectedIndex = 1;
                            AutomationProperties.SetName(leftDisplayTextBox, "Latitude");
                            AutomationProperties.SetName(rightDisplayTextBox, "Longitude");
                            break;
                        case 3:
                            displayModeComboBox.SelectedIndex = 2;
                            AutomationProperties.SetName(leftDisplayTextBox, "Wind direction");
                            AutomationProperties.SetName(rightDisplayTextBox, "Wind speed");
                            break;
                        case 4:
                            displayModeComboBox.SelectedIndex = 3;
                            AutomationProperties.SetName(leftDisplayTextBox, "Heading");
                            AutomationProperties.SetName(rightDisplayTextBox, "Status");
                            break;
                    }
                    leftDisplayTextBox.Text = Aircraft.pmdg737.IRS_DisplayLeft.Value;
                    rightDisplayTextBox.Text = Aircraft.pmdg737.IRS_DisplayRight.Value;

                    #endregion

                    // Left mode selector.
                    #region "Left mode selector"
                    switch (leftModeSelector.CurrentState.Key)
                    {
                        case 0:
                            leftModeSelectorComboBox.SelectedIndex = 0;
                            break;
                        case 1:
                            leftModeSelectorComboBox.SelectedIndex = 1;
                            break;
                        case 2:
                            leftModeSelectorComboBox.SelectedIndex = 2;
                            break;
                        case 3:
                            leftModeSelectorComboBox.SelectedIndex = 3;
                            break;
                    }

                    #endregion

                    //Right mode selector.
                    #region "Right mode selector"
                    switch (rightModeSelector.CurrentState.Key)
                    {
                        case 0:
                            rightModeSelectorComboBox.SelectedIndex = 0;
                            break;
                        case 1:
                            rightModeSelectorComboBox.SelectedIndex = 1;
                            break;
                        case 2:
                            rightModeSelectorComboBox.SelectedIndex = 2;
                            break;
                        case 3:
                            rightModeSelectorComboBox.SelectedIndex = 3;
                            break;
                    }
                    #endregion

                    // Indicators.
                    #region "Indicators"
                    dcFailLeftTextBox.Text = leftDcFailLight.CurrentState.Value;
                    dcFailRightTextBox.Text = rightDcFailLight.CurrentState.Value;
                    faultLeftTextBox.Text = leftIruFaultLight.CurrentState.Value;
                    faultRightTextBox.Text = rightIruFaultLight.CurrentState.Value;
                    gpsTextBox.Text = gpsLight.CurrentState.Value;
                    iruLeftTextBox.Text = leftIruLight.CurrentState.Value;
                    iruRightTextBox.Text = rightIruLight.CurrentState.Value;
                    dcLeftTextBox.Text = leftDcLight.CurrentState.Value;
                    dcRightTextBox.Text = rightDcLight.CurrentState.Value;
                    #endregion
                });
            });
        }

        private void displayModeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.AddedItems[0] as ComboBoxItem;
            if (selectedItem.Name == "trkGsComboBoxItem")
            {
                PMDG737Aircraft.IRSDisplayTrackGS();
            }
            if(selectedItem.Name == "pPosComboBoxItem")
            {
                PMDG737Aircraft.IRSDisplayPPOS();
            }
            if(selectedItem.Name == "windComboBoxItem")
            {
                PMDG737Aircraft.IRSDisplayWind();
            }
            if(selectedItem.Name == "hdgStatComboBoxItem")
            {
                PMDG737Aircraft.IRSDisplayHdgStat();
            }
        }

        private void leftModeSelectorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.AddedItems[0] as ComboBoxItem;

            if(selectedItem.Name == "leftSelectorOffComboBoxItem")
            {
                PMDG737Aircraft.IRULeftOff();
            }
            if(selectedItem.Name == "leftModeAlignComboBoxItem")
            {
                PMDG737Aircraft.IRULeftAlign();
            }
            if(selectedItem.Name == "leftModeNavComboBoxItem")
            {
                PMDG737Aircraft.IRULeftNav();
            }
            if(selectedItem.Name == "leftModeAttComboBoxItem")
            {
                PMDG737Aircraft.IRULeftAtt();
            }
        }

        private void rightModeSelectorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectedItem = e.AddedItems[0] as ComboBoxItem;

            if(selectedItem.Name == "rightSelectorOffComboBoxItem")
            {
                PMDG737Aircraft.IRURightOff();
            }
            if(selectedItem.Name == "rightModeAlignComboBoxItem")
            {
                PMDG737Aircraft.IRURightAlign();
            }
            if(selectedItem.Name == "rightModeNavComboBoxItem")
            {
                PMDG737Aircraft.IRURightNav();
            }
            if(selectedItem.Name == "rightModeAttComboBoxItem")
            {
                PMDG737Aircraft.IRURightAtt();
            }
        }
    }
}
