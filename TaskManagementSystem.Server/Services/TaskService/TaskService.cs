using TaskManagementSystem.Server.Models;

namespace TaskManagementSystem.Server.Services.TaskService;
public class TaskService : ITaskService
{
  private readonly IDbAccess _dbAccess;

  public TaskService(IDbAccess dbAccess)
  {
    _dbAccess = dbAccess;
  }
  public async Task Create(TaskModel request)
  {
    await _dbAccess.SaveData<TaskModel, dynamic>(
      """
        INSERT INTO task (name, description, task_list_id, sub_tasks, created_at, updated_at) 
        VALUES (@Name, @Description, @TaskListId, @SubTaskIds, @CreatedAt, @UpdatedAt)
      """,
      new {
        Name = request.Name,
        Description = request.Description,
        TaskListId = request.TaskListId,
        SubTaskIds = request.SubTaskIds,
        CreatedAt = request.CreatedAt,
        UpdatedAt = request.UpdatedAt
      }
    );
  }

  public async Task Delete(long id)
  {
    await _dbAccess.SaveData<TaskModel, dynamic>("DELETE FROM task WHERE id = @Id", new { Id = id });
  }

  public async Task<List<TaskModel>> GetAll()
  {
    var result = await _dbAccess.GetData<TaskModel, dynamic>(
      """
        SELECT
          id AS Id, 
          name AS Name, 
          description AS Description,
          task_list_id AS TaskListId,
          sub_tasks AS SubTaskIds,
          created_at AS CreatedAt, 
          updated_at AS UpdatedAt
        FROM task
      """, new {}
    );
    return result.ToList();
  }

  public async Task<TaskModel?> GetById(long id)
  {
    var result = await _dbAccess.GetData<TaskModel, dynamic>(
      """
        SELECT
          id AS Id, 
          name AS Name, 
          description AS Description,
          task_list_id AS TaskListId,
          sub_tasks AS SubTaskIds,
          created_at AS CreatedAt, 
          updated_at AS UpdatedAt
        FROM task WHERE id = @Id
      """, 
      new { 
        Id = id 
      }
    );
    return result.FirstOrDefault();
  }

  public async Task Update(long id, TaskModel request)
  {
    await _dbAccess.SaveData<TaskModel, dynamic>(
      """
        UPDATE task t SET 
          name = @Name, 
          description = @Description,
          task_list_id = @TaskListId,  
          sub_tasks = @SubTaskIds,
          updated_at = @UpdatedAt 
        WHERE t.id = @Id
      """,
      new {
        Id = id,
        Name = request.Name,
        Description = request.Description,
        TaskListId = request.TaskListId,
        SubTaskIds = request.SubTaskIds,
        UpdatedAt = request.UpdatedAt
      }
    );
  }
}