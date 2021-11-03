using Bk.App.Web.Data.Entities;
using Bk.App.Web.Data.Interfaces;
using Bk.App.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bk.App.Web.Mapping
{
    public class ApplicationUserMapping:IApplicationUserMapping
    {
        public List<UserListModel> MapToUseList(List<ApplicationUser> users)
        {
            return users.Select(x => new UserListModel()
            {
                Id=x.Id,
                Name = x.Name,
                Surname = x.Surname
            }).ToList();
        }

        public UserListModel MapToUser(ApplicationUser users)
        {
            return new UserListModel()
            {
                Id=users.Id,
                Name=users.Name,
                Surname=users.Surname
            };
        }

       
    }
}
