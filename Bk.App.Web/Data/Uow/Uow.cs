using Bk.App.Web.Data.Context;
using Bk.App.Web.Data.Interfaces;
using Bk.App.Web.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bk.App.Web.Data.Uow
{
    public class Uow:IUow
    {
        private BKContext _context;
        public Uow(BKContext context)
        {
            _context = context;
        }
        public IGenericRepository<T> GetGenericRepository<T>() where T:class,new()
        {
            return new GenericRepository<T>(_context);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
