using DavyKager;
using NHotkey.WindowsForms;
using NHotkey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSUIPC;
using NAudio.Wave;
using System.Configuration;
using tfm.copilot;

namespace tfm
{
    public partial class App: System.Windows.Application
    {

        // list to store registered hotkey identifiers
        //readonly List<string> hotkeys = new List<string>();
        //readonly List<string> autopilotHotkeys = new List<string>();

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

        private void commandMode(object? sender, HotkeyEventArgs e)
        {
            // Check to see if we are connected to the sim.
            if (FSUIPCConnection.IsOpen || DebugEnabled || helpModeEnabled)
            {
                // remove the left bracket autopilot command
                HotkeyManager.Current.Remove("ap_Command_Key");
                // play the command sound
                cmdSound = new WaveFileReader(@"sounds\command.wav");
                mixer.AddMixerInput(cmdSound);
                if (helpModeEnabled)
                {
                    Speak(rm.GetString("Command_Key"));
                }
                // populate a list of hotkeys, so we can clear them later.
                foreach (SettingsProperty s in tfm.Properties.Hotkeys.Default.Properties)
                {
                    if (s.Name == "Command_Key") continue;
                    if (s.Name.StartsWith("ap_")) continue;
                    hotkeys.Add(s.Name);
                    try
                    {
                        HotkeyManager.Current.AddOrReplace(s.Name, (Keys)tfm.Properties.Hotkeys.Default[s.Name], onKeyPressed);
                    }
                    catch (NHotkey.HotkeyAlreadyRegisteredException ex)
                    {
                        logger.Debug($"Cannot register {s.Name}. Probably duplicated key. {ex.Message}");
                        Output(isGauge: false, output: $"hotkey error in {s.Name}");
                    }

                }




            }
            else
            {
                Tolk.Output("not connected to simulator");

            }

        }

        private void autopilotCommandMode(object? sender, HotkeyEventArgs e)
        {
            // unregister the right bracket command key so it isn't pressed by accident
            HotkeyManager.Current.Remove("Command_Key");
            // Check to see if we are connected to the sim
            if (FSUIPCConnection.IsOpen || DebugEnabled)
            {
                // play the command sound
                // AudioPlaybackEngine.Instance.PlaySound(cmdSound);
                apCmdSound = new WaveFileReader(@"sounds\ap_command.wav");
                mixer.AddMixerInput(apCmdSound);
                if (helpModeEnabled)
                {
                    Speak(rm.GetString("ap_Command_Key"));
                }

                // populate a list of hotkeys, so we can clear them later.
                foreach (SettingsProperty s in tfm.Properties.Hotkeys.Default.Properties)
                {
                    if (s.Name == "Autopilot_Command_Key") continue;
                    if (s.Name.StartsWith("ap_") || s.Name == "toggle_help_mode")
                    {
                        autopilotHotkeys.Add(s.Name);
                        try
                        {
                            HotkeyManager.Current.AddOrReplace(s.Name, (Keys)tfm.Properties.Hotkeys.Default[s.Name], onAutopilotKeyPressed);
                        }
                        catch (NHotkey.HotkeyAlreadyRegisteredException ex)
                        {
                            logger.Debug($"Cannot register {s.Name}. Probably duplicated key.");
                            Output(isGauge: false, output: $"hotkey error in {s.Name}");

                        }
                    }

                }


            }
            else
            {
                Tolk.Output("not connected to simulator. ");

            }

        }

        private void onAutopilotKeyPressed(object? sender, HotkeyEventArgs e)
        {

            e.Handled = true;
            ResetHotkeys();

            if (helpModeEnabled == true)
            {
                if (e.Name == "toggle_help_mode")
                {
                    Output(isGauge: false, output: "Toggle Command help. Exiting help.");
                    helpModeEnabled = false;
                    return;
                }

                Speak(rm.GetString(e.Name));
                return;
            }
            ExecuteAutopilotCommand(e.Name);

        }

