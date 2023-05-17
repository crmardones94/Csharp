using Microsoft.EntityFrameworkCore;
using WebApiRegistroActividades.Model;

namespace WebApiRegistroActividades
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }


        public DbSet<Usuario> usuarios { get; set; }
    }
}
