namespace PhotographyPortfolio.Helpers
{
    public static class PhotoHelper
    {
        // Unsures that the file is an image
        public static bool IsImageFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return false; // No file or empty file
            }

            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
            string fileExtension = Path.GetExtension(file.FileName).ToLower();

            return allowedExtensions.Contains(fileExtension);
        }
    }
}
