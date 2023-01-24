using AutoMapper;
using ReadingApp.Shared.DTOs;
using ReadingApp.Shared.Entities;
using ReadingApp.WebAPI.Helpers;

namespace ReadingApp.WebAPI.MappingProfiles
{
    public class ReadingMappingProfile: Profile
    {
        public ReadingMappingProfile()
        {
            CreateMap<Reading, ReadingDto>()
                .ForMember(m => m.AdditionalPropertyProcessorValue, o => o.MapFrom(s => AdditionalPropertyProcessorHandler.GetAdditionalPropertyProcessorValue(s)));
            CreateMap<ReadingCreateDto, Reading>()
                .ForMember(m => m.Enabled, o => o.MapFrom(s => true));
            CreateMap<ReadingUpdateDto, Reading>();
        }
    }
}
