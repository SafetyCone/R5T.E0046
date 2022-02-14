using System;

using R5T.B0001;
using R5T.B0002;
using R5T.T0040;
using R5T.T0044;
using R5T.T0045;
using R5T.T0098;
using R5T.T0113;


namespace R5T.E0046.Library
{
    public static class Instances
    {
        public static ICompilationUnitOperator CompilationUnitOperator { get; } = T0045.CompilationUnitOperator.Instance;
        public static IFileSystemOperator FileSystemOperator { get; } = T0044.FileSystemOperator.Instance;
        public static IOperation Operation { get; } = T0098.Operation.Instance;
        public static INamespaceName NamespaceName { get; } = B0002.NamespaceName.Instance;
        public static IProjectOperator ProjectOperator { get; } = T0113.ProjectOperator.Instance;
        public static IProjectPathsOperator ProjectPathsOperator { get; } = T0040.ProjectPathsOperator.Instance;
        public static ISolutionOperator SolutionOperator { get; } = T0113.SolutionOperator.Instance;
        public static ITypeName TypeName { get; } = B0001.TypeName.Instance;
        public static ITypeNameOperator TypeNameOperator { get; } = B0001.TypeNameOperator.Instance;
    }
}
