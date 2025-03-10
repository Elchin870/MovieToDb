using AutoMapper;
using CityManagerApi2.Dtos;
using CityManagerApi2.Entities;

namespace CityManagerApi2.Mappers
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<City, CityForListDto>()
                .ForMember(dest => dest.PhotoUrl, option =>
                {
                    option.MapFrom(src => src.CityImages.FirstOrDefault(c => c.IsMain).Url);
                });

            CreateMap<City, CityDto>().ReverseMap();
                
        }
    }
}
