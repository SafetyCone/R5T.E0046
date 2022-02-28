using System;

using R5T.Lombardy;

using R5T.T0062;
using R5T.T0063;

using R5T.E0046.Library;


namespace R5T.E0046
{
    public static partial class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="O999_Scratch"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<O999_Scratch> AddO999_ScratchAction(this IServiceAction _,
            IServiceAction<ICompilationUnitContextProvider> compilationUnitContextProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<IUsingDirectivesFormatter> usingDirectivesFormatterAction)
        {
            var serviceAction = _.New<O999_Scratch>(services => services.AddO999_Scratch(
                compilationUnitContextProviderAction,
                stringlyTypedPathOperatorAction,
                usingDirectivesFormatterAction));

            return serviceAction;
        }
    }
}