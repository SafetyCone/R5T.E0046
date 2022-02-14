using System;


namespace R5T.E0046.T001
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class UsingDirectiveBlockSortOrder : IUsingDirectiveBlockSortOrder
    {
        #region Static
        
        public static UsingDirectiveBlockSortOrder Instance { get; } = new();

        #endregion
    }
}