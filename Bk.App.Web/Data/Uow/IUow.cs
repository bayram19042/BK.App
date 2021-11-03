using Bk.App.Web.Data.Interfaces;

namespace Bk.App.Web.Data.Uow
{
    public interface IUow
    {

        IGenericRepository<T> GetGenericRepository<T>() where T : class, new();
        void SaveChanges();
        

        }
}