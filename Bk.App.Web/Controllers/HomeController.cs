
using Bk.App.Web.Data.Context;
using Bk.App.Web.Data.Entities;
using Bk.App.Web.Data.Interfaces;
using Bk.App.Web.Data.Repositories;
using Bk.App.Web.Data.Uow;
using Bk.App.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bk.App.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IApplicationUserMapping _userMapping;
        //private readonly IApplicationUserRepositories _applicationUser;
        //private readonly BKContext _context;
        //public HomeController(BKContext context,IApplicationUserRepositories applicationUser, IApplicationUserMapping userMapping)
        //{
        //    _context = context;
        //    _applicationUser = applicationUser;
        //    _userMapping = userMapping;
        //}
        //private readonly IGenericRepository<ApplicationUser> _genericUserRepository;
        //public HomeController(IGenericRepository<ApplicationUser> genericUserRepository)
        //{
        //    _genericUserRepository = genericUserRepository;
        //}
        private readonly IUow _uow;
        public HomeController(IUow uow)
        {
            _uow = uow;
        }
        public IActionResult Index()
        {
            var list =_uow.GetGenericRepository<ApplicationUser>().getAll();
            
            return View(list);
        }
    }
}
