using MV_to_do_list.Context;
using MV_to_do_list.DTOs;
using MV_to_do_list.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MV_to_do_list.Services
{
    public class TodoService
    {
        private readonly AppDbContext _context;

        public TodoService()
        {
            // Em ASP.NET Web API clássico, você pode instanciar assim
            _context = new AppDbContext();
        }

        public async Task<IEnumerable<ResponseTodoDTO>> GetAllTodos()
        {
            var todos = await _context.Todos
                .Select(x => new ResponseTodoDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Status = x.Status,
                    CreatedAt = x.CreatedAt
                })
                .ToListAsync();  // EF6 suporta ToListAsync :contentReference[oaicite:1]{index=1}

            return todos;
        }

        public async Task<ResponseTodoDTO> GetTodoById(long id)
        {
            var todo = await _context.Todos
                .Where(x => x.Id == id)
                .Select(x => new ResponseTodoDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Status = x.Status,
                    CreatedAt = x.CreatedAt
                })
                .SingleOrDefaultAsync();  // EF6 também suporta SingleOrDefaultAsync :contentReference[oaicite:2]{index=2}

            return todo;
        }

        public async Task<ResponseTodoDTO> CreateTodo(CreateTodoDTO todoDTO)
        {
            var newTodo = new Todo
            {
                Title = todoDTO.Title,
                Description = todoDTO.Description,
                // Status pode ficar padrão se não for enviado
            };

            _context.Todos.Add(newTodo);
            await _context.SaveChangesAsync(); // EF6 SaveChangesAsync :contentReference[oaicite:3]{index=3}

            return new ResponseTodoDTO
            {
                Id = newTodo.Id,
                Title = newTodo.Title,
                Description = newTodo.Description,
                Status = newTodo.Status,
                CreatedAt = newTodo.CreatedAt
            };
        }

        public async Task<bool> UpdateTodoStatusById(long id, UpdateTodoStatusDTO updateTodo)
        {
            var todo = await _context.Todos.FindAsync(id); // FindAsync existe no EF6 :contentReference[oaicite:4]{index=4}
            if (todo == null)
                return false;

            todo.Status = updateTodo.Status;
            await _context.SaveChangesAsync(); // assíncrono no EF6 :contentReference[oaicite:5]{index=5}
            return true;
        }

        public async Task<bool> DeleteTodoById(long id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
                return false;

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
