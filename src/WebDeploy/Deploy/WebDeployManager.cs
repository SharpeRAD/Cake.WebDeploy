#region Using Statements
    using System;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using System.Net.Security;
    using System.Diagnostics;

    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Core.Diagnostics;

    using Microsoft.Web.Deployment;
#endregion



namespace Cake.WebDeploy
{
    /// <summary>
    /// Responsible for deploying packages
    /// </summary>
    public class WebDeployManager : IWebDeployManager
    {
        #region Fields (2)
            private readonly ICakeEnvironment _Environment;
            private readonly ICakeLog _Log;
        #endregion





        #region Constructor (1)
            /// <summary>
            /// Initializes a new instance of the <see cref="WebDeployManager" /> class.
            /// </summary>
            /// <param name="environment">The environment.</param>
            /// <param name="log">The log.</param>
            public WebDeployManager(ICakeEnvironment environment, ICakeLog log)
            {
                if (environment == null)
                {
                    throw new ArgumentNullException("environment");
                }
                if (log == null)
                {
                    throw new ArgumentNullException("log");
                }

                _Environment = environment;
                _Log = log;
            }
        #endregion





        #region Functions (4)
            /// <summary>
            /// Deploys the content of a website
            /// </summary>
            /// <param name="settings">The deployment settings.</param>
            /// <returns>The <see cref="DeploymentChangeSummary"/> that was applied during the deployment.</returns>
            public DeploymentChangeSummary Deploy(DeploySettings settings)
            {
                if (settings == null)
                {
                    throw new ArgumentNullException("settings");
                }
                if (settings.SourcePath == null)
                {
                    throw new ArgumentNullException("settings.SourcePath");
                }



                DeploymentBaseOptions sourceOptions = new DeploymentBaseOptions();
                DeploymentBaseOptions destOptions = this.GetBaseOptions(settings);

                FilePath sourcePath = settings.SourcePath.MakeAbsolute(_Environment);
                string destPath = settings.SiteName;

                destOptions.TraceLevel = settings.TraceLevel;
                destOptions.Trace += OnTraceEvent;

                DeploymentWellKnownProvider sourceProvider = DeploymentWellKnownProvider.ContentPath;
                DeploymentWellKnownProvider destProvider = DeploymentWellKnownProvider.Auto;



                //If a target path was specified, it could be virtual or physical
                if (settings.DestinationPath != null)
                {
                    if (System.IO.Path.IsPathRooted(settings.DestinationPath.FullPath))
                    {
                        // If it's rooted (e.g. d:\home\site\foo), use DirPath
                        sourceProvider = DeploymentWellKnownProvider.DirPath;
                        destProvider = DeploymentWellKnownProvider.DirPath;

                        destPath = settings.DestinationPath.FullPath;
                    }
                    else
                    {
                        // It's virtual, so append it to what we got from the publish profile
                        destPath += "/" + settings.DestinationPath.FullPath;
                    }
                }
                //When a SiteName is given but no DestinationPath
                else if (!String.IsNullOrWhiteSpace(settings.SiteName))
                {
                    //use ContentPath so it gets deployed to the Path of the named website in IIS
                    //which is the same behaviour as in Visual Studio
                    destProvider = DeploymentWellKnownProvider.ContentPath;
                }



                //If the content path is a zip file, use the Package provider
                string extension = sourcePath.GetExtension();
                if (extension != null && extension.Equals(".zip", StringComparison.OrdinalIgnoreCase))
                {
                    // For some reason, we can't combine a zip with a physical target path
                    if (destProvider == DeploymentWellKnownProvider.DirPath)
                    {
                        throw new Exception("A source zip file can't be used with a physical target path");
                    }

                    sourceProvider = DeploymentWellKnownProvider.Package;
                }



                //Sync Options
                DeploymentSyncOptions syncOptions = new DeploymentSyncOptions
                {
                    DoNotDelete = !settings.Delete,
                    WhatIf = settings.WhatIf
                };



                //Deploy
                _Log.Debug(Verbosity.Normal, "Deploying Website...");
                _Log.Debug(Verbosity.Normal, String.Format("-siteName '{0}'", settings.SiteName));
                _Log.Debug(Verbosity.Normal, String.Format("-destination '{0}'", settings.PublishUrl));
                _Log.Debug(Verbosity.Normal, String.Format("-source '{0}'", sourcePath.FullPath));
                _Log.Debug("");

                using (var deploymentObject = DeploymentManager.CreateObject(sourceProvider, sourcePath.FullPath, sourceOptions))
                {
                    foreach (var kv in settings.Parameters)
                    {
                        deploymentObject.SyncParameters[kv.Key].Value = kv.Value;
                    }

                    return deploymentObject.SyncTo(destProvider, destPath, destOptions, syncOptions);
                }
            }



            //Helpers
            private DeploymentBaseOptions GetBaseOptions(DeploySettings settings)
            {
                DeploymentBaseOptions options = new DeploymentBaseOptions
                {
                    ComputerName = settings.PublishUrl,

                    UserName = settings.Username,
                    Password = settings.Password,

                    AuthenticationType = settings.NTLM ? "ntlm" : "basic"
                };

                if (settings.AllowUntrusted)
                {
                    ServicePointManager.ServerCertificateValidationCallback = OnCertificateValidation;
                }

                return options;
            }

            private void OnTraceEvent(object sender, DeploymentTraceEventArgs e)
            {
                switch(e.EventLevel)
                {
                    case TraceLevel.Error:
                        _Log.Error(e.Message);
                        break;

                    case TraceLevel.Warning:
                        _Log.Warning(e.Message);
                        break;

                    case TraceLevel.Info:
                        _Log.Information(e.Message);
                        break;

                    case TraceLevel.Verbose:
                        _Log.Verbose(e.Message);
                        break;
                }
            }

            private bool OnCertificateValidation(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors errors)
            {
                return true;
            }
        #endregion
    }
}
