using System;


namespace R5T.E0046.Library
{
    public class CompilationUnitContext : ICompilationUnitContext
    {
        public ICodeFileContext CodeFileContext { get; set; }

        public IProjectFileContext ProjectFileContext => this.CodeFileContext.ProjectFileContext;
    }
}
