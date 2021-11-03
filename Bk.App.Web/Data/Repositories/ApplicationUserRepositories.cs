using Bk.App.Web.Data.Context;
using Bk.App.Web.Data.Entities;
using Bk.App.Web.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bk.App.Web.Data.Repositories
{
    public class ApplicationUserRepositories : IApplicationUserRepositories
    {
        private readonly BKContext _context;
        public ApplicationUserRepositories(BKContext context)
        {
            _context = context;
        }
        public List<ApplicationUser> GetAll()
        {
            return _context.ApplicationUsers.ToList();
        }

        public ApplicationUser GetById(int id)
        {
            return _context.ApplicationUsers.SingleOrDefault(x=>x.Id==id);
        }
    }
}
