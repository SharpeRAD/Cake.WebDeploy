# Cake.WebDeploy
Cake Build addon that extends Cake with WebDeploy commands for publishing to IIS

[![Build status](https://ci.appveyor.com/api/projects/status/rld9874ha4woe9m7?svg=true)](https://ci.appveyor.com/project/PhillipSharpe/cake-webdeploy)

[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)

[![Join the chat at https://gitter.im/cake-build/cake](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/cake-build/cake?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)



## Implemented functionality

This is a list of some the currently implemented functionality:

* Deploy websites from a package or folder
* Locally / remotely using credentials
* Outputting the trace information to the cake log



## Usage

```csharp
#addin "Cake.WebDeploy"


Task("Deploy")
    .Description("Deploy an example website")
    .Does(() =>
	{
		DeployWebsite(new PublishSettings()
		{
			SourcePath = "./src/Package.zip",
			SiteName = "TestSite",

			ComputerName = "remote-location",
			Username = "admin",
			Password = "pass1"
		});
	});


RunTarget("Deploy");
```


## Example

A complete cake build example can be found [here](https://github.com/SharpeRAD/Cake.WebDeploy/blob/master/test/build.cake)
