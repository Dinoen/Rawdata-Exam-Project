using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Raw5MovieDb_WebApi.Model
{
    public class TitlePrincipals
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("tconst")]
        public string Tconst { get; set; }

        [JsonProperty("ordering")]
        public long Ordering { get; set; }

        [JsonProperty("nconst")]
        public string Nconst { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("job")]
        public string Job { get; set; }

        [JsonProperty("characters")]
        public string Characters { get; set; }
    }
}