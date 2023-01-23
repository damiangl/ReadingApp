using ReadingApp.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReadingApp.Infrastructure.DTOs
{
    public class ReadingItemDto
    {
        public int Id { get; set; }
        public DateTime ReadingDate { get; set; }
        public Double ReadingValue { get; set; }

        public int ReadingId { get; set; }
        public ReadingDto? Reading { get; set; }
    }
}
