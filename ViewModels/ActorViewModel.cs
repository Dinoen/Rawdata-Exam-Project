using System;
namespace Raw5MovieDb_WebApi.ViewModels
{

    //De her klasser er de objekter som bliver sendt videre til webbet via controllerne
    public class ActorViewModel
    {
        public string Nconst { get; set; }
        public string Url { get; set; }
        public string Primaryname { get; set; }
        public string Birthyear { get; set; }
        public string Deathyear { get; set; }
        public string Primaryprofession { get; set; }
        public string Knownfortitles { get; set; }
        public double Namerating { get; set; }
    }
}
