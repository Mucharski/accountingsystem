using SistemasCorporativos.Entities;

namespace Global.Shared.Handlers;

public interface IHandler<T>
{
    Task<GenericApiResponse<T>> Handle(T command);
}
