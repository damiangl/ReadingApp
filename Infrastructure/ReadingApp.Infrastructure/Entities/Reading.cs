using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ReadingApp.Infrastructure.Entities
{
    [Table("reading")]
    public class Reading
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String? Name { get; set; }
        public String? Description { get; set; }
        public String? AdditionalPropertyProcessor { get; set; }
        public bool Enabled { get; set; }

        List<ReadingItem>? Items { get; set; }
    }
}
