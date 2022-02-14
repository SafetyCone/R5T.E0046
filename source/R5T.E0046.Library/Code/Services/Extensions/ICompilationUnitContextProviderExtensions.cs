﻿using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.E0046.Library
{
    public static class ICompilationUnitContextProviderExtensions
    {
        public static async Task<CompilationUnitContext> GetCompilationUnitContext(this ICompilationUnitContextProvider compilationUnitContextProvider,
            string projectFilePath,
            string projectDirectoryRelativeCodeFilePath,
            bool verifyCodeFileExists = false)
        {
            var codeFileContext = await compilationUnitContextProvider.GetCodeFileContext(
                projectFilePath,
                projectDirectoryRelativeCodeFilePath,
                verifyCodeFileExists);

            var output = new CompilationUnitContext
            {
                CodeFileContext = codeFileContext,
            };

            return output;
        }

        /// <summary>
        /// Allows performing an action in a compilation unit context, supplying only a project file path and a project directory-relative code file path.
        /// If the code file path does not exist, the initial compilation unit context action is run, and the resulting compilation unit provided to the compilation unit context action.
        /// </summary>
        public static async Task InAcquiredCompilationUnitContext(this ICompilationUnitContextProvider compilationUnitContextProvider,
            string projectFilePath,
            string projectDirectoryRelativeCodeFilePath,
            CompilationUnitContextAction compilationUnitContextAction,
            InitialCompilationUnitContextAction initialCompilationUnitContextAction)
        {
            var compilationUnitContext = await compilationUnitContextProvider.GetCompilationUnitContext(
                projectFilePath,
                projectDirectoryRelativeCodeFilePath,
                // Allow creation of new code file as part of compilation unit acquisition.
                verifyCodeFileExists: false);

            await Instances.CompilationUnitOperator.ModifyAcquired(
                compilationUnitContext.CodeFileContext.CodeFilePath,
                async inputCompilationUnit =>
                {
                    var compilationUnit = await compilationUnitContext.Modify(
                        inputCompilationUnit,
                        async xCompilationUnit =>
                        {
                            xCompilationUnit = await compilationUnitContextAction(compilationUnitContext, xCompilationUnit);
                            
                            return xCompilationUnit;
                        });

                    return compilationUnit;
                },
                async inputCompilationUnit =>
                {
                    var compilationUnit = await compilationUnitContext.Modify(
                        inputCompilationUnit,
                        async xCompilationUnit =>
                        {
                            xCompilationUnit = await initialCompilationUnitContextAction(compilationUnitContext, xCompilationUnit);

                            return xCompilationUnit;
                        });

                    return compilationUnit;
                });
        }
    }
}
