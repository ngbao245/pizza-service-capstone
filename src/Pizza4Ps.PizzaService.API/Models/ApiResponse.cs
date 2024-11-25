namespace Pizza4Ps.PizzaService.API.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Result { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }

        // Constructor cho thành công
        public ApiResponse()
        {
            Success = true;
        }
    }
}
