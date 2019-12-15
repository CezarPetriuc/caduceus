using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class WebApplication2Context : DbContext
    {
        public WebApplication2Context(DbContextOptions<WebApplication2Context> options) : base(options)
        {
        }

        public DbSet<Simptom> Simptom { get; set; }
    }
}
    