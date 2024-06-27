using CommissionApp.Entities;
namespace CommissionApp.Repositories;
public interface IReadRepository<out T> where T : class, IEntity
{
    IEnumerable<T> GetAll();
    T GetById(int id);
}


