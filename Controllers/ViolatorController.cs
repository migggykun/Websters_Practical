using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Websters.Models;
using Websters.Models.Repositories.UnitOfWork;

namespace Websters.Controllers
{
    [Authorize]
    [RoutePrefix("Violator")]
    public class ViolatorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ViolatorController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            UnitOfWork unitOfWork = new UnitOfWork(_context);
            var users = unitOfWork.Accounts.GetAll();
            ViewBag.violators = users;
            return View();
        }

        [Route("GetList")]
        public ActionResult GetList()
        {
            UnitOfWork unitOfWork = new UnitOfWork(_context);
            var users = unitOfWork.Accounts.GetAll();
            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}