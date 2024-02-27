#install .NET 8

choco install dotnet-8.0-sdk





$dir = 'c:\TEMP\'
mkdir -F $dir
cd $dir

#Update Chrome
$Installer = "chrome_installer.exe";
Invoke-WebRequest "http://dl.google.com/chrome/install/latest/chrome_installer.exe" -OutFile $Installer;
Start-Process -FilePath $dir$Installer -Args "/silent /install" -Verb RunAs -Wait;
Remove-Item $dir$Installer;


#Update Visual Studio Installer

$Installer = "vs_community.exe";
Invoke-WebRequest "https://aka.ms/vs/17/release/vs_community.exe" -OutFile $Installer;
Start-Process -FilePath $dir$Installer -Args "--quiet --update" -Verb RunAs -Wait;
Remove-Item $dir$Installer

#Update Visual Studio
cd 'C:\Program Files (x86)\Microsoft Visual Studio\Installer'
.\setup.exe update --force --quiet --productid 'Microsoft.VisualStudio.Product.Community' --channelId 'VisualStudio.17.Release'