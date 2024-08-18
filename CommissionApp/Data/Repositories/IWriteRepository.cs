using CommissionApp.Data.Entities;

namespace CommissionApp.Data.Repositories
{
    public interface IWriteRepository<in T> where T : class, IEntity
    {
        void Add(T item);
        void Remove(T item);
        void RemoveAll();
        void Save();
    }
}
