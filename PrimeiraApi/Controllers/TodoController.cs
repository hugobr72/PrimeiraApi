using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimeiraApi.Data;
using PrimeiraApi.Models;
using PrimeiraApi.NovaPasta2;

namespace PrimeiraApi.Controllers {
    [ApiController]
    [Route("api")]
    public class TodoController : ControllerBase {
        [HttpGet]
        [Route("todos")]
        public async Task<IActionResult> Get(
            [FromServices] AppDbContext context
            ) {
            try { 
            var todos = await context.Todos.ToListAsync();
            return Ok(todos);
            }catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("todos/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id) {
            var todo = await context
                .Todos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return todo == null
                ? NotFound()
                : Ok(todo);
        }

        [HttpPost("todos")]
        public async Task<IActionResult> PostAsync(
        [FromServices] AppDbContext context,
        [FromBody] CreateTodoViewModel model) {
            if (!ModelState.IsValid)
                return BadRequest();

            var todo = new Todo {
                Date = DateTime.Now,
                Done = false,
                Title = model.Title
            };

            try {
                await context.Todos.AddAsync(todo);
                await context.SaveChangesAsync();
                return Created($"api/todos/{todo.Id}", todo);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("todos/{id}")]
        public async Task<IActionResult> DeleteById(
            [FromServices] AppDbContext context,
            [FromRoute] int id) {
            var todo = await context
                .Todos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            try {
                context.Todos.Remove(todo);
                await context.SaveChangesAsync();
                return Ok();
            }catch(Exception e) {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Route("todos/{id}")]
        public async Task<IActionResult> UpdateById(
        [FromServices] AppDbContext context,
        [FromRoute] int id,
        [FromBody] CreateTodoViewModel model
        ) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            var todo = await context
                .Todos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            todo.Title = model.Title;
            todo.Date = DateTime.Now;
            try {
                context.Todos.Update(todo);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}
