using AutoMapper;
using Raw5MovieDb_WebApi.Model;

namespace Raw5MovieDb_WebApi.ViewModels.Profiles
{
    public class TitleProfile : Profile
    {
        public TitleProfile()
        {
            CreateMap<Title, TitleViewModel>();
        }
    }
}
