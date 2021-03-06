﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Services.ChallongeModels
{
    internal class TournamentWrapper
    {
        [JsonProperty("tournament")]
        public Tournament Tournament { get; set; }

        [JsonProperty("api_key")]
        public string ApiKey { get; set; }
    }

    public class Tournament
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("private")]
        public bool Private { get; set; }

        [JsonProperty("hide_forum")]
        public bool HideForum { get; set; }

        [JsonProperty("signup_cap")]
        public int SignupCap { get; set; }
    }
}
