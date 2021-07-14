namespace Vueling.Infrastructure.Application.Contracts
{
    public interface IAdd<T>
    {
        T Add(T model);
    }
}
