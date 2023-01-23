using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReadingApp.Infrastructure.Entities
{
    [Table("reading_item")]
    public class ReadingItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime ReadingDate { get; set; }
        public Double ReadingValue { get; set; }
        public bool Enabled { get; set; }

        public int ReadingId { get; set; }
        public Reading? Reading { get; set; }
    }
}
