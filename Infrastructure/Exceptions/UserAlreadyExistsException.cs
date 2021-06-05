using System;
namespace Infrastructure.Exceptions
{
    [Serializable]
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string message)
            : base(message) { }
    }
}
