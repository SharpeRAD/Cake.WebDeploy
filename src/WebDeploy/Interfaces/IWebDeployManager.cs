#region Using Statements
using Microsoft.Web.Deployment;
#endregion



namespace Cake.WebDeploy
{
    /// <summary>
    /// Responsible for deploying packages
    /// </summary>
    public interface IWebDeployManager
    {
        #region Methods (1)
        /// <summary>
        /// Deploys the content of a website
        /// </summary>
        /// <param name="settings">The deployment settings.</param>
        /// <returns>The <see cref="DeploymentChangeSummary"/> that was applied during the deployment.</returns>
        DeploymentChangeSummary Deploy(DeploySettings settings);
        #endregion
    }
}
