namespace Domain.Shared;

public class Result<T> : Result
{
    private Result(bool isSuccess, Error error, T value) : base(isSuccess, error)
    {
        if (isSuccess && error!= Shared.Error.None)
        {
            throw new InvalidOperationException();
        }
        if(!isSuccess && error == Shared.Error.None)
        {
            throw new InvalidOperationException();
        }
        
        Value = value;
    }

    public T Value { get; }

    public static Result<T> Success(T value) => new(true, Error.None, value);

    public new static Result<T> Failure(Error error) => new(false, error, default!);
}