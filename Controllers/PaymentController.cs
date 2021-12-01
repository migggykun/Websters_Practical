using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Websters.Models;
using Websters.Models.Repositories.UnitOfWork;
using Websters.ViewModels;

namespace Websters.Controllers
{

        [Authorize]
        [RoutePrefix("Payment")]
        public class PaymentController : Controller
        {
            private readonly AppDbContext _context;

            public PaymentController()
            {
                _context = new AppDbContext();
            }

            public ActionResult Index(PaymentViewModel p)
            {

                UnitOfWork unitOfWork = new UnitOfWork(_context);
                Payment payment = new Payment()
                {
                    committedViolationId = p.committedViolationId,
                    amountTendered = p.amountTendered,
                    change = p.amountTendered - p.price,
                    datePaid = DateTime.Now
                };

                unitOfWork.Payments.Add(payment);
                unitOfWork.Complete();
                return Redirect("Violator/Index");
            }

            [Route("History")]
            public ActionResult History()
            {

                UnitOfWork unitOfWork = new UnitOfWork(_context);
                var paymentLogs = unitOfWork.Payments.GetPaymentLogs();
                ViewBag.paymentLogs = paymentLogs;
                return View();
            }

        }
}