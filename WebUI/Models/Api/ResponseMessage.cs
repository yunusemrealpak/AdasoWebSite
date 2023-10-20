namespace WebUI.Models.Api
{
    public class ResponseMessage<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int DataCount { get; set; } = 0;
        public T Data { get; set; }
    }
}
