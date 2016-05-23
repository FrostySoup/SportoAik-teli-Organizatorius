using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Services.ChallongeModels
{
    public class ApiKeyOnly
    {

        [JsonProperty("api_key")]
        public string ApiKey { get; set; }
    }
}
