#region Using Statements
using Cake.Core;
using Cake.Core.Annotations;

using Microsoft.Web.Deployment;
#endregion



namespace Cake.WebDeploy
{
    /// <summary>
    /// Contains Cake aliases for WebDeploy
    /// </summary>
    [CakeAliasCategory("WebDeploy")]
    [CakeNamespaceImport("Microsoft.Web.Deployment")]
    public static class WebDeployAliases
    {
        #region Methods
        /// <summary>
        /// Deploys the content of a website
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="settings">The deployment settings.</param>
        /// <returns>The <see cref="DeploymentChangeSummary"/> that was applied during the deployment.</returns>
        [CakeMethodAlias]
        public static DeploymentChangeSummary DeployWebsite(this ICakeContext context, DeploySettings settings)
        {
            return new WebDeployManager(context.Environment, context.Log).Deploy(settings);
        }
        #endregion
    }
}
