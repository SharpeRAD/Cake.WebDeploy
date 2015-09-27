#Download and install Chocolatey
iex ((new-object net.webclient).DownloadString("https://chocolatey.org/install.ps1"))

## Install WebPI
cInst webpicommandline -h

#Install WebDeploy
$webPiProducts = @('webdeploy') 
WebPICMD /Install /Products:"$($webPiProducts -join ',')" /AcceptEULA

#Start Services
Start-Service W3SVC
Start-Service WMSVC
Start-Service msdepsvc