using System;

using R5T.Lombardy;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;
using R5T.T0062;
using R5T.T0063;


namespace R5T.E0046.Library
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="UsingNameAliasDirectiveBlockLabelProvider"/> implementation of <see cref="IUsingNameAliasDirectiveBlockLabelProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IUsingNameAliasDirectiveBlockLabelProvider> AddUsingNameAliasDirectiveBlockLabelProviderAction(this IServiceAction _)
        {
            var serviceAction = _.New<IUsingNameAliasDirectiveBlockLabelProvider>(services => services.AddUsingNameAliasDirectiveBlockLabelProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="UsingDirectivesFormatter"/> implementation of <see cref="IUsingDirectivesFormatter"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IUsingDirectivesFormatter> AddUsingDirectivesFormatterAction(this IServiceAction _,
            IServiceAction<IUsingNameAliasDirectiveBlockLabelProvider> usingNameAliasDirectiveBlockLabelProviderAction,
            IServiceAction<IUsingNameAliasDirectiveBlockSortOrderProvider> usingNameAliasDirectiveBlockSortOrderProviderAction,
            IServiceAction<IUsingNameAliasDirectiveComparerProvider> usingNameAliasDirectiveComparerProviderAction,
            IServiceAction<IUsingNamespaceDirectiveBlockLabelProvider> usingNamespaceDirectiveBlockLabelProviderAction,
            IServiceAction<IUsingNamespaceDirectiveBlockSortOrderProvider> usingNamespaceDirectiveBlockSortOrderProviderAction,
            IServiceAction<IUsingNamespaceDirectiveComparerProvider> usingNamespaceDirectiveComparerProviderAction)
        {
            var serviceAction = _.New<IUsingDirectivesFormatter>(services => services.AddUsingDirectivesFormatter(
                usingNameAliasDirectiveBlockLabelProviderAction,
                usingNameAliasDirectiveBlockSortOrderProviderAction,
                usingNameAliasDirectiveComparerProviderAction,
                usingNamespaceDirectiveBlockLabelProviderAction,
                usingNamespaceDirectiveBlockSortOrderProviderAction,
                usingNamespaceDirectiveComparerProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="CompilationUnitContextProvider"/> implementation of <see cref="ICompilationUnitContextProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ICompilationUnitContextProvider> AddCompilationUnitContextProviderAction(this IServiceAction _,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<IVisualStudioProjectFileOperator> visualStudioProjectFileOperatorAction,
            IServiceAction<IVisualStudioProjectFileReferencesProvider> visualStudioProjectFileReferencesProviderAction,
            IServiceAction<IVisualStudioSolutionFileOperator> visualStudioSolutionFileOperatorAction)
        {
            var serviceAction = _.New<ICompilationUnitContextProvider>(services => services.AddCompilationUnitContextProvider(
                stringlyTypedPathOperatorAction,
                visualStudioProjectFileOperatorAction,
                visualStudioProjectFileReferencesProviderAction,
                visualStudioSolutionFileOperatorAction));

            return serviceAction;
        }
    }
}
