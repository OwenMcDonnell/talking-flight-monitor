using FSUIPC;
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
using UserControl = System.Windows.Controls.UserControl;
using System.Windows.Threading;


namespace tfm.PMDG.PMDG_737.CockpitPanels
{
        public partial class OverheadAntiIce : UserControl
    {

        // Controls
        #region
private        SingleStateToggle leftSideWindowHeatSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_WindowHeatSw[0]).First() as SingleStateToggle;
private        SingleStateToggle leftForwardWindowHeatSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_WindowHeatSw[1]).First() as SingleStateToggle;
private        SingleStateToggle rightForwardWindowHeatSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_WindowHeatSw[2]).First() as SingleStateToggle;
private        SingleStateToggle rightSideWindowHeatSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_WindowHeatSw[3]).First() as SingleStateToggle;
private        SingleStateToggle wingAntiIceSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_WingAntiIceSw).First() as SingleStateToggle;
private        SingleStateToggle leftEngineAntiIceSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_EngAntiIceSw[0]).First() as SingleStateToggle;
private        SingleStateToggle rightEngineAntiIceSwitch = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_EngAntiIceSw[1]).First() as SingleStateToggle;

                SingleStateToggle leftWindowHeatIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_annunON[0]).First() as SingleStateToggle;
        private        SingleStateToggle leftForwardWindowHeatIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_annunON[1]).First() as SingleStateToggle;
