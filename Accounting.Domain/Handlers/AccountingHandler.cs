using Accounting.Domain.Commands;
using Accounting.Domain.Handlers.Interfaces;
using Accounting.Domain.Repositories.Interfaces;
using Global.Shared;
using Global.Shared.Entities;

namespace Accounting.Domain.Handlers;

public class AccountingHandler : IAccountingHandler
{
    private readonly IAccountingRepository _repository;

    public AccountingHandler(IAccountingRepository repository)
    {
        _repository = repository;
    }

    public async Task<IGenericApiResponse> Handle(CreateAccountTypeCommand command)
    {
        command.Validate();
        
        if (!command.IsValid)
        {
            return new InvalidCommandData(command.ErrorsList);
        }
        
        int rowsInserted = await _repository.CreateAccountType(command.Name);

        if (rowsInserted == 0)
        {
            return new GenericApiResponse<string>("Houve um erro ao inserir o registro.", false, "Error");
        }
        
        return new GenericApiResponse<string>("Funcionou!", true, "Dados obtidos com sucesso!");
    }
}