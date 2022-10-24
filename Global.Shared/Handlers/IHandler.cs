using Global.Shared.Command;
using Global.Shared.Entities;

namespace Global.Shared.Handlers;

public interface IHandler<T> where T : ICommand
{
    Task<IGenericApiResponse> Handle(T command);
}