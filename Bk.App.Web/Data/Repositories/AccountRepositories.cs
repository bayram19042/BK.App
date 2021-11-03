using Bk.App.Web.Data.Context;
using Bk.App.Web.Data.Entities;
using Bk.App.Web.Data.Interfaces;
using Bk.App.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bk.App.Web.Data.Repositories
{
    public class AccountRepositories : IAccountRepositories
    {
        private readonly BKContext _context;
        public AccountRepositories(BKContext context)
        {
            _context = context;
        }
        public void Create(Account model)
        {
            _context.Accounts.Add(model);
            _context.SaveChanges();
        }
    }
}