private        SingleStateToggle rightForwardWindowHeatIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_annunON[2]).First() as SingleStateToggle;
private        SingleStateToggle rightWindowHeatIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_annunON[3]) as SingleStateToggle;
private        SingleStateToggle leftWindowOverheatIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_annunOVERHEAT[0]).First() as SingleStateToggle;
private        SingleStateToggle leftForwardWindowOverheatIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_annunOVERHEAT[1]).First() as SingleStateToggle;
private        SingleStateToggle rightForwardWindowOverheatIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_annunOVERHEAT[2]).First() as SingleStateToggle;
private        SingleStateToggle rightWindowOverheatIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_annunOVERHEAT[3]).First() as SingleStateToggle;
private        SingleStateToggle captainPitotHeatIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_annunCAPT_PITOT).First() as SingleStateToggle;
private        SingleStateToggle firstOfficerPitotHeatIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_annunFO_PITOT).First() as SingleStateToggle;
private        SingleStateToggle captainElevatorPitotHeatIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_annunL_ELEV_PITOT).First() as SingleStateToggle;
private        SingleStateToggle firstOfficerElevatorPitotHeatIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_annunR_ELEV_PITOT).First() as SingleStateToggle;
private        SingleStateToggle captainAlphaVaneIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_annunL_ALPHA_VANE).First() as SingleStateToggle;
private        SingleStateToggle firstOfficerAlphaVaneIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_annunR_ALPHA_VANE).First() as SingleStateToggle;
private        SingleStateToggle tempProbeIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_annunL_TEMP_PROBE).First() as SingleStateToggle;
private        SingleStateToggle auxPitotIndicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_annunAUX_PITOT).First() as SingleStateToggle;
private        SingleStateToggle valve1Indicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_annunVALVE_OPEN[0]).First() as SingleStateToggle;
private        SingleStateToggle valve2Indicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_annunVALVE_OPEN[1]).First() as SingleStateToggle;
private        SingleStateToggle cowlAntiIce1Indicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_annunCOWL_ANTI_ICE[0]).First() as SingleStateToggle;
private        SingleStateToggle cowlAntiIce2Indicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_annunCOWL_ANTI_ICE[1]).First() as SingleStateToggle;
private        SingleStateToggle cowlValve1Indicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_annunCOWL_VALVE_OPEN[0]).First() as SingleStateToggle;
private        SingleStateToggle cowlValve2Indicator = PMDG737Aircraft.PanelControls.Where(x => x.Offset == Aircraft.pmdg737.ICE_annunCOWL_VALVE_OPEN[1]).First() as SingleStateToggle;
#endregion  

        public OverheadAntiIce()
        {
            InitializeComponent();
            }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(300),
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
                    
        App.UI.BuildToggleButton(leftSideWHToggleButton, leftSideWindowHeatSwitch, "Left side");
                    App.UI.BuildToggleButton(leftForwardWHToggleButton, leftForwardWindowHeatSwitch, "Left forward");
                    App.UI.BuildToggleButton(rightForwardWHToggleButton, rightForwardWindowHeatSwitch, "Right forward");
                    App.UI.BuildToggleButton(rightSideWHToggleButton, rightSideWindowHeatSwitch, "Right side");
                    App.UI.BuildToggleButton(wingToggleButton, wingAntiIceSwitch);
                    App.UI.BuildToggleButton(leftEngineToggleButton, leftEngineAntiIceSwitch, "#1");
                    App.UI.BuildToggleButton(rightEngineToggleButton, rightEngineAntiIceSwitch, "#2");
                    if (leftWindowHeatIndicator.Offset.ValueChanged)
                    {
                        leftSideWindowHeatTextBox.Text = leftWindowHeatIndicator.Name;
                    }
                    
                    /*
                    App.UI.BuildIndicatorTextBox(leftForwardWindowHeatTextBox, leftForwardWindowHeatIndicator);
                    App.UI.BuildIndicatorTextBox(rightForwardWindowHeatTextBox, rightForwardWindowHeatIndicator);
                    App.UI.BuildIndicatorTextBox(rightSideWindowHeatTextBox, rightWindowHeatIndicator);
                   App.UI.BuildIndicatorTextBox(leftSideWindowOverheatTextBox, leftWindowOverheatIndicator);
                    App.UI.BuildIndicatorTextBox(leftForwardWindowOverheatTextBox, leftForwardWindowOverheatIndicator);
                    App.UI.BuildIndicatorTextBox(rightForwardWindowOverheatTextBox, rightForwardWindowOverheatIndicator);
                    App.UI.BuildIndicatorTextBox(rightSideWindowOverheatTextBox, rightWindowOverheatIndicator);
                    App.UI.BuildIndicatorTextBox(captainPitotHeatTextBox, captainPitotHeatIndicator);
                    App.UI.BuildIndicatorTextBox(firstOfficerPitotHeatTextBox, firstOfficerPitotHeatIndicator);
                    App.UI.BuildIndicatorTextBox(captainElevatorPitotHeatTextBox, captainElevatorPitotHeatIndicator);
                    App.UI.BuildIndicatorTextBox(firstOfficerElevatorPitotHeatTextBox, firstOfficerElevatorPitotHeatIndicator);
                    App.UI.BuildIndicatorTextBox(captainAlphaVaneTextBox, captainAlphaVaneIndicator);
                    App.UI.BuildIndicatorTextBox(firstOfficerAlphaVaneTextBox, firstOfficerAlphaVaneIndicator);
                    App.UI.BuildIndicatorTextBox(TempProbeTextBox, tempProbeIndicator);
                    App.UI.BuildIndicatorTextBox(auxPitotTextBox, auxPitotIndicator);
                    App.UI.BuildIndicatorTextBox(valve1TextBox, valve1Indicator);
                    App.UI.BuildIndicatorTextBox(valve2TextBox, valve2Indicator);
                    App.UI.BuildIndicatorTextBox(antiIceCowl1TextBox, cowlAntiIce1Indicator);
                    App.UI.BuildIndicatorTextBox(antiIceCowl2TextBox, cowlAntiIce2Indicator);
                    App.UI.BuildIndicatorTextBox(cowlValve1TextBox, cowlValve1Indicator);
                    App.UI.BuildIndicatorTextBox(cowlValve2TextBox, cowlValve2Indicator);
                    */
                }); 
            });

        }
    }
}
