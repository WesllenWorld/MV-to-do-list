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
                .ToListAsync();  

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
                .SingleOrDefaultAsync(); 

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
            await _context.SaveChangesAsync(); 

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
            var todo = await _context.Todos.FindAsync(id); 
            if (todo == null)
                return false;

            todo.Status = updateTodo.Status;
            await _context.SaveChangesAsync(); 
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
