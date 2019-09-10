using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Siemens.MP.Data.Repositories
{
    public interface IGenericRepository<T> where T: class
    {
        System.Threading.Tasks.Task<List<T>> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Delete(object id);
        void Update(T obj);
        void Save();

    }
}
