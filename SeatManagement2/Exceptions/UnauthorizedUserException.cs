namespace SeatManagement2.Exceptions
{
    public class UnauthorizedUserException : Exception
    {
        public UnauthorizedUserException()
        {

        }
        public UnauthorizedUserException(string message) : base(message)
        {

        }
    }
}
