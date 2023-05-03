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
        public static readonly RoutedUICommand focusCDUDisplay = new RoutedUICommand("Focus CDU display", "FocusCDUDisplay", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.Home, ModifierKeys.Alt) });
        public static readonly RoutedUICommand focusScratchpad = new RoutedUICommand("Focus scratchpad", "FocusScratchpad", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.S, ModifierKeys.Alt) });
        public static readonly RoutedUICommand focusLineSelectMode = new RoutedUICommand("Focus line select mode", "FocusLineSelectMode", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.A, ModifierKeys.Alt) });
        public static readonly RoutedUICommand initRefPage = new RoutedUICommand("Move to INIT-REF page", "MoveToINIT-REFPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.I, ModifierKeys.Alt) });
        public static readonly RoutedUICommand rtePage = new RoutedUICommand("Move to RTE page", "MoveToRTEPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.T, ModifierKeys.Alt) });
        public static readonly RoutedUICommand clbPage = new RoutedUICommand("Move to CLB page", "MoveToCLBPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.B, ModifierKeys.Alt) });
        public static readonly RoutedUICommand crzPage = new RoutedUICommand("Move to CRZ page", "MoveToCRZPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.Z, ModifierKeys.Alt) });
        public static readonly RoutedUICommand legsPage = new RoutedUICommand("Move to LEGS page", "MoveToLEGSPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.G, ModifierKeys.Alt) });
        public static readonly RoutedUICommand depArPage = new RoutedUICommand("Move to DEP-AR page", "MoveToDEP-ARPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.D, ModifierKeys.Alt) });
        public static readonly RoutedUICommand holdPage = new RoutedUICommand("Move to HOLD page", "MoveToHOLDPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.H, ModifierKeys.Alt) });
        public static readonly RoutedUICommand progPage = new RoutedUICommand("Move to PROG page", "MoveToPROGPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.P, ModifierKeys.Alt) });
        public static readonly RoutedUICommand n1Page = new RoutedUICommand("Move to N1 page", "MoveToN1Page", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.N, ModifierKeys.Alt) });
        public static readonly RoutedUICommand fixPage = new RoutedUICommand("Move to FIX page", "MoveToFIXPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.F, ModifierKeys.Alt) });
        public static readonly RoutedUICommand previousPage = new RoutedUICommand("Move to previous page", "MoveToPreviousPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.PageUp) });
        public static readonly RoutedUICommand nextPage = new RoutedUICommand("Move to next page", "MoveToNextPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.PageDown) });
        public static readonly RoutedUICommand menuPage = new RoutedUICommand("Move to MENU page", "MoveToMENUPage", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.M, ModifierKeys.Alt) });
        public static readonly RoutedUICommand executeCDUAction = new RoutedUICommand("Execute CDU action", "ExecuteCDUAction", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.E, ModifierKeys.Alt) });
        public static readonly RoutedUICommand clearScratchpad = new RoutedUICommand("Clear scratchpad", "ClearScratchpad", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.C, ModifierKeys.Alt) });
        public static readonly RoutedUICommand refreshCDU = new RoutedUICommand("Refresh CDU", "RefreshCDU", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.R, ModifierKeys.Alt) });
        public static readonly RoutedUICommand deleteCDUAction = new RoutedUICommand("Send CDU DELETE key", "SendCDUDELETEKey", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.X, ModifierKeys.Alt) });
        public static readonly RoutedUICommand changeLineSelectKeys = new RoutedUICommand("Change line select keys", "ChangeLineSelectKeys", typeof(CDUKeyCommands), new InputGestureCollection { new KeyGesture(Key.L, ModifierKeys.Control) });
    }
}
