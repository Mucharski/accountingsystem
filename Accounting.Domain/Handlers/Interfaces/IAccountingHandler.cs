using Accounting.Domain.Commands;
using Global.Shared.Handlers;

namespace Accounting.Domain.Handlers.Interfaces;

public interface IAccountingHandler : IHandler<CreateAccountTypeCommand>
{
}