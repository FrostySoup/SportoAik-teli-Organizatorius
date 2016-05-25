using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Identity;
using WebApplication3.Models.TurnyroModeliai;
using WebApplication3.Services.Contracts;

namespace WebApplication3.Services
{
    public class TeamService : ITeamService
    {
        public Komanda getUserTeam(AppDbContext context, ApplicationUser currentUser) {
            return context.Komanda.Where(m => m.Kapitonas.Id == currentUser.Id).FirstOrDefault();
        }
    }
}
