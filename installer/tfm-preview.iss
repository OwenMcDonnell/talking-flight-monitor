; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Talking Flight Monitor Preview"
; #define MyAppVersion "24.1"
#define MyAppPublisher "Talking Flight Monitor"
#define MyAppURL "http://www.talkingflightmonitor.com"
#define MyAppExeName "tfm.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{E3C41783-472D-47F7-85A6-F2BF212EF4DC}
AppName={#MyAppName}
#ifdef MyAppVersion
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}
#else
AppVersion="test"
AppVerName={#MyAppName} {{AppVersion}
#endif

AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}

LicenseFile="license.txt"
DisableWelcomePage=no
DefaultGroupName="Talking Flight Monitor Preview"
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputDir=.
#ifdef MyAppVersion
OutputBaseFilename=tfm-{#MyAppVersion}
#else 
OutputBaseFilename=tfm-test
#endif

Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "..\source\bin\Debug\net8.0\*"; Excludes: "tfm-preview.iss"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs

; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Registry]
Root: HKLM64; Subkey: "Software\Talking Flight Monitor Preview"; Flags: uninsdeletekeyifempty
Root: HKLM64; Subkey: "Software\Talking Flight Monitor Preview\Talking Flight Monitor Preview"; Flags: uninsdeletekeyifempty
Root: HKLM64; Subkey: "Software\Talking Flight Monitor Preview\Talking Flight Monitor Preview\Settings"; ValueType: string; ValueName: "InstallPath"; ValueData: "{app}"

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

