using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BLL.DAL
{
    public class Db : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Residence> Residences { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Document> Documents { get; set; }

        public Db(DbContextOptions<Db> options) : base(options)
        {
        }
    }
}
