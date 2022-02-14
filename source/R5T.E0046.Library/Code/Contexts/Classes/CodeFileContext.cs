using System;


namespace R5T.E0046.Library
{
    public class CodeFileContext : ICodeFileContext
    {
        public string CodeFilePath { get; set; }

        public IProjectFileContext ProjectFileContext { get; set; }
    }
}
