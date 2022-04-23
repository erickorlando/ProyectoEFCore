namespace ProyectoEFCore.Dto.Response;

public class BaseResponse
{
    public bool Success { get; set; }
    public string Error { get; set; }
}

public class BaseResponseGeneric<TResult> : BaseResponse
{
    public TResult Resultado { get; set; }
}