using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //Provides attribute classes that are used to
                                             //define metadata for ASP.NET MVC and ASP.NET
                                             //data controls.
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Newtonsoft.Json; //Newtonsoft er den package som gør at vi kan arbejde med JSON
using Newtonsoft.Json.Converters;

//NuGet er en package manager


namespace Raw5MovieDb_WebApi.Model
{
    public class Actor
    {

        //JsonProperty fortæller JsonSerializeren at Nconst skal hedde nconst når den converteres 
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        [JsonProperty("nconst")]
        public string Nconst { get; set; }

        [JsonProperty("primaryname")]
        public string Primaryname { get; set; }

        [JsonProperty("birthyear")]
        public string Birthyear { get; set; }

        [JsonProperty("deathyear")]
        public string Deathyear { get; set; }

        [JsonProperty("primaryprofession")]
        public string Primaryprofession { get; set; }

        [JsonProperty("knownfortitles")]
        public string Knownfortitles { get; set; }

        [JsonProperty("namerating")] 
        public double? Namerating { get; set; }

        public Actor()
        {
            
        }

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}