namespace School_Management_System.Service.Responses
{
    public class ServiceResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public ServiceResponse(bool isSuccess, string? message, T? data = default)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }
    }
}
