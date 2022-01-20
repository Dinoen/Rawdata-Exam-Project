using AutoMapper;
using Raw5MovieDb_WebApi.Model;

namespace Raw5MovieDb_WebApi.ViewModels.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreViewModel>();
        }
    }
}
