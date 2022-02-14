using System;
using System.Threading.Tasks;


namespace R5T.E0046.Library
{
    public static class ICodeFileContextProviderExtensions
    {
        public static async Task<ICodeFileContext> GetCodeFileContext(this ICodeFileContextProvider codeFileContextProvider,
            string projectFilePath,
            string projectDirectoryRelativeCodeFilePath,
            bool verifyCodeFileExists = false)
        {
            var projectFileContext = await codeFileContextProvider.GetProjectFileContext(
                projectFilePath,
                // Always verify that the project file exists since its path was provided.
                verifyProjectFileExists: true);

            var codeFilePath = Instances.ProjectPathsOperator.GetFilePathFromProjectDirectoryRelativePath(
               projectFilePath,
               projectDirectoryRelativeCodeFilePath);

            if (verifyCodeFileExists)
            {
                Instances.FileSystemOperator.VerifyFileExists(codeFilePath);
            }

            var output = new CodeFileContext
            {
                CodeFilePath = codeFilePath,
                ProjectFileContext = projectFileContext,
            };

            return output;
        }
    }
}
