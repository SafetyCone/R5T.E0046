using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Magyar;
using R5T.Ostrogothia.Rivet;

using R5T.A0003;
using R5T.D0048.Default;
using R5T.D0077.A002;
using R5T.D0078.A002;
using R5T.D0079.A002;
using R5T.D0081.I001;
using R5T.D0083.I001;
using R5T.D0088.I0002;
using R5T.D0101.I0001;
using R5T.D0101.I001;
using R5T.T0063;

using R5T.E0046.Library;

using IProvidedServiceActionAggregation = R5T.D0088.I0002.IProvidedServiceActionAggregation;
using IRequiredServiceActionAggregation = R5T.D0088.I0002.IRequiredServiceActionAggregation;
using ServicesPlatformRequiredServiceActionAggregation = R5T.A0003.RequiredServiceActionAggregation;


namespace R5T.E0046
{
    public class HostStartup : HostStartupBase
    {
        public override Task ConfigureConfiguration(IConfigurationBuilder configurationBuilder)
        {
            // Do nothing.
        
            return Task.CompletedTask;
        }

        protected override Task ConfigureServices(IServiceCollection services, IProvidedServiceActionAggregation providedServicesAggregation)
        {
            // Inputs.
            var executionSynchronicityProviderAction = Instances.ServiceAction.AddConstructorBasedExecutionSynchronicityProviderAction(Synchronicity.Synchronous);

            var organizationProviderAction = Instances.ServiceAction.AddOrganizationProviderAction(); // Rivet organization.

            var rootOutputDirectoryPathProviderAction = Instances.ServiceAction.AddConstructorBasedRootOutputDirectoryPathProviderAction(@"C:\Temp\Output");

            // Services platform.
            var servicesPlatformRequiredServiceActionAggregation = new ServicesPlatformRequiredServiceActionAggregation
            {
                ConfigurationAction = providedServicesAggregation.ConfigurationAction,
                ExecutionSynchronicityProviderAction = executionSynchronicityProviderAction,
                LoggerAction = providedServicesAggregation.LoggerAction,
                LoggerFactoryAction = providedServicesAggregation.LoggerFactoryAction,
                MachineMessageOutputSinkProviderActions = EnumerableHelper.Empty<IServiceAction<D0099.D002.IMachineMessageOutputSinkProvider>>(),
                MachineMessageTypeJsonSerializationHandlerActions = EnumerableHelper.Empty<IServiceAction<D0098.IMachineMessageTypeJsonSerializationHandler>>(),
                OrganizationProviderAction = organizationProviderAction,
                RootOutputDirectoryPathProviderAction = rootOutputDirectoryPathProviderAction,
            };

            var servicesPlatform = Instances.ServiceAction.AddProvidedServiceActionAggregation(
                servicesPlatformRequiredServiceActionAggregation);

            // Services.

            // Project repository.
            var projectRepositoryFilePathsProviderAction = Instances.ServiceAction.AddHardCodedProjectRepositoryFilePathsProviderAction();

            var fileBasedProjectRepositoryAction = Instances.ServiceAction.AddFileBasedProjectRepositoryAction(
                projectRepositoryFilePathsProviderAction);

            var projectRepositoryAction = Instances.ServiceAction.ForwardFileBasedProjectRepositoryToProjectRepositoryAction(
                fileBasedProjectRepositoryAction);

            // Visual studio.
            var dotnetOperatorActions = Instances.ServiceAction.AddDotnetOperatorActions(
                servicesPlatform.CommandLineOperatorAction,
                servicesPlatform.SecretsDirectoryFilePathProviderAction);
            var visualStudioProjectFileOperatorActions = Instances.ServiceAction.AddVisualStudioProjectFileOperatorActions(
                dotnetOperatorActions.DotnetOperatorAction,
                servicesPlatform.FileNameOperatorAction,
                servicesPlatform.StringlyTypedPathOperatorAction);
            var visualStudioProjectFileReferencesProviderAction = Instances.ServiceAction.AddVisualStudioProjectFileReferencesProviderAction(
                servicesPlatform.StringlyTypedPathOperatorAction);
            var visualStudioSolutionFileOperatorActions = Instances.ServiceAction.AddVisualStudioSolutionFileOperatorActions(
                dotnetOperatorActions.DotnetOperatorAction,
                servicesPlatform.FileNameOperatorAction,
                servicesPlatform.StringlyTypedPathOperatorAction);

            // Level 01.
            var compilationUnitContextProviderAction = Instances.ServiceAction.AddCompilationUnitContextProviderAction(
                servicesPlatform.StringlyTypedPathOperatorAction,
                visualStudioProjectFileOperatorActions.VisualStudioProjectFileOperatorAction,
                visualStudioProjectFileReferencesProviderAction,
                visualStudioSolutionFileOperatorActions.VisualStudioSolutionFileOperatorAction);
            var usingNameAliasDirectiveBlockLabelProviderAction = Instances.ServiceAction.AddUsingNameAliasDirectiveBlockLabelProviderAction();
            var usingNameAliasDirectiveBlockSortOrderProviderAction = Instances.ServiceAction.AddRivetUsingNameAliasDirectiveBlockSortOrderProviderAction();
            var usingNameAliasDirectiveComparerProviderAction = Instances.ServiceAction.AddAlphabeticalUsingNameAliasDirectiveComparerProviderAction();
            var usingNamespaceDirectiveBlockLabelProviderAction = Instances.ServiceAction.AddUsingNamespaceDirectiveBlockLabelProviderAction();
            var usingNamespaceDirectiveBlockSortOrderProviderAction = Instances.ServiceAction.AddRivetUsingNamespaceDirectiveBlockSortOrderProviderAction();
            var usingNamespaceDirectiveComparerProviderAction = Instances.ServiceAction.AddAlphabeticalUsingNamespaceDirectiveComparerProviderAction();

            // Level 02.
            var usingDirectivesFormatterAction = Instances.ServiceAction.AddUsingDirectivesFormatterAction(
                usingNameAliasDirectiveBlockLabelProviderAction,
                usingNameAliasDirectiveBlockSortOrderProviderAction,
                usingNameAliasDirectiveComparerProviderAction,
                usingNamespaceDirectiveBlockLabelProviderAction,
                usingNamespaceDirectiveBlockSortOrderProviderAction,
                usingNamespaceDirectiveComparerProviderAction);

            // Operations.

            // Level 01.
            var o999_ScratchAction = Instances.ServiceAction.AddO999_ScratchAction(
                compilationUnitContextProviderAction,
                servicesPlatform.StringlyTypedPathOperatorAction,
                usingDirectivesFormatterAction);

            // Run.
            services.MarkAsServiceCollectonConfigurationStatement()
                .Run(servicesPlatform.ConfigurationAuditSerializerAction)
                .Run(servicesPlatform.ServiceCollectionAuditSerializerAction)
                // Services.
                // Operations.
                .Run(o999_ScratchAction)
                ;

            return Task.CompletedTask;
        }

        protected override Task FillRequiredServiceActions(IRequiredServiceActionAggregation requiredServiceActions)
        {
        
            // Do nothing since none are required.
        
            return Task.CompletedTask;
        }
    }
}