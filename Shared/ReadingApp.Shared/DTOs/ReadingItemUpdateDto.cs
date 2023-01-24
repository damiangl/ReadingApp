using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingApp.Shared.DTOs
{
    public class ReadingItemUpdateDto
    {
        public int Id { get; set; }
        public DateTime ReadingDate { get; set; }
        public Double ReadingValue { get; set; }
    }
}
