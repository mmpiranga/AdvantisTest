using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private TestHaylesEntities _context;
        private DbSet<T> _dbSet;

        public GenericRepository()
        {
            this._context = new TestHaylesEntities();
            this._dbSet = _context.Set<T>();
        }

        public GenericRepository(TestHaylesEntities _context)
        {
            this._context = _context;
            this._dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return this._dbSet.ToList();
        }

        public T GetByID(object id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T entity = this.GetByID(id);
            _dbSet.Remove(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public int Save()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
