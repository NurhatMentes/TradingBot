namespace Core.Results;

public class ErrorResult : Result
{
    public ErrorResult(string message, int statusCode = 400)
        : base(false, message, statusCode)
    {
    }
}