        private void ExecuteAutopilotCommand(string Name)
        {
            frmAutopilot ap;
            frmComRadios com;
            frmNavRadios nav;
            frmAltimeter alt;
            string gaugeName;
            string gaugeValue;
            bool isGauge = true;

            switch (Name)
            {
                case "ap_Aircraft_Flows":
                    frmPMDG737Flows frmFlows = new frmPMDG737Flows();
                    frmFlows.ShowDialog();
                    break;

                case "toggle_help_mode":
                    // enabling command help is handled here. Since command functions are bypassed when help is on, we handle turning it off in the key pressed event.
                    if (helpModeEnabled == false)
                    {
                        Output(isGauge: false, output: "Command help enabled");
                        helpModeEnabled = true;
                    }
                    break;

                case "ap_FMCMessage":
                    ReadPmdgFMCMessage("requested");
                    break;
                case "ap_set_spoilers":
                    ap = new frmAutopilot("spoilers");
                    ap.ShowDialog();
                    break;

                case "ap_Get_Altitude":
                    gaugeName = "AP altitude";

                    if (PMDG737Detected)
                    {
                        gaugeValue = PMDG737Aircraft.GetMCPAltitudeComponents();
                        Output(isGauge: false, output: gaugeValue);
                    } // PMDG737
                    else if (PMDG777Detected)
                    {
                        gaugeValue = PMDG777Aircraft.GetMCPAltitudeComponents();
                        Output(isGauge: false, output: gaugeValue);
                    }
                    else
                    {

                        gaugeValue = Autopilot.ApAltitude.ToString();
                        if (Autopilot.ApAltitudeLock) gaugeValue = " hold " + gaugeValue;
                        Output(gaugeName, gaugeValue, isGauge);
                    }
                    break;
                case "ap_Set_Altitude":
                    if (PMDG737Detected)
                    {
                        _PMDG737MCPComponentsManager.ShowAltitudeWindow();
                    } // PMDG 737
                    else if (PMDG747Detected)
                    {
                        if (PMDG747Aircraft.MCPComponents["altitude"].Visible)
                        {
                            Output(isGauge: false, output: "The altitude box is already open!");
                        }
                        else
                        {
                            PMDG747Aircraft.ShowAltitudeBox();
                        }
                    }
                    else if (PMDG777Detected)
                    {
                        if (PMDG777Aircraft.McpComponents["altitude"].Visible)
                        {
                            Output(isGauge: false, output: "The altitude box is already open!");
                        }
                        else
                        {
                            PMDG777Aircraft.ShowAltitudeBox();
                        }
                    } // End PMDG777.
                    else
                    {
                        ap = new frmAutopilot("Altitude");
                        ap.ShowDialog();
                        break;
                    }
                    break;
                case "ap_NavigationBox":

                    if (PMDG737Detected)
                    {
                        _PMDG737MCPComponentsManager.ShowNavaidsWindow();
                    }
                    else if (PMDG747Detected)
                    {
                        if (PMDG747Aircraft.MCPComponents["navigation"].Visible)
                        {
                            Output(isGauge: false, output: "The MCP flight controls window is already open!");
                        }
                        else
                        {
                            PMDG747Aircraft.ShowNavigationBox();
                        }
                    }
                    else if (PMDG777Detected)
                    {
                        if (PMDG777Aircraft.McpComponents["navigation"].Visible)
                        {
                            Output(isGauge: false, output: "The navigation box is already open!");
                        } // navigation box already open.
                        else
                        {
                            PMDG777Aircraft.ShowNavigationBox();
                        } // navigation box is displayed.
                    } // PMDG 777
                    break;
                case "ap_Get_Altimeter":
                    ReadAltimeter(true);
                    break;
                case "ap_Set_Altimeter":
                    alt = new frmAltimeter();
                    alt.ShowDialog();
                    break;

                case "ap_Get_Heading":
                    gaugeName = "AP heading";
                    if (PMDG737Detected)
                    {
                        gaugeValue = PMDG737Aircraft.GetMCPHeadingComponents();
                        Output(isGauge: false, output: gaugeValue);
                    } // PMDG 737
                    else if (PMDG777Detected)
                    {
                        gaugeValue = PMDG777Aircraft.GetMCPHeadingComponents();
                        Output(isGauge: false, output: gaugeValue);
                    }
                    else
                    {
                        gaugeValue = Autopilot.ApHeading.ToString();
                        if (Autopilot.ApHeadingLock) gaugeValue = " hold " + gaugeValue;
                        Output(gaugeName, gaugeValue, isGauge);
                    } // Freeware
                    break;
                case "ap_Set_Heading":
                    if (PMDG737Detected)
                    {
                        _PMDG737MCPComponentsManager.ShowHeadingWindow();
                    }
                    else if (PMDG747Detected)
                    {
                        if (PMDG747Aircraft.MCPComponents["heading"].Visible)
                        {
                            Output(isGauge: false, output: "The heading box is already open!");
                        }
                        else
                        {
                            PMDG747Aircraft.ShowHeadingBox();
                        }
                    }
                    else if (PMDG777Detected)
                    {
                        if (PMDG777Aircraft.McpComponents["heading"].Visible)
                        {
                            Output(isGauge: false, output: "The heading box is already open!");
                        }
                        else
                        {
                            PMDG777Aircraft.McpComponents["heading"].Show();
                        }
                    } // End PMDG777 check.
                    else
                    {
                        ap = new frmAutopilot("Heading");
                        ap.ShowDialog();
                    } // End freeware.
                    break;

                case "ap_Get_Airspeed":
                    gaugeName = "AP airspeed";
                    gaugeValue = string.Empty;
                    if (PMDG737Detected)
                    {
                        if (PMDG737Aircraft.SpeedType == PMDG.AircraftSpeed.Indicated)
                        {
                            gaugeValue = PMDG737Aircraft.GetMCPSpeedComponents();
                            Output(isGauge: false, output: gaugeValue);
                        }
                    } // PMDG737
                    else if (PMDG777Detected)
                    {
                        gaugeValue = PMDG777Aircraft.GetMCPSpeedComponents();
                        Output(isGauge: false, output: gaugeValue);
                    }

                    // freeware.
                    else
                    {
                        gaugeValue = Autopilot.ApAirspeed.ToString();
                        if (Autopilot.ApAirspeedHold) gaugeValue = " hold " + gaugeValue;
                        Output(gaugeName, gaugeValue, isGauge);
                    } // freeware
                    break;

                case "ap_Set_Airspeed":
                    if (PMDG737Detected)
                    {
                        _PMDG737MCPComponentsManager.ShowSpeedWindow();
                    }
                    else if (PMDG747Detected)
                    {
                        if (PMDG747Aircraft.MCPComponents["speed"].Visible)
                        {
                            Output(isGauge: false, output: "The speed box is already open!");
                        }
                        else
                        {
                            PMDG747Aircraft.ShowSpeedBox();
                        }
                    } // PMDG747
                    else if (PMDG777Detected)
                    {

                        if (PMDG777Aircraft.McpComponents["speed"].Visible)
                        {
                            Output(isGauge: false, output: "Speed box already open!");
                            history.AddItem("Speed box already open!");
                        }
                        else
                        {
                            PMDG777Aircraft.ShowSpeedBox();
                        }
                    } // End PMDG 777.
                    else
                    {
                        ap = new frmAutopilot("Airspeed");
                        ap.ShowDialog();
                    } // End freeware planes.
                    break;

                case "ap_Get_Mach_Speed":
                    gaugeName = "AP mach";
                    gaugeValue = string.Empty;
                    if (PMDG737Detected)
                    {
                        if (PMDG737Aircraft.SpeedType == PMDG.AircraftSpeed.Mach)
                        {
                            gaugeValue = PMDG737Aircraft.GetMCPSpeedComponents();
                            Output(isGauge: false, output: gaugeValue);
                        } // MachSpeed
                    } // PMDG737

                    // freeware
                    else
                    {
                        gaugeValue = Autopilot.ApMachSpeed.ToString();
                        if (Autopilot.ApMachHold) gaugeValue = " hold " + gaugeValue;
                    } // freeware
                    Output(gaugeName, gaugeValue, isGauge);
                    break;

                case "ap_Set_Mach_Speed":

                    if (PMDG737Detected)
                    {
                        _PMDG737MCPComponentsManager.ShowSpeedWindow();
                    } // PMDG737
                    else
                    {
                        ap = new frmAutopilot("Mach");
                        ap.ShowDialog();
                    }
                    break;

                case "ap_Get_Vertical_Speed":
                    gaugeName = "AP vertical speed";
                    gaugeValue = Autopilot.ApVerticalSpeed.ToString();
                    if (Autopilot.ApVerticalSpeedHold) gaugeValue = " hold " + gaugeValue;
                    Output(gaugeName, gaugeValue, isGauge);
                    break;

                case "ap_Set_Vertical_Speed":
                    if (PMDG737Detected)
                    {
                        _PMDG737MCPComponentsManager.ShowVerticalSpeedWindow();
                    }
                    else if (PMDG747Detected)
                    {
                        if (PMDG747Aircraft.MCPComponents["vertical"].Visible)
                        {
                            Output(isGauge: false, output: "The vertical speed box is already open!");
                        }
                        else
                        {
                            PMDG747Aircraft.ShowVerticalSpeedBox();
                        }
                    }
                    else if (PMDG777Detected)
                    {
                        if (PMDG777Aircraft.McpComponents["vertical"].Visible)
                        {
                            Output(isGauge: false, output: "The vertical speed box is already open!");
                        }
                        else
                        {
                            PMDG777Aircraft.McpComponents["vertical"].Show();
                        }
                    } // End PMDG777 check.
                    else
                    {
                        ap = new frmAutopilot("Vertical speed");
                        ap.ShowDialog();
                    } // End freeware check.

                    break;
                case "ap_Get_Com_Radios":
                    Output(isGauge: false, output: $"com 1: {Autopilot.Com1Freq.ToString()}. ");
                    Output(isGauge: false, output: $"com 2: {Autopilot.Com2Freq.ToString()}. ");
                    break;


                case "ap_Set_Com_Radios":
                    com = new frmComRadios();
                    com.ShowDialog();
                    break;

                case "ap_Get_Nav_Radios":
                    string navInfo = null;
                    Output(isGauge: false, output: $"nav 1: {Autopilot.Nav1Freq.ToString()}. Course: {Autopilot.Nav1Course.ToString()}. ");

                    if (Aircraft.AutopilotRadioStatus.Value[6])
                    {
                        // nav 1 has ILS
                        navInfo += "ILS. \n";
                        double gsInclination = (double)Aircraft.Nav1GSInclination.Value * 360d / 65536d - 360d;
                        navInfo += "Glide slope angle: " + gsInclination.ToString("F1") + "degrees. \n";
                        navInfo += $"{Aircraft.Vor1Name.Value}. \n";
                        double magvar = (double)Aircraft.MagneticVariation.Value * 360d / 65536d;
                        double rwyHeading = (double)Aircraft.Nav1LocaliserInverseRunwayHeading.Value * 360d / 65536d + 180d - magvar;
                        navInfo += "localiser heading: " + rwyHeading.ToString("F0");
                    }
                    else
                    {
                        if (Aircraft.Vor1ID.Value != "")
                        {
                            navInfo += $"VOR ID: {Aircraft.Vor1ID.Value}. ";
                        }

                    }
                    Output(isGauge: false, output: navInfo);
                    break;
                case "ap_Set_Nav_Radios":
                    nav = new frmNavRadios();
                    nav.ShowDialog();
                    break;


                case "ap_Get_Transponder":
                    gaugeName = "Transponder";
                    gaugeValue = Autopilot.Transponder.ToString();
                    Output(gaugeName, gaugeValue, isGauge);
                    break;
                case "ap_Set_Transponder":

                    if (PMDG737Detected)
                    {
                        bool isTransponderOpen = false;
                        foreach (var w in App.Current.Windows)
                        {
                            if (w is tfm.PMDG.PMDG_737.Forms.TransponderDialog)
                            {
                                isTransponderOpen = true;
                            }
                        }

                        if (isTransponderOpen)
                        {
                            Output(isGauge: false, output: "The transponder window is already open!");
                        }
                        else
                        {
                            tfm.PMDG.PMDG_737.Forms.TransponderDialog t = new PMDG.PMDG_737.Forms.TransponderDialog();
                            t.Show();
                        }
                    }
                    else
                    {
                        ap = new frmAutopilot("Transponder");
                        ap.ShowDialog();

                    }
                    break;

                case "ap_Set_Throttle":
                    ap = new frmAutopilot("Throttle");
                    ap.ShowDialog();
                    break;

                case "ap_PMDG_CDU2":
                    if (PMDG737Detected)
                    {
                        var is737CDUOpen = false;
                        foreach (System.Windows.Window w in App.Current.Windows)
                        {
                            if (w is tfm.PMDG.PMDG_737.Forms.Cdu2Dialog)
                            {
                                is737CDUOpen = true;
                                break;
                            } // End the form is valid.
                        } // End foreach

                        if (is737CDUOpen)
                        {
                            Output(isGauge: false, output: "The FMC window is already open!");
                            break;
                        } // End what to do when CDU is already open.
                        else
                        {
                            tfm.PMDG.PMDG_737.Forms.Cdu2Dialog cdu = new PMDG.PMDG_737.Forms.Cdu2Dialog();
                            App.UI.FocusWindow(cdu, cdu.cduDisplay);
                            is737CDUOpen = true;
                            break;
                        } // End what to do if FMC isn't open.
                        is737CDUOpen = false;
                        break;
                    } // End checking for PMDG 737

                    break;
                case "ap_PMDG_CDU":
                    if (PMDG737Detected)
                    {
                        var is737CDUOpen = false;
                        foreach (System.Windows.Window w in App.Current.Windows)
                        {
                            if (w is tfm.PMDG.PMDG_737.Forms.Cdu1Dialog)
                            {
                                is737CDUOpen = true;
                                break;
                            } // End the form is valid.
                        } // End foreach

                        if (is737CDUOpen)
                        {
                            Output(isGauge: false, output: "The FMC window is already open!");
                            break;
                        } // End what to do when CDU is already open.
                        else
                        {
                            tfm.PMDG.PMDG_737.Forms.Cdu1Dialog cdu = new PMDG.PMDG_737.Forms.Cdu1Dialog();
                            App.UI.FocusWindow(cdu, cdu.cduDisplay);
                            is737CDUOpen = true;
                            break;
                        } // End what to do if FMC isn't open.
                        is737CDUOpen = false;
                        break;
                    } // End checking for PMDG 737
                    else if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("747"))
                    {
                        var is747CDUOpen = false;
                        foreach (Form form in System.Windows.Forms.Application.OpenForms)
                        {
                            if (form is _747CDU)
                            {
                                is747CDUOpen = true;
                                break;
                            } // End the form is valid.
                        } // End foreach

                        if (is747CDUOpen)
                        {
                            Output(isGauge: false, output: "The FMC window is already open!");
                            break;
                        } // End what to do when CDU is already open.
                        else
                        {
                            _747CDU _747CDU = new _747CDU();
                            _747CDU.Show();
                            is747CDUOpen = true;
                            break;
                        } // End what to do if FMC isn't open.
                        is747CDUOpen = false;
                        break;
                    } // End PMDG 747.
                    else if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("777"))
                    {
                        var is777CDUOpen = false;
                        foreach (Form form in System.Windows.Forms.Application.OpenForms)
                        {
                            if (form is _777CDU)
                            {
                                is777CDUOpen = true;
                                break;
                            } // End the form is valid.
                        } // End foreach

                        if (is777CDUOpen)
                        {
                            Output(isGauge: false, output: "The FMC window is already open!");
                            break;
                        } // End what to do when CDU is already open.
                        else
                        {
                            _777CDU _777CDU = new _777CDU();
                            _777CDU.Show();
                            is777CDUOpen = true;
                            break;
                        } // End what to do if FMC isn't open.
                        is777CDUOpen = false;
                        break;
                    } // End PMDG 777.
                    break;

