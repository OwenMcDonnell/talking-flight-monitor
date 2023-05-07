using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace tfm.PMDG.PMDG_737.Forms
{
    public static class CDUKeyCommands
    {

        // Keyboard commands for the FMC window.

        // Constant key commands.
        #region "Constant commands"
        public static readonly RoutedUICommand focusCDUDisplay = new RoutedUICommand("Focus CDU display", "FocusCDUDisplay", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.Home, ModifierKeys.Alt) });
        public static readonly RoutedUICommand focusScratchpad = new RoutedUICommand("Focus scratchpad", "FocusScratchpad", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.S, ModifierKeys.Alt) });
        public static readonly RoutedUICommand focusLineSelectMode = new RoutedUICommand("Focus line select mode", "FocusLineSelectMode", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.L, ModifierKeys.Alt) });
        public static readonly RoutedUICommand initRefPage = new RoutedUICommand("Move to INIT-REF page", "MoveToINIT-REFPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.I, ModifierKeys.Alt) });
        public static readonly RoutedUICommand rtePage = new RoutedUICommand("Move to RTE page", "MoveToRTEPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.T, ModifierKeys.Alt) });
        public static readonly RoutedUICommand clbPage = new RoutedUICommand("Move to CLB page", "MoveToCLBPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.B, ModifierKeys.Alt) });
        public static readonly RoutedUICommand crzPage = new RoutedUICommand("Move to CRZ page", "MoveToCRZPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.Z, ModifierKeys.Alt) });
        public static readonly RoutedUICommand desPage = new RoutedUICommand("Move to DES page", "MoveToDESPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D, ModifierKeys.Alt) });
        public static readonly RoutedUICommand legsPage = new RoutedUICommand("Move to LEGS page", "MoveToLEGSPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.G, ModifierKeys.Alt) });
        public static readonly RoutedUICommand depArPage = new RoutedUICommand("Move to DEP-AR page", "MoveToDEP-ARPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.A, ModifierKeys.Alt) });
        public static readonly RoutedUICommand holdPage = new RoutedUICommand("Move to HOLD page", "MoveToHOLDPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.H, ModifierKeys.Alt) });
        public static readonly RoutedUICommand progPage = new RoutedUICommand("Move to PROG page", "MoveToPROGPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.P, ModifierKeys.Alt) });
        public static readonly RoutedUICommand n1Page = new RoutedUICommand("Move to N1 page", "MoveToN1Page", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.N, ModifierKeys.Alt) });
        public static readonly RoutedUICommand fixPage = new RoutedUICommand("Move to FIX page", "MoveToFIXPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F, ModifierKeys.Alt) });
        public static readonly RoutedUICommand previousPage = new RoutedUICommand("Move to previous page", "MoveToPreviousPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.Up, ModifierKeys.Alt) });
        public static readonly RoutedUICommand nextPage = new RoutedUICommand("Move to next page", "MoveToNextPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.Down, ModifierKeys.Alt) });
        public static readonly RoutedUICommand menuPage = new RoutedUICommand("Move to MENU page", "MoveToMENUPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.M, ModifierKeys.Alt) });
        public static readonly RoutedUICommand executeCDUAction = new RoutedUICommand("Execute CDU action", "ExecuteCDUAction", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.E, ModifierKeys.Alt) });
        public static readonly RoutedUICommand clearScratchpad = new RoutedUICommand("Clear scratchpad", "ClearScratchpad", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.C, ModifierKeys.Alt) });
        public static readonly RoutedUICommand refreshCDU = new RoutedUICommand("Refresh CDU", "RefreshCDU", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.R, ModifierKeys.Alt) });
        public static readonly RoutedUICommand deleteCDUAction = new RoutedUICommand("Send CDU DELETE key", "SendCDUDELETEKey", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.X, ModifierKeys.Alt) });
        public static readonly RoutedUICommand changeLineSelectKeys = new RoutedUICommand("Change line select keys", "ChangeLineSelectKeys", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.L, ModifierKeys.Control) });
        #endregion

        // Default line select keys: ctrl/alt 1-6.
        #region "Default line select keys"

        // Left side.
        #region "Left side"
        public static readonly RoutedUICommand lsk1Left = new RoutedUICommand("Line select 1 left", "Lsk1Left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D1, ModifierKeys.Control) });
        public static readonly RoutedUICommand lsk2Left = new RoutedUICommand("Line select 2 left", "Lsk2Left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D2, ModifierKeys.Control) });
        public static readonly RoutedUICommand lsk3Left = new RoutedUICommand("Line select 3 left", "Lsk3Left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D3, ModifierKeys.Control) });
        public static readonly RoutedUICommand lsk4Left = new RoutedUICommand("Line select 4 left", "Lsk4Left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D4, ModifierKeys.Control) });
        public static readonly RoutedUICommand lsk5Left = new RoutedUICommand("Line select 5 left", "Lsk5Left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D5, ModifierKeys.Control) });
        public static readonly RoutedUICommand lsk6Left = new RoutedUICommand("Line select 6 left", "Lsk6Left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D6, ModifierKeys.Control) });
        #endregion

        // Right side.
        #region "Right side"
        public static readonly RoutedUICommand lsk1Right = new RoutedUICommand("Line select 1 right", "Lsk1Right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D1, ModifierKeys.Alt) });
        public static readonly RoutedUICommand lsk2Right = new RoutedUICommand("Line select 2 right", "Lsk2Right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D2, ModifierKeys.Alt) });
        public static readonly RoutedUICommand lsk3Right = new RoutedUICommand("Line select 3 right", "Lsk3Right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D3, ModifierKeys.Alt) });
        public static readonly RoutedUICommand lsk4Right = new RoutedUICommand("Line select 4 right", "Lsk4Right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D4, ModifierKeys.Alt) });
        public static readonly RoutedUICommand lsk5Right = new RoutedUICommand("Line select 5 right", "Lsk5Right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D5, ModifierKeys.Alt) });
        public static readonly RoutedUICommand lsk6Right = new RoutedUICommand("Line select 6 right", "Lsk6Right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D6, ModifierKeys.Alt) });
        #endregion
        #endregion

        // Alternate line select keys: F1-F12.
        #region "Alternate line select keys"

        // Left side.
        #region "Left side"
        public static readonly RoutedUICommand altLsk1Left = new RoutedUICommand("Alternate line select 1 left", "AltLsk1Left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F1, ModifierKeys.None) });
        public static readonly RoutedUICommand altLsk2Left = new RoutedUICommand("Alternate line select 2 left", "AltLsk2Left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F2, ModifierKeys.None) });
        public static readonly RoutedUICommand altLsk3Left = new RoutedUICommand("Alternate line select 3 left", "AltLsk3Left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F3, ModifierKeys.None) });
        public static readonly RoutedUICommand altLsk4Left = new RoutedUICommand("Alternate line select 4 left", "AltLsk4Left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F4, ModifierKeys.None) });
        public static readonly RoutedUICommand altLsk5Left = new RoutedUICommand("Alternate line select 5 left", "AltLsk5Left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F5, ModifierKeys.None) });
        public static readonly RoutedUICommand altLsk6Left = new RoutedUICommand("Alternate line select 6 left", "AltLsk6Left", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F6, ModifierKeys.None) });
        #endregion

        // Right side.
        #region "Right side"
        public static readonly RoutedUICommand altLsk1Right = new RoutedUICommand("Alternate line select 1 right", "AltLsk1Right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F7, ModifierKeys.None) });
        public static readonly RoutedUICommand altLsk2Right = new RoutedUICommand("Alternate line select 2 right", "AltLsk2Right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F8, ModifierKeys.None) });
        public static readonly RoutedUICommand altLsk3Right = new RoutedUICommand("Alternate line select 3 right", "AltLsk3Right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F9, ModifierKeys.None) });
        public static readonly RoutedUICommand altLsk4Right = new RoutedUICommand("Alternate line select 4 right", "AltLsk4Right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F10, ModifierKeys.None) });
        public static readonly RoutedUICommand altLsk5Right = new RoutedUICommand("Alternate line select 5 right", "AltLsk5Right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F11, ModifierKeys.None) });
        public static readonly RoutedUICommand altLsk6Right = new RoutedUICommand("Alternate line select 6 right", "AltLsk6Right", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F12, ModifierKeys.None) });
        #endregion
        #endregion
    }
}
