using AutoMapper;
using ReadingApp.Shared.DTOs;
using ReadingApp.Shared.Entities;

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
