namespace Talabat.API.Errors
{
    public class ApiValdetionResponse : ApiResponse
    {
        public IEnumerable<string>? Errors { get; set; }
        public ApiValdetionResponse() : base(400)
        {
        }

    }
}
