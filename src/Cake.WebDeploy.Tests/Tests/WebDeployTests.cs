#region Using Statements
using System.IO;

using Xunit;
#endregion



namespace Cake.WebDeploy.Tests
{
    public class WebDeployTests
    {
        #region Methods
        [Fact(Skip = "Not working on AppVeyor")]
        public void Should_Deploy_Website_At_Default_Path()
        {
            //Clear
            string deployDir = @"C:/inetpub/wwwroot/";
           
            if (File.Exists(deployDir + "web.config"))
            {
                File.Delete(deployDir + "web.config");
            }

            

            //Deploy
            IWebDeployManager manager = CakeHelper.CreateWebDeployManager();

            DeploySettings settings = new DeploySettings();
            
            settings.SiteName = "Default Web Site";
            settings.NTLM = true;

            settings.SourcePath = "./Cake.WebDeploy.TestSite/obj/Release/Package/Cake.WebDeploy.TestSite.zip";
            settings.ParametersFilePath = "./Cake.WebDeploy.TestSite/obj/Release/Package/Cake.WebDeploy.TestSite.Parameters.xml";


            manager.Deploy(settings);



            //Asert
            Assert.True(File.Exists(deployDir + "web.config"));
        }



        [Fact(Skip = "Not working on AppVeyor")]
        public void Should_Deploy_Website_At_Specified_Path()
        {
            //Clear
            string deployDir = @"C:/inetpub/test/";

            if (File.Exists(deployDir + "web.config"))
            {
                File.Delete(deployDir + "web.config");
            }



            //Deploy
            IWebDeployManager manager = CakeHelper.CreateWebDeployManager();

            DeploySettings settings = new DeploySettings();

            settings.SiteName = "Default Web Site";
            settings.NTLM = true;

            settings.SourcePath = "./Cake.WebDeploy.TestSite/obj/Release/netcoreapp1.1/PubTmp/Out/";
            settings.DestinationPath = deployDir;

            manager.Deploy(settings);



            //Asert
            Assert.True(File.Exists(deployDir + "web.config"));
        }



        [Fact]
        public void Should_Append_Port()
        {
            DeploySettings settings = new DeploySettings()
                .SetAllowUntrusted(true)
                .FromSourcePath("./deployment/PATH")
                .UseSiteName("Test").UsePort(8172)
                .UseComputerName("XXX")
                .UseUsername(@"YYY")
                .UsePassword("ZZZ");

            Assert.Equal("https://XXX:8172/msdeploy.axd?site=Test", settings.PublishUrl);
        }



        [Fact]
        public void Should_Use_AppOffline()
        {
            DeploySettings deploySettings = new DeploySettings();

            Assert.False(deploySettings.UseAppOffline);

            deploySettings.UseAppOffline(true);

            Assert.True(deploySettings.UseAppOffline);
        }
        #endregion
    }
}