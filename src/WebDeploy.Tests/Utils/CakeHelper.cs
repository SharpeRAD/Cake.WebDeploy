#region Using Statements
    using System.IO;

    using Cake.Core;

    using NSubstitute;
#endregion



namespace Cake.WebDeploy.Tests
{
    internal static class CakeHelper
    {
        #region Functions (2)
            public static ICakeEnvironment CreateEnvironment()
            {
                var environment = Substitute.For<ICakeEnvironment>();

                environment.WorkingDirectory = Directory.GetCurrentDirectory();
                environment.WorkingDirectory = environment.WorkingDirectory.Combine("../../../../");

                return environment;
            }

            public static IWebDeployManager CreateWebDeployManager()
            {
                return new WebDeployManager(CakeHelper.CreateEnvironment(), new DebugLog());
            }
        #endregion
    }
}
