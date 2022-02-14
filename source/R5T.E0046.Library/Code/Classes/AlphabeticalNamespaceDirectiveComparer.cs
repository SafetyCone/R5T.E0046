using System;
using System.Collections.Generic;


namespace R5T.E0046.Library
{
    public class AlphabeticalNamespaceDirectiveComparer : IComparer<string>
    {
        #region Static

        public static AlphabeticalNamespaceDirectiveComparer Instance { get; } = new();

        #endregion


        public int Compare(string xNamespaceName, string yNamespaceName)
        {
            var output = xNamespaceName.CompareTo(yNamespaceName);
            return output;
        }
    }
}
