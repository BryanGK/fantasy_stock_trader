using System;
namespace Infrastructure.Exceptions
{
    [Serializable]
    public class StockNotFoundException : Exception
    {
        public string Stock { get; }

        public StockNotFoundException(string message)
            :base(message) { }
    }
}
