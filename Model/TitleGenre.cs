using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raw5MovieDb_WebApi.Model
{
    public class TitleGenre
    {
        [JsonProperty("tconst")]
        public string TitleTconst { get; set; }

        [JsonProperty("genreid")]
        public int GenreId { get; set; }
        
        public Genre Genre { get; set; }
    }
}
