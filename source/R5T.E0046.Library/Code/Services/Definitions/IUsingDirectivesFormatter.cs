using System;

using R5T.T0064;


namespace R5T.E0046.Library
{
    [ServiceDefinitionMarker]
    public interface IUsingDirectivesFormatter : IServiceDefinition
    {
        IUsingNameAliasDirectiveBlockLabelProvider NameAliasBlockLabelProvider { get; }
        IUsingNameAliasDirectiveBlockSortOrderProvider NameAliasBlockSortOrderProvider { get; }
        IUsingNameAliasDirectiveComparerProvider NameAliasComparerProvider { get; }

        IUsingNamespaceDirectiveBlockLabelProvider NamespaceBlockLabelProvider { get; }
        IUsingNamespaceDirectiveBlockSortOrderProvider NamespaceBlockSortOrderProvider { get; }
        IUsingNamespaceDirectiveComparerProvider NamespaceComparerProvider { get; }
    }
}
