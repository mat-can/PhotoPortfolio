using PhotographyPortfolio.Data;
using PhotographyPortfolio.Data.Models;
using PhotographyPortfolio.Services.Interfaces;

namespace PhotographyPortfolio.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly PhotoDbContext _context;
        private readonly IHttpClientFactory _clientFactory;

        public PhotoService(PhotoDbContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
        }

        public IEnumerable<Photo> GetGallery()
        {
            var photos = _context.Photos.ToList();

            return photos;
        }

        public async Task UploadAsync(IFormFile file, string title, string description)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is required.");
            }

            var fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            var photo = new Photo
            {
                Title = title,
                Description = description,
                ImagePath = $"/images/{fileName}",
                UploadedAt = DateTime.Now,
            };

            _context.Photos.Add(photo);
            await _context.SaveChangesAsync();
        }

        public void DeletePhoto(int id)
        {
            var photo = _context.Photos.Find(id);
            if (photo != null)
            {
                _context.Photos.Remove(photo);
                _context.SaveChangesAsync();
            }
        }
    }
}
