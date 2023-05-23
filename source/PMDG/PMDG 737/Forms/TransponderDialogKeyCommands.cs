using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace tfm.PMDG.PMDG_737.Forms
{
    public static class TransponderDialogKeyCommands
    {
        public static readonly RoutedUICommand focusTransponderCodeInput = new RoutedUICommand("Focus transponder code input", "Focus transponder code input", typeof(TransponderDialogKeyCommands), new InputGestureCollection { new KeyGesture(Key.E, ModifierKeys.Alt) });
        public static readonly RoutedUICommand cycleSource = new RoutedUICommand("Cycle transponder source", "Cycle transponder source", typeof(TransponderDialogKeyCommands), new InputGestureCollection { new KeyGesture(Key.S, ModifierKeys.Alt) });
        public static readonly RoutedUICommand cycleAlternateSource = new RoutedUICommand("Cycle alternate transponder source", "Cycle alternate transponder source", typeof(TransponderDialogKeyCommands), new InputGestureCollection { new KeyGesture(Key.A, ModifierKeys.Alt) });
        public static readonly RoutedUICommand cycleModes = new RoutedUICommand("Cycle transponder modes", "Cycle transponder modes", typeof(TransponderDialogKeyCommands), new InputGestureCollection { new KeyGesture(Key.M, ModifierKeys.Alt) });
        public static readonly RoutedUICommand activateIdent = new RoutedUICommand("Activate transponder ident", "Activate transponder ident", typeof(TransponderDialogKeyCommands), new InputGestureCollection { new KeyGesture(Key.I, ModifierKeys.Alt) });
        public static readonly RoutedUICommand activateTests = new RoutedUICommand("Activate transponder testsinput", "Activate transponder tests", typeof(TransponderDialogKeyCommands), new InputGestureCollection { new KeyGesture(Key.T, ModifierKeys.Alt) });
        public static readonly RoutedUICommand focusFailureLight = new RoutedUICommand("Focus transponder failure light", "Focus transponder failure light", typeof(TransponderDialogKeyCommands), new InputGestureCollection { new KeyGesture(Key.F, ModifierKeys.Alt) });
        public static readonly RoutedUICommand commandBindingHelp = new RoutedUICommand("Get command help", "Get command help", typeof(TransponderDialogKeyCommands), new InputGestureCollection { new KeyGesture(Key.F1, ModifierKeys.None) });
    }
}
