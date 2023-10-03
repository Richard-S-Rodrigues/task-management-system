using TaskManagementSystem.Server.Models;

namespace TaskManagementSystem.Server.Services.TaskListService;
public class TaskListService : ITaskListService
{
  private readonly IDbAccess _dbAccess;

  public TaskListService(IDbAccess dbAccess)
  {
    _dbAccess = dbAccess;
  }
  public async Task<TaskList> Create(TaskList request)
  {
    TaskList data = new TaskList 
    {
      Name = request.Name,
      TaskBoardId = request.TaskBoardId,
      CreatedAt = request.CreatedAt,
      UpdatedAt = request.UpdatedAt
    };

    var generatedId = await _dbAccess.SaveData<TaskList, dynamic>(
      """
        INSERT INTO task_list (name, task_board_id, created_at, updated_at) 
        VALUES (@Name, @TaskBoardId, @CreatedAt, @UpdatedAt)
      """,
      data
    );
    data.Id = generatedId;

    return data;
  }

  public async Task Delete(long id)
  {
    await _dbAccess.SaveData<TaskList, dynamic>("DELETE FROM task_list WHERE id = @Id", new { Id = id });
  }

  public async Task<List<TaskList>> GetAll()
  {
    var result = await _dbAccess.GetData<TaskList, dynamic>(
      """
        SELECT
          id AS Id, 
          name AS Name,
          task_board_id AS TaskBoardId, 
          created_at AS CreatedAt, 
          updated_at AS UpdatedAt
        FROM task_list
      """, new {}
    );
    return result.ToList();
  }

  public async Task<TaskList?> GetById(long id)
  {
    var result = await _dbAccess.GetData<TaskList, dynamic>(
      """
        SELECT
          id AS Id, 
          name AS Name, 
          task_board_id AS TaskBoardId,
          created_at AS CreatedAt, 
          updated_at AS UpdatedAt
        FROM task_list WHERE id = @Id
      """, 
      new { 
        Id = id 
      }
    );
    return result.FirstOrDefault();
  }

  public async Task<TaskList> Update(long id, TaskList request)
  {
    TaskList data = new TaskList 
    {
      Id = id,
      Name = request.Name,
      TaskBoardId = request.TaskBoardId,
      CreatedAt = request.CreatedAt,
      UpdatedAt = request.UpdatedAt
    };

    await _dbAccess.SaveData<TaskList, dynamic>(
      """
        UPDATE task_list tl SET 
          name = @Name,
          task_board_id = @TaskBoardId, 
          updated_at = @UpdatedAt 
        WHERE tl.id = @Id
      """,
      data
    );

    return data;
  }

  public async Task<List<TaskList>> GetByBoardId(long boardId)
  {
    var result = await _dbAccess.GetData<TaskList, dynamic>(
      """
        SELECT
          id AS Id, 
          name AS Name,
          task_board_id AS TaskBoardId, 
          created_at AS CreatedAt, 
          updated_at AS UpdatedAt
        FROM task_list WHERE task_board_id = @TaskBoardId
      """, new {
        TaskBoardId = boardId
      }
    );
    return result.ToList();
  }
}