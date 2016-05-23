using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Services.ChallongeModels
{
    internal class ShowParticipantWrapper
    {
        [JsonProperty("participant")]
        public Participant Participant { get; set; }

        [JsonProperty("api_key")]
        public string ApiKey { get; set; }
    }

    public class ShowParticipant
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("misc")]
        public string TeamId { get; set; }
    }
}
