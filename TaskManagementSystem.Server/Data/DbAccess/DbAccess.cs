using System.Data;
using Dapper;
using Npgsql;

public class DbAccess: IDbAccess 
{ 
  private readonly IConfiguration _config;
  
  public DbAccess(IConfiguration config)
  {
    _config = config;
  }

  public async Task<IEnumerable<T>> GetData<T, U>(
    string storedProcedure,
    U parameters,
    string connectionId = "DefaultConnection"
  )
  {
    using var connection = new NpgsqlConnection(_config.GetConnectionString(connectionId));
    return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.Text);
  }

  public async Task SaveData<T, U>(
    string storedProcedure,
    U parameters,
    string connectionId = "DefaultConnection"
  )
  {
    using var connection = new NpgsqlConnection(_config.GetConnectionString(connectionId));
    await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.Text);
  }
}