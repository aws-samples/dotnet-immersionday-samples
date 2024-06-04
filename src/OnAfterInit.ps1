#install .NET 8

choco install dotnet-8.0-sdk

#Set directory
$dir = 'c:\TEMP\'
mkdir -F $dir
cd $dir

#Update Chrome
$Installer = "chrome_installer.exe";
Invoke-WebRequest "http://dl.google.com/chrome/install/latest/chrome_installer.exe" -OutFile $Installer;
Start-Process -FilePath $dir$Installer -Args "/silent /install" -Verb RunAs -Wait;
# Remove-Item $dir$Installer;


#Update Visual Studio Installer
$Installer = "vs_community.exe";
Invoke-WebRequest "https://aka.ms/vs/17/release/vs_community.exe" -OutFile $Installer;
Start-Process -FilePath $dir$Installer -Args "--quiet --update" -Verb RunAs -Wait;
# Remove-Item $dir$Installer

#Update Visual Studio
Start-Process -FilePath "C:\Program Files (x86)\Microsoft Visual Studio\Installer\setup.exe" -Verb RunAs -Args " update --force --quiet --productid Microsoft.VisualStudio.Product.Community --channelId VisualStudio.17.Release" -Wait

#Update AWS Toolkit for Visual Studio
$Installer = "AWSToolkitPackage.v17.vsix"
Invoke-WebRequest "https://amazonwebservices.gallerycdn.vsassets.io/extensions/amazonwebservices/awstoolkitforvisualstudio2022/1.53.0.0/1716505505925/AWSToolkitPackage.v17.vsix" -OutFile $Installer
Start-Process -FilePath "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\VSIXInstaller.exe" -Verb RunAs -Args "/quiet $dir$Installer" -Wait







