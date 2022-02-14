using System;

using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.E0046.Library
{
    public delegate Task<CompilationUnitSyntax> InitialCompilationUnitContextAction(
        ICompilationUnitContext compilationUnitContext,
        CompilationUnitSyntax emptyCompilationUnit);

    public delegate Task<CompilationUnitSyntax> CompilationUnitContextAction(
        ICompilationUnitContext compilationUnitContext,
        CompilationUnitSyntax compilationUnit);
}
