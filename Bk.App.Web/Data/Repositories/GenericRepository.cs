using Bk.App.Web.Data.Context;
using Bk.App.Web.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bk.App.Web.Data.Repositories
{
    public class GenericRepository<T>:IGenericRepository<T> where T:class , new()
    {
        private readonly BKContext _context;
        public GenericRepository(BKContext context)
        {
            _context = context;
        }
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
           
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            
        }
        public List<T> getAll()
        {
            return _context.Set<T>().ToList();
        }
        public T getById(object id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> getList()
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}
