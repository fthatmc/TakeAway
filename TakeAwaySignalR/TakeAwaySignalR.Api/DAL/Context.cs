using Microsoft.EntityFrameworkCore;

namespace TakeAwaySignalR.Api.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ATMACA\\SQLEXPRESS;database=TakeAwaySignalRDb;integrated security=true;TrustServerCertificate=true;");
        }
        public DbSet<Delivery> Deliveries { get; set; }
    }
}
