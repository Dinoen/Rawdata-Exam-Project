using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Raw5MovieDb_WebApi.Model
{
    public class UserSearchHistory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("search_id")]
        public int SearchId { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("uconst")]
        public string Uconst { get; set; }
    }
}