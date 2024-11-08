﻿namespace Core.Results;

public class DataResult<T> : Result, IDataResult<T>
{
    public T Data { get; }

    public DataResult(T data, bool success, string message = null, int statusCode = 200)
        : base(success, message, statusCode)
    {
        Data = data;
    }
}