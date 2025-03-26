namespace IntegracaoAcumuloPontos.API.Responses
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public Response(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public static Response<T> SuccessResponse(T data, string message = "Operação realizada com sucesso.")
        {
            return new Response<T>(true, message, data);
        }
        public static Response<T> ErrorResponse(T data, string message = "Operação falhou.")
        {
            return new Response<T>(false, message, data);
        }
    }
}
