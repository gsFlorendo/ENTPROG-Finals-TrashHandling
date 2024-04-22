using System.ComponentModel.DataAnnotations;

namespace TrashHandling.Models
{
    public class TrashCollectionViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Truck Plate Number")]
        public string TruckPlateNumber { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        [Display(Name = "Staff")]
        public string StaffAssigned { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(4)]
        [Display(Name = "Type of Trash")]
        public string TypeofTrash { get; set; }
        [Required]
        [Display(Name = "Deployment Date")]
        public DateTime DeployedDate { get; set; }
    }
}
