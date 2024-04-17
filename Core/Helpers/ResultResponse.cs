namespace Web_API_Webshop.Core.Helpers
{
    public class ResultResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        public ResultResponse()
        {
            Success = true;
        }

        public ResultResponse(T data)
        {
            Success = true;
            Data = data;
        }

        public ResultResponse(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
        }
    }
}
