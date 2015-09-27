## Install WebPI
cInst webpicommandline -yes

#Install Url Rewrite and ARR
$webPiProducts = @('webdeploy') 
WebPICMD /Install /Products:"$($webPiProducts -join ',')" /AcceptEULA

#Start Services
Start-Service W3SVC
Start-Service WMSVC
Start-Service msdepsvc

netsh advfirewall set allprofiles state off