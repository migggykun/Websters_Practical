using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Websters.Models.Repositories.UnitOfWork;
using Websters.ViewModels;

namespace Websters.Controllers
{
    [RoutePrefix("CommittedViolation")]
    public class CommittedViolationController : Controller
    {

        private readonly AppDbContext _context;


        public CommittedViolationController()
        {
            _context = new AppDbContext();
        }

        // GET: CommittedViolation
        public ActionResult Index()
        {
            return View();
        }

        
        [Route("AddFine")]
        public ActionResult AddFine()
        {
            return View("AddFine");
        }

        [Route("Add")]
        public ActionResult AddFine(FineViewModel fineVM)
        {

            UnitOfWork unitOfWork = new UnitOfWork(_context);
            unitOfWork.CommitedViolations.Add(fineVM);
            unitOfWork.Complete();
            return new RedirectResult("~/Violator/Index");
        }
    }
}