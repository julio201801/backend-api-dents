using Microsoft.AspNetCore.Http;
using System.Data;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NGsystem.Dents.Core;

public class Result<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }
    public CustomErrorCode? ErrorCode { get; }
    public IEnumerable<CustomErrorCode>? Errordetails { get; }
    private Result(T value) { IsSuccess = true; Value = value; }
    private Result(CustomErrorCode errorCode) { IsSuccess = false; ErrorCode = errorCode; }
    private Result(IEnumerable<CustomErrorCode> errors)
    {
        IsSuccess = false;
        Value = default;
        Errordetails = errors ?? new List<CustomErrorCode>(); // Evita `null`
    }
    public static Result<T> Success(T value) => new(value);
    public static Result<T> Failure(CustomErrorCode  ErrorCode) => new(ErrorCode);
    public static Result<T> Failure(CustomErrorCode errorCode,IEnumerable<CustomErrorCode> errors) => new(errors);
    public IResult MatchApiException(Func<T, IResult> onSuccess, Func<ApiException, IResult> onFailure)
    {
        var errVal = new ApiException(   Errordetails?.FirstOrDefault()?.Message ?? "Error desconocido",
                                         Errordetails?.FirstOrDefault()?.Category ?? "Sistema",
                                         (int)HttpStatusCode.BadRequest,
                                         Errordetails);
        var errDomain = new ApiException(ErrorCode?.Message ?? "Error desconocido",
                                         ErrorCode ? .Category ?? "Sistema",
                                         (int)HttpStatusCode.BadRequest,
                                         null);
        return IsSuccess
            ? onSuccess(Value!)
            : onFailure(errVal==null? errDomain: errVal);

    }
}
