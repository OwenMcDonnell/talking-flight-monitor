using tfm.PMDG;
using FSUIPC;
using DavyKager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm
{
public static class PMDG737Aircraft
    {

                private static tfm.PMDG.PMDG737.McpComponents.AltitudeBox altitudeBox = new PMDG.PMDG737.McpComponents.AltitudeBox();
        private static tfm.PMDG.PMDG737.McpComponents.SpeedBox speedBox = new PMDG.PMDG737.McpComponents.SpeedBox();
        private static tfm.PMDG.PMDG737.McpComponents.HeadingBox headingBox = new PMDG.PMDG737.McpComponents.HeadingBox();
        private static tfm.PMDG.PMDG737.McpComponents.VerticalSpeedBox verticalSpeedBox = new PMDG.PMDG737.McpComponents.VerticalSpeedBox();

        public static Dictionary<string, System.Windows.Forms.Form> MCPComponents
        {
            get =>
                new Dictionary<string, System.Windows.Forms.Form>
                {
                    {"altitude", altitudeBox },
                    {"speed", speedBox },
                    {"heading", headingBox },
                    {"vertical", verticalSpeedBox },
                };
        }



        public static TimeSpan TimeToDestination
        {
            get
            {
                double groundSpeed = ((double)Aircraft.GroundSpeed.Value * 3600d) / (65536d * 1852d);
                groundSpeed = Math.Round(groundSpeed);
                double time = Aircraft.pmdg737.FMC_DistanceToDest.Value / groundSpeed;
                return TimeSpan.FromHours(time);
            }
        } // End TimeToDestination.

        public static TimeSpan TimeToTOD
        {
            get
            {
                double groundSpeed = ((double)Aircraft.GroundSpeed.Value * 3600d) / (65536d * 1852d);
                groundSpeed = Math.Round(groundSpeed);
                double time = Aircraft.pmdg737.FMC_DistanceToTOD.Value / groundSpeed;
                                return TimeSpan.FromHours(time);
            }
        } // End TimeToTOD.

        public static double CurrentFlapsPosition
        {
            get
            {
                return Math.Round(Aircraft.pmdg737.MAIN_TEFlapsNeedle[0].Value);
            }
        } // End CurrentFlapsPosition.

        public static void AltitudeIntervene()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_ALT_INTV_SWITCH, Aircraft.ClkL);
        } // AltitudeIntervene.

        public static void ToggleAltitudeHold()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_ALT_HOLD_SWITCH, Aircraft.ClkL);
        } // ToggleAltitudeHold.

        public static void ToggleVNav()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_VNAV_SWITCH, Aircraft.ClkL);
        } // ToggleVNav

        public static void ToggleLevelChange()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_LVL_CHG_SWITCH, Aircraft.ClkL);
        } // ToggleLevelChange.

        public static void SetAltitude(string altitudeText)
        {
            ushort.TryParse(altitudeText, out ushort altitude);
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_ALT_SET, altitude);
        } // SetAltitude

public static void ShowAltitudeBox()
        {
            MCPComponents["altitude"].Show();
        } // ShowAltitudeBox.

        public static void ToggleHeadingSelect()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_HDG_SEL_SWITCH, Aircraft.ClkL);
        } //HeadingSelect

        public static void ToggleLNav()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_LNAV_SWITCH, Aircraft.ClkL);
        } // ToggleLNav()

        public static void SetHeading(string headingText)
        {
            short.TryParse(headingText, out short heading);
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_HDG_SET, heading);
        } // SetHeading

        public static void ShowHeadingBox()
        {
            MCPComponents["heading"].Show();
        } // ShowHeadingBox.

        public static void VerticalSpeedIntervene()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_VS_SWITCH, Aircraft.ClkL);
        } // VerticalSpeedIntervene

        public static void SetVerticalSpeed(string verticalSpeedText)
        {
            ushort.TryParse(verticalSpeedText, out ushort verticalSpeed);
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_VS_SET, verticalSpeed);
        } // SetVerticalSpeed

        public static void ShowVerticalSpeedBox()
        {
            MCPComponents["vertical"].Show();
        } // ShowVerticalSpeedBox

        public static void SpeedIntervene()
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_SPD_INTV_SWITCH, Aircraft.ClkL);
        } // SpeedIntervene

        public static void ShowSpeedBox()
        {
            MCPComponents["speed"].Show();
        } // ShowSpeedBox
                    } // End PMDG737Aircraft.
} // End namespace.
