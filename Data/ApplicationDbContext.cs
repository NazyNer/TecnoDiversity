using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TecnoDiversity.Models;

namespace TecnoDiversity.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {}

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<SubCategoria> SubCategorias { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Salida> Salidas { get; set; }
}
