namespace PhotographyPortfolio.Contracts.Request
{
    public class UploadRequest
    {
        public IFormFile? File { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
