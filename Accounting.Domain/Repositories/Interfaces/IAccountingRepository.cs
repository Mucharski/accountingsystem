namespace Accounting.Domain.Repositories.Interfaces;

public interface IAccountingRepository
{
    public Task<int> CreateAccountType(string name);
}