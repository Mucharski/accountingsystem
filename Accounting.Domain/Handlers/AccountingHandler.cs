using Accounting.Domain.Commands;
using Accounting.Domain.Handlers.Interfaces;
using Accounting.Domain.Repositories.Interfaces;
using Global.Shared.Entities;

namespace Accounting.Domain.Handlers;

public class AccountingHandler : IAccountingHandler
{
    private readonly IAccountingRepository _repository;

    public AccountingHandler(IAccountingRepository repository)
    {
        _repository = repository;
    }

    public async Task<GenericApiResponse<string>> Handle(CreateAccountTypeCommand command)
    {
        _repository.CreateAccountType(command.Name);
        
        return new GenericApiResponse<string>("Funcionou!", true, "Dados obtidos com sucesso!");
    }
}