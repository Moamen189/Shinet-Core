namespace API.Errors
{
    public class ApiException : ApiResponse
    {
        public string Deatails { get; set; }
        public ApiException(int statusCode, string message = null , string details = null) : base(statusCode, message)
        {
            Deatails= details;
        }
    }
}
