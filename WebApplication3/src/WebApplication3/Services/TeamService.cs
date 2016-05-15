using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Identity;
using WebApplication3.Models.TurnyroModeliai;

namespace WebApplication3.Services
{
    public class TeamService
    {
        private static TeamService instance;

        private TeamService() { }

        public static TeamService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TeamService();
                }
                return instance;
            }
        }

        public Komanda getUserTeam(AppDbContext context, ApplicationUser currentUser) {
            return context.Komanda.Where(m => m.Kapitonas.Id == currentUser.Id).FirstOrDefault();
        }
    }
}
