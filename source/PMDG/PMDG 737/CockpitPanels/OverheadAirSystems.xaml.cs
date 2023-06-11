using tfm.PMDG.PanelObjects;
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
using System.Windows.Threading;
using UserControl = System.Windows.Controls.UserControl;


namespace tfm.PMDG.PMDG_737.CockpitPanels
{
        public partial class OverheadAirSystems : UserControl
    {

        // Panel controls and indicators.
        #region "Controls"
        private SingleStateToggle airSourceSelector = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_TempSourceSelector).First() as SingleStateToggle;
        private SingleStateToggle airTrimSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_TrimAirSwitch).First() as SingleStateToggle;
        private SingleStateToggle leftRecircFanSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_RecircFanSwitch[0]).First() as SingleStateToggle;
        private SingleStateToggle rightRecircFanSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_RecircFanSwitch[1]).First() as SingleStateToggle;
        private SingleStateToggle leftPackSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_PackSwitch[0]).First() as SingleStateToggle;
        private SingleStateToggle rightPackSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_PackSwitch[1]).First() as SingleStateToggle;
        private SingleStateToggle leftBleedSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_BleedAirSwitch[0]).First() as SingleStateToggle;
        private SingleStateToggle rightBleedSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_BleedAirSwitch[1]).First() as SingleStateToggle;
        private SingleStateToggle apuBleedSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_APUBleedAirSwitch).First() as SingleStateToggle;
        private SingleStateToggle isolationValveSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_IsolationValveSwitch).First() as SingleStateToggle;
        private SingleStateToggle outflowValveSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_OutflowValveSwitch).First() as SingleStateToggle;


        private SingleStateToggle flightDeckTempIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_annunZoneTemp[0]).First() as SingleStateToggle;
        private SingleStateToggle forwardCabinTempIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_annunZoneTemp[1]).First() as SingleStateToggle;
        private SingleStateToggle aftCabinTempIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_annunZoneTemp[2]).First() as SingleStateToggle;
        private SingleStateToggle dualBleedIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_annunDualBleed).First() as SingleStateToggle;
        private SingleStateToggle leftRamDoorIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_annunRamDoorL).First() as SingleStateToggle;
        private SingleStateToggle rightRamDoorIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_annunRamDoorR).First() as SingleStateToggle;
        private SingleStateToggle leftPackTripIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_annunPackTripOff[0]).First() as SingleStateToggle;
        private SingleStateToggle rightPackTripIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_annunPackTripOff[1]).First() as SingleStateToggle;
        private SingleStateToggle leftWingOverheatIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_annunWingBodyOverheat[0]).First() as SingleStateToggle;
        private SingleStateToggle rightWingOverheatIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_annunWingBodyOverheat[1]).First() as SingleStateToggle;
        private SingleStateToggle leftBleedTripIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_annunBleedTripOff[0]).First() as SingleStateToggle;
        private SingleStateToggle rightBleedTripIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.AIR_annunBleedTripOff[1]).First() as SingleStateToggle;
        #endregion

        public OverheadAirSystems()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            InitializePanelControls();
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

                Dispatcher.Invoke(() =>
                {

                    CyclePanelControls();
                });
            });
        }


        // Load the panel controls when the user control is loaded.
        private void InitializePanelControls()
        {

            // Controls.
            #region "Controls"
            airSourceComboBox.SelectedIndex = airSourceSelector.CurrentState.Key;
            App.UI.BuildToggleButton(trimToggleButton, airTrimSwitch);
            App.UI.BuildToggleButton(leftRecircToggleButton, leftRecircFanSwitch);
            App.UI.BuildToggleButton(rightRecircToggleButton, rightRecircFanSwitch);
            leftPackComboBox.SelectedIndex = leftPackSwitch.CurrentState.Key;
            rightPackComboBox.SelectedIndex = rightPackSwitch.CurrentState.Key;
            App.UI.BuildToggleButton(leftBleedToggleButton, leftBleedSwitch);
            App.UI.BuildToggleButton(rightBleedToggleButton, rightBleedSwitch);
            App.UI.BuildToggleButton(apuBleedToggleButton, apuBleedSwitch);
            isolationComboBox.SelectedIndex = isolationValveSwitch.CurrentState.Key;
            outFlowComboBox.SelectedIndex = outflowValveSwitch.CurrentState.Key;
                        #endregion

            //Indicators
            #region "Indicators"
            App.UI.BuildIndicatorTextBox(fltDeckTempTextBox, flightDeckTempIndicator, "Flight deck demprature indicator");
            App.UI.BuildIndicatorTextBox(fwdCabinTempTextBox, forwardCabinTempIndicator, "Forward cabin temprature indicator");
            App.UI.BuildIndicatorTextBox(aftCabinTempTextBox, aftCabinTempIndicator, "AFT cabin temprature indicator");
            App.UI.BuildIndicatorTextBox(dualBleedTextBox, dualBleedIndicator, "Dual bleed indicator");
            App.UI.BuildIndicatorTextBox(leftRamDoorTextBox, leftRamDoorIndicator, "Left ram door indicator");
            App.UI.BuildIndicatorTextBox(rightRamDoorTextBox, rightRamDoorIndicator, "Right ram door indicator");
            App.UI.BuildIndicatorTextBox(leftPackTripTextBox, leftPackTripIndicator, "Left pack trip indicator");
            App.UI.BuildIndicatorTextBox(rightPackTripTextBox, rightPackTripIndicator, "Right pack trip indicator");
            App.UI.BuildIndicatorTextBox(leftWingOverheatTextBox, leftWingOverheatIndicator, "Left wing overheat indicator");
            App.UI.BuildIndicatorTextBox(rightWingOverheatTextBox, rightWingOverheatIndicator, "Right wing overheat indicator");
            App.UI.BuildIndicatorTextBox(leftBleedTripTextBox, leftBleedTripIndicator, "Left bleed trip indicator");
            App.UI.BuildIndicatorTextBox(rightBleedTripTextBox, rightBleedTripIndicator, "Right bleed trip indicator");
                        #endregion
                    }

        // Used inside timers or tasks to update panel controls.
        private void CyclePanelControls()
        {

            // Controls.
            #region "Controls"
            if (airSourceSelector.Offset.ValueChanged)
            {
                airSourceComboBox.SelectedIndex = airSourceSelector.CurrentState.Key;
            }
            if (airTrimSwitch.Offset.ValueChanged)
            {
                App.UI.BuildToggleButton(trimToggleButton, airTrimSwitch);
            }
            if (leftRecircFanSwitch.Offset.ValueChanged)
            {
                App.UI.BuildToggleButton(leftRecircToggleButton, leftRecircFanSwitch);
            }
            if (rightRecircFanSwitch.Offset.ValueChanged)
            {
                App.UI.BuildToggleButton(rightRecircToggleButton, rightRecircFanSwitch);
            }
            if (leftPackSwitch.Offset.ValueChanged)
            {
                leftPackComboBox.SelectedIndex = leftPackSwitch.CurrentState.Key;
            }
            if (rightPackSwitch.Offset.ValueChanged)
            {
                rightPackComboBox.SelectedIndex = rightPackSwitch.CurrentState.Key;
            }
            if (leftBleedSwitch.Offset.ValueChanged)
            {
                App.UI.BuildToggleButton(leftBleedToggleButton, leftBleedSwitch);
            }
            if (rightBleedSwitch.Offset.ValueChanged)
            {
                App.UI.BuildToggleButton(rightBleedToggleButton, rightBleedSwitch);
            }
            if (apuBleedSwitch.Offset.ValueChanged)
            {
                App.UI.BuildToggleButton(apuBleedToggleButton, apuBleedSwitch);
            }
            if (isolationValveSwitch.Offset.ValueChanged)
            {
                isolationComboBox.SelectedIndex = isolationValveSwitch.CurrentState.Key;
            }
            if (outflowValveSwitch.Offset.ValueChanged)
            {
                outFlowComboBox.SelectedIndex = outflowValveSwitch.CurrentState.Key;
            }
            #endregion

            //Indicators
            #region "Indicators"
            if (flightDeckTempIndicator.Offset.ValueChanged)
            {
                App.UI.BuildIndicatorTextBox(fltDeckTempTextBox, flightDeckTempIndicator, "Flight deck demprature indicator");
            }
            if (forwardCabinTempIndicator.Offset.ValueChanged)
            {
                App.UI.BuildIndicatorTextBox(fwdCabinTempTextBox, forwardCabinTempIndicator, "Forward cabin temprature indicator");
            }
            if (aftCabinTempIndicator.Offset.ValueChanged)
            {
                App.UI.BuildIndicatorTextBox(aftCabinTempTextBox, aftCabinTempIndicator, "AFT cabin temprature indicator");
            }
            if (dualBleedIndicator.Offset.ValueChanged)
            {
                App.UI.BuildIndicatorTextBox(dualBleedTextBox, dualBleedIndicator, "Dual bleed indicator");
            }
            if (leftRamDoorIndicator.Offset.ValueChanged)
            {
                App.UI.BuildIndicatorTextBox(leftRamDoorTextBox, leftRamDoorIndicator, "Left ram door indicator");
            }
            if (rightRamDoorIndicator.Offset.ValueChanged)
            {
                App.UI.BuildIndicatorTextBox(rightRamDoorTextBox, rightRamDoorIndicator, "Right ram door indicator");
            }
            if (leftPackTripIndicator.Offset.ValueChanged)
            {
                App.UI.BuildIndicatorTextBox(leftPackTripTextBox, leftPackTripIndicator, "Left pack trip indicator");
            }
            if (rightPackTripIndicator.Offset.ValueChanged)
            {
                App.UI.BuildIndicatorTextBox(rightPackTripTextBox, rightPackTripIndicator, "Right pack trip indicator");
            }
            if (leftWingOverheatIndicator.Offset.ValueChanged)
            {
                App.UI.BuildIndicatorTextBox(leftWingOverheatTextBox, leftWingOverheatIndicator, "Left wing overheat indicator");
            }
            if (rightWingOverheatIndicator.Offset.ValueChanged)
            {
                App.UI.BuildIndicatorTextBox(rightWingOverheatTextBox, rightWingOverheatIndicator, "Right wing overheat indicator");
            }
            if (leftBleedTripIndicator.Offset.ValueChanged)
            {
                App.UI.BuildIndicatorTextBox(leftBleedTripTextBox, leftBleedTripIndicator, "Left bleed trip indicator");
            }
            if (rightBleedTripIndicator.Offset.ValueChanged)
            {
                App.UI.BuildIndicatorTextBox(rightBleedTripTextBox, rightBleedTripIndicator, "Right bleed trip indicator");
            }
            #endregion
                                }

    }
}
