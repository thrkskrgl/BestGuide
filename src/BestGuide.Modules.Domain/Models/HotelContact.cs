using BestGuide.Modules.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BestGuide.Modules.Domain.Models
{
    [Table("HotelContact", Schema = "modules")]
    public class HotelContact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public HotelContactType Type { get; set; }

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        [Required]
        public Guid HotelId { get; set; }

        [ForeignKey("HotelId")]
        public virtual Hotel Hotel { get; set; }
    }
}
