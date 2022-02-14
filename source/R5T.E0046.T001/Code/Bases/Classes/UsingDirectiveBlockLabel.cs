using System;


namespace R5T.E0046.T001
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class UsingDirectiveBlockLabel : IUsingDirectiveBlockLabel
    {
        #region Static
        
        public static UsingDirectiveBlockLabel Instance { get; } = new();

        #endregion
    }
}