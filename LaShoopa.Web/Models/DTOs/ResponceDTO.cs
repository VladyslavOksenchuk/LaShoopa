namespace LaShoopa.Web.Models.DTOs
{
	public class ResponceDTO
	{
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string Error { get; set; }
        public List<string> Message { get; set; }
    }
}
