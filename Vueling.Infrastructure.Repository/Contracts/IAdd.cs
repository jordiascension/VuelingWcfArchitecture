namespace Vueling.Infrastructure.Repository.Contracts
{
    public interface IAdd<T>
    {
        T Add(T model);
    }
}
