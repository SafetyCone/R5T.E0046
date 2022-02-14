using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.E0046.Library
{
    [ServiceDefinitionMarker]
    public interface IUsingNameAliasDirectiveBlockSortOrderProvider : IServiceDefinition
    {
        Task<UsingDirectiveBlockSortOrder> GetUsingNameAliasDirectiveBlockSortOrder();
    }
}
