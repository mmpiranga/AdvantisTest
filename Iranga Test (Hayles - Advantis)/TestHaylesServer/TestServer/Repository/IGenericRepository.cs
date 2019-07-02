using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(object id);
        IEnumerable<T> Get(Func<T, bool> predicate);
        void Insert(T entity);
        void Update(T entity);
        void Delete(object id);
        void Delete(T entity);
        int Save();
    }
}
