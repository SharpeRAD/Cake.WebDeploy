#region Using Statements
    using System;

    using Microsoft.Web.Deployment;
#endregion



namespace Cake.WebDeploy
{
    public interface IWebDeployManager
    {
        /// <summary>
        /// Deploys the content of a website
        /// </summary>
        /// <param name="settings">The publish settings.</param>
        /// <returns>DeploymentChangeSummary.</returns>
        DeploymentChangeSummary Deploy(PublishSettings settings);
    }
}
