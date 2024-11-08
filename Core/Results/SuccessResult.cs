namespace Core.Results;

public class SuccessResult : Result
{
    public SuccessResult(string message = null)
        : base(true, message, 200)
    {
    }
}