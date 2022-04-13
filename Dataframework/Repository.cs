using System;
using System.Collections.Generic;
using System.Linq;
using Dataframework.Context;
using Dataframework.Interface;
using Microsoft.EntityFrameworkCore;

namespace Dataframework
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly TirisanContext _context;
        public Repository()
        {
            this._context = new TirisanContext();
        }

        public IEnumerable<T> GetAll() => this._context.Set<T>().ToList();

        public IEnumerable<T> GetWhere(Func<T, bool> filters) => this._context.Set<T>().Where(filters).ToList();
  
        public void Insert(T instance)
        {
            this._context.Set<T>().Add(instance);
            _context.SaveChanges();
        }

        public void Update(T instance)
        {
            _context.Entry(instance).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(T key)
        {
            _context.Set<T>().Remove(key);
            _context.SaveChanges();
        }
    }
}