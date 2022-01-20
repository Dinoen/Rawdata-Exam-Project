using Raw5MovieDb_WebApi.Model;
using System;
using System.Collections.Generic;

namespace Raw5MovieDb_WebApi.ViewModels
{
    public class TitleViewModel
    {
        public string Tconst { get; set; }
        public string Url { get; set; }
        public string Actors { get; set; }
        public string Titletype { get; set; }
        public string Primarytitle { get; set; }
        public string Originaltitle { get; set; }
        public bool Isadult { get; set; }
        public string Startyear { get; set; }
        public string Endyear { get; set; }
        public int Runtimeminutes { get; set; }
        public IList<GenreViewModel> GenreList { get; set; }
        public TitleRatingViewModel ImdbRating { get; set; }
        public OmdbDataViewModel OmdbData { get; set; }
    }
}
