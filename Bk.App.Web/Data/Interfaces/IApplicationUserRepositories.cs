using Bk.App.Web.Data.Entities;
using System.Collections.Generic;

namespace Bk.App.Web.Data.Interfaces
{
    public interface IApplicationUserRepositories
    {
        List<ApplicationUser> GetAll();
        ApplicationUser GetById(int id);
    }
}