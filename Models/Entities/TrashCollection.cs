using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrashHandling.Models.Entities
{
    public class TrashCollection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 4)]
        [RegularExpression("^[A-Za-z\\s-]+$", ErrorMessage = "Only letters, spaces, and dashes are allowed.")]
        public string TruckPlateNumber { get; set; }
        public string StaffAssigned { get; set; }
        public string TypeofTrash { get; set; }
        public DateTime? DeployedDate { get; set; }
    }
}
