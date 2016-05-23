namespace WebApplication3.Models.TurnyroModeliai
{

    public class TurnyroDalyvis
    {
        public int KomandaID { get; set; }
        public Komanda Komanda { get; set; }

        public int TurnyrasID { get; set; }
        public Turnyras Turnyras { get; set; }

        public long ChallongeId { get; set; }
    }
}