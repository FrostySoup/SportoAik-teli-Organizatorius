using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Services.ChallongeModels
{
    internal class ParticipantWrapper
    {
        [JsonProperty("participant")]
        public Participant Participant { get; set; }

        [JsonProperty("api_key")]
        public string ApiKey { get; set; }
    }

    public class Participant
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
