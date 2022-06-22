using Microsoft.EntityFrameworkCore;

namespace ExportData.Data.Repository
{
    internal class DbRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly PersonContext _db;
        private readonly DbSet<T> _set;
        public bool AutoSaveChanges { get; set; } = true;
        public virtual IQueryable<T> Items => _set;
        public DbRepository(PersonContext db)
        {
            _db = db;
            _set = db.Set<T>();
        }
        public T Add(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            if (AutoSaveChanges)
                _db.SaveChanges();
            return item;
        }
        public async Task<T> AddAsync(T item, CancellationToken cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return item;
        }
        public async Task AddAsync(IEnumerable<T> items, CancellationToken cancel = default)
        {
            foreach(var item in items)
            {
                if (item is null) throw new ArgumentNullException(nameof(item));
                _db.Entry(item).State = EntityState.Added;
            }
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        }
        public T Get(int id)
        {
            return Items.SingleOrDefault(item => item.Id == id);
        }
        public async Task<T> GetAsync(int id, CancellationToken cancel = default) => await Items
            .SingleOrDefaultAsync(item => item.Id == id)
            .ConfigureAwait(false);
        public void Remove(int id)
        {
            _db.Remove(new T { Id = id });
            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int id, CancellationToken cancel = default)
        {
            _db.Remove(new T { Id = id });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        }
        public void Update(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Modified;
            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task UpdateAsync(T item, CancellationToken cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Modified;
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        }
    }
}
