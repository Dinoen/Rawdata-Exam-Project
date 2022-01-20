using AutoMapper;
using Raw5MovieDb_WebApi.Model;

namespace Raw5MovieDb_WebApi.ViewModels.Profiles
{
    public class OmdbDataProfile : Profile
    {
        public OmdbDataProfile()
        {
            CreateMap<OmdbData, OmdbDataViewModel>();
        }
    }
}
