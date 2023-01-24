using ReadingApp.Shared.DTOs;

namespace ReadingApp.WebAPI.Services.Interfaces
{
    public interface IReadingItemService
    {
        int Create(ReadingItemCreateDto readingCreateDto);
        void Delete(int id);
        void DeleteAll();
        IEnumerable<ReadingItemDto> ReadAll();
        IEnumerable<ReadingItemDto> ReadAt(int readingId);
        void Update(ReadingItemUpdateDto raadingUpdateDto);
    }
}