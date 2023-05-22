using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace tfm
{
        public partial class WindowBindingsHelp : Window
    {

        CommandBindingCollection? _commands;
        public WindowBindingsHelp(CommandBindingCollection commands)
        {
            InitializeComponent();
            _commands = commands;
            ListCommandBindings();
            commandDisplayTextBox.Focus();
        }

        private void ListCommandBindings()
        {
            
            foreach (CommandBinding binding in _commands)
            {
                RoutedCommand routedCommand = binding.Command as RoutedCommand;
                if (routedCommand != null)
                {
                    string commandName = routedCommand.Name;
                    commandDisplayTextBox.Text += commandName + ": ";

                    bool isFirstGesture = true;
                    foreach (InputGesture gesture in routedCommand.InputGestures)
                    {
                        if (!isFirstGesture)
                        {
                            commandDisplayTextBox.Text += " + ";
                        }

                        string keyCommandString = GetDisplayStringForGesture(gesture);
                        commandDisplayTextBox.Text += keyCommandString;
                        isFirstGesture = false;
                    }

                    commandDisplayTextBox.Text += "\n";
                }
            }
        }

        private string GetDisplayStringForGesture(InputGesture gesture)
        {
            if (gesture is KeyGesture keyGesture)
            {
                ModifierKeysConverter modifierConverter = new ModifierKeysConverter();
                string modifiers = modifierConverter.ConvertToString(keyGesture.Modifiers);
                string key = string.Empty;
                if(keyGesture.Key.ToString() == "D1")
                {
                    key = "1";
                }
                else if(keyGesture.Key.ToString() == "D2")
                {
                    key = "2";
                }
                else if(keyGesture.Key.ToString() == "D3")
                {
                    key = "3";
                }
                else if(keyGesture.Key.ToString() == "D4")
                {
                    key = "4";
                }
                else if(keyGesture.Key.ToString() == "D5")
                {
                    key = "5";
                }
                else if(keyGesture.Key.ToString() == "D6")
                {
                    key = "6";
                }
                else if(keyGesture.Key.ToString() == "D7")
                {
                    key = "7";
                }
                else if(keyGesture.Key.ToString() == "D8")
                {
                    key = "8";
                }
                else if(keyGesture.Key.ToString() == "D9")
                {
                    key = "9";
                }
                else if(keyGesture.Key.ToString() == "D0")
                {
                    key = "0";
                }
                else
                {
                    key = keyGesture.Key.ToString();
                }
                if (!string.IsNullOrEmpty(modifiers))
                {
                    return modifiers + " + " + key;
                }
                else
                {
                    return key;
                }
            }
            else if (gesture is MouseGesture mouseGesture)
            {
                return mouseGesture.MouseAction.ToString();
            }
            else
            {
                // Handle other gesture types if needed
                return string.Empty;
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
