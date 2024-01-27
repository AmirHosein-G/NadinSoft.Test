using System.Net;

namespace Domain.Dto.Shared;

public abstract class ApiResponse
{
    public ApiResponse(){}
    public ApiResponse(bool success)
    {
        Success = success;
        if (!success)
        {
            Message = "Server Error";
            Status = HttpStatusCode.InternalServerError;
        }
        else
        {
            Status = HttpStatusCode.OK;
            Message = "OK";
        }
    }
    public ApiResponse(bool success, string message)
    {
        Success = success;
        Message = message;
    }
    public ApiResponse(HttpStatusCode status, string message)
    {
        Status = status;
        Success = (int)status >= 200 && (int)status < 300;

        if (!string.IsNullOrEmpty(message))
        {
            Message = message;
        }
        else
        {
            if (!Success) Message = "Server Error";
            else { Message = "Ok"; }
        }
    }
    public bool Success { get; set; } = true;
    public HttpStatusCode Status { get; set; }
    public string Message { get; set; }
    public abstract dynamic Data { get; set; }
}
