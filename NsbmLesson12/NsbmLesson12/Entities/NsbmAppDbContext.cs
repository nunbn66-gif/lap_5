using Microsoft.EntityFrameworkCore;
using NsbmLesson12.Models;
namespace NsbmLesson12.Data
{
    public class NsbmAppDbContext : DbContext
    {
        public DbSet<NsbmLesson12.Models.NsbmProduct> NsbmProduct { get; set; } = default!;
        public NsbmAppDbContext(DbContextOptions<NsbmAppDbContext> options) : base(options) { }
        public DbSet<NsbmCategory> NsbmCategories { get; set; }
    }
}
