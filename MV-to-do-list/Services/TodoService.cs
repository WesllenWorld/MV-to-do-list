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
        public async Task<IEnumerable<Todo>> GetAllTodos()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<Todo> GetTodoById(long id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<Todo> CreateTodo(CreateTodoDTO todoDTO)
        {
            Todo newTodo = new Todo
            {
                Title = todoDTO.Title,
                Description = todoDTO.Description,
                Status = todoDTO.Status
            };

            _context.AddAsync(newTodo);
            await _context.SaveChangesAsync();

            return newTodo;
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