                case "ap_PMDG_Panels":

                    if (PMDG737Detected)
                    {
                        bool panelsOpen = false;

                        foreach (var w in App.Current.Windows)
                        {
                            if (w is tfm.PMDG.PMDG_737.CockpitPanels.CockpitPanelsDialog)
                            {
                                panelsOpen = true;
                            }
                        }

                        if (panelsOpen)
                        {
                            Output(isGauge: false, output: "The cockpit dialog is already open!");
                        }
                        else
                        {
                            tfm.PMDG.PMDG_737.CockpitPanels.CockpitPanelsDialog cockpitPanels = new PMDG.PMDG_737.CockpitPanels.CockpitPanelsDialog();
                            App.UI.FocusWindow(cockpitPanels, cockpitPanels.panelsTreeView);
                        }
                    }
                    else if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("747"))
                    {
                        CockPitPanels_747 cp = new CockPitPanels_747();
                        cp.Show();
                    }
                    else if (Aircraft.AircraftName.Value.Contains("PMDG") && Aircraft.AircraftName.Value.Contains("777"))
                    {
                        CockpitPanels_777 cp = new CockpitPanels_777();
                        cp.Show();
                    }
                    break;

                default:
                    Tolk.Output("key not defined");
                    break;

            }
        }

        public void ExecuteCommand(string Name)
        {
            switch (Name)
            {

                case "SpeedBrakeDecrease":
                    PMDG737Aircraft.SpeedBrakeDecrease();
                    AnnounceCurrentSpeedBrake();
                    break;

                case "SpeedBrakeIncrease":
                    PMDG737Aircraft.SpeedBrakeIncrease();
                    AnnounceCurrentSpeedBrake();
                    break;

                case "SpeedBrakeArm":
                    PMDG737Aircraft.SpeedBrakeArm();
                    AnnounceCurrentSpeedBrake();
                    break;

                case "SpeedBrakeOff":
                    PMDG737Aircraft.SpeedBrakeOff();
                    AnnounceCurrentSpeedBrake();
                    break;

                case "SpeedBrakeFull":
                    PMDG737Aircraft.SpeedBrakeFull();
                    AnnounceCurrentSpeedBrake();
                    break;

                case "SpeedBrakeFlight":
                    PMDG737Aircraft.SpeedBrakeFlight();
                    AnnounceCurrentSpeedBrake();
                    break;

                case "SpeedBrakeHalf":
                    PMDG737Aircraft.SpeedBrakeHalf();
                    AnnounceCurrentSpeedBrake();
                    break;

                case "DestinationRunwayInfo":
                    OnDestinationRunway();
                    break;
                case "ShowSimBriefFlightPlan":

                    var isSimBriefPlanOpen = false;
                    foreach (Form sb in System.Windows.Forms.Application.OpenForms)
                    {
                        if (sb is SimBrief.SimBriefForm)
                        {
                            isSimBriefPlanOpen = true;
                            break;
                        }
                    } // loop

                    if (isSimBriefPlanOpen)
                    {
                        Output(isGauge: false, output: "The SimBrief flight plan window is already open!");
                        break;
                    }
                    else
                    {
                        SimBrief.SimBriefForm sb = new SimBrief.SimBriefForm();
                        sb.ShowDialog();
                        isSimBriefPlanOpen = true;
                        break;
                    }
                    isSimBriefPlanOpen = false;
                    break;
                case "CloudTracking":

                    if (FSUIPCConnection.FSUIPCVersion.Major >= 7)
                    {
                        Output(isGauge: false, output: "Cloud tracking is only available in P3D 4 and later.");
                    }
                    else
                    {
                        if (isCloudTrackingEnabled)
                        {
                            cloudTrackingTimer.Stop();
                            isCloudTrackingEnabled = false;
                            Output(isGauge: false, output: "Cloud tracking off.");
                        }
                        else
                        {
                            cloudTrackingTimer.Start();
                            isCloudTrackingEnabled = true;
                            Output(isGauge: false, output: "Cloud tracking on.");
                        }
                    }
                    break;
                case "SetTrim":
                    if (PMDG737Detected)
                    {
                        bool isTrimWindowOpen = false;
                        foreach (var w in App.Current.Windows)
                        {
                            if (w is tfm.PMDG.PMDG_737.Forms.TrimDialog)
                            {
                                isTrimWindowOpen = true;
                                break;
                            }
                        }

                        if (isTrimWindowOpen)
                        {
                            Output(isGauge: false, output: "The trim window is already open!");
                        }
                        else
                        {
                            tfm.PMDG.PMDG_737.Forms.TrimDialog t = new PMDG.PMDG_737.Forms.TrimDialog();
                            t.Show();
                        }
                    }
                    else
                    {
                        throw new NotImplementedException("Setting trim is only available for the PMDG 737 at this time.");
                    }
                    break;
                case "JumpToRunway":
                    foreach (System.Windows.Window w in App.Current.Windows)
                    {
                        if (w.GetType().Name == "RunwaysDialog")
                        {
                            Output(isGauge: false, output: "The jump to runway dialog is already open!");
                            return;
                        }
                    }
                    tfm.JumpTo.RunwaysDialog rd = new JumpTo.RunwaysDialog();
                    App.UI.FocusWindow(rd, rd.airportIcaoTextBox);

                    break;
                case "JumpToGate":

                    foreach (System.Windows.Window w in App.Current.Windows)
                    {
                        if (w.GetType().Name == "GatesDialog")
                        {
                            Output(isGauge: false, output: "The jump to gates dialog is already open!");
                            return;
                        }
                    }

                    tfm.JumpTo.GatesDialog g = new JumpTo.GatesDialog();
                    App.UI.FocusWindow(g, g.airportIcaoTextBox);
                    break;


                case "toggle_help_mode":
                    // enabling command help is handled here. Since command functions are bypassed when help is on, we handle turning it off in the key pressed event.
                    if (helpModeEnabled == false)
                    {
                        Output(isGauge: false, output: "Command help enabled");
                        helpModeEnabled = true;
                    }
                    break;

                case "keyboard_manager":
                    DisplayKeyboardManager();
                    break;
                case "ApplicationRestart":
                    string appPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                    System.Diagnostics.Process.Start(appPath);
                    App.Current.Shutdown();
                    break;
                case "destination_runway":

                    foreach (var w in App.Current.Windows)
                    {
                        if (w.GetType().Name == "DestinationRunwayWindow")
                        {
                            Output(isGauge: false, output: "The destination runway dialog is already open!");
                            return;
                        }
                    }

                    Flight_planning.DestinationRunwayWindow dr = new Flight_planning.DestinationRunwayWindow();
                    App.UI.FocusWindow(dr, dr.airportTextBox);
                    break;
                case "get_speedbreak":

                    if (PMDG737Detected)
                    {
                        var speedBrakeValue = string.Empty;
                        switch (PMDG737Aircraft.CurrentSpeedBrakePosition)
                        {
                            case 100:
                                speedBrakeValue = "Armed";
                                break;
                            case 272:
                                speedBrakeValue = "Flt";
                                break;
                            case 400:
                                speedBrakeValue = "Up";
                                break;
                            case 250:
                                speedBrakeValue = "50%";
                                break;
                            case 0:
                                speedBrakeValue = "Off";
                                break;
                            default:
                                speedBrakeValue = PMDG737Aircraft.CurrentSpeedBrakePosition.ToString();
                                break;
                        }

                        Output(isGauge: false, output: speedBrakeValue);
                    }

                    if (PMDG747Detected)
                    {
                        var speedBrakeValue = string.Empty;
                        switch (PMDG747Aircraft.CurrentSpeedBrakePosition)
                        {
                            case 0:
                                speedBrakeValue = "down";
                                break;
                            case 25:
                                speedBrakeValue = "armed";
                                break;
                            case 62:
                                speedBrakeValue = "flt";
                                break;
                            case 100:
                                speedBrakeValue = "up";
                                break;
                            default:
                                speedBrakeValue = PMDG747Aircraft.CurrentSpeedBrakePosition.ToString();
                                break;
                        }

                        Output(isGauge: false, output: speedBrakeValue);

                    }

                    if (PMDG777Detected)
                    {
                        foreach (tfm.PMDG.PanelObjects.SingleStateToggle toggle in PMDG777Aircraft.PanelControls)
                        {
                            if (toggle.Name == "Speedbrake")
                            {
                                Output(isGauge: false, output: toggle.ToString());
                                break;
                            }
                        }
                    } // PMDG 777
                    break;
                case "report_issue":
                    ReportIssue();
                    break;
                case "display_website":
                    DisplayWebsite();
                    break;
                case "weather_center":
                    if (FSUIPCConnection.FSUIPCVersion.Major >= 7)
                    {
                        Output(isGauge: false, output: "The weather center only works in P3d 4 and later.");
                    }
                    else
                    {
                        tfm.Weather.WeatherCenterForm weatherCenter = new Weather.WeatherCenterForm();
                        if (weatherCenter.Visible)
                        {
                            Output(isGauge: false, output: "The weather center is already open!");
                        }
                        else
                        {
                            weatherCenter.ShowDialog();
                        }
                    }
                    break;
                case "A2A_manager":
                    DisplayA2AManager();
                    break;
                case "application_settings":

                    DisplayApplicationSettings();
                    break;

                case "LocalTime":
                    ReadSimulatorTime();
                    break;
                case "distanceToDescent":
                    onTODKey();
                    break;
                case "n1monitor":
                    frmAutopilot frmAutopilot = new frmAutopilot("n1Monitor");
                    frmAutopilot.ShowDialog();
                    break;
                case "application_quit":
                    Tolk.Output("TFM is shutting down...");
                    App.Current.Shutdown();
                    break;

                case "get_spoilers":
                    onSpoilersKey();
                    break;

                case "flight_planner":
                    /*var isPlannerActive = false;
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form is FlightPlanForm)
                        {
                            isPlannerActive = true;
                            break;
                        }
                    }
                    if (isPlannerActive)
                    {
                        Output(isGauge: false, output: "Flight planner is already open!");
                        break;
                    }
                    else
                    {
                        FlightPlanForm fp = new FlightPlanForm();
                        fp.ShowDialog();
                        isPlannerActive = true;
                        break;
                    }
                    isPlannerActive = false;
                    break;*/
                    Output(isGauge: false, output: "Feature not yet implemented.");
                    break;
                case "takeoff_assist":
                    Output(isGauge: false, output: "Takeoff assist is no longer supported.");
                    break;
                case "ASL_Altitude":
                    OnASLKey();
                    break;
                case "Fuel_Manager":
                    if (fuelManagerActive)
                    {
                        Output(isGauge: false, output: "fuel manager already open");
                        break;
                    }
                    if (Aircraft.AircraftName.Value.Contains("PMDG"))
                    {
                        MessageBox.Show("Fuel manager is not available on PMDG aircraft. Please use the FMC to load fuel.", "error");
                        break;

                    }
                    else
                    {
                        frmFuelManager frm = new frmFuelManager();
                        fuelManagerActive = true;
                        frm.ShowDialog();
                        fuelManagerActive = false;
                        break;
                    }


                case "Current_Location":
                    OnCurrentLocation();
                    break;
                case "AGL_Altitude":
                    OnAGLKey();
                    break;
                case "Disable_Command_Key":
                    Output(isGauge: false, output: "command key disabled.");
                    CommandKeyEnabled = false;
                    break;

                case "Aircraft_Heading":
                    OnHeadingKey();
                    break;
                case "Indicated_Airspeed":
                    OnIASKey();
                    break;
                case "Read_Simulation_Rate":
                    ReadSimulationRate(true);
                    break;
                case "Ground_Speed":
                    onGroundSpeedKey();
                    break;

                case "True_Airspeed":
                    OnTASKey();
                    break;
                case "Mach_Speed":
                    OnMachKey();
                    break;
                case "Vertical_Speed":
                    OnVSpeedKey();
                    break;
                case "Landing_Rate":
                    OnLandingRateKey();
                    break;

                case "Outside_Temperature":
                    onAirtempKey();
                    break;
                case "Toggle_Trim_Announcement":
                    onTrimKey();
                    break;
                case "Mute_Simconnect_Messages":
                    OnMuteSimconnectKey();
                    break;
                case "Toggle_Global_Mute":
                    OnGlobalMuteKey();
                    break;

                case "Repeat_Last_Simconnect_Message":
                    onRepeatLastSimconnectMessage();
                    break;
                case "Output_History":
                    frmOutputHistory frmHistory = new frmOutputHistory();
                    frmHistory.ShowDialog();
                    break;

                case "Nearest_City":
                    OnCityKey();
                    break;
                case "Next_Waypoint":
                    OnWaypointKey();
                    break;
                case "Destination_Info":
                    OnDestinationKey();
                    break;
                case "Attitude_Mode":
                    onAttitudeKey();
                    break;
                case "Toggle_Autopilot_Announcement":
                    onAutopilotKey();
                    break;
                case "Toggle_GPWS_Announcement":
                    onGPWSKey();
                    break;
                case "Toggle_ILS_Announcement":
                    onToggleILSKey();
                    break;
                case "Toggle_Flaps_Announcement":
                    onToggleFlapsAnnouncementKey();
                    break;
                case "Read_Flaps_Angle":
                    onFlapsKey();
                    break;
                case "Read_Landing_Gear":
                    onGearStateKey();
                    break;

                case "Wind_Information":
                    onWindKey();
                    break;
                case "cloud_info":
                    if (FSUIPCConnection.FSUIPCVersion.Major >= 7)
                    {
                        Output(isGauge: false, output: "Cloud tracking is only available in P3d 4 and later.");
                    }
                    else
                    {
                        OnCloudKey();
                    }

                    break;
                case "Runway_Guidance_Mode":
                    onRunwayGuidanceKey();
                    break;
                case "Fuel_Report":
                    onFuelReportKey();
                    break;
                case "Fuel_Flow":
                    onFuelFlowKey();
                    break;
                case "Weight_Report":
                    onWeightReportKey();
                    break;

                case "Fuel_Tank_1":
                    onFuelTankKey(1);
                    break;
                case "Fuel_Tank_2":
                    onFuelTankKey(2);
                    break;
                case "Fuel_Tank_3":
                    onFuelTankKey(3);
                    break;
                case "Fuel_Tank_4":
                    onFuelTankKey(4);
                    break;
                case "Fuel_Tank_5":
                    onFuelTankKey(5);
                    break;
                case "Fuel_Tank_6":
                    onFuelTankKey(6);
                    break;
                case "Fuel_Tank_7":
                    onFuelTankKey(7);
                    break;
                case "Fuel_Tank_8":
                    onFuelTankKey(8);
                    break;
                case "Fuel_Tank_9":
                    onFuelTankKey(9);
                    break;
                case "Fuel_Tank_10":
                    onFuelTankKey(10);
                    break;
                case "Nearby_Airborn_Aircraft":

                    if (tfm.Properties.Settings.Default.VatsimMode)
                    {
                        tfm.Vatsim.VatsimRadar vatsimRadar = new Vatsim.VatsimRadar();
                        vatsimRadar.Show();
                    }
                    else
                    {
                        onNearbyAircraft();
                    }
                    break;
                case "Nearby_Ground_Aircraft":
                    onTCASGround();
                    break;
                case "Engine_1_Throttle":
                    onEngineThrottleKey(1);
                    break;

                case "Engine_2_Throttle":
                    onEngineThrottleKey(2);
                    break;

                case "Engine_3_Throttle":
                    onEngineThrottleKey(3);
                    break;

                case "Engine_4_Throttle":
                    onEngineThrottleKey(4);
                    break;

                case "Engine_1_Info":
                    OnEngineInfoKey(1);
                    break;
                case "Engine_2_Info":
                    OnEngineInfoKey(2);
                    break;
                case "Engine_3_Info":
                    OnEngineInfoKey(3);
                    break;
                case "Engine_4_Info":
                    OnEngineInfoKey(4);
                    break;
                case "Toggle_Braille_Output":
                    onBrailleOutputKey();
                    break;

            }
        }

        private void onKeyPressed(object? sender, HotkeyEventArgs e)
        {

            e.Handled = true;
            ResetHotkeys();
            if (helpModeEnabled == true)
            {
                if (e.Name == "toggle_help_mode")
                {
                    Output(isGauge: false, output: "Toggle Command help. Exiting help.");
                    helpModeEnabled = false;
                    return;
                }
                Output(isGauge: false, output: rm.GetString(e.Name));
                return;
            }

            ExecuteCommand(e.Name);

        }


    }
}
