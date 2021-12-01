using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Websters.ViewModels;

namespace Websters.Models.Repositories.Persistence
{
    public class ViolationRepository : Repository<Violation>
    {
           
        public ViolationRepository(AppDbContext context) : base(context)
        {

        }

        public List<CommitedViolationViewModel> GetViolationsOfUser(string userId)
        {
            var violations = from cv in appDbContext.CommitedViolations
                             join vi in appDbContext.Violations on cv.violationID equals vi.id
                             where cv.userID == userId
                             select new { 
                             cvId = cv.id,
                             violation = vi
                             };

            List<CommitedViolationViewModel> commitedViolations = new List<CommitedViolationViewModel>();

            foreach (var v in violations)
            {

                commitedViolations.Add(
                new CommitedViolationViewModel()
                {
                    Id = v.cvId,
                    Violation = v.violation
                }
                );

            }

            return commitedViolations;

        }

        private AppDbContext appDbContext
        {
            get
            {
                return _context as AppDbContext;
            }
        }

        private ApplicationDbContext IdentityDbContext
        {
            get
            {
                return new ApplicationDbContext();
            }
        }

        
    }
}