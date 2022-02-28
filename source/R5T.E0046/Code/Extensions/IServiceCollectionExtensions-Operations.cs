using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Lombardy;

using R5T.T0063;

using R5T.E0046.Library;


namespace R5T.E0046
{
    public static partial class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="O999_Scratch"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO999_Scratch(this IServiceCollection services,
            IServiceAction<ICompilationUnitContextProvider> compilationUnitContextProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<IUsingDirectivesFormatter> usingDirectivesFormatterAction)
        {
            services
                .Run(compilationUnitContextProviderAction)
                .Run(stringlyTypedPathOperatorAction)
                .Run(usingDirectivesFormatterAction)
                .AddSingleton<O999_Scratch>();

            return services;
        }
    }
}