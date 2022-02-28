using System;

using R5T.E0046.Library;
using R5T.E0046.T001;


namespace System
{
    public static partial class IUsingNameAliasDirectiveBlockLabelExtensions
    {
        public static string Classes(this IUsingNameAliasDirectiveBlockLabel _)
        {
            return UsingNameAliasDirectiveBlockLabels.Classes;
        }

        public static string Default(this IUsingNameAliasDirectiveBlockLabel _)
        {
            return UsingNameAliasDirectiveBlockLabels.Default;
        }

        public static string Interfaces(this IUsingNameAliasDirectiveBlockLabel _)
        {
            return UsingNameAliasDirectiveBlockLabels.Interfaces;
        }
    }
}
