﻿using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.E0046.Library
{
    [ServiceImplementationMarker]
    public class UsingNameAliasDirectiveBlockSortOrderProvider : IUsingNameAliasDirectiveBlockSortOrderProvider, IServiceImplementation
    {
        public Task<UsingDirectiveBlockSortOrder> GetUsingNameAliasDirectiveBlockSortOrder()
        {
            throw new NotImplementedException();
        }
    }
}
