namespace TaskManagementSystem.Server.Models;

public class TaskBoard
{
  public long? Id { get; set; }
  public required string Name { get; set; }
  public string? Description { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}