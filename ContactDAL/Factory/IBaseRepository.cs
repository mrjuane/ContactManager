using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactDAL.Factory
{
    public interface IBaseRepository<T> : IDisposable
    {
        T GetEntity(int id);
        int Insert(T entity);
        int Update(T entity);
        bool Delete(int id);
        IEnumerable<T> GetAll();
    }
}
