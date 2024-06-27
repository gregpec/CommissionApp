namespace CommissionApp.Repositories
{
    using CommissionApp.Entities;
  
    public class ListRepository<T> : IRepository<T>
     where T : class, IEntity, new() 
    {
        private readonly List<T> _items = new();
        public IEnumerable<T> GetAll()
        {
            return _items.ToList(); 
        }
        public T? GetById(int id)
        {
            return _items.Single(item => item.Id == id);
        }
        public void Add(T item)
        {
            item.Id = _items.Count + 1; 
            _items.Add(item);
        }
        public void Remove(T item)
        {
            _items.Remove(item);
        }
        public void RemoveAll()
        {
            var allEntities = _items.ToList();
            foreach (var item in allEntities)
            {
            }
        }
        public void Save()
        {
        }
    }
}
