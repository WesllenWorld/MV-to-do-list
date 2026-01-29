using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MV_to_do_list.DTOs;
using MV_to_do_list.Entities;
using MV_to_do_list.Services;

namespace MV_to_do_list.Controllers
{
    [ApiController]
    [Route("api/tarefas")]
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
            var todos = await todoService.GetTodosService();
            return Ok(todos);
        }

        // GET: Retornar uma tarefa específica pelo identificador
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(long Id)
        {
            var todo = await todoService.GetTodoByIdService(Id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        //POST: Cadastrar uma nova tarefa
        //[HttpPost]


        //PUT: Atualizar o status da tarefa

        //DELETE: Remover uma tarefa

    }
}
