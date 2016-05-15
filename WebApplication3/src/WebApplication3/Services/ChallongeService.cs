using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Services.ChallongeModels;
using Flurl.Http;
using WebApplication3.Models.TurnyroModeliai;

namespace WebApplication3.Services
{
    public class ChallongeService
    {
        public static async Task AddTeam(Komanda komanda)
        {
            var participant = new ParticipantWrapper()
            {
                ApiKey = "LQaugevNzjBY1EoU7lfpvbyeyWFeUI6vWGP4tgWo",
                Participant = new Participant() { Name = komanda.Pavadinimas }
            };

            var result = await "https://api.challonge.com/v1/tournaments/12321512/participants.json"
                .PostJsonAsync(participant)
                .ReceiveJson();
        }

        public static async Task CreateTournament()
        {
            var tournament = new TournamentWrapper() {
                ApiKey = "LQaugevNzjBY1EoU7lfpvbyeyWFeUI6vWGP4tgWo",
                Tournament = new Tournament() { Name = "Pirmas turnyras", Url = "1232152112" }
            };

            var result = await "https://api.challonge.com/v1/tournaments.json"
                .PostJsonAsync(tournament)
                .ReceiveJson();
        }
    }
}
