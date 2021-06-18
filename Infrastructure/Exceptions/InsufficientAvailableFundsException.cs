using System;
namespace Infrastructure.Exceptions
{
    [Serializable]
    public class InsufficientAvailableFundsException : Exception
    { 
        public InsufficientAvailableFundsException(string message)
            : base(message) { }
    }
}
