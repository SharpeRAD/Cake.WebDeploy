#region Using Statements
    using System;
    using System.Diagnostics;

    using Cake.Core.IO;
#endregion



namespace Cake.WebDeploy
{
    public class PublishSettings
    {
        #region Fields (9)
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
        #endregion





        #region Constructor (1)
            public PublishSettings()
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
            }
        #endregion





        #region Properties (10)
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
        #endregion
    }
}
