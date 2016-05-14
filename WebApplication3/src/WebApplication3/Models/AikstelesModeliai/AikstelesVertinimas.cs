using WebApplication3.Models.Identity;

namespace WebApplication3.Models.AikstelesModeliai
{
    public class AikstelesVertinimas
    {
        public string ID { get; set; }
        public int Vertinimas { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Aikstele Aikstele { get; set; }
    }
}