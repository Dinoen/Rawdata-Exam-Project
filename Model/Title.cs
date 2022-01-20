using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Raw5MovieDb_WebApi.Model
{
    public partial class Title
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("tconst")]
        public string Tconst { get; set; }

        [JsonProperty("titletype")]
        public string Titletype { get; set; }

        [JsonProperty("primarytitle")]
        public string Primarytitle { get; set; }

        [JsonProperty("originaltitle")]
        public string Originaltitle { get; set; }

        [JsonProperty("isadult")]
        public bool Isadult { get; set; }

        [JsonProperty("startyear")]
        public string Startyear { get; set; }

        [JsonProperty("endyear")]
        public string Endyear { get; set; }

        [JsonProperty("runtimeminutes")]
        public int? Runtimeminutes { get; set; }

        public IList<TitleGenre> Genres { get; set; }

        public TitleRating TitleRating { get; set; }

        public OmdbData OmdbData { get; set; }

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
