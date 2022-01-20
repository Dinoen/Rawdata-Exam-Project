using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Raw5MovieDb_WebApi.Model
{
public partial class OmdbData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("tconst")]
        public string Tconst { get; set; }

        [JsonProperty("poster")]
        public Uri Poster { get; set; }

        [JsonProperty("awards")]
        public string Awards { get; set; }

        [JsonProperty("plot")]
        public string Plot { get; set; }

        public Title Title { get; set; }
    }
}