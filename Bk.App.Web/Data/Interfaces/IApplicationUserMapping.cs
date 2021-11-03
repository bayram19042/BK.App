using Bk.App.Web.Data.Entities;
using Bk.App.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bk.App.Web.Data.Interfaces
{
    public interface IApplicationUserMapping
    {
        List<UserListModel> MapToUseList(List<ApplicationUser> users);
        UserListModel MapToUser(ApplicationUser users);
    }
}
