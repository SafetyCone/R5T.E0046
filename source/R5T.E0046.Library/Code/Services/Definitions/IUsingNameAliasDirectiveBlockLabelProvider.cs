using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.E0046.Library
{
    [ServiceDefinitionMarker]
    public interface IUsingNameAliasDirectiveBlockLabelProvider : IServiceDefinition
    {
        public Task<string> GetBlockLabel(
            string destinationName,
            string sourceNameExpression,
            string localNamespaceName);
    }
}
