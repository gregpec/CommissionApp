using CommissionApp.Data.Entities;
namespace CommissionApp.Data.Repositories;
public interface IReadRepository<out T> where T : class, IEntity
{
    IEnumerable<T> GetAll();
    T GetById(int id);
}


