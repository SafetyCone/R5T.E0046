using System;

using R5T.B0002;
using R5T.T0040;
using R5T.T0062;
using R5T.T0070;


namespace R5T.E0046
{
    public static class Instances
    {
        public static IHost Host { get; } = T0070.Host.Instance;
        public static INamespaceName NamespaceName { get; } = B0002.NamespaceName.Instance;
        public static IProjectPathsOperator ProjectPathsOperator { get; } = T0040.ProjectPathsOperator.Instance;
        public static IServiceAction ServiceAction { get; } = T0062.ServiceAction.Instance;
    }
}