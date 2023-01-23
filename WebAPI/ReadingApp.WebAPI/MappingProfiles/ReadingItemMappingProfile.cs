using AutoMapper;
using ReadingApp.Infrastructure.DTOs;
using ReadingApp.Infrastructure.Entities;

namespace ReadingApp.WebAPI.MappingProfiles
{
    public class ReadingItemMappingProfile : Profile
    {
        public ReadingItemMappingProfile()
        {
            CreateMap<ReadingItem, ReadingItemDto>();
            CreateMap<ReadingItemCreateDto, ReadingItem>()
                .ForMember(m => m.Enabled, o => o.MapFrom(s => true));
            CreateMap<ReadingItemUpdateDto, ReadingItem>();
        }
    }
}
