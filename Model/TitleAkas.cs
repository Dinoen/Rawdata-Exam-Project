using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Raw5MovieDb_WebApi.Model
{
    public class TitleAkas
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("titleid")]
        public string Titleid { get; set; }

        [JsonProperty("ordering")]
        public long Ordering { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("types")]
        public string Types { get; set; }

        [JsonProperty("attributes")]
        public string Attributes { get; set; }

        [JsonProperty("isoriginaltitle")]
        public bool Isoriginaltitle { get; set; }
    }
}