namespace API.ErrorHandler
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string? GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad request",
                401 => "Not Autorized",
                404 => "the server cannot find the requested resource",
                500 => "the server encountered an unexpected condition that prevented it from fulfilling the request",
                _=> null
            };
        }

        public int StatusCode { get; set;}
        public string Message { get; set; }

    }
}