using Microsoft.EntityFrameworkCore;
using PracticaCRUD_Producto.Models.Entities;

namespace PracticaCRUD_Producto.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Producto> Producto {  get; set;  }
        public DbSet<Categoria> Categoria { get; set; }
    }
}
