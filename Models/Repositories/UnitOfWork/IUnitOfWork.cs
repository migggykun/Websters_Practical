using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websters.Models.Repositories.Persistence;

namespace Websters.Models.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ViolationRepository Violations { get; set; }
        CommittedViolationRepository CommitedViolations { get; set; }
        AccountRepository Accounts { get; set; }
        PaymentRepository Payments { get; set; }
    }
}
