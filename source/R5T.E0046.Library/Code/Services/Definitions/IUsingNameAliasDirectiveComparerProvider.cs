﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0064;


namespace R5T.E0046.Library
{
    [ServiceDefinitionMarker]
    public interface IUsingNameAliasDirectiveComparerProvider : IServiceDefinition
    {
        public Task<IComparer<NameAlias>> GetComparer(string blockLabel);
    }
}
