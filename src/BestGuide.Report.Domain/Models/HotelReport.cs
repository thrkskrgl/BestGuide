using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BestGuide.Report.Domain.Enums;

namespace BestGuide.Report.Domain.Models
{
    [Table("HotelReport", Schema = "report")]
    public class HotelReport
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public ReportStatus Status { get; set; }

        [Required]
        [MaxLength(250)]
        public string Location { get; set; }

        public int HotelCount { get; set; }

        public int TelephoneCount { get; set; }

        [MaxLength(50)]
        public string? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [MaxLength(50)]
        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
