using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class CaduceusContext : DbContext
    {
        public CaduceusContext(DbContextOptions<CaduceusContext> options) : base(options)
        {
        }

        public DbSet<Simptom> Simptom { get; set; }
    }
}
    