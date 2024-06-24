namespace PhotographyPortfolio.Data.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public DateTime UploadedAt { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}