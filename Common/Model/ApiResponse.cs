namespace Common.Model
{
    public class ApiResponse<T> where T : class
    {
        public ApiResponse(bool v, int statusCode, List<string> messages, T? data, List<T>? listData, Dictionary<string, object>? metadata)
        {
            Success = v;
            StatusCode = statusCode;
            Messages = messages;
            Data = data;
            Metadata = metadata;
            ListData = listData;
        }

        public bool Success { get; }
        public int StatusCode { get; }
        public List<string> Messages { get; }
        public T? Data { get; }
        public List<T>? ListData { get; }
        public Dictionary<string, object>? Metadata { get; }
    }
}
