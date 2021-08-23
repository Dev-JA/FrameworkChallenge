using Ecommerce.models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce
{
    public class CRUDContext : DbContext
    {
        public CRUDContext(DbContextOptions<CRUDContext> options) : base(options) { }
        public DbSet<Fruta> Frutas { get; set; }
    }
}
