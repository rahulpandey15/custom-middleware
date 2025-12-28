namespace middleware
{
    public class ApiKeyModelDto
    {
        public string ProductApiKey { get; set; } = default!;

        public string CustomerApiKey { get; set; }= default!;
    }
}
