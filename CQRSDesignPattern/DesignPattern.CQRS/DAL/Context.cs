using Microsoft.EntityFrameworkCore;

namespace DesignPattern.CQRS.DAL
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=NAKI\\SQLEXPRESS;initial catalog=DesignPatternCQRS;integrated security=true;");

        }

        public DbSet<Product> Products { get; set; }
    }
}
