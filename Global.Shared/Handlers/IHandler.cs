namespace Global.Shared.Handlers;

public interface IHandler<T>
{
    Task<T> Handle(T command);
}