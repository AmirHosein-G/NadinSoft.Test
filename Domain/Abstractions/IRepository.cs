namespace Domain.Abstractions
{
    public interface IRepository<T> 
    {
        IUnitOfWork UnitOfWork { get; }
    }
}