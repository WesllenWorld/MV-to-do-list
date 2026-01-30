using System.Data.Entity;
using MV_to_do_list.Models;


namespace MV_to_do_list.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=MinhaConexao")
        {

        }

        public DbSet<Todo> Todos { get; set; } = null;
    }
}
