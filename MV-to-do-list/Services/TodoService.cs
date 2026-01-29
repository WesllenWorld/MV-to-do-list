using Microsoft.EntityFrameworkCore;
using MV_to_do_list.Context;
using MV_to_do_list.DTOs;
using MV_to_do_list.Entities;
using System;

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
        public async Task<IEnumerable<ResponseTodoDTO>> GetAllTodos()
        {
            return await _context.Todos.Select(x => new ResponseTodoDTO { 
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Status = x.Status,
                CreatedAt = x.CreatedAt,

            }).ToListAsync();
        }

        public async Task<ResponseTodoDTO> GetTodoById(long id)
        {
            //return await _context.Todos.FindAsync(id);
            return await _context.Todos.Where(x => x.Id == id).Select(x => new ResponseTodoDTO
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Status = x.Status,
                CreatedAt = x.CreatedAt,
            }).SingleOrDefaultAsync();

        }

        public async Task<ResponseTodoDTO> CreateTodo(CreateTodoDTO todoDTO)
        {
            Todo newTodo = new Todo
            {
                Title = todoDTO.Title,
                Description = todoDTO.Description,
                //Status = todoDTO.Status não criar todo concluido
            };

            _context.AddAsync(newTodo);
            await _context.SaveChangesAsync();

            return new ResponseTodoDTO
            {
                //transfira do todo pro dto
                Id = newTodo.Id,
                Title = newTodo.Title,
                Description = newTodo.Description,
                Status = newTodo.Status,
                CreatedAt = newTodo.CreatedAt,

            };
        }

        public async Task<bool> UpdateTodoStatusById(long id, UpdateTodoStatusDTO updateTodo)
        {
            var todo = await _context.Todos.FindAsync(id);
            //bool updated = true;

            if(todo == null)
            {
                return false;
            }
            todo.Status = updateTodo.Status;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTodoById(long id)
        {
            var todo = await _context.Todos.FindAsync(id);
            
            if (todo == null)
            {
                return false;
            }
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
