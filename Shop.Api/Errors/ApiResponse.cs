namespace Shop.Api.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GenerateMessageForStatusCode(statusCode);
        }

        private string GenerateMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorised, you are not",
                404 => "Resource found, it was not",
                500 => "Errors are the path to the dark side.",
                _ => null
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

    }
}