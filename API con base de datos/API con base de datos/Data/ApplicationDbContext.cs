using API_con_base_de_datos.Models;
using Microsoft.EntityFrameworkCore;



namespace API_con_base_de_datos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Producto> Productos { get; set; }
    }
}
