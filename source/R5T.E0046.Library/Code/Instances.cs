using System;

using R5T.B0001;
using R5T.B0002;
using R5T.B0004;
using R5T.T0034;
using R5T.T0036;
using R5T.T0040;
using R5T.T0044;
using R5T.T0045;
using R5T.T0098;
using R5T.T0113;

using ITypeName = R5T.B0001.ITypeName;


namespace R5T.E0046.Library
{
    public static class Instances
    {
        public static IClassGenerator ClassGenerator { get; } = T0045.ClassGenerator.Instance;
        public static IClassName ClassName { get; } = T0036.ClassName.Instance;
        public static ICompilationUnitOperator CompilationUnitOperator { get; } = T0045.CompilationUnitOperator.Instance;
        public static IFileSystemOperator FileSystemOperator { get; } = T0044.FileSystemOperator.Instance;
        public static IIndentation Indentation { get; } = T0036.Indentation.Instance;
        public static INamespaceGenerator NamespaceGenerator { get; } = T0045.NamespaceGenerator.Instance;
        public static INamespacedTypeName NamespacedTypeName { get; } = T0034.NamespacedTypeName.Instance;
        public static INamespaceName NamespaceName { get; } = B0002.NamespaceName.Instance;
        public static INamespaceNameOperator NamespaceNameOperator { get; } = B0002.NamespaceNameOperator.Instance;
        public static INamespaceNameTokenOperator NamespaceNameTokenOperator { get; } = B0002.NamespaceNameTokenOperator.Instance;
        public static IOperation Operation { get; } = T0098.Operation.Instance;
        public static IProjectOperator ProjectOperator { get; } = T0113.ProjectOperator.Instance;
        public static IProjectPathsOperator ProjectPathsOperator { get; } = T0040.ProjectPathsOperator.Instance;
        public static IPropertyGenerator PropertyGenerator { get; } = T0045.PropertyGenerator.Instance;
        public static ISolutionOperator SolutionOperator { get; } = T0113.SolutionOperator.Instance;
        public static ITypeName TypeName { get; } = B0001.TypeName.Instance;
        public static ITypeNameOperator TypeNameOperator { get; } = B0001.TypeNameOperator.Instance;
        public static IUsingDirectiveBlockLabel UsingDirectiveBlockLabel { get; } = B0004.UsingDirectiveBlockLabel.Instance;
        public static IUsingDirectiveBlockSortOrder UsingDirectiveBlockSortOrder { get; } = B0004.UsingDirectiveBlockSortOrder.Instance;
        public static IUsingNameAliasDirectiveBlockLabel UsingNameAliasDirectiveBlockLabel { get; } = B0004.UsingNameAliasDirectiveBlockLabel.Instance;
    }
}
