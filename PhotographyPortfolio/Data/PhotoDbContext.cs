using Microsoft.EntityFrameworkCore;
using PhotographyPortfolio.Data.Models;

namespace PhotographyPortfolio.Data
{
    public class PhotoDbContext : DbContext
    {
        public PhotoDbContext(DbContextOptions<PhotoDbContext> options) : base(options) { }

        public DbSet<Photo> Photos { get; set; }
    }
}
