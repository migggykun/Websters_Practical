using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Websters.Models.Repositories.Persistence
{
    public class AccountRepository
    {
        private readonly ApplicationDbContext _context;
        private IQueryable<ApplicationUser> Users;


        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var userManager = new UserManager<ApplicationUser>(userStore);
            Users = userManager.Users;
        }

        public List<ApplicationUser> GetAll()
        {
            return Users.ToList();
        }
    }
}
