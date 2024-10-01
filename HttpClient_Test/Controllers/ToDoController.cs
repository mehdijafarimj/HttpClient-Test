using HttpClient_Test.Domain;
using HttpClient_Test.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace HttpClient_Test.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class ToDoController : ControllerBase
{
    private readonly ToDoListHandler _handler;
    public ToDoController(ToDoListHandler handler)
    {
        _handler = handler;
    }
    
    [HttpGet]
    public IActionResult GetAllTask()
    {
        var toDoListHandler = new ToDoListHandler();

        var content = toDoListHandler.GetAllTasks();
        return Ok(content);
    }

    [HttpPost]
    public IActionResult CreateTasks([FromBody] CreateTaskDto dto)
    {
        bool success = _handler.CreateTask(dto);

        if (success == true)
        {
            return Ok("created successfully");
        }
        else
        {
            return BadRequest("failed to create task");
        }
    }

    [HttpPatch("unmark/{id}")]
    public IActionResult UncheckStatus(int id)
    {
        var task = _handler.Unmark(id);

        if (task == true)
        {
            return Ok("Updated successfully");
        }
        else
        {
            return NotFound("not found");
        }
    }

    [HttpPatch("mark/{id}")]
    public IActionResult CheckStatus(int id)
    {
        var task = _handler.Mark(id);

        if (task == true)
        {
            return Ok("Checked");
        }
        else
        {
            return BadRequest("Already checked");
        }

    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var task = _handler.DeleteTask(id);

        if (task == true)
        {
            return Ok("Deleted successfully");
        }
        else
        {
            return NotFound("not found");
        }
    }

}
