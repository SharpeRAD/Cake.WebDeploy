#region Using Statements
    using System;

    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Core.Annotations;

    using Microsoft.Web.Deployment;
#endregion



namespace Cake.WebDeploy
{
    [CakeAliasCategory("WebDeploy")]
    public static class CakeAliases
    {
        /// <summary>
        /// Deploys the content of a website
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="settings">The publish settings.</param>
        /// <returns>DeploymentChangeSummary.</returns>
        [CakeMethodAlias]
        public static DeploymentChangeSummary DeployWebsite(this ICakeContext context, PublishSettings settings)
        {
            return new WebDeployManager(context.Environment, context.Log).Deploy(settings);
        }
    }
}
