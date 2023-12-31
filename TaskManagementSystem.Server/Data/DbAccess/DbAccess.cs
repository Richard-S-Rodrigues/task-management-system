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

  public async Task<int?> SaveData<T, U>(
    string storedProcedure,
    U parameters,
    string connectionId = "DefaultConnection"
  )
  {
    using var connection = new NpgsqlConnection(_config.GetConnectionString(connectionId));
    await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.Text);
    
    storedProcedure += "RETURNING Id";

    try
    {
      int generatedId = connection.QuerySingle<int>(storedProcedure, parameters);
      return generatedId;
    } 
    catch(InvalidOperationException ex)
    {
      Console.WriteLine("No records were inserted or retrieved: " + ex.Message);
    }
    catch(Exception ex) 
    {
      Console.WriteLine("An error occured: " + ex.Message);
    }
    return null;
  }
}