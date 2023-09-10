using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Server.Models;
using TaskManagementSystem.Server.Services.TaskService;

namespace TaskManagementSystem.Server.Controllers;

[ApiController]
[EnableCors("corsapp")]
[Route("[controller]/[action]")]
public class TaskController: ControllerBase
{
  private readonly ITaskService _taskService;

  public TaskController(ITaskService taskService)
  {
    _taskService = taskService;
  }

  [HttpGet]
  public async Task<ActionResult<List<TaskModel>>> GetAll()
  {
    var tasks = await _taskService.GetAll();
    return Ok(tasks);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<TaskModel>> GetById(long id)
  {
    var task = await _taskService.GetById(id);
    if (task is null) 
    {
      return NotFound("Task not found");
    }
    return Ok(task);
  }

  [HttpPost]
  public async Task<ActionResult> Create(TaskModel request)
  {
    await _taskService.Create(request);
    return Ok();
  }

  [HttpPut("{id}")]
  public async Task<ActionResult> Update([FromRoute] long id, [FromBody] TaskModel request)
  {
    await _taskService.Update(id, request);
    var task = await _taskService.GetById(id);
    if (task is null)
    {
      return NotFound("Task not found");
    }
    return Ok(task);
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> Delete(long id)
  {
    await _taskService.Delete(id);
    return Ok();
  }
}