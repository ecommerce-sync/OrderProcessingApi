namespace OrderProcessingApi.Helpers.Exceptions;

public class InvalidUserException : Exception
{
    public string UserId { get; }
    public InvalidUserException(){}

    public InvalidUserException(string message)
        : base(message) { }

    public InvalidUserException(string message, Exception inner)
        : base(message, inner) { }

    public InvalidUserException(string message, string userId)
        : this(message)
    {
        UserId = userId;
    }
}