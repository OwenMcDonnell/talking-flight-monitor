using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using tfm.PMDG.PMDG_737.McpComponents;

namespace tfm.PMDG.PMDG_737.Forms
{
    public static class CDUKeyCommands
    {
        public static readonly RoutedUICommand commandBindingHelp = new RoutedUICommand("Get command help", "Get command help", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F1, ModifierKeys.Control | ModifierKeys.Shift) });
        // Keyboard commands for the FMC window.

        // Constant key commands.
        #region "Constant commands"
        public static readonly RoutedUICommand focusCDUDisplay = new RoutedUICommand("Focus CDU display", "Focus CDU display", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.Home, ModifierKeys.Alt) });
        public static readonly RoutedUICommand focusScratchpad = new RoutedUICommand("Focus scratchpad", "Focus scratchpad", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.S, ModifierKeys.Alt) });
        public static readonly RoutedUICommand focusLineSelectMode = new RoutedUICommand("Focus line select mode", "Focus line select mode indicator", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.L, ModifierKeys.Alt) });
        public static readonly RoutedUICommand initRefPage = new RoutedUICommand("Move to INIT-REF page", "Activate INIT-REF page", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.I, ModifierKeys.Alt) });
        public static readonly RoutedUICommand rtePage = new RoutedUICommand("Move to RTE page", "Activate RTE page", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.T, ModifierKeys.Alt) });
        public static readonly RoutedUICommand clbPage = new RoutedUICommand("Move to CLB page", "Activate CLB page", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.B, ModifierKeys.Alt) });
        public static readonly RoutedUICommand crzPage = new RoutedUICommand("Move to CRZ page", "Activate CRZ page", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.Z, ModifierKeys.Alt) });
        public static readonly RoutedUICommand desPage = new RoutedUICommand("Move to DES page", "Activate DES page", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D, ModifierKeys.Alt) });
        public static readonly RoutedUICommand legsPage = new RoutedUICommand("Move to LEGS page", "Activate LEGS page", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.G, ModifierKeys.Alt) });
        public static readonly RoutedUICommand depArPage = new RoutedUICommand("Move to DEP-AR page", "Activate DEP-AR page", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.A, ModifierKeys.Alt) });
        public static readonly RoutedUICommand holdPage = new RoutedUICommand("Move to HOLD page", "Activate HOLD page", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.H, ModifierKeys.Alt) });
        public static readonly RoutedUICommand progPage = new RoutedUICommand("Move to PROG page", "Activate PROG page", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.P, ModifierKeys.Alt) });
        public static readonly RoutedUICommand n1Page = new RoutedUICommand("Move to N1 page", "Activate N1 page", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.N, ModifierKeys.Alt) });
        public static readonly RoutedUICommand fixPage = new RoutedUICommand("Move to FIX page", "Activate FIX page", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F, ModifierKeys.Alt) });
        public static readonly RoutedUICommand previousPage = new RoutedUICommand("Move to previous page", "Activate previous page", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.Up, ModifierKeys.Alt) });
        public static readonly RoutedUICommand nextPage = new RoutedUICommand("Move to next page", "Activate next page", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.Down, ModifierKeys.Alt) });
        public static readonly RoutedUICommand menuPage = new RoutedUICommand("Move to MENU page", "Activate MENU page", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.M, ModifierKeys.Alt) });
        public static readonly RoutedUICommand executeCDUAction = new RoutedUICommand("Execute CDU action", "Execute CDU action", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.E, ModifierKeys.Alt) });
        public static readonly RoutedUICommand clearScratchpad = new RoutedUICommand("Clear scratchpad", "Clear scratchpad", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.C, ModifierKeys.Alt) });
        public static readonly RoutedUICommand refreshCDU = new RoutedUICommand("Refresh CDU", "Refresh CDU display", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.R, ModifierKeys.Alt) });
        public static readonly RoutedUICommand deleteCDUAction = new RoutedUICommand("Send CDU DELETE key", "Activate the DELETE key", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.X, ModifierKeys.Alt) });
        public static readonly RoutedUICommand changeLineSelectKeys = new RoutedUICommand("Change line select keys", "Toggle line select key modes", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.L, ModifierKeys.Control) });
        #endregion

        // Default line select keys: ctrl/alt 1-6.
        #region "Default line select keys"

        // Left side.
        #region "Left side"
        public static readonly RoutedUICommand lsk1Left = new RoutedUICommand("Line select 1 left", "Lsk 1-left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D1, ModifierKeys.Control) });
        public static readonly RoutedUICommand lsk2Left = new RoutedUICommand("Line select 2 left", "Lsk 2-left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D2, ModifierKeys.Control) });
        public static readonly RoutedUICommand lsk3Left = new RoutedUICommand("Line select 3 left", "Lsk 3-left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D3, ModifierKeys.Control) });
        public static readonly RoutedUICommand lsk4Left = new RoutedUICommand("Line select 4 left", "Lsk 4-left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D4, ModifierKeys.Control) });
        public static readonly RoutedUICommand lsk5Left = new RoutedUICommand("Line select 5 left", "Lsk 5-left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D5, ModifierKeys.Control) });
        public static readonly RoutedUICommand lsk6Left = new RoutedUICommand("Line select 6 left", "Lsk 6-left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D6, ModifierKeys.Control) });
        #endregion

        // Right side.
        #region "Right side"
        public static readonly RoutedUICommand lsk1Right = new RoutedUICommand("Line select 1 right", "Lsk1-right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D1, ModifierKeys.Alt) });
        public static readonly RoutedUICommand lsk2Right = new RoutedUICommand("Line select 2 right", "Lsk 2-right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D2, ModifierKeys.Alt) });
        public static readonly RoutedUICommand lsk3Right = new RoutedUICommand("Line select 3 right", "Lsk 3-right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D3, ModifierKeys.Alt) });
        public static readonly RoutedUICommand lsk4Right = new RoutedUICommand("Line select 4 right", "Lsk 4-right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D4, ModifierKeys.Alt) });
        public static readonly RoutedUICommand lsk5Right = new RoutedUICommand("Line select 5 right", "Lsk5-right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D5, ModifierKeys.Alt) });
        public static readonly RoutedUICommand lsk6Right = new RoutedUICommand("Line select 6 right", "Lsk6-right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D6, ModifierKeys.Alt) });
        #endregion
        #endregion

        // Alternate line select keys: F1-F12.
        #region "Alternate line select keys"

        // Left side.
        #region "Left side"
        public static readonly RoutedUICommand altLsk1Left = new RoutedUICommand("Alternate line select 1 left", "Lsk 1-left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F1, ModifierKeys.None) });
        public static readonly RoutedUICommand altLsk2Left = new RoutedUICommand("Alternate line select 2 left", "Lsk 2-left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F2, ModifierKeys.None) });
        public static readonly RoutedUICommand altLsk3Left = new RoutedUICommand("Alternate line select 3 left", "Lsk 3-left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F3, ModifierKeys.None) });
        public static readonly RoutedUICommand altLsk4Left = new RoutedUICommand("Alternate line select 4 left", "Lsk 4-left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F4, ModifierKeys.None) });
        public static readonly RoutedUICommand altLsk5Left = new RoutedUICommand("Alternate line select 5 left", "Lsk 5-left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F5, ModifierKeys.None) });
        public static readonly RoutedUICommand altLsk6Left = new RoutedUICommand("Alternate line select 6 left", "Lsk 6-left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F6, ModifierKeys.None) });
        #endregion

        // Right side.
        #region "Right side"
        public static readonly RoutedUICommand altLsk1Right = new RoutedUICommand("Alternate line select 1 right", "Lsk 1-right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F7, ModifierKeys.None) });
        public static readonly RoutedUICommand altLsk2Right = new RoutedUICommand("Alternate line select 2 right", "Lsk 2-right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F8, ModifierKeys.None) });
        public static readonly RoutedUICommand altLsk3Right = new RoutedUICommand("Alternate line select 3 right", "Lsk 3-right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F9, ModifierKeys.None) });
        public static readonly RoutedUICommand altLsk4Right = new RoutedUICommand("Alternate line select 4 right", "Lsk 4-right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F10, ModifierKeys.None) });
        public static readonly RoutedUICommand altLsk5Right = new RoutedUICommand("Alternate line select 5 right", "Lsk 5-right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F11, ModifierKeys.None) });
        public static readonly RoutedUICommand altLsk6Right = new RoutedUICommand("Alternate line select 6 right", "Lsk 6-right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F12, ModifierKeys.None) });
        #endregion
        #endregion
    }
}
