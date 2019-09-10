using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siemens.MP.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApplicationDbContext _context = null;
        private DbSet<T> table = null;

        public GenericRepository(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public System.Threading.Tasks.Task<List<T>> GetAll()
        {
            List<T> obj = new List<T>();
            using (var context = new ApplicationDbContext())
            {
                obj = (from objs in table select objs).ToList();
            }
            return System.Threading.Tasks.Task.FromResult(obj);
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
            Save();
        }
        public void Delete(object id)
        {

        }
        public void Update(T obj)
        {

        }
        public void Save()
        {

        }
    }
}
