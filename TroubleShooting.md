# WebDeploy Troubleshooting



### Error message
```
Could not load file or assembly 'Microsoft.Web.Deployment, Version=9.0.0.0, Culture=Neutral, PubliKeyToken=31bf3856ad364e35 or one of its dependencies. The system can not find the file specified.
```

### Solution
* WebDeploy must be installed on the machine your running the build script on:
http://www.iis.net/downloads/microsoft/web-deploy



### Error message
```
Could not connect to the remote computer
```

### Solution
* Make sure the "Web Management Service" and "Web Deployment Agent Service" are installed and running on the remote computer.
* By default WebDeploy will connect on port 8172 so chek any firewall restrictions between you and the remote computer.



### Error message
```
Connected to the remote computer using Web Manage Service, but could not authorize.
```

### Solution
* Check the PublishSettings credentials against the "IIS Manager Users" section in IIS on the remote machine.
* Check the "IIS Manager Permissions" section of IIS for the site your publishing to has an entry for the user your connecting with.