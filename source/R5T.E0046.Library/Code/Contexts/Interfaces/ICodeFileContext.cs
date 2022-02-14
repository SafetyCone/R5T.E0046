using System;


namespace R5T.E0046.Library
{
    public interface ICodeFileContext : IHasProjectFileContext
    {
        public string CodeFilePath { get; }
    }
}
