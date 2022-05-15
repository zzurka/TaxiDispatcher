namespace TaxiDispatcher.ConsoleClient.Models
{
    public class ResponseResult<T>
    {
        public bool Succeeded { get; set; }
        public T? Data { get; set; }
        public ResponseError? Error { get; set; }
    }
}
