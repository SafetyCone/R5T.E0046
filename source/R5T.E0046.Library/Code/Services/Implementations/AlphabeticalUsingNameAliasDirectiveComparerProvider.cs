﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0064;


namespace R5T.E0046.Library
{
    [ServiceImplementationMarker]
    public class AlphabeticalUsingNameAliasDirectiveComparerProvider : IUsingNameAliasDirectiveComparerProvider, IServiceImplementation
    {
        public Task<IComparer<NameAlias>> GetComparer(string _)
        {
            var output = AlphabeticalNameAliasDirectiveComparer.Instance;

            return Task.FromResult(output as IComparer<NameAlias>);
        }
    }
}
