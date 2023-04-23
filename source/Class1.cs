using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace tfm
{
    

    public class Settings : ApplicationSettingsBase
    {
        [UserScopedSetting]
        [DefaultSettingValue("None")]
        public System.String GeonamesUsername
        {
            get { return (System.String)this["GeonamesUsername"]; }
            set { this["GeonamesUsername"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("False")]
        public System.Boolean FlightFollowing
        {
            get { return (System.Boolean)this["FlightFollowing"]; }
            set { this["FlightFollowing"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public System.Boolean AutomaticAnnouncements
        {
            get { return (System.Boolean)this["AutomaticAnnouncements"]; }
            set { this["AutomaticAnnouncements"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public System.Boolean ReadSimconnectMessages
        {
            get { return (System.Boolean)this["ReadSimconnectMessages"]; }
            set { this["ReadSimconnectMessages"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public System.Boolean ReadGPWS
        {
            get { return (System.Boolean)this["ReadGPWS"]; }
            set { this["ReadGPWS"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public System.Boolean ReadILS
        {
            get { return (System.Boolean)this["ReadILS"]; }
            set { this["ReadILS"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public System.Boolean ReadGroundSpeed
        {
            get { return (System.Boolean)this["ReadGroundSpeed"]; }
            set { this["ReadGroundSpeed"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("False")]
        public System.Boolean UseMetric
        {
            get { return (System.Boolean)this["UseMetric"]; }
            set { this["UseMetric"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("10")]
        public System.String FlightFollowingTimeInterval
        {
            get { return (System.String)this["FlightFollowingTimeInterval"]; }
            set { this["FlightFollowingTimeInterval"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("5")]
        public System.String ILSAnnouncementTimeInterval
        {
            get { return (System.String)this["ILSAnnouncementTimeInterval"]; }
            set { this["ILSAnnouncementTimeInterval"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("1")]
        public System.Int32 AttitudeAnnouncementMode
        {
            get { return (System.Int32)this["AttitudeAnnouncementMode"]; }
            set { this["AttitudeAnnouncementMode"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public System.Boolean AltitudeAnnouncements
        {
            get { return (System.Boolean)this["AltitudeAnnouncements"]; }
            set { this["AltitudeAnnouncements"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public System.Boolean ReadFlaps
        {
            get { return (System.Boolean)this["ReadFlaps"]; }
            set { this["ReadFlaps"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("False")]
        public System.Boolean ReadAutopilot
        {
            get { return (System.Boolean)this["ReadAutopilot"]; }
            set { this["ReadAutopilot"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("False")]
        public System.Boolean FlightFollowingOffline
        {
            get { return (System.Boolean)this["FlightFollowingOffline"]; }
            set { this["FlightFollowingOffline"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("0")]
        public System.Int32 SAPISpeechRate
        {
            get { return (System.Int32)this["SAPISpeechRate"]; }
            set { this["SAPISpeechRate"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("False")]
        public System.Boolean ReadNavRadios
        {
            get { return (System.Boolean)this["ReadNavRadios"]; }
            set { this["ReadNavRadios"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("None")]
        public System.String NewAvionicsTab
        {
            get { return (System.String)this["NewAvionicsTab"]; }
            set { this["NewAvionicsTab"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("False")]
        public System.Boolean AvionicsTabChangeFlag
        {
            get { return (System.Boolean)this["AvionicsTabChangeFlag"]; }
            set { this["AvionicsTabChangeFlag"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public System.Boolean OutputBraille
        {
            get { return (System.Boolean)this["OutputBraille"]; }
            set { this["OutputBraille"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("50")]
        public System.Decimal OutputHistoryLength
        {
            get { return (System.Decimal)this["OutputHistoryLength"]; }
            set { this["OutputHistoryLength"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("off")]
        public System.String takeOffAssistMode
        {
            get { return (System.String)this["takeOffAssistMode"]; }
            set { this["takeOffAssistMode"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("None")]
        public System.String bingMapsAPIKey
        {
            get { return (System.String)this["bingMapsAPIKey"]; }
            set { this["bingMapsAPIKey"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("1")]
        public System.String PMDGCDUKeyLayout
        {
            get { return (System.String)this["PMDGCDUKeyLayout"]; }
            set { this["PMDGCDUKeyLayout"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("None")]
        public System.String AzureAPIKey
        {
            get { return (System.String)this["AzureAPIKey"]; }
            set { this["AzureAPIKey"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("ScreenReader")]
        public System.String SpeechSystem
        {
            get { return (System.String)this["SpeechSystem"]; }
            set { this["SpeechSystem"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("ScreenReader")]
        public System.String FallbackSpeechSystem
        {
            get { return (System.String)this["FallbackSpeechSystem"]; }
            set { this["FallbackSpeechSystem"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("None")]
        public System.String AzureServiceRegion
        {
            get { return (System.String)this["AzureServiceRegion"]; }
            set { this["AzureServiceRegion"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("None")]
        public System.String AzureVoice
        {
            get { return (System.String)this["AzureVoice"]; }
            set { this["AzureVoice"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public System.Boolean SettingsRequiresUpgrade
        {
            get { return (System.Boolean)this["SettingsRequiresUpgrade"]; }
            set { this["SettingsRequiresUpgrade"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public System.Boolean AnnouncePerfInitComplete
        {
            get { return (System.Boolean)this["AnnouncePerfInitComplete"]; }
            set { this["AnnouncePerfInitComplete"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public System.Boolean AnnounceTakeoffConfigComplete
        {
            get { return (System.Boolean)this["AnnounceTakeoffConfigComplete"]; }
            set { this["AnnounceTakeoffConfigComplete"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public System.Boolean PlayStartupSound
        {
            get { return (System.Boolean)this["PlayStartupSound"]; }
            set { this["PlayStartupSound"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public System.Boolean PlayShutdownSound
        {
            get { return (System.Boolean)this["PlayShutdownSound"]; }
            set { this["PlayShutdownSound"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("None")]
        public System.String P3DAirportsDatabasePath
        {
            get { return (System.String)this["P3DAirportsDatabasePath"]; }
            set { this["P3DAirportsDatabasePath"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("False")]
        public System.Boolean ReadLocaliserHeadingOffsets
        {
            get { return (System.Boolean)this["ReadLocaliserHeadingOffsets"]; }
            set { this["ReadLocaliserHeadingOffsets"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("False")]
        public System.Boolean ReadGSAltitude
        {
            get { return (System.Boolean)this["ReadGSAltitude"]; }
            set { this["ReadGSAltitude"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("False")]
        public System.Boolean UseDatabase
        {
            get { return (System.Boolean)this["UseDatabase"]; }
            set { this["UseDatabase"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("False")]
        public System.Boolean SpeechHistoryTimestamps
        {
            get { return (System.Boolean)this["SpeechHistoryTimestamps"]; }
            set { this["SpeechHistoryTimestamps"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public System.Boolean SapiILSAnnouncements
        {
            get { return (System.Boolean)this["SapiILSAnnouncements"]; }
            set { this["SapiILSAnnouncements"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("False")]
        public System.Boolean VatsimMode
        {
            get { return (System.Boolean)this["VatsimMode"]; }
            set { this["VatsimMode"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("simplified")]
        public System.String avionics_tab
        {
            get { return (System.String)this["avionics_tab"]; }
            set { this["avionics_tab"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public System.Boolean ShowFirstRunDialog
        {
            get { return (System.Boolean)this["ShowFirstRunDialog"]; }
            set { this["ShowFirstRunDialog"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("None")]
        public System.String MSFSAirportsDatabasePath
        {
            get { return (System.String)this["MSFSAirportsDatabasePath"]; }
            set { this["MSFSAirportsDatabasePath"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public System.Boolean PreflightAlignIRS
        {
            get { return (System.Boolean)this["PreflightAlignIRS"]; }
            set { this["PreflightAlignIRS"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("False")]
        public System.Boolean FlowMuteSpeech
        {
            get { return (System.Boolean)this["FlowMuteSpeech"]; }
            set { this["FlowMuteSpeech"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("None")]
        public System.String SimBriefUserID
        {
            get { return (System.String)this["SimBriefUserID"]; }
            set { this["SimBriefUserID"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public System.Boolean IsSimBriefEnabled
        {
            get { return (System.Boolean)this["IsSimBriefEnabled"]; }
            set { this["IsSimBriefEnabled"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("False")]
        public System.Boolean IsSimBriefUserIDValid
        {
            get { return (System.Boolean)this["IsSimBriefUserIDValid"]; }
            set { this["IsSimBriefUserIDValid"] = value; }
        }

    }

}
