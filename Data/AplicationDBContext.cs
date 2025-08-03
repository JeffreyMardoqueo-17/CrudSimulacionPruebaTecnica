using CrudSimulacionPruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudSimulacionPruebaTecnica.Data
{
    public class AplicationDBContext : DbContext
    {
        public AplicationDBContext(DbContextOptions<AplicationDBContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
        
    }
}
