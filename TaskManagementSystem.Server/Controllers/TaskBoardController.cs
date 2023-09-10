using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Server.Models;
using TaskManagementSystem.Server.Services.TaskBoardService;

namespace TaskManagementSystem.Server.Controllers;

[ApiController]
[EnableCors("corsapp")]
[Route("[controller]/[action]")]
public class TaskBoardController: ControllerBase
{
  private readonly ITaskBoardService _taskBoardService;

  public TaskBoardController(ITaskBoardService taskBoardService)
  {
    _taskBoardService = taskBoardService;
  }

  [HttpGet]
  public async Task<ActionResult<List<TaskBoard>>> GetAll()
  {
    var tasks = await _taskBoardService.GetAll();
    return Ok(tasks);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<TaskBoard>> GetById(long id)
  {
    var taskBoard = await _taskBoardService.GetById(id);
    if (taskBoard is null) 
    {
      return NotFound("Task board not found");
    }
    return Ok(taskBoard);
  }

  [HttpPost]
  public async Task<ActionResult> Create(TaskBoard request)
  {
    await _taskBoardService.Create(request);
    return Ok();
  }

  [HttpPut("{id}")]
  public async Task<ActionResult> Update([FromRoute] long id, [FromBody] TaskBoard request)
  {
    await _taskBoardService.Update(id, request);
    var taskBoard = await _taskBoardService.GetById(id);
    if (taskBoard is null)
    {
      return NotFound("Task board not found");
    }
    return Ok(taskBoard);
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> Delete(long id)
  {
    await _taskBoardService.Delete(id);
    return Ok();
  }
}