using Bk.App.Web.Data.Context;
using Bk.App.Web.Data.Entities;
using Bk.App.Web.Data.Interfaces;
using Bk.App.Web.Data.Uow;
using Bk.App.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bk.App.Web.Controllers
{
    public class AccountController : Controller
    {
        //private readonly BKContext _context;
        //private readonly IApplicationUserMapping _userMapping;
        //private readonly IApplicationUserRepositories    _userRepositories;
        //private readonly IAccountMapper _accountMapper;
        //private readonly IAccountRepositories _accountRepositories;
        //public AccountController(BKContext context, IApplicationUserMapping userMapping,IApplicationUserRepositories userRepositories,IAccountRepositories accountRepositories,IAccountMapper accountMapper)
        //{
        //    _context = context;
        //    _userMapping = userMapping;
        //    _userRepositories = userRepositories;
        //    _accountMapper = accountMapper;
        //    _accountRepositories = accountRepositories;
        //}


        private readonly IUow _uow;
        public AccountController(IUow uow)
        {
            _uow = uow;
        }
        public IActionResult Create(int id)
        {
            
           
            
            return View(_uow.GetGenericRepository<ApplicationUser>().getById(id));
        }
        [HttpPost]
        public IActionResult Create(AccountCreateModel model)
        {
            
            _uow.GetGenericRepository<Account>().Create(new Account
            {
                Balance = model.Balance,
                ApplicationUserId = model.ApplicationUserId,
                AccountNumber = model.AccountNumber
            });
            _uow.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult AccountList(int userid)
        {
            var users = _uow.GetGenericRepository<ApplicationUser>().getList();
            var  user = users.SingleOrDefault(x => x.Id == userid);
            ViewBag.Name = user.Name;
            ViewBag.Surname = user.Surname;
            var account = _uow.GetGenericRepository<Account>().getList();
            var accounts = account.Where(x => x.ApplicationUserId == userid).ToList();
            var list = new List<AccountListModel>();
            foreach(var item in accounts)
            {
                list.Add(new AccountListModel()
                {
                    Id = item.Id,
                    Balance = item.Balance,
                    AccountNumber = item.AccountNumber,
                    ApplicationUserId = item.ApplicationUserId
                });
            }
            return View(list);
        }
        [HttpGet]
        public IActionResult SendMoney(int accountId)
        {
            ViewBag.senderId = accountId;
            var accounts = _uow.GetGenericRepository<Account>().getList();
            var accountList = accounts.Where(x => x.Id != accountId);
            var list =new List<AccountListModel>();
            foreach(var item in accountList)
            {
                list.Add(new AccountListModel()
                {
                    Id = item.Id,
                    Balance = item.Balance,
                    AccountNumber = item.AccountNumber,
                    ApplicationUserId = item.ApplicationUserId
                });
            }
            return View(new SelectList(list,"Id","AccountNumber"));
        }

        [HttpPost]
        public IActionResult SendMoney(SendMoneyModel model)
        {
            var senderaccount = _uow.GetGenericRepository<Account>().getById(model.SenderId);
            senderaccount.Balance -= model.Amount;
            _uow.GetGenericRepository<Account>().Update(senderaccount);
            var account = _uow.GetGenericRepository<Account>().getById(model.AccountId);
            account.Balance += model.Amount;
            _uow.GetGenericRepository<Account>().Update(account);
            _uow.SaveChanges();
            return RedirectToAction("Index","home");
        }

    }
}
