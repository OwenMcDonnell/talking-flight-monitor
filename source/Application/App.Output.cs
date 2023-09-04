using DavyKager;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm
{
    public partial class App: System.Windows.Application
    {
/// <summary>
///  TODO: Try to consolidate output.
/// </summary>
/// <param name="gaugeName"></param>
/// <param name="gaugeValue"></param>
/// <param name="isGauge"></param>
/// <param name="output"></param>
/// <param name="textOutput"></param>
/// <param name="useSAPI"></param>
/// <param name="interruptSpeech"></param>
        public void Output(string gaugeName = "", string gaugeValue = "", bool isGauge = false, string output = "", bool textOutput = true, bool useSAPI = false, bool interruptSpeech = false)
        {
            // We can do anything we want since the gage/value are broken up into different variables now.
            // The event should take care of anything the screen reader needs to output to the user.

            // when e.isGage is true, e.output is empty.
            // Otherwise, e.output should contain a string to send to the screen reader.
            // EX: the next waypoint feature is inappropriate for e.gageName and e.gageValue, so e.isGage will be false, and e.output will have the output for the next waypoint.

            if (isGauge)
            {
                switch (gaugeName)
                {
                    case "Vertical speed":
                        // We can implement different settings here. One of them is braille support.
                        // After including a braille only, speech only, or both setting,
                        // All we need to do is check for the setting and respond to it.
                        // Braile, speech, and output can have different output without toying with the backend code.
                        // This also makes way for message type: short or long. A pilot might not want
                        // to hear "feet per minute" every time he/she presses ]v, so, give them a choice.
                        // That setting would be checked here because it influences screen reader/braille output.
                        // The log may also contain different formatting options. For now, stick with
                        // reasonable defaults.

                        Speak($"{gaugeValue} feet per minute.");
                        braille($"VSPD {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");

                        break;
                    case "Outside temperature":
                        Speak($"{gaugeValue} degrees");
                        braille($"temp {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;
                    case "ASL altitude":
                        Speak($"{gaugeValue} feet ASL.");
                        braille($"ASL  {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "AGL altitude":
                        Speak($"{gaugeValue} feet AGL.");
                        braille($"AGL {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "Airspeed true":
                        Speak($"{gaugeValue} knotts true");
                        braille($"TAS {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "Airspeed indicated":
                        Speak($"{gaugeValue} knotts indicated");
                        braille($"IAS {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "Ground speed":
                        Speak($"{gaugeValue} knotts ground speed");
                        braille($"{gaugeName}: {gaugeValue}\n");
                        history.AddItem($"gnd: {gaugeValue}\n");
                        break;

                    case "Mach":
                        Speak($"Mach {gaugeValue}. ");
                        braille($"mach{gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "Localiser":

                        if (useSAPI)
                        {
                            Speak($"{gaugeValue}. ", useSAPI: true);
                        }
                        else
                        {
                            Speak($"{gaugeValue}. ");
                        }

                        braille($"loc {gaugeValue}\n");
                        break;

                    case "Glide slope":

                        if (useSAPI)
                        {
                            Speak($"{gaugeValue}", useSAPI: true);
                        }
                        else
                        {
                            Speak($"{gaugeValue}");
                        }

                        braille($"gs {gaugeValue}\n");
                        break;

                    case "Altimeter":
                        Speak($"{gaugeName}: {gaugeValue}. ");
                        braille($"{gaugeName}: {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "Flaps":
                        Speak($"{gaugeName} {gaugeValue}. ");
                        braille($"{gaugeName} {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "Gear":
                        Speak($"{gaugeName} {gaugeValue}. ");
                        braille($"{gaugeName}: {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "AP heading":
                        if (PMDG737Detected || PMDG747Detected || PMDG777Detected)
                        {
                            Speak($"{gaugeValue}");
                            braille($"{gaugeValue}");
                            history.AddItem($"{gaugeValue}");
                        }
                        else
                        {
                            Speak($"heading {gaugeValue}. ");
                            braille($"hdg: {gaugeValue}\n");
                            history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        }
                        break;

                    case "AP airspeed":
                        if (PMDG737Detected || PMDG747Detected || PMDG777Detected)
                        {
                            Speak(gaugeValue);
                            braille(gaugeValue);
                            history.AddItem(gaugeValue);
                        } // PMDG
                        else
                        {
                            Speak($"{gaugeValue} knotts. ");
                            braille($"{gaugeName}: {gaugeValue}\n");
                            history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        }
                        break;

                    case "AP mach":
                        if (PMDG737Detected || PMDG747Detected || PMDG777Detected)
                        {
                            Speak(gaugeValue);
                            braille(gaugeValue);
                            history.AddItem(gaugeValue);
                        } // PMDG
                        else
                        {

                            Speak($"Mach {gaugeValue}");
                            braille($"{gaugeName}: {gaugeValue}\n");
                            history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        }
                        break;

                    case "AP vertical speed":
                        Speak($"{gaugeValue} feet per minute. ");
                        braille($"{gaugeValue} FPM\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;
                    case "AP altitude":

                        if (PMDG737Detected || PMDG747Detected || PMDG777Detected)
                        {
                            Speak(gaugeValue);
                            braille(gaugeValue);
                            history.AddItem(gaugeValue);
                        } // PMDG
                        else
                        {
                            Speak($"{gaugeName}: {gaugeValue} feet. ");
                            braille($"{gaugeName}: {gaugeValue}\n");
                            history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        }
                        break;


                    case "Com1":
                        Speak($"{gaugeName}: {gaugeValue}. ");
                        braille($"{gaugeName}: {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "Com2":
                        Speak($"{gaugeName}: {gaugeValue}. ");
                        braille($"{gaugeName}: {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "Nav1":
                        Speak($"{gaugeName}: {gaugeValue}. ");
                        braille($"{gaugeName}: {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "Nav2":
                        Speak($"{gaugeName}: {gaugeValue}. ");
                        braille($"{gaugeName}: {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;

                    case "Transponder":
                        Speak($"squawk {gaugeValue}. ");
                        braille($"Squawk: {gaugeValue}\n");
                        history.AddItem($"{gaugeName}: {gaugeValue}\n");
                        break;





                    default:
                        Tolk.Output("Gage or instrument not supported.\n");
                        break;
                }
            } // End gage output.
            else
            {
                if (useSAPI == true)
                {
                    Speak(useSAPI: true, interruptSpeech: interruptSpeech, output: output);
                }
                else
                {
                    Speak(output, interruptSpeech: interruptSpeech);
                }
                if (textOutput == true)
                {
                    history.AddItem($"{output}\n");
                }

            } // end generic output
        } // end output method

        public async void Speak(string output, bool useSAPI = false, bool interruptSpeech = false)
        {
            if (tfm.Properties.Settings.Default.SpeechSystem == "SAPI" || useSAPI == true)
            {
                if (interruptSpeech == true) synth.SpeakAsyncCancelAll();
                synth.Rate = tfm.Properties.Settings.Default.SAPISpeechRate;
                synth.SpeakAsync(output);
                return;
            }
            if (tfm.Properties.Settings.Default.SpeechSystem == "ScreenReader")
            {
                Tolk.Speak(output, interruptSpeech);

            }
            /*if (Properties.Settings.Default.SpeechSystem == "Azure")
            {
                var voice = Properties.Settings.Default.AzureVoice;
                var ssml = $"<speak version='1.0' xml:lang='en-US' xmlns='http://www.w3.org/2001/10/synthesis' xmlns:mstts='http://www.w3.org/2001/mstts'><voice name='{voice}'>{output}</voice></speak>";
                using (SpeechSynthesisResult result = await azureSynth.SpeakSsmlAsync(ssml))
                {
                    if (result.Reason == ResultReason.Canceled)
                    {
                        var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                        logger.Debug($"Error getting speech from Azure: {cancellation.Reason}");
                        if (Properties.Settings.Default.FallbackSpeechSystem == "ScreenReader")
                        {
                            Tolk.Speak(output, interruptSpeech);
                        }
                        else
                        {
                            if (interruptSpeech == true) synth.SpeakAsyncCancelAll();
                            synth.Rate = Properties.Settings.Default.SAPISpeechRate;
                            synth.SpeakAsync(output);

                        }

                    }
                }



            }*/
        }
        private void braille(string output)
        {
            if (tfm.Properties.Settings.Default.OutputBraille)
            {
                Tolk.Braille(output);
            }
        } // Braille

    }
}
