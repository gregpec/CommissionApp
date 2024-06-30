using CommissionApp.Entities;
namespace CommissionApp.Repositories;
public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
    where T : class, IEntity
{
}

