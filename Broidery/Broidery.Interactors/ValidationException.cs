using System;

namespace Broidery.Interactors
{
    public partial class AuthenticationInteractor
    {
        public class ValidationException : Exception
        {
            public ValidationException(string message) : base(message) { }
        }
    }
}