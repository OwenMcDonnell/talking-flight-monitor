﻿using System;
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

        // Speed window.
        #region "Speed"
        public static readonly RoutedUICommand focusSpeedInput = new RoutedUICommand("Focus speed input", "FocusSpeedInput", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.E, ModifierKeys.Alt) });
        public static readonly RoutedUICommand focusSpeedBrake = new RoutedUICommand("Focus speed brake", "FocusSpeedBrake", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.K, ModifierKeys.Alt) });
        public static readonly RoutedUICommand focusAutoBrake = new RoutedUICommand("Focus auto brake", "FocusAutoBrake", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.T, ModifierKeys.Alt) });
        public static readonly RoutedUICommand speedIntervene = new RoutedUICommand("Activate speed intervene", "ActivateSpeedIntervene", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.I, ModifierKeys.Alt) });
        public static readonly RoutedUICommand changeOver = new RoutedUICommand("Toggle between IAS or Mach speed", "ChangeOver", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.C, ModifierKeys.Alt) });
        public static readonly RoutedUICommand autoThrottle = new RoutedUICommand("Toggle auto throttle", "AutoThrottle", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.U, ModifierKeys.Alt) });
        public static readonly RoutedUICommand n1Selector = new RoutedUICommand("N1 selector", "N1Selector", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.L, ModifierKeys.Alt) });
        public static readonly RoutedUICommand n1Switch = new RoutedUICommand("Toggle N1", "ToggleN1", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.N, ModifierKeys.Alt) });
        public static readonly RoutedUICommand speedSwitch = new RoutedUICommand("Toggle speed hold", "ToggleSpeedHold", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.S, ModifierKeys.Alt) });
        public static readonly RoutedUICommand autoThrottleDisengage = new RoutedUICommand("Disengage auto throttle", "AutoThrottleDisengage", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.D, ModifierKeys.Alt) });
        public static readonly RoutedUICommand spoilerA = new RoutedUICommand("Toggle spoiler A", "ToggleSpoilerA", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.A, ModifierKeys.Alt) });
        public static readonly RoutedUICommand spoilerB = new RoutedUICommand("Toggle spoiler A", "ToggleSpoilerB", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.B, ModifierKeys.Alt) });
        public static readonly RoutedUICommand increaseSpeedBrake = new RoutedUICommand("Increase speed brake", "IncreaseSpeedBrake", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.OemPlus, ModifierKeys.None) });
        public static readonly RoutedUICommand decreaseSpeedBrake = new RoutedUICommand("Decrease speed brake", "DecreaseSpeedBrake", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.OemMinus, ModifierKeys.None) });
        public static readonly RoutedUICommand armSpeedBrake = new RoutedUICommand("Arm speed brake", "ArmSpeedBrake", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.A, ModifierKeys.Control | ModifierKeys.Shift) });
        public static readonly RoutedUICommand fltSpeedBrake = new RoutedUICommand("Flt speed brake", "FltSpeedBrake", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.F, ModifierKeys.Control) });
        public static readonly RoutedUICommand fullSpeedBrake = new RoutedUICommand("Full speed brake", "FullSpeedBrake", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.U, ModifierKeys.Control) });
        public static readonly RoutedUICommand halfSpeedBrake = new RoutedUICommand("Half speed brake", "HalfSpeedBrake", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.H, ModifierKeys.Control) });
        public static readonly RoutedUICommand speedBrakeOff = new RoutedUICommand("Speed brake off", "SpeedBrakeOff", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.O, ModifierKeys.Control | ModifierKeys.Shift) });
        public static readonly RoutedUICommand autoBrakeOff = new RoutedUICommand("Auto brake off", "AutoBrakeOff", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.O, ModifierKeys.Control) });
        public static readonly RoutedUICommand autoBrakeRTO = new RoutedUICommand("Auto brake RTO", "AutoBrakeRTO", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.R, ModifierKeys.Control) });
        public static readonly RoutedUICommand autoBrakeDisarm = new RoutedUICommand("Auto brake disarm", "AutoBrakeDisarm", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.D, ModifierKeys.Control) });
        public static readonly RoutedUICommand autoBrake1 = new RoutedUICommand("Auto brake 1", "AutoBrake1", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.D1, ModifierKeys.Control) });
        public static readonly RoutedUICommand autoBrake2 = new RoutedUICommand("Auto brake 2", "AutoBrake2", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.D2, ModifierKeys.Control) });
        public static readonly RoutedUICommand autoBrake3 = new RoutedUICommand("Auto brake 3", "AutoBrake3", typeof(MCPKeyCommands), new InputGestureCollection { new KeyGesture(Key.D3, ModifierKeys.Control) });
                #endregion
    }
}