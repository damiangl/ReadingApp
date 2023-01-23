using ReadingApp.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReadingApp.Infrastructure.DTOs
{
    public class ReadingDto
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public String? Description { get; set; }
        public String? AdditionalPropertyProcessorValue { get; set; }

        List<ReadingItemDto>? Items { get; set; }
    }
}
