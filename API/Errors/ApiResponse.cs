namespace API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int statusCode , string message = null)  
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(StatusCode);
        
        
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A Bad REquest You Have Made",
                401 => "Authorized You Are Not",
                404 => "Response Found it is NOT",
                500 => "Server Error",
                _ => null
            };
        }
    }
}
