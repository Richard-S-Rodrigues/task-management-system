using TaskManagementSystem.Server.Models;

namespace TaskManagementSystem.Server.Services.TaskListService;

public interface ITaskListService: ICrudService<TaskList>
{
  Task<List<TaskList>> GetByBoardId(long boardId);
}