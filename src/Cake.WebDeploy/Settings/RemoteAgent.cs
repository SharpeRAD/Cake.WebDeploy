namespace Cake.WebDeploy
{
    /// <summary>
    /// The type of agent used during the deplyment
    /// </summary>
    public enum RemoteAgent
    {
        /// <summary>
        /// IIS Web Management Service
        /// </summary>
        WMSvc,

        /// <summary>
        /// Microsoft Deploymnent Service
        /// </summary>
        MSDepSvc,

        /// <summary>
        /// Temporary Agent
        /// </summary>
        TempAgent,

        /// <summary>
        /// None
        /// </summary>
        None,
    }
}
