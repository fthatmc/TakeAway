using Microsoft.EntityFrameworkCore;
using TakeAway.Comment.DAL.Entities;

namespace TakeAway.Comment.DAL.Context
{
    public class CommentContext : DbContext
    {
        public CommentContext(DbContextOptions<CommentContext> options) : base(options)
        {

        }

        public DbSet<UserComment> UserComments { get; set; }
    }
}
