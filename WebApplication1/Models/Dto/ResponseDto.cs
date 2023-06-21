namespace WebApplication1.Models.Dto
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}
