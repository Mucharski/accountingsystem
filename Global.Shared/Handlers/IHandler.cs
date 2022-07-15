using Global.Shared.Command;
using Global.Shared.Entities;

namespace Global.Shared.Handlers;

public interface IHandler<T, R> where T : ICommand
{
    Task<GenericApiResponse<R>> Handle(T command);
}