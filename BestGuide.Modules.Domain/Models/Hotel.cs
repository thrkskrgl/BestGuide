using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BestGuide.Modules.Domain.Models
{
    [Table("Hotel", Schema = "modules")]
    public class Hotel
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string? AuthorizedName { get; set; }

        [MaxLength(100)]
        public string? AuthorizedSurname { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [MaxLength(50)]
        public string? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public HashSet<HotelContact> Contacts { get; set; } = [];
    }
}
