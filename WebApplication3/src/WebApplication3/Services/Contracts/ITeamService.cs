using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Identity;
using WebApplication3.Models.TurnyroModeliai;

namespace WebApplication3.Services.Contracts
{
    public interface ITeamService
    {
        Komanda getUserTeam(AppDbContext context, ApplicationUser currentUser);
    }
}
