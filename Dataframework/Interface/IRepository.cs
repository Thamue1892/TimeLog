using System;
using System.Collections.Generic;

namespace Dataframework.Interface
{
    public interface IRepository<T> where T : class, new()
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetWhere(Func<T, bool> filters);
        void Insert(T instance);
        void Update(T instance);
        void Delete(T key);
    }

}