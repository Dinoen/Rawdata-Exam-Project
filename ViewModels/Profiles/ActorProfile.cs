using AutoMapper;
using Raw5MovieDb_WebApi.Model;

namespace Raw5MovieDb_WebApi.ViewModels.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, ActorViewModel>();
        }
    }
}
