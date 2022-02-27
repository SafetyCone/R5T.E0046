﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.E0046.Library
{
    [ServiceDefinitionMarker]
    public interface IUsingNamespaceDirectiveComparerProvider : IServiceDefinition
    {
        public Task<IComparer<string>> GetComparer(string blockLabel);
    }
}