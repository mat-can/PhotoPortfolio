
using PhotographyPortfolio.Data.Models;

namespace PhotographyPortfolio.Services.Interfaces
{
    public interface IPhotoService
    {
        void DeletePhoto(int id);
        IEnumerable<Photo> GetGallery();
        Task UploadAsync(IFormFile file, string title, string description);
    }
}
