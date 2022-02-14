using System;

using Microsoft.CodeAnalysis;


namespace R5T.E0046.Library
{
    public class SyntaxTokenSyntaxAnnotation : TypedSyntaxAnnotation<SyntaxToken>
    {
        public SyntaxTokenSyntaxAnnotation(SyntaxAnnotation annotation)
            : base(annotation)
        {
        }
    }
}
