using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAway.Domain.Entities;

namespace TakeAway.Persistance.Context
{
	public class OrderContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=ATMACA\\SQLEXPRESS;initial Catalog=TakeAwayOrderDb;integrated Security=true");
		}
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Ordering> Orderings { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
	}
}
