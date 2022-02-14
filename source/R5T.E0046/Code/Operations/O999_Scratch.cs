using System;
using System.Threading.Tasks;

using R5T.Lombardy;

using R5T.T0020;

using R5T.E0046.Library;


namespace R5T.E0046
{
    [OperationMarker]
    public class O999_Scratch : IActionOperation
    {
        private ICompilationUnitContextProvider CompilationUnitContextProvider { get; }
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public O999_Scratch(
            ICompilationUnitContextProvider compilationUnitContextProvider,
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.CompilationUnitContextProvider = compilationUnitContextProvider;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public async Task Run()
        {
            await this.TryCompilationUnitContext();
        }

        private async Task TryCompilationUnitContext()
        {
            // Inputs.
            var projectFilePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\Test\source\TestProject\TestProject.csproj";
            var codeFilePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\Test\source\TestProject\Test.cs";

            // Run.
            var projectDirectoryRelativeCodeFilePath = Instances.ProjectPathsOperator.GetProjectDirectoryRelativeFilePath(
                projectFilePath,
                codeFilePath,
                this.StringlyTypedPathOperator);

            await this.CompilationUnitContextProvider.InAcquiredCompilationUnitContext(
                projectFilePath,
                projectDirectoryRelativeCodeFilePath,
                async (compilationUnitContext, compilationUnit) =>
                {
                    compilationUnit = compilationUnit.AddUsings(
                        Instances.NamespaceName.System_Threading_Tasks());

                    return compilationUnit;
                },
                async (compilationUnitContext, compilationUnit) =>
                {
                    compilationUnit = compilationUnit.AddUsings(
                        Instances.NamespaceName.System_Threading_Tasks());

                    return compilationUnit;
                });
        }
    }
}
