using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.E0046.Library
{
    [ServiceImplementationMarker]
    public class UsingNameAliasDirectiveBlockLabelProvider : IUsingNameAliasDirectiveBlockLabelProvider, IServiceImplementation
    {
        public Task<string> GetBlockLabel(
            string destinationName,
            string sourceNameExpression,
            string localNamespaceName)
        {
            string Internal()
            {
                var isDocumentation = Instances.TypeNameOperator.Equals(
                    destinationName,
                    Instances.TypeName.Documentation());
                if (isDocumentation)
                {
                    return Instances.UsingNameAliasDirectiveBlockLabel.Documentation();
                }

                var isGlossary = Instances.TypeNameOperator.Equals(
                    destinationName,
                    Instances.TypeName.Glossary());
                if (isGlossary)
                {
                    return Instances.UsingNameAliasDirectiveBlockLabel.Documentation();
                }

                var isInstances = Instances.TypeNameOperator.Equals(
                    destinationName,
                    Instances.TypeName.Instances());
                if (isInstances)
                {
                    return Instances.UsingNameAliasDirectiveBlockLabel.Instances();
                }

                var isInterface = Instances.TypeNameOperator.IsInterface(destinationName);
                if (isInterface)
                {
                    return Instances.UsingNameAliasDirectiveBlockLabel.Interfaces();
                }

                // Otherwise, use the default, even if it's a class (as there is no way to tell a class from a namespace).
                var output = Instances.UsingNameAliasDirectiveBlockLabel.Default();
                return output;
            }

            var output = Internal();

            return Task.FromResult(output);
        }
    }
}
