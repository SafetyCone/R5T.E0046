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
        private IUsingDirectivesFormatter UsingDirectivesFormatter { get; }


        public O999_Scratch(
            ICompilationUnitContextProvider compilationUnitContextProvider,
            IStringlyTypedPathOperator stringlyTypedPathOperator,
            IUsingDirectivesFormatter usingDirectivesFormatter)
        {
            this.CompilationUnitContextProvider = compilationUnitContextProvider;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
            this.UsingDirectivesFormatter = usingDirectivesFormatter;
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
            var namespaceName = "TestProject";

            var projectDirectoryRelativeCodeFilePath = Instances.ProjectPathsOperator.GetProjectDirectoryRelativeFilePath(
                projectFilePath,
                codeFilePath,
                this.StringlyTypedPathOperator);

            await this.CompilationUnitContextProvider.InAcquiredCompilationUnitContext(
                projectFilePath,
                projectDirectoryRelativeCodeFilePath,
                async (compilationUnitContext, compilationUnit) =>
                {
                    var outputCompilationUnit = compilationUnit;

                    // Add usings idempotently.
                    outputCompilationUnit = outputCompilationUnit
                        .AddUsings(
                            "System",
                            "System.Threading.Tasks",
                            "R5T.Lombardy",
                            "R5T.T0020",
                            "R5T.S0029.Library",
                            "LocalData",
                            "Microsoft.Extensions.Hosting",
                            "R5T.D0088",
                            "R5T.D0090",
                            // Yes, repeats.
                            "System",
                            "System.Threading.Tasks",
                            "Microsoft.Extensions.Configuration",
                            "Microsoft.Extensions.DependencyInjection",
                            "R5T.Magyar",
                            "R5T.Ostrogothia.Rivet",
                            "R5T.A0003",
                            "R5T.D0048.Default",
                            "R5T.D0077.A002",
                            "R5T.D0078.A002",
                            "R5T.D0079.A002",
                            "R5T.D0081.I001",
                            "R5T.D0083.I001",
                            "R5T.D0088.I0002",
                            "R5T.D0101.I0001",
                            "R5T.D0101.I001",
                            "R5T.D0108.I0001",
                            "R5T.D0108.I001",
                            "R5T.D0109.I0001",
                            "R5T.D0109.I001",
                            "R5T.T0063",
                            "R5T.S0029.Library",
                            // Local namespace name.
                            "TestProject.Library")
                        .AddUsings(
                            ("IProvidedServiceActionAggregation", "R5T.D0088.I0002.IProvidedServiceActionAggregation"),
                            ("ServicesPlatformRequiredServiceActionAggregation", "R5T.A0003.RequiredServiceActionAggregation"),
                            ("IRequiredServiceActionAggregation", "R5T.D0088.I0002.IRequiredServiceActionAggregation"),
                            ("Documentation", "TestProject.Documentation"),
                            ("Instances", "TestProject.Code.Instances"),
                            ("Glossary", "TestProject.Glossary"))
                        ;

                    // Get all usings.
                    outputCompilationUnit = await this.UsingDirectivesFormatter.FormatUsingDirectives(
                        outputCompilationUnit,
                        namespaceName);

                    return outputCompilationUnit;
                },
                async (compilationUnitContext, compilationUnit) =>
                {
                    var outputCompilationUnit = compilationUnit;

                    outputCompilationUnit = outputCompilationUnit.AddUsings(
                        Instances.NamespaceName.System_Threading_Tasks());

                    outputCompilationUnit = await this.UsingDirectivesFormatter.FormatUsingDirectives(
                        outputCompilationUnit,
                        namespaceName);

                    return outputCompilationUnit;
                });
        }
    }
}
