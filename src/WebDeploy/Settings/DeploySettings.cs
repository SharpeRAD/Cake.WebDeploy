#region Using Statements
using System;
using System.Collections.Generic;
using System.Diagnostics;

using Cake.Core.IO;
#endregion



namespace Cake.WebDeploy
{
    /// <summary>
    /// The settings used for the deployment
    /// </summary>
    public class DeploySettings
    {
        #region Fields (16)
        private string _PublishUrl = "";
        private RemoteAgent _AgentType = RemoteAgent.None;
        private bool? _NTLM = null;
        private bool _AllowUntrusted;

        private string _ComputerName = "";
        private int _Port;
        private string _SiteName = "";

        private string _Username = "";
        private string _Password = "";

        private TraceLevel _TraceLevel;
        private bool _Delete;
        private bool _WhatIf;

        private FilePath _SourcePath;
        private FilePath _DestinationPath;
        private Dictionary<string, string> _Parameters;
        private List<SkipRule> _DeploymentSkipRules;
        #endregion





        #region Constructor (1)
        /// <summary>
        /// Initializes a new instance of the <see cref="DeploySettings" /> class.
        /// </summary>
        public DeploySettings()
        {
            _PublishUrl = "";
            _AgentType = RemoteAgent.None;
            _NTLM = null;
            _AllowUntrusted = true;

            _ComputerName = "localhost";
            _Port = DeployUtils.DefaultPort;
            _SiteName = "";

            _Username = "";
            _Password = "";

            _TraceLevel = TraceLevel.Info;
            _Delete = true;
            _WhatIf = false;

            _SourcePath = null;
            _DestinationPath = null;
            _Parameters = new Dictionary<string, string>();
            _DeploymentSkipRules = new List<SkipRule>();
        }
        #endregion





        #region Properties (16)
        /// <summary>
        /// Gets or sets the url to publish that package to
        /// </summary>
        public string PublishUrl
        {
            get
            {
                if (!String.IsNullOrEmpty(_PublishUrl))
                {
                    return _PublishUrl;
                }
                else
                {
                    if ((_AgentType == RemoteAgent.WMSvc) || (_AgentType == RemoteAgent.None))
                    {
                        return DeployUtils.GetWmsvcUrl(_ComputerName, _Port, _SiteName);
                    }
                    else
                    {
                        return _ComputerName;
                    }
                }
            }
            set
            {
                _PublishUrl = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of remote agent to connect to
        /// </summary>
        public RemoteAgent AgentType
        {
            get
            {
                return _AgentType;
            }
            set
            {
                _AgentType = value;
            }
        }

        /// <summary>
        /// Gets or sets if NTLM authentication should be used
        /// </summary>
        public bool NTLM
        {
            get
            {

                if (!_NTLM.HasValue)
                {
                    if ((_AgentType == RemoteAgent.WMSvc) || (_AgentType == RemoteAgent.None))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

                return _NTLM.Value;
            }
            set
            {
                _NTLM = value;
            }
        }

        /// <summary>
        /// Gets or sets if untrusted certificates should be allowed
        /// </summary>
        public bool AllowUntrusted
        {
            get
            {
                return _AllowUntrusted;
            }
            set
            {
                _AllowUntrusted = value;
            }
        }


        /// <summary>
        /// Gets or sets the computer name to publish to
        /// </summary>
        public string ComputerName
        {
            get
            {
                return _ComputerName;
            }
            set
            {
                _ComputerName = value;
            }
        }

        /// <summary>
        /// Sets the remote port to connect on
        /// </summary>
        public int Port
        {
            get
            {
                return _Port;
            }
            set
            {
                _Port = value;
            }
        }

        /// <summary>
        /// Sets the name of the website to publish
        /// </summary>
        public string SiteName
        {
            get
            {
                return _SiteName;
            }
            set
            {
                _SiteName = value;
            }
        }


        /// <summary>
        /// Gets or sets the credentials to use when connecting
        /// </summary>
        public string Username
        {
            get
            {
                return _Username;
            }
            set
            {
                _Username = value;
            }
        }

        /// <summary>
        /// Gets or sets the credentials to use when connecting
        /// </summary>
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }


        /// <summary>
        /// Gets or sets the logging trace level
        /// </summary>
        public TraceLevel TraceLevel
        {
            get
            {
                return _TraceLevel;
            }
            set
            {
                _TraceLevel = value;
            }
        }

        /// <summary>
        /// Gets or sets if files that no longer exist should be deleted
        /// </summary>
        public bool Delete
        {
            get
            {
                return _Delete;
            }
            set
            {
                _Delete = value;
            }
        }

        /// <summary>
        /// Gets or sets if operations will not be executed but events will still be fired
        /// </summary>
        public bool WhatIf
        {
            get
            {
                return _WhatIf;
            }
            set
            {
                _WhatIf = value;
            }
        }



        /// <summary>
        /// Gets or sets the source of the package to publish
        /// </summary>
        public FilePath SourcePath
        {
            get
            {
                return _SourcePath;
            }
            set
            {
                _SourcePath = value;
            }
        }

        /// <summary>
        /// Gets or sets the destination of the package to publish to
        /// </summary>
        public FilePath DestinationPath
        {
            get
            {
                return _DestinationPath;
            }
            set
            {
                _DestinationPath = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Parameters" />.
        /// </summary>
        public Dictionary<string, string> Parameters
        {
            get { return _Parameters; }
        }

        /// <summary>
        /// Gets or sets the <see cref="SkipRules" />.
        /// </summary>
        public List<SkipRule> SkipRules
        {
            get { return _DeploymentSkipRules; }
        }
        #endregion
    }
}
