#Install WebDeploy
cInst webdeploy --yes

#Start Services
Start-Service W3SVC
Start-Service WMSVC
Start-Service msdepsvc