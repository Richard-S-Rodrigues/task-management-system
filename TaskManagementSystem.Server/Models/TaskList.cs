namespace TaskManagementSystem.Server.Models;

public class TaskList
{
  public long? Id { get; set; }
  public required string Name { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}