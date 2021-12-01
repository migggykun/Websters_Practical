using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Websters.Models.Repositories.Persistence;

namespace Websters.Models.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly ApplicationDbContext _Identitycontext;
        public ViolationRepository Violations { get; set; }
        public CommittedViolationRepository CommitedViolations { get; set; }
        public AccountRepository Accounts { get; set; }
        public PaymentRepository Payments { get; set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Violations = new ViolationRepository(_context);
            CommitedViolations = new CommittedViolationRepository(_context);
            Payments = new PaymentRepository(_context);
        }

        public UnitOfWork(ApplicationDbContext context)
        {
            _Identitycontext = context;
            Accounts = new AccountRepository(_Identitycontext);
        }

        /// <summary>
        /// Reflect changes to database
        /// </summary>
        /// <returns></returns>
        public int Complete()
        {
            return _context.SaveChanges();
        }

        //Disconnects connection with external resources
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}