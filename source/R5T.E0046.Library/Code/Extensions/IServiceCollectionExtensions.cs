using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Lombardy;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;
using R5T.T0063;


namespace R5T.E0046.Library
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="AlphabeticalUsingNamespaceDirectiveComparerProvider"/> implementation of <see cref="IUsingNamespaceDirectiveComparerProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddAlphabeticalUsingNamespaceDirectiveComparerProvider(this IServiceCollection services)
        {
            services.AddSingleton<IUsingNamespaceDirectiveComparerProvider, AlphabeticalUsingNamespaceDirectiveComparerProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="AlphabeticalUsingNameAliasDirectiveComparerProvider"/> implementation of <see cref="IUsingNameAliasDirectiveComparerProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddAlphabeticalUsingNameAliasDirectiveComparerProvider(this IServiceCollection services)
        {
            services.AddSingleton<IUsingNameAliasDirectiveComparerProvider, AlphabeticalUsingNameAliasDirectiveComparerProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="RivetUsingNamespaceDirectiveBlockSortOrderProvider"/> implementation of <see cref="IUsingNamespaceDirectiveBlockSortOrderProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddRivetUsingNamespaceDirectiveBlockSortOrderProvider(this IServiceCollection services)
        {
            services.AddSingleton<IUsingNamespaceDirectiveBlockSortOrderProvider, RivetUsingNamespaceDirectiveBlockSortOrderProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="RivetUsingNameAliasDirectiveBlockSortOrderProvider"/> implementation of <see cref="IUsingNameAliasDirectiveBlockSortOrderProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddRivetUsingNameAliasDirectiveBlockSortOrderProvider(this IServiceCollection services)
        {
            services.AddSingleton<IUsingNameAliasDirectiveBlockSortOrderProvider, RivetUsingNameAliasDirectiveBlockSortOrderProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="UsingNameAliasDirectiveBlockLabelProvider"/> implementation of <see cref="IUsingNameAliasDirectiveBlockLabelProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddUsingNameAliasDirectiveBlockLabelProvider(this IServiceCollection services)
        {
            services.AddSingleton<IUsingNameAliasDirectiveBlockLabelProvider, UsingNameAliasDirectiveBlockLabelProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="UsingNamespaceDirectiveBlockLabelProvider"/> implementation of <see cref="IUsingNamespaceDirectiveBlockLabelProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddUsingNamespaceDirectiveBlockLabelProvider(this IServiceCollection services)
        {
            services.AddSingleton<IUsingNamespaceDirectiveBlockLabelProvider, UsingNamespaceDirectiveBlockLabelProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="UsingDirectivesFormatter"/> implementation of <see cref="IUsingDirectivesFormatter"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddUsingDirectivesFormatter(this IServiceCollection services,
            IServiceAction<IUsingNameAliasDirectiveBlockLabelProvider> usingNameAliasDirectiveBlockLabelProviderAction,
            IServiceAction<IUsingNameAliasDirectiveBlockSortOrderProvider> usingNameAliasDirectiveBlockSortOrderProviderAction,
            IServiceAction<IUsingNameAliasDirectiveComparerProvider> usingNameAliasDirectiveComparerProviderAction,
            IServiceAction<IUsingNamespaceDirectiveBlockLabelProvider> usingNamespaceDirectiveBlockLabelProviderAction,
            IServiceAction<IUsingNamespaceDirectiveBlockSortOrderProvider> usingNamespaceDirectiveBlockSortOrderProviderAction,
            IServiceAction<IUsingNamespaceDirectiveComparerProvider> usingNamespaceDirectiveComparerProviderAction)
        {
            services
                .Run(usingNameAliasDirectiveBlockLabelProviderAction)
                .Run(usingNameAliasDirectiveBlockSortOrderProviderAction)
                .Run(usingNameAliasDirectiveComparerProviderAction)
                .Run(usingNamespaceDirectiveBlockLabelProviderAction)
                .Run(usingNamespaceDirectiveBlockSortOrderProviderAction)
                .Run(usingNamespaceDirectiveComparerProviderAction)
                .AddSingleton<IUsingDirectivesFormatter, UsingDirectivesFormatter>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="CompilationUnitContextProvider"/> implementation of <see cref="ICompilationUnitContextProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddCompilationUnitContextProvider(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<IVisualStudioProjectFileOperator> visualStudioProjectFileOperatorAction,
            IServiceAction<IVisualStudioProjectFileReferencesProvider> visualStudioProjectFileReferencesProviderAction,
            IServiceAction<IVisualStudioSolutionFileOperator> visualStudioSolutionFileOperatorAction)
        {
            services
                .Run(stringlyTypedPathOperatorAction)
                .Run(visualStudioProjectFileOperatorAction)
                .Run(visualStudioProjectFileReferencesProviderAction)
                .Run(visualStudioSolutionFileOperatorAction)
                .AddSingleton<ICompilationUnitContextProvider, CompilationUnitContextProvider>();

            return services;
        }
    }
}
