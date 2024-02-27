# PLEASE DO NOT MODIFY THIS FILE!
# Implement your logic in "OnAfterInit.ps1" and "OnAfterUserLogin.ps1" files.

param(
	[string] $eventName
)

# Test cases:
#$eventName = $null # Uncomment this line for debuggin
#$eventName = "" # Uncomment this line for debuggin
#$eventName = "bogus" # Uncomment this line for debuggin
#$eventName = "on-after-init" # Uncomment this line for debuggin
#$eventName = "on-after-user-login" # Uncomment this line for debuggin

switch($eventName) {
	"on-after-init" { & ./OnAfterInit.ps1 }
	"on-after-user-login" { & ./OnAfterUserLogin.ps1 }
	Default {
		Write-Warning "Event `"$eventName`" is not supported"
		return
	}
}