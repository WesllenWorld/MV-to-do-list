using System.Net;
using System.Web.Http;
using MV_to_do_list.DTOs;
using MV_to_do_list.Models;
using MV_to_do_list.Services;
using System.Threading.Tasks;

namespace MV_to_do_list.Controllers
{
    [RoutePrefix("api/tarefas")]
    public class TodoController : ApiController
    {
        private readonly TodoService todoService;

        public TodoController()
        {
            // Se você não tiver DI configurado ainda,
            // pode instanciar o service aqui (ou usar um container)
            todoService = new TodoService();
        }

        // GET api/tarefas
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetTodos()
        {
            var todos = await todoService.GetAllTodos();
            return Ok(todos);
        }

        // GET api/tarefas/{id}
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IHttpActionResult> GetTodoById(long id)
        {
            var todo = await todoService.GetTodoById(id);
            if (todo == null)
                return NotFound();

            return Ok(todo);
        }

        // POST api/tarefas
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> CreateTodo([FromBody] CreateTodoDTO todoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var todo = await todoService.CreateTodo(todoDTO);
                return CreatedAtRoute("", new { id = todo.Id }, todo);
            }
            catch (System.Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, $"Internal server error: {e.Message}");
            }
        }

        // PUT api/tarefas/{id}
        [HttpPut]
        [Route("{id:long}")]
        public async Task<IHttpActionResult> UpdateTodoStatusById(long id, [FromBody] UpdateTodoStatusDTO updateTodo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool updated = await todoService.UpdateTodoStatusById(id, updateTodo);
            if (updated)
                return StatusCode(HttpStatusCode.NoContent);
            else
                return NotFound();
        }

        // DELETE api/tarefas/{id}
        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IHttpActionResult> DeleteTodoById(long id)
        {
            bool removed = await todoService.DeleteTodoById(id);
            if (removed)
                return StatusCode(HttpStatusCode.NoContent);
            else
                return NotFound();
        }
    }
}
