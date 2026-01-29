using Microsoft.EntityFrameworkCore;
using MV_to_do_list.Context;
using MV_to_do_list.Entities;

namespace MV_to_do_list.Services
{
    public class TodoService
    {
        //injeção de dependência do DbContext
        private readonly AppDbContext _context;
        public TodoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Todo>> GetTodosService()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<Todo> GetTodoByIdService(long Id)
        {
            return await _context.Todos.FindAsync(Id);
        }
    }
}
