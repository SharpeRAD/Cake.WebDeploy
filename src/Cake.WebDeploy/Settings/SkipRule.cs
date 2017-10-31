#region Using Statements
using System;
#endregion



namespace Cake.WebDeploy
{
    /// <summary>
    /// Instructions that should be performed during the deployment
    /// </summary>
    public class SkipRule
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SkipRule" /> class.
        /// </summary>
        public SkipRule()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkipRule" /> class.
        /// </summary>
        public SkipRule(string name, string skipAction, string objectName, string absolutePath, string xpath = null)
        {
            Name = name;
            SkipAction = skipAction;
            ObjectName = objectName;
            AbsolutePath = absolutePath;
            XPath = xpath;
        }
        #endregion





        #region Properties
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the SkipAction.
        /// </summary>
        public string SkipAction { get; set; }

        /// <summary>
        /// Gets or sets the ObjectName.
        /// </summary>
        public string ObjectName { get; set; }

        /// <summary>
        /// Gets or sets the AbsolutePath.
        /// </summary>
        public string AbsolutePath { get; set; }

        /// <summary>
        /// Gets or sets the XPath.
        /// </summary>
        public string XPath { get; set; }
        #endregion
    }
}
