#region Using Statements
using System.IO;

using Cake.Core;
using Cake.Testing;
#endregion



namespace Cake.WebDeploy.Tests
{
    internal static class CakeHelper
    {
        #region Methods (2)
        public static ICakeEnvironment CreateEnvironment()
        {
            var environment = FakeEnvironment.CreateWindowsEnvironment();
            environment.WorkingDirectory = Directory.GetCurrentDirectory();
            environment.WorkingDirectory = environment.WorkingDirectory.Combine("../../../");

            return environment;
        }

        public static IWebDeployManager CreateWebDeployManager()
        {
            return new WebDeployManager(CakeHelper.CreateEnvironment(), new DebugLog());
        }
        #endregion
    }
}
