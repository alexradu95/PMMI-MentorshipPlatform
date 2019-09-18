using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siemens.MP.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context = null;
        private readonly DbSet<T> table = null;

        public GenericRepository(ApplicationDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        public async System.Threading.Tasks.Task<List<T>> GetAll()
        {
            List<T> obj = new List<T>();
            using (var context = new ApplicationDbContext())
            {
                obj = (from objs in table select objs).ToList();
            }
            return await System.Threading.Tasks.Task.FromResult(obj);
        }
        public virtual async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
            Save();
        }
        public void Delete(object id)
        {
            T obj = table.Find(id);
            table.Remove(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
