using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Siemens.MP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Siemens.MP.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : AbstractEntity
    {
        private readonly ApplicationDbContext _context = null;
        private readonly DbSet<T> table = null;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GenericRepository(ApplicationDbContext _context, IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
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
           beforeInsert(obj);
           table.Add(obj);
           Save();
        }

        private void beforeInsert(T obj)
        {
            obj.CreatedById = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            obj.ModifiedById = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            obj.CreatedAt = DateTime.Now;
            obj.ModifiedAt = DateTime.Now;
        }

        private void beforeUpdate(T obj)
        {
            obj.ModifiedById = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            obj.ModifiedAt = DateTime.Now;
        }

        public void Delete(object id)
        {
            T obj = table.Find(id);
            table.Remove(obj);
        }
        public void Update(T obj)
        {
            beforeUpdate(obj);
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
