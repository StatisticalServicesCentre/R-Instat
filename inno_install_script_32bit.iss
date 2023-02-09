; Script generated by the Inno Script Studio Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppVersion= {#GetStringFileInfo("instat\bin\Release\instat.exe", "FileVersion")}
AppId={{979E51D8-9BC4-418F-8D4D-9B44FEA869A6-{#SetupSetting("AppVersion")}}
AppName=R-Instat
AppVerName ={code:GetShortAppVersion|{#SetupSetting("AppVersion")}}

AppPublisher=African Maths Initiative
AppPublisherURL=http://r-instat.org/
AppSupportURL=http://r-instat.org/
AppUpdatesURL=http://r-instat.org/
DefaultDirName={autopf}\R-Instat\{#SetupSetting("AppVerName")}\
DefaultGroupName=R-Instat
AllowNoIcons=yes
OutputBaseFilename=R-Instat_{#SetupSetting("AppVersion")}_Installer_32
SetupIconFile=.\instat\Resources\rinstat_icon_Hih_icon.ico
UninstallDisplayIcon=.\instat\Resources\rinstat_icon_Hih_icon.ico
Compression=lzma
SolidCompression=yes

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}";
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; OnlyBelowVersion: 0

[Files]
Source: "instat\bin\Release\instat.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "instat\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
;{#SetupSetting("AppVersion")}
Name: "{group}\R-Instat {#SetupSetting("AppVersion")}"; Filename: "{app}\instat.exe"
Name: "{group}\{cm:UninstallProgram,R-Instat}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\R-Instat {#SetupSetting("AppVersion")}"; Filename: "{app}\instat.exe"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\R-Instat {#SetupSetting("AppVersion")}"; Filename: "{app}\instat.exe"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\instat.exe"; Description: "{cm:LaunchProgram,R-Instat}"; Flags: nowait postinstall skipifsilent

[Code]
function GetShortAppVersion(Param: String): String;
var 
  major,minor,revision:String; 
begin 
  major := Copy(Param,0,Pos('.',Param));
  Delete(Param,1,Pos('.',Param));
  minor := Copy(Param,0,Pos('.',Param));
  Delete(Param,1,Pos('.',Param));
  revision := Copy(Param,0,Pos('.',Param)-1);
  Result := major +  minor + revision;
end;
