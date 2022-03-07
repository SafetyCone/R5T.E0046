using System;

using R5T.B0002;
using R5T.B0004;
using R5T.T0034;
using R5T.T0036;
using R5T.T0040;
using R5T.T0045;
using R5T.T0062;
using R5T.T0070;
using R5T.T0098;


namespace R5T.E0046
{
    public static class Instances
    {
        public static IClassGenerator ClassGenerator { get; } = T0045.ClassGenerator.Instance;
        public static IClassName ClassName { get; } = T0036.ClassName.Instance;
        public static IHost Host { get; } = T0070.Host.Instance;
        public static IIndentation Indentation { get; } = T0036.Indentation.Instance;
        public static INamespacedTypeName NamespacedTypeName { get; } = T0034.NamespacedTypeName.Instance;
        public static INamespaceName NamespaceName { get; } = B0002.NamespaceName.Instance;
        public static INamespaceNameOperator NamespaceNameOperator { get; } = B0002.NamespaceNameOperator.Instance;
        public static IOperation Operation { get; } = T0098.Operation.Instance;
        public static IProjectPathsOperator ProjectPathsOperator { get; } = T0040.ProjectPathsOperator.Instance;
        public static IPropertyGenerator PropertyGenerator { get; } = T0045.PropertyGenerator.Instance;
        public static IServiceAction ServiceAction { get; } = T0062.ServiceAction.Instance;
        public static IUsingDirectiveBlockLabel UsingDirectiveBlockLabel { get; } = B0004.UsingDirectiveBlockLabel.Instance;
        public static IUsingDirectiveBlockSortOrder UsingDirectiveBlockSortOrder { get; } = B0004.UsingDirectiveBlockSortOrder.Instance;
        public static IUsingNameAliasDirectiveBlockLabel UsingNameAliasDirectiveBlockLabel { get; } = B0004.UsingNameAliasDirectiveBlockLabel.Instance;
    }
}