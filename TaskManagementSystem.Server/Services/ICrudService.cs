namespace TaskManagementSystem.Server.Services;

public interface ICrudService<T>
{
  Task<List<T>> GetAll();
  Task<T?> GetById(long id);
  Task Create(T request);
  Task Update(long id, T request);
  Task Delete(long id);
}