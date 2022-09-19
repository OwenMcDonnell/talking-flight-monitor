; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Talking Flight Monitor"
#define MyAppVersion "2022.9.1"
#define MyAppPublisher "Talking Flight Monitor"
#define MyAppURL "http://www.talkingflightmonitor.com"
#define MyAppExeName "tfm.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{CF550E2F-B91A-40EF-9354-227750FA87EA}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}

LicenseFile="license.txt"
DisableWelcomePage=no
DefaultGroupName="Talking Flight Monitor"
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputDir=tfm
OutputBaseFilename=tfm-{#MyAppVersion}
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "..\source\bin\Debug\*"; Excludes: "tfm.iss"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs

; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Registry]
Root: HKLM64; Subkey: "Software\Talking Flight Monitor"; Flags: uninsdeletekeyifempty
Root: HKLM64; Subkey: "Software\Talking Flight Monitor\Talking Flight Monitor"; Flags: uninsdeletekeyifempty
Root: HKLM64; Subkey: "Software\Talking Flight Monitor\Talking Flight Monitor\Settings"; ValueType: string; ValueName: "InstallPath"; ValueData: "{app}"

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

