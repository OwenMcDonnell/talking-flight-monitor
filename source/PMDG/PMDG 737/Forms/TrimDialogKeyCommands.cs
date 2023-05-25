using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace tfm.PMDG.PMDG_737.Forms
{
    public static class TrimDialogKeyCommands
    {

        public static readonly RoutedUICommand commandBindingHelp = new RoutedUICommand("Get command help", "Get command help", typeof(TrimDialogKeyCommands), new InputGestureCollection { new KeyGesture(Key.F1, ModifierKeys.None) });
        public static readonly RoutedUICommand focusElevatorTrim = new RoutedUICommand("Focus trim indicator", "Focus trim indicator", typeof(TrimDialogKeyCommands), new InputGestureCollection { new KeyGesture(Key.T, ModifierKeys.Alt) });
        public static readonly RoutedUICommand focusAileronTrim = new RoutedUICommand("Focus aileron trim indicator", "Focus aileron trim indicator", typeof(TrimDialogKeyCommands), new InputGestureCollection { new KeyGesture(Key.A, ModifierKeys.Alt) });
        public static readonly RoutedUICommand focusStabTrim = new RoutedUICommand("Focus stab trim indicator", "Focus stab trim indicator", typeof(TrimDialogKeyCommands), new InputGestureCollection { new KeyGesture(Key.B, ModifierKeys.Alt) });
        public static readonly RoutedUICommand ElectricalTrim = new RoutedUICommand("Activate electrical trim", "Activate electrical trim", typeof(TrimDialogKeyCommands), new InputGestureCollection { new KeyGesture(Key.E, ModifierKeys.Alt) });
        public static readonly RoutedUICommand autoPilotTrim = new RoutedUICommand("Activate auto pilot trim", "Activate auto pilot trim", typeof(TrimDialogKeyCommands), new InputGestureCollection { new KeyGesture(Key.U, ModifierKeys.Alt) });
        public static readonly RoutedUICommand stabTrim = new RoutedUICommand("Activate stab trim", "Activate stab trim", typeof(TrimDialogKeyCommands), new InputGestureCollection { new KeyGesture(Key.S, ModifierKeys.Alt) });
        public static readonly RoutedUICommand FocusOutOfTrimIndicator = new RoutedUICommand("Focus stab out of trim indicator", "Focus out of stab indicator", typeof(TrimDialogKeyCommands), new InputGestureCollection { new KeyGesture(Key.O, ModifierKeys.Alt) });
        public static readonly RoutedUICommand increaseElevatorTrim = new RoutedUICommand("Increase elevator trim", "Increase elevator trim", typeof(TrimDialogKeyCommands), new InputGestureCollection { new KeyGesture(Key.OemPlus, ModifierKeys.None) });
        public static readonly RoutedUICommand decreaseElevatorTrim = new RoutedUICommand("Decrease elevator trim", "Decrease elevator trim", typeof(TrimDialogKeyCommands), new InputGestureCollection { new KeyGesture(Key.OemMinus, ModifierKeys.None) });
        public static readonly RoutedUICommand aileronTrimLeft = new RoutedUICommand("Aileron trim left", "Aileron trim left", typeof(TrimDialogKeyCommands), new InputGestureCollection { new KeyGesture(Key.OemMinus, ModifierKeys.Shift) });
        public static readonly RoutedUICommand aileronTrimRight = new RoutedUICommand("Aileron trim right", "Aileron trim right", typeof(TrimDialogKeyCommands), new InputGestureCollection { new KeyGesture(Key.OemPlus, ModifierKeys.Shift) });
    }
}
