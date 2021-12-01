using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Websters.Models;
using Websters.Models.Repositories.UnitOfWork;
using Websters.ViewModels;

namespace Websters.Controllers
{
    [Authorize]
    [RoutePrefix("Violation")]
    public class ViolationController : Controller
    {
        private readonly AppDbContext _context;

        public ViolationController()
        {
            _context = new AppDbContext();
        }


        public ActionResult Index()
        {
            UnitOfWork unitOfWork = new UnitOfWork(_context);
            var violations = unitOfWork.Violations.GetAll();
            ViewBag.violations = violations;
            return View("ViolationsView");
        }

        [Route("AddViolation")]
        public ActionResult DisplayAddViolation()
        {
            return View("AddViolationForm");
        }

        public ActionResult Add(Violation violation)
        {
            UnitOfWork unitOfWork = new UnitOfWork(_context);
            unitOfWork.Violations.Add(violation);
            unitOfWork.Complete();
            return new RedirectResult("~/Violation/Index");
        }


        public ActionResult Delete(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(_context);
            var violation = unitOfWork.Violations.Get(id);
            if (violation != null)
            {
                unitOfWork.Violations.Remove(violation);
            }
            unitOfWork.Complete();
            return new RedirectResult("~/Violation/Index");
        }


        [Route("GetList")]
        public ActionResult GetList()
        {
            UnitOfWork unitOfWork = new UnitOfWork(_context);
            var violations = unitOfWork.Violations.GetAll().ToList();
            List<Violation> list = new List<Violation>();
            foreach (var v in violations)
            {
                list.Add(v as Violation);
            }


          return Json(list, JsonRequestBehavior.AllowGet);
        }

        [Route("GetUserViolations")]
        public ActionResult GetUserViolations(string Id, string name)
        {
            UnitOfWork unitOfWork = new UnitOfWork(_context);
            
            var violations = unitOfWork.Violations.GetViolationsOfUser(Id);
            ViewBag.violations = violations;
            ViewBag.name = name;
            return View("UserViolations");
        }

        [Route("Pay/{id}/{vId}")]
        public ActionResult Pay(int id,int vId)
        {
            UnitOfWork unitOfWork = new UnitOfWork(_context);
            var violation = unitOfWork.Violations.Get(vId);
            ViewBag.violation = violation;
            ViewBag.committedViolationId = id;
            return View();
        }
    }
}