using System;

using R5T.B0002;
using R5T.T0040;
using R5T.T0062;
using R5T.T0070;
using R5T.T0098;

using R5T.E0046.T001;


namespace R5T.E0046
{
    public static class Instances
    {
        public static IHost Host { get; } = T0070.Host.Instance;
        public static INamespaceName NamespaceName { get; } = B0002.NamespaceName.Instance;
        public static IOperation Operation { get; } = T0098.Operation.Instance;
        public static IProjectPathsOperator ProjectPathsOperator { get; } = T0040.ProjectPathsOperator.Instance;
        public static IServiceAction ServiceAction { get; } = T0062.ServiceAction.Instance;
        public static IUsingDirectiveBlockLabel UsingDirectiveBlockLabel { get; } = T001.UsingDirectiveBlockLabel.Instance;
        public static IUsingDirectiveBlockSortOrder UsingDirectiveBlockSortOrder { get; } = T001.UsingDirectiveBlockSortOrder.Instance;
        public static IUsingNameAliasDirectiveBlockLabel UsingNameAliasDirectiveBlockLabel { get; } = T001.UsingNameAliasDirectiveBlockLabel.Instance;
    }
}