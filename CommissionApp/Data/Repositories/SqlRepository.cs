namespace CommissionApp.Data.Repositories;

using CommissionApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly DbSet<T> _dbSet;
    private readonly DbContext _dbContext;
    private readonly Action<T>? _itemAddedCallback;
    public SqlRepository(DbContext dbContext, Action<T>? itemAddedCallback = null)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
        _itemAddedCallback = itemAddedCallback;
    }

    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;
    public event EventHandler<T>? AllRemoved;
    public event EventHandler<T>? NewAuditEntry;
    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }
    public T? GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Add(T item)
    {
        _dbSet.Add(item);
        _itemAddedCallback?.Invoke(item);
        ItemAdded?.Invoke(this, item);
    }
    public void Remove(T item)
    {
        _dbSet.Remove(item);
        ItemRemoved?.Invoke(this, item);
        NewAuditEntry?.Invoke(this, item);
    }
    public void RemoveAll()
    {
        var allEntities = _dbSet.ToList();
        _dbSet.RemoveRange(allEntities);
        foreach (var item in allEntities)
        {
            ItemRemoved?.Invoke(this, item);
            NewAuditEntry?.Invoke(this, item);
        }
    }
    public void Save()
    {
        _dbContext.SaveChanges();
    }
}