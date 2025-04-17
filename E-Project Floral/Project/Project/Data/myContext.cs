using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data
{
    public class myContext : DbContext
    {
        public myContext(DbContextOptions<myContext> options) : base(options)
        {
        }
        public DbSet<Bouquet> Bouquets { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
