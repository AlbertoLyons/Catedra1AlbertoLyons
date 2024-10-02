using Catedra1AlbertoLyons.src.models;
using Microsoft.EntityFrameworkCore;

namespace Catedra1AlbertoLyons.src.data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}