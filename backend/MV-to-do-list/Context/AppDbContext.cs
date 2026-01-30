using Microsoft.EntityFrameworkCore;
using MV_to_do_list.Entities;


namespace MV_to_do_list.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; } = null;
    }
}
