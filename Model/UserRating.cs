using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Raw5MovieDb_WebApi.Model
{
    public class UserRating
    {
        [JsonProperty("rating")]
        public long Rating { get; set; }

        [JsonProperty("uconst")]
        public string Uconst { get; set; }

        [JsonProperty("tconst")]
        public string Tconst { get; set; }
    }
}