using AutoMapper;
using ReadingApp.Shared.DTOs;
using ReadingApp.Shared.Entities;
using ReadingApp.WebAPI.DbContexts;
using ReadingApp.WebAPI.Services.Interfaces;

namespace ReadingApp.WebAPI.Services
{
    public class ReadingItemService : IReadingItemService
    {
        private readonly ReadingDbContext dbContext;
        private readonly IMapper mapper;
        private readonly ILogger<ReadingItemService> logger;

        public ReadingItemService(ReadingDbContext dbContext, IMapper mapper, ILogger<ReadingItemService> logger)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.logger = logger;
        }

        public int Create(ReadingItemCreateDto readingCreateDto)
        {
            var readingItem = mapper.Map<ReadingItem>(readingCreateDto);
            dbContext.ReadingItems.Add(readingItem);
            dbContext.SaveChanges();
            return readingItem.Id;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReadingItemDto> ReadAll()
        {
            var readingItems = dbContext.ReadingItems.Where(w => w.Enabled.Equals(true));
            var readingItemDtos = mapper.Map<List<ReadingItemDto>>(readingItems);
            return readingItemDtos;
        }

        public IEnumerable<ReadingItemDto> ReadAt(int readingId)
        {
            var readingItems = dbContext.ReadingItems.Where(w => w.Enabled.Equals(true) && w.ReadingId.Equals(readingId));
            var readingItemDtos = mapper.Map<List<ReadingItemDto>>(readingItems);
            return readingItemDtos;
        }

        public void Update(ReadingItemUpdateDto raadingUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
