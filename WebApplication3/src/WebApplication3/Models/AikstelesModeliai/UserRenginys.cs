using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Identity;

namespace WebApplication3.Models.AikstelesModeliai
{
    public class UserRenginys
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        
        public string RenginysId { get; set; }
        public Renginys Renginys { get; set; }
    }
}
