namespace TaskManagementSystem.Server.Models;

public class TaskModel
{
  public long? Id { get; set; }
  public required string Name { get; set; }
  public string? Description { get; set; }
  public long TaskListId { get; set; }
  public IList<int> SubTaskIds { get; set; } = new List<int>();
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}