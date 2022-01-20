using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Raw5MovieDb_WebApi.Model
{
    public class TitleEpisode
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("tconst")]
        public string Tconst { get; set; }

        [JsonProperty("parenttconst")]
        public string Parenttconst { get; set; }

        [JsonProperty("seasonnumber")]
        public long Seasonnumber { get; set; }

        [JsonProperty("episodenumber")]
        public long Episodenumber { get; set; }
    }
}