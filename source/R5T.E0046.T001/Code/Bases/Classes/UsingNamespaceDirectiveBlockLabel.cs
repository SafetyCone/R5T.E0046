using System;


namespace R5T.E0046.T001
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class UsingNamespaceDirectiveBlockLabel : IUsingNamespaceDirectiveBlockLabel
    {
        #region Static
        
        public static UsingNamespaceDirectiveBlockLabel Instance { get; } = new();

        #endregion
    }
}