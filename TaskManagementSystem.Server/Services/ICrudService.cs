namespace TaskManagementSystem.Server.Services;

public interface ICrudService<T>
{
  Task<List<T>> GetAll();
  Task<T?> GetById(long id);
  Task<T> Create(T request);
  Task<T> Update(long id, T request);
  Task Delete(long id);
}