namespace FilesAPI.Responses
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
