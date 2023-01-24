using ReadingApp.Shared.DTOs;
using ReadingApp.Shared.Entities;

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