using Microsoft.EntityFrameworkCore;

namespace MV_to_do_list.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
