using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Server.Models;
using TaskManagementSystem.Server.Services.TaskListService;

namespace TaskManagementSystem.Server.Controllers;

[ApiController]
[EnableCors("corsapp")]
[Route("[controller]/[action]")]
public class TaskListController: ControllerBase
{
  private readonly ITaskListService _taskListService;

  public TaskListController(ITaskListService taskListService)
  {
    _taskListService = taskListService;
  }

  [HttpGet]
  public async Task<ActionResult<List<TaskList>>> GetAll()
  {
    var taskLists = await _taskListService.GetAll();
    return Ok(taskLists);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<TaskList>> GetById(long id)
  {
    var taskList = await _taskListService.GetById(id);
    if (taskList is null) 
    {
      return NotFound("Task list not found");
    }
    return Ok(taskList);
  }

  [HttpPost]
  public async Task<ActionResult> Create(TaskList request)
  {
    var result = await _taskListService.Create(request);
    return Ok(result);
  }

  [HttpPut("{id}")]
  public async Task<ActionResult> Update([FromRoute] long id, [FromBody] TaskList request)
  {
    var result = await _taskListService.Update(id, request);
    return Ok(result);
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> Delete(long id)
  {
    await _taskListService.Delete(id);
    return Ok();
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<List<TaskList>>> GetByBoardId(long id)
  {
    var taskLists = await _taskListService.GetByBoardId(id);
    return Ok(taskLists);
  }
}