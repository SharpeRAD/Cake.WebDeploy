# Cake.WebDeploy
Cake-Build addin that extends Cake with WebDeploy commands for publishing to IIS

[![Build status](https://ci.appveyor.com/api/projects/status/rld9874ha4woe9m7?svg=true)](https://ci.appveyor.com/project/PhillipSharpe/cake-webdeploy)

[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)

[![Join the chat at https://gitter.im/cake-build/cake](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/cake-build/cake?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)



## Implemented functionality

* Deploy websites from a package or folder
* Locally / remotely using credentials
* Outputting the trace information to the cake log



## Referencing

Cake.WebDeploy is available as a nuget package from the package manager console:

```csharp
Install-Package Cake.WebDeploy
```

or directly in your build script via a cake addin:

```csharp
#addin "Cake.WebDeploy"
```



## Usage

```csharp
#addin "Cake.WebDeploy"


Task("Deploy")
    .Description("Deploy to a remote computer with web deployment agent installed")
    .Does(() =>
	{
		DeployWebsite(new DeploySettings()
		{
			SourcePath = "./src/Package.zip",
			SiteName = "TestSite",

			ComputerName = "remote-location",
			Username = "admin",
			Password = "pass1"
		});
	});


Task("Deploy-Custom")
    .Description("Deploy to Azure using a custom url")
    .Does(() =>
	{
		DeployWebsite(new DeploySettings()
		{
			SourcePath = "./src/Package.zip",
			PublishUrl = "{WEBSITENAME}.scm.azurewebsites.net",
			Username = "admin",
			Password = "pass1"
		});
	});


Task("Deploy-Fluent")
    .Description("Deploy using fluent settings")
    .Does(() =>
	{
		DeployWebsite(new DeploySettings()
			.FromSourcePath("./src/Package.zip")
			.UseSiteName("TestSite")
			.UseComputerName("remote-location")
			.UseUsername("admin")
			.UsePassword("pass1"));
	});
	

Task("Deploy-WhatIf")
    .Description("See what would occur when publishing (WhatIf) and files should be deleted if they don't exist (Delete)")
    .Does(() =>
	{
		DeployWebsite(new DeploySettings()
		{
			SourcePath = "./src/Package.zip",
			Username = "admin",
			Password = "pass1",

			Delete = true,
			WhatIf = true
		});
	});


RunTarget("Deploy");
```



## Example

A complete Cake example can be found [here](https://github.com/SharpeRAD/Cake.WebDeploy/blob/master/test/build.cake)



## TroubleShooting

A few pointers for correctly enabling WebDeploy scripting can be found [here](https://github.com/SharpeRAD/Cake.WebDeploy/blob/master/TroubleShooting.md)