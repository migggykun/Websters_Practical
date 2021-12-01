using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Websters.ViewModels;

namespace Websters.Models.Repositories.Persistence
{
    public class PaymentRepository : Repository<Payment>
    {
           
        public PaymentRepository(AppDbContext context) : base(context)
        {

        }


        public List<PaymentLogViewModel> GetPaymentLogs()
        {
            var paymentLogs = from cv in appDbContext.CommitedViolations
                             join vi in appDbContext.Violations on cv.violationID equals vi.id
                             join p in appDbContext.Payments on cv.id equals p.committedViolationId
                             select new
                             {
                                 paymentId = p.id,
                                 violationName = vi.name,
                                 violationPrice = vi.price,
                                 dateCommitted = cv.dateAdded,
                                 amountTendered = p.amountTendered,
                                 datePaid = p.datePaid,
                                 userId = cv.userID
                             };

            var z = from p in paymentLogs.AsEnumerable()
                    join x in IdentityDB.GetAll() on p.userId equals x.Id
                          select new
                          {
                              paymentId = p.paymentId,
                              violationName = p.violationName,
                              violationPrice = p.violationPrice,
                              dateCommitted = p.dateCommitted,
                              amountTendered = p.amountTendered,
                              userId = p.userId,
                              datePaid = p.datePaid,
                              violator = x.UserName
                          };

            List<PaymentLogViewModel> payments = new List<PaymentLogViewModel>();

            foreach (var p in z)
            {

                payments.Add(
                new PaymentLogViewModel()
                {
                    transactionID = p.paymentId,
                    name = p.violationName,
                    price = p.violationPrice,
                    dateCommitted = p.dateCommitted,
                    datePaid = p.datePaid,
                    amountTendered = p.amountTendered,
                    violator = p.violator
                }
                );

            }

            return payments;
        }
        private AppDbContext appDbContext
        {
            get
            {
                return _context as AppDbContext;
            }
        }

        private AccountRepository IdentityDB
        {
            get
            {
                return new AccountRepository(new ApplicationDbContext());
            }
        }
        
    }
}