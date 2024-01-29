namespace SocialMedia.API.response
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            this.Data = data;
        }
        public string? Message { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }

    }
}
