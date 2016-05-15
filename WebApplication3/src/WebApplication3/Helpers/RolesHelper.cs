using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Identity;

namespace WebApplication3.Helpers
{
    public class RolesHelper
    {
        private readonly UserManager<ApplicationUser> _securityManager;
        private AppDbContext _context;

        public RolesHelper(UserManager<ApplicationUser> secMgr, AppDbContext context)
        {
            _securityManager = secMgr;
            _context = context;    
        }

        //new List<string>() { string, string }
        public async Task addRoles(string currentUserName, IEnumerable<string> roles)
        {
            var currentUser = _context.Users.FirstOrDefault(x => x.UserName == currentUserName);
            await _securityManager.AddToRolesAsync(currentUser, roles);
        }

        //new List<string>() { string, string }
        public async Task removeRoles(string currentUserName, IEnumerable<string> roles)
        {
            var currentUser = _context.Users.FirstOrDefault(x => x.UserName == currentUserName);
            await _securityManager.RemoveFromRolesAsync(currentUser, roles);
        }
    }
}
