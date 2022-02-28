using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.E0046.Library
{
    [ServiceImplementationMarker]
    public class RivetUsingNamespaceDirectiveBlockSortOrderProvider : IUsingNamespaceDirectiveBlockSortOrderProvider, IServiceImplementation
    {
        public Task<UsingDirectiveBlockSortOrder> GetUsingNamespaceDirectiveBlockSortOrder()
        {
            var usingNamespaceDirectivesSortOrder = Instances.UsingDirectiveBlockSortOrder.RivetNamespaces();

            return Task.FromResult(usingNamespaceDirectivesSortOrder);
        }
    }
}
