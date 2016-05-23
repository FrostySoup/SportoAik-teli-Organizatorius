using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Services.ChallongeModels;
using Flurl.Http;
using WebApplication3.Models.TurnyroModeliai;

namespace WebApplication3.Services
{
    public class ChallongeService
    {
        private const string apiKey = "LQaugevNzjBY1EoU7lfpvbyeyWFeUI6vWGP4tgWo";

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static async Task StartTournament(string challongeAddress)
        {
            var address = "https://api.challonge.com/v1/tournaments/" + challongeAddress + "/start.json";

            var apiKeyOnly = new ApiKeyOnly()
            {
                ApiKey = apiKey,
            };

            var result = await address
            .PostJsonAsync(apiKeyOnly)
            .ReceiveJson().ConfigureAwait(false);
        }

        public static async Task<dynamic> ShowParticipant(TurnyroDalyvis dalyvis, string challongeAddress)
        {
            var address = "https://api.challonge.com/v1/tournaments/" + challongeAddress + "/participants/" + dalyvis.ChallongeId + ".json?api_key=" + apiKey;
            var result = await address
                .GetJsonAsync().ConfigureAwait(false);

            return result;
        }

        public static async Task<dynamic> MatchesIndex(string challongeAddress)
        {
            var address = "https://api.challonge.com/v1/tournaments/" + challongeAddress + "/matches.json?api_key=" + apiKey;
            var result = await address
                .GetJsonAsync().ConfigureAwait(false);

            return result;
        }

        public static async Task<dynamic> AddTeam(Komanda komanda, string challongeAddress)
        {
            var address = "https://api.challonge.com/v1/tournaments/" + challongeAddress + "/participants.json";
            var participant = new ParticipantWrapper()
                {
                    ApiKey = apiKey,
                    Participant = new Participant() {
                        Name = komanda.Pavadinimas,
                        TeamId = komanda.KomandaID.ToString()
                }
            };

            var result = await address
                .PostJsonAsync(participant)
                .ReceiveJson().ConfigureAwait(false);

            return result;
        }

        public static async Task<dynamic> CreateTournament(Turnyras turnyras)
        {
            var tournamentUrl = RandomString(20);
            var tournament = new TournamentWrapper() {
                ApiKey = apiKey,
                Tournament = new Tournament() {
                    Name = turnyras.Pavadinimas,
                    SignupCap = turnyras.KomanduKiekis,
                    HideForum = true,
                    Private = true,
                    Url = tournamentUrl,
                }
            };

            var result = await "https://api.challonge.com/v1/tournaments.json"
                .PostJsonAsync(tournament)
                .ReceiveJson().ConfigureAwait(false);

            //var json = JsonConvert.SerializeObject(request);

            return result;
        }
    }
}
