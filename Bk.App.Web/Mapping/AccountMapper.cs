using Bk.App.Web.Data.Entities;
using Bk.App.Web.Data.Interfaces;
using Bk.App.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bk.App.Web.Mapping
{
    public class AccountMapper:IAccountMapper
    {
        public Account AccountMapTo(AccountCreateModel model)
        {
            return new Account()
            {
                Balance = model.Balance,
                AccountNumber = model.AccountNumber,
                ApplicationUserId = model.ApplicationUserId

            };
        }
    }
}
