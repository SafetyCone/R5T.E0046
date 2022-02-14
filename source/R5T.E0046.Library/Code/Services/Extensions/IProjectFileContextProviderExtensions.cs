using System;
using System.Threading.Tasks;


namespace R5T.E0046.Library
{
    public static class IProjectFileContextProviderExtensions
    {
        public static async Task<IProjectFileContext> GetProjectFileContext(this IProjectFileContextProvider projectFileContextProvider,
            string projectFilePath,
            bool verifyProjectFileExists = false)
        {
            if (verifyProjectFileExists)
            {
                Instances.FileSystemOperator.VerifyFileExists(projectFilePath);
            }

            var solutionFilePaths = await Instances.SolutionOperator.GetSolutionFilePathsContainingProject(
               projectFilePath,
               projectFileContextProvider.StringlyTypedPathOperator,
               projectFileContextProvider.VisualStudioSolutionFileOperator);

            var output = new ProjectFileContext
            {
                ProjectFilePath = projectFilePath,
                SolutionFilePaths = solutionFilePaths,
                VisualStudioProjectFileOperator = projectFileContextProvider.VisualStudioProjectFileOperator,
                VisualStudioProjectFileReferencesProvider = projectFileContextProvider.VisualStudioProjectFileReferencesProvider,
                VisualStudioSolutionFileOperator = projectFileContextProvider.VisualStudioSolutionFileOperator
            };

            return output;
        }
    }
}
