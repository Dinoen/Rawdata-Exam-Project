using AutoMapper;
using Raw5MovieDb_WebApi.Model;

namespace Raw5MovieDb_WebApi.ViewModels.Profiles
{
    public class TitleRatingProfile : Profile
    {
        public TitleRatingProfile()
        {
            CreateMap<TitleRating, TitleRatingViewModel>();
        }
    }
}
