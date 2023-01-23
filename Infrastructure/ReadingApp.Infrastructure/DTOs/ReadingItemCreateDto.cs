using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingApp.Infrastructure.DTOs
{
    public class ReadingItemCreateDto
    {
        public DateTime ReadingDate { get; set; }
        public Double ReadingValue { get; set; }

        public int ReadingId { get; set; }
    }
}
