using Microsoft.Extensions.Configuration;

namespace Global.Shared.Repository;

public abstract class BaseRepository
{
    protected static void InitConnection(IConfiguration config)
    {
        SqliteConnection(config);
    }


    private static void SqliteConnection(IConfiguration config)
    {
        string connString = $"Data Source={config.GetConnectionString("Sqlite")}; Version=3;";
        ConnSqlite = connString;
    }

    protected static string ConnSqlite { get; set; }
}