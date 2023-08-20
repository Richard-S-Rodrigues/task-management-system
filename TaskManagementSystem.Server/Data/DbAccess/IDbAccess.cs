public interface IDbAccess 
{
  Task<IEnumerable<T>> GetData<T, U>(
    string storedProcedure,
    U parameters,
    string connectionId = "DefaultConnection"
  );

  Task SaveData<T, U>(
    string storedProcedure,
    U parameters,
    string connectionId = "DefaultConnection"
  );
}