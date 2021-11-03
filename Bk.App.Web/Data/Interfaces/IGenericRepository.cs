using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bk.App.Web.Data.Interfaces
{
   public interface IGenericRepository<T> where T:class,new()
    {

        void Create(T entity);

        void Delete(T entity);


        void Update(T entity);

        List<T> getAll();

        T getById(object id);


        IQueryable<T> getList();
       
    }
}
