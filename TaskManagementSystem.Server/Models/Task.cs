namespace TaskManagementSystem.Server.Models;

public class TaskModel
{
  public long Id { get; set; }
  public required string Name { get; set; }
  public string? Description { get; set; }
  public TaskStatus Status { get; set; }
  public IList<long> SubTaskIds { get; set; } = new List<long>();
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}