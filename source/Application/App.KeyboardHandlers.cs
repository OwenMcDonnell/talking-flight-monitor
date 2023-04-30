using DavyKager;
using NHotkey.WindowsForms;
using NHotkey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm
{
    public partial class App: System.Windows.Application
    {

        // list to store registered hotkey identifiers
        readonly List<string> hotkeys = new List<string>();
        readonly List<string> autopilotHotkeys = new List<string>();

        bool _TFMKeysEnabled = false;

        public bool TFMKeysEnabled { get => _TFMKeysEnabled; set => _TFMKeysEnabled = value; }

        private void OnTFMKeysActivation(object? Sender, HotkeyEventArgs e)
        {
            // Toggle the TFM keys enabled flag.
            TFMKeysEnabled = !TFMKeysEnabled;

            if (TFMKeysEnabled)
            {
                Tolk.Output("TFM keys enabled.");
                // Register TFM key commands.
            }
            else
            {
                Tolk.Output("TFM keys disabled.");

                // Unregister TFM key commands.
            }
        }

        private void OnTFMQuit(object? Sender, HotkeyEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void RegisterTFMGlobalCommands()
        {
            HotkeyManager.Current.AddOrReplace("TFMGlobalToggle", Keys.T | Keys.Control | Keys.Alt, OnTFMKeysActivation);
            HotkeyManager.Current.AddOrReplace("TFMQuitCommand", Keys.X | Keys.Control | Keys.Shift, OnTFMQuit);
        }


    }
}
