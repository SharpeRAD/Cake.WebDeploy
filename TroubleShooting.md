# WebDeploy Troubleshooting

https://docs.microsoft.com/en-us/iis/publish/troubleshooting-web-deploy/troubleshooting-web-deploy
https://docs.microsoft.com/en-us/iis/publish/troubleshooting-web-deploy/troubleshooting-common-problems-with-web-deploy



### Error message
```
Error: Failed to install addin 'Cake.Powershell'
Could not find any assemblies compatible with .NETFramework, Version=4.5
```

### Solution
* Please be aware of the breaking changes that occurred with the release of [Cake v0.22.0](https://cakebuild.net/blog/2017/09/cake-v0.22.0-released), as a result you will need to upgrade Cake in order to use Cake.WebDeploy [v0.3.0] or above.



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
* By default WebDeploy will connect on port 8172 so check any firewall restrictions between you and the remote computer.



### Error message
```
Connected to the remote computer using Web Manage Service, but could not authorize.
```

### Solution
* Check the DeploySettings credentials against the "IIS Manager Users" section in IIS on the remote machine.
* Check the "IIS Manager Permissions" section of IIS for the site your publishing to has an entry for the user your connecting with.



### Error message
```
Microsoft.Web.Deployment.DeploymentException: Source (sitemanifest) and destination (contentPath) are not compatible for the given operation.
```

### Solution
* The settings you are passing to WebDeploy contradict the settings inside the packages manifest file. Remove the settings from the manifest file or use the same settings when calling WebDeploy (eg: use DestinationPath over siteName).