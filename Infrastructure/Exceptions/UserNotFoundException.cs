using System;
namespace Infrastructure.Exceptions
{
    [Serializable]
    public class UserNotFoundException : Exception
    {

        public UserNotFoundException(string message)
            : base(message) { }

    }
}
