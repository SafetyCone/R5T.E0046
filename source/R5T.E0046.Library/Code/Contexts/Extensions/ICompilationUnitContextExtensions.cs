using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.E0046.Library
{
    public static class ICompilationUnitContextExtensions
    {
        /// <summary>
        /// Performs common actions before modifying code, including:
        /// * Adding the System namespace.
        /// </summary>
        public static Task<CompilationUnitSyntax> PerformBeforeModificationOperationActions(this ICompilationUnitContext _,
            CompilationUnitSyntax compilationUnit)
        {
            compilationUnit = compilationUnit.EnsureHasUsings(
                Instances.NamespaceName.System());

            return Task.FromResult(compilationUnit);
        }

        /// <summary>
        /// Performs common actions after modifying code, including:
        /// * Formatting using directives, including blocking, block ordering, and within-block ordering.
        /// </summary>
        public static Task<CompilationUnitSyntax> PerformAfterModificationOperationActions(this ICompilationUnitContext _,
            CompilationUnitSyntax compilationUnit)
        {
            return Task.FromResult(compilationUnit);
        }

        public static async Task<CompilationUnitSyntax> Modify(this ICompilationUnitContext compilationUnitContext,
            CompilationUnitSyntax compilationUnit,
            CompilationUnitContextAction compilationUnitContextAction)
        {
            compilationUnit = await compilationUnitContext.PerformBeforeModificationOperationActions(compilationUnit);

            compilationUnit = await compilationUnitContextAction(
                compilationUnitContext,
                compilationUnit);

            compilationUnit = await compilationUnitContext.PerformAfterModificationOperationActions(compilationUnit);

            return compilationUnit;
        }

        public static async Task<CompilationUnitSyntax> Modify(this ICompilationUnitContext compilationUnitContext,
            CompilationUnitSyntax compilationUnit,
            Func<CompilationUnitSyntax, Task<CompilationUnitSyntax>> compilationUnitAction)
        {
            compilationUnit = await compilationUnitContext.PerformBeforeModificationOperationActions(compilationUnit);

            compilationUnit = await compilationUnitAction(compilationUnit);

            compilationUnit = await compilationUnitContext.PerformAfterModificationOperationActions(compilationUnit);

            return compilationUnit;
        }
    }
}
