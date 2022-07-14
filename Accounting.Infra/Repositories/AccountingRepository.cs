using Global.Shared.Repository;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace Accounting.Infra.Repositories;

public class AccountingRepository : BaseRepository
{
    public AccountingRepository(IConfiguration config)
    {
        InitConnection(config);
    }
}
