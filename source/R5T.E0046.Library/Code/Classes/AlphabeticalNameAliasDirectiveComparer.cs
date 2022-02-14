using System;
using System.Collections.Generic;

using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.E0046.Library
{
    public class AlphabeticalNameAliasDirectiveComparer : IComparer<NameAlias>
    {
        #region Static

        public static AlphabeticalNameAliasDirectiveComparer Instance { get; } = new();

        #endregion


        public int Compare(NameAlias xNameAlias, NameAlias yNameAlias)
        {
            var output = xNameAlias.CompareTo(yNameAlias);
            return output;
        }
    }
}
