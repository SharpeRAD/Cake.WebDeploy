#region Using Statements
using System.IO;

using Xunit;
#endregion



namespace Cake.WebDeploy.Tests
{
    public class WebDeployTests
    {
        #region Methods (2)
        [Fact]
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

            settings.SourcePath = "./src/WebDeploy.TestSite/obj/Release/Package/Cake.WebDeploy.TestSite.zip";
            settings.ParametersFilePath = "./src/WebDeploy.TestSite/obj/Release/Package/Cake.WebDeploy.SetParameters.xml";


            manager.Deploy(settings);



            //Asert
            Assert.True(File.Exists(deployDir + "web.config"));
        }



        [Fact]
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

            settings.SourcePath = "./src/WebDeploy.TestSite/obj/Release/Package/PackageTmp/";
            settings.DestinationPath = deployDir;

            manager.Deploy(settings);



            //Asert
            Assert.True(File.Exists(deployDir + "web.config"));
        }
        #endregion
    }
}