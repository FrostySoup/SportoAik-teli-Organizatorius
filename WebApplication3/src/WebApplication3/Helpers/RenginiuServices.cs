using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.DataHelpers;
using WebApplication3.Models.AikstelesModeliai;
using WebApplication3.Models.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

namespace WebApplication3.Helpers
{
    static public class RenginiuServices
    {
        static public TupleBoolUser checkJoin(AppDbContext _context, string email, string renginioId)
        {
            var currentUser = _context.Users
                .Where(x => x.Email == email)
                .FirstOrDefault();
            bool canJoin = true;
            var renginys = _context.Renginiai
                .Where(r => r.RenginysID == renginioId)
                .Include(x => x.UserRenginys)
                .ThenInclude(r => r.ApplicationUser)
                .FirstOrDefault();
            List<ApplicationUser> user = new List<ApplicationUser>();
            if (renginys != null)
                foreach (UserRenginys u in renginys.UserRenginys)
                {                   
                    if (u.ApplicationUserId.Equals(currentUser.Id))
                        canJoin = false;
                    user.Add(currentUser = _context.Users
                        .Where(x => x.Id == u.ApplicationUserId)
                        .FirstOrDefault());
                }
            return new TupleBoolUser(canJoin, user);
        }
    }
}
