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
        /// <param name="settings">The deployment settings.</param>
        /// <returns>The <see cref="DeploymentChangeSummary"/> that was applied during the deployment.</returns>
        DeploymentChangeSummary Deploy(DeploySettings settings);
    }
}
