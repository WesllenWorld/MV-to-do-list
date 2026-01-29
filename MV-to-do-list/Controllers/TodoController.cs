using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MV_to_do_list.DTOs;
using MV_to_do_list.Entities;
using MV_to_do_list.Services;

namespace MV_to_do_list.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        //injeção de dependência do Service
        private readonly TodoService todoService;
        public TodoController(TodoService todoService)
        {
            this.todoService = todoService;
        }

        //GET: Retornar todas as tarefas cadastradas
        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            //return await _context.Tarefas.ToListAsync();
            var todos = await todoService.GetAllTodos();
            return Ok(todos);
        }

        // GET: Retornar uma tarefa específica pelo identificador
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(long id)
        {
            var todo = await todoService.GetTodoById(id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        //POST: Cadastrar uma nova tarefa
        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] CreateTodoDTO todoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var todo = await todoService.CreateTodo(todoDTO);
                return CreatedAtAction(nameof(GetTodoById), new { id = todo.Id }, todo);

            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }


        //PUT: Atualizar o status da tarefa
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoStatusById(long id, [FromBody] UpdateTodoStatusDTO updateTodo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool updated = await todoService.UpdateTodoStatusById(id, updateTodo);
            if (updated)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        //DELETE: Remover uma tarefa
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoById(long id)
        {
            bool todo = await todoService.DeleteTodoById(id);
            if (todo)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
                
        }

    }
}
