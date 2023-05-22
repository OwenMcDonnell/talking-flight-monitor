using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using tfm.PMDG.PMDG_737.Forms;

namespace tfm.PMDG.PMDG_737.McpComponents
{
    public static class MCPKeyCommands
    {
        public static readonly RoutedUICommand commandBindingHelp = new RoutedUICommand("Get command help", "Get command help", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.F1, ModifierKeys.None) });

        // Altitude window
        #region "Altitude"
        public static readonly RoutedUICommand focusAltitudeInput = new RoutedUICommand("Focus altitude input", "Focus altitude input", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.E, ModifierKeys.Alt) });
        public static readonly RoutedUICommand altitudeIntervene = new RoutedUICommand("Activate altitude intervene", "Activate altitude intervene", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.I, ModifierKeys.Alt) });
        public static readonly RoutedUICommand toggleVNav = new RoutedUICommand("Toggle V-Nav", "Toggle V-Nav", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.V, ModifierKeys.Alt) });
        public static readonly RoutedUICommand toggleLvlChange = new RoutedUICommand("Toggle level change", "Toggle level change", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.L, ModifierKeys.Alt) });
        public static readonly RoutedUICommand toggleAltitudeHold = new RoutedUICommand("Toggle altitude hold", "Toggle altitude hold", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.H, ModifierKeys.Alt) });
        #endregion

        //Heading
        #region "Heading"
        public static readonly RoutedUICommand focusHeadingInput = new RoutedUICommand("Focus heading input", "Focus heading input", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.E, ModifierKeys.Alt) });
        public static readonly RoutedUICommand toggleHdgSel = new RoutedUICommand("Toggle HDG SEL", "Toggle Hdg sel", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.H, ModifierKeys.Alt) });
        public static readonly RoutedUICommand toggleLNav = new RoutedUICommand("Toggle L-Nav", "Toggle L-Nav", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.L, ModifierKeys.Alt) });
        #endregion

        //Navaids
        #region "Navaids"
        public static readonly RoutedUICommand toggleFDL = new RoutedUICommand("Toggle FD/L", "Toggle FD/L", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.L, ModifierKeys.Alt) });
        public static readonly RoutedUICommand toggleFDR = new RoutedUICommand("Toggle FD/R", "Toggle FD/R", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.R, ModifierKeys.Alt) });
        public static readonly RoutedUICommand toggleCMDA = new RoutedUICommand("Toggle CMD/A", "Toggle CMD/A", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.A, ModifierKeys.Alt) });
        public static readonly RoutedUICommand toggleCMDB = new RoutedUICommand("Toggle CMD/B", "Toggle CMD/B", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.B, ModifierKeys.Alt) });
        public static readonly RoutedUICommand toggleAppMode = new RoutedUICommand("Toggle APP mode", "Toggle approach mode", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.P, ModifierKeys.Alt) });
        public static readonly RoutedUICommand cycleBankLimit = new RoutedUICommand("Cycle bank limit", "Cycle bank limit", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.K, ModifierKeys.Alt) });
        public static readonly RoutedUICommand toggleVorLoc = new RoutedUICommand("Toggle VOR/LOC", "Toggle VOR/LOC hold", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.V, ModifierKeys.Alt) });
        public static readonly RoutedUICommand toggleCWSA = new RoutedUICommand("Toggle CWS/A", "Toggle CWS/A", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.C, ModifierKeys.Alt) });
        public static readonly RoutedUICommand toggleCWSB = new RoutedUICommand("Toggle CWS/B", "Toggle CWS/B", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.W, ModifierKeys.Alt) });
        public static readonly RoutedUICommand toggleDisengageBar = new RoutedUICommand("Toggle disengage bar", "Toggle disengage bar", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.I, ModifierKeys.Alt) });
        public static readonly RoutedUICommand disconnectAutoPilot = new RoutedUICommand("Disconnect autopilot", "Disconnect auto pilot", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.D, ModifierKeys.Alt) });
        #endregion

        // Speed window.
        #region "Speed"
        public static readonly RoutedUICommand focusSpeedInput = new RoutedUICommand("Focus speed input", "Focus speed input", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.E, ModifierKeys.Alt) });
        public static readonly RoutedUICommand focusSpeedBrake = new RoutedUICommand("Focus speed brake", "Focus speed brake", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.K, ModifierKeys.Alt) });
        public static readonly RoutedUICommand focusAutoBrake = new RoutedUICommand("Focus auto brake", "Focus auto brake", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.T, ModifierKeys.Alt) });
        public static readonly RoutedUICommand speedIntervene = new RoutedUICommand("Activate speed intervene", "Activate speed intervene", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.I, ModifierKeys.Alt) });
        public static readonly RoutedUICommand changeOver = new RoutedUICommand("Toggle between IAS or Mach speed", "Activate change over", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.C, ModifierKeys.Alt) });
        public static readonly RoutedUICommand autoThrottle = new RoutedUICommand("Toggle auto throttle", "Toggle auto throttle", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.U, ModifierKeys.Alt) });
        public static readonly RoutedUICommand n1Selector = new RoutedUICommand("N1 selector", "Cycle N1 selector", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.L, ModifierKeys.Alt) });
        public static readonly RoutedUICommand n1Switch = new RoutedUICommand("Toggle N1", "Toggle N1", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.N, ModifierKeys.Alt) });
        public static readonly RoutedUICommand speedSwitch = new RoutedUICommand("Toggle speed hold", "Toggle speed hold", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.S, ModifierKeys.Alt) });
        public static readonly RoutedUICommand autoThrottleDisengage = new RoutedUICommand("Disengage auto throttle", "Disengage auto throttle", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.D, ModifierKeys.Alt) });
        public static readonly RoutedUICommand spoilerA = new RoutedUICommand("Toggle spoiler A", "Toggle spoiler/A", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.A, ModifierKeys.Alt) });
        public static readonly RoutedUICommand spoilerB = new RoutedUICommand("Toggle spoiler A", "Toggle spoiler/B", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.B, ModifierKeys.Alt) });
        public static readonly RoutedUICommand increaseSpeedBrake = new RoutedUICommand("Increase speed brake", "Increase speed brake", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.OemPlus, ModifierKeys.None) });
        public static readonly RoutedUICommand decreaseSpeedBrake = new RoutedUICommand("Decrease speed brake", "Decrease speed brake", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.OemMinus, ModifierKeys.None) });
        public static readonly RoutedUICommand armSpeedBrake = new RoutedUICommand("Arm speed brake", "Arm speed brake", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.A, ModifierKeys.Control | ModifierKeys.Shift) });
        public static readonly RoutedUICommand fltSpeedBrake = new RoutedUICommand("Flt speed brake", "Set speed brake to FLT", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.F, ModifierKeys.Control) });
        public static readonly RoutedUICommand fullSpeedBrake = new RoutedUICommand("Full speed brake", "Speed brake 100%", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.U, ModifierKeys.Control) });
        public static readonly RoutedUICommand halfSpeedBrake = new RoutedUICommand("Half speed brake", "Speed brake 50%", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.H, ModifierKeys.Control) });
        public static readonly RoutedUICommand speedBrakeOff = new RoutedUICommand("Speed brake off", "Speed brake off", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.O, ModifierKeys.Control | ModifierKeys.Shift) });
        public static readonly RoutedUICommand autoBrakeOff = new RoutedUICommand("Auto brake off", "Auto brake off", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.O, ModifierKeys.Control) });
        public static readonly RoutedUICommand autoBrakeRTO = new RoutedUICommand("Auto brake RTO", "Auto brake RTO", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.R, ModifierKeys.Control) });
        public static readonly RoutedUICommand autoBrakeDisarm = new RoutedUICommand("Auto brake disarm", "Disarm auto brake", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.D, ModifierKeys.Control) });
        public static readonly RoutedUICommand autoBrake1 = new RoutedUICommand("Auto brake 1", "Auto brake 1", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.D1, ModifierKeys.Control) });
        public static readonly RoutedUICommand autoBrake2 = new RoutedUICommand("Auto brake 2", "Auto brake 2", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.D2, ModifierKeys.Control) });
        public static readonly RoutedUICommand autoBrake3 = new RoutedUICommand("Auto brake 3", "Auto brake 3", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.D3, ModifierKeys.Control) });
        #endregion

        // Vertical speed.
        #region "Vertical speed"
        public static readonly RoutedUICommand focusVerticalSpeedInput = new RoutedUICommand("Focus vertical speed input", "Focus vertical speed input", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.E, ModifierKeys.Alt) });
        public static readonly RoutedUICommand toggleVerticalSpeedMode = new RoutedUICommand("Toggle vertical speed mode", "Toggle vertical speed mode", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.V, ModifierKeys.Alt) });
        #endregion
    }
}
