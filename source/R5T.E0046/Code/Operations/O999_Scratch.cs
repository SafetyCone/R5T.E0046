using System;
using System.Linq;
using System.Threading.Tasks;

using R5T.Lombardy;

using R5T.D0116;
using R5T.D0117;
using R5T.T0020;
using R5T.X0003;


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
            await this.AddExtensionMethodBaseInstancesToProject();
            //await this.CreateInstancesCodeFileAndClass();
            //await this.TryCompilationUnitContext();
        }

#pragma warning disable IDE0051 // Remove unused private members

        private async Task AddExtensionMethodBaseInstancesToProject()
        {
            // Inputs.
            var projectFilePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\Test\source\TestProject\TestProject.csproj";

            var namespaceName = Instances.ProjectPathsOperator.GetDefaultProjectNamespaceName(projectFilePath);

            var extensionMethodBaseInterfaceNamespacedTypeNames = new[]
            {
                "R5T.L0012.T001.IMSBuild",
                "R5T.B0000.IObjectOperator",
                "R5T.T0035.X002.IMicrosoftExtensionsNamespaceName",
            };

            // Run.
            await this.CompilationUnitContextProvider.AddExtensionMethodBasesToProjectInstances(
                projectFilePath,
                namespaceName,
                extensionMethodBaseInterfaceNamespacedTypeNames,
                this.UsingDirectivesFormatter);
        }

        private async Task CreateInstancesCodeFileAndClass()
        {
            // Inputs.
            var projectFilePath = @"C:\Code\DEV\Git\GitHub\SafetyCone\Test\source\TestProject\TestProject.csproj";

            var extensionMethodBaseInterfaceNamespacedTypeNames = new[]
            {
                "R5T.E0038.Lib.IServiceDefinitionOperator",
                "R5T.T0060.IPredicateProvider",
            };

            // Run.
            var instancesProjectDirectoryRelativeCodeFilePath = Instances.ProjectPathsOperator.GetInstancesCodeFileRelativePath();

            var namespaceName = Instances.ProjectPathsOperator.GetDefaultProjectNamespaceName(projectFilePath);

            await this.CompilationUnitContextProvider.InAcquiredCompilationUnitContext(
                projectFilePath,
                instancesProjectDirectoryRelativeCodeFilePath,
                async (compilationUnitContext, compilationUnit) =>
                {
                    var outputCompilationUnit = await compilationUnitContext.InAcquiredNamespaceContext(
                        compilationUnit,
                        namespaceName,
                        async (namespaceCompilationUnit, namespaceContext) =>
                        {
                            //var outputNamespaceCompilationUnit = namespaceCompilationUnit;

                            var outputNamespaceCompilationUnit = await namespaceContext.InAcquiredClassContext(
                                namespaceCompilationUnit,
                                Instances.ClassName.Instances(),
                                async (classCompilationUnit, classContext) =>
                                {
                                    var outputClassCompilationUnit = classCompilationUnit;

                                    // Add usings.
                                    var requiredNamespaces = extensionMethodBaseInterfaceNamespacedTypeNames
                                        .Select(x => Instances.NamespacedTypeName.GetNamespaceName(x))
                                        ;

                                    // Add and format all usings.
                                    outputClassCompilationUnit = await this.UsingDirectivesFormatter.AddAndFormatNamespaceNames(
                                        outputClassCompilationUnit,
                                        requiredNamespaces,
                                        namespaceName);

                                    // Now add instances.
                                    var instanceTuples = Instances.Operation.GetInstanceTuples(
                                        extensionMethodBaseInterfaceNamespacedTypeNames,
                                        namespaceName);

                                    var instanceProperties = Instances.PropertyGenerator.GetInstancesInstanceProperties(
                                        instanceTuples)
                                        // Indent.
                                        .Select(xProperty => xProperty.IndentBlock_Old(
                                            Instances.Indentation.Property()))
                                        .Now();

                                    outputClassCompilationUnit = classContext.ClassAnnotation.ModifySynchronous(outputClassCompilationUnit,
                                        @class =>
                                        {
                                            // Determine new properties.
                                            var existingProperties = @class.GetProperties();

                                            var newProperties = instanceProperties.Except(existingProperties, InstancePropertyEqualityComparer.Instance);

                                            var outputClass = @class.AddProperties(newProperties);

                                            // Order properties by type name.
                                            outputClass = outputClass.OrderPropertiesBy(xProperty =>
                                            {
                                                var typeName = xProperty.GetTypeExpressionText();
                                                return typeName;
                                            });

                                            // Set the open and close brace trivia. This must be done after ordering since trivia is always leading trivia, so the first property needs to have been already decided.
                                            outputClass = outputClass.EnsureBraceSpacing();

                                            return outputClass;
                                        });

                                    return outputClassCompilationUnit;
                                },
                                () =>
                                {
                                    var outputInstancesClass = Instances.ClassGenerator.GetPublicStaticClass2(Instances.ClassName.Instances())
                                        .IndentBlock(Instances.Indentation.Class())
                                        ;

                                    return outputInstancesClass;
                                });

                            return outputNamespaceCompilationUnit;
                        });

                    return outputCompilationUnit;
                },
                async (compilationUnitContext, compilationUnit) =>
                {
                    var outputCompilationUnit = compilationUnit;

                    // Add usings idempotently.
                    outputCompilationUnit = outputCompilationUnit.AddLotsOfUsings();

                    // Format all usings.
                    outputCompilationUnit = await this.UsingDirectivesFormatter.FormatUsingDirectives(
                        outputCompilationUnit,
                        namespaceName);

                    return outputCompilationUnit;
                });
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
                    outputCompilationUnit = outputCompilationUnit.AddLotsOfUsings();

                    // Now format usings.
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

#pragma warning restore IDE0051 // Remove unused private members
        }
    }
}
