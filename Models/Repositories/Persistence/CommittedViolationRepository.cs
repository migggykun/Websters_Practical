using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Websters.ViewModels;

namespace Websters.Models.Repositories.Persistence
{
    public class CommittedViolationRepository : Repository<Violation>
    {
        public CommittedViolationRepository(AppDbContext context)
            : base(context)
        {
        }

        public void Add(FineViewModel entity)
        {
            var cv = new CommitedViolation()
            {
                userID = entity.Violator.Id,
                violationID = entity.Violation.id,
                isPaid = false,
                dateAdded = DateTime.Now
            };

           appDbContext.CommitedViolations.Add(cv);
        }

        private AppDbContext appDbContext
        {
            get
            {
                return _context as AppDbContext;
            }
        }
    }
}