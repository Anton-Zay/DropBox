using Microsoft.EntityFrameworkCore;

namespace DropBoxApp.Models
{
    public class FileContext : DbContext
    {
        public FileContext(DbContextOptions<FileContext> options) : base(options)
        {
        }
        public DbSet<File> Files { get; set; } = null!; // что это?
    }
}
