using Accounting.Domain.Repositories.Interfaces;
using Dapper;
using Global.Shared.Repository;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace Accounting.Infra.Repositories;

public class AccountingRepository : BaseRepository, IAccountingRepository
{
    public AccountingRepository(IConfiguration config)
    {
        InitConnection(config);
    }

    public async void CreateAccountType(string name)
    {
        await using SqliteConnection conn = new(ConnSqlite);
        await conn.OpenAsync();

        await conn.ExecuteAsync("INSERT INTO account_type (name) VALUES (@Name)", new
        {
            Name = name
        });
    }
}