namespace Parking.Infrastructure.Exceptions
{
    public class BrockerException : Exception
    {
        public BrockerException() : base() { }

        public BrockerException(string message) : base(message) { }
    }
}
