#region Using Statements
using System;
#endregion



namespace Cake.WebDeploy
{
    internal static class DeployUtils
    {
        #region Constants
        internal const string MSDeployHandler = "msdeploy.axd";
        internal const int DefaultPort = 8172;
        #endregion





        #region Methods
        internal static string GetWmsvcUrl(string computerName, int port, string siteName)
        {
            if (!computerName.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                // Some examples of what we might expect here:
                // foo.com:443/MSDeploy/msdeploy.axd
                // foo.com/MSDeploy/msdeploy.axd
                // foo.com:443
                // foo.com

                computerName = DeployUtils.AppendPortIfNotSpecified(computerName, port);
                computerName = DeployUtils.AppendHttpsIfNotSpecified(computerName);
                computerName = DeployUtils.AppendHandlerIfNotSpecified(computerName);
                computerName = DeployUtils.AppendSiteIfNotSpecified(computerName, siteName);
            }

            return computerName;
        }



        internal static string AppendHandlerIfNotSpecified(string publishUrl)
        {
            if (!publishUrl.EndsWith(DeployUtils.MSDeployHandler, StringComparison.OrdinalIgnoreCase))
            {
                if (publishUrl.EndsWith("/"))
                {
                    publishUrl = publishUrl + DeployUtils.MSDeployHandler;
                }
                else
                {
                    publishUrl = publishUrl + "/" + DeployUtils.MSDeployHandler;
                }
            }

            return publishUrl;
        }

        internal static string AppendPortIfNotSpecified(string publishUrl, int port)
        {
            string[] colonParts = publishUrl.Split(new char[] { ':' });

            if (colonParts.Length == 1)
            {
                // No port was specified so we need to add it in
                int slashIndex = publishUrl.IndexOf('/');

                if (slashIndex > -1)
                {
                    //Before slash
                    publishUrl = publishUrl.Insert(slashIndex, ":" + port.ToString());
                }
                else
                {
                    //No Slash
                    publishUrl = publishUrl + ":" + DefaultPort;
                }
            }

            if (colonParts.Length > 1)
            {
                // It's possible that a port was specified, but we're not sure.  Apps like Monaco do weird
                // things like put colon characters in the path and who knows what might happen in the future.
                // We're being extra careful here to make sure that we only look for ports after the hostname.
                // This means right after a colon, but never following ANY '/' characters.

                // Examples of colonParts[0] might be
                // test.com
                // foo.com/bar
                int slashIndex = colonParts[0].IndexOf('/');

                if (slashIndex > -1)
                {
                    // Since a slash was found before the first colon, we know that the first colon was
                    // not used for the port.  Therefore we need to inject the default port before the first slash
                    colonParts[0] = colonParts[0].Insert(slashIndex, ":" + port.ToString());

                    publishUrl = string.Join(":", colonParts);
                }
            }

            return publishUrl;
        }

        internal static string AppendHttpsIfNotSpecified(string publishUrl)
        {
            if (!publishUrl.ToLower().Contains("https://"))
            {
                return string.Format("https://{0}", publishUrl);
            }
            else
            {
                return publishUrl;
            }
        }

        internal static string AppendSiteIfNotSpecified(string publishUrl, string siteName)
        {
            int markIndex = publishUrl.IndexOf('?');

            if ((markIndex > -1) && (markIndex < (publishUrl.Length - 1)))
            {
                string queryString = publishUrl.Substring(markIndex + 1);

                if (!queryString.ToLower().Contains("site=" + siteName.ToLower()))
                {
                    return string.Format("{0}&site={1}", publishUrl, siteName);
                }
                else
                {
                    return publishUrl;
                }
            }
            else
            {
                return string.Format("{0}?site={1}", publishUrl, siteName);
            }
        }
        #endregion
    }
}
