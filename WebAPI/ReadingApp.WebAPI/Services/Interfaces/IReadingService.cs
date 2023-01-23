using ReadingApp.Infrastructure.DTOs;
using ReadingApp.Infrastructure.Entities;

namespace ReadingApp.WebAPI.Services.Interfaces
{
    public interface IReadingService
    {
        int Create(ReadingCreateDto readingCreateDto);
        void Delete(int id);
        void DeleteAll();
        IEnumerable<ReadingDto> ReadAll();
        ReadingDto? ReadAt(int id);
        void Update(ReadingUpdateDto raadingUpdateDto);
    }
}