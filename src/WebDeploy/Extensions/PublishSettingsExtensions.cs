#region Using Statements
    using System;
    using System.Diagnostics;
#endregion



namespace Cake.WebDeploy
{
    /// <summary>
    /// Contains extension methods for <see cref="PublishSettings" />.
    /// </summary>
    public static class PublishSettingsExtensions
    {
        /// <summary>
        /// Sets the url to publish that package to
        /// </summary>
        /// <param name="settings">The publish settings.</param>
        /// <param name="url">The publish url</param>
        /// <returns>The same <see cref="PublishSettings"/> instance so that multiple calls can be chained.</returns>
        public static PublishSettings SetPublishUrl(this PublishSettings settings, string url)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.PublishUrl = url;
            return settings;
        }

        /// <summary>
        /// Sets the type of remote agent to connect to
        /// </summary>
        /// <param name="settings">The publish settings.</param>
        /// <param name="agentType">The type of remote agent</param>
        /// <returns>The same <see cref="PublishSettings"/> instance so that multiple calls can be chained.</returns>
        public static PublishSettings UseAgentType(this PublishSettings settings, RemoteAgent agentType)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.AgentType = agentType;
            return settings;
        }

        /// <summary>
        /// Sets if NTLM authentication should be used
        /// </summary>
        /// <param name="settings">The publish settings.</param>
        /// <param name="ntlm">use NTLM</param>
        /// <returns>The same <see cref="PublishSettings"/> instance so that multiple calls can be chained.</returns>
        public static PublishSettings UseNTLM(this PublishSettings settings, bool ntlm = true)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.NTLM = ntlm;
            return settings;
        }

        /// <summary>
        /// Sets if untrusted certificates should be allowed
        /// </summary>
        /// <param name="settings">The publish settings.</param>
        /// <param name="untrusted">Allow untrusted certificates</param>
        /// <returns>The same <see cref="PublishSettings"/> instance so that multiple calls can be chained.</returns>
        public static PublishSettings SetAllowUntrusted(this PublishSettings settings, bool untrusted = true)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.AllowUntrusted = untrusted;
            return settings;
        }



        /// <summary>
        /// Sets the computer name on publish to
        /// </summary>
        /// <param name="settings">The publish settings.</param>
        /// <param name="name">The computer name</param>
        /// <returns>The same <see cref="PublishSettings"/> instance so that multiple calls can be chained.</returns>
        public static PublishSettings UseComputerName(this PublishSettings settings, string name)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.ComputerName = name;
            return settings;
        }

        /// <summary>
        /// Sets the remote port to connect on.
        /// </summary>
        /// <param name="settings">The publish settings.</param>
        /// <param name="path">The working directory for the process to be started.</param>
        /// <returns>The same <see cref="PublishSettings"/> instance so that multiple calls can be chained.</returns>
        public static PublishSettings UsePort(this PublishSettings settings, int port)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.Port = port;
            return settings;
        }

        /// <summary>
        /// Sets the name of the website to publish
        /// </summary>
        /// <param name="settings">The publish settings.</param>
        /// <param name="name">The name of the website to publish</param>
        /// <returns>The same <see cref="PublishSettings"/> instance so that multiple calls can be chained.</returns>
        public static PublishSettings UseSiteName(this PublishSettings settings, string name)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.ComputerName = name;
            return settings;
        }



        /// <summary>
        /// Sets the credentials to use when connecting
        /// </summary>
        /// <param name="settings">The publish settings.</param>
        /// <param name="username">The username to connect with.</param>
        /// <returns>The same <see cref="PublishSettings"/> instance so that multiple calls can be chained.</returns>
        public static PublishSettings UseUsername(this PublishSettings settings, string username)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.Username = username;
            return settings;
        }

        /// <summary>
        /// Sets the credentials to use when connecting
        /// </summary>
        /// <param name="settings">The publish settings.</param>
        /// <param name="password">The password to connect with.</param>
        /// <returns>The same <see cref="PublishSettings"/> instance so that multiple calls can be chained.</returns>
        public static PublishSettings UsePassword(this PublishSettings settings, string password)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.Password = password;
            return settings;
        }
        


        /// <summary>
        /// Sets the logging trace level
        /// </summary>
        /// <param name="settings">The publish settings.</param>
        /// <param name="level">The trace level.</param>
        /// <returns>The same <see cref="PublishSettings"/> instance so that multiple calls can be chained.</returns>
        public static PublishSettings SetTraceLevel(this PublishSettings settings, TraceLevel level)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.TraceLevel = level;
            return settings;
        }

        /// <summary>
        /// Sets if files that no longer exist should be deleted
        /// </summary>
        /// <param name="settings">The publish settings.</param>
        /// <param name="delete">IF files should be deleted.</param>
        /// <returns>The same <see cref="PublishSettings"/> instance so that multiple calls can be chained.</returns>
        public static PublishSettings SetDelete(this PublishSettings settings, bool delete = true)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.Delete = delete;
            return settings;
        }

        /// <summary>
        /// Sets if operations will not be executed but events will still be fired
        /// </summary>
        /// <param name="settings">The publish settings.</param>
        /// <param name="whatIf">If operations will not be executed</param>
        /// <returns>The same <see cref="PublishSettings"/> instance so that multiple calls can be chained.</returns>
        public static PublishSettings SetWhatIf(this PublishSettings settings, bool whatIf = true)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.WhatIf = whatIf;
            return settings;
        }


        /// <summary>
        /// Sets the source of the package to publish
        /// </summary>
        /// <param name="settings">The publish settings.</param>
        /// <param name="path">The path to the package to publish</param>
        /// <returns>The same <see cref="PublishSettings"/> instance so that multiple calls can be chained.</returns>
        public static PublishSettings SetSourcePath(this PublishSettings settings, string path)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.SourcePath = path;
            return settings;
        }

        /// <summary>
        /// Sets the destination of the package to publish to
        /// </summary>
        /// <param name="settings">The publish settings.</param>
        /// <param name="path">The path where the package should end up</param>
        /// <returns>The same <see cref="PublishSettings"/> instance so that multiple calls can be chained.</returns>
        public static PublishSettings SetDestinationPath(this PublishSettings settings, string path)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings.DestinationPath = path;
            return settings;
        }

    }
}
