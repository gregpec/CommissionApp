using CommissionApp.Data.Entities;
namespace CommissionApp.Data.Repositories;
public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
    where T : class, IEntity
{
}

