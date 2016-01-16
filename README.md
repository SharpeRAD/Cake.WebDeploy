# Cake.WebDeploy
Cake-Build addin that extends Cake with WebDeploy commands for publishing to IIS

[![Build status](https://ci.appveyor.com/api/projects/status/rld9874ha4woe9m7?svg=true)](https://ci.appveyor.com/project/SharpeRAD/cake-webdeploy)

[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)

[![Join the chat at https://gitter.im/cake-build/cake](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/cake-build/cake)



## Table of contents

1. [Implemented functionality](https://github.com/SharpeRAD/Cake.WebDeploy#implemented-functionality)
2. [Referencing](https://github.com/SharpeRAD/Cake.WebDeploy#referencing)
3. [Usage](https://github.com/SharpeRAD/Cake.WebDeploy#usage)
4. [Example](https://github.com/SharpeRAD/Cake.WebDeploy#example)
5. [TroubleShooting](https://github.com/SharpeRAD/Cake.WebDeploy#troubleshooting)
6. [Plays well with](https://github.com/SharpeRAD/Cake.WebDeploy#plays-well-with)
7. [License](https://github.com/SharpeRAD/Cake.WebDeploy#license)
8. [Share the love](https://github.com/SharpeRAD/Cake.WebDeploy#share-the-love)



## Implemented functionality

* Deploy websites from a package or folder
* Locally / remotely using credentials
* Outputting the trace information to the cake log
* Testing changes using WhatIf flag



## Referencing

[![NuGet Version](http://img.shields.io/nuget/v/Cake.WebDeploy.svg?style=flat)](https://www.nuget.org/packages/Cake.WebDeploy/) [![NuGet Downloads](http://img.shields.io/nuget/dt/Cake.WebDeploy.svg?style=flat)](https://www.nuget.org/packages/Cake.WebDeploy/)

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


Task("Deploy-Folder")
    .Description("Deploy to/from folders")
    .Does(() =>
    {
        DeployWebsite(new DeploySettings()
        {
            SourcePath = "./src/Website/",
            DestinationPath = @"C:/src/Websites/Test/",

            Username = "admin",
            Password = "pass1"
        });
    });


Task("Deploy-Url")
    .Description("Deploy to Azure using a custom Url")
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

A complete Cake example can be found [here](https://github.com/SharpeRAD/Cake.WebDeploy/blob/master/test/build.cake).



## TroubleShooting

A few pointers for correctly enabling WebDeploy scripting can be found [here](https://github.com/SharpeRAD/Cake.WebDeploy/blob/master/TroubleShooting.md).



## Plays well with

If your looking to manage IIS its worth checking out [Cake.IIS](https://github.com/SharpeRAD/Cake.IIS) or if your running a WebFarm inside AWS then check out [Cake.AWS.ElasticLoadBalancing](https://github.com/SharpeRAD/Cake.AWS.ElasticLoadBalancing).

If your looking for a way to trigger cake tasks based on windows events or at scheduled intervals then check out [Cake.CakeBoss](https://github.com/SharpeRAD/CakeBoss).



## License

Copyright � 2015 - 2016 Phillip Sharpe

Cake.WebDeploy is provided as-is under the MIT license. For more information see [LICENSE](https://github.com/SharpeRAD/Cake.WebDeploy/blob/master/LICENSE).



## Share the love

If this project helps you in anyway then please :star: the repository.
