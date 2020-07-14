using Newtonsoft.Json;
using System;
using time_ghost.Core.Helpers;

namespace time_ghost.Core.Models
{
    [Serializable]
    public class Timer
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        [JsonConverter(typeof(GuidJsonConverter))]
        public Guid Id { get; set; }
    }
}
