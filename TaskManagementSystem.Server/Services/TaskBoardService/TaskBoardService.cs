using TaskManagementSystem.Server.Models;

namespace TaskManagementSystem.Server.Services.TaskBoardService;
public class TaskBoardService : ITaskBoardService
{
  private readonly IDbAccess _dbAccess;

  public TaskBoardService(IDbAccess dbAccess)
  {
    _dbAccess = dbAccess;
  }
  public async Task<TaskBoard> Create(TaskBoard request)
  {
    TaskBoard data = new TaskBoard 
    {
      Name = request.Name,
      Description = request.Description,
      CreatedAt = request.CreatedAt,
      UpdatedAt = request.UpdatedAt
    };

    var generatedId = await _dbAccess.SaveData<TaskBoard, dynamic>(
      """
        INSERT INTO task_board (name, description, created_at, updated_at) 
        VALUES (@Name, @Description, @CreatedAt, @UpdatedAt)
      """,
      data
    );
    data.Id = generatedId;
    return data;
  }

  public async Task Delete(long id)
  {
    await _dbAccess.SaveData<TaskBoard, dynamic>("DELETE FROM task_board WHERE id = @Id", new { Id = id });
  }

  public async Task<List<TaskBoard>> GetAll()
  {
    var result = await _dbAccess.GetData<TaskBoard, dynamic>(
      """
        SELECT
          id AS Id, 
          name AS Name,
          description AS Description, 
          created_at AS CreatedAt, 
          updated_at AS UpdatedAt
        FROM task_board
      """, new {}
    );
    return result.ToList();
  }

  public async Task<TaskBoard?> GetById(long id)
  {
    var result = await _dbAccess.GetData<TaskBoard, dynamic>(
      """
        SELECT
          id AS Id, 
          name AS Name,
          description AS Description, 
          created_at AS CreatedAt, 
          updated_at AS UpdatedAt
        FROM task_board WHERE id = @Id
      """, 
      new { 
        Id = id 
      }
    );
    return result.FirstOrDefault();
  }

  public async Task<TaskBoard> Update(long id, TaskBoard request)
  {
    TaskBoard data = new TaskBoard 
    {
      Id = id,
      Name = request.Name,
      Description = request.Description,
      CreatedAt = request.CreatedAt,
      UpdatedAt = request.UpdatedAt
    };

    await _dbAccess.SaveData<TaskBoard, dynamic>(
      """
        UPDATE task_board tb SET 
          name = @Name,
          description = @Description, 
          updated_at = @UpdatedAt 
        WHERE tb.id = @Id
      """,
      data
    );
    return data;
  }
}