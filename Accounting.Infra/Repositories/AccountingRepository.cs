using Accounting.Domain.Repositories.Interfaces;
using Accounting.Infra.Queries;
using Dapper;
using Global.Shared.Repository;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace Accounting.Infra.Repositories;

public class AccountingRepository : BaseRepository, IAccountingRepository
{
    private readonly AccountingQueries _queries;
    public AccountingRepository(IConfiguration config, AccountingQueries queries)
    {
        InitConnection(config);
        _queries = queries;
    }

    public async Task<int> CreateAccountType(string name)
    {
        await using SqliteConnection conn = new(ConnSqlite);
        await conn.OpenAsync();

        return await conn.ExecuteAsync(_queries.CreateAccountType(), new
        {
            Name = name
        });
    }
}