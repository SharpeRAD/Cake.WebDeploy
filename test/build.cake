#addin "Cake.WebDeploy"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");





//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

var solutions       = GetFiles("../src/TestSite.sln");





///////////////////////////////////////////////////////////////////////////////
// TASK DEFINITIONS
///////////////////////////////////////////////////////////////////////////////

Task("Build")
	.Description("Publish the website to a zip package")
    .Does(() =>
{
    // Build all solutions.
    foreach(var solution in solutions)
    {
		Information("Building {0}", solution);

		//You need to include the 'DeployOnBuild' property to create the publish zip
		MSBuild(solution, settings => 
			settings.SetPlatformTarget(PlatformTarget.MSIL)
				.WithProperty("TreatWarningsAsErrors","true")
				.WithProperty("DeployOnBuild","true")
				.WithTarget("Build")
				.SetConfiguration(configuration));
    }
});

Task("Deploy")
	.IsDependentOn("Build")
	.Description("Deploy an example website")
	.Does(() =>
	{
		DeployWebsite(new PublishSettings()
		{
			SourcePath = "../src/WebDeploy.TestSite/obj/Release/Package/Cake.WebDeploy.TestSite.zip",
			SiteName = "TestSite",

			ComputerName = "remote-location",
			Username = "admin",
			Password = "pass1"
		});
	});



//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Deploy");





///////////////////////////////////////////////////////////////////////////////
// EXECUTION
///////////////////////////////////////////////////////////////////////////////

RunTarget(target);