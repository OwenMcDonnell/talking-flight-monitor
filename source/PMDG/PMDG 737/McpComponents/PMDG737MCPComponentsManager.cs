using tfm.PMDG.PMDG_737.McpComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace tfm.PMDG.PMDG_737.McpComponents
{
    public class PMDG737MCPComponentsManager
    {

        McpAltitudeWindow altitudeWindow = new McpAltitudeWindow();
        McpHeadingWindow headingWindow = new McpHeadingWindow();
        McpNavAidsWindow navAidsWindow = new McpNavAidsWindow();
        McpSpeedWindow speedWindow = new McpSpeedWindow();
        McpVerticalSpeedWindow verticalSpeedWindow = new McpVerticalSpeedWindow();

        public Dictionary<string, Window> MCPComponents
        {
            get => new Dictionary<string, Window>()
            {
                {"altitude", altitudeWindow },
                {"heading", headingWindow },
                {"navigation", navAidsWindow },
                {"speed", speedWindow },
                {"vertical", verticalSpeedWindow },
                            };
        }

        public void ShowAltitudeWindow()
        {

            if(altitudeWindow.Visibility == Visibility.Visible)
            {
                altitudeWindow.BringIntoView();
            }
            else
            {
                altitudeWindow.ShowDialog();
            }
        }

        public void ShowHeadingWindow()
        {
            if(headingWindow.Visibility == Visibility.Visible)
            {
                headingWindow.BringIntoView();
            }
            else
            {
                headingWindow.ShowDialog();
            }
        }

        public void ShowNavaidsWindow()
        {
            if(navAidsWindow.Visibility == Visibility.Visible)
            {
                navAidsWindow.BringIntoView();
            }
            else
            {
                navAidsWindow.ShowDialog();
            }
        }

        public void ShowSpeedWindow()
        {
            if(speedWindow.Visibility == Visibility.Visible)
            {
                speedWindow.BringIntoView();
            }
            else
            {
                speedWindow.ShowDialog();
            }
        }

        public void ShowVerticalSpeedWindow()
        {
            if(verticalSpeedWindow.Visibility == Visibility.Visible)
            {
                verticalSpeedWindow.BringIntoView();
            }
            else
            {
                verticalSpeedWindow.ShowDialog();
            }
        }
    }
}
