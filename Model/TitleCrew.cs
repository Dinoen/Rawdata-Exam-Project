using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Raw5MovieDb_WebApi.Model
{
    public class TitleCrew
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("tconst")]
        public string Tconst { get; set; }

        [JsonProperty("directors")]
        public string Directors { get; set; }

        [JsonProperty("writers")]
        public string Writers { get; set; }
    }
